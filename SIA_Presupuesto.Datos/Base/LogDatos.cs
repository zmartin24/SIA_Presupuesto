using SIA_Presupuesto.Datos.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using Seguridad.Log;
using Seguridad.Servicio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Base
{
    public class LogDatos
    {
        private UsuarioOperacion usuInfo;
        private IOcurrencia ocurrencia;
        //private static IOcurrencia ocurrenciaError;

        public LogDatos(UsuarioOperacion usuInfo, IOcurrencia ocurrencia)
        {
            this.usuInfo = usuInfo;
            this.ocurrencia = ocurrencia;
            //ocurrenciaError = ocurrencia;
        }

        public void RegistrarLog(string descripcion, TipoAccion tipoAccion)
        {
            if (usuInfo == null) return;
            ocurrencia.RegistraInformacion(usuInfo.IDSistema, usuInfo.IDUsuario, DateTime.Now, usuInfo.NomUsuarioPC, usuInfo.IPUsuario, usuInfo.NombrePC, descripcion, tipoAccion);
        }

        //private static void RegistrarError(UsuarioOperacion usuInfo, string descripcion, TipoAccion tipoAccion)
        //{
        //    if (usuInfo == null) return;
        //    ocurrenciaError.RegistraError(usuInfo.IDSistema, usuInfo.IDUsuario, DateTime.Now, usuInfo.NomUsuarioPC, usuInfo.IPUsuario, usuInfo.NombrePC, descripcion, tipoAccion);
        //}

        public void RegistrarError(string descripcion, TipoAccion tipoAccion)
        {
            if (usuInfo == null) return;
            ocurrencia.RegistraError(usuInfo.IDSistema, usuInfo.IDUsuario, DateTime.Now, usuInfo.NomUsuarioPC, usuInfo.IPUsuario, usuInfo.NombrePC, descripcion, tipoAccion);
        }

        public void RegistrarNuevoLogID<TEntidad>(int idLog) where TEntidad : class
        {
            if (idLog > 0)
                RegistrarLog(string.Format(CultureInfo.InvariantCulture, Mensajes.traza_AgregarElementoRepositorioID, typeof(TEntidad).Name, idLog), TipoAccion.Ingreso);
            else
                RegistrarLog(string.Format(CultureInfo.InvariantCulture, Mensajes.traza_AgregarElementoRepositorio, typeof(TEntidad).Name), TipoAccion.Ingreso);
        }
    }
}
