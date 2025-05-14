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
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmActualizacionReajustePorRRHH : frmDialogoBase, IActualizacionReajustePorRRHHVista
    {
        private ActualizacionReajustePorRRHHPresentador actualizacionPorRRHHPresentador;

        public List<Area> listaAreasSeleccionadas { get { return ObtenerMarcados(); } }

        public bool IndicaElimina { get { return ceElimina.Checked; } set { ceElimina.Checked = value; } }

        public bool IndicaSoloReajuste { get { return ceSoloReajuste.Checked; } set { ceSoloReajuste.Checked = value; } }

        public frmActualizacionReajustePorRRHH(int idReaMenPro, int idProAnu, Form padre):
            base(padre, false)
        {
            InitializeComponent();
            this.actualizacionPorRRHHPresentador = new ActualizacionReajustePorRRHHPresentador(idProAnu, idReaMenPro,  this);
            Text = "Actualizar Reajuste de Presupuesto por el cálculo de RRHH";
        }

        protected override void InicializarValidacion()
        {

        }

        protected override void InicializarDatos()
        {
            actualizacionPorRRHHPresentador.Inicializar();
            CrearArbol();
        }

        protected override void GuardarDatos()
        {
            bool continuar = true;
            if (ceElimina.Checked && !EmitirMensajePregunta("¿Está seguro de eliminar todos los detalles?"))
                continuar = false;

            if (continuar)
            {
                if (actualizacionPorRRHHPresentador.Guardar())
                //if (evaluacionMensualGeneralPresentador.GuardarDatos(ObtenerMarcados()))
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);

            }
        }

        private List<Area> ObtenerMarcados()
        {
            Area are;
            List<Area> lista = new List<Area>();
            foreach (System.Windows.Forms.TreeNode nodo in trvAreas.Nodes)
            {
                foreach (System.Windows.Forms.TreeNode nodo1 in nodo.Nodes)
                {
                    foreach (System.Windows.Forms.TreeNode nodo2 in nodo1.Nodes)
                    {
                        if (nodo2.Checked)
                        {
                            are = (Area)nodo2.Tag;
                            if (are != null)
                            {
                                lista.Add(are);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private void CrearArbol()
        {
            List<Direccion> ListaDireccion = actualizacionPorRRHHPresentador.listaDirecciones();
            List<Subdireccion> ListaSubdirecion = actualizacionPorRRHHPresentador.listaSubdirecciones();
            List<Area> ListaAreas = actualizacionPorRRHHPresentador.listaAreas();
            List<int> IDsAreas = actualizacionPorRRHHPresentador.listaIDsAreas();

            System.Windows.Forms.TreeNode dir = null;
            System.Windows.Forms.TreeNode sub = null;
            System.Windows.Forms.TreeNode are = null;

            trvAreas.Nodes.Clear();

            foreach (Direccion grup in ListaDireccion)
            {
                dir = new System.Windows.Forms.TreeNode();

                var hijos = ListaSubdirecion.Where(w => w.idDireccion == grup.idDireccion);
                //
                foreach (Subdireccion pres in hijos)
                {
                    sub = new System.Windows.Forms.TreeNode();

                    var hijos2 = ListaAreas.Where(w => w.idSubDireccion == pres.idSubdireccion);

                    foreach (Area area in hijos2)
                    {
                        are = new System.Windows.Forms.TreeNode();
                        are.Text = area.desArea;
                        are.Tag = area;
                        if (IDsAreas.Contains(area.idArea))
                            dir.Checked = sub.Checked = are.Checked = true;
                        sub.Nodes.Add(are);
                    }

                    sub.Text = pres.desSubdireccion;
                    sub.Tag = pres;
                    dir.Nodes.Add(sub);
                }

                dir.Text = grup.desDireccion;
                dir.Tag = grup;

                trvAreas.Nodes.Add(dir);
            }
        }

        private void trvAreas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SeleccionarHijos(e.Node);
        }

        private void SeleccionarPadres(System.Windows.Forms.TreeNode nodoPrincipal)
        {
            if (nodoPrincipal == null) return;
            if (nodoPrincipal.Parent != null)
            {
                nodoPrincipal.Parent.Checked = true;
                SeleccionarPadres(nodoPrincipal.Parent);
            }
        }

        private void SeleccionarHijos(System.Windows.Forms.TreeNode nodoPrincipal)
        {
            foreach (System.Windows.Forms.TreeNode nodo in nodoPrincipal.Nodes)
            {
                nodo.Checked = nodoPrincipal.Checked;

                if (nodo.Nodes.Count > 0)
                {
                    SeleccionarHijos(nodo);
                }
            }
        }

        private void ceSoloReajuste_CheckedChanged(object sender, EventArgs e)
        {
            trvAreas.Enabled = !ceSoloReajuste.Checked;
        }
    }
}