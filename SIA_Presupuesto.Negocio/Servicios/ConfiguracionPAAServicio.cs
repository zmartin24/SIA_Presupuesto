using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class ConfiguracionPAAServicio : IConfiguracionPAAServicio
    {
        private IConfiguracionPAARepositorio repositorio;

        public ConfiguracionPAAServicio(IConfiguracionPAARepositorio vrepositorio)
        {
            this.repositorio = vrepositorio;
        }

        #region Busqueda y Listas
        public List<ConfiguracionPAA> TraerListaConfiguracionPAA(int vidTipConPaa)
        {
            return repositorio.TraerVariosPorCondicion(x => x.idTipConPaa == vidTipConPaa && x.estado != 1).ToList();
        }
        #endregion
    }
}
