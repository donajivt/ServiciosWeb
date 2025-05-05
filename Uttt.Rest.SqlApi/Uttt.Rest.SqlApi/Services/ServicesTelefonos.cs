using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uttt.Rest.SqlApi.Domain;
using Uttt.Rest.SqlApi.Infraestructure;

namespace Uttt.Rest.SqlApi.Services
{
    public class ServicesTelefonos : IServicesTelefonos
    {
        private readonly basetestmodelEntities2 testEntities;
        private readonly NLog.Logger logger = LogManager
            .GetLogger("databaseLogger");
        public ServicesTelefonos()
        {
            this.testEntities = new basetestmodelEntities2();
        }
        public bool Insertar(Telefonos _telefonos)
        {
            bool respuesta = false;
            try
            {
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    this.testEntities.Database.BeginTransaction();
                    this.testEntities.Telefonos.Add(_telefonos);

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
                    Telefonos telefonos = this.testEntities.Telefonos.Include("Personas").Where(a => a.Id == id).FirstOrDefault();
                    if (telefonos != null)
                    {
                        this.testEntities.Telefonos.Remove(telefonos);
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
        public Telefonos GetById(int id)
        {
            Telefonos telefonos = new Telefonos();
            try
            {
                if (this.testEntities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                }
                telefonos = this.testEntities.Telefonos.Include("Personas").Where(a => a.Id == id).FirstOrDefault();
                if (telefonos != null)
                {
                    return telefonos;
                }
                else
                {
                    return telefonos;
                }

            }
            catch (Exception ex)
            {
                logger.Error("error: " + ex);
                return null;
            }
        }
        public List<Telefonos> GetAll()
        {
            return this.testEntities.Telefonos.Include("Personas").ToList();
        }
    }
}