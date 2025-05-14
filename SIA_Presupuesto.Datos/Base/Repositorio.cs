using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Globalization;
using Seguridad.Servicio;
using SIA_Presupuesto.Datos.Recursos;
using Seguridad.Log;
using System.Data.Entity.Infrastructure.Interception;

namespace SIA_Presupuesto.Datos.Base
{
    public abstract class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : class
    {
        private readonly IDbSet<TEntidad> dbEstablecida;
        private IContexto contexto;
        protected IOcurrencia ocurrencia = null;
        private LogDatos logDatos;

        private UsuarioOperacion usuInfo;
        public UsuarioOperacion UsuarioOperacion
        {
            set { usuInfo = value; }
        }

        public IUnidadTrabajo UnidadTrabajo
        {
            get
            {
                return contexto as IUnidadTrabajo;
            }
        }
        protected Repositorio(IContexto contexto, IOcurrencia ocurrencia)
        {
            this.contexto = contexto;
            this.ocurrencia = ocurrencia;

            logDatos = new LogDatos(this.usuInfo, ocurrencia);
            DbInterception.Add(new LogInterceptorEF(logDatos));
            dbEstablecida = contexto.Establecer<TEntidad>();
        }

        public virtual void Agregar(TEntidad entidad)
        {
            dbEstablecida.Add(entidad);
        }
        public virtual void Actualizar(TEntidad entidad)
        {
            dbEstablecida.Attach(entidad);
            this.contexto.Entrada(entidad).State = EntityState.Modified;
        }
        public virtual void Eliminar(TEntidad entidad)
        {
            dbEstablecida.Remove(entidad);
        }
        public virtual void Eliminar(Expression<Func<TEntidad, bool>> condicion)
        {
            IEnumerable<TEntidad> objects = dbEstablecida.Where<TEntidad>(condicion).AsEnumerable();
            foreach (TEntidad obj in objects)
                dbEstablecida.Remove(obj);
        }

        public virtual bool VerificarExistencia(Expression<Func<TEntidad, bool>> condicion)
        {
            return dbEstablecida.Any(condicion);
        }

        public virtual TEntidad TraerPorID(long id)
        {
            return dbEstablecida.Find(id);
        }
        public virtual TEntidad TraerPorID(string id)
        {
            return dbEstablecida.Find(id);
        }
        public virtual List<TEntidad> TraerTodos()
        {
            return dbEstablecida.ToList();
        }
        public virtual List<TEntidad> TraerVariosPorCondicion(Expression<Func<TEntidad, bool>> condicion)
        {
            return dbEstablecida.Where(condicion).ToList();
        }
        public TEntidad TraerPorCondicion(Expression<Func<TEntidad, bool>> condicion)
        {
            return dbEstablecida.Where(condicion).FirstOrDefault<TEntidad>();
        }

        public void RegistrarErroresAlLog(string descripcion, TipoAccion tipoAccion)
        {
            logDatos.RegistrarError(descripcion, tipoAccion);
        }

    }
}
