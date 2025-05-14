using DevExpress.Export.Xl;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Adquisicion.Helper
{
    public class ExportarHelperAdquisicion
    {
        public static void ExportarEvaluacionDetalladaBienServicio(string rutaArchivo, List<ReporteEvaluacionDetalladaBienSerExportaPres> lista)
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
                    string titulo = string.Empty;
                    string cuentaNivel1 = string.Empty, cuentaNivel1_ = string.Empty;
                    string cuentaNivel2 = string.Empty, cuentaNivel2_ = string.Empty;
                    


                    List<PosicionFormula> listaPosicionesNivel1 = new List<PosicionFormula>();
                    List<PosicionFormula> listaPosicionesNivel2 = new List<PosicionFormula>();
                    List<int> cantNivel1 = new List<int>();
                    List<int> cantNivel2 = new List<int>();
                    List<int> cantNivel0 = new List<int>();
                    List<int> listaNivel0 = new List<int>();
                    int filas = 0, cantInicio = 0, cantDetalle = 0;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        cuentaNivel1 = dato.numCuentaN1;
                        cuentaNivel2 = dato.numCuentaN2;

                        if (!titulo.Equals(dato.titulo))
                        {
                            hoja = exportar.CrearHoja(documento, "Evaluacion Detallada");
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, dato.titulo, columnas.Count - 1);
                            exportar.GenerarTituloPosicion(hoja, "(EXPRESADO EN DOLARES AMERICANOS)", 0, 1, columnas.Count - 1, 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 4;
                            cantInicio = 6;
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                            titulo = dato.titulo;

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuentaN1, formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuentaN1, formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            filas += 1;
                            /*******************************/
                            /*Cuenta Nivel 2*/
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuentaN2, formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuentaN2, formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            filas += 1;
                            /*Fin Cuenta Nivel 2*/
                            cuentaNivel1_ = cuentaNivel1;
                            cuentaNivel2_ = cuentaNivel2;
                        }

                        if (!cuentaNivel1_.Equals(cuentaNivel1))
                        {
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL ", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantInicio, cantDetalle) });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantInicio, cantDetalle) });
                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            cantNivel2.Add(filas);
                            filas += 1;
                            cantDetalle = 0;

                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL ", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, 0) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, 0) });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, 0) });
                            
                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            cantNivel1.Add(filas);
                            cantNivel2.Clear();
                            filas += 1;
                            
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 1;
                            /*Cuenta Nivel 1*/
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuentaN1, formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuentaN1, formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor(), });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            filas += 1;
                            /*Fin Cuenta Nivel 1*/

                            /*Cuenta Nivel 2*/
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuentaN2, formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuentaN2, formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            filas += 1;
                            /*Fin Cuenta Nivel 2*/
                            cantInicio = filas;
                            cuentaNivel1_ = cuentaNivel1;
                            cuentaNivel2_ = cuentaNivel2;
                        }

                        if (!cuentaNivel2_.Equals(cuentaNivel2))
                        {
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantInicio, cantDetalle) });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantInicio, cantDetalle) });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantInicio, cantDetalle) });
                            cantDetalle = 0;
                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            cantNivel2.Add(filas);
                            filas += 1;
                            
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            filas += 1;
                            /*Cuenta Nivel 2*/
                            listaFila.Clear();
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuentaN2, formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuentaN2, formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });
                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor(), });

                            listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                            exportar.GenerarDatosFila(hoja, listaFila, 20);
                            filas += 1;
                            /*Fin Cuenta Nivel 2*/

                            cantInicio = filas;
                            cuentaNivel2_ = cuentaNivel2;
                        }

                        listaFila.Clear();

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.Abreviado, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.precio, formato = null });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.enero, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.febrero, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.marzo, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.abril, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.mayo, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.junio, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.julio, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.agosto, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.setiembre, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.octubre, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.noviembre, formato = null });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.diciembre, formato = null });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloNegritaColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaDerecha(6, filas, 12) });

                        /*Imprime Detalle*/
                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        cantDetalle += 1;
                        filas += 1;
                    }

                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL ", formato = ExportarExcelHelper.SoloRojoColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloRojoColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantInicio, cantDetalle) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantInicio, cantDetalle) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantInicio, cantDetalle) });
                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    cantNivel2.Add(filas);
                    filas += 1;
                    cantDetalle = 0;

                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL ", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel2, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel2, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel2, 0) });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    cantNivel1.Add(filas);
                    cantNivel2.Clear();
                    filas += 1;

                    exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                    filas += 1;
                    ////
                    listaFila.Clear();

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL GENERAL", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ene, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = feb, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = mar, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = abr, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(9, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = may, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(10, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jun, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(11, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = jul, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(12, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = ago, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(13, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = set, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(14, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = oct, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(15, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = nov, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(16, cantNivel1, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dic, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(17, cantNivel1, 0) });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = total, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(18, cantNivel1, 0) });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;
                    cantNivel1.Add(filas);

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
        public static void ExportarEvaluacionPresupuestoPorCuentas(string rutaArchivo, List<ReporteEvaluacionPresupuestoPorCuentasPres> lista, int idMoneda, string desPresupuesto, string desSubPresupuesto)
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

                    List<int> listaPosicionN2 = new List<int>();
                    List<int> listaPosicionN3 = new List<int>();
                    List<int> listaNivel0 = new List<int>();


                    int filas = 0, filaInicio = 6, filaInicioN2 = 0, cantInicio = 0;
                    string numCuenta = string.Empty;

                    bool imprimeTitulo = false;
                    string titulo = idMoneda==63 ? "(EXPRESADO EN SOLES)" : "(EXPRESADO EN DOLARES AMERICANOS)";

                    List<XlCellRange> listaNivel_1 = new List<XlCellRange>();


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
                            cantInicio = 7;
                        }
                        /*Buscamos posicion de detalles */
                        listaPosicionN2.Clear();
                        
                        if (dato.ListaDivisionarias.Count > 0)
                        {
                            bool primeravez = true;
                            foreach (var divisionaria in dato.ListaDivisionarias)
                            {
                                filaInicio++;
                                if (primeravez) filaInicioN2 = filaInicio;
                                primeravez = false;
                                listaPosicionN2.Add(filaInicio);
                                if (divisionaria.ListaCuentasEspecificas.Count > 0)
                                {
                                    foreach (var cuenta in divisionaria.ListaCuentasEspecificas)
                                    {
                                        filaInicio++;
                                        if (cuenta.ListaDeVouchers.Count > 0)
                                        {
                                            foreach (var voucher in cuenta.ListaDeVouchers)
                                            {
                                                filaInicio++;
                                            }
                                            filaInicio = filaInicio + 1;
                                        }
                                    }
                                }
                            }
                        }
                        
                        
                        /*Cuenta Nivel 1*/
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desCuenta, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.importePre, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaPosicionN2, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.importeEje, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaPosicionN2, 0) });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.saldo, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaPosicionN2, 0) });
                        listaNivel_1.Add(XlCellRange.FromLTRB(6, 7, 6, 7));
                        exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                        filas += 1;
                        cantInicio += 1;
                        filaInicio = filaInicio + 1;
                        listaNivel0.Add(filas - 2);

                        /*Fin Cuenta Nivel 1*/
                        /*Cuenta Nivel 2*/
                        if (dato.ListaDivisionarias.Count>0)
                        {
                            foreach (var divisionaria in dato.ListaDivisionarias)
                            {

                                /*Buscamos posicion de detalles */
                                listaPosicionN3.Clear();
                                if (divisionaria.ListaCuentasEspecificas.Count > 0)
                                {
                                    foreach (var cuenta in divisionaria.ListaCuentasEspecificas)
                                    {
                                        filaInicioN2++;
                                        listaPosicionN3.Add(filaInicioN2);
                                        if (cuenta.ListaDeVouchers.Count > 0)
                                        {
                                            foreach (var voucher in cuenta.ListaDeVouchers)
                                            {
                                                filaInicioN2++;
                                            }
                                            filaInicioN2 = filaInicioN2 + 1;
                                        }
                                    }
                                }
                                listaFila.Clear();
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = divisionaria.numCuenta, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = divisionaria.desCuenta, formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloVerdeColor() });

                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.importePre, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaPosicionN3, 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.importeEje, formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaPosicionN3, 0) });
                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = divisionaria.saldo , formato = ExportarExcelHelper.SoloVerdeColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaPosicionN3, 0) });

                                exportar.GenerarDatosFilaCombina(hoja, listaFila, 20, 3, filas - 1, 5);
                                filas += 1;
                                cantInicio += 1;
                                filaInicioN2 = filaInicioN2 + 1;
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
                                        cantInicio += 1;
                                        /*Fin Cuenta Nivel 3*/
                                        if (cuenta.ListaDeVouchers.Count > 0)
                                        {
                                            /*imprimir titulo de detalle*/
                                            //exportar.GenerarCabeceraFilas(hoja, columnasVoocher.Select(s => s.nombre));
                                            exportar.GenerarCabeceraFilasDetalle(hoja, columnasVoucher.Select(s => s.nombre), 3);
                                            filas += 1;
                                            cantInicio += 1;
                                            foreach (var detalle in cuenta.ListaDeVouchers)
                                            {
                                                listaFila.Clear();
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = detalle.numero, formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Fecha, valor = detalle.fechaMov, formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = detalle.glosa, formato = null });

                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = detalle.importe, formato = null });
                                                listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = null });

                                                exportar.GenerarDatosFila(hoja, listaFila, 20);
                                                filas += 1;
                                                cantInicio += 1;
                                                /*Fin detalle*/

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }// fin lista clase

                    ////Ultimo Total
                    listaFila.Clear();
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "TOTAL ", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = "", formato = ExportarExcelHelper.SoloAzulColor() });

                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(6, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(7, listaNivel0, 0) });
                    listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = 0, formato = ExportarExcelHelper.SoloAzulColor(), formula = ExportarExcelHelper.SumarPorCoordenadasHaciaAbajo(8, listaNivel0, 0) });

                    exportar.GenerarDatosFila(hoja, listaFila, 20);
                    filas += 1;

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
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.monEjeAct, formato = ExportarExcelHelper.SoloAzulColor()});
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
        public static void ExportarCertificacionRequerimiento(string rutaArchivo, List<CertificacionRequerimientoExportaPres> lista, int tipoReq)
        {
            ExportarExcelHelper exportar = new ExportarExcelHelper();
            using (var archivo = exportar.CrearArchivo(rutaArchivo))
            {
                using (var documento = exportar.CrearDocumento(archivo, XlDocumentFormat.Xlsx))
                {

                    var columnas = new List<ColumnaExportar>();

                    columnas.Add(new ColumnaExportar { nombre = "N° DE CERTIFICACION", tamanioAncho = 150, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "FECHA", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = tipoReq == 0 ? "REQUERIMIENTO" : tipoReq == 1 ? "FOREBI" : "FORESE", tamanioAncho = 120, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "PRESUPUESTO", tamanioAncho = 250, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "SUBPRESUPUESTO", tamanioAncho = 300, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "DIRECCION", tamanioAncho = 220, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "CUENTA", tamanioAncho = 60, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "RUBRO", tamanioAncho = 150, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "JUSTIFICACION", tamanioAncho = 200, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "ESTADO", tamanioAncho = 150, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "ORDEN", tamanioAncho = 150, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "DESCRIPCION BIEN/SERVICIO", tamanioAncho = 200, formato = new XlCellFormatting() });
                    //Importe
                    columnas.Add(new ColumnaExportar { nombre = "CANTIDAD", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "UNIDAD", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "PRECIO S/", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "MONTO S/", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "T. CAMBIO", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "PRECIO US$", tamanioAncho = 80, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "MONTO US$ ", tamanioAncho = 90, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "USUARIO", tamanioAncho = 75, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "FECHA", tamanioAncho = 130, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "USUARIO AMPL.", tamanioAncho = 110, formato = new XlCellFormatting() });
                    columnas.Add(new ColumnaExportar { nombre = "FECHA AMPL.", tamanioAncho = 130, formato = new XlCellFormatting() });

                    var listaFila = new List<CeldaExportar>();

                    int filas = 0;

                    bool imprimeTitulo = true;

                    IXlSheet hoja = null;
                    foreach (var dato in lista)
                    {
                        if (imprimeTitulo)
                        {
                            hoja = exportar.CrearHoja(documento, "Lista Certificado");
                            exportar.GenerarColumnas(hoja, columnas);
                            exportar.GenerarTitulo(hoja, "LISTA CERTIFICACION DE REQUERIMIENTO", columnas.Count - 1);
                            exportar.GenerarFilaEnBlanco(hoja, columnas.Count);
                            exportar.GenerarCabeceraFilas(hoja, columnas.Select(s => s.nombre));
                            filas += 1;
                            imprimeTitulo = false;
                        }

                        /*Cuenta Nivel 1*/
                        listaFila.Clear();
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.sigla.ToString() });//, formato = ExportarExcelHelper.SoloAzulColor() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Fecha, valor = dato.fechaEmision });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numeroReq.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desPresupuesto.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desSubpresupuesto.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.direccion });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numCuenta.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.rubro.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.descripcion.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.estadoReq.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.numOrden.ToString() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.desProductoServicio.ToString() });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.cantidad });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.unidad });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.precio });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.totalSoles });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.tipoCambio });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.precioDolares });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Decimal, valor = dato.totalDolares });

                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.usuCrea });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.FechaHora, valor = dato.fechaCrea, formato = new XlCellFormatting() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.Cadena, valor = dato.usuAmp, formato = new XlCellFormatting() });
                        listaFila.Add(new CeldaExportar { tipoDato = TipoDatoExportar.FechaHora, valor = dato.fechaAmp, formato = new XlCellFormatting() });

                        exportar.GenerarDatosFila(hoja, listaFila, 20);
                        filas += 1;
                        
                    }// fin lista

                    ((IDisposable)hoja).Dispose();
                }
            }
        }
    }
}
