using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using Seguridad.Servicio;

namespace SIA_Presupuesto.Negocio.Contratos.Base
{
    public interface IRepositorio<TEntidad> where TEntidad : class
    {
        UsuarioOperacion UsuarioOperacion { set; }
        IUnidadTrabajo UnidadTrabajo { get; }
        void Agregar(TEntidad entidad);
        void Actualizar(TEntidad entidad);
        void Eliminar(TEntidad entidad);
        void Eliminar(Expression<Func<TEntidad, bool>> codicion);
        bool VerificarExistencia(Expression<Func<TEntidad, bool>> condicion);
        TEntidad TraerPorID(long Id);
        TEntidad TraerPorID(string Id);
        TEntidad TraerPorCondicion(Expression<Func<TEntidad, bool>> codicion);
        List<TEntidad> TraerTodos();
        List<TEntidad> TraerVariosPorCondicion(Expression<Func<TEntidad, bool>> codicion);
        void RegistrarErroresAlLog(string descripcion, TipoAccion tipoAccion);
    }
}
