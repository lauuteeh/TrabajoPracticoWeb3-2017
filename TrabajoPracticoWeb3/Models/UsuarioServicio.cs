using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
} 