using DevExpress.Export.Xl;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Helper
{
    public class ExportarProHelper
    {
        public static void ExportarProgramacionAnual(string rutaArchivo, List<ProgramacionAnualAreaExporta> lista)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 60, formato = new XlCellFormatting() });

                    //Meses
                    columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 100, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Area", tamanioAncho = 250, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();
                    decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                    string direccion = string.Empty;
                    string titulo = string.Empty;
                    string cuentaNivel1 = string.Empty;
                    string cuentaNivel2 = string.Empty;
                    string grupo = string.Empty;

                    List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                    List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                    List<int> cantNivel1 = new List<int>();
                    List<int> cantNivel2 = new List<int>();
                    List<int> cantNivel0 = new List<int>();
                    List<int> listaNivel0 = new List<int>();
                    //List<int> cantNivel3 = new List<int>();
                    int filas = 0, cantInicio = 0, cantNivel3=0, cantDetalle = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!titulo.Equals(dato.titulo))
                        {
                            if (hoja != null)
                            {
                                //suma += dato.TotalNeto;
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;

                                //Ultimo Total
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                filas +=1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                ((IDisposable)hoja).Dispose();
                            }

                            hoja = exportar.CrearHoja(documento, dato.codDireccion);
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, dato.titulo /*string.Format("PRESUPUESTO ANUAL DE REMUNERACIONES, BIENES Y SERVICIOS {0} - {1}", 2018, dato.desDireccion)*/, columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 3;
                            cantInicio = 3;
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                        }

                        if(!dato.grupo.Equals(grupo))
                        {
                            if (!string.IsNullOrEmpty(grupo))
                            {
                                cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                filas += 1;
                                cantInicio += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                listaNivel0.Add(filas);

                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;
                                cantInicio += 1;

                                
                            }

                            exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas+1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                            filas += 1;
                            cantInicio += 1;
                        }

                        //string cuentaBancaria = string.Empty;

                        if (hoja != null)
                        {
                            if (dato.nivel == 1)
                            {
                                listaFila.Clear();

                                cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 2).Select(s=>(Int32)s.posicion).ToList();

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta,
                                    formato = ExportarExcelHelper.SoloRojoColor()
                                });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor()  });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor()});
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloRojoColor(),
                                    formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.novimebre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), formula = null });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                filas += 1;
                                cuentaNivel1 = dato.numCuenta;
                            }
                            else if (dato.nivel == 2)
                            {
                                cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion + cantDetalle).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.novimebre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                filas += 1;
                                cuentaNivel2 = dato.numCuenta;
                            }
                            else
                            {
                                cantNivel3 = dato.ProgramacionAnualDetallePres.Count();

                                listaFila.Clear();

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas+2, cantNivel3): null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.novimebre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                filas += 1;

                                foreach (var dato1 in dato.ProgramacionAnualDetallePres)
                                {
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formato = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;
                                    //cantDetalle += 1;
                                }

                                ene += (decimal)dato.enero;
                                feb += (decimal)dato.febrero;
                                mar += (decimal)dato.marzo;
                                abr += (decimal)dato.abril;
                                may += (decimal)dato.mayo;
                                jun += (decimal)dato.junio;
                                jul += (decimal)dato.julio;
                                ago += (decimal)dato.agosto;
                                set += (decimal)dato.setiembre;
                                oct += (decimal)dato.octubre;
                                nov += (decimal)dato.novimebre;
                                dic += (decimal)dato.diciembre;
                                total += (decimal)dato.total;

                            }
                        }

                        direccion = dato.desDireccion;
                        titulo = dato.titulo;
                        grupo = dato.grupo;
                    }

                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion + cantDetalle).ToList();

                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE","").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });

                    filas += 1;
                    cantInicio += 1;
                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    listaNivel0.Add(filas);

                    //suma += dato.TotalNeto;
                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                    filas += 1;
                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL REMUNERACIONES, BIENES Y SERVICIOS", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;

                    ((IDisposable)hoja).Dispose();
                }
            }
        }
        public static void ExportarProgramacionAnual(string rutaArchivo, List<ReporteProgramacionAnualExportaPres> lista)
        {
            if (lista.Count > 0)
            {
                ExportarExcelHelper exportar = new ExportarExcelHelper();
                using (var archivo = exportar.CrearArchivo(rutaArchivo))
                {
                    using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                    {

                        var columnas = new List<ColumnaExportar>();
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 80, formato = new XlCellFormatting() });

                        //Meses
                        columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                        columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Area", tamanioAncho = 250, formato = new XlCellFormatting() });

                        var listaFila = new List<CeldaExportar>();
                        decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                        string direccion = string.Empty;
                        string titulo = string.Empty;
                        string cuentaNivel1 = string.Empty;
                        string cuentaNivel2 = string.Empty;
                        string grupo = string.Empty;

                        List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                        List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                        List<int> cantNivel1 = new List<int>();
                        List<int> cantNivel2 = new List<int>();
                        List<int> cantNivel0 = new List<int>();
                        List<int> listaNivel0 = new List<int>();
                        int filas = 0, cantInicio = 0, cantNivel3 = 0;

                        IXlSheet hoja = null;
                        foreach (var dato in lista)
                        {
                            if (!titulo.Equals(dato.titulo))
                            {
                                if (hoja != null)
                                {
                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;

                                    //Ultimo Total
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                    ((IDisposable)hoja).Dispose();
                                }

                                hoja = exportar.CrearHoja(documento, dato.codDireccion);
                                exportar.GenerarColumnas(hoja, columnas);
                                exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                                exportar.GenerarTituloPosicion(hoja, dato.desMoneda, 0, 1, columnas.Count - 1, 1);
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 3;
                                cantInicio = 3;
                                exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                            }

                            if (!dato.grupo.Equals(grupo))
                            {
                                if (!string.IsNullOrEmpty(grupo))
                                {
                                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    cantInicio += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    listaNivel0.Add(filas);

                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;
                                    cantInicio += 1;
                                }

                                exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                                filas += 1;
                                cantInicio += 1;
                            }

                            if (hoja != null)
                            {
                                if (dato.nivel == 1)
                                {
                                    listaFila.Clear();

                                    cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Cadena,
                                        valor = dato.numCuenta,
                                        formato = ExportarExcelHelper.SoloRojoColor()
                                    });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Decimal,
                                        valor = dato.enero,
                                        formato = ExportarExcelHelper.SoloRojoColor(),
                                        formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio)
                                    });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.novimebre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                    filas += 1;
                                    cuentaNivel1 = dato.numCuenta;
                                }
                                else if (dato.nivel == 2)
                                {
                                    cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.novimebre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                    filas += 1;
                                    cuentaNivel2 = dato.numCuenta;
                                }
                                else
                                {
                                    cantNivel3 = dato.ListaReporteProgramacionAnualDetalleExportaPres.Count();

                                    listaFila.Clear();

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.novimebre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;

                                    foreach (var dato1 in dato.ListaReporteProgramacionAnualDetalleExportaPres)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formato = null });

                                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                                        filas += 1;
                                    }

                                    ene += (decimal)dato.enero;
                                    feb += (decimal)dato.febrero;
                                    mar += (decimal)dato.marzo;
                                    abr += (decimal)dato.abril;
                                    may += (decimal)dato.mayo;
                                    jun += (decimal)dato.junio;
                                    jul += (decimal)dato.julio;
                                    ago += (decimal)dato.agosto;
                                    set += (decimal)dato.setiembre;
                                    oct += (decimal)dato.octubre;
                                    nov += (decimal)dato.novimebre;
                                    dic += (decimal)dato.diciembre;
                                    total += (decimal)dato.total;

                                }
                            }

                            direccion = dato.desDireccion;
                            titulo = dato.titulo;
                            grupo = dato.grupo;
                        }

                        cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });

                        filas += 1;
                        cantInicio += 1;
                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        listaNivel0.Add(filas);

                        exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                        filas += 1;
                        ////Ultimo Total
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL REMUNERACIONES, BIENES Y SERVICIOS", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null });

                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        filas += 1;

                        ((IDisposable)hoja).Dispose();
                    }
                }
            }
        }
        public static void ExportarReajusteMensualPresupuesto(string rutaArchivo, ReajusteMensualProgramacion reajuste, List<ReajusteMensualAreaExporta> lista)
        {
            int reduccion = (reajuste.mesReajuste - 1);
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 60, formato = new XlCellFormatting() });

                    //Meses
                    if(reajuste.mesReajuste <= 1) columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 2) columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 3) columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 4) columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 5) columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 6) columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 7) columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 8) columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 9) columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 10) columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    if (reajuste.mesReajuste <= 11) columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 100, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Area", tamanioAncho = 250, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();
                    decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                    string direccion = string.Empty;
                    string titulo = string.Empty;
                    string cuentaNivel1 = string.Empty;
                    string cuentaNivel2 = string.Empty;
                    string grupo = string.Empty;

                    List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                    List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                    List<int> cantNivel1 = new List<int>();
                    List<int> cantNivel2 = new List<int>();
                    List<int> cantNivel0 = new List<int>();
                    List<int> listaNivel0 = new List<int>();
                    //List<int> cantNivel3 = new List<int>();
                    int filas = 0, cantInicio = 0, cantNivel3 = 0, cantDetalle = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!titulo.Equals(dato.titulo))
                        {
                            if (hoja != null)
                            {
                                //suma += dato.TotalNeto;
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;

                                //Ultimo Total
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                filas += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                ((IDisposable)hoja).Dispose();
                            }

                            hoja = exportar.CrearHoja(documento, dato.codDireccion);
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, dato.titulo /*string.Format("PRESUPUESTO ANUAL DE REMUNERACIONES, BIENES Y SERVICIOS {0} - {1}", 2018, dato.desDireccion)*/, columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 3;
                            cantInicio = 3;
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                        }

                        if (!dato.grupo.Equals(grupo))
                        {
                            if (!string.IsNullOrEmpty(grupo))
                            {
                                cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15 - reduccion, cantNivel0, cantInicio) });
                                if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16 - reduccion, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17 - reduccion, cantNivel0, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18 - reduccion, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                filas += 1;
                                cantInicio += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                listaNivel0.Add(filas);

                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;
                                cantInicio += 1;


                            }

                            exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                            filas += 1;
                            cantInicio += 1;
                        }

                        //string cuentaBancaria = string.Empty;

                        if (hoja != null)
                        {
                            if (dato.nivel == 1)
                            {
                                listaFila.Clear();

                                cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Add(new CeldaExportar
                                {
                                    tipoDato = TipoDatoExportar.Cadena,
                                    valor = dato.numCuenta,
                                    formato = ExportarExcelHelper.SoloRojoColor()
                                });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                if (reajuste.mesReajuste <= 1)  listaFila.Add(new CeldaExportar
                                {
                                    tipoDato = TipoDatoExportar.Decimal,
                                    valor = dato.enero,
                                    formato = ExportarExcelHelper.SoloRojoColor(),
                                    formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio)
                                });

                                if (reajuste.mesReajuste <= 2)  listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7- reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15 - reduccion, cantNivel1, cantInicio) });
                                if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16 - reduccion, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17 - reduccion, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18 - reduccion, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                filas += 1;
                                cuentaNivel1 = dato.numCuenta;
                            }
                            else if (dato.nivel == 2)
                            {
                                cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion + cantDetalle).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15 - reduccion, cantNivel2, cantInicio) });
                                if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16 - reduccion, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17 - reduccion, cantNivel2, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18 - reduccion, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                filas += 1;
                                cuentaNivel2 = dato.numCuenta;
                            }
                            else
                            {
                                cantNivel3 = dato.ReajusteMensualDetallePres.Count();

                                listaFila.Clear();

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15 - reduccion, filas + 2, cantNivel3) : null });
                                if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16 - reduccion, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17 - reduccion, filas + 2, cantNivel3) : null });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18 - reduccion, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                filas += 1;

                                foreach (var dato1 in dato.ReajusteMensualDetallePres)
                                {
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantidad, formato = null });

                                    if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formato = null });
                                    if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formato = null });
                                    if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formato = null });
                                    if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formato = null });
                                    if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formato = null });
                                    if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formato = null });
                                    if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formato = null });
                                    if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formato = null });
                                    if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formato = null });
                                    if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formato = null });
                                    if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12 - reduccion) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formato = null});

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;
                                    //cantDetalle += 1;
                                }

                                ene += (decimal)dato.enero;
                                feb += (decimal)dato.febrero;
                                mar += (decimal)dato.marzo;
                                abr += (decimal)dato.abril;
                                may += (decimal)dato.mayo;
                                jun += (decimal)dato.junio;
                                jul += (decimal)dato.julio;
                                ago += (decimal)dato.agosto;
                                set += (decimal)dato.setiembre;
                                oct += (decimal)dato.octubre;
                                nov += (decimal)dato.noviembre;
                                dic += (decimal)dato.diciembre;
                                total += (decimal)dato.total;

                            }
                        }

                        direccion = dato.desDireccion;
                        titulo = dato.titulo;
                        grupo = dato.grupo;
                    }

                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion + cantDetalle).ToList();

                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15 - reduccion, cantNivel0, cantInicio) });
                    if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16 - reduccion, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17 - reduccion, cantNivel0, cantInicio) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18 - reduccion, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    filas += 1;
                    cantInicio += 1;
                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    listaNivel0.Add(filas);

                    //suma += dato.TotalNeto;
                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                    filas += 1;
                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL REMUNERACIONES, BIENES Y SERVICIOS", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    if (reajuste.mesReajuste <= 1) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 2) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 3) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 4) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 5) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 6) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 7) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 8) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 9) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 10) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15 - reduccion, listaNivel0, 0) });
                    if (reajuste.mesReajuste <= 11) listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16 - reduccion, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17 - reduccion, listaNivel0, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18- reduccion, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;

                    ((IDisposable)hoja).Dispose();
                }
            }
        }

        public static void ExportarEvaluacionMensualPresupuesto(string rutaArchivo, List<EvaluacionMensualAreaExporta> lista)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 60, formato = new XlCellFormatting() });

                    //Meses
                    columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 100, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();
                    decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                    string direccion = string.Empty;
                    string cuentaNivel1 = string.Empty;
                    string cuentaNivel2 = string.Empty;
                    string grupo = string.Empty;

                    List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                    List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                    List<int> cantNivel1 = new List<int>();
                    List<int> cantNivel2 = new List<int>();
                    List<int> cantNivel0 = new List<int>();
                    List<int> listaNivel0 = new List<int>();
                    //List<int> cantNivel3 = new List<int>();
                    int filas = 0, cantInicio = 0, cantNivel3 = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!direccion.Equals(dato.desDireccion))
                        {
                            if (hoja != null)
                            {
                                //suma += dato.TotalNeto;
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;

                                //Ultimo Total
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                filas += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                ((IDisposable)hoja).Dispose();
                            }

                            hoja = exportar.CrearHoja(documento, dato.codDireccion);
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, string.Format("EVALUACION MENSUAL DE PRESUPUESTO {0} - {1}", "NOVIEMBRE", 2018), columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 3;
                            cantInicio = 3;
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                        }

                        if (!dato.grupo.Equals(grupo))
                        {
                            if (!string.IsNullOrEmpty(grupo))
                            {
                                cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                filas += 1;
                                cantInicio += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                listaNivel0.Add(filas);

                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;
                                cantInicio += 1;


                            }

                            exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                            filas += 1;
                            cantInicio += 1;
                        }

                        //string cuentaBancaria = string.Empty;

                        if (hoja != null)
                        {
                            if (dato.nivel == 1)
                            {
                                listaFila.Clear();

                                cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Add(new CeldaExportar
                                {
                                    tipoDato = TipoDatoExportar.Cadena,
                                    valor = dato.numCuenta,
                                    formato = ExportarExcelHelper.SoloRojoColor()
                                });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                listaFila.Add(new CeldaExportar
                                {
                                    tipoDato = TipoDatoExportar.Decimal,
                                    valor = dato.enero,
                                    formato = ExportarExcelHelper.SoloRojoColor(),
                                    formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio)
                                });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                filas += 1;
                                cuentaNivel1 = dato.numCuenta;
                            }
                            else if (dato.nivel == 2)
                            {
                                cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                filas += 1;
                                cuentaNivel2 = dato.numCuenta;
                            }
                            else
                            {
                                cantNivel3 = dato.EvaluacionMensualDetallePres.Count();

                                listaFila.Clear();

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });

                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                filas += 1;

                                foreach (var dato1 in dato.EvaluacionMensualDetallePres)
                                {
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantidad, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12) });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;
                                }

                                ene += (decimal)dato.enero;
                                feb += (decimal)dato.febrero;
                                mar += (decimal)dato.marzo;
                                abr += (decimal)dato.abril;
                                may += (decimal)dato.mayo;
                                jun += (decimal)dato.junio;
                                jul += (decimal)dato.julio;
                                ago += (decimal)dato.agosto;
                                set += (decimal)dato.setiembre;
                                oct += (decimal)dato.octubre;
                                nov += (decimal)dato.noviembre;
                                dic += (decimal)dato.diciembre;
                                total += (decimal)dato.total;

                            }
                        }

                        direccion = dato.desDireccion;
                        grupo = dato.grupo;
                    }

                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                    filas += 1;
                    cantInicio += 1;
                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    listaNivel0.Add(filas);

                    //suma += dato.TotalNeto;
                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                    filas += 1;
                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;

                    ((IDisposable)hoja).Dispose();
                }
            }
        }
        public static void ExportarEvaluacionMensualPresupuesto(string rutaArchivo, List<ReporteEvaluacionMensualExportaPres> lista)
        {
            if (lista.Count > 0)
            {
                ExportarExcelHelper exportar = new ExportarExcelHelper();
                using (var archivo = exportar.CrearArchivo(rutaArchivo))
                {
                    using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                    {

                        var columnas = new List<ColumnaExportar>();
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 80, formato = new XlCellFormatting() });

                        //Meses
                        columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                        columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 100, formato = new XlCellFormatting() });

                        var listaFila = new List<CeldaExportar>();
                        decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                        string direccion = string.Empty;
                        string cuentaNivel1 = string.Empty;
                        string cuentaNivel2 = string.Empty;
                        string grupo = string.Empty;

                        List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                        List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                        List<int> cantNivel1 = new List<int>();
                        List<int> cantNivel2 = new List<int>();
                        List<int> cantNivel0 = new List<int>();
                        List<int> listaNivel0 = new List<int>();

                        int filas = 0, cantInicio = 0, cantNivel3 = 0;

                        IXlSheet hoja = null;
                        foreach (var dato in lista)
                        {
                            if (!direccion.Equals(dato.desDireccion))
                            {
                                if (hoja != null)
                                {
                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;

                                    //Ultimo Total
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                    ((IDisposable)hoja).Dispose();
                                }

                                hoja = exportar.CrearHoja(documento, dato.codDireccion);
                                exportar.GenerarColumnas(hoja, columnas);
                                exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                                exportar.GenerarTituloPosicion(hoja, dato.desMoneda, 0, 1, columnas.Count - 1, 1);
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 3;
                                cantInicio = 3;
                                exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                            }

                            if (!dato.grupo.Equals(grupo))
                            {
                                if (!string.IsNullOrEmpty(grupo))
                                {
                                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                    filas += 1;
                                    cantInicio += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    listaNivel0.Add(filas);

                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;
                                    cantInicio += 1;


                                }

                                exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                                filas += 1;
                                cantInicio += 1;
                            }

                            if (hoja != null)
                            {
                                if (dato.nivel == 1)
                                {
                                    listaFila.Clear();

                                    cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Cadena,
                                        valor = dato.numCuenta,
                                        formato = ExportarExcelHelper.SoloRojoColor()
                                    });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Decimal,
                                        valor = dato.enero,
                                        formato = ExportarExcelHelper.SoloRojoColor(),
                                        formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio)
                                    });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                    filas += 1;
                                    cuentaNivel1 = dato.numCuenta;
                                }
                                else if (dato.nivel == 2)
                                {
                                    cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                    filas += 1;
                                    cuentaNivel2 = dato.numCuenta;
                                }
                                else
                                {
                                    cantNivel3 = dato.ListaReporteEvaluacionMensualDetalleExportaPres.Count();

                                    listaFila.Clear();

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;

                                    foreach (var evaluacionMensualDetalle in dato.ListaReporteEvaluacionMensualDetalleExportaPres)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = evaluacionMensualDetalle.descripcion, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = evaluacionMensualDetalle.Abreviado, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.precio, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.enero, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.febrero, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.marzo, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.abril, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.mayo, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.junio, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.julio, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.agosto, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.setiembre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.octubre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.noviembre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = evaluacionMensualDetalle.diciembre, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12) });

                                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                                        filas += 1;
                                    }

                                    ene += (decimal)dato.enero;
                                    feb += (decimal)dato.febrero;
                                    mar += (decimal)dato.marzo;
                                    abr += (decimal)dato.abril;
                                    may += (decimal)dato.mayo;
                                    jun += (decimal)dato.junio;
                                    jul += (decimal)dato.julio;
                                    ago += (decimal)dato.agosto;
                                    set += (decimal)dato.setiembre;
                                    oct += (decimal)dato.octubre;
                                    nov += (decimal)dato.noviembre;
                                    dic += (decimal)dato.diciembre;
                                    total += (decimal)dato.total;

                                }
                            }

                            direccion = dato.desDireccion;
                            grupo = dato.grupo;
                        }

                        cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                        filas += 1;
                        cantInicio += 1;
                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        listaNivel0.Add(filas);

                        exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                        filas += 1;
                        ////Ultimo Total
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });

                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        filas += 1;

                        ((IDisposable)hoja).Dispose();
                    }
                }
            }
        }
        public static void ExportarRequerimientos(string rutaArchivo, List<RequerimientoBienServicioDetallePresExporta> lista)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 60, formato = new XlCellFormatting() });

                    //Meses
                    columnas.Add(new ColumnaExportar { nombre = "Cant. Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "CANT", tamanioAncho = 100, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "TOTAL", tamanioAncho = 100, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "AREA", tamanioAncho = 150, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();
                    decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                    decimal cantene = 0, cantfeb = 0, cantmar = 0, cantabr = 0, cantmay = 0, cantjun = 0, cantjul = 0, cantago = 0, cantset = 0, cantoct = 0, cantnov = 0, cantdic = 0, cant = 0;
                    string direccion = string.Empty;
                    string cuentaNivel1 = string.Empty;
                    string cuentaNivel2 = string.Empty;
                    string grupo = string.Empty;

                    List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                    List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                    List<int> cantNivel1 = new List<int>();
                    List<int> cantNivel2 = new List<int>();
                    List<int> cantNivel0 = new List<int>();
                    List<int> listaNivel0 = new List<int>();
                    //List<int> cantNivel3 = new List<int>();
                    int filas = 0, cantInicio = 0, cantNivel3 = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!direccion.Equals(dato.desDireccion))
                        {
                            if (hoja != null)
                            {
                                //suma += dato.TotalNeto;
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;

                                //Ultimo Total
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantene, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantfeb, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmar, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantabr, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmay, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjun, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjul, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantago, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantset, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantoct, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantnov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantdic, formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cant, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                filas += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                cantene = 0; cantfeb = 0; cantmar = 0; cantabr = 0; cantmay = 0; cantjun = 0; cantjul = 0; cantago = 0; cantset = 0; cantoct = 0; cantnov = 0; cantdic = 0; cant = 0;
                                ((IDisposable)hoja).Dispose();
                            }

                            hoja = exportar.CrearHoja(documento, "DD");
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, string.Format("PRESUPUESTO ANUAL DE REMUNERACIONES, BIENES Y SERVICIOS {0} - {1}", 2019, dato.desDireccion), columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 3;
                            cantInicio = 3;
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                        }

                        if (!dato.grupo.Equals(grupo))
                        {
                            if (!string.IsNullOrEmpty(grupo))
                            {
                                cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantfeb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantabr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmay, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantset, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantoct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantnov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantdic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel0, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cant, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });
                                filas += 1;
                                cantInicio += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                listaNivel0.Add(filas);

                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;
                                cantInicio += 1;


                            }

                            exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                            filas += 1;
                            cantInicio += 1;
                        }

                        //string cuentaBancaria = string.Empty;

                        if (hoja != null)
                        {
                            if (dato.nivel == 1)
                            {
                                listaFila.Clear();

                                cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Add(new CeldaExportar
                                {
                                    tipoDato = TipoDatoExportar.Cadena,
                                    valor = dato.numCuenta,
                                    formato = ExportarExcelHelper.SoloRojoColor()
                                });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantEnero,  formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantEnero * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantFebrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantFebrero * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMarzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMarzo * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAbril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAbril * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMayo * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJunio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJunio * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJulio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJulio * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAgosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAgosto * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantSetiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantSetiembre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantOctubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantOctubre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantNoviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantNoviembre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantDiciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantDiciembre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantidad*dato.precio,2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), formula = null });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                filas += 1;
                                cuentaNivel1 = dato.numCuenta;
                            }
                            else if (dato.nivel == 2)
                            {
                                cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantEnero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantEnero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantFebrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantFebrero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMarzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMarzo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAbril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAbril * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMayo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJunio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJunio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJulio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJulio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAgosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAgosto * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantSetiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantSetiembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantOctubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantOctubre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantNoviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantNoviembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantDiciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantDiciembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel2, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantidad * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                filas += 1;
                                cuentaNivel2 = dato.numCuenta;
                            }
                            else
                            {
                                cantNivel3 = dato.RequerimientoBienServicioDetalleExporta.Count();

                                listaFila.Clear();

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantEnero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantEnero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantFebrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantFebrero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMarzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMarzo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAbril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAbril * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMayo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJunio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJunio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJulio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJulio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAgosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAgosto * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantSetiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantSetiembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantOctubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantOctubre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantNoviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantNoviembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantDiciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantDiciembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, filas + 2, cantNivel3) : null });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantidad * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                filas += 1;

                                int [] listaColumnasCant = { 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28 };
                                int[] listaColumnasImp = { 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29 };
                                foreach (var dato1 in dato.RequerimientoBienServicioDetalleExporta)
                                {
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantEnero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantEnero * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantFebrero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantFebrero * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantMarzo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantMarzo * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantAbril, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantAbril * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantMayo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantMayo * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantJunio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantJunio * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantJulio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantJulio * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantAgosto, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantAgosto * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantSetiembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantSetiembre * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantOctubre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantOctubre * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantNoviembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantNoviembre * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantDiciembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantDiciembre * dato1.precio, 2), formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasCant.ToList(), 0) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasImp.ToList(), 0) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formula = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;
                                }

                                cantene += (decimal)dato.cantEnero;
                                ene += Math.Round((decimal)dato.cantEnero * dato.precio, 2);
                                cantfeb += (decimal)dato.cantFebrero;
                                feb += Math.Round((decimal)dato.cantFebrero * dato.precio, 2);
                                cantmar += (decimal)dato.cantMarzo;
                                mar += Math.Round((decimal)dato.cantMarzo * dato.precio, 2);
                                cantabr += (decimal)dato.cantAbril;
                                abr += Math.Round((decimal)dato.cantAbril * dato.precio, 2);
                                cantmay += (decimal)dato.cantMayo;
                                may += Math.Round((decimal)dato.cantMayo * dato.precio, 2);
                                cantjun += (decimal)dato.cantJunio;
                                jun += Math.Round((decimal)dato.cantJunio * dato.precio, 2);
                                cantjul += (decimal)dato.cantJulio;
                                jul += Math.Round((decimal)dato.cantJulio * dato.precio, 2);
                                cantago += (decimal)dato.cantAgosto;
                                ago += Math.Round((decimal)dato.cantAgosto * dato.precio, 2);
                                cantset += (decimal)dato.cantSetiembre;
                                set += Math.Round((decimal)dato.cantSetiembre * dato.precio, 2);
                                cantoct += (decimal)dato.cantOctubre;
                                oct += Math.Round((decimal)dato.cantOctubre * dato.precio, 2);
                                cantnov += (decimal)dato.cantNoviembre;
                                nov += Math.Round((decimal)dato.cantNoviembre * dato.precio, 2);
                                cantdic += (decimal)dato.cantDiciembre;
                                dic += Math.Round((decimal)dato.cantDiciembre * dato.precio, 2);
                                cant += (decimal)dato.cantidad;
                                total += Math.Round((decimal)dato.cantidad * dato.precio, 2);

                            }
                        }

                        direccion = dato.desDireccion;
                        grupo = dato.grupo;
                    }

                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel0, cantInicio) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });

                    filas += 1;
                    cantInicio += 1;
                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    listaNivel0.Add(filas);

                    //suma += dato.TotalNeto;
                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                    filas += 1;
                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantfeb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantabr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmay, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantset, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantoct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantnov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantdic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, listaNivel0, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cant, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;

                    ((IDisposable)hoja).Dispose();
                }
            }
        }

        public static void ExportarRequerimientosArea(string rutaArchivo, List<RequerimientoBienServicioDetallePresExporta> lista)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 60, formato = new XlCellFormatting() });

                    //Meses
                    columnas.Add(new ColumnaExportar { nombre = "Cant. Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Junio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "Cant. Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "CANT", tamanioAncho = 100, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "TOTAL", tamanioAncho = 100, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "AREA", tamanioAncho = 100, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();
                    decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                    decimal cantene = 0, cantfeb = 0, cantmar = 0, cantabr = 0, cantmay = 0, cantjun = 0, cantjul = 0, cantago = 0, cantset = 0, cantoct = 0, cantnov = 0, cantdic = 0, cant = 0;
                    string direccion = string.Empty;
                    string area = string.Empty;
                    string cuentaNivel1 = string.Empty;
                    string cuentaNivel2 = string.Empty;
                    string grupo = string.Empty;

                    List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                    List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                    List<int> cantNivel1 = new List<int>();
                    List<int> cantNivel2 = new List<int>();
                    List<int> cantNivel0 = new List<int>();
                    List<int> listaNivel0 = new List<int>();
                    //List<int> cantNivel3 = new List<int>();
                    int filas = 0, cantInicio = 0, cantNivel3 = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!direccion.Equals(dato.desDireccion))
                        {
                            if (hoja != null)
                            {
                                //suma += dato.TotalNeto;
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;

                                //Ultimo Total
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantene, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantfeb, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmar, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantabr, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmay, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjun, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjul, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantago, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantset, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantoct, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantnov, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantdic, formato = ExportarExcelHelper.SoloAzulColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cant, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                filas += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                cantene = 0; cantfeb = 0; cantmar = 0; cantabr = 0; cantmay = 0; cantjun = 0; cantjul = 0; cantago = 0; cantset = 0; cantoct = 0; cantnov = 0; cantdic = 0; cant = 0;
                                ((IDisposable)hoja).Dispose();
                            }

                            hoja = exportar.CrearHoja(documento, "DD");
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, string.Format("PRESUPUESTO ANUAL DE REMUNERACIONES, BIENES Y SERVICIOS {0} - {1}", 2019, dato.desDireccion), columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 3;
                            cantInicio = 3;
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                        }

                        if (!dato.grupo.Equals(grupo))
                        {
                            if (!string.IsNullOrEmpty(grupo))
                            {
                                cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantfeb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantabr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmay, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantset, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantoct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantnov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantdic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel0, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cant, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel0, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });
                                filas += 1;
                                cantInicio += 1;
                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                listaNivel0.Add(filas);

                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 1;
                                cantInicio += 1;


                            }

                            exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                            filas += 1;
                            cantInicio += 1;
                        }

                        //string cuentaBancaria = string.Empty;

                        if (hoja != null)
                        {
                            if (dato.nivel == 1)
                            {
                                listaFila.Clear();

                                cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && dato.desArea.Equals(c.desArea) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Add(new CeldaExportar
                                {
                                    tipoDato = TipoDatoExportar.Cadena,
                                    valor = dato.numCuenta,
                                    formato = ExportarExcelHelper.SoloRojoColor()
                                });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantEnero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantEnero * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantFebrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantFebrero * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMarzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMarzo * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAbril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAbril * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMayo * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJunio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJunio * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJulio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJulio * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAgosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAgosto * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantSetiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantSetiembre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantOctubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantOctubre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantNoviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantNoviembre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantDiciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantDiciembre * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel1, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantidad * dato.precio, 2), formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel1, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desArea, formato = ExportarExcelHelper.SoloRojoColor(), formula = null});

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                filas += 1;
                                cuentaNivel1 = dato.numCuenta;
                            }
                            else if (dato.nivel == 2)
                            {
                                cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && dato.desArea.Equals(c.desArea) && c.numCuenta.Contains(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantEnero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantEnero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantFebrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantFebrero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMarzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMarzo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAbril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAbril * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMayo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJunio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJunio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJulio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJulio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAgosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAgosto * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantSetiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantSetiembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantOctubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantOctubre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantNoviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantNoviembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantDiciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantDiciembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel2, cantInicio) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantidad * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel2, cantInicio) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desArea, formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                //exportar.GenerarDatosFila(hoja, listaFila, 20);
                                exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                filas += 1;
                                cuentaNivel2 = dato.numCuenta;
                            }
                            else
                            {
                                cantNivel3 = dato.RequerimientoBienServicioDetalleExporta.Count();

                                listaFila.Clear();

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel2, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantEnero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantEnero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantFebrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantFebrero * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMarzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMarzo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAbril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAbril * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantMayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantMayo * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJunio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJunio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantJulio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantJulio * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantAgosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantAgosto * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantSetiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantSetiembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantOctubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantOctubre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantNoviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantNoviembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantDiciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantDiciembre * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, filas + 2, cantNivel3) : null });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato.cantidad * dato.precio, 2), formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, filas + 2, cantNivel3) : null });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desArea, formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                filas += 1;

                                int[] listaColumnasCant = { 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28 };
                                int[] listaColumnasImp = { 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29 };
                                foreach (var dato1 in dato.RequerimientoBienServicioDetalleExporta)
                                {
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantEnero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantEnero * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantFebrero, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantFebrero * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantMarzo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantMarzo * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantAbril, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantAbril * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantMayo, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantMayo * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantJunio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantJunio * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantJulio, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantJulio * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantAgosto, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantAgosto * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantSetiembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantSetiembre * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantOctubre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantOctubre * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantNoviembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantNoviembre * dato1.precio, 2), formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantDiciembre, formato = null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = Math.Round((decimal)dato1.cantDiciembre * dato1.precio, 2), formato = null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasCant.ToList(), 0) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasImp.ToList(), 0) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formula = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;
                                }

                                cantene += (decimal)dato.cantEnero;
                                ene += Math.Round((decimal)dato.cantEnero * dato.precio, 2);
                                cantfeb += (decimal)dato.cantFebrero;
                                feb += Math.Round((decimal)dato.cantFebrero * dato.precio, 2);
                                cantmar += (decimal)dato.cantMarzo;
                                mar += Math.Round((decimal)dato.cantMarzo * dato.precio, 2);
                                cantabr += (decimal)dato.cantAbril;
                                abr += Math.Round((decimal)dato.cantAbril * dato.precio, 2);
                                cantmay += (decimal)dato.cantMayo;
                                may += Math.Round((decimal)dato.cantMayo * dato.precio, 2);
                                cantjun += (decimal)dato.cantJunio;
                                jun += Math.Round((decimal)dato.cantJunio * dato.precio, 2);
                                cantjul += (decimal)dato.cantJulio;
                                jul += Math.Round((decimal)dato.cantJulio * dato.precio, 2);
                                cantago += (decimal)dato.cantAgosto;
                                ago += Math.Round((decimal)dato.cantAgosto * dato.precio, 2);
                                cantset += (decimal)dato.cantSetiembre;
                                set += Math.Round((decimal)dato.cantSetiembre * dato.precio, 2);
                                cantoct += (decimal)dato.cantOctubre;
                                oct += Math.Round((decimal)dato.cantOctubre * dato.precio, 2);
                                cantnov += (decimal)dato.cantNoviembre;
                                nov += Math.Round((decimal)dato.cantNoviembre * dato.precio, 2);
                                cantdic += (decimal)dato.cantDiciembre;
                                dic += Math.Round((decimal)dato.cantDiciembre * dato.precio, 2);
                                cant += (decimal)dato.cantidad;
                                total += Math.Round((decimal)dato.cantidad * dato.precio, 2);

                            }
                        }

                        direccion = dato.desDireccion;
                        grupo = dato.grupo;
                    }

                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, cantNivel0, cantInicio) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, cantNivel0, cantInicio) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null});
                    filas += 1;
                    cantInicio += 1;
                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    listaNivel0.Add(filas);

                    //suma += dato.TotalNeto;
                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                    filas += 1;
                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantfeb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantabr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantmay, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantjul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(19, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(20, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(21, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantset, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(22, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(23, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantoct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(24, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(25, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantnov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(26, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(27, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cantdic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(28, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(29, listaNivel0, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cant, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(30, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(31, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null});

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;

                    ((IDisposable)hoja).Dispose();
                }
            }
        }
        public static void ExportarPAC(string rutaArchivo, List<ReportePlanAnualAdquisicionExportaPres> lista)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();

                    columnas.Add(new ColumnaExportar { nombre = "N.REF", tamanioAncho = 47, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "ÍTEM ÚNICO", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "N.ÍTEM", tamanioAncho = 55, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "SÍNTESIS DE ESPECIFICACIONES TÉCNICAS", tamanioAncho = 286, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CODIGO DE BIENES Y SERVICIOS", tamanioAncho = 93, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "UNIDAD DE MEDIDA", tamanioAncho = 92, formato = new XlCellFormatting() });

                    columnas.Add(new ColumnaExportar { nombre = "CANTIDAD", tamanioAncho = 93, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "VALOR ESTIMADO", tamanioAncho = 101, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "TIPO DE MONEDA", tamanioAncho = 77, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "FINANCIAMIENTO", tamanioAncho = 120, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "MODALIDAD DE ADQUISICION", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "ÓRGANO ENCARGADO DE LA ADQUISICIÓN O CONTRATACIÓN", tamanioAncho = 108, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "OBSERVACIONES", tamanioAncho = 156, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();
                    decimal SumavalorEst = 0;

                    string titulo = string.Empty;
                    int cantDetalle = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!titulo.Equals(dato.titulo))
                        {
                            hoja = exportar.CrearHoja(documento, "P.A.C. - " + lista[0].anio.ToString());
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            listaFila.Clear();

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "A) NOMBRE DE LA ENTIDAD :" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = lista[0].endtidad });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "D) AÑO.:" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = lista[0].anio.ToString() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            listaFila.Clear();

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "B) SIGLAS :" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = lista[0].siglas });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "E) R.U.C.:" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = lista[0].ruc.ToString() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            listaFila.Clear();

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "C) PLIEGO :" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = lista[0].pliego });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });
                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre), 81);
                            titulo = dato.titulo;
                        }


                        listaFila.Clear();
                        cantDetalle += 1;

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Entero, valor = cantDetalle, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = null, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcionCuenta, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = null, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.Abreviado, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.cant, formato = null });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.valorEst, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.moneda, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.fuenteFinan, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.tipoProceso, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.organoEncargado, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = null, formato = null });

                        /*Imprime Detalle*/
                        exportar.GenerarDatosFila(hoja, listaFila, 20);

                    }

                    ////Ultimo Total
                    ////
                    listaFila.Clear();

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL GENERAL", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = SumavalorEst, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, 10, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);

                    ((IDisposable)hoja).Dispose();
                }
            }
        }
        public static void ExportarEvaluacionPresupuestoPorCuentas(string rutaArchivo, List<EvaluacionPresupuestoPorCuentasPres> lista, int idMoneda, string desPresupuesto, string desSubPresupuesto)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();

                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 500, formato = new XlCellFormatting() });
                    //Importe
                    columnas.Add(new ColumnaExportar { nombre = "Importe Pre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Importe Eje", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Saldo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    /**/

                    var columnasVoucher = new List<ColumnaExportar>();

                    columnasVoucher.Add(new ColumnaExportar { nombre = "", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnasVoucher.Add(new ColumnaExportar { nombre = "", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnasVoucher.Add(new ColumnaExportar { nombre = "", tamanioAncho = 60, formato = new XlCellFormatting() });

                    columnasVoucher.Add(new ColumnaExportar { nombre = "Número", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnasVoucher.Add(new ColumnaExportar { nombre = "Fecha", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnasVoucher.Add(new ColumnaExportar { nombre = "Glosa", tamanioAncho = 500, formato = new XlCellFormatting() });
                    //Importe
                    columnasVoucher.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnasVoucher.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnasVoucher.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                    /**/

                    var listaFila = new List<CeldaExportar>();

                    int filas = 0;
                    bool imprimeTitulo = false;
                    string titulo = idMoneda == 63 ? "(EXPRESADO EN SOLES)" : "(EXPRESADO EN DOLARES AMERICANOS)";


                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!imprimeTitulo)
                        {
                            hoja = exportar.CrearHoja(documento, "Evaluacion por Cuenta");
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, "EVALUACIÓN PRESUPUESTO POR CUENTAS", columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, desPresupuesto, 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarTituloPosicion(hoja, desSubPresupuesto, 0, 2, columnas.Count - 1, 2);
                            exportar.GenerarTituloPosicion(hoja, titulo, 0, 3, columnas.Count - 1, 3);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 6;
                            exportar.GenerarCabeceraFilasCombinar(hoja, columnas.Select(s => s.nombre), 3, 5, 5);
                            filas += 1;
                            imprimeTitulo = true;
                        }

                        /*Cuenta Nivel 1*/
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuenta, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.importePre, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.importeEje, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.saldo, formato = ExportarExcelHelper.SoloAzulColor() });

                        exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                        filas += 1;
                        /*Fin Cuenta Nivel 1*/
                        /*Cuenta Nivel 2*/
                        if (dato.ListaDivisionarias.Count > 0)
                        {
                            foreach (var divisionaria in dato.ListaDivisionarias)
                            {
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = divisionaria.numCuenta, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = divisionaria.desCuenta, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.importePre, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.importeEje, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.saldo, formato = ExportarExcelHelper.SoloVerdeColor() });

                                exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                                filas += 1;
                                /*Fin Cuenta Nivel 2*/

                                if (dato.ListaDivisionarias.Count > 0)
                                {
                                    foreach (var cuenta in divisionaria.ListaCuentasEspecificas)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuenta.numCuenta, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuenta.desCuenta, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.importePre, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.importeEje, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.saldo, formato = ExportarExcelHelper.SoloVerdeColor() });

                                        exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                                        filas += 1;
                                        /*Fin Cuenta Nivel 3*/
                                        if (cuenta.ListaDeVouchers.Count > 0)
                                        {
                                            /*imprimir titulo de detalle*/
                                            //exportar.GenerarCabeceraFilas(hoja, columnasVoocher.Select(s => s.nombre));
                                            exportar.GenerarCabeceraFilasDetalle(hoja, columnasVoucher.Select(s => s.nombre), 3);
                                            filas += 1;
                                            foreach (var detalle in cuenta.ListaDeVouchers)
                                            {
                                                listaFila.Clear();
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = detalle.voucher, formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Fecha, valor = detalle.fechaMov, formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = detalle.glosa, formato = null });

                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = detalle.importe, formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });

                                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                                filas += 1;
                                                /*Fin detalle*/

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }// fin lista clase



                    ((IDisposable)hoja).Dispose();
                }
            }
        }
        public static void ExportarPresupuestoAprobadoComprometidoEjecutado(string rutaArchivo, List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> lista, int idMoneda, string desPresupuesto, string desSubPresupuesto)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();

                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 500, formato = new XlCellFormatting() });
                    //Importe
                    columnas.Add(new ColumnaExportar { nombre = "Importe Pre", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Importe Com", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Importe Eje", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "Saldo", tamanioAncho = 90, formato = new XlCellFormatting() });
                    /**/

                    var listaFila = new List<CeldaExportar>();

                    int filas = 0;
                    bool imprimeTitulo = false;
                    string textoMoneda = idMoneda == 63 ? "(EXPRESADO EN SOLES)" : "(EXPRESADO EN DOLARES AMERICANOS)";


                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (!imprimeTitulo)
                        {
                            hoja = exportar.CrearHoja(documento, "Consulta Presupuesto");
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, "PRESUPUESTO APROBADO, COMPROMETIDO, EJECUTADO Y SALDO", columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, desPresupuesto, 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarTituloPosicion(hoja, desSubPresupuesto, 0, 2, columnas.Count - 1, 2);
                            exportar.GenerarTituloPosicion(hoja, textoMoneda, 0, 3, columnas.Count - 1, 3);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 6;
                            exportar.GenerarCabeceraFilasCombinar(hoja, columnas.Select(s => s.nombre), 3, 5, 5);
                            filas += 1;
                            imprimeTitulo = true;
                        }

                        /*Cuenta Nivel 1*/
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.clase.ToString(), formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desClase, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.monPre, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.monCom, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.monEjeAct, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.saldo, formato = ExportarExcelHelper.SoloAzulColor() });

                        exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                        filas += 1;
                        /*Fin Cuenta Nivel 1*/
                        /*Cuenta Nivel 2*/
                        if (dato.ListaDivisionarias.Count > 0)
                        {
                            foreach (var divisionaria in dato.ListaDivisionarias)
                            {
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = divisionaria.divisionaria.ToString(), formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = divisionaria.desDivisionaria, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.monPre, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.monCom, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.monEjeAct, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.saldo, formato = ExportarExcelHelper.SoloVerdeColor() });

                                exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                                filas += 1;
                                /*Fin Cuenta Nivel 2*/

                                if (dato.ListaDivisionarias.Count > 0)
                                {
                                    foreach (var cuenta in divisionaria.ListaCuentasEspecificas)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });//, formato = ExportarExcelHelper.SoloNegritaColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuenta.numCuenta });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuenta.desCuenta });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "" });//, formato = ExportarExcelHelper.SoloVerdeColor() });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.monPre });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.monCom });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.monEjeAct });//, formato = ExportarExcelHelper.SoloVerdeColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = cuenta.saldo });//, formato = ExportarExcelHelper.SoloVerdeColor() });

                                        exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                                        filas += 1;
                                        /*Fin Cuenta Nivel 3*/
                                    }
                                }
                            }
                        }
                    }// fin lista clase



                    ((IDisposable)hoja).Dispose();
                }
            }
        }
        public static void ExportarEvaluacionReajusteMensualConCantidad(string rutaArchivo, List<EvaluacionReajusteMensualAreaExporta> lista, int mesReajuste)
        {
            if (lista.Count > 0)
            {
                ExportarExcelHelper exportar = new ExportarExcelHelper();
                using (var archivo = exportar.CrearArchivo(rutaArchivo))
                {
                    using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                    {

                        var columnas = new List<ColumnaExportar>();
                        var segundaFilacolumnas = new List<ColumnaExportar>();

                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 65, formato = new XlCellFormatting() });

                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 40, formato = new XlCellFormatting() });
                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 40, formato = new XlCellFormatting() });
                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 60, formato = new XlCellFormatting() });
                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 350, formato = new XlCellFormatting() });
                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 50, formato = new XlCellFormatting() });
                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 60, formato = new XlCellFormatting() });

                        //Meses
                        if (mesReajuste.Equals(1))
                        {
                            if (mesReajuste.Equals(1))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (2 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(2))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }

                            columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (3 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(3))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (4 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(4))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (5 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(5))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (6 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(6))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (7 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(7))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (8 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(8))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });

                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (9 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(9))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });

                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (10 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(10))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Octube", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        if (11 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(11))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }


                        if (12 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(12))
                            {
                                columnas.Add(new ColumnaExportar { nombre = "Total. Eval.", tamanioAncho = 90, formato = new XlCellFormatting() });
                                segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                            }
                            columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 60, formato = new XlCellFormatting() });
                            columnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });

                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Cant.", tamanioAncho = 60, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "Importe", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }
                        else
                        {
                            columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 90, formato = new XlCellFormatting() });
                            segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 90, formato = new XlCellFormatting() });
                        }

                        columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Area", tamanioAncho = 250, formato = new XlCellFormatting() });

                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 100, formato = new XlCellFormatting() });
                        segundaFilacolumnas.Add(new ColumnaExportar { nombre = "", tamanioAncho = 250, formato = new XlCellFormatting() });

                        var listaFila = new List<CeldaExportar>();
                        decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                        string direccion = string.Empty;
                        string titulo = string.Empty;
                        string cuentaNivel1 = string.Empty;
                        string cuentaNivel2 = string.Empty;
                        string grupo = string.Empty;
                        int numInicio = 6;//inicio la ubicacion de la columna cantidad
                        int numCol = 0;//para la ubicacion de la columna cantidad

                        List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                        List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                        List<int> cantNivel1 = new List<int>();
                        List<int> cantNivel2 = new List<int>();
                        List<int> cantNivel0 = new List<int>();
                        List<int> listaNivel0 = new List<int>();
                        int filas = 0, cantInicio = 0, cantNivel3 = 0;

                        IXlSheet hoja = null;
                        foreach (var dato in lista)
                        {
                            if (!titulo.Equals(dato.titulo))
                            {
                                if (hoja != null)
                                {
                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;

                                    //Ultimo Total
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                    if (1 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(1))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (2 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(2))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (3 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(3))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (4 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(4))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (5 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(5))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (6 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(6))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (7 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(7))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (8 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(8))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (9 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(9))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (10 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(10))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }

                                    if (11 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(11))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    if (12 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(12))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor() });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });
                                    }


                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                    ((IDisposable)hoja).Dispose();
                                }

                                hoja = exportar.CrearHoja(documento, dato.codDireccion);
                                exportar.GenerarColumnas(hoja, columnas);
                                exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                                exportar.GenerarTituloPosicion(hoja, dato.desMoneda, 0, 1, columnas.Count - 1, 1);
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 4;
                                cantInicio = 4;

                                exportar.GenerarCabeceraFilasCombinarHorizontalSegunMesReajuete(hoja, columnas.Select(s => s.nombre), 3, mesReajuste);
                                exportar.GenerarCabeceraFilasCombinarVerticalSegunMesReajuete(hoja, segundaFilacolumnas.Select(s => s.nombre), 4, mesReajuste);
                            }

                            if (!dato.grupo.Equals(grupo))
                            {
                                if (!string.IsNullOrEmpty(grupo))
                                {
                                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                    numInicio = 6;//inicio la ubicacion de la columna cantidad
                                    numCol = 0;//para la ubicacion de la columna cantidad

                                    if (1 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(1))
                                        {
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel0, cantInicio) });
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }

                                    if (2 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(2))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (3 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(3))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (4 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(4))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (5 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(5))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (6 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(6))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (7 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(7))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (8 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(8))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (9 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(9))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (10 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(10))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (11 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(11))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }
                                    if (12 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(12))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });
                                        numInicio++;
                                    }

                                    numCol = numInicio;

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    cantInicio += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    listaNivel0.Add(filas);

                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;
                                    cantInicio += 1;


                                }

                                exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                                filas += 1;
                                cantInicio += 1;
                            }

                            if (hoja != null)
                            {
                                if (dato.nivel == 1)
                                {
                                    listaFila.Clear();

                                    cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                    numInicio = 6;//inicio la ubicacion de la columna cantidad
                                    numCol = 0;//para la ubicacion de la columna cantidad

                                    if (1 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(1))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }

                                    if (2 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(2))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }

                                    if (3 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(3))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (4 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(4))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (5 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(5))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (6 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(6))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (7 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(7))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (8 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(8))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (9 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(9))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (10 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(10))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (11 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(11))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }
                                    if (12 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(12))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel1, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });
                                        numInicio++;
                                    }


                                    numCol = numInicio;

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                    filas += 1;
                                    cuentaNivel1 = dato.numCuenta;
                                }
                                else if (dato.nivel == 2)
                                {
                                    cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                    numInicio = 6;//inicio la ubicacion de la columna cantidad
                                    numCol = 0;//para la ubicacion de la columna cantidad

                                    if (1 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(1))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }

                                    if (2 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(2))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }

                                    if (3 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(3))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (4 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(4))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (5 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(5))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (6 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(6))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (7 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(7))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (8 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(8))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (9 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(9))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (10 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(10))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (11 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(11))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }
                                    if (12 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(12))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel2, cantInicio) });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });
                                        numInicio++;
                                    }

                                    numCol = numInicio;

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                    filas += 1;
                                    cuentaNivel2 = dato.numCuenta;
                                }
                                else
                                {
                                    cantNivel3 = dato.EvaluacionReajusteMensualDetallePorPresupuesto.Count();

                                    listaFila.Clear();

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                    numInicio = 6;//inicio la ubicacion de la columna cantidad
                                    numCol = 0;//para la ubicacion de la columna cantidad

                                    if (1 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(1))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }

                                    if (2 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(2))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }

                                    if (3 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(3))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (4 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(4))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (5 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(5))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (6 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(6))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (7 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(7))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (8 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(8))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (9 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(9))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (10 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(10))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (11 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(11))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }
                                    if (12 >= mesReajuste)
                                    {
                                        if (mesReajuste.Equals(12))
                                        {
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                            numInicio++;
                                        }
                                        numCol = numInicio;
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, filas + 2, cantNivel3) : null });
                                        numInicio = numInicio + 2;
                                    }
                                    else
                                    {
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });
                                        numInicio++;
                                    }

                                    numCol = numInicio;

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;

                                    foreach (var dato1 in dato.EvaluacionReajusteMensualDetallePorPresupuesto)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                        numInicio = 6;//inicio la ubicacion de la columna cantidad
                                        numCol = 0;//para la ubicacion de la columna cantidad
                                        List<int> listaColumnas = new List<int>();
                                        List<int> listaColumnasEvaluacion = new List<int>();

                                        if (1 >= mesReajuste)
                                        {
                                            listaColumnas.Add(numInicio + 1);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantEnero, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formato = null });
                                            numInicio++;
                                        }

                                        if (2 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(2))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantFebrero, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formato = null });
                                            numInicio++;
                                        }

                                        if (3 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(3))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantMarzo, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formato = null });
                                            numInicio++;
                                        }
                                        if (4 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(4))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantAbril, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formato = null });
                                            numInicio++;
                                        }
                                        if (5 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(5))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantMayo, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formato = null });
                                            numInicio++;
                                        }
                                        if (6 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(6))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantJunio, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formato = null });
                                            numInicio++;
                                        }
                                        if (7 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(7))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantJulio, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formato = null });
                                            numInicio++;
                                        }
                                        if (8 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(8))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantAgosto, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formato = null });
                                            numInicio++;
                                        }
                                        if (9 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(9))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantSetiembre, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formato = null });
                                            numInicio++;
                                        }
                                        if (10 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(10))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantOctubre, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formato = null });
                                            numInicio++;
                                        }
                                        if (11 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(11))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantNoviembre, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formato = null });
                                            numInicio++;
                                        }
                                        if (12 >= mesReajuste)
                                        {
                                            if (mesReajuste.Equals(12))
                                            {
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnasEvaluacion) });
                                                numInicio++;
                                            }
                                            listaColumnas.Add(numInicio + 1);
                                            numCol = numInicio;
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.cantDiciembre, formato = null });
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formulaString = ExportarExcelHelper.MultiplicarPorCoordenadasHaciaDerechaString(5, filas + 1, numCol) });
                                            numInicio = numInicio + 2;
                                        }
                                        else
                                        {
                                            listaColumnas.Add(numInicio);
                                            listaColumnasEvaluacion.Add(numInicio);
                                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formato = null });
                                            numInicio++;
                                        }

                                        numCol = numInicio;

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(filas + 1, listaColumnas) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formato = null });

                                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                                        filas += 1;
                                    }

                                    ene += (decimal)dato.enero;
                                    feb += (decimal)dato.febrero;
                                    mar += (decimal)dato.marzo;
                                    abr += (decimal)dato.abril;
                                    may += (decimal)dato.mayo;
                                    jun += (decimal)dato.junio;
                                    jul += (decimal)dato.julio;
                                    ago += (decimal)dato.agosto;
                                    set += (decimal)dato.setiembre;
                                    oct += (decimal)dato.octubre;
                                    nov += (decimal)dato.noviembre;
                                    dic += (decimal)dato.diciembre;
                                    total += (decimal)dato.total;

                                }
                            }

                            direccion = dato.desDireccion;
                            titulo = dato.titulo;
                            grupo = dato.grupo;
                        }

                        cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                        numInicio = 6;//inicio la ubicacion de la columna cantidad
                        numCol = 0;//para la ubicacion de la columna cantidad

                        if (1 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(1))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, cantNivel0, cantInicio) });
                            numInicio++;
                        }

                        if (2 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(2))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (3 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(3))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (4 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(4))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (5 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(5))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (6 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(6))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (7 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(7))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (8 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(8))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (9 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(9))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (10 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(10))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (11 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(11))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        if (12 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(12))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, cantNivel0, cantInicio) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });
                            numInicio++;
                        }
                        numCol = numInicio;

                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });

                        filas += 1;
                        cantInicio += 1;
                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        listaNivel0.Add(filas);

                        //suma += dato.TotalNeto;
                        exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                        filas += 1;
                        ////Ultimo Total
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL REMUNERACIONES, BIENES Y SERVICIOS", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        numInicio = 6;//inicio la ubicacion de la columna cantidad
                        numCol = 0;//para la ubicacion de la columna cantidad

                        if (1 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(1))
                            {
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                            }
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                            numInicio++;
                        }

                        if (2 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(2))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (3 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(3))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (4 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(4))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (5 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(5))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (6 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(6))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (7 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(7))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (8 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(8))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (9 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(9))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (10 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(10))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (11 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(11))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                            numInicio++;
                        }
                        if (12 >= mesReajuste)
                        {
                            if (mesReajuste.Equals(12))
                            {
                                numCol = numInicio;
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numInicio, listaNivel0, 0) });
                                numInicio++;
                            }
                            numCol = numInicio;
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol + 1, listaNivel0, 0) });
                            numInicio = numInicio + 2;
                        }
                        else
                        {
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });
                            numInicio++;
                        }

                        numCol = numInicio;

                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                        //listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(numCol, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null });

                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        filas += 1;

                        ((IDisposable)hoja).Dispose();
                    }
                }
            }
        }
        public static void ExportarSubpresupuesto(string rutaArchivo, List<ReporteSubpresupuestoExportaPres> lista)
        {
            if (lista.Count > 0)
            {
                ExportarExcelHelper exportar = new ExportarExcelHelper();
                using (var archivo = exportar.CrearArchivo(rutaArchivo))
                {
                    using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                    {

                        var columnas = new List<ColumnaExportar>();
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 80, formato = new XlCellFormatting() });

                        //Meses
                        columnas.Add(new ColumnaExportar { nombre = lista.FirstOrDefault().mes, tamanioAncho = 90, formato = new XlCellFormatting() });

                        columnas.Add(new ColumnaExportar { nombre = "Area", tamanioAncho = 250, formato = new XlCellFormatting() });

                        var listaFila = new List<CeldaExportar>();
                        decimal importe = 0;
                        string direccion = string.Empty;
                        string titulo = string.Empty;
                        string cuentaNivel1 = string.Empty;
                        string cuentaNivel2 = string.Empty;
                        string grupo = string.Empty;

                        List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                        List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                        List<int> cantNivel1 = new List<int>();
                        List<int> cantNivel2 = new List<int>();
                        List<int> cantNivel0 = new List<int>();
                        List<int> listaNivel0 = new List<int>();
                        int filas = 0, cantInicio = 0, cantNivel3 = 0;

                        IXlSheet hoja = null;
                        foreach (var dato in lista)
                        {
                            if (!titulo.Equals(dato.titulo))
                            {
                                if (hoja != null)
                                {
                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;

                                    //Ultimo Total
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = importe, formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    importe = 0;
                                    ((IDisposable)hoja).Dispose();
                                }

                                hoja = exportar.CrearHoja(documento, "Presupuesto Mensual");
                                exportar.GenerarColumnas(hoja, columnas);
                                exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                                exportar.GenerarTituloPosicion(hoja, dato.desMoneda, 0, 1, columnas.Count - 1, 1);
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 3;
                                cantInicio = 3;
                                exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                            }

                            if (!dato.grupo.Equals(grupo))
                            {
                                if (!string.IsNullOrEmpty(grupo))
                                {
                                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = importe, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    cantInicio += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    listaNivel0.Add(filas);

                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;
                                    cantInicio += 1;
                                }

                                exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                                filas += 1;
                                cantInicio += 1;
                            }

                            if (hoja != null)
                            {
                                if (dato.nivel == 1)
                                {
                                    listaFila.Clear();

                                    cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Cadena,
                                        valor = dato.numCuenta,
                                        formato = ExportarExcelHelper.SoloRojoColor()
                                    });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Decimal,
                                        valor = dato.importe,
                                        formato = ExportarExcelHelper.SoloRojoColor(),
                                        formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio)
                                    });


                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                    filas += 1;
                                    cuentaNivel1 = dato.numCuenta;
                                }
                                else if (dato.nivel == 2)
                                {
                                    cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.importe, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                    filas += 1;
                                    cuentaNivel2 = dato.numCuenta;
                                }
                                else
                                {
                                    cantNivel3 = dato.ListaReporteSubpresupuestoDetalleExportaPres.Count();

                                    listaFila.Clear();

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.importe, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;

                                    foreach (var dato1 in dato.ListaReporteSubpresupuestoDetalleExportaPres)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.Abreviado, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.importe, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formato = null });

                                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                                        filas += 1;
                                    }

                                    importe += (decimal)dato.importe;
                                }
                            }

                            direccion = dato.desDireccion;
                            titulo = dato.titulo;
                            grupo = dato.grupo;
                        }

                        cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });

                        filas += 1;
                        cantInicio += 1;
                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        listaNivel0.Add(filas);

                        exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                        filas += 1;
                        ////Ultimo Total
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL REMUNERACIONES, BIENES Y SERVICIOS", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = importe, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null });

                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        filas += 1;

                        ((IDisposable)hoja).Dispose();
                    }
                }
            }
        }
        public static void ExportarProgramacionAnualGenericaDetalleResumen(string rutaArchivo, List<ReporteProgramacionAnualExportaMasivoPres> lista)
        {
            if (lista.Count > 0)
            {

                var listaResumenGenerica = lista.Where(x => x.nivel == 2).Select(s => new { idGruGen = s.idGruGen, desGenerica = s.desGenerica, posicionGen = s.posicionGen }).ToList().GroupBy(g => new { g.idGruGen, g.desGenerica, g.posicionGen }).ToList();

                List<int> listaFilasDetalle = new List<int>();//Para Resumen Generica
                List<FilaSuma> listaFilasGenerica = new List<FilaSuma>();//Para Resumen Generica

                ExportarExcelHelper exportar = new ExportarExcelHelper();

                using (var archivo = exportar.CrearArchivo(rutaArchivo))
                {
                    using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                    {
                        var columnas = new List<ColumnaExportar>();
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 40, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "CTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Descripción", tamanioAncho = 350, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Unidad", tamanioAncho = 50, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Prec. Uni", tamanioAncho = 80, formato = new XlCellFormatting() });

                        //Meses
                        columnas.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 100, formato = new XlCellFormatting() });

                        columnas.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 120, formato = new XlCellFormatting() });
                        columnas.Add(new ColumnaExportar { nombre = "Area", tamanioAncho = 250, formato = new XlCellFormatting() });

                        var listaFila = new List<CeldaExportar>();
                        decimal ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, set = 0, oct = 0, nov = 0, dic = 0, total = 0;
                        string direccion = string.Empty;
                        string titulo = string.Empty;
                        var desMoneda = lista.FirstOrDefault().desMoneda;
                        string cuentaNivel1 = string.Empty;
                        string cuentaNivel2 = string.Empty;
                        string grupo = string.Empty;

                        List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                        List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                        List<int> cantNivel1 = new List<int>();
                        List<int> cantNivel2 = new List<int>();
                        List<int> cantNivel0 = new List<int>();
                        List<int> listaNivel0 = new List<int>();
                        int filas = 0, cantInicio = 0, cantNivel3 = 0;

                        IXlSheet hoja = null;
                        foreach (var dato in lista)
                        {
                            if (!titulo.Equals(dato.titulo))
                            {
                                if (hoja != null)
                                {
                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;

                                    //Ultimo Total
                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "T", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    ene = 0; feb = 0; mar = 0; abr = 0; may = 0; jun = 0; jul = 0; ago = 0; set = 0; oct = 0; nov = 0; dic = 0; total = 0;
                                    ((IDisposable)hoja).Dispose();
                                }

                                hoja = exportar.CrearHoja(documento, "Presupuesto Anual Gen.");
                                exportar.GenerarColumnas(hoja, columnas);
                                exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                                exportar.GenerarTituloPosicion(hoja, dato.desMoneda, 0, 1, columnas.Count - 1, 1);
                                exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                filas += 3;
                                cantInicio = 3;
                                exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                            }

                            if (!dato.grupo.Equals(grupo))
                            {
                                if (!string.IsNullOrEmpty(grupo))
                                {
                                    cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                                    filas += 1;
                                    cantInicio += 1;
                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    listaNivel0.Add(filas);

                                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                                    filas += 1;
                                    cantInicio += 1;
                                }

                                exportar.GenerarTituloPosicionColor(hoja, dato.grupo, 0, filas + 1, columnas.Count - 1, filas + 1, XlColor.FromArgb(50, 113, 7));
                                filas += 1;
                                cantInicio += 1;
                            }

                            if (hoja != null)
                            {
                                if (dato.nivel == 1)
                                {
                                    listaFila.Clear();

                                    cantNivel1 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 2).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Cadena,
                                        valor = dato.numCuenta,
                                        formato = ExportarExcelHelper.SoloRojoColor()
                                    });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                                    listaFila.Add(new CeldaExportar
                                    {
                                        tipoDato = TipoDatoExportar.Decimal,
                                        valor = dato.enero,
                                        formato = ExportarExcelHelper.SoloRojoColor(),
                                        formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, cantInicio)
                                    });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloRojoColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel1);
                                    filas += 1;
                                    cuentaNivel1 = dato.numCuenta;
                                }
                                else if (dato.nivel == 2)
                                {
                                    cantNivel2 = lista.Where(c => dato.desDireccion.Equals(c.desDireccion) && c.numCuenta.StartsWith(dato.numCuenta) && c.nivel == 3).Select(s => (Int32)s.posicion).ToList();

                                    listaFila.Clear();
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = cuentaNivel1, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), incluyeFormula = false });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, cantInicio) });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, cantInicio) });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFilaMasPosicion(hoja, listaFila, 20, listaPosicionesNivel2);
                                    filas += 1;
                                    cuentaNivel2 = dato.numCuenta;
                                    var filaGenerica = new FilaSuma { fila = filas, id = (int)dato.idGruGen };
                                    listaFilasGenerica.Add(filaGenerica);
                                }
                                else
                                {
                                    cantNivel3 = dato.ListaReporteProgramacionAnualDetalleExportaMasivoPres.Count();

                                    listaFila.Clear();

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor() });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, filas + 2, cantNivel3) : null });

                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.total, formato = ExportarExcelHelper.SoloNegritaColor(), formula = cantNivel3 > 0 ? ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, filas + 2, cantNivel3) : null });
                                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloNegritaColor(), formula = null });

                                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                                    filas += 1;

                                    foreach (var dato1 in dato.ListaReporteProgramacionAnualDetalleExportaMasivoPres)
                                    {
                                        listaFila.Clear();
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.descripcion, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desUnidad, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.precio, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.enero, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.febrero, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.marzo, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.abril, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.mayo, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.junio, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.julio, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.agosto, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.setiembre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.octubre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.noviembre, formato = null });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato1.diciembre, formato = null });

                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12) });
                                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato1.desArea, formato = null });

                                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                                        filas += 1;
                                    }

                                    ene += (decimal)dato.enero;
                                    feb += (decimal)dato.febrero;
                                    mar += (decimal)dato.marzo;
                                    abr += (decimal)dato.abril;
                                    may += (decimal)dato.mayo;
                                    jun += (decimal)dato.junio;
                                    jul += (decimal)dato.julio;
                                    ago += (decimal)dato.agosto;
                                    set += (decimal)dato.setiembre;
                                    oct += (decimal)dato.octubre;
                                    nov += (decimal)dato.noviembre;
                                    dic += (decimal)dato.diciembre;
                                    total += (decimal)dato.total;

                                }
                            }

                            direccion = dato.desDireccion;
                            titulo = dato.titulo;
                            grupo = dato.grupo;
                        }

                        cantNivel0 = lista.Where(c => c.desDireccion.Equals(direccion) && c.grupo.Equals(grupo) && c.nivel == 1).Select(s => (Int32)s.posicion).ToList();

                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = string.Format("TOTAL {0}", grupo.Replace("PRESUPUESTO DE", "").ToUpper()), formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel0, cantInicio) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel0, cantInicio) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), formula = null });

                        filas += 1;
                        cantInicio += 1;
                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        listaNivel0.Add(filas);

                        exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                        filas += 1;
                        ////Ultimo Total
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL REMUNERACIONES, BIENES Y SERVICIOS", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaNivel0, 0) });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaNivel0, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor(), formula = null });

                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        filas += 1;

                        //Resumen----------------------------------------------------------------
                        var columnasResumenGenerica = new List<ColumnaExportar>();

                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "GENÉRICA DE GATOS - DEVIDA", tamanioAncho = 350, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "", tamanioAncho = 50, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "", tamanioAncho = 80, formato = new XlCellFormatting() });
                        //Meses
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Enero", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Febrero", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Marzo", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Abril", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Mayo", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Junio", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Julio", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Agosto", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Setiembre", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Octubre", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Noviembre", tamanioAncho = 100, formato = new XlCellFormatting() });
                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Diciembre", tamanioAncho = 100, formato = new XlCellFormatting() });

                        columnasResumenGenerica.Add(new ColumnaExportar { nombre = "Total", tamanioAncho = 120, formato = new XlCellFormatting() });

                        if (listaResumenGenerica.Count > 0)
                        {
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 2;
                            exportar.GenerarTituloPosicion(hoja, titulo, 3, filas, columnasResumenGenerica.Count + 2, filas, ExportarExcelHelper.formatoPersonalizado(true, 18, true));
                            filas += 1;
                            exportar.GenerarTituloPosicion(hoja, desMoneda, 3, filas, columnasResumenGenerica.Count + 2, filas, ExportarExcelHelper.formatoPersonalizado(false, 11, true));
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            exportar.GenerarCabeceraFilas(hoja, 3, columnasResumenGenerica.Select(s => s.nombre));
                            filas += 2;


                            foreach (var dato in listaResumenGenerica.OrderBy(x => x.Key.posicionGen))
                            {
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = new XlCellFormatting() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = new XlCellFormatting() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = new XlCellFormatting() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.Key.desGenerica, formato = ExportarExcelHelper.NormalConBorde() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.NormalConBorde() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.NormalConBorde() });


                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaFilasGenerica.Where(x => x.id == dato.Key.idGruGen).ToList().Select(s => s.fila).ToList(), 0) });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0.00m, formato = ExportarExcelHelper.NormalConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas + 1, 12) });

                                exportar.GenerarDatosFila(hoja, listaFila, 20);//genera fila
                                filas += 1;

                                listaFilasDetalle.Add(filas);

                            }

                            filas += 1;
                            //Ultimo Total resumen
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = new XlCellFormatting() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = new XlCellFormatting() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = new XlCellFormatting() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloAzulColorConBorde() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColorConBorde() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColorConBorde() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, listaFilasDetalle, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, listaFilasDetalle, 0) });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColorConBorde(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, listaFilasDetalle, 0) });

                            exportar.GenerarDatosFila(hoja, listaFila, 20);//genera fila
                            filas += 1;
                        }

                        ((IDisposable)hoja).Dispose();
                    }
                }
            }
        }
    }
}
