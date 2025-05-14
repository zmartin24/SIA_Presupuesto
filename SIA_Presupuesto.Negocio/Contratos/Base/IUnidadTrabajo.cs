using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Base
{
    public interface IUnidadTrabajo
    {
        int GuardarCambios();
        Task<int> GuardarCambiosAsincronamente();

        void AumentarLatencia(int segundos);
        //void Rollback_Cambios();
        //void ActualizarCambios();
        //DateTime ObtenerFechaServidor();
        //IEnumerable<TEntidad> EjecutarConsulta<TEntidad>(string sqlConsulta, params object[] parametros);
        //int EjecutarComando(string sqlComando, params object[] parametros);
    }
}
