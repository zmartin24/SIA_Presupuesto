using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ColeccionRegistroHelper : CollectionBase
    {
        public Type this[int indice]
        {
            get
            {
                if (List.Count > indice)
                    return List[indice] as Type;
                return null;
            }
        }

        public void Agregar(Type valor)
        {
            Type existeDetalle = esExistente(valor);
            if (existeDetalle == null)
                List.Add(valor);
        }

        public void Quitar(Type valor)
        {
            int indice = List.IndexOf(valor);

            if (List.Contains(valor))
                List.Remove(valor);

            if (indice != -1 && List.Count > 0)
            {
                if (indice >= List.Count)
                    indice = List.Count - 1;
            }
        }

        private Type esExistente(Type valor)
        {
            foreach (Type detalle in List)
                if (detalle.FullName == valor.FullName)
                    return detalle;
            return null;
        }

        public Type Buscar(string nombre)
        {
            foreach (Type detalle in List)
                if (detalle.Name == nombre)
                    return detalle;
            return null;
        }
    }
}
