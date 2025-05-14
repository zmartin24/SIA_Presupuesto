using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmFormula : frmDialogoBase, IFormulaVista
    {
        private FormulaPresentador formulaPresentador;
        public int PosicionCursor_enTxtValor { get; set; }
        public frmFormula(PropiedadPresupuestoRemuneracion propiedad)
        {
            InitializeComponent();
            Text = "Formula";
            this.formulaPresentador = new FormulaPresentador(propiedad, this);
        }

        public ColumnView ColumnaActualSeleccionada { get { return grcConcepto.MainView as ColumnView; } }

        private ConceptoPresupuestoRemuneracion ConceptoSelecionado
        {
            get
            {
                if (ColumnaActualSeleccionada == null || ColumnaActualSeleccionada.FocusedRowHandle < 0) return null;
                return (ColumnaActualSeleccionada.GetRow(ColumnaActualSeleccionada.FocusedRowHandle) as ConceptoPresupuestoRemuneracion);
            }
        }

        private List<ConceptoPresupuestoRemuneracion> listaConceptos;

        public List<ConceptoPresupuestoRemuneracion> listaDatosPrincipales
        {
            set
            {
                this.listaConceptos = value;
                grcConcepto.DataSource = value;
            }
        }

        public string valor
        {
            set { txtValor.Text = value; }
            get { return txtValor.Text; }
        }

        private void grvConcepto_DoubleClick(object sender, EventArgs e)
        {
            if (ConceptoSelecionado != null)
            {
                insertarEn_txtValor(ConceptoSelecionado.codigo);
                this.PosicionCursor_enTxtValor += ConceptoSelecionado.codigo.Length - 1;

                txtValor.Select(PosicionCursor_enTxtValor, 0);
                txtValor.Focus();
            }
        }

        private void insertarEn_txtValor(string valor)
        {
            int tamanioCadena = txtValor.Text.Length;
            string valorActual = txtValor.Text;

            if (PosicionCursor_enTxtValor < 0)
                PosicionCursor_enTxtValor = 0;

            if (tamanioCadena == this.PosicionCursor_enTxtValor)
                txtValor.Text += valor;
            else
                txtValor.Text = valorActual.Substring(0, PosicionCursor_enTxtValor) + valor + valorActual.Substring((PosicionCursor_enTxtValor), (tamanioCadena - PosicionCursor_enTxtValor));

            this.PosicionCursor_enTxtValor++;

            poneColor_Operadores_Simbolos();

            txtValor.Select(PosicionCursor_enTxtValor, 0);
            txtValor.Focus();
        }

        private void poneColor_Operadores_Simbolos()
        {
            bool esNumero = true;
            string actual = "";
            string parteConcepto = "";
            bool agregar = false;
            string valor = txtValor.Text + ")"; // delimitamos el final
            Font fnt = new Font("Verdana", 8F, FontStyle.Bold, GraphicsUnit.Point);
            Font fnt2 = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);

            for (int i = 0; i < valor.Length; i++)
            {
                actual = valor.Substring(i, 1);

                if (esOperadorMatemativo(actual))
                {
                    agregar = true;
                    txtValor.SelectionStart = i;
                    txtValor.SelectionLength = 1;
                    txtValor.SelectionColor = Color.DarkGreen;
                    txtValor.SelectionFont = fnt2;
                }
                else
                    parteConcepto += actual;

                if (agregar && !parteConcepto.Equals(""))
                {
                    txtValor.SelectionStart = (i - parteConcepto.Length);
                    txtValor.SelectionLength = parteConcepto.Length;
                    txtValor.SelectionFont = fnt;
                    if (!esOperador(parteConcepto))
                    {
                        try
                        {
                            Convert.ToDecimal(parteConcepto);
                            txtValor.SelectionFont = fnt2;
                            esNumero = true;
                        }
                        catch (System.FormatException)
                        {
                            esNumero = false;
                        }

                        txtValor.SelectionColor = Color.Black;

                        //if (!esNumero)
                        //{
                        //    if (PropiedadServicio.esParametro(parteConcepto, listaParametros))
                        //        txtValor.SelectionColor = Color.Maroon;
                        //    else
                        //    {
                        //        if (parteConcepto.Length != 5)
                        //            txtValor.SelectionColor = Color.Red;
                        //    }
                        //}
                    }
                    else
                    {
                        txtValor.SelectionColor = Color.DarkBlue;
                    }

                    parteConcepto = "";
                }
                agregar = false;
            }
        }

        public bool esOperadorMatemativo(string texto)
        {
            bool operador = false;

            if (texto.Equals("*") || texto.Equals("/") || texto.Equals("-") ||
                   texto.Equals("+") || texto.Equals("(") || texto.Equals(")") ||
                   texto.Equals("<") || texto.Equals(">") || texto.Equals("%") ||
                   texto.Equals("=") || texto.Equals(","))
            {
                operador = true;
            }

            return operador;
        }

        public bool esOperador(string parteConcepto)
        {
            bool operador = false;

            if ((parteConcepto.Equals("SI") || parteConcepto.Equals("NEGACION") || parteConcepto.Equals("VERDAD")
                            || parteConcepto.Equals("FALSO") || parteConcepto.Equals("Y") || parteConcepto.Equals("O")
                            || parteConcepto.Equals("RDON") || parteConcepto.Equals("RESTO")))
            {
                operador = true;
            }

            return operador;
        }

        private void txtValor_MouseUp(object sender, MouseEventArgs e)
        {
            string Descripcion = "";
            try
            {
                Descripcion = listaConceptos.Where(x => x.codigo.Equals(txtValor.SelectedText)).First().descripcion;
            }
            catch (Exception ex) { }

            if (Descripcion.Length > 0)
                lbDescripcion.Text = txtValor.SelectedText + " = " + Descripcion;
            else
            {
                //try
                //{
                //    Descripcion = listaParametros.Where(x => x.idTipoParametro.Equals(txtValor.SelectedText)).First().nomTipoParametro;
                //}
                //catch (Exception ex) { }

                //if (Descripcion.Length > 0)
                //    lbDescripcion.Text = "PARAMETRO DE PLANILLA - " + txtValor.SelectedText + " = " + Descripcion;
                //else
                //{
                //    lbDescripcion.Text = PropiedadServicio.ejemploOperador(txtValor.SelectedText);
                //}
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 37)
                this.PosicionCursor_enTxtValor = txtValor.SelectionStart - 1;
            else
            {
                if (e.KeyValue == 36)
                    this.PosicionCursor_enTxtValor = 0;
                else
                {
                    if (e.KeyValue == 35)
                        this.PosicionCursor_enTxtValor = txtValor.TextLength;
                    else
                    {
                        if (e.KeyValue == 39)
                            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 1;
                        else
                            this.PosicionCursor_enTxtValor = txtValor.SelectionStart;
                    }
                }
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 37) || (e.KeyChar >= 40 && e.KeyChar <= 57)
                || (e.KeyChar >= 60 && e.KeyChar <= 62))
            {
                e.Handled = false;
                this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 1;
            }
            else
            {
                if (e.KeyChar == 8)
                    this.PosicionCursor_enTxtValor = txtValor.SelectionStart;
                else
                    e.Handled = true;
            }
        }
        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtValor, ValidacionHelper.ReglaNoDebeSerVacio);
        }


        protected override void InicializarDatos()
        {
            formulaPresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (formulaPresentador.GuardarDatos())
            {

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        public string ejemploOperador(string operador)
        {
            string Ejemplo = "";

            switch (operador)
            {
                case "SI": Ejemplo = "SI( Expresión ,X,Y) Si Expresión cumple retorna X, caso contrario retorna Y (Ejem : SI (4>2,4,3) retorna 4)"; break;
                case "NEGACION": Ejemplo = "NEGACION(Expresión) => Expresión cumple retorna Falso ( Ejem : NEGACION (2<3) retorna Falso )"; break;
                case "VERDAD": Ejemplo = "A>B = VERDAD() => Expresión retorna Verdad ( Ejem: 4>2 = VERDAD() retorna Verdad)"; break;
                case "FALSO": Ejemplo = "A>B = FALSO() => Expresión retorna Falso ( Ejem : 4>7 = FALSO() retorna Falso"; break;
                case "Y": Ejemplo = "Y(Expresión1,Expresión2) Si las dos Expresiones cumplen retorna verdadero, caso contrario retorna falso ( Ejem Y(4=4,5<8) retorna Verdadero)"; break;
                case "O": Ejemplo = "O(Expresión1,Expresión2) Si una opción cumple retorna verdadero, caso contrario retorna falso ( Ejem Y(4=4,9<8) retorna Verdadero)"; break;
                case "RDON": Ejemplo = "RDON(A,B) Donde A : Número a redondear , B : Número de decimales ( Ejem: RDON(10.581,2) retorna 10.58)"; break;
                case "RESTO": Ejemplo = "RESTO(A,B) Donde A : Dividendo , B : Divisor ( Ejem: RESTO(9,2) retorna 1)"; break;
            }

            return Ejemplo;
        }

        private void sbSi_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("SI(,,)");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 2;
            lbDescripcion.Text = ejemploOperador("SI");
        }

        private void sbNegacion_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("NEGACION()");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 8;
            lbDescripcion.Text = ejemploOperador("NEGACION");
        }

        private void sbVerdadero_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("VERDAD");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart;
            lbDescripcion.Text = ejemploOperador("VERDAD");
        }

        private void sbFalso_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("FALSO");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart;
            lbDescripcion.Text = ejemploOperador("FALSO");
        }

        private void sbY_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("Y()");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 1;
            lbDescripcion.Text = ejemploOperador("Y");
        }

        private void sbO_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("O()");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 1;
            lbDescripcion.Text = ejemploOperador("O");
        }

        private void sbDivision_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("/");
        }

        private void sbMultiplicacion_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("*");
        }

        private void sbResta_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("-");
        }

        private void sbSuma_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("+");
        }

        private void sbPorcentaje_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("%");
        }

        private void sbIgual_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("=");
        }

        private void sbAbreParentesis_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("(");
        }

        private void sbCierraParentesis_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor(")");
        }

        private void sbMayor_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor(">");
        }

        private void sbMenor_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("<");
        }

        private void sbRedondear_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("RDON(,)");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 9;//-2
            lbDescripcion.Text = ejemploOperador("RDON");
        }

        private void sbResto_Click(object sender, EventArgs e)
        {
            insertarEn_txtValor("RESTO(,)");
            this.PosicionCursor_enTxtValor = txtValor.SelectionStart + 5; //-2
            lbDescripcion.Text = ejemploOperador("RESTO");
        }
    }
}