using Rest.Api.Compras.Sql.Repository;
using Rest.Api.Domain1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Api.Domain1.Infraestructura
{
    public interface IRepositorioArticulos
    {
        List<articulos> GetAllArticulos();
        articulos GetArticuloByCodBarras(string codigoBarras);
        List<articulos> GetAllArticulosByStock();
        List<articulos> GetAllArticulosTake(int total);
        List<articulos> GetAllArticulosStartByName(string descripcion);
        decimal GetPriceArticleMax();
        bool InsertarArticulo(articulos articulo);
        bool EliminarArticulo(string codigoBarras);
    }
}
