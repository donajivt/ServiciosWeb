using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Api.Compras.Common.Web.Dto
{
    public class ArticuloDto
    {
        public string cod_barras { get; set; }
        public string cod_asociado { get; set; }
        public long id_clasificacion { get; set; }
        public string cod_interno { get; set; }
        public string descripcion { get; set; }
        public string descripcion_corta { get; set; }
        public decimal cantidad_um { get; set; }
        public System.Guid id_unidad { get; set; }
        public System.Guid id_proveedor { get; set; }
        public decimal precio_compra { get; set; }
        public decimal utilidad { get; set; }
        public decimal precio_venta { get; set; }
        public string tipo_articulo { get; set; }
        public decimal stock { get; set; }
        public decimal stock_min { get; set; }
        public decimal stock_max { get; set; }
        public Nullable<System.DateTime> kit_fecha_ini { get; set; }
        public Nullable<System.DateTime> kit_fecha_fin { get; set; }
        public bool articulo_disponible { get; set; }
        public bool kit { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public bool visible { get; set; }
        public short puntos { get; set; }
        public System.DateTime last_update_inventory { get; set; }
        public string cve_productos { get; set; }
        public string id_objeto_impuesto { get; set; }
    }
}