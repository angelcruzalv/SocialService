using System;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using cecati_117.Models;
using System.Net;
using Microsoft.AspNet.Identity.EntityFramework;
using cecati_117.Areas.Admin.ClasesCompartidas;

namespace cecati_117.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CuentasController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        #region Constructores necesarios para acceder a cuentas de usuario
        public CuentasController()
        {
        }

        public CuentasController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        #endregion

        #region Pagina con lista de usuarios
        public ActionResult Index()
        {
            //Mas información de este codigo aqui https://www.c-sharpcorner.com/article/list-of-users-with-roles-in-mvc-asp-net-identity/ //
            //Aqui le decimos que obtenga el usuario actual y la cuenta de usuario por default para que no pueda ser eliminada mientras se ejecuta la lista
            ApplicationUser usuarioLogeado = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.FullName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UsuariosConRoles()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            var usuarios = usersWithRoles.Where(x => x.Email != "cecati117.2018@gmail.com" && x.Email != usuarioLogeado.Email).ToList();
            return View(usuarios);
        }
        #endregion

        #region Pagina para registro de usuarios
        public ActionResult Registro()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registro(RegisterViewModel model, FormCollection form)
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    string rolname = form["RoleName"];
                    result = UserManager.AddToRole(user.Id, rolname); //registro de usuario al rol https://www.codeproject.com/Questions/808785/Adding-user-to-role-upon-registration-mvc //

                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);  lo comenté porque sino la cuenta que acabas de crear se logea y quita a la otra cuenta

                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar correo electrónico con este vínculo
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }
        #endregion

        #region Rutina para borrar un usuario seleccionado de la lista
        public ActionResult BorrarUsuario(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string singleString = "";
            var us = context.Users.Where(x => x.Id == id).ToList();
            foreach (var name in us)
            {
                singleString = String.Join(",", name.UserName);
            }

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(singleString, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.Delete(user);

            return RedirectToAction("Index");
        } 
        #endregion

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}