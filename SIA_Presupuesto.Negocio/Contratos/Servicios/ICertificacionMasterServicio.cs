using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface ICertificacionMasterServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(CertificacionMaster certificacionMaster);
        Resultado Modificar(CertificacionMaster certificacionMaster);
        Resultado Anular(int opcion, CertificacionMaster certificacionMaster, string usuario);
        #endregion

        #region Busqueda y listas
        CertificacionMaster BuscarPorCodigo(int idCerMas);
        Forebi BuscarForebi(int idForebi);
        Forese BuscarForese(int idForese);
        ForeDetallePoco BuscarForebiDetallePoco(int idForeDet);
        ForeDetallePoco BuscarForeseDetallePoco(int idForeDet);
        List<CertificacionMasterPres> TraerListaCertificacionMaster(int anio);
        List<Forebi> TraerListaForebiTodos();
        List<Forese> TraerListaForeseTodos();
        List<CertificacionRequerimiento> TraerListaCertificacionRequerimiento(int idCerMas);
        ValidarForebisePres ValidarForebise(int idCerMas);

        #endregion
    }
}
