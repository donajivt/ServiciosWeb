using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services;

namespace Test1
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
        const double valorPredefinido = 45.78d;

        [WebMethod]
        public string HelloWorld()
        {
            return "Holiii brou";
        }
        [WebMethod]
        public double sumar(double t, double r)
        {
            return t + r;
        }
        [WebMethod]
        public double restar(double t, double r)
        {
            return t - r;
        }
        [WebMethod]
        public string restar1(double a, double b, double c)
        {
            return (((a - b) + c)+ valorPredefinido).ToString();
        }
        [WebMethod]
        public double multiplicar (double a, double b) { 
            return a * b; 
        }
        [WebMethod]
        public double dividir(double a, double b)
        {
            return a / b;
        }

        [WebMethod]
        public string mayor(double w, double c)
        {
            if (w > c)
            {
                return $"El numero mayor es: {w}";
            }
            else
            {
                return $"El numero mayor es: {c}";
            }
        }
        [WebMethod]
        public string comparacion(double d, double h, double f)
        {
            if(d>h && d> f && h > f) 
            {
                return $"el mayor es: {d}  el mediano es: {h}   el menor es: {f}";
            }else if (h > d && h > f && d > f)
            {
                return $"el mayor es: {h}  el mediano es: {d}   el menor es: {f}";
            }
            else if (f > d && f > h && d > h)
            {
                return $"el mayor es: {f}  el mediano es: {d}   el menor es: {h}";
            }
            else
            {
                return "La comparación necesita más condicionales";
            }
        }
        [WebMethod]
        public string comparacion2(double d, double h, double f)
        {
            string respuesta = "";
            string respuesta2 = "";
            if (d > h && d > f && h > f)
            {
                respuesta = $"el mayor es: {d}\n  el mediano es: {h}\n   el menor es: {f}\n";
                if (d % f == 0)
                {
                    double v=d / f;
                    if(v == h)
                    {
                        respuesta2 = $"El numero intermedio entre {d} y {f} es: {v}";
                                            return respuesta + respuesta2;
                    }
                    else
                    {
                        return respuesta;
                    }
                    
                }
                else
                {
                    return respuesta;
                }
            }
            else if (h > d && h > f && d > f)
            {
                respuesta = $"el mayor es: {h}\n  el mediano es: {d}\n   el menor es: {f}\n";
                if (h % f == 0)
                {
                    double v = h / f;
                    
                    if (v == d)
                    {
                        respuesta2 = $"El numero intermedio entre {h} y {f} es: {v}";
                        return respuesta + respuesta2;

                    }
                    else
                    {
                        return respuesta;
                    }
                }
                else
                {
                    return respuesta;
                }
            }
            else if (f > d && f > h && d > h)
            {
                respuesta = $"el mayor es: {f}\n  el mediano es: {d}\n   el menor es: {h}\n";
                if (f % h == 0)
                {
                    double v = f / h;
                    
                    if (v == d)
                    {
                        respuesta2 = $"El numero intermedio entre {f} y {h} es: {v}";
                        return respuesta + respuesta2;

                    }
                    else
                    {
                        return respuesta;
                    }
                }
                else
                {
                    return respuesta;
                }
            }
            else if (d > h && d > f && f > h)
            {
                respuesta = $"el mayor es: {d}\n  el mediano es: {f}\n   el menor es: {h}\n";
                if (d % h == 0)
                {
                    double v = d / h;
                    
                    if (v == f)
                    {
                        respuesta2 = $"El numero intermedio entre {d} y {h} es: {v}";
                        return respuesta + respuesta2;

                    }
                    else
                    {
                        return respuesta;
                    }
                }
                else
                {
                    return respuesta;
                }
            }
            else if (h > d && h > f && f > d)
            {
                respuesta = $"el mayor es: {h}\n  el mediano es: {f}\n   el menor es: {d}\n";
                if (h % d == 0)
                {
                    double v = h / d;
                    
                    if (v == f)
                    {
                        respuesta2 = $"El numero intermedio entre {h} y {d} es: {v}";
                        return respuesta + respuesta2;

                    }
                    else
                    {
                        return respuesta;
                    }
                }
                else
                {
                    return respuesta;
                }
            }
            else if (f > d && f > h && h > d)
            {
                respuesta = $"el mayor es: {f}\n  el mediano es: {h}\n   el menor es: {d}\n";
                if (f % d == 0)
                {
                    double v = f / d;
                    
                    if (v == h)
                    {
                        respuesta2 = $"El numero intermedio entre {f} y {d} es: {v}";
                        return respuesta + respuesta2;

                    }
                    else
                    {
                        return respuesta;
                    }
                }
                else
                {
                    return respuesta;
                }
            }
            else if (f == d && f == h)
            {
                respuesta = "Los tres números son iguales";
                return respuesta;
            }
            else if (f == d && h > d)
            {
                respuesta = $"los numeros {f} y {d} son iguales\n y el mayor es: {h}";
                return respuesta;
            }
            else if (f == d && d > h)
            {
                respuesta = $"los numeros {f} y {d} son iguales\n y el menor es: {h}";
                return respuesta;
            }
            else if (h == d && h > f)
            {
                respuesta = $"los numeros {h} y {d} son iguales\n y el menor es: {f}";
                return respuesta;
            }
            else if (h == d && f > h)
            {
                respuesta = $"los numeros {h} y {d} son iguales\n y el mayor es: {f}";
                return respuesta;
            }
            else if (h == f && h > d)
            {
                respuesta = $"los numeros {h} y {f} son iguales\n y el menor es: {d}";
                return respuesta;
            }
            else if (h == f && d > h)
            {
                respuesta = $"los numeros {h} y {f} son iguales\n y el mayor es: {d}";
                return respuesta;
            }
            else
            {
                return "La comparación necesita más condicionales";
            }
        }

        [WebMethod]
        public string[] Arreglos()
        {
            string[] almacenamiento = new string[5];
            for (int i = 0; i < almacenamiento.Length; i++)
            {
                almacenamiento[i] = $"El elemento es: {i}";
            }
            return almacenamiento;
        }
        [WebMethod]
        public double[] ArregloDouble()
        {
            double[] almacenamiento = new double[5];
            for (int i = 0; i < almacenamiento.Length; i++)
            {
                almacenamiento[i] = i + (5 * 20) - Math.PI;
            }
            return almacenamiento;
        }
        [WebMethod]
        public double[] ArregloDinamico(string n)
        {
            if (isNumero(n))
            {   
                int x = int.Parse(n);
                double[] almacenamiento = new double[x];
                if (x >= 0)
                {
                    for (int i = 0; i < almacenamiento.Length; i++)
                    {
                        almacenamiento[i] = i + (5 * 20) - Math.PI;
                    }
                    return almacenamiento;
                }
            }
            else
            {
                System.Console.WriteLine("Datos Incorrectos");
                return null;
            }
            return null;
        }
        private  Boolean isNumero(String cadena)
        {
            try
            {
                int.Parse(cadena);
                return true;
            }
            catch (FormatException)
            {
                System.Console.WriteLine("Datos Incorrectos");
                return false;
            }
        }

        [WebMethod]
        public List<string> GetList()
        {
            List<string> lista = new List<string>();
            for(int i = 0; i < 100000; i++)
            {
                lista.Add(Math.PI + i.ToString());
            }
            return lista;
        }
    }
}
