using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uttt.Rest.SqlApi.Domain;
using Uttt.Rest.SqlApi.Dto;

namespace Uttt.Rest.SqlApi.Infraestructure
{
    public interface IServicesPersonas
    {
        bool Insertar(Personas _personas);
        bool Eliminar(int id);
        Personas GetById(int id);
        List<Personas> GetAll();
        bool Actualizar(int id, Personas personas);
    }
}