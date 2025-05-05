using Rest.Api.Compras.Sql.Repository;
using Rest.Api;
using Rest.Api.Domain1.Infraestructura;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Rest.Api.Domain1.Repositorio
{
    public class RepositorioArticulos : IRepositorioArticulos
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly comprasEntities entidad;
        public RepositorioArticulos()
        {
            entidad = new comprasEntities();
        }
        public List<articulos> GetAllArticulos()
        {
            return entidad.articulos.ToList();
        }
        public articulos GetArticuloByCodBarras(string codigoBarras)
        {
            try
            {
                // select * from articulos where cod_barras == codigoBarras
                articulos articulo = entidad.articulos.FirstOrDefault(p => p.cod_barras.Equals(codigoBarras));
                return articulo;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

        }
        public List<articulos> GetAllArticulosByStock()
        {
            List<articulos> articulo = new List<articulos>();
            try
            {
                articulo = entidad.articulos.Where(p => p.stock_min > 100).ToList();
                return articulo;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return articulo;
            }

        }
        public List<articulos> GetAllArticulosTake(int total)
        {
            // total es igual a 5
            //select top(5) * from articulos
            return entidad.articulos.Take(total).ToList();
        }
        public List<articulos> GetAllArticulosStartByName(string descripcion)
        {
            //select * from articulos where descripcion like'a%'
            return entidad.articulos.Where(p => p.descripcion.StartsWith(descripcion)).ToList();
        }
        public decimal GetPriceArticleMax()
        {
            //select max(precio_venta) as precio_venta from articulos
            return (decimal)entidad.articulos.Max(p => p.precio_venta);
        }
        public bool InsertarArticulo(articulos articulo)
        {
            try
            {
                entidad.articulos.Add(articulo);
                entidad.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool EliminarArticulo(string codigoBarras)
        {
            bool result = false;
            try
            {
                articulos articulo = entidad.articulos.FirstOrDefault(p => p.cod_barras.Equals(codigoBarras));
                entidad.articulos.Remove(articulo);
                if (entidad.SaveChanges() > 0)
                {
                    result = true;
                }
                return result;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return result;
            }
        }
    }
}
