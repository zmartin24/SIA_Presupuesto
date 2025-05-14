using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaCertificacionPresupuestalVista : IListaBase
    {
        List<CertificacionMasterPres> listaDatosPrincipales { set; }
        List<Anio> listaAnios { set; }
        int anioPresentacion { set; get; }
    }
}
