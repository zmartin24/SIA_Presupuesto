using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface ICertificacionMasterRepositorio : IRepositorio<CertificacionMaster>
    {
        #region Operaciones
        bool AnularCertificacionMaster(int opcion, int idCerMas, int tipoReq, string nomUsuario);
        #endregion
        #region Listas
        List<CertificacionMasterPres> TraerListaCertificacionMaster(int anio);
        List<Forebi> TraerListaForebiTodos();
        List<Forese> TraerListaForeseTodos();
        #endregion

        #region Busquedas
        Forebi BuscarForebi(int idForebi);
        Forese BuscarForese(int idForese);
        ForeDetallePoco BuscarForebiDetallePoco(int idForeDet);
        ForeDetallePoco BuscarForeseDetallePoco(int idForeDet);
        ValidarForebisePres ValidarForebise(int idCerMas);
        #endregion

    }
}
