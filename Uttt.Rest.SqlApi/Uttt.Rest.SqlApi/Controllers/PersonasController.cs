using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Uttt.Rest.SqlApi.Domain;
using Uttt.Rest.SqlApi.Dto;
using Uttt.Rest.SqlApi.Infraestructure;
using Uttt.Rest.SqlApi.Services;

namespace Uttt.Rest.SqlApi.Controllers
{
    [RoutePrefix ("api/personas")]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class PersonasController : ApiController
    {
        private readonly IServicesPersonas servicesPersonas;
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public PersonasController()
        {
            servicesPersonas = new ServicesPersonas();
        }

        //consultar todo
        [Route("all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Personas> personas = servicesPersonas.GetAll();
            //maper para regresar el dto
            List <PersonasDto> personasDto = AutoMapper.Mapper.Map<List<PersonasDto>>(personas);
            return Ok(personasDto);
        }

        //insertar 
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar(PersonasDto personas)
        {
            try
            {
                Personas persona = AutoMapper.Mapper.Map<Personas>(personas);
                if (servicesPersonas.Insertar(persona))
                {
                    return Ok("Se realizo la accion correctamente");
                }
                else
                {
                    logger.Error("Error.");
                    return BadRequest($"Existen errores en la insercción");
                }
                
            }catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest($"Existen errores en la insercción: {ex.Message}");
            }
        }

        // actualizar
        [HttpPut]
        [Route("actualizar/{id}")]
        public IHttpActionResult Actualizar(int id, PersonasDto personas)
        {
            try
            {
                Personas persona = AutoMapper.Mapper.Map<Personas>(personas);
                if(servicesPersonas.Actualizar(id, persona))
                {
                    return Ok("Se realizo la actualizacion correctamente");
                }
                else
                {
                    return BadRequest($"Existen errores en la insercción");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest($"Existen errores en la insercción: {ex.Message}");
            }
        }

        // eliminar
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IHttpActionResult Eliminar(int id)
        {
            try
            {
                if (servicesPersonas.Eliminar(id))
                {
                    return Ok("Los datos se eliminaron correctamente");
                }
                else
                {
                    return BadRequest($"Existen errores en la eliminación");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest($"Existen errores en la eliminación: {ex.Message}");
            }
        }

        // consultar by id
        [HttpGet]
        [Route("consultar/{id}")]
        public IHttpActionResult GetId(int id)
        {
            try
            {
                Personas personas = servicesPersonas.GetById(id);
                PersonasDto personasDto = AutoMapper.Mapper.Map<PersonasDto>(personas);
                if(personasDto != null)
                {
                    return Ok(personasDto);
                }
                else
                {
                    return BadRequest($"Existen errores en la consulta");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest($"Existen errores en la consulta: {ex.Message}");
            }
        }
    }
}
