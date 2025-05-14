using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Seguridad.Modelo;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class OpcionHelper
    {
        private FormBase padre = null;
        private ControlBase controlActual;
        private List<Opcion> listaOpciones;
        //private List<Opcion> ListaOpcionMod = null;
        private List<BarButtonItem> listaBotonesRibbon;
        //private bool bloquearCambiarPagina = false;
        private RibbonPageCategory categoriaDetalle;

        public RibbonControl Ribbon
        {
            get
            {
                if (padre == null) return null;
                return padre.RibbonControl;
            }
        }

        public RibbonControl RibbonPrincipal
        {
            get
            {
                if (padre == null) return null;
                return padre.RibbonControlPrincipal;
            }
        }

        //public RibbonControl RibbonPrincipal
        //{
        //    get
        //    {
        //        if (padre == null) return null;
        //        return padre.RibbonOpcionesPrincipal;
        //    }
        //}

        private BarButtonItem botonEditar;
        public BarButtonItem BotonEditar
        {
            get
            {
                if (botonEditar == null) return null;
                return botonEditar;
            }
        }
        public ControlBase ControlActual
        {
            get { return controlActual; }
            set
            {
                if (controlActual == value) return;
                controlActual = value;
                //if (controlActual != null)
                    //InicializarMenuRibbon();
            }
        }

        public OpcionHelper(FormBase padre)
        {
            this.padre = padre;

            CrearBotones(this.padre.MenuModulo.MenuSistema);
            CrearCategoriaDetalle();
            CargarOpciones(this.padre.MenuModulo.MenuSistema);
        }

        //private void InicializarMenuRibbon()
        //{
        //    ActualizarMenu();
        //}
        //private void ActualizarMenu()
        //{
        //    bloquearCambiandoPagina = true;
        //    foreach (RibbonPage pagina in Ribbon.TotalPageCategory.Pages)
        //    {
        //        if (pagina.Tag == null) continue;
        //        pagina.Visible = ControlActual.EsPaginaAdecuada(pagina);
        //        if (pagina.Visible && pagina.Tag.Equals(ControlActual))
        //        {
        //            padre.RibbonControl.SelectedPage = pagina;
        //        }
        //    }
        //    bloquearCambiandoPagina = false;
        //}

        #region Creacion de opciones por el menu asignado

        private void CargarOpciones(Menu menu)
        {
            CargarOpciones(menu, this.Ribbon);
            //CargarOpciones(menu, this.RibbonPrincipal);
        }

        private void CargarOpciones(Menu menu, RibbonControl Ribbon)
        {
            //Principal
            if (listaOpciones == null) return;

            RibbonPage ribbonPagina = new RibbonPage();
            ribbonPagina.Text = menu.titulo;
            ribbonPagina.Name = "rp" + menu.nomMenu;
            ribbonPagina.Tag = menu.control;

            //Detalle
            RibbonPage ribbonPaginaDet = null;
            if (menu.MenuOpcion.Any(a => a.Opcion.esParaDetalle))
            {
                ribbonPaginaDet = new RibbonPage();
                ribbonPaginaDet.Text = menu.titulo;
                ribbonPaginaDet.Name = "rp" + menu.nomMenu + "s";
                ribbonPaginaDet.Tag = ".";
            }

            IEnumerable<Opcion> grupos = listaOpciones
                .Where(s => s.tipo.Equals("G") && ((menu.MenuOpcion.Any(a => a.Opcion.esParaDetalle) && s.esParaDetalle) || (!s.esParaDetalle)))
                .OrderBy(o => o.posicion);

            //bool soloLectura = false;
            foreach (Opcion grupo in grupos)
            {
                RibbonPageGroup ribbonGrupo = new RibbonPageGroup(grupo.titulo);
                ribbonGrupo.Name = "rpg" + grupo.nomOpcion + menu.nomMenu;
                ribbonGrupo.Text = grupo.titulo;

                var botones = listaOpciones
                    .Where(s => s.idDependencia == grupo.idOpcion && s.tipo.Equals("O"))
                    .OrderBy(o => o.posicion);

                foreach (Opcion boton in botones)
                {
                    foreach (var Item in Ribbon.Items)
                    {
                        BarButtonItem ItemBoton = Item as BarButtonItem;
                        if (ItemBoton != null)
                        {
                            if (ItemBoton.Name.ToUpper().Equals("BBI" + boton.nomOpcion.ToUpper()))
                            {
                                ItemBoton.Tag = boton;
                                ribbonGrupo.ItemLinks.Add(ItemBoton);
                                break;
                            }
                        }
                    }
                }

                if (!grupo.esParaDetalle) ribbonPagina.Groups.Add(ribbonGrupo);
                else
                    if (ribbonPaginaDet != null)
                {
                    ribbonPaginaDet.Groups.Add(ribbonGrupo);
                }
            }
            //SegundoCambio = true;
            Ribbon.Pages.Add(ribbonPagina);
            if (ribbonPaginaDet != null) categoriaDetalle.Pages.Add(ribbonPaginaDet);
        }

        private void CrearCategoriaDetalle()
        {
            CrearCategoriaDetalle(this.Ribbon);
            //CrearCategoriaDetalle(this.RibbonPrincipal);
        }

        private void CrearCategoriaDetalle(RibbonControl Ribbon)
        {
            categoriaDetalle = new RibbonPageCategory();
            categoriaDetalle.Text = "Detalle";
            categoriaDetalle.Name = "rpcDetalle";
            categoriaDetalle.Color = System.Drawing.Color.Empty;
            Ribbon.PageCategories.Add(categoriaDetalle);
        }

        private void CrearBotones(Menu menu)
        {
            CrearBotones(menu, this.Ribbon);
            //CrearBotones(menu, this.RibbonPrincipal);
        }

        private void CrearBotones(Menu menu, RibbonControl Ribbon)
        {
            //Creacion de Botones de Exportacion
            if (menu.MenuOpcion.Count > 0)
                listaOpciones = menu.MenuOpcion.Where(w => w.estado).Select(s => s.Opcion).ToList();
            
            if (listaOpciones == null) return;

            BotonesExportacion();
            listaBotonesRibbon = new List<BarButtonItem>();
            var botones = listaOpciones.Where(s => s.tipo == "O").Distinct();

            foreach (Opcion boton in botones)
            {
                BarButtonItem nuevoBoton = new BarButtonItem();
                nuevoBoton.Name = "bbi" + boton.nomOpcion;
                nuevoBoton.Caption = boton.titulo;
                if (!boton.nomOpcion.ToUpper().Equals("EXPORTAR"))
                    nuevoBoton.ButtonStyle = BarButtonStyle.Default;
                else
                {
                    nuevoBoton.ButtonStyle = BarButtonStyle.DropDown;
                    nuevoBoton.DropDownControl = padre.PmExportacion;
                }
                nuevoBoton.Tag = boton;
                nuevoBoton.LargeGlyph = UtilitarioComun.byteA_Imagen(boton.iconoGrande);
                nuevoBoton.Glyph = UtilitarioComun.byteA_Imagen(boton.iconoPequenio);
                AsignarEvento(nuevoBoton);
                Ribbon.Items.Add(nuevoBoton);
            }
        }

        private void AsignarEvento(BarButtonItem nuevoBoton)
        {
            switch (nuevoBoton.Name.ToUpper())
            {
                case "BBINUEVO":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarNuevo(); });
                    break;
                case "BBINUEVOMULTIPLE":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarNuevoMultiple(); });
                    break;
                case "BBIMODIFICAR":
                    this.botonEditar = nuevoBoton; // Para ser utlizado en los eventos con el grid principal de cada menu
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarModificacion(); });
                    break;
                case "BBIELIMINAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarEliminacion(); });
                    break;
                case "BBIANULAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarAnulacion(); });
                    break;
                case "BBIGUARDAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.GuardarDetalle(); });
                    break;
                case "BBIGUARDARCERRAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.GuardarYCerrarDetalle(); });
                    break;
                case "BBICERRAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.CerrarDetalle(); });
                    break;
                case "BBIACTUALIZAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.Actualizar(); });
                    break;
                case "BBIREFRESCAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.Actualizar(); });
                    break;
                case "BBIEXPORTAR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.Exportar(); });
                    break;
                case "BBIIMPRIMIR":
                    nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.Imprimir(); });
                    break;

                case "BBIREFRESCARDET":
                    if (((Opcion)nuevoBoton.Tag).esParaDetalle)
                        nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RefrescarDetalle(); });
                    break;

                case "BBINUEVODET":
                    if (((Opcion)nuevoBoton.Tag).esParaDetalle)
                        nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.NuevoDet(); });
                    break;

                case "BBIMODIFICARDET":
                    if (((Opcion)nuevoBoton.Tag).esParaDetalle)
                        nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.ModificacionDet(); });
                    break;

                case "BBIANULARDET":
                    if (((Opcion)nuevoBoton.Tag).esParaDetalle)
                        nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.AnularDet(); });
                    break;

                default:
                    if (nuevoBoton.Tag != null)
                    {
                        if (((Opcion)nuevoBoton.Tag).esParaDetalle)
                            nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarOtrasOperacionesDet(((Opcion)nuevoBoton.Tag).nomOpcion); /*ControlActual.GuardarDetalle();*/ });
                        else
                            nuevoBoton.ItemClick += new ItemClickEventHandler(delegate { ControlActual.Boton = nuevoBoton; ControlActual.RealizarOtrasOperaciones(((Opcion)nuevoBoton.Tag).nomOpcion); });
                    }
                    break;
            }
        }

        private void BotonesExportacion()
        {
            BotonesExportacion(this.Ribbon, this.padre.PmExportacion);
            //BotonesExportacion(this.RibbonPrincipal, this.padre.PmExportacionPrinciipal);
        }

        private void BotonesExportacion(RibbonControl Ribbon, PopupMenu PmExportacion)
        {
            //PDF
            BarButtonItem bbiExportaPDF = new BarButtonItem
            {
                Name = "bbiExportaPDF",
                Caption = Mensajes.BotonExportaPDF,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToPDF", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToPDF", TamanioImagen.Pequenio16),
            };

            bbiExportaPDF.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarPDF(); });
            Ribbon.Items.Add(bbiExportaPDF);

            //XLS
            BarButtonItem bbiExportaXLS = new BarButtonItem
            {
                Name = "bbiExportaXLS",
                Caption = Mensajes.BotonExportaXLS,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToExcel", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToExcel", TamanioImagen.Pequenio16),
            };

            bbiExportaXLS.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarXLS(); });
            Ribbon.Items.Add(bbiExportaXLS);

            //XLSX
            BarButtonItem bbiExportaXLSX = new BarButtonItem
            {
                Name = "bbiExportaXLSX",
                Caption = Mensajes.BotonExportaXLSX,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToExcel", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToExcel", TamanioImagen.Pequenio16),
            };

            bbiExportaXLSX.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarXLSX(); });
            Ribbon.Items.Add(bbiExportaXLSX);

            //RTF
            BarButtonItem bbiExportaRTF = new BarButtonItem
            {
                Name = "bbiExportaRTF",
                Caption = Mensajes.BotonExportaRTF,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToRTF", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToRTF", TamanioImagen.Pequenio16),
            };

            bbiExportaRTF.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarRTF(); });
            Ribbon.Items.Add(bbiExportaRTF);

            //HTML
            BarButtonItem bbiExportaHTML = new BarButtonItem
            {
                Name = "bbiExportaHTML",
                Caption = Mensajes.BotonExportaHTML,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToHTML", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToHTML", TamanioImagen.Pequenio16),
            };

            bbiExportaHTML.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarHTML(); });
            Ribbon.Items.Add(bbiExportaHTML);

            //MHT
            BarButtonItem bbiExportaMHT = new BarButtonItem
            {
                Name = "bbiExportaMHT",
                Caption = Mensajes.BotonExportaMHT,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToMHT", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToMHT", TamanioImagen.Pequenio16),
            };

            bbiExportaMHT.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarMHT(); });
            Ribbon.Items.Add(bbiExportaMHT);

            //TEXTO
            BarButtonItem bbiExportaTXT = new BarButtonItem
            {
                Name = "bbiExportaTXT",
                Caption = Mensajes.BotonExportaTXT,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToTXT", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToTXT", TamanioImagen.Pequenio16),
            };

            bbiExportaTXT.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarTexto(); });
            Ribbon.Items.Add(bbiExportaTXT);

            //XML
            BarButtonItem bbiExportaXML = new BarButtonItem
            {
                Name = "bbiExportaXML",
                Caption = Mensajes.BotonExportaXML,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToXML", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToXML", TamanioImagen.Pequenio16),
            };

            bbiExportaXML.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarXML(); });
            Ribbon.Items.Add(bbiExportaXML);

            //IMAGEN
            BarButtonItem bbiExportaImagen = new BarButtonItem
            {
                Name = "bbiExportaImagen",
                Caption = Mensajes.BotonExportaImagen,
                ButtonStyle = BarButtonStyle.Default,
                LargeGlyph = ImagenHelper.TraerImagen("ExportToIMG", TamanioImagen.Grande32),
                Glyph = ImagenHelper.TraerImagen("ExportToIMG", TamanioImagen.Pequenio16),
            };

            bbiExportaImagen.ItemClick += new ItemClickEventHandler(delegate { ControlActual.ExportarImagen(); });
            Ribbon.Items.Add(bbiExportaImagen);


            //Inicializa Popup Exportacion
            PmExportacion.BeginInit();

            PmExportacion.ItemLinks.AddRange(new BarButtonItem[]
            {
                bbiExportaPDF, bbiExportaXLS, bbiExportaXLSX, bbiExportaRTF,
                bbiExportaHTML, bbiExportaMHT, bbiExportaTXT, bbiExportaXML,
                bbiExportaImagen
            });

            PmExportacion.EndInit();

        }

        #endregion

        #region Puesta en marcha opciones detalle

        //Genera el Ribbon del detalle
        internal void CrearDetalleRibbon()
        {
            CrearDetalleRibbon(this.Ribbon);
            //CrearDetalleRibbon(this.RibbonPrincipal);
        }

        internal void CrearDetalleRibbon(RibbonControl Ribbon)
        {
            foreach (RibbonPage pagina in Ribbon.TotalPageCategory.Pages)
            {
                if (pagina.Tag == null ||
                    ControlActual.DetalleControlActivo == null ||
                    ControlActual.DetalleControlActivo.PaginaRibbonActivo != null) continue;

                if (pagina.Tag.GetType().Equals(typeof(string)))
                {
                    pagina.Tag = ((Opcion)ControlActual.Boton.Tag).control;
                }

                if (pagina.Tag.Equals(ControlActual.NombreDetalleTipo))
                    ControlActual.DetalleControlActivo.CrearPaginaRibbonActivo(pagina);
            }
        }

        private bool bloquearCambiandoPagina = false;

        internal void ActualizarMenu()
        {
            ActualizarMenu(this.Ribbon);
            //ActualizarMenu(this.RibbonPrincipal);
        }

        internal void ActualizarMenu(RibbonControl Ribbon)
        {
            bloquearCambiandoPagina = true;
            foreach (RibbonPage pagina in Ribbon.TotalPageCategory.Pages)
            {
                if (pagina.Tag == null) continue;
                pagina.Visible = ControlActual.EsPaginaAdecuada(pagina);
                if (pagina.Visible && pagina.Tag.Equals(ControlActual))
                {
                    //padre.RibbonControl.SelectedPage = pagina;
                    Ribbon.SelectedPage = pagina;
                }
            }
            bloquearCambiandoPagina = false;
        }

        #endregion

        #region Puesta en marcha de opciones principales

        internal void AgregarPaginaPorControl(ControlBase controlPrincipalControl)
        {
            AgregarPaginaPorControl(controlPrincipalControl, this.Ribbon);
            //AgregarPaginaPorControl(controlPrincipalControl, this.RibbonPrincipal);
        }

        internal void AgregarPaginaPorControl(ControlBase controlPrincipalControl, RibbonControl Ribbon)
        {
            foreach (RibbonPage pagina in Ribbon.TotalPageCategory.Pages)
            {
                if (pagina.Tag == null) continue;
                if (pagina.Tag.Equals(controlPrincipalControl.NombreTipo))
                {
                    controlPrincipalControl.PaginaActivaRibbon = pagina;
                    pagina.Tag = controlPrincipalControl;
                    break;
                }
            }
        }

        #endregion

        #region Eventos y Acciones de Ribbon de opcion

        public void AsignarEventoMenuRibbonPadre()
        {
            AsignarEventoMenuRibbonPadre(false, this.Ribbon);
            //AsignarEventoMenuRibbonPadre(esFormularioPrincipal, this.RibbonPrincipal);
        }

        public void AsignarEventoMenuRibbonPadre(bool esFormularioPrincipal)
        {
            AsignarEventoMenuRibbonPadre(esFormularioPrincipal, this.Ribbon);
            //AsignarEventoMenuRibbonPadre(esFormularioPrincipal, this.RibbonPrincipal);
        }
        public void AsignarEventoMenuRibbonPadre(bool esFormularioPrincipal, RibbonControl Ribbon)
        {
            if (esFormularioPrincipal)
            {
                Ribbon.SelectedPageChanging -= new RibbonPageChangingEventHandler(RibbonControl_SelectedPageChanging);
            }
            else
            {
                Ribbon.SelectedPageChanging += new RibbonPageChangingEventHandler(RibbonControl_SelectedPageChanging);
            }
        }
        private void RibbonControl_SelectedPageChanging(object sender, RibbonPageChangingEventArgs e)
        {
            EjecutarAccionEvento(e.Page);
        }

        public bool SegundoCambio { get; set; }
        public void EjecutarAccionEvento(RibbonPage pagina)
        {
            if (pagina == null || SegundoCambio) return;
            if (bloquearCambiandoPagina) return;
            System.Windows.Forms.Control control = pagina.Tag as System.Windows.Forms.Control;
            EstablecerControl(control);
        }

        private System.Windows.Forms.Control controlActivo = null;
        public void EstablecerControl(System.Windows.Forms.Control control)
        {
            if (control == null) return;
            if (!control.Visible) control.Show();
            control.BringToFront();
            if (!Object.Equals(control, controlActivo))
                VentanaHelper.CerrarPersonalizacionFormulario(ControlActual);
            controlActivo = control;

            bloquearCambiandoPagina = true;
            try
            {
                ControlBase tControl = control as ControlBase;
                if (tControl != null) tControl.DetalleControlActivo = null;
                ControlDetalleBase dControl = control as ControlDetalleBase;
                if (dControl != null) ControlActual.DetalleControlActivo = dControl;
            }
            finally
            {
                bloquearCambiandoPagina = false;
                SegundoCambio = false;
            }
        }

        //public void CargarOpcionPrincipal()
        //{
        //    foreach (RibbonPageCategory cat in Ribbon.PageCategories)
        //    {
        //        RibbonPageCategory nuevo = cat.Clone() as RibbonPageCategory;
        //        RibbonPrincipal.PageCategories.Add(nuevo);
        //    }
        //}

        #endregion
    }
}
