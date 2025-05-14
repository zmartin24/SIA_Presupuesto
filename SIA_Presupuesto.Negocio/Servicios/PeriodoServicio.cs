using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PeriodoServicio : ServicioBase, IPeriodoServicio
    {
        IPeriodoRepositorio repositorio;

        public PeriodoServicio(IPeriodoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Periodo ObtenerxAnio(int anio)
        {
            return repositorio.TraerPorCondicion(t => t.anio == anio);
        }

        public Periodo ObtenerActivo()
        {
            return repositorio.TraerPorCondicion(t => t.estado == "A");
        }

        public List<Periodo> ListaPeriodo()
        {
            return repositorio.TraerTodos().OrderByDescending(x=>x.anio).ToList();
        }
    }
}
