using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uttt.Rest.SqlApi.Domain;

namespace Uttt.Rest.SqlApi.Infraestructure
{
    public interface IServicesTelefonos
    {
        bool Insertar(Telefonos _telefonos);
        bool Eliminar(int id);
        Telefonos GetById(int id);
        List<Telefonos> GetAll();
    }
}