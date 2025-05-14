using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.Enumeradores
{
    public static class Estados
    {
        public const int Anulado = 1;
        public const int Activo = 2;
        public const int Provisionado = 3;
        public const int SinRendir = 4;
        public const int EnRendicion = 5;
        public const int Rendido = 6;
        public const int EnLiquidacion = 7;
        public const int SinControl = 8;
        public const int ConControl = 9;
        public const int Aprobado = 10;
        public const int Rechazado = 11;
        public const int EnProceso = 19;
        public const int EnviadoAprovision = 47;
        public const int Tramitado = 55;
        public const int Fraccionado = 56;
        public const int Pagado = 57;
        public const int Cerrado = 58;
        public const int Asignado = 59;
        public const int Liquidado = 60;
        public const int NoRecuperable = 61;
        public const int SinConciliar = 62;
        public const int Conciliado = 63;
        public const int Cancelado = 64;
        public const int ParcialmenteLiquidado = 65;
        public const int Reembolsado = 66;
        public const int Reintegrado = 67;
        public const int ComprobanteTesGenerado = 68;
        public const int ChequeAnulado = 69;
    }
}
