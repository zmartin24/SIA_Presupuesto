using SIA_Presupuesto.WinForm.General.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ColeccionDetalleModulosHelper : CollectionBase
    {
        ControlBase propietario;

        public ColeccionDetalleModulosHelper(ControlBase propietario)
        {
            this.propietario = propietario;
        }

        public ControlDetalleBase this[int indice]
        {
            get
            {
                if (List.Count > indice)
                    return List[indice] as ControlDetalleBase;
                return null;
            }
        }

        ControlDetalleBase esDetalleExistente(ControlDetalleBase valor)
        {
            foreach (ControlDetalleBase detalle in List)
                if (detalle.ID == valor.ID)
                    return detalle;
            return null;
        }

        public bool esDetalleExistente(int codigo)
        {
            foreach (ControlDetalleBase detalle in List)
                if (detalle.Codigo == codigo)
                {
                    propietario.DetalleControlActivo = detalle;
                    return true;
                }
            return false;
        }

        public bool estaSucioDetalleExistente()
        {
            foreach (ControlDetalleBase detalle in List)
                if (detalle.Ocupado) return true;
            return false;
        }

        public void Agregar(ControlDetalleBase valor)
        {
            ControlDetalleBase existeDetalle = esDetalleExistente(valor);
            if (existeDetalle == null)
            {
                List.Add(valor);
                propietario.DetalleControlActivo = valor;
            }
            else
            {
                valor.Dispose();
                propietario.DetalleControlActivo = existeDetalle;
            }
            //propietario.RibbonMenuController.CalcCloseAllDetails();
        }

        public void Eliminar(ControlDetalleBase valor)
        {
            int indice = List.IndexOf(valor);

            if (List.Contains(valor))
                List.Remove(valor);

            if (indice != -1 && List.Count > 0)
            {
                if (indice >= List.Count)
                    indice = List.Count - 1;
                propietario.DetalleControlActivo = (ControlDetalleBase)List[indice];
            }
            else
                propietario.DetalleControlActivo = null;

            if (valor != null)
                valor.Dispose();
            //propietario.RibbonMenuController.CalcCloseAllDetails();
        }

        public void EliminarTodo(bool closeEditing)
        {
            for (int i = List.Count - 1; i >= 0; i--)
            {
                ControlDetalleBase temp = this[i];
                if (temp.Ocupado && !closeEditing) continue;
                List.RemoveAt(i);
                temp.Dispose();
            }
            propietario.DetalleControlActivo = null;
            //propietario.RibbonMenuController.CalcCloseAllDetails();
        }

        internal void OcularDetalles()
        {
            foreach (ControlDetalleBase detalle in List)
                detalle.Hide();
        }
    }
}
