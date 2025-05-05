using NLog;
using Rest.Api.Compras.Sql.Repository;
using Rest.Api.Domain1.Infraestructura;
using Rest.Api.Domain1.Repositorio;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Rest.Api.Compras.Controllers
{
    [RoutePrefix("api/articulos")]
    public class ArticulosController : ApiController
    {
        readonly comprasEntities comprasEntities;
        private readonly IRepositorioArticulos repositorio;
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ArticulosController()
        {
            comprasEntities = new comprasEntities();
            repositorio = new RepositorioArticulos();
        }

        [HttpPost]
        [Route("post")]
        [SwaggerResponse(HttpStatusCode.InternalServerError,
            "Existe un error al insertar las entidades del tipo articulo")]
        [SwaggerOperation("devuelve un listado de entidades tipo articulo")]

        public IHttpActionResult Insert(articulos item)
        {
            try
            {
                repositorio.InsertarArticulo(item);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("No se pudo realizar la operación");
            }
        }
        [HttpGet]
        [Route("get")]
        [SwaggerResponse(HttpStatusCode.InternalServerError,
        "Existe un error al obtener las entidades del tipo articulo")]
        [SwaggerOperation("devuelve un listado de entidades tipo articulo")]
        public IHttpActionResult All()
        {
            try
            {
                var articulo = repositorio.GetAllArticulos();
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("No se pudo realizar la operación");
            }
        }
    }

}
    

