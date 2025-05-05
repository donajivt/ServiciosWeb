using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login2.Models
{
    public class ModeloUsuario
    {
        public String GetMensajeAdmin()
        {
            return "Has sido validado con éxito Administrador :)";
        }
        public String GetMensajeUsuario()
        {
            return "Has sido validado con éxito Usuario :)";
        }
    }
}