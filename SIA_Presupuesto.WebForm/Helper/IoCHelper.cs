using SIA_Presupuesto.IoC.Contenedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Helper
{
    public class IoCHelper
    {
        public static T ResolverIoC<T>() where T : class
        {
            IContenedor contenedor = Fabrica.Instancia.ContenedorActual;
            Encriptador.llave = "SIACORAH.SIA_Presupuesto.OficinaTI2020**";
            Type tipo = typeof(T);
            return contenedor.Resolver(tipo) as T;
        }
    }
}