using System;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class PartidaPresupuestalPrecioPres
    {
        public override string ToString()
        {
            return idParPre + "|" + descripcion + "|" + numCuenta + "|" + idUnidad + "|" + precio + "|" + idCueCon;
        }

        public static PartidaPresupuestalPrecioPres Parse(string str)
        {
            string[] strArray = str.Split('|');

            PartidaPresupuestalPrecioPres newInstance = new PartidaPresupuestalPrecioPres()
            {
                idParPre = Convert.ToInt32(strArray[0]),
                descripcion = strArray[1],
                idUnidad = Convert.ToInt32(strArray[2]),
                precio = Convert.ToDecimal(strArray[3]),
                idCueCon = Convert.ToInt32(strArray[4])
            };
            return newInstance;
        }
    }
}
