using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uttt.Rest.SqlApi.Domain;

namespace Uttt.Rest.SqlApi.Infraestructure
{
    public interface IServicesDirecciones
    {
        bool Insertar(Direcciones _direccion);
        bool Eliminar(int id);
        Direcciones GetById(int id);
        List<Direcciones> GetAll();
    }
}