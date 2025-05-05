using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using Uttt.Rest.SqlApi.Domain;
using Uttt.Rest.SqlApi.Infraestructure;

namespace Uttt.Rest.SqlApi.Services
{
    public class ServicesPersonas : IServicesPersonas
    {
        private readonly basetestmodelEntities2 testEntities;
        private readonly NLog.Logger logger = LogManager
            .GetLogger("databaseLogger");
        public ServicesPersonas()
        {
            this.testEntities = new basetestmodelEntities2();
        }
        public bool Insertar(Personas _personas)
        {
            bool respuesta = false;
            try
            {
                this.testEntities.Database.Connection.Open();
                if(this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    var Transaction = this.testEntities.Database.BeginTransaction();
                    this.testEntities.Personas.Add(_personas);
                    
                    if(this.testEntities.SaveChanges() > 0)
                    {
                        respuesta = true;
                        Transaction.Commit();
                        return respuesta;
                    }
                    else
                    {
                        respuesta = false;
                        Transaction.Rollback();
                        return respuesta;
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                logger.Error($"La inserccion no se realizó: {ex.Message}");
                return respuesta;
            }
        }
        public bool Eliminar(int id)
        {
            bool respuesta = false;
            try
            {
                this.testEntities.Database.Connection.Open();
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    var Transaction = this.testEntities.Database.BeginTransaction();
                    Personas personas = this.testEntities.Personas.Include("Direcciones").Include("Telefonos").Where(a => a.Id == id).FirstOrDefault();
                    if (personas != null)
                    {
                        this.testEntities.Direcciones.RemoveRange(personas.Direcciones);
                        this.testEntities.Telefonos.Remove(personas.Telefonos);
                        this.testEntities.Personas.Remove(personas);
                        this.testEntities.SaveChanges();
                        Transaction.Commit();
                        respuesta=true;
                    }
                    else
                    {
                        Transaction.Rollback();
                    }
                }
                return respuesta;
            }catch(Exception ex)
            {
                logger.Error("error"+ex);
                return respuesta;
            }
        }
        public Personas GetById(int id)
        {
            Personas personas = new Personas();
            try
            {
                this.testEntities.Database.Connection.Open();
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open )
                {
                }
                personas = this.testEntities.Personas.Include("Telefonos").Include("Direcciones").Where(a => a.Id == id).FirstOrDefault();
                if (personas != null)
                {
                    return personas;
                }
                else
                {
                    return personas;
                }
                
            }
            catch(Exception ex)
            {
                logger.Error("error: "+ex);
                return null;
            }
        }
        public List<Personas> GetAll()
        {
            return this.testEntities.Personas.Include("Telefonos").Include("Direcciones").ToList();
        }
        public bool Actualizar(int id,Personas personas)
        {
            bool respuesta = false;
            try
            {
                this.testEntities.Database.Connection.Open();
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    var Transaction = this.testEntities.Database.BeginTransaction();
                    Personas personaOld = this.testEntities.Personas.FirstOrDefault(a => a.Id == id);
                    if(personaOld != null)
                    {
                        personaOld.Nombre = personas.Nombre;
                        personaOld.ApellidoPaterno = personas.ApellidoPaterno;
                        personaOld.ApellidoMaterno = personas.ApellidoMaterno;
                        personaOld.Rfc = personas.Rfc;
                        personaOld.Edad = personas.Edad;
                        personaOld.Telefonos.TelefonoCelular = personas.Telefonos.TelefonoCelular;
                        personaOld.Telefonos.TelefonoCasa = personas.Telefonos.TelefonoCasa;
                        //this.testEntities.Personas.Add(personaOld);
                        this.testEntities.Entry(personaOld).State = System.Data.Entity.EntityState.Modified;
                        if(this.testEntities.SaveChanges()>0)
                        {
                            respuesta = true;
                            Transaction.Commit();
                            return respuesta;
                        }
                        else
                        {
                            respuesta = false;
                            Transaction.Rollback();
                            return respuesta;
                        }
                    }
                }
                return respuesta;
            }
            catch( Exception ex ) 
            {
                logger.Error($"La actualizacion no se realizó: {ex.Message}");
                return respuesta;
            }
        }
    }
}