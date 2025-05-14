using DevExpress.Utils.Controls;
using Seguridad.Modelo;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.WinForm.General.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class MenuModulo
    {
        private Menu menuSistema;
        private Type tipoControl;
        private IContenedor _Contenedor;
        private Base.ControlBase controlUsuario;
        private frmDialogo frmBaseDialogo;
        public Menu MenuSistema
        {
            get { return menuSistema; }
        }
        
        public Base.ControlBase ControlUsuario
        {
            get { return controlUsuario; }
        }

        public Base.ControlBase TControl
        {
            get
            {
                if (this.controlUsuario == null)
                {

                    ConstructorInfo constructorInfoObj = tipoControl.GetConstructor(Type.EmptyTypes);
                    if (constructorInfoObj == null)
                        throw new ApplicationException(string.Format("", tipoControl.FullName));
                    this.controlUsuario = constructorInfoObj.Invoke(null) as Base.ControlBase;

                    //this.controlUsuario = _Contenedor.Resolver(tipoControl) as Base.ControlBase;
                }
                return this.controlUsuario;
            }
        }

        public frmDialogo TControlDialogo
        {
            get
            {
                if (this.frmBaseDialogo == null)
                {
                    this.frmBaseDialogo = _Contenedor.Resolver(tipoControl) as frmDialogo;
                }
                return this.frmBaseDialogo;
            }
        }

        public MenuModulo(Menu menuSistema, Type tipoControl)
        {
            _Contenedor = Fabrica.Instancia.ContenedorActual;
            this.menuSistema = menuSistema;
            this.tipoControl = tipoControl;
            //this.controlUsuario = controlUsuario;
        }
    }
}
