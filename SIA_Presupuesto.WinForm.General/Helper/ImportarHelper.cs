using SIA_Contable.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ImportarHelper
    {
        private const string coneccionExcel = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source= {0}; Extended Properties=\"Excel 12.0 Xml; HDR=YES;IMEX=1\"";
        private const string consulta = "select * from [{0}$]";
        // [FECHA OPER.], [FECHA VALOR], [DESCRIPCIÓN], [OFICINA], [CAN], [N° OPER.], [CARGO/ABONO], [ITF], [SALDO CONTABLE]

        //private OleDbConnection cnnOleDb;
        //private OleDbCommand cmdOleDb;
        //private OleDbDataReader drOleDb;
        private static string Mensaje { get; set; }

        public static bool CargarDatosEstadoCuenta(string ruta, string nombreArchivo, int anio, out List<DetalleEstadoCuentaMensual> lista)
        {
            string coneccion = string.Format(coneccionExcel, ruta);
            string cons = string.Format(consulta, nombreArchivo);
            return EjecutarConsultaOleDbFormatoEstadoCuenta(coneccion, cons, anio, out lista);
        }

        private static bool EjecutarConsultaOleDbFormatoEstadoCuenta(string coneccion, string consulta, int anio, out List<DetalleEstadoCuentaMensual> lista)
        {
            OleDbConnection cnnOleDb;
            OleDbCommand cmdOleDb;
            OleDbDataReader drOleDb;
            bool respuesta = false;
            cnnOleDb = new OleDbConnection();
            lista = new List<DetalleEstadoCuentaMensual>();

            try
            {
                cnnOleDb.ConnectionString = coneccion;
                cmdOleDb = new OleDbCommand(consulta, cnnOleDb);
                cmdOleDb.CommandType = CommandType.Text;
                cnnOleDb.Open();
                drOleDb = cmdOleDb.ExecuteReader();
                while (drOleDb.Read())
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(drOleDb.GetValue(0))) && !string.IsNullOrWhiteSpace(Convert.ToString(drOleDb.GetValue(0))))
                    {
                        string fecOpe = string.Format("{0}-{1}", Convert.ToString(drOleDb.GetValue(0)).Trim(), anio).Replace('-','/');
                        string fecVal = string.Format("{0}-{1}", Convert.ToString(drOleDb.GetValue(1)).Trim(), anio).Replace('-', '/');
                        string nroOpe = Convert.ToString(drOleDb.GetValue(5)).Trim();
                        string imp = Convert.ToString(drOleDb.GetValue(6)).Trim().Replace(",", "");
                        string itf = Convert.ToString(drOleDb.GetValue(7)).Trim().Replace(",", "");
                        string saldoCont = Convert.ToString(drOleDb.GetValue(8)).Trim().Replace(",", "");
                        DateTime fo = Convert.ToDateTime(fecOpe);
                        string descripcion = Convert.ToString(drOleDb.GetValue(2));
                        string can = Convert.ToString(drOleDb.GetValue(4));
                        string oficina = Convert.ToString(drOleDb.GetValue(3));
                        int nroOperacion = !string.IsNullOrEmpty(nroOpe) ? Convert.ToInt32(nroOpe) : 0;
                        lista.Add(new DetalleEstadoCuentaMensual
                        {
                            fechaOperacion = fo,
                            fechaValor = Convert.ToDateTime(fecVal),
                            descripcion = descripcion,
                            oficina = oficina,
                            can = can,
                            nroOperacion = nroOperacion,
                            tipoOperacion = !string.IsNullOrEmpty(imp) ? Convert.ToDecimal(imp) >= 0.0m ? "AB" : "CA" : "NN",
                            importe = !string.IsNullOrEmpty(imp) ? Convert.ToDecimal(imp): 0.0m,
                            itf = !string.IsNullOrEmpty(itf)? Convert.ToDecimal(itf) : 0.0m,
                            saldoContable = !string.IsNullOrEmpty(saldoCont) ? Convert.ToDecimal(saldoCont) : 0.0m
                        });
                        respuesta = true;
                    }
                    //else
                    //{
                    //    if (!string.IsNullOrEmpty(Convert.ToString(drOleDb.GetValue(1))) && !string.IsNullOrWhiteSpace(Convert.ToString(drOleDb.GetValue(1))))
                    //    {
                    //        respuesta = false;
                    //        break;
                    //    }
                    //}
                }
            }
            catch (OleDbException ex)
            {
                respuesta = false;
                Mensaje = "Error al Ejecutar consulta : " + ex.Message;
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = "Error al Ejecutar consulta :" + ex.Message;
            }
            finally
            {
                cnnOleDb.Close();
            }
            return respuesta;
        }
    }
}
