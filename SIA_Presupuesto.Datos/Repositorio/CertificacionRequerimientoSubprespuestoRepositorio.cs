using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class CertificacionRequerimientoSubprespuestoRepositorio : Repositorio<CertificacionRequerimientoSubprespuesto>, ICertificacionRequerimientoSubprespuestoRepositorio
    {
        public CertificacionRequerimientoSubprespuestoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }
        
    }
}