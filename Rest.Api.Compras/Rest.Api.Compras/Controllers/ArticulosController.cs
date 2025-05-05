using AutoMapper;
using NLog;
using Rest.Api.Compras.Common.Web.DataTransfer;
using Rest.Api.Compras.Common.Web.Dto;
using Rest.Api.Compras.Models;
using Rest.Api.Domain1.Entities;
using Rest.Api.Domain1.Infraestructura;
using Rest.Api.Domain1.Repositorio;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Rest.Api.Compras.Controllers
{
    [RoutePrefix("api/articulos")]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ArticulosController : ApiController
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IRepositorioArticulos repositorio;
        
        private IMapper mapper;
        public ArticulosController() 
        { 
            repositorio = new RepositorioArticulos();
        }
        [HttpPost]
        [Route("insertar")]
        [ResponseType(typeof(ResponseWrapper<List<ArticuloDto>>))]
        [SwaggerResponse(HttpStatusCode.OK, "Se inserta de forma exitosa la carga de todas las entidades",
            typeof(ResponseWrapper<List<articulos>>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError,
            "Existe un error al insertar las entidades del tipo articulo")]
        [SwaggerOperation("devuelve un listado de entidades tipo articulo")]

        public IHttpActionResult Insert( articulos articulo)
        {
            try
            {
                repositorio.InsertarArticulo(articulo);
                return Ok();    
            }catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("No se pudo realizar la operación");
            }
        }
        [HttpGet]
        [Route("all")]
        [ResponseType(typeof(ResponseWrapper<List<ArticuloDto>>))]
        [SwaggerResponse(HttpStatusCode.OK, "Se Obtiene de forma exitosa la carga de todas las entidades",
            typeof(ResponseWrapper<List<ArticuloDto>>))]
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
        [HttpGet]
        [Route("codigo")]
        [ResponseType(typeof(ResponseWrapper<List<ArticuloDto>>))]
        [SwaggerResponse(HttpStatusCode.OK, "Se Obtiene de forma exitosa la carga de todas las entidades",
            typeof(ResponseWrapper<List<ArticuloDto>>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError,
            "Existe un error al obtener las entidades del tipo articulo")]
        [SwaggerOperation("devuelve un listado de entidades tipo articulo")]
        public IHttpActionResult GetByCodBarras(string codigoBarras)
        {
            try
            {
                articulos articulo = repositorio.GetArticuloByCodBarras(codigoBarras);
                if (articulo == null)
                {
                    return NotFound();
                }
                return Ok(new ResponseWrapper<List<ArticuloDto>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Se eencontraron resultados para esta consulta realizada.",
                    Data = AutoMapper.Mapper.Map<List<ArticuloDto>>(articulo)

                });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("No se pudo realizar la operación");
            }
        }
    }
}
