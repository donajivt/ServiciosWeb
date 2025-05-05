using Login2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Login2.Controllers
{
    public class UsuarioController : ApiController
    {
        ModeloUsuario modelo;
        public UsuarioController()
        {
            modelo = new ModeloUsuario();
        }
        [Authorize(Roles = "Administrador")]
        public String Get()
        {
            return modelo.GetMensajeAdmin();
        }
        [HttpGet]
        [Authorize(Roles = "Usuario")]
        [Route ("api/currito")]
        public String usuario()
        {
            return modelo.GetMensajeUsuario();
        }
    }
}
