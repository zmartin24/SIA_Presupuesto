using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class CertificacionDetalleRepositorio : Repositorio<CertificacionDetalle>, ICertificacionDetalleRepositorio
    {
        public CertificacionDetalleRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        //public List<ProgramacionAnualDetallePres> TraerListaProgramacionAnualDetalle(int idProAnuArea)
        //{
        //    List<ProgramacionAnualDetallePres> lista = new List<ProgramacionAnualDetallePres>();

        //    var contexto = this.UnidadTrabajo as IContexto;
        //    lista = contexto.TraerListaProgramacionAnualDetalle(idProAnuArea).ToList();

        //    return lista;
        //}
    }
}
