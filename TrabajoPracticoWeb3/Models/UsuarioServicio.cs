using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class UsuarioServicio
    {
        private static myContext cnt;

        public static Usuarios IniciarSesion(Usuarios us)
        {
            cnt = new myContext();
            var existeUsuario = cnt.Usuarios.Where(x => x.NombreUsuario == us.NombreUsuario && x.Password == us.Password).FirstOrDefault();
            return existeUsuario;
        }

        public static bool ExisteUsuarioEnSesion()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void CerrarSesion()
        {
            FormsAuthentication.SignOut();
        }

        public static int ObtenerUsuario()
        {
            int user_id = 0;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    user_id = Convert.ToInt32(ticket.UserData);
                }
            }
            return user_id;
        }
        public static void AgregarUsuarioASesion(string id)
        {
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("usuario", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddMonths(3);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
