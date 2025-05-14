using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class CalculadoraPresupuestoRemeracion : ICalculadoraPresupuestoRemeracion
    {
        private string[] operadores = { "*", "/", "-", "+", "%", "(", ")", "<", ">", "=", ",", "SI", "NEGACION", "VERDAD", "FALSO", "RESTO", "Y", "O", "RDON" };
        private const string simboloFormula = "FR";
        private const string simboloFijo = "FI";
        private const int idMonedaDolares = 64;

        private List<PropiedadPoco> lista;
        private List<DatoCalculoPresupuestoRemuneracion> listaCalculo;
        private List<PuestoPoco> listaPuestos;
        private List<ParametroPresupuestoRemuneracion> listaParametro;

        private const int logitudCodConcepto = 5;
        private const int logitudCodParametro = 3;
        Dictionary<string, int> xListaCodigos = null;
        int ultFijo = 0;
        decimal xcomprueba = 0;
        //int sum = 0, valor = 0;
        private string mensaje;
        private bool error;
        private int mesDesde;
        private int mesHasta;
        private int mesReajuste;
        private int anio;
        private TipoCambioPresupuesto tipoCambioMensual;
        private TipoCambioAnual tipoCambioAnual;
        private int idTipMon;

        Dictionary<string, PropiedadPoco> ListaCodigos;
        
        public string Mensaje
        {
            get { return mensaje; }
        }

        public bool Error
        {
            get { return error; }
        }


        public CalculadoraPresupuestoRemeracion(List<PuestoPoco> listaPuestos, List<PropiedadPoco> lista, 
            List<DatoCalculoPresupuestoRemuneracion> listaCalculo, 
            List<ParametroPresupuestoRemuneracion> listaParametro, int mesDesde, int mesHasta, 
            TipoCambioPresupuesto tipoCambioMensual, TipoCambioAnual tipoCambioAnual, int idTipMon, int mesReajuste, int anio)
        {
            this.lista = lista;
            this.listaParametro = listaParametro;
            this.listaCalculo = listaCalculo;
            this.listaPuestos = listaPuestos;
            this.mesDesde = mesDesde;
            this.mesHasta = mesHasta;
            this.tipoCambioMensual = tipoCambioMensual;
            this.tipoCambioAnual = tipoCambioAnual;
            this.idTipMon = idTipMon;
            this.mesReajuste = mesReajuste;
            this.anio = anio;
        }


        private void EnListarCodigos()
        {
            ListaCodigos = new Dictionary<string, PropiedadPoco>();
            xListaCodigos = new Dictionary<string, int>();

            lista = lista.OrderBy(o => o.orden).ThenBy(t => t.concepto).ToList();
            int cont = 0;
            int cont2 = 0;
            foreach (var propiedad in lista)
            {
                propiedad.numero = ++cont;
                if (propiedad.seVisualiza) propiedad.numeroImp = ++cont2;

                if (!ListaCodigos.Keys.Contains(propiedad.codigo))
                    ListaCodigos.Add(propiedad.codigo, propiedad);

                //Agregado
                if (!xListaCodigos.Keys.Contains(propiedad.codigo))
                {
                    if (propiedad.codTipoValor.Equals(simboloFijo)
                        || propiedad.esAcumulativo)
                    {
                        xListaCodigos.Add(propiedad.codigo, ultFijo);
                        ++ultFijo;
                    }
                    else
                        xListaCodigos.Add(propiedad.codigo, 0);
                }
            }
        }

        private int ValorOrden(string codigo)
        {
            if (xListaCodigos.ContainsKey(codigo))
            {
                var x = xListaCodigos[codigo];
                if (x > 0)
                    return x;
                else
                    return AcumularValor(ListaCodigos[codigo]);
            }
            else
            {
                //Valida existencia de parametro
                //if (ListaCodigosParametro.ContainsKey(codigo))
                //    return 0;
                //else
                if (decimal.TryParse(codigo, out xcomprueba))
                    return 0;
            }
            return -1;
        }

        private int AcumularValor(PropiedadPoco xpropiedadBus)
        {
            int sum = ultFijo;
            int valor = 0;
            string[] dependencias = xpropiedadBus.valor.Split(operadores, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
            foreach (string parametro in dependencias)
            {
                valor = ValorOrden(parametro);
                if (valor != -1)
                    sum += valor;
                else
                    throw new InvalidOperationException(string.Format(Mensajes.MensajeParametroNoReconocido, parametro));
            }
            xListaCodigos[xpropiedadBus.codigo] = sum;
            return sum;
        }

        private List<PropiedadPoco> OrdenarListadoAlternativo()
        {
            Dictionary<PropiedadPoco, int> listaOrdenada = new Dictionary<PropiedadPoco, int>();

            try
            {
                EnListarCodigos();
                foreach (PropiedadPoco propiedad in this.lista)
                {
                    if (propiedad.codTipoValor.Equals(simboloFormula))
                    {
                        listaOrdenada.Add(propiedad, ValorOrden(propiedad.codigo));
                    }
                    else
                    {
                        listaOrdenada.Add(propiedad, xListaCodigos[propiedad.codigo]);
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = string.Format(Mensajes.MensajeErrorOrdenamientoEstructura, ex.Message);
                ////mensaje = ex.Message;
                error = true;
            }

            var ordenado = listaOrdenada.OrderBy(o => o.Value).Select(s => s.Key).ToList();
            foreach (PropiedadPoco pro in ordenado)
                Console.WriteLine(listaOrdenada[pro] + "\t" + pro.codigo + " " + pro.concepto + " " + pro.valor);

            return ordenado;
        }

        public List<ResultadoCalculoPoco> Calcular()
        {
            //List<ContratoCalculoPoco> listaContrato = null;
            List<PropiedadPoco> listaOrdenada = OrdenarListadoAlternativo();
            //if (!this.error)
            //{
            //    listaContrato = PrepararCalculo();
            //}
            return !this.error ? ProcesarCalculo(listaOrdenada) : new List<ResultadoCalculoPoco>();
        }

        private List<ResultadoCalculoPoco> ProcesarCalculo(List<PropiedadPoco> listaOrdenada)
        {
            List<ResultadoCalculoPoco> resultado = new List<ResultadoCalculoPoco>();

            ResultadoCalculoPoco detalle;
            CalcEngine.CalcEngine calculadora;
            decimal tipoCambio = 0;

            //Puestos
            foreach (PuestoPoco puesto in listaPuestos)
            {
                //Meses
                for (int mes = mesDesde; mes <= mesHasta; mes++)
                {
                    //Actualizacion de tipo de cambio segun mes
                    tipoCambio = tipoCambioMensual == null ?
                            this.tipoCambioAnual != null ? tipoCambioAnual.valor : 0
                            : mes != mesReajuste ? this.tipoCambioAnual != null ? tipoCambioAnual.valor : 0 : tipoCambioMensual.valor;

                    calculadora = new CalcEngine.CalcEngine();
                    foreach (PropiedadPoco propiedad in listaOrdenada)
                    {
                        detalle = new ResultadoCalculoPoco();
                        detalle.idProPreRem = propiedad.idProPreRem;
                        detalle.idPuePre = puesto.idPuesto;
                        detalle.mes = mes;
                        switch (propiedad.codOrigen)
                        {
                            //Ninguno --Por defecto en soles
                            case "NNN":
                                if (propiedad.codTipoValor.Equals(simboloFormula))
                                    detalle.valor = Math.Round(Convert.ToDecimal(calculadora.Evaluate(propiedad.valor)), 2, MidpointRounding.AwayFromZero);
                                else
                                    detalle.valor = Convert.ToDecimal(propiedad.valor);
                                //indicaSuma = true;
                                break;

                            //Remuneración
                            case "REM":
                                if (this.idTipMon != puesto.idTipMon)
                                {
                                    detalle.valor = puesto.idTipMon == idMonedaDolares ?
                                        Math.Round((decimal)puesto.remuneracion * tipoCambio, 2, MidpointRounding.AwayFromZero) :
                                        Math.Round((decimal)puesto.remuneracion / tipoCambio, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                    detalle.valor = puesto.remuneracion;

                                break;

                            //Es Vacante
                            case "ESV":
                                detalle.valor = puesto.esVacante ? 1 : 0;
                                break;

                            //Es Remuneración diaria
                            case "RDI":
                                detalle.valor = puesto.esRemDiaria ? 1 : 0;
                                break;

                            //Cantidad de Vacantes
                            case "CVA":
                                detalle.valor = puesto.cantVacante;
                                break;

                            //Mes de Cálculo
                            case "MES":
                                detalle.valor = mes;
                                break;

                            //Mes de Cálculo
                            case "GRA":
                                detalle.valor = puesto.grado;
                                break;

                            //Con Bono Alimentación
                            case "IBA":
                                detalle.valor = puesto.conBonoAlimentacion ? 1 : 0;
                                break;

                            //Con Bono Alimentación Especial
                            case "IBD":
                                detalle.valor = puesto.conBonoAlimentacionAdi ? 1 : 0;
                                break;

                            //Con Bono Movilidad
                            case "IBM":
                                detalle.valor = puesto.conBonoMovilidad ? 1 : 0;
                                break;

                            //Con Bono Productividad
                            case "IBP":
                                detalle.valor = puesto.conBonoProductividad ? 1 : 0;
                                break;
                            //Con Sctr Salud
                            case "ISS":
                                detalle.valor = puesto.conSctrSalud ? 1 : 0;
                                break;
                            //ConCon Sctr Pensión
                            case "ISP":
                                detalle.valor = puesto.conSctrPension ? 1 : 0;
                                break;
                            //Situación Especial
                            case "SIE":
                                detalle.valor = puesto.situacionEspecial;
                                break;

                            //Dias del mes actual
                            case "DMS":
                                detalle.valor = DateTime.DaysInMonth(this.anio, mes);
                                break;

                            //dias del mes actual que se encuentra entre las fecha del puesto
                            case "DEF":
                                detalle.valor = puesto.fechaInicio.Month <= mes && puesto.fechaTermino.Month >= mes ?
                                     puesto.fechaInicio.Month == mes ? DateTime.DaysInMonth(this.anio, mes) - puesto.fechaInicio.Day + 1 :
                                     puesto.fechaTermino.Month == mes ? puesto.fechaTermino.Day : DateTime.DaysInMonth(this.anio, mes) 
                                     : 0;

                                break;
                            //Categoria Laboral del puesto
                            case "CAT":
                                detalle.valor = puesto.idCatLab;
                                break;
                            //Categoria Laboral del puesto
                            case "CON":
                                detalle.valor = puesto.idConLab;
                                break;

                            //Parametro
                            case "PAR":
                                var parametro = this.listaParametro.FirstOrDefault(w => w.idConPreRem == propiedad.idConPreRem);
                                if(parametro != null)
                                {
                                    if(parametro.idTipMon != this.idTipMon)
                                    {
                                        detalle.valor = parametro.idTipMon == idMonedaDolares ?
                                        Math.Round((decimal)parametro.importe * tipoCambio, 2, MidpointRounding.AwayFromZero) :
                                        Math.Round((decimal)parametro.importe / tipoCambio, 2, MidpointRounding.AwayFromZero);
                                    }
                                    else detalle.valor = parametro.importe;
                                }

                                break;
                        }

                        calculadora.Variables[propiedad.codigo] = detalle.valor;

                        resultado.Add(detalle);
                    }
                }
            }

            return resultado;
        }
    }
}
