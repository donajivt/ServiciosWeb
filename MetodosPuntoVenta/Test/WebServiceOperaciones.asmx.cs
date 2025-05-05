using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Test
{
    /// <summary>
    /// Descripción breve de WebServiceOperaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceOperaciones : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Holiiiiiii brouuuuu";
        }
        [WebMethod]
        public double precioVenta(double precioCompra)
        {
            double IVA = 0.16;
            double ganacia = 0.2;
            double precioVenta;
            precioVenta = precioCompra + (precioCompra * IVA) + (precioCompra * ganacia);
            return precioVenta;
        }
        [WebMethod]
        public double descuentoMayoreo(int stock, double precioCompra)
        {
            if(stock>20)
            {
                double descuento = precioCompra * 0.10;
                precioCompra = precioCompra-descuento;
                return precioCompra;
            }
            else
            {
                return precioCompra;
            }
        }
        [WebMethod]
        public double precioWiskey(double precioCompra)
        {
            double IVA = 0.16;
            double ganacia = 0.2;
            double ISR = 0.025;
            double precioVenta;
            precioVenta = precioCompra + (precioCompra * IVA) + (precioCompra * ganacia)+(precioCompra * ISR);
            return precioVenta;
        }
        [WebMethod]
        public double precioTequila(double precioCompra)
        {
            double IVA = 0.16;
            double ganacia = 0.2;
            double ISR = 0.08;
            double precioVenta;
            precioVenta = precioCompra + (precioCompra * IVA) + (precioCompra * ganacia) + (precioCompra * ISR);
            return precioVenta;
        }
        [WebMethod]
        public double precioCerveza(double precioCompra)
        {
            double IVA = 0.16;
            double ganacia = 0.2;
            double ISR = 0.09;
            double precioVenta;
            precioVenta = precioCompra + (precioCompra * IVA) + (precioCompra * ganacia) + (precioCompra * ISR);
            return precioVenta;
        }
        [WebMethod]
        public double precioCoñaq(double precioCompra)
        {
            double IVA = 0.16;
            double ganacia = 0.2;
            double ISR = 0.32;
            double precioVenta;
            precioVenta = precioCompra + (precioCompra * IVA) + (precioCompra * ganacia) + (precioCompra * ISR);
            return precioVenta;
        }
        [WebMethod]
        public double precioMedicamentos(double precioCompra)
        {
            double IVA = 0;
            double ganacia = 0.2;
            double precioVenta;
            precioVenta = precioCompra + (precioCompra * IVA) + (precioCompra * ganacia);
            return precioVenta;
        }
        [WebMethod]
        public int IvaExento()
        {
            return 0;
        }
        [WebMethod]
        public double descuentoPromocion5(double precioVenta)
        {
            double descuento = precioVenta * 0.05;
            precioVenta = precioVenta - descuento;
            return precioVenta;

        }
        [WebMethod]
        public double descuentoPromocion6(double precioVenta)
        {
            double descuento = precioVenta * 0.06;
            precioVenta = precioVenta - descuento;
            return precioVenta;

        }
        [WebMethod]
        public double descuentoPromocion7(double precioVenta)
        {
            double descuento = precioVenta * 0.07;
            precioVenta = precioVenta - descuento;
            return precioVenta;

        }
        [WebMethod]
        public double descuentoPromocion8(double precioVenta)
        {
            double descuento = precioVenta * 0.08;
            precioVenta = precioVenta - descuento;
            return precioVenta;

        }
        [WebMethod]
        public double descuentoPromocion9(double precioVenta)
        {
            double descuento = precioVenta * 0.09;
            precioVenta = precioVenta - descuento;
            return precioVenta;

        }
        [WebMethod]
        public double descuentoPromocion10(double precioVenta)
        {
            double descuento = precioVenta * 0.10;
            precioVenta = precioVenta - descuento;
            return precioVenta;

        }
        [WebMethod]
        public double impuestoCoñaq(double precioCompra)
        {
            double ISR = 0.32;
            return precioCompra * ISR;
        }
        [WebMethod]
        public double impuestoWiskey(double precioCompra)
        {
            double ISR = 0.025;
            return precioCompra * ISR;
        }
        [WebMethod]
        public double impuestoTequila(double precioCompra)
        {
            double ISR = 0.08;
            return precioCompra * ISR;
        }
        [WebMethod]
        public double impuestoCerveza(double precioCompra)
        {
            double ISR = 0.09;
            return precioCompra * ISR;
        }
        [WebMethod]
        public double impuestoIVA(double precioCompra)
        {
            return  precioCompra * 0.16;
        }
    }
}
