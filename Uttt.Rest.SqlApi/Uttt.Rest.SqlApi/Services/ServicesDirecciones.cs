using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uttt.Rest.SqlApi.Domain;
using Uttt.Rest.SqlApi.Infraestructure;

namespace Uttt.Rest.SqlApi.Services
{ 
    public class ServicesDirecciones : IServicesDirecciones
    {
        private readonly basetestmodelEntities2 testEntities;
        private readonly NLog.Logger logger = LogManager
            .GetLogger("databaseLogger");
        public ServicesDirecciones() 
        {
            this.testEntities = new basetestmodelEntities2();
        }
        public bool Insertar(Direcciones _direccion)
        {
            bool respuesta = false;
            try
            {
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    this.testEntities.Database.BeginTransaction();
                    this.testEntities.Direcciones.Add(_direccion);

                    if (this.testEntities.SaveChanges() > 0)
                    {
                        respuesta = true;
                        this.testEntities.Database.BeginTransaction().Commit();
                    }
                    else
                    {
                        respuesta = false;
                        this.testEntities.Database.BeginTransaction().Rollback();
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                logger.Error("error" + ex);
                return respuesta;
            }
        }
        public bool Eliminar(int id)
        {
            bool respuesta = false;
            try
            {
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    this.testEntities.Database.BeginTransaction();
                    Direcciones direcciones = this.testEntities.Direcciones.Include("Personas").Where(a => a.Id == id).FirstOrDefault();
                    if (direcciones != null)
                    {
                        this.testEntities.Direcciones.Remove(direcciones);
                        this.testEntities.SaveChanges();
                        this.testEntities.Database.BeginTransaction().Commit();
                        respuesta = true;
                    }
                    else
                    {
                        this.testEntities.Database.BeginTransaction().Rollback();
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                logger.Error("error" + ex);
                return respuesta;
            }
        }
        public Direcciones GetById(int id)
        {
            Direcciones direcciones = new Direcciones();
            try
            {
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                }
                direcciones = this.testEntities.Direcciones.Include("Personas").Where(a => a.Id == id).FirstOrDefault();
                if (direcciones != null)
                {
                    return direcciones;
                }
                else
                {
                    return direcciones;
                }

            }
            catch (Exception ex)
            {
                logger.Error("error: " + ex);
                return null;
            }
        }
        public List<Direcciones> GetAll()
        {
            return this.testEntities.Direcciones.Include("Personas").ToList();
        }
    }
}