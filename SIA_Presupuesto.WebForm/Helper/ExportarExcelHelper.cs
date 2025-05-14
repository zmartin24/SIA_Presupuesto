using DevExpress.Export.Xl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Helper
{
    public class ExportarExcelHelper
    {

        public FileStream CrearArchivo(string nombreArchivo)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(nombreArchivo, FileMode.Create);
            }
            catch (Exception ex)
            {
                string msj = "Error : " + ex.Message;
            }
            return stream;
        }

        public IXlDocument CrearDocumento(FileStream stream, XlDocumentFormat formato)
        {
            IXlDocument documento = null;
            try
            {
                IXlExporter exporter = XlExport.CreateExporter(formato);
                documento = exporter.CreateDocument(stream);
            }
            catch (Exception ex)
            {
                string msj = "Error : " + ex.Message;
            }
            return documento;
        }

        public IXlSheet CrearHoja(IXlDocument document, string tituloHoja)
        {
            document.Options.Culture = CultureInfo.CurrentCulture;
            IXlSheet hoja = document.CreateSheet();
            
            hoja.Name = tituloHoja;
            ParametroConfiguracionHoja(hoja, tituloHoja);
            hoja.PrintArea = hoja.DataRange;
            return hoja;
        }

        /*Genera columnas*/
        public void GenerarColumnas(IXlSheet hoja, List<ColumnaExportar> columnas)
        {
            foreach (var columna in columnas)
            {
                using (IXlColumn column = hoja.CreateColumn())
                {
                    column.WidthInPixels = columna.tamanioAncho;
                    if (columna.formato != null)
                        column.ApplyFormatting(columna.formato);
                }
            }
        }

        public void GenerarTitulo(IXlSheet hoja, string vtitulo, int cantColumnas)
        {
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Name = "Calibri";
            formatting.Font.SchemeStyle = XlFontSchemeStyles.None;
            formatting.Font.Size = 18;
            formatting.Font.Color = Color.FromArgb(0x00, 0x00, 0x00); //XlColor.FromTheme(XlThemeColor.Dark1, 0.35);
            formatting.Border = new XlBorder();
            formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

            formatting.Alignment = new XlCellAlignment();
            formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;

            using (IXlRow row = hoja.CreateRow())
            {
                using (IXlCell cell = row.CreateCell())
                {
                    cell.Value = vtitulo.ToUpper();
                    cell.Formatting = formatting;
                }
                row.BlankCells(cantColumnas, formatting);
            }
            hoja.MergedCells.Add(XlCellRange.FromLTRB(0, 0, cantColumnas, 0));
        }

        public void GenerarTituloPosicion(IXlSheet hoja, string vtitulo, int columnaInicio, int filaInicio, int cantColumnas, int cantFilas)
        {
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Name = "Calibri";
            formatting.Font.SchemeStyle = XlFontSchemeStyles.None;
            formatting.Font.Size = 11;
            formatting.Font.Color = Color.FromArgb(0x00, 0x00, 0x00); //XlColor.FromTheme(XlThemeColor.Dark1, 0.35);
            formatting.Border = new XlBorder();
            formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

            formatting.Alignment = new XlCellAlignment();
            formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;

            using (IXlRow row = hoja.CreateRow())
            {
                using (IXlCell cell = row.CreateCell())
                {
                    cell.Value = vtitulo.ToUpper();
                    cell.Formatting = formatting;
                }
                row.BlankCells(cantColumnas, formatting);
            }
            hoja.MergedCells.Add(XlCellRange.FromLTRB(columnaInicio, filaInicio, cantColumnas, cantFilas));
        }

        public void GenerarTituloPosicionColor(IXlSheet hoja, string vtitulo, int columnaInicio, int filaInicio, int cantColumnas, int cantFilas, XlColor color)
        {
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Name = "Calibri";
            formatting.Font.SchemeStyle = XlFontSchemeStyles.None;
            formatting.Font.Size = 11;
            formatting.Font.Color = color;// Color.FromArgb(0x00, 0x00, 0x00); //XlColor.FromTheme(XlThemeColor.Dark1, 0.35);
            formatting.Font.Bold = true;

            //formatting.Border = new XlBorder();
            //formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            //formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
            //formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
            //formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
            //formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
            //formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
            //formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
            //formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

            formatting.Alignment = new XlCellAlignment();
            formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Left;

            using (IXlRow row = hoja.CreateRow())
            {
                using (IXlCell cell = row.CreateCell())
                {
                    cell.Value = vtitulo.ToUpper();
                    cell.Formatting = formatting;
                }
                row.BlankCells(cantColumnas, formatting);
            }
            hoja.MergedCells.Add(XlCellRange.FromLTRB(columnaInicio, filaInicio, cantColumnas, cantFilas));
        }

        public void GenerarSubtitulo(IXlSheet hoja, string vtitulo)
        {
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Name = "Calibri";
            formatting.Font.SchemeStyle = XlFontSchemeStyles.None;
            formatting.Font.Size = 18;
            formatting.Font.Color = Color.FromArgb(0x00, 0x00, 0x00); //XlColor.FromTheme(XlThemeColor.Dark1, 0.35);
            formatting.Border = new XlBorder();
            formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

            formatting.Alignment = new XlCellAlignment();
            formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;

            using (IXlRow row = hoja.CreateRow())
            {
                using (IXlCell cell = row.CreateCell())
                {
                    cell.Value = vtitulo.ToUpper();
                    cell.Formatting = formatting;
                }

                row.BlankCells(13, formatting);
            }
            hoja.MergedCells.Add(XlCellRange.FromLTRB(0, 0, 13, 0));
        }

        public void GenerarCabeceraFilas(IXlSheet hoja, IEnumerable<string> nombreColumnas)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                foreach (string columnName in nombreColumnas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);

                        formatting.Border = new XlBorder();
                        formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                        formatting.Alignment = new XlCellAlignment();
                        formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;

                        cell.Value = columnName;
                        cell.ApplyFormatting(formatting);
                    }
                }
            }

            //sheet.MergedCells.Add(XlCellRange.FromLTRB(2, vpos_top_button, 3, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(4, vpos_top_button, 5, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(6, vpos_top_button, 7, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(8, vpos_top_button, 9, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(10, vpos_top_button, 11, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(12, vpos_top_button, 13, vpos_top_button));

        }
        public void GenerarTituloPosicion(IXlSheet hoja, string vtitulo, int columnaInicio, int filaInicio, int cantColumnas, int cantFilas, XlCellFormatting formatting)
        {
            formatting.Alignment = new XlCellAlignment();
            formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;

            using (IXlRow row = hoja.CreateRow())
            {
                using (IXlCell cell = row.CreateCell(columnaInicio))
                {
                    cell.Value = vtitulo.ToUpper();
                    cell.Formatting = formatting;
                }
                row.BlankCells(cantColumnas - columnaInicio, formatting);
            }
            hoja.MergedCells.Add(XlCellRange.FromLTRB(columnaInicio, filaInicio, cantColumnas, cantFilas));
        }
        public void GenerarCabeceraFilas(IXlSheet hoja, IEnumerable<string> nombreColumnas, int tamanioAlto)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                row.HeightInPixels = tamanioAlto;
                foreach (string columnName in nombreColumnas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);


                        formatting.Border = new XlBorder();
                        formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                        formatting.Alignment = new XlCellAlignment();
                        formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                        formatting.Alignment.VerticalAlignment = XlVerticalAlignment.Center;
                        formatting.Alignment.WrapText = true;

                        cell.Value = columnName;
                        cell.ApplyFormatting(formatting);
                    }
                }
            }

            //sheet.MergedCells.Add(XlCellRange.FromLTRB(2, vpos_top_button, 3, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(4, vpos_top_button, 5, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(6, vpos_top_button, 7, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(8, vpos_top_button, 9, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(10, vpos_top_button, 11, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(12, vpos_top_button, 13, vpos_top_button));

        }
        public void GenerarCabeceraFilas(IXlSheet hoja, int colIni, IEnumerable<string> nombreColumnas)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                foreach (string columnName in nombreColumnas)
                {
                    using (IXlCell cell = row.CreateCell(colIni))
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);

                        formatting.Border = new XlBorder();
                        formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                        formatting.Alignment = new XlCellAlignment();
                        formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                        formatting.Alignment.VerticalAlignment = XlVerticalAlignment.Center;

                        cell.Value = columnName;
                        cell.ApplyFormatting(formatting);
                    }
                    colIni++;
                }
            }

            //sheet.MergedCells.Add(XlCellRange.FromLTRB(2, vpos_top_button, 3, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(4, vpos_top_button, 5, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(6, vpos_top_button, 7, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(8, vpos_top_button, 9, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(10, vpos_top_button, 11, vpos_top_button));
            //sheet.MergedCells.Add(XlCellRange.FromLTRB(12, vpos_top_button, 13, vpos_top_button));

        }
        public void GenerarCabeceraFilasCombinar(IXlSheet hoja, IEnumerable<string> nombreColumnas, int vpos_left, int vpos_top_button, int vpos_top_right)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                foreach (string columnName in nombreColumnas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);


                        formatting.Border = new XlBorder();
                        formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                        formatting.Alignment = new XlCellAlignment();
                        formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                        formatting.Alignment.VerticalAlignment = XlVerticalAlignment.Center;
                        formatting.Alignment.WrapText = true;

                        cell.Value = columnName;
                        cell.Formatting = formatting;
                        //cell.ApplyFormatting(formatting);
                    }
                }
            }

            hoja.MergedCells.Add(XlCellRange.FromLTRB(vpos_left, vpos_top_button, vpos_top_right, vpos_top_button));

        }
        public void GenerarCabeceraFilasDetalle(IXlSheet hoja, IEnumerable<string> nombreColumnas, int columnaInicio)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                int cont = 0;
                foreach (string columnName in nombreColumnas)
                {

                    using (IXlCell cell = row.CreateCell())
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        if (cont >= columnaInicio)
                        {
                            formatting.Border = new XlBorder();
                            formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                            formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                            formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                            formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                            formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                            formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                            formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                            formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                            formatting.Fill = XlFill.SolidFill(Color.FromArgb(192, 192, 192));

                            formatting.Alignment = new XlCellAlignment();
                            formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                        }
                        cell.Value = columnName;
                        cell.ApplyFormatting(formatting);
                        cont = cont + 1;
                    }
                }
            }
        }
        public void CombinacionesColumnas(IXlSheet hoja, List<ColumnaExportar> listaColumnasCombinar)
        {
            foreach (var columna in listaColumnasCombinar)
            {
                if (columna.NroCeldasCombinarHaciaIzquierda > 0 || columna.NroCeldasCombinarHaciaArriba > 0
                    || columna.NroCeldasCombinarHaciaDerecha > 0 || columna.NroCeldasCombinarHaciaAbajo > 0)
                    hoja.MergedCells.Add(XlCellRange.FromLTRB(columna.NroCeldasCombinarHaciaIzquierda, columna.NroCeldasCombinarHaciaArriba,
                        columna.NroCeldasCombinarHaciaDerecha, columna.NroCeldasCombinarHaciaAbajo));
            }
        }

        public void GenerarDatosFila(IXlSheet sheet, List<CeldaExportar> celdas, int tamanioAlto)
        {
            // Create the data row to display the employee's information.
            using (IXlRow row = sheet.CreateRow())
            {
                row.HeightInPixels = tamanioAlto;

                foreach (var celda in celdas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        switch (celda.tipoDato)
                        {
                            case TipoDatoExportar.Vacio:
                                cell.Value = string.Empty;
                                break;
                            case TipoDatoExportar.Cadena:
                                cell.Value = Convert.ToString(celda.valor);
                                break;
                            case TipoDatoExportar.Entero:
                                cell.Value = Convert.ToInt32(celda.valor);
                                break;
                            case TipoDatoExportar.Decimal:
                                cell.Value = Convert.ToDouble(celda.valor);
                                cell.Formatting = XlNumberFormat.NumberWithThousandSeparator2;
                                break;
                            case TipoDatoExportar.Fecha:
                                cell.Value = Convert.ToDateTime(celda.valor);
                                cell.Formatting = XlNumberFormat.ShortDate;
                                break;
                        }

                        if (celda.formato != null)
                            cell.ApplyFormatting(celda.formato);
                        if (celda.formula != null)
                            cell.SetFormula(celda.formula);
                    }
                }
            }
        }
        public void GenerarDatosFilaCombina(IXlSheet sheet, List<CeldaExportar> celdas, int tamanioAlto, int vpos_left, int vpos_top_button, int vpos_top_right)
        {
            // Create the data row to display the employee's information.
            using (IXlRow row = sheet.CreateRow())
            {
                row.HeightInPixels = tamanioAlto;

                foreach (var celda in celdas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        switch (celda.tipoDato)
                        {
                            case TipoDatoExportar.Vacio:
                                cell.Value = string.Empty;
                                break;
                            case TipoDatoExportar.Cadena:
                                cell.Value = Convert.ToString(celda.valor);
                                break;
                            case TipoDatoExportar.Entero:
                                cell.Value = Convert.ToInt32(celda.valor);
                                break;
                            case TipoDatoExportar.Decimal:
                                cell.Value = Convert.ToDouble(celda.valor);
                                cell.Formatting = XlNumberFormat.NumberWithThousandSeparator2;
                                break;
                            case TipoDatoExportar.Fecha:
                                XlNumberFormat fechaFormat = @"dd/mm/yyyy";
                                cell.Value = Convert.ToDateTime(celda.valor);
                                cell.Formatting = fechaFormat; //XlNumberFormat.ShortDate;

                                break;
                        }

                        if (celda.formato != null)
                            cell.ApplyFormatting(celda.formato);
                        if (celda.formula != null)
                            cell.SetFormula(celda.formula);
                    }
                    //sheet.MergedCells.Add(XlCellRange.FromLTRB(vpos_left, vpos_top_button, vpos_top_right, vpos_top_button));
                }
                sheet.MergedCells.Add(XlCellRange.FromLTRB(vpos_left, vpos_top_button, vpos_top_right, vpos_top_button));
            }
        }
        public void GenerarDatosFilaMasPosicion(IXlSheet sheet, List<CeldaExportar> celdas, int tamanioAlto, List<PosicionFormula> listaPosiciones)
        {
            // Create the data row to display the employee's information.
            using (IXlRow row = sheet.CreateRow())
            {
                row.HeightInPixels = tamanioAlto;

                foreach (var celda in celdas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        
                        switch (celda.tipoDato)
                        {
                            case TipoDatoExportar.Vacio:
                                cell.Value = string.Empty;
                                break;
                            case TipoDatoExportar.Cadena:
                                cell.Value = Convert.ToString(celda.valor);
                                break;
                            case TipoDatoExportar.Entero:
                                cell.Value = Convert.ToInt32(celda.valor);
                                break;
                            case TipoDatoExportar.Decimal:
                                cell.Value = Convert.ToDouble(celda.valor);
                                cell.Formatting = XlNumberFormat.NumberWithThousandSeparator2;
                                break;
                            case TipoDatoExportar.Fecha:
                                cell.Value = Convert.ToDateTime(celda.valor);
                                cell.Formatting = XlNumberFormat.ShortDate;
                                break;
                        }

                        if (celda.formato != null)
                            cell.ApplyFormatting(celda.formato);

                        if (celda.formula != null)
                            cell.SetFormula(celda.formula);

                        if (listaPosiciones != null && celda.incluyeFormula)
                            listaPosiciones.Add(new PosicionFormula { columna = cell.ColumnIndex,
                                posicion = XlCellRange.FromLTRB(cell.ColumnIndex, row.RowIndex, cell.ColumnIndex, row.RowIndex) });
                    }
                }
            }
        }

        public static XlCellFormatting formatoTotal()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Font.Size = 11;
            formatoTotal.NumberFormat = XlNumberFormat.NumberWithThousandSeparator2;

            formatoTotal.Alignment = new XlCellAlignment();
            formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }

        public static XlCellFormatting NegritaNormal()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Font.Size = 11;

            formatoTotal.NumberFormat = XlNumberFormat.NumberWithThousandSeparator2;

            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }
        public static XlCellFormatting NormalConBorde()
        {
            XlCellFormatting formatting = new XlCellFormatting();

            formatting.Border = new XlBorder();
            formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
            formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

            return formatting;
        }

        public static XlCellFormatting SoloNegritaColor()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Font.Size = 11;

            formatoTotal.Fill = XlFill.SolidFill(Color.AliceBlue);
            //formatoTotal.NumberFormat = XlNumberFormat.NumberWithThousandSeparator2;

            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }

        public static XlCellFormatting SoloRojoColor()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromArgb(220, 0, 30);
            formatoTotal.Font.Size = 11;

            formatoTotal.Fill = XlFill.SolidFill(Color.AliceBlue);
            //formatoTotal.NumberFormat = XlNumberFormat.NumberWithThousandSeparator2;

            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }

        public static XlCellFormatting SoloAzulColor()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromArgb(29, 60, 149);
            formatoTotal.Font.Size = 12;

            formatoTotal.Fill = XlFill.SolidFill(Color.AliceBlue);
            //formatoTotal.NumberFormat = XlNumberFormat.NumberWithThousandSeparator2;

            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }
        public static XlCellFormatting SoloAzulColorConBorde()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromArgb(29, 60, 149);
            formatoTotal.Font.Size = 12;

            formatoTotal.Fill = XlFill.SolidFill(Color.AliceBlue);

            formatoTotal.Border = new XlBorder();
            formatoTotal.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Border.TopLineStyle = XlBorderLineStyle.Thin;
            formatoTotal.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatoTotal.Border.BottomLineStyle = XlBorderLineStyle.Thin;
            formatoTotal.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatoTotal.Border.LeftLineStyle = XlBorderLineStyle.Thin;
            formatoTotal.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
            formatoTotal.Border.RightLineStyle = XlBorderLineStyle.Thin;

            return formatoTotal;
        }

        public static XlCellFormatting SoloVerdeColor()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromArgb(50, 113, 7);
            formatoTotal.Font.Size = 12;

            formatoTotal.Fill = XlFill.SolidFill(Color.AliceBlue);
            //formatoTotal.NumberFormat = XlNumberFormat.NumberWithThousandSeparator2;

            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }

        public static XlCellFormatting NegritaNormalNumero()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Font.Size = 11;

            //formatoTotal.NumberFormat = NumberWithThousandSeparator 
            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }

        public static XlCellFormatting NegritaNormalNumeroConRaya()
        {
            XlCellFormatting formatoTotal = new XlCellFormatting();
            formatoTotal.Font = new XlFont();
            formatoTotal.Font.Name = "Calibri";
            formatoTotal.Font.Bold = true;

            formatoTotal.Border = new XlBorder();
            formatoTotal.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Border.TopLineStyle = XlBorderLineStyle.Thin;

            formatoTotal.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatoTotal.Font.Size = 11;

            //formatoTotal.NumberFormat = NumberWithThousandSeparator 
            //formatoTotal.Alignment = new XlCellAlignment();
            //formatoTotal.Alignment.HorizontalAlignment = XlHorizontalAlignment.Right;

            return formatoTotal;
        }
        public static XlCellFormatting formatoPersonalizado(bool esNegrita, int sizeFuente, bool conBorde)
        {
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Name = "Calibri";
            formatting.Font.Bold = esNegrita;

            formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
            formatting.Font.Size = sizeFuente;
            if (conBorde)
            {
                formatting.Border = new XlBorder();
                formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;
            }
            return formatting;
        }

        public void GenerarFilaEnBlanco(IXlSheet sheet, int cantCeldas)
        {
            // Specify formatting settings for the document title.
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Name = "Calibri";
            formatting.Font.SchemeStyle = XlFontSchemeStyles.None;

            // Create the data row to display the employee's information.
            using (IXlRow row = sheet.CreateRow())
            {
                row.HeightInPixels = 20;
                row.BlankCells(cantCeldas, formatting);
            }
        }

        public void ParametroConfiguracionHoja(IXlSheet sheet, string titulo)
        {
            // Specify the header and footer for the odd-numbered pages.
            sheet.HeaderFooter.OddHeader = XlHeaderFooter.FromLCR("Proyecto CORAH.", null, XlHeaderFooter.Date);
            sheet.HeaderFooter.OddFooter = XlHeaderFooter.FromLCR(titulo, null, XlHeaderFooter.PageNumber + " de " + XlHeaderFooter.PageTotal);

            // Specify page margins.
            sheet.PageMargins = new XlPageMargins();
            sheet.PageMargins.PageUnits = XlPageUnits.Centimeters;
            sheet.PageMargins.Left = 2.0;
            sheet.PageMargins.Right = 1.0;
            sheet.PageMargins.Top = 1.4;
            sheet.PageMargins.Bottom = 1.4;
            sheet.PageMargins.Header = 0.7;
            sheet.PageMargins.Footer = 0.7;

            // Specify page settings.
            sheet.PageSetup = new XlPageSetup();
            // Select the paper size.
            sheet.PageSetup.PaperKind = PaperKind.A4;
            // Set the page orientation to Landscape.
            sheet.PageSetup.PageOrientation = XlPageOrientation.Landscape;
            // Scale the print area to fit to one page wide.
            sheet.PageSetup.FitToPage = true;
            sheet.PageSetup.FitToWidth = 1;
            sheet.PageSetup.FitToHeight = 0;
            //
            sheet.PageSetup.Scale = 75;
            
        }

        public static IXlFormulaParameter SumarPorCoordenadasHaciaAbajo(int columnaInicial, int filaInicial, int NroFilas)
        {
            //XlFunc.Sum()
            return XlFunc.Sum(XlCellRange.FromLTRB(columnaInicial, filaInicial, columnaInicial, filaInicial + NroFilas - 1));
        }

        public static IXlFormulaParameter SumarPorCoordenadasHaciaDerecha(int columnaInicial, int filaInicial, int NroColumnas)
        {
            //XlFunc.Sum()
            return XlFunc.Sum(XlCellRange.FromLTRB(columnaInicial, filaInicial, columnaInicial + NroColumnas - 1, filaInicial));
        }

        public static IXlFormulaParameter SumarPorCoordenadasHaciaAbajo(int columnaInicial, List<int> posicionesfilas, int incremento)
        {
            //XlFunc.Sum()
            List<IXlFormulaParameter> rangos = new List<IXlFormulaParameter>();
            foreach(int i in posicionesfilas)
            {
                rangos.Add(XlCellRange.FromLTRB(columnaInicial, i + incremento, columnaInicial, i + incremento));
            }

            return XlFunc.Sum(rangos.ToArray()); // XlFunc.Subtotal(rangos, XlSummary.Sum, false);
        }

        public static IXlFormulaParameter SumarPorCoordenadasHaciaDerecha(int filaInicial, List<int> posicionesColumnas, int incremento)
        {
            //XlFunc.Sum()
            List<IXlFormulaParameter> rangos = new List<IXlFormulaParameter>();
            foreach (int i in posicionesColumnas)
            {
                rangos.Add(XlCellRange.FromLTRB(i + incremento, filaInicial, i + incremento, filaInicial));
            }

            return XlFunc.Sum(rangos.ToArray()); // XlFunc.Subtotal(rangos, XlSummary.Sum, false);
        }
        public void GenerarCabeceraFilasCombinarHorizontalSegunMesReajuete(IXlSheet hoja, IEnumerable<string> nombreColumnas, int vpos_top_button, int mesReajuste)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                foreach (string columnName in nombreColumnas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);

                        formatting.Border = new XlBorder();
                        formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                        formatting.Alignment = new XlCellAlignment();
                        formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                        formatting.Alignment.VerticalAlignment = XlVerticalAlignment.Center;
                        formatting.Alignment.WrapText = true;

                        cell.Value = columnName;
                        cell.ApplyFormatting(formatting);
                    }
                }
            }
            int posCol = 0;
            foreach (string columnName in nombreColumnas)
            {
                if (string.IsNullOrEmpty(columnName) && posCol > 0)
                    hoja.MergedCells.Add(XlCellRange.FromLTRB(posCol - 1, vpos_top_button, posCol, vpos_top_button));
                posCol++;
            }


        }
        public void GenerarCabeceraFilasCombinarVerticalSegunMesReajuete(IXlSheet hoja, IEnumerable<string> nombreColumnas, int vpos_top_button, int mesReajuste)
        {
            using (IXlRow row = hoja.CreateRow())
            {
                foreach (string columnName in nombreColumnas)
                {
                    using (IXlCell cell = row.CreateCell())
                    {
                        XlCellFormatting formatting = new XlCellFormatting();

                        formatting.Font = new XlFont();
                        formatting.Font.Name = "Calibri";
                        formatting.Font.Bold = true;
                        formatting.Font.Color = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);

                        formatting.Border = new XlBorder();
                        formatting.Border.TopColor = XlColor.FromTheme(XlThemeColor.Dark1, 0.0);
                        formatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.BottomColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.LeftColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.LeftLineStyle = XlBorderLineStyle.Thin;
                        formatting.Border.RightColor = Color.FromArgb(0x00, 0x00, 0x00);
                        formatting.Border.RightLineStyle = XlBorderLineStyle.Thin;

                        formatting.Alignment = new XlCellAlignment();
                        formatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                        formatting.Alignment.VerticalAlignment = XlVerticalAlignment.Center;
                        formatting.Alignment.WrapText = true;


                        cell.Value = columnName;
                        cell.ApplyFormatting(formatting);
                    }
                }
            }
            int posCol = 0;
            foreach (string columnName in nombreColumnas)
            {
                if (string.IsNullOrEmpty(columnName))
                    hoja.MergedCells.Add(XlCellRange.FromLTRB(posCol, vpos_top_button - 1, posCol, vpos_top_button));
                posCol++;
            }

        }
        public static string MultiplicarPorCoordenadasHaciaDerechaString(int columnaInicial, int filaInicial, int NroColumnas)
        {
            string numLeft = XlCellRange.FromLTRB(columnaInicial, filaInicial, columnaInicial, filaInicial).ToString();
            string numRight = XlCellRange.FromLTRB(NroColumnas, filaInicial, NroColumnas, filaInicial).ToString();

            return "ROUND(" + numLeft + "*" + numRight + ",2)";
        }
        public static IXlFormulaParameter SumarPorCoordenadasHaciaDerecha(int filaInicial, List<int> posicionesColumnas)
        {
            List<IXlFormulaParameter> rangos = new List<IXlFormulaParameter>();
            foreach (int i in posicionesColumnas)
            {
                rangos.Add(XlCellRange.FromLTRB(i, filaInicial, i, filaInicial));
            }

            return XlFunc.Sum(rangos.ToArray()); // XlFunc.Subtotal(rangos, XlSummary.Sum, false);
        }
    }

    public enum TipoDatoExportar
    {
        Vacio = 0,
        Cadena = 1,
        Entero = 2,
        Decimal = 3,
        Fecha = 4
    }

    public class CeldaExportar
    {
        public object valor { get; set; }
        public TipoDatoExportar tipoDato { get; set; }
        public XlCellFormatting formato { get; set; }
        public IXlFormulaParameter formula { get; set; }
        public string formulaString { get; set; }
        public  bool incluyeFormula { get; set; }
        //public int tamanioAlto { get; set; }
    }

    public class PosicionFormula
    {
        public int columna { get; set; }
        public XlCellRange posicion { get; set; }
    }

    public class FilaSuma
    {
        public int fila { get; set; }

        public int id { get; set; }
    }

    public class ColumnaExportar
    {
        public string nombre { get; set; }
        public int tamanioAncho { get; set; }
        public XlCellFormatting formato { get; set; }
        public int NroCeldasCombinarHaciaArriba { get; set; }
        public int NroCeldasCombinarHaciaAbajo { get; set; }
        public int NroCeldasCombinarHaciaDerecha { get; set; }
        public int NroCeldasCombinarHaciaIzquierda { get; set; }
    }
}
