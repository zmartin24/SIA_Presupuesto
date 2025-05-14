window.Presupuesto = (function () {

    //Actualizar Tamaño
    function ActualizarGridAltura(grid) {
        grid.SetHeight(0);
        var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
        if (document.body.scrollHeight > containerHeight)
            containerHeight = document.body.scrollHeight;
        grid.SetHeight(containerHeight);
    }

    // #region Inicio - Requerimiento Mensual de Bienes y Servicios - Cabecera

    var keyReqMensual;
    var estadoReqMensual;
    var totalRequerimientoMensual;
    function grvRequerimientoMensual_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyReqMensual = s.GetRowKey(e.visibleIndex);
            s.GetRowValues(e.visibleIndex, 'total;estado', OnGetRowValueEstadoReqMen);
        }
    }
    function OnGetRowValueEstadoReqMen(value) {
        totalRequerimientoMensual = value[0];
        estadoReqMensual = value[1];
    }

    function traerIDRequerimientoMensualSeleccionada() {

        if (keyReqMensual)
            return keyReqMensual;
        return null;
    };
    function traerEstadoRequerimientoMensualSeleccionada() {
        if (estadoReqMensual)
            return estadoReqMensual;
        return null;
    };



    function botonNuevoRequerimientoMensualGeneral_Click(s, e) {
        popRequerimientoMensual.SetHeaderText("Nuevo Requerimiento Mensual");
        showClearedPopup(popRequerimientoMensual);
        popRequerimientoMensual.PerformCallback("Nuevo|0");
        cbDireccionReqMensual.Focus();
    };

    function botonEditarRequerimientoMensualGeneral_Click(s, e) { // TODO
        popRequerimientoMensual.SetHeaderText("Editar Requerimiento Mensual");
        var id = traerIDRequerimientoMensualSeleccionada();
        var estado = traerEstadoRequerimientoMensualSeleccionada();
        
        
        if (id != null) {
            if (estado == 10 || estado == 59) {
                alert("Error: no es posisble editar, requerimiento ya fue procesado");
                popRequerimientoMensual.SetHeaderText("Requerimiento Mensual");
                showClearedPopup(popRequerimientoMensual);
                popRequerimientoMensual.PerformCallback("Mostrar|" + id);
                btnGrabar.SetEnabled(false);
            }
            else {
                showClearedPopup(popRequerimientoMensual);
                popRequerimientoMensual.PerformCallback("Editar|" + id);
            }
        }
        else
            alert('Debe seleccionar un requerimiento');
    };
    function botonClonarRequerimientoMensualGeneral_Click(s, e) {
        var id = traerIDRequerimientoMensualSeleccionada();
        var total = totalRequerimientoMensual;

        if (id == null) {
            alert('Debe seleccionar un requerimiento mensual');
            e.processOnServer = false;
            
        }
        else if (total == 0) {
            e.processOnServer = false;
            alert('No puedes clonar requerimiento con importe cero');
        }
        else {
            popRequerimientoMensual.SetHeaderText("Clonar Requerimiento (" + id + ")");
            showClearedPopup(popRequerimientoMensual);
            popRequerimientoMensual.PerformCallback("Clonar|" + id);
        }
    };

    function botonAnularRequerimientoMensualGeneral_Click(s, e) {
        var id = traerIDRequerimientoMensualSeleccionada();
        var estado = traerEstadoRequerimientoMensualSeleccionada();
        
        if (id != null) {
            if (estado == 10 || estado == 59) {
                alert("Error: no es posisble anular, requerimiento ya fue procesado");
                e.processOnServer = false;
                return;
            }

            if (confirm("¿Desea anular el requerimiento?"))
                cpPrincipal.PerformCallback(serializeArgs(["Anular", id]));
        }
        else
            alert('Debe seleccionar un requerimiento');
    };

    function botonDetalleRequerimientoMensualGeneral_Click(s, e) {
        var id = traerIDRequerimientoMensualSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./frmRequerimientoMensualBienServicio.aspx?idReq=" + id;
            $(location).attr('href', url);
        }
    };
    function botonRequerimientoMensualSeguimiento_Click(s, e) {
        var id = traerIDRequerimientoMensualSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./frmRequerimientoMensualSeguimiento.aspx?idReq=" + id;
            $(location).attr('href', url);
        }
    };

    function botonAprobarRequerimientoMensualGeneral_Click(s, e) { // TODO
        
        var id = traerIDRequerimientoMensualSeleccionada();
        var estado = traerEstadoRequerimientoMensualSeleccionada();

        if (id != null) {
            if (estado == 10 || estado == 59) {
                alert("Error: no es posisble aprobar, requerimiento ya fue procesado");
                e.processOnServer = false;
            }
            else {
                var seleccion = confirm("¿Está seguro de aprobar requerimiento?");
                if (seleccion) {
                    var boton = document.getElementById('<%=btnAprobar.ClientID%>');
                    boton.click();
                }
                else
                    e.processOnServer = false;
            }
        }
        else {
            alert('Debe seleccionar un requerimiento');
            e.processOnServer = false;
        }
    };
    function botonVolverEstadoRequerimientoMensualGeneral_Click(s, e) { 

        var id = traerIDRequerimientoMensualSeleccionada();
        var estado = traerEstadoRequerimientoMensualSeleccionada();

        if (id != null) {
            if (estado == 59) {
                alert("Error: no es posisble anular aprobación, requerimiento ya fue asignado un presupuesto");
                e.processOnServer = false;
            }
            else if (estado == 2) {
                e.processOnServer = false;
            }
            else {
                var seleccion = confirm("¿Está seguro de anular aprobación?");
                if (seleccion) {
                    var boton = document.getElementById('<%=btnVolver.ClientID%>');
                    boton.click();
                }
                else
                    e.processOnServer = false;
            }
        }
        else {
            alert('Debe seleccionar un requerimiento');
            e.processOnServer = false;
        }

    };

    function botonImprimirRequerimientoMensualGeneral_Click(s, e) {
        var id = traerIDRequerimientoMensualSeleccionada();
        openReport_("ReqMensualBieSer", id);
    };

    function botonGuardarRequerimientoMensualGeneral_Click(s, e) {

        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            e.processOnServer = false;
            return;
        }

        //var commandName = popRequerimientoMensual.cpID ? "Editar" : "Nuevo";
        var commandName = popRequerimientoMensual.cpOpcion;

        var idArea = cbAreaReqMensual.GetValue().toString();
        var idTipoRequerimiento = cbTipoRequerimiento.GetValue().toString();
        var idMoneda = cbMoneda.GetValue().toString();
        var anio = seAnio.GetNumber().toString();
        var mes = cbMesRegReqMensual.GetValue().toString();
        var descripcion = txtDescripcion.GetValue().toString();        

        var arg = serializeArgs([commandName, popRequerimientoMensual.cpID, idArea, idTipoRequerimiento, idMoneda, anio, mes, descripcion]);
        
        GuardarFormularioAyuda(popRequerimientoMensual, arg, cpPrincipal);
    };

    function botonCancelarRequerimientoMensualGeneral_Click(s, e) {
        popRequerimientoMensual.Hide();
    };

    function cbAnioListado_SelectedIndexChanged(s, e) {
        var parametro = cbAnioListado.GetValue().toString() + "|" + cbMesListado.GetValue().toString();
        
        grvRequerimientoMensual.PerformCallback(parametro);
    };

    function cbMesListado_SelectedIndexChanged(s, e) {
        var parametro = cbAnioListado.GetValue().toString() + "|" + cbMesListado.GetValue().toString();

        grvRequerimientoMensual.PerformCallback(parametro);
    };

    var ultimaDireccionReqMensual = null;
    function cbDireccionReqMensual_SelectedIndexChanged(s, e) {
        if (cbSubdireccionReqMensual.InCallback()) {
            ultimaDireccionReqMensual = cbDireccionReqMensual.GetValue().toString();
        }
        else {
            cbSubdireccionReqMensual.PerformCallback(cbDireccionReqMensual.GetValue().toString());
            cbAreaReqMensual.PerformCallback(cbDireccionReqMensual.GetValue().toString());
        }
    };

    function cbSubdireccionReqMensual_EndCallback(s, e) {
        if (ultimaDireccionReqMensual) {
            cbSubdireccionReqMensual.PerformCallback(ultimaDireccionReqMensual);
            ultimaDireccionReqMensual = null;
        }
    };

    var ultimaSubdireccionReqMensual = null;
    function cbSubdireccionReqMensual_SelectedIndexChanged(s, e) {
        if (cbAreaReqMensual.InCallback()) {
            ultimaSubdireccionReqMensual = cbSubdireccionReqMensual.GetValue().toString();
        }
        else {
            cbAreaReqMensual.PerformCallback(cbSubdireccionReqMensual.GetValue().toString());
        }
    };
    var ultimaAreaReqMensual = null;
    function cbAreaReqMensual_SelectedIndexChanged(s, e) {
        var tipoReq = cbTipoRequerimiento.GetValue().toString();
        var anio = seAnio.GetNumber().toString();
        var mes = cbMesRegReqMensual.GetValue().toString();

        var idArea = '0';
        if (cbAreaReqMensual.GetValue() != null)
            idArea = cbAreaReqMensual.GetValue().toString();


        var parametro = tipoReq + "|" + anio + "|" + mes + "|" + idArea;
        grvRequerimientoBienServicio.PerformCallback(parametro);
    };
    function cbTipoRequerimiento_SelectedIndexChanged(s, e) {

        if (cbTipoRequerimiento.InCallback()) {
            ultimaGruEje = cbGruPreEje.GetValue().toString();
        }
        else {
            cbTipoRequerimiento.PerformCallback(cbTipoRequerimiento.GetValue().toString());
        }
        //var tipoReq = cbTipoRequerimiento.GetValue().toString();
        //var anio = seAnio.GetNumber().toString();
        //var mes = cbMesRegReqMensual.GetValue().toString();

        //var idArea = '0';
        //if (cbAreaReqMensual.GetValue() != null)
        //    idArea = cbAreaReqMensual.GetValue().toString();
        //console.log('cbTipoRequerimiento.GetValue().toString() :', tipoReq);
        
        //var parametro = tipoReq + "|" + anio + "|" + mes + "|" + idArea;
        //grvRequerimientoBienServicio.PerformCallback(parametro);
    };

    function cargar_grvRequerimientoBienServicio() {
        //sessionStorage.setItem("nombre", "Antony Lachi");
        //var UserName = popRequerimientoMensual.cpIdSession;//'<%= Session("idSession") %>';

        ////console.log("Datos de Session :", sessionStorage.getItem("idSession"));
        ////console.log("Datos de Session :", UserName);

        var tipoReq = cbTipoRequerimiento.GetValue().toString();
        var anio = seAnio.GetNumber().toString();
        var mes = cbMesRegReqMensual.GetValue().toString();

        var idArea = '0';
        if (cbAreaReqMensual.GetValue() != null)
            idArea = cbAreaReqMensual.GetValue().toString();

        var parametro = tipoReq + "|" + anio + "|" + mes + "|" + idArea;
        grvRequerimientoBienServicio.PerformCallback(parametro);
    }

    function cbMesRegReqMensual_SelectedIndexChanged(s, e) {
        cargar_grvRequerimientoBienServicio();
    };

    function seAnio_NumberChanged(s, e) {
        setTimeout(function () {
            cargar_grvRequerimientoBienServicio();
        }, 100);
    }

    function cbAreaReqMensual_EndCallback(s, e) {
        if (ultimaSubdireccionReqMensual) {
            cbAreaReqMensual.PerformCallback(ultimaSubdireccionReqMensual);
            ultimaSubdireccionReqMensual = null;
        }
    };

    var ultimaDireccionReporte = null;
    function cbDireccionReporte_SelectedIndexChanged(s, e) {
        if (cbSubdireccionReporte.InCallback()) {
            ultimaDireccionReporte = cbDireccionReporte.GetValue().toString();
        }
        else {
            cbSubdireccionReporte.PerformCallback(cbDireccionReporte.GetValue().toString());            
        }
    };

    function cbSubdireccionReporte_EndCallback(s, e) {
        if (ultimaDireccionReporte) {
            cbSubdireccionReporte.PerformCallback(ultimaDireccionReporte);
            ultimaDireccionReporte = null;
        }
    };

    var ultimaDireccionReporteRRHHImp = null;
    function cbDireccionReporteRRHHImp_SelectedIndexChanged(s, e) {
        if (cbSubdireccionReporteImp.InCallback()) {
            ultimaDireccionReporteRRHHImp = cbDireccionReporteImp.GetValue().toString();
        }
        else {
            cbSubdireccionReporteImp.PerformCallback(cbDireccionReporteImp.GetValue().toString());
        }
    };
    function cbSubdireccionReporteImp_EndCallback(s, e) {
        if (ultimaDireccionReporteRRHHImp) {
            cbSubdireccionReporteImp.PerformCallback(ultimaDireccionReporteRRHHImp);
            ultimaDireccionReporteRRHHImp = null;
        }
    };


    function botonImprimirReporteMensual_Click(s, e) {

        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            e.processOnServer = false;
            return;
        }

        var idDireccion = cbDireccionReporte.GetValue().toString();
        var idSubdireccion = cbSubdireccionReporte.GetValue().toString();
        var tipo = cbTipoReporte.GetValue().toString();
        var tipoRequerimiento = cbRequerimientoReporte.GetValue().toString();
        var anio = cbAnioReporte.GetValue().toString();
        var mes = cbMesReporte.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ReqMensualBieSerDireccion", idDireccion, idSubdireccion, tipo, tipoRequerimiento, anio, mes]);
        openPageViewerPopup(url, "ReqMensualBieSerDireccion");
    };

    function botonSalirReporteMensual_Click(s, e) {
        popReporteDireccion.Hide();
    };
    function botonMigraRequerimiento_Click(s, e) {
        var seleccion = confirm("¿Está seguro de registrar detalles?");
        if (seleccion) {
            var boton = document.getElementById('<%=btnMigra.ClientID%>');
            boton.click();
        }
        else
            e.processOnServer = false;
    };

    // #endregion



    //Reportes
    function pageViewerPopup_Shown(s, e) {
        //preparePopupWithIframe(s);
    };


    function pageViewerPopup_CloseUp(s, e) {
        s.SetContentUrl("");
    };

    function openReport_(reportName, itemID) {
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs([reportName, itemID]);
        openPageViewerPopup(url, reportName);
    };

    function openReport(reportName, itemID) {
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs([reportName, itemID]);
        openPageViewerPopup(url, reportName);
    };
    function openReport(reportName, itemID, codReporte, idDireccion, idFueFin) {
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs([reportName, itemID, codReporte, idDireccion, idFueFin]);
        openPageViewerPopup(url, reportName);
    };
    function openReport(reportName, codReporte, anio, mes) {
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs([reportName, codReporte, anio, mes]);
        openPageViewerPopup(url, reportName);
    };

    function openPageViewerPopup(contentUrl, reportName) {
        //alert(contentUrl + ' : ' + reportName);
        pageViewerPopup.SetHeaderText(pageViewerPopup.cpReportDisplayNames[reportName]);
        pageViewerPopup.Show();
        pageViewerPopup.SetContentUrl(contentUrl);
    };

    function openPageViewerPopupSin(titulo, contenidoUrl) {
        pageViewerPopup.SetHeaderText(titulo);
        pageViewerPopup.Show();
        pageViewerPopup.SetContentUrl(contenidoUrl);
    };

    //General
    function showClearedPopup(popup) {
        popup.Show();
        ASPxClientEdit.ClearEditorsInContainer(document.getElementById("EditFormsContainer"));
    };

    function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    };

    function serializeArgs(args) {
        var result = [];
        for (var i = 0; i < args.length; i++) {
            var value = args[i] ? args[i].toString() : "";
            result.push(value.length);
            result.push("|");
            result.push(value);
        }
        return result.join("");
    };

    function GuardarFormularioAyuda(popup, args, panel) {
        //alert(popup+' - P '+args+' pen '+panel);
        if (!ASPxClientEdit.ValidateEditorsInContainer(popup.GetMainElement()))
            return;

        popup.Hide();
        var callbackArgs = [popup.cpOpcion, popup.cpNombre, args];
        panel.PerformCallback(serializeArgs(callbackArgs));
    };

    function cpPrincipal_EndCallback(s, e) {
        if (cpPrincipal.cpMensaje) {
            
            if (cpPrincipal.cpGrid) {
                switch (cpPrincipal.cpGrid) {
                    case "grvRequerimiento":
                        grvRequerimiento.Refresh();
                        break;
                    case "grvRequerimientoMensual":
                        grvRequerimientoMensual.Refresh();
                        break;
                    case "grvReqRecursosHumanos":
                        grvReqRecursosHumanos.Refresh();
                        break;
                    case "grvReqDet":
                        grvReqDet.Refresh();
                        break;
                    case "grvPac":
                        grvPac.Refresh();
                        break;
                    case "grvGasRec":
                        grvGasRec.Refresh();
                        break;
                    case "grvSubPresupuesto":
                        grvSubPresupuesto.Refresh();
                        break;
                    case "grvEvaluacion":
                        grvEvaluacion.Refresh();
                        break;
                    case "grvPresupuesto":
                        grvPresupuesto.Refresh();
                        break;
                    case "grvCertificacion":
                        grvCertificacion.Refresh();
                        break;
                    case "grvPresupuestoClase":
                        grvPresupuestoClase.Refresh();
                        break;
                    case "grvPivot":
                        grvPivot.Refresh();
                        break;
                    case "grvReqMenDet":
                        grvReqMenDet.Refresh();
                        break;
                        
                }
            }
        }
    };
    
    
    function cbCuenta_SelectedIndexChanged(s, e) {
          var  valor = cbCuenta.GetValue().toString();
          grvProducto.Refresh();
    };
    function cbTipo_SelectedIndexChanged(s, e) {
        
        hdfValores.Set('tipo', cbTipo.GetValue().toString());
        
        if (cbTipo.GetValue().toString() == 2) {
            chkConPartida.SetValue(true);
            chkConPartida.SetEnabled(false);
            btnSelecPartida.SetEnabled(true);
            btnSelecProducto.SetEnabled(false);

            frmDetalle.GetItemByName('bliPartida').SetVisible(true);
            frmDetalle.GetItemByName('bliProducto').SetVisible(false);
        }
        else {
            chkConPartida.SetEnabled(true);
            chkConPartida.SetValue(false);
            btnSelecPartida.SetEnabled(false);
            btnSelecProducto.SetEnabled(true);

            frmDetalle.GetItemByName('bliPartida').SetVisible(false);
            frmDetalle.GetItemByName('bliProducto').SetVisible(true);
        }
        hdfValores.Set('idProducto', '0');
        hdfValores.Set('idParPre', '0');
        txtDescripcion.SetValue('');
        btnSelecPartida.SetValue('');
        btnSelecProducto.SetValue('');
        cbUnidad.SetValue(4);//Defecto Unidad
        sePrecio.SetValue(0);
        cbTipo.Focus();
    };
    function cbPartida_SelectedIndexChanged(s, e) {
        cbPartida.PerformCallback(cbPartida.GetSelectedItem());
    };
    function cbPartida_EndCallback(s, e) {
        var tmpText = '';

        tmpText = s.precio;
        alert('Cambia Partida: ' + tmpText);
    }

    function ceEsVacante_CheckedChanged(s, e) {
        //Synchronize the client variable's value with the confirm dialog checkbox' 
        //setting, and focus the Yes button
        //var esVacante = ceEsVacante.GetValue().toString();
        if (ceEsVacante.GetValue()) {
            
            txtPersonal.SetValue('[VACANTE]');
            seCantVacante.SetValue(1);
            seCantVacante.SetEnabled(true);
            btnAyudaPersonal.SetEnabled(false);
            seCantVacante.Focus();
        }
        else {
            txtPersonal.SetValue('');
            seCantVacante.SetValue(0);
            seCantVacante.SetEnabled(false);
            btnAyudaPersonal.SetEnabled(true);
            btnAyudaPersonal.Focus();
        }
        
    };
    //Guardar Requerimiento General
    //
    //Direccion y Subdireccion
    var ultimaDireccion = null;
    function cbDireccion_SelectedIndexChanged(s, e) {
        if (cbSubdireccion.InCallback()) {
            ultimaDireccion = cbDireccion.GetValue().toString();
        }
        else {
            cbSubdireccion.PerformCallback(cbDireccion.GetValue().toString());
        }
    };

    function cbSubdireccion_EndCallback(s, e) {
        if (ultimaDireccion) {
            cbSubdireccion.PerformCallback(ultimaDireccion);
            ultimaDireccion = null;
        }
    };

    var ultimaSubdireccion = null;
    function cbSubdireccion_SelectedIndexChanged(s, e) {
        if (cbArea.InCallback()) {
            ultimaSubdireccion = cbSubdireccion.GetValue().toString();
        }
        else {
            cbArea.PerformCallback(cbSubdireccion.GetValue().toString());
        }
    };

    function cbArea_EndCallback(s, e) {
        if (ultimaSubdireccion) {
            cbArea.PerformCallback(ultimaSubdireccion);
            ultimaSubdireccion = null;
        }
    };

    function cbAnio_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString();
        cpPrincipal.PerformCallback(serializeArgs(["Lista", "0"]));//Para principal
        grvRequerimiento.PerformCallback(parametro);
    };

    function cbAnioPreMen_SelectedIndexChanged(s, e) {
        var parametro = cbAnioPreMen.GetValue().toString();
        grvSubPresupuesto.PerformCallback(parametro);
    };

    function cbAnioPopExpProAnuMas_SelectedIndexChanged(s, e) {
        hdfValores.Set("anioPopExpProAnuMas", cbAnioPopExpProAnuMas.GetValue().toString())
        grvPopExpProAnuMas.PerformCallback();
    };

    function cbAnioRRHH_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString();
        cpPrincipal.PerformCallback(serializeArgs(["Lista", "0"]));
        grvReqRecursosHumanos.PerformCallback(parametro);
    };

    function cbAnioCertificacion_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString();
        grvCertificacion.PerformCallback(parametro);
    };

    function cbAnioEva_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString() + "|" + cbMes.GetValue().toString();
        grvEvaluacion.PerformCallback(parametro);
    };

    function cbMesEva_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString() + "|" + cbMes.GetValue().toString();
        grvEvaluacion.PerformCallback(parametro);
    };

    function cbAnioRea_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString() + "|" + cbMes.GetValue().toString();
        grvReajuste.PerformCallback(parametro);
    };

    function cbMesRea_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString() + "|" + cbMes.GetValue().toString();
        grvReajuste.PerformCallback(parametro);
    };
    function cbAnioAyudaPrecio_SelectedIndexChanged(s, e) {
        var parametro = cbAnio.GetValue().toString() + "|" + hdfValores.Get("idProducto") + "|" + cbCuenta.GetValue().toString() + "|" + hdfValores.Get("idReq");
        grvPrecio.PerformCallback(parametro);
    };
    function cbAnioEvaRea_SelectedIndexChanged(s, e) {
        hdfValores.Set("anioEvaRea", cbAnioEvaRea.GetValue().toString())
        var parametro = cbAnioEvaRea.GetValue().toString();
        grvPresupuestoAnualEvaRea.PerformCallback(parametro);
    };
    
    var ultimaGruPre = null;
    function cbGruPre_SelectedIndexChanged(s, e) {
        if (cbPresupuesto.InCallback()) {
            ultimaGruPre = cbGruPre.GetValue().toString();
        }
        else {
            cbPresupuesto.PerformCallback(cbGruPre.GetValue().toString());
        }
    };
    function cbPresupuesto_EndCallback(s, e) {
        if (ultimaGruPre) {
            cbPresupuesto.PerformCallback(ultimaGruPre);
            ultimaGruPre = null;
        }
    };
    var ultimaPresupuesto = null;
    function cbPresupuesto_SelectedIndexChanged(s, e) {
        if (cbSubPresupuesto.InCallback()) {
            ultimaPresupuesto = cbPresupuesto.GetValue().toString();
        }
        else {
            cbSubPresupuesto.PerformCallback(cbPresupuesto.GetValue().toString());
        }
    };
    function cbSubPresupuesto_EndCallback(s, e) {
        if (ultimaPresupuesto) {
            cbArea.PerformCallback(ultimaSubdireccion);
            ultimaPresupuesto = null;
        }
    };
    var ultimaSubPresupuesto = null;
    function cbSubPresupuesto_SelectedIndexChanged(s, e) {
        var parametro = cbSubPresupuesto.GetValue().toString();
            grvPresupuestoClase.PerformCallback(parametro);
    };
    //Evaluacion Pop Ejecución
    var ultimaGruEje = null;
    function cbGruPreEje_SelectedIndexChanged(s, e) {
        if (cbPreEje.InCallback()) {
            ultimaGruEje = cbGruPreEje.GetValue().toString();
        }
        else {
            cbPreEje.PerformCallback(cbGruPreEje.GetValue().toString());
        }
    };
    function cbPreEje_EndCallback(s, e) {
        if (ultimaGruEje) {
            cbPreEje.PerformCallback(ultimaGruEje);
            ultimaGruEje = null;
        }
    };
    var ultimaPresupuestoEje = null;
    function cbPreEje_SelectedIndexChanged(s, e) {
        if (cbSubPreEje.InCallback()) {
            ultimaPresupuestoEje = cbPreEje.GetValue().toString();
        }
        else {
            cbSubPreEje.PerformCallback(cbPreEje.GetValue().toString());
        }
    };
    function cbSubPreEje_EndCallback(s, e) {
        if (ultimaPresupuestoEje) {
            cbSubPreEje.PerformCallback(ultimaPresupuestoEje);
            ultimaPresupuestoEje = null;
        }
    };
    //Evaluacion Pop Ejecución por fechas
    var ultimaGruEjeFec = null;
    function cbGruPre_PreMenFec_SelectedIndexChanged(s, e) {
        if (cbPre_PreMenFec.InCallback()) {
            ultimaGruEjeFec = cbGruPre_PreMenFec.GetValue().toString();
        }
        else {
            cbPre_PreMenFec.PerformCallback(cbGruPre_PreMenFec.GetValue().toString());
        }
    };
    function cbPre_PreMenFec_EndCallback(s, e) {
        if (ultimaGruEjeFec) {
            cbPre_PreMenFec.PerformCallback(ultimaGruEjeFec);
            ultimaGruEjeFec = null;
        }
    };

    //Requerimiento
    var keyReq;
    var totalRequerimiento;
    function grvRequerimiento_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyReq = s.GetRowKey(e.visibleIndex);
            s.GetRowValues(e.visibleIndex, 'idReqBieSer;total', OnGetRowValuesRequerimiento);
        }    
    }

    function traerIDRequerimientoSeleccionada() {
        
        if (keyReq)
            return keyReq;
        return null;
    };
    function OnGetRowValuesRequerimiento(values) {
        totalRequerimiento = values[1];
    }

    //grvReqRecursosHumanos
    var keyReqRH;
    function grvReqRecursosHumanos_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyReqRH = s.GetRowKey(e.visibleIndex);
        }
    }

    function traerIDRequerimientoRHSeleccionada() {
        if (keyReqRH)
            return keyReqRH;
        return null;
    };


    //Reajuste
    var keyRea;
    function grvReajuste_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyRea = s.GetRowKey(e.visibleIndex);
        }
    }
    function traerIDReajusteSeleccionada() {
        if (keyRea)
            return keyRea;
        return null;
    };

    //Presupuesto mensual
    var keySubPre;
    function grvSubPresupuesto_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keySubPre = s.GetRowKey(e.visibleIndex);
        }
    }
    function traerIDSubPresupuestoSeleccionada() {
        if (keySubPre)
            return keySubPre;
        return null;
    };

    //Presupuesto Anual
    var keyProAnu;
    function grvProgramacionAnual_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyProAnu = s.GetRowKey(e.visibleIndex);
        }
    }
    function traerIDPresupuestoAnualSeleccionada() {
        if (keyProAnu)
            return keyProAnu;
        return null;
    };

    //Evaluacion
    var keyEva;
    function grvEvaluacion_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyEva = s.GetRowKey(e.visibleIndex);
        }
    }
    function traerIDEvaluacionSeleccionada() {
        if (keyEva)
            return keyEva;
        return null;
    };

    function traerIDPacSeleccionada() {

        if (keyReq)
            return keyReq;
        return null;
    };
    function traerIDGasRecSeleccionada() {
        if (keyReq)
            return keyReq;
        return null;
    };
    function traerIDCertificacionSeleccionada() {

        if (keyReq)
            return keyReq;
        return null;
    };

    function botonNuevoRequerimientoGeneral_Click(s, e) {
        popRequerimiento.SetHeaderText("Nuevo Requerimiento");
        showClearedPopup(popRequerimiento);
        popRequerimiento.PerformCallback("Nuevo|0");
        cbDireccion.Focus();
        e.processOnServer = false;
    };

    function botonEditarRequerimientoGeneral_Click(s, e) { // TODO
        popRequerimiento.SetHeaderText("Editar Requerimiento");
        var id = traerIDRequerimientoSeleccionada();
        if (id != null) {
            showClearedPopup(popRequerimiento);
            popRequerimiento.PerformCallback("Editar|" + id);
            e.processOnServer = false;
        }
        else
            alert('Debe seleccionar un requerimiento');
    };
    function botonClonarRequerimientoGeneral_Click(s, e) { 
        var id = traerIDRequerimientoSeleccionada();
        var total = totalRequerimiento;

        if (id == null) {
            e.processOnServer = false;
            alert('Debe seleccionar un requerimiento');
            
        } else if (total == 0) {
            e.processOnServer = false;
            alert('No puedes clonar requerimiento con importe cero');
        }
        else {
            popRequerimiento.SetHeaderText("Clonar Requerimiento (" + id + ")");
            showClearedPopup(popRequerimiento);
            popRequerimiento.PerformCallback("Clonar|" + id);
        }
    };

    function botonEditarRequerimientoRRHH_Click(s, e) { // TODO
        popRequerimiento.SetHeaderText("Editar Requerimiento");
        var id = traerIDRequerimientoRHSeleccionada();
        if (id != null) {
            showClearedPopup(popRequerimiento);
            popRequerimiento.PerformCallback("Editar|" + id);
        }
        else
            alert('Debe seleccionar un requerimiento');
    };

    function botonAnularRequerimientoGeneral_Click(s, e) {
        var id = traerIDRequerimientoSeleccionada();
        if (id != null) {
            if (confirm("¿Desea anular el requerimiento?"))
                cpPrincipal.PerformCallback(serializeArgs(["Anular", id]));
        }
        else
            alert('Debe seleccionar un requerimiento');
    };
    function botonAnularRequerimientoRRHH_Click(s, e) {
        var id = traerIDRequerimientoRHSeleccionada();
        if (id != null) {
            if (confirm("¿Desea anular el requerimiento?"))
                cpPrincipal.PerformCallback(serializeArgs(["Anular", id]));
        }
        else
            alert('Debe seleccionar un requerimiento');
    };

    function botonImprimirRequerimientoGeneral_Click(s, e) {
        var id = traerIDRequerimientoSeleccionada();
        //alert(id);
        openReport_("ReqBieSer", id);
    };

    function botonImprimirRequerimientoDetMen_Click(s, e) {
        //var id = traerIDRequerimientoSeleccionada
        var id = hdfValores.Get("idReq");
        //alert(id);
        openReport_("ReqBieSerDetMen", id);
    };
    

    function botonConsolidadoPorDirecciones_Click(s, e) {
        var anio = parseInt(cbAnio.GetValue());
        openReport("ConsPorDir", anio);
    };

    function botonResumenPorSubdirecciones_Click(s, e) {
        popReporteDireccion.SetHeaderText("Resumen por Dirección y Subdirección");
        showClearedPopup(popReporteDireccion);
        popReporteDireccion.PerformCallback("0");
    };

    function botonSalirReporteResumenPorSubdirecciones_Click(s, e) {
        popReporteDireccion.Hide();
    };

    function botonImprimirResumenPorSubdirecciones_Click(s, e) {
       
        e.processOnServer = false;
        var anio = parseInt(cbDir.GetValue());
        //var idFueFin = cbFueFinCal.GetValue().toString();
        var id = cbDir.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ResPresPorSub", anio, id]);
        openPageViewerPopup(url, "ResPresPorSub");
       
    };

    //CALENDARIO ANUAL PRESUPUESTO ********************************************************************
    function botonCalendarioPresAnual_Click(s, e) {
        popCalendarioAnual.SetHeaderText("Calendario Anual de Presupuesto");
        showClearedPopup(popCalendarioAnual);
        popCalendarioAnual.PerformCallback("0");
    };

    function botonImprimirCalendarioPresAnual_Click(s, e) {
        var anio = parseInt(cbAnioCal.GetValue());
        var idFueFin = cbFueFinCal.GetValue().toString();
        var idProAnu = cbPresAnual.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["CalPresAnu", anio, idFueFin, idProAnu]);
        openPageViewerPopup(url, "CalPresAnu");
    };

    function botonSalirReporteCalendarioPres_Click(s, e) {
        popCalendarioAnual.Hide();
    };

    //CALENDARIO EVALUACION Y REAJUSTE PRESUPUESTO ********************************************************************
    function botonImprimirEvaluacion_Click(s, e) {
        var idTipRep = parseInt(cbTipRep.GetValue());
        var anio = parseInt(cbAnioEvaImp.GetValue());
        var mes = parseInt(cbMesEvaImp.GetValue());
        openReport("ImprimirEvaluacion", idTipRep, anio, mes);
    };
    function botonCalendarioPresAnualEvaReajuste_Click(s, e) {
        popCalendarioAnual.SetHeaderText("Calendario Reajuste y Evaluación de Presupuesto");
        showClearedPopup(popCalendarioAnual);
        popCalendarioAnual.PerformCallback("0");
    };
    function botonPopImprimirSalGru_Click(s, e) {
        popSaldoGrupo.SetHeaderText("Imprimir Saldos");
        showClearedPopup(popSaldoGrupo);
        popSaldoGrupo.PerformCallback("0");
    };

    function botonImprimirCalendarioEvaReajuste_Click(s, e) {
        var anio = parseInt(cbAnioCal.GetValue());
        var mesEva = cbMesEvaCal.GetValue().toString();
        var mesRea = cbMesReaCal.GetValue().toString();
        var idFueFin = cbFueFinCal.GetValue().toString();
        var idProAnu = cbPresAnual.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["CalEvaReajuste", anio, idFueFin, idProAnu, mesEva, mesRea]);
        openPageViewerPopup(url, "CalEvaReajuste");
    };

    function botonSalirReporteCalendarioEvaReajuste_Click(s, e) {
        popCalendarioAnual.Hide();
    };

    //CONSOLIDADO EVALUACION Y REAJUSTE PRESUPUESTO ********************************************************************
    function botonPopImprimirEvaluacionMensual_Click(s, e) {
        popImprimirEvaluacion.SetHeaderText("Reporte por Evaluación");
        showClearedPopup(popImprimirEvaluacion);
        popImprimirEvaluacion.PerformCallback("0");
    };

    function botonPopExpProAnu_Click(s, e) {

        var id = traerIDPresupuestoAnualSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            hdfValores.Set("idProAnu", id);
            popExportaProAnu.SetHeaderText("Exportar Presupuesto Anual");
            showClearedPopup(popExportaProAnu);
            popExportaProAnu.PerformCallback("0");
        }
    };

    function botonPopExpProAnuMas_Click(s, e) {
        popExportaProAnuMasivo.SetHeaderText("Exportar Presupuesto Anual Masivo");
        showClearedPopup(popExportaProAnuMasivo);
        popExportaProAnuMasivo.PerformCallback("0");
    };

    function botonPopExportarPresupuestoMensualMoneda_Click(s, e) {
        var id = !(traerIDSubPresupuestoSeleccionada()) ? hdfValores.Get("idSubPre") : traerIDSubPresupuestoSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            hdfValores.Set("idSubPre", id);
            popPreMenMoneda.SetHeaderText("Exportar Presupuesto Mensual");
            showClearedPopup(popPreMenMoneda);
            popPreMenMoneda.PerformCallback("0");
        }
    };
    function botonExportarEvaluacionMoneda_Click(s, e) {
        
        var id = traerIDEvaluacionSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            hdfValores.Set("id", id);
            popEvaluacionMoneda.SetHeaderText("Exportar Evaluación Mensual de Presupuesto");
            showClearedPopup(popEvaluacionMoneda);
            popEvaluacionMoneda.PerformCallback("0");
        }
    };
    function botonExportarEvaluacionReajuste_Click(s, e) {
        popEvaRea.SetHeaderText("Exportar Evaluación y Reajuste de Presupuesto");
        showClearedPopup(popEvaRea);
        popEvaRea.PerformCallback("0");
    };
    function botonConsolidadoPorDireccionesEvaReajuste_Click(s, e) {
        popCalendarioAnualCon.SetHeaderText("Consolidado Reajuste y Evaluación de Presupuesto por Direcciones");
        showClearedPopup(popCalendarioAnualCon);
        popCalendarioAnualCon.PerformCallback("0");
    };

    function botonImprimirConsolidadoEvaReajuste_Click(s, e) {
        var anio = parseInt(cbAnioCon.GetValue());
        var mesEva = cbMesEvaCon.GetValue().toString();
        var mesRea = cbMesReaCon.GetValue().toString();
        var idFueFin = cbFueFinCon.GetValue().toString();
        var idProAnu = 0;
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ConsEvaReaPorDir", anio, idFueFin, idProAnu, mesEva, mesRea]);
        openPageViewerPopup(url, "ConsEvaReaPorDir");
    };

    function botonSalirReporteConsolidadoEvaReajuste_Click(s, e) {
        popCalendarioAnualCon.Hide();
    };


    //RESUMEN EVALUACION Y REAJUSTE PRESUPUESTO POR SUBDIRECCION ********************************************************************
    function botonResumenPorSubdireccionesEvaReajuste_Click(s, e) {
        popReporteDireccion.SetHeaderText("Resumen Reajuste y Evaluación de Presupuesto por Subdirección");
        showClearedPopup(popReporteDireccion);
        popReporteDireccion.PerformCallback("0");
    };
    function botonPopImprimirEjePreMen_Click(s, e) {
        popEjecucionPreMen.SetHeaderText("Resumen de Ejecución de Presupuesto Mensual");
        showClearedPopup(popEjecucionPreMen);
        popEjecucionPreMen.PerformCallback("0");
    };
    function botonPopImprimirEjePreMenFec_Click(s, e) {
        popEjecucionPreMenFec.SetHeaderText("Resumen de Ejecución de Presupuesto Mensual por Fechas");
        showClearedPopup(popEjecucionPreMenFec);
        popEjecucionPreMenFec.PerformCallback("0");
    };

    function botonImprimirResumenPorSubdirEvaReajuste_Click(s, e) {
        var anio = parseInt(cbAnioSub.GetValue());
        var idDir = 0;
        var mesEva = cbMesEvaSub.GetValue().toString();
        var mesRea = cbMesReaSub.GetValue().toString();
        var idGruPre = cbGruPre.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ResEvaReajuste", anio, idDir, idGruPre, mesRea, mesEva]);
        openPageViewerPopup(url, "ResEvaReajuste");
    };
    function botonImprimirEjecucionPreMen_Click(s, e) {
        var idGruPre = cbGruPreEje.GetValue().toString();
        var idPre = cbPreEje.GetValue().toString();
        var idSubPre = cbSubPreEje.GetValue().toString();
        var idMoneda = cbMonedaEje.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["EjecucionPreMen", idGruPre, idPre, idSubPre, idMoneda]);
        openPageViewerPopup(url, "EjecucionPreMen");
    };
    function botonImprimirEjecucionPreMenFec_Click(s, e) {
        var fechaDesde = cFecDesde_PreMenFec.GetDate().toLocaleDateString().toString();
        var fechaHasta = cFecHasta_PreMenFec.GetDate().toLocaleDateString().toString();
        var idGruPre = cbGruPre_PreMenFec.GetValue().toString();
        var idPre = cbPre_PreMenFec.GetValue().toString();
        var idMoneda = cbMoneda_PreMenFec.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["EjecucionPreMenFec", fechaDesde, fechaHasta, idGruPre, idPre, idMoneda]);
        openPageViewerPopup(url, "EjecucionPreMenFec");
    };
    function botonImprimirEvaluacionSaldoPorGrupo_Click(s, e) {
        var anio = parseInt(cbAnio_SalGru.GetValue());
        var mesEva = cbMesEva_SalGru.GetValue().toString();
        var mesRea = cbMesRea_SalGru.GetValue().toString();
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ImprimirEvaluacionSaldoGrupo", anio, mesEva, mesRea]);
        openPageViewerPopup(url, "ImprimirEvaluacionSaldoGrupo");
    };

    function botonSalirResumenPorSubdirEvaReajuste_Click(s, e) {
        popReporteDireccion.Hide();
    };
    /********************************************************************/
    //Requerimiento Recurso Humano
    

    //********************************************************************

    function cbMesEvaReaEva_SelectedIndexChanged(s, e) {
        var mesEva = parseInt(cbMesEvaReaEva.GetValue());
        if (mesEva == 12) {
            cbMesEvaReaRea.SetValue(12);
        }
        else
            cbMesEvaReaRea.SetValue(mesEva + 1);
    };

    function cbMesEvaCal_SelectedIndexChanged(s, e) {
        var mesEva = parseInt(cbMesEvaCal.GetValue());
        if(mesEva == 12)
        {
            cbMesReaCal.SetValue(12);
        }
        else
            cbMesReaCal.SetValue(mesEva+1);
    };

    function cbMesEvaSub_SelectedIndexChanged(s, e) {
        var mesEva = parseInt(cbMesEvaSub.GetValue());
        if(mesEva == 12)
        {
            cbMesReaSub.SetValue(12);
        }
        else
            cbMesReaSub.SetValue(mesEva + 1);
    };

    function cbMesEva_SalGru_SelectedIndexChanged(s, e) {
        var mesEva = parseInt(cbMesEva_SalGru.GetValue());
        if (mesEva == 12) {
            cbMesRea_SalGru.SetValue(12);
        }
        else
            cbMesRea_SalGru.SetValue(mesEva + 1);
    };

    function cbMesEvaCon_SelectedIndexChanged(s, e) {
        var mesEva = parseInt(cbMesEvaCon.GetValue());
        if(mesEva == 12)
        {
            cbMesReaCon.SetValue(12);
        }
        else
            cbMesReaCon.SetValue(mesEva + 1);
    };


    /**********************************************/

    function botonImprimirPacGeneral_Click(s, e) {

        var id = traerIDPacSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            openReport("PacGeneral", id, 0);
        }

    };
    function botonImprimirPacGeneralDireccion_Click(s, e) {
        var id = traerIDPacSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            openReport("PacGeneralDireccion", id, 0);
        }
    };
    function botonImprimirPacDireccion_Click(s, e) {
        
        popReporteDireccion.SetHeaderText("Reporte por Dirección");
        showClearedPopup(popReporteDireccion);
        popReporteDireccion.PerformCallback("0");
    };
    function botonImprimirReportePacDireccion_Click(s, e) {
        var id = traerIDPacSeleccionada();
        var codReporte = cbReporte.GetValue().toString();
        var idDireccion = cbDir.GetValue().toString();
        var idFueFin = cbFueFin.GetValue().toString();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            openReport("PacDireccion", id, codReporte, idDireccion, idFueFin);
        }

    };

    function botonImprimirDireccion_Click(s, e) {
        popReporteDireccion.SetHeaderText("Reporte por Dirección");
        showClearedPopup(popReporteDireccion);
        popReporteDireccion.PerformCallback("0");
    };
    
    
    function botonExportarExcelPac_Click(s, e) {
        var id = traerIDPacSeleccionada();
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var boton = document.getElementById('<%=btnExportarExcel.ClientID%>');
            boton.click();
        }
    };
    function botonExportarExcelEvaluacion_Click(s, e) {
        var boton = document.getElementById('<%=btnExportarExcel.ClientID%>');
        if(boton!=null)
            boton.click();
    };

    /*Gasto Recurrente*/
    function botonImprimirGasRecGeneral_Click(s, e) {
        var id = traerIDGasRecSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            openReport("GasRecGeneral", id, 0);
        }
    };
    function botonImprimirReporteGasRecDireccion_Click(s, e) {
        var id = traerIDGasRecSeleccionada();
        var idDireccion = cbDir.GetValue().toString();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            openReport("GasRecDireccion", id, idDireccion);
        }
    };
    /*Certificacion */
    function botonImprimirCertificacion_Click(s, e) {
        var id = traerIDCertificacionSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            openReport("CertificacionPresupuestal", id, 0);
        }
    };

    function botonImprimirReporte_Click(s, e) {

        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            e.processOnServer = false;
            return;
        }

        var id = cbDireccionReporte.GetValue().toString();//Falta la dirección
        var idSubdireccion = cbSubdireccionReporte.GetValue() != null ? cbSubdireccionReporte.GetValue().toString() : '0';//Falta la Subdirección
        
        var tipo = cbTipo.GetValue().toString();//Falta la dirección
        var anio = cbAnioPeriodo.GetValue().toString();
        var idMoneda = cbMonedaReporte.GetValue().toString();

        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ReqBieSerDireccion", id, idSubdireccion, tipo, anio, idMoneda]);
        openPageViewerPopup(url, "ReqBieSerDireccion");
    };
    function botonImprimirReporteRR_Click(s, e) {
        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            e.processOnServer = false;
            return;
        }

        var anio = cbAnioPeriodo.GetValue().toString();
        var idDireccion = cbDireccionReporte.GetValue().toString();//Falta la dirección
        var idSubdireccion = cbSubdireccionReporte.GetValue().toString();//Falta la dirección
        
        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ReqRecHum", anio, idDireccion, idSubdireccion]);
        openPageViewerPopup(url, "ReqRecHum");
    };
    function botonImprimirReporteRRImp_Click(s, e) {
        //console.log('Validacion :', ASPxClientEdit.ValidateGroup('Validation'));

        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            e.processOnServer = false;
            return;
        }

        var anio = cbAnioPeriodoImp.GetValue().toString();
        var idMoneda = cbMonedaReporteImp.GetValue().toString();
        var idDireccion = cbDireccionReporteImp.GetValue().toString();//Falta la dirección
        var idSubdireccion = cbSubdireccionReporteImp.GetValue() != null ? cbSubdireccionReporteImp.GetValue().toString() : '0';

        console.log('idMoneda :', idMoneda);
        console.log('idDireccion :', idDireccion);
        console.log('idSubdireccion :', idSubdireccion);
        

        var url = "../VistaDocumento.aspx?ReportArgs=" + serializeArgs(["ReqRecHumImp", anio, idMoneda, idDireccion, idSubdireccion]);
        openPageViewerPopup(url, "ReqRecHumImp");
    };

    function botonDetalleRequerimientoGeneral_Click(s, e) {
        var id = traerIDRequerimientoSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else
        {
            var url = "./frmRequerimientoBienServicio.aspx?idReq=" + id;
            $(location).attr('href', url);
        }
    };
    //Requerimiento Recuro Humano
    function botonDetalleRequerimientoRH_Click(s, e) {
        var id = traerIDRequerimientoRHSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./frmRequerimientoRecursoHumano.aspx?idReqRecHum=" + id;
            $(location).attr('href', url);
        }
    };

    function botonImprimirRequerimientoRH_Click(s, e) {
        var id = traerIDRequerimientoRHSeleccionada();
        if (!id) {
            alert("Debe seleccionar al menos un registro");
            e.processOnServer = false;
        }
        else {
            openReport_("ReqRecHum", id);
        }

    };

    function botonImpReqRHDirArea_Click(s, e) {
        popReporteDireccion.SetHeaderText("Reporte por Subirección");
        showClearedPopup(popReporteDireccion);
        popReporteDireccion.PerformCallback("0");
    };
    function botonImpReqRHDirImp_Click(s, e) {
        popReporteDireccionImp.SetHeaderText("Reporte por Dirección, Subdirección, importes");
        showClearedPopup(popReporteDireccionImp);
        popReporteDireccionImp.PerformCallback("0");
    };
    
    //
    function botonDetalleReajusteGeneral_Click(s, e) {
        var id = traerIDReajusteSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./frmReajusteMensualPresupuesto.aspx?id=" + id;
            $(location).attr('href', url);
        }
    };

    function botonDetallePresupuestoAnual_Click(s, e) {
        var id = traerIDPresupuestoAnualSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./frmPresupuestoAnual.aspx?id=" + id;
            $(location).attr('href', url);
        }
    };

    function botonDetalleEvaluacionMensual_Click(s, e) {
        var id = traerIDEvaluacionSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./frmEvaluacionMensualPresupuesto.aspx?id=" + id;
            $(location).attr('href', url);
        }
    };

    function botonDetallePac_Click(s, e) {
        var id = traerIDPacSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./ListaPacDetalles.aspx?idPac=" + id;
            $(location).attr('href', url);
        }
    };

    function botonDetalleGastoRecurrente_Click(s, e) {
        var id = traerIDGasRecSeleccionada();

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./ListaGastoRecurrenteDetalles.aspx?idGasRec=" + id;
            $(location).attr('href', url);
        }
    };

    function botonDetalleCertificacion_Click(s, e) {
        var id = traerIDPacSeleccionada();
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./ListaCertificacionDetalles.aspx?idCerMas=" + id;
            $(location).attr('href', url);
        }
    };
    function botonDetallePresupuestoMensual_Click(s, e) {
        var id = traerIDSubPresupuestoSeleccionada();
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var url = "./ListaPresupuestoMensualDetalles.aspx?idSubPre=" + id;
            $(location).attr('href', url);
        }
    };

    function botonGuardarRequerimientoGeneral_Click(s, e) {
        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            e.processOnServer = false;
            return;
        }
        var commandName = popRequerimiento.cpOpcion;

        var idArea = cbArea.GetValue().toString();
        var idMoneda = cbMoneda.GetValue().toString();
        var descripcion = txtDescripcion.GetValue().toString();
        var anio = seAnio.GetNumber().toString();
        var arg = serializeArgs([commandName, popRequerimiento.cpID, idArea, idMoneda, descripcion, anio]);
        
        GuardarFormularioAyuda(popRequerimiento, arg, cpPrincipal);
    };

    function botonCancelarRequerimientoGeneral_Click(s, e) {
        popRequerimiento.Hide();
    };

    function popRequerimiento_EndCallback(s, e) {
        //popRequerimiento.Hide();
        s.SetHeaderText(s.cpNombre);
        cbDireccion.Focus();
    };

    //Detalle Requerimiento
    var keyReqDet;
    function grvReqDet_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyReqDet = s.GetRowKey(e.visibleIndex);
        }
    }


    function traerIDRequerimientoDetSeleccionada() {
        if (keyReqDet)
            return keyReqDet;
        return null;
    };
    //Detalle Requerimiento Mensual
    var keyReqMenDet;
    //grvReqMenDet
    function grvReqMenDet_OnGridSelectionChanged(s, e) {
        if (e.isSelected) {
            keyReqMenDet = s.GetRowKey(e.visibleIndex);
        }
    }


    function traerIDRequerimientoMensualDetalleSeleccionada() {
        if (keyReqMenDet)
            return keyReqMenDet;
        return null;
    };

    function botonNuevoRequerimientoDet_Click(s, e) {
        popReqDet.SetHeaderText("Nuevo Detalle de Requerimiento");
        showClearedPopup(popReqDet);
        popReqDet.PerformCallback("Nuevo|0");
    };
    function botonNuevoRequerimientoMensualDetalle_Click(s, e) {
        //alert(cpPrincipal.cpEstadoReqMen);
        if (cpPrincipal.cpEstadoReqMen == "10" || cpPrincipal.cpEstadoReqMen == "59") {
            alert("Error: no es posisble agregar detalles, requerimiento ya fue procesado");
            return;
        }
        popReqDet.SetHeaderText("Nuevo Detalle de Requerimiento");
        showClearedPopup(popReqDet);
        popReqDet.PerformCallback("Nuevo|0");
    };
    

    function botonEditarRequerimientoDet_Click(s, e) { // TODO
        popReqDet.SetHeaderText("Editar Detalle de Requerimiento");
        var id = traerIDRequerimientoDetSeleccionada();
        showClearedPopup(popReqDet);
        popReqDet.PerformCallback("Editar|" + id);
    };
    function botonEditarRequerimientoMensualDetalle_Click(s, e) { // TODO
        var id = traerIDRequerimientoMensualDetalleSeleccionada();
        if (id == null) {
            alert("Seleccione un detalle válido");
            return;
        }
        showClearedPopup(popReqDet);
        
        if (cpPrincipal.cpEstadoReqMen == "10" || cpPrincipal.cpEstadoReqMen == "59") {
            popReqDet.SetHeaderText("Detalle de Requerimiento");
            btnGrabar.SetEnabled(false);

            popReqDet.PerformCallback("Mostrar|" + id);
        }
        else {
            popReqDet.SetHeaderText("Editar Detalle de Requerimiento");
            popReqDet.PerformCallback("Editar|" + id);
        }
    };
    function GetIdProducto() {
        return hdfValores.Get("idProducto");
    }
    function SetIdProducto(valor) {
        return hdfValores.Set("idProducto", valor);
    }

    function botonAnularRequerimientoDet_Click(s, e) {
        var id = traerIDRequerimientoDetSeleccionada();
        if (confirm("¿Desea anular el requerimiento?"))
            cpPrincipal.PerformCallback(serializeArgs(["Anular", id]));
    };
    function botonAnularRequerimientoMensualDetalle_Click(s, e) {
        if (cpPrincipal.cpEstadoReqMen == "10" || cpPrincipal.cpEstadoReqMen == "59") {
            alert("Error: no es posisble anular detalle, requerimiento ya fue procesado");
            return false;
        }
        var id = traerIDRequerimientoMensualDetalleSeleccionada();
        if (confirm("¿Desea anular el requerimiento?"))
            cpPrincipal.PerformCallback(serializeArgs(["Anular", id]));
    };

    function botonSalirRequerimientoDet_Click(s, e) {
        var id = getUrlParameter('idReq');
        var url = "./ListaRequerimientoBienServicio.aspx";
        $(location).attr('href', url);
    }
    function botonSalirRequerimientoMensualDet_Click(s, e) {
        //var id = getUrlParameter('idReq');
        var url = "./ListaRequerimientoMensualBienServicio.aspx";
        $(location).attr('href', url);
    }
    //Requerimiento RRHH
    function botonNuevoRequerimientoDetRH_Click(s, e) {
        popPuestoReq.SetHeaderText("Nuevo Personal");
        showClearedPopup(popPuestoReq);
        popPuestoReq.PerformCallback("Nuevo|0");
        txtPersonal.Focus();
    };

    function botonEditarRequerimientoDetRH_Click(s, e) { 
        popPuestoReq.SetHeaderText("Editar Personal");
        var id = traerIDRequerimientoDetSeleccionada();
        showClearedPopup(popPuestoReq);
        popPuestoReq.PerformCallback("Editar|" + id);
    };
    
    function botonAnularRequerimientoDetRH_Click(s, e) {
        var id = traerIDRequerimientoDetSeleccionada();
        if (confirm("¿Desea anular el personal?"))
            cpPrincipal.PerformCallback(serializeArgs(["Anular", id]));
    };

    function botonSalirRequerimientoDetRH_Click(s, e) {
        var id = getUrlParameter('idReqRecHum');
        var url = "./ListaRequerimientoRecursoHumano.aspx?idReqRecHum=" + id;
        $(location).attr('href', url);
    }

    //Producto
    function botonAyudaRequerimientoDet_Click(s, e) {
        verProducto(s.GetMainElement(), '0');
    };

    var idPro;
    function verProducto(elemento, _idPro) {
        capProducto.SetContentHtml("");
        popAyudaProducto.ShowAtElement(elemento);
        idPro = _idPro;
    }
    function popAyudaProducto_Shown(s, e) {
        capProducto.PerformCallback(idPro);
    }

    function grvProducto_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'Descripcion', BuscaNombreProducto);
        s.GetRowValues(e.visibleIndex, 'idProducto', BuscaCodigoProducto);
        popAyudaProducto.Hide();
    }
    function grvDetalleMes_BachEditEndEditing(s, e) {
        setTimeout(function () {
            if (s.batchEditApi.HasChanges()) {
                actualiza = true;
                s.UpdateEdit();
            }
        }, 200);
    }
    function grvDetalleMes_EndCallback(s, e) {
        if (grvDetalleMes.cpSubtotal) {
            seSubtotal.SetText(grvDetalleMes.cpSubtotal);
        }
    }

    function grvReqDet_BachEditEndEditing(s, e) {
        setTimeout(function () {
            if (s.batchEditApi.HasChanges()) {
                actualiza = true;
                s.UpdateEdit();
            }
        }, 200);
    }
    

    function grvReqMenDet_BachEditEndEditing(s, e) {
        setTimeout(function () {
            if (s.batchEditApi.HasChanges()) {
                actualiza = true;
                s.UpdateEdit();
            }
        }, 200);
    }
    function grvReqMenDet_EndCallback(s, e) {
        if (grvReqMenDet.cpSubtotal) {
            seSubtotal.SetText(grvReqMenDet.cpSubtotal);
            ASPxlblSubTotal.SetText(grvReqMenDet.cpSubtotal);
        }
    }

    function BuscaCodigoProducto(valor) {
        hdfValores.Set('idProducto', valor);
        clbUnidad.PerformCallback(valor);
    }
    function BuscaNombreProducto(valor) {
        txtDescripcion.SetText(valor);
    }
    
    function clbUnidad_CallbackComplete(s, e) {
       cbUnidad.SetValue(e.result);
    };
    function chkConPartida_CheckedChanged(s, e) {
        txtDescripcion.SetValue('');
      
        if (chkConPartida.GetValue()) {
            btnSelecProducto.SetEnabled(false);
            btnSelecProducto.SetValue('');
            
            btnSelecPartida.SetEnabled(true);
            btnSelecPartida.SetValue('');

            frmDetalle.GetItemByName('bliPartida').SetVisible(true);
            frmDetalle.GetItemByName('bliProducto').SetVisible(false);

            btnSelecPartida.Focus();
        }
        else {
            btnSelecPartida.SetValue('');
            btnSelecPartida.SetEnabled(false);

            btnSelecProducto.SetEnabled(true);
            btnSelecProducto.SetValue('');

            frmDetalle.GetItemByName('bliPartida').SetVisible(false);
            frmDetalle.GetItemByName('bliProducto').SetVisible(true);

            btnSelecProducto.Focus();
        }
    };
    function chkConPartidaReqMen_CheckedChanged(s, e) {
        txtDescripcion.SetValue('');
        lblCuenta.SetValue('[Cuenta]');

        if (chkConPartida.GetValue()) {
            btnSelecProducto.SetEnabled(false);
            btnSelecProducto.SetValue('');

            btnSelecPartida.SetEnabled(true);
            btnSelecPartida.SetValue('');

            frmDetalle.GetItemByName('bliPartida').SetVisible(true);
            frmDetalle.GetItemByName('bliProducto').SetVisible(false);

            btnSelecPartida.Focus();
        }
        else {
            btnSelecPartida.SetValue('');
            btnSelecPartida.SetEnabled(false);

            btnSelecProducto.SetEnabled(true);
            btnSelecProducto.SetValue('');

            frmDetalle.GetItemByName('bliPartida').SetVisible(false);
            frmDetalle.GetItemByName('bliProducto').SetVisible(true);

            btnSelecProducto.Focus();
        }
    };

    //precio
    function botonAyudaPrecio_Click(s, e) {
        verPrecio(s.GetMainElement(), '0');
    };
    var precio;
    function verPrecio(elemento, _precio) {
        capPrecio.SetContentHtml("");
        popAyudaPrecio.ShowAtElement(elemento);
        precio = _precio;
    }
    function popAyudaPrecio_Shown(s, e) {
        var parametro = hdfValores.Get("idProducto") + "|" + cbCuenta.GetValue().toString() + "|" + hdfValores.Get("idReq");
        popAyudaPrecio.PerformCallback(parametro);
    }
    //seleccion precio
    function grvPrecio_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'precio', BuscaPrecio);
        popAyudaPrecio.Hide();
    }
    function BuscaPrecio(valor) {
        sePrecio.SetText(valor);
    }
    //Partida Precio
    function botonAyudaPartidaPrecio_Click(s, e) {
        hdfValores.Set('datoDescripcionPartida', '');
        
        verPartidaPrecio(s.GetMainElement(), '0');
    };
    function verPartidaPrecio(elemento, _precio) {
        capPartidaPrecio.SetContentHtml("");
        popAyudaPartidaPrecio.ShowAtElement(elemento);
        precio = _precio;
    }
    function popAyudaPartidaPrecio_Shown(s, e) {
        var parametro = cbTipo.GetValue().toString();
        hdfValores.Set('tipo', cbTipo.GetValue().toString());
        popAyudaPartidaPrecio.PerformCallback(parametro);
    }
    function popAyudaPartidaPrecioReqMen_Shown(s, e) {
        popAyudaPartidaPrecio.PerformCallback();
    }
    //seleccion Partida, Unidad, Precio y cuenta
    function grvPartidaPrecio_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'idParPre;descripcion;idUnidad;precio;idCueCon;numCuenta', OnGetRowValuesPartidaPreReqDetAnual);
        popAyudaPartidaPrecio.Hide();
    }
    function grvPartidaPrecioReqDet_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'idParPre;descripcion;idUnidad;precio;idCueCon;numCuenta', OnGetRowValuesPartidaPreReqDet);
        popAyudaPartidaPrecio.Hide();
    }
    function OnGetRowValuesPartidaPreReqDetAnual(values) {
        hdfValores.Set('idParPre', values[0]);
        popReqDet.cpIdParPre = values[0];
        

        btnSelecPartida.SetText(values[1]);
        txtDescripcion.SetText(values[1]);


        cbUnidad.SetValue(values[2]);

        sePrecio.SetValue(values[3]);
        if (grvDetalleMes.cpSubtotal) {
            grvDetalleMes.PerformCallback(sePrecio.GetValue().toString());
        }

        hdfValores.Set('idCueCon', values[4]);
        popReqDet.cpIdCueCon = values[4];

        lblCuenta.SetValue(values[5]);
    }
    function OnGetRowValuesPartidaPreReqDet(values) {
        hdfValores.Set('idParPre', values[0]);
        popReqDet.cpIdParPre = values[0];

        btnSelecPartida.SetText(values[1]);
        txtDescripcion.SetText(values[1]);
        cbUnidad.SetValue(values[2]);
        sePrecio.SetValue(values[3]);
        hdfValores.Set('idCueCon', values[4]);
        popReqDet.cpIdCueCon = values[4];

        lblCuenta.SetValue(values[5]);

        SubTotal_SeSubtotal();
    }
    
    //Producto Precio
    function botonAyudaProductoPrecio_Click(s, e) {
        hdfValores.Set('datoDescripcion', '');
        verProductoPrecio(s.GetMainElement(), '0');
    };
    function verProductoPrecio(elemento, _precio) {
        capProductoPrecio.SetContentHtml("");
        popAyudaProductoPrecio.ShowAtElement(elemento);
        precio = _precio;
    }
    function popAyudaProductoPrecio_Shown(s, e) {
        popAyudaProductoPrecio.PerformCallback();
    }
    
    function txtBuscarProducto_onTextChanged(s, e) {
        setTimeout(function () {
            if (txtBuscarProducto.GetValue().toString().length > 3) {
                var parametro = txtBuscarProducto.GetValue().toString();
                hdfValores.Set('datoDescripcion', parametro);
                grvProductoPrecio.PerformCallback(parametro);
            }
            
        }, 100);
    }
    function txtBuscarPartida_onTextChanged(s, e) {
        setTimeout(function () {
            if (txtBuscarPartida.GetValue().toString().length > 3) {
                var parametro = txtBuscarPartida.GetValue().toString();
                hdfValores.Set('datoDescripcionPartida', parametro);
                grvPartidaPrecio.PerformCallback(parametro);
            }

        }, 100);
    }

    function sePrecio_KeyPress(s, e) {
        setTimeout(function () {
            if (grvDetalleMes.cpSubtotal) {
                
                grvDetalleMes.PerformCallback();
            }

        }, 100);
    }
    function sePrecio_NumberChanged(s, e) {
        setTimeout(function () {
            if (grvDetalleMes.cpSubtotal) {

                grvDetalleMes.PerformCallback(sePrecio.GetValue().toString());
            }

        }, 100);
    }
    function SubTotal_SeSubtotal() {
        let precio = sePrecio.GetValue();
        let cantidad = seCantidad.GetValue();
        seSubtotal.SetValue((precio.toFixed(2) * cantidad.toFixed(2)).toFixed(2));
    }
    function sePrecioReqDet_KeyPress(s, e) {
        setTimeout(function () {
            SubTotal_SeSubtotal();
        }, 100);
    }
    function sePrecioReqDet_NumberChanged(s, e) {
        setTimeout(function () {
            SubTotal_SeSubtotal();
        }, 100);
    }
    function seCantidadReqMen_KeyPress(s, e) {
        setTimeout(function () {
            SubTotal_SeSubtotal();
        }, 100);
    }
    function seCantidadReqMen_NumberChanged(s, e) {
        setTimeout(function () {
            SubTotal_SeSubtotal();
        }, 100);
    }
   
    //seleccion Producto, Unidad, Precio y cuenta
    function grvProductoPrecio_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'idProducto;descripcion;idUnidad;precio;idCueCon;numCuenta', OnGetRowValuesProductoReqDetAnual);
        popAyudaProductoPrecio.Hide();
    }
    function grvProductoPrecioReqDet_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'idProducto;descripcion;idUnidad;precio;idCueCon;numCuenta', OnGetRowValuesProductoReqDet);
        popAyudaProductoPrecio.Hide();
    }
    function OnGetRowValuesProductoReqDet(values) {
        hdfValores.Set('idProducto', values[0]);
        popReqDet.cpIdProducto = values[0];
        
        btnSelecProducto.SetText(values[1]);
        txtDescripcion.SetText(values[1]);
        cbUnidad.SetValue(values[2]);
        sePrecio.SetValue(values[3]);
        hdfValores.Set('idCueCon', values[4]);
        popReqDet.cpIdCueCon = values[4];

        lblCuenta.SetValue(values[5]);

        SubTotal_SeSubtotal();
    }
    function OnGetRowValuesProductoReqDetAnual(values) {
        hdfValores.Set('idProducto', values[0]);
        popReqDet.cpIdProducto = values[0];

        btnSelecProducto.SetText(values[1]);
        txtDescripcion.SetText(values[1]);

        cbUnidad.SetValue(values[2]);

        sePrecio.SetValue(values[3]);
        if (grvDetalleMes.cpSubtotal) {
            grvDetalleMes.PerformCallback(sePrecio.GetValue().toString());
        }

        hdfValores.Set('idCueCon', values[4]);
        popReqDet.cpIdCueCon = values[4];
        lblCuenta.SetValue(values[5]);
    }
    function BuscarIdParPre(valor) {
        hdfValores.Set('idParPre', valor);
        popReqDet.cpIdParPre = valor;
    }
    function BuscarIdProducto(valor) {
        hdfValores.Set('idProducto', valor);
        popReqDet.cpIdProducto = valor;
    }
    function BuscarDesPartida(valor) {
        btnSelecPartida.SetText(valor);
        txtDescripcion.SetText(valor);
    }
    function BuscarDesProducto(valor) {
        txtDescripcion.SetText(valor);
        btnSelecProducto.SetText(valor);
    }
    function BuscarUnidad(valor) {
        cbUnidad.SetValue(valor);
    }
    function BuscarPrecio(valor) {
        //hdfValores.Set('precioActual', valor);
        //alert(valor);
        sePrecio.SetValue(valor);
        if (grvDetalleMes.cpSubtotal) {
            grvDetalleMes.PerformCallback(sePrecio.GetValue().toString());
        }
    }
    function BuscarPrecioReqDet(valor) {
        sePrecio.SetValue(valor);
    }
    function BuscarCuenta(valor) {
        hdfValores.Set('idCueCon', valor);
        cbCuenta.SetValue(valor);
    }
    function BuscarCuentaReqDet(valor) {
        hdfValores.Set('idCueCon', valor);
    }
    function BuscarNumCuenta(valor) {
        lblCuenta.SetValue(valor);
    }

    //Seleccion Personal
    function botonAyudaPersonal_Click(s, e) {
        verPersonal(s.GetMainElement(), '0');
    };
    var idTrabajador;
    function verPersonal(elemento, _idTrabajador) {
        capPersonal.SetContentHtml("");
        popAyudaPersonal.ShowAtElement(elemento);
        idTrabajador = _idTrabajador;
    }
    function popAyudaPersonal_Shown(s, e) {
        var parametro = hdfValores.Get("idTrabajador") + "|" + hdfValores.Get("idReqRecHum");
        popAyudaPersonal.PerformCallback(parametro);
    }
    function grvPersonal_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'trabajador', BuscaPersonal);
        s.GetRowValues(e.visibleIndex, 'idTrabajador', BuscaidTrabjador);
        popAyudaPersonal.Hide();
    }
    function BuscaPersonal(valor) {
        txtPersonal.SetText(valor);
    }
    function BuscaidTrabjador(valor) {
        hdfValores.Set('idTrabajador', valor);
    }
    //Lista Cargo
    function botonAyudaCargo_Click(s, e) {
        verCargo(s.GetMainElement(), '0');
    };
    var idCargo;
    function verCargo(elemento, _idCargo) {
        capCargo.SetContentHtml("");
        popAyudaCargo.ShowAtElement(elemento);
        idCargo = _idCargo;
    }
    function popAyudaCargo_Shown(s, e) {
        popAyudaCargo.PerformCallback();
    }
    //seleccion cargo y datos
    function grvCargo_RowDblClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'idCargo;desCargo;grado;remuneracion;idMoneda', OnGetRowValuesDatosCargo);
        popAyudaCargo.Hide();
    }
    function OnGetRowValuesDatosCargo(values) {
        hdfValores.Set('idCargo', values[0]);

        txtCargo.SetText(values[1]);
        seGrado.SetValue(values[2]);
        seRemuneracion.SetValue(values[3]);
        cbMoneda.SetValue(values[4]);
    }

    /////////////////////////////////////////////////
    function botonGuardarRequerimientoDet_Click(s, e) {
        
        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            alert('Faltan datos');
            e.processOnServer = false;
            return;
        }

        var commandName = popReqDet.cpID ? "Editar" : "Nuevo";

        var tipo = cbTipo.GetValue().toString();

        //var idCuenta = hdfValores.Get("idCueCon").toString();
        var descripcion = txtDescripcion.GetValue().toString();
        var idUnidad = cbUnidad.GetValue().toString();
        var precio = sePrecio.GetNumber().toString();
        var justificacion = txtJustificacion.GetValue().toString();

        var idParPre = popReqDet.cpIdParPre;
        var idCuenta = popReqDet.cpIdCueCon;  //popReqDet.cpID ? hdfValores.Get("idCueCon") : popReqDet.cpIdCueCon;
        var idProducto = popReqDet.cpIdProducto;

        var arg = serializeArgs([commandName, popReqDet.cpID, tipo, idParPre, idCuenta, descripcion, idUnidad, precio, justificacion, idProducto]);

        GuardarFormularioAyuda(popReqDet, arg, cpPrincipal);
        popReqDet.Hide();
    };
    function botonGuardarRequerimientoMenDet_Click(s, e) {

        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            alert('Valida');
            e.processOnServer = false;
            return;
        } 

        var commandName = popReqDet.cpID ? "Editar" : "Nuevo";
       
        var idParPre = popReqDet.cpID ? popReqDet.cpIdParPre : hdfValores.Get("idParPre");
        var idProducto = popReqDet.cpID ? popReqDet.cpIdProducto : hdfValores.Get("idProducto");
        var idCuenta = popReqDet.cpID ? popReqDet.cpIdCueCon : hdfValores.Get("idCueCon");

        var descripcion = txtDescripcion.GetValue().toString();
        var idUnidad = cbUnidad.GetValue().toString();
        var precio = sePrecio.GetNumber().toString();
        var cantidad = seCantidad.GetNumber().toString();
        var justificacion = txtJustificacion.GetValue().toString();
        
        var arg = serializeArgs([commandName, popReqDet.cpID, idParPre, idProducto, idCuenta, descripcion, idUnidad, precio, cantidad, justificacion]);
        
        GuardarFormularioAyuda(popReqDet, arg, cpPrincipal);
        popReqDet.Hide();
    };

    //grabar puesto requerimiento
    function botonGuardarRequerimientoDetRH_Click(s, e) {

        if (!ASPxClientEdit.ValidateGroup('Validation')) {
            alert('Validacion');
            e.processOnServer = false;
            return;
        }  

        var commandName = popPuestoReq.cpID ? "Editar" : "Nuevo";

        var idTrabajador = hdfValores.Get("idTrabajador");
        var esVacante = ceEsVacante.GetValue().toString();

        var cantVacante = '0';
        if (seCantVacante.GetValue() != null) cantVacante = seCantVacante.GetNumber().toString();

        var idSede = cbSede.GetValue().toString();
        var idRegLab = cbRegLab.GetValue().toString();
        var idCatLab = cbCatLab.GetValue().toString();
        var idConLab = cbConLab.GetValue().toString();

        var idCargo = hdfValores.Get("idCargo");
        var grado = seGrado.GetNumber().toString();
        var remuneracion = seRemuneracion.GetNumber().toString();
        var idTipMon = cbMoneda.GetValue().toString();

        var idCargoPropuesto = '0';
        
        var gradoPropuesto = '0';

        var remPropuesta = '0';

        var esRemDiaria = ceEsRemDiaria.GetValue().toString();

        var justificacion = '';
        if (txtJustificacion.GetValue() != null) justificacion = txtJustificacion.GetValue().toString();

        var observacion = '';
        if (txtObservacion.GetValue() != null) observacion = txtObservacion.GetValue().toString();

        var idFueFin = cbFueFin.GetValue().toString();

        var mesInicio = parseInt(defechaInicio.GetDate().getMonth()) + 1;
        var mesTermino = parseInt(defechaTermino.GetDate().getMonth()) + 1;

        var fechaInicio = defechaInicio.GetDate().getDate() + '/' + mesInicio + '/' + defechaInicio.GetDate().getFullYear();
        var fechaTermino = defechaTermino.GetDate().getDate() + '/' + mesTermino + '/' + defechaTermino.GetDate().getFullYear();
        
        var arg = serializeArgs([commandName, popPuestoReq.cpID, hdfValores.Get("idReqRecHum"), idTrabajador, esVacante, cantVacante, idSede, idRegLab, idCatLab, idConLab, idCargo, grado, remuneracion, idTipMon, idCargoPropuesto, gradoPropuesto, remPropuesta, esRemDiaria, justificacion, idFueFin, observacion, fechaInicio, fechaTermino]);
        
        GuardarFormularioAyuda(popPuestoReq, arg, cpPrincipal);
    };

    function botonCancelarRequerimientoDet_Click(s, e) {
        e.processOnServer = false;
        popReqDet.Hide();
    };

    function botonCancelarRequerimientoDetRH_Click(s, e) {
        e.processOnServer = false;
        popPuestoReq.Hide();
    };

    function botonSalirReporte_Click(s, e) {
        e.processOnServer = false;
        popReporteDireccion.Hide();
    };

    function popReqDet_EndCallback(s, e) {
        s.SetHeaderText(s.cpNombre);
        cbCuenta.Focus();
    };
    function popPuestoReq_EndCallback(s, e) {
        s.SetHeaderText(s.cpNombre);
        txtPersonal.Focus();
    };

    function grvRequerimiento_ToolbarItemClick(s, e) {
        var nombre = e.item.name;

        switch (nombre) {
            case "Detalle":
                agregarUnidadMedida(0, s);
                break;
            case "Exportar":
                agregarUnidadMedida(0, s);
                break;
            case "ConsolidadoDir":
                agregarUnidadMedida(0, s);
                break;
            case "ResumenSub":
                agregarUnidadMedida(0, s);
                break;
            case "CalendarioPres":
                agregarUnidadMedida(0, s);
                break;
        }
    };

    //var isPostbackInitiated = false;
    function botonExportarReajuste_Click(s, e) {
        var id = traerIDReajusteSeleccionada();
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var boton = document.getElementById('<%=btnImprimir.ClientID%>');
            boton.click();
        }
    }

    //var isPostbackInitiated = false;
    function botonExportarPresupuestoAnual_Click(s, e) {

        var id = hdfValores.Get("idProAnu");
        hdfValores.Set('idMonedaExpProAnu', cbMonedaExpProAnu.GetValue().toString());
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var boton = document.getElementById('<%=btnExpProAnu.ClientID%>');
            boton.click();
        }
    }
    function botonExportarPresupuestoAnualMasivo_Click(s, e) {

        hdfValores.Set('idMonedaPopExpProAnuMas', cbMonedaPopExpProAnuMas.GetValue().toString());
        var boton = document.getElementById('<%=btnExpProAnuMas.ClientID%>');
        boton.click();
    }

    function botonExportarPresupuestoMensual_Click(s, e) {
        var id = hdfValores.Get("idSubPre");

        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            var boton = document.getElementById('<%=btnExpPreMen.ClientID%>');
            boton.click();
        }
    }

    function botonExportarEvaluacionMensual_Click(s, e) {
        
        var id = hdfValores.Get("id");
        
        if (!id) {
            alert("Debe seleccionar al menos un item");
            e.processOnServer = false;
        }
        else {
            //alert("Click");
            var boton = document.getElementById('<%=btnExpEva.ClientID%>');
            boton.click();
        }
    }
    function botonExportarEvaluacionReajusteMensual_Click(s, e) {
        hdfValores.Set('anioEvaRea', cbAnioEvaRea.GetValue().toString());
        hdfValores.Set('mesEvaReaEva', cbMesEvaReaEva.GetValue().toString());
        hdfValores.Set('mesEvaReaRea', cbMesEvaReaRea.GetValue().toString());
        var boton = document.getElementById('<%=btnPopExpEvaRea.ClientID%>');
        boton.click();
    }
    

    function grvDetalle_BachEditEndEditing(s, e) {
        setTimeout(function () {
            if (s.batchEditApi.HasChanges()) {
                actualiza = true;
                s.UpdateEdit();
            }
        }, 200);
    }

    function initMoreButton(s, e) {
        $(s.GetMainElement()).find(".more-info").click(function () {
            var $btn = $(this);
            callback1.PerformCallback($btn.attr("data-key"), function (res) {
                $btn.replaceWith(res);
            });
        });
    }

    function onInit(s, e) {
        AdjustSize();
    }
    function onEndCallback(s, e) {
        AdjustSize();
    }
    function AdjustSize() {
        var height = Math.max(0, document.documentElement.clientHeight);
        grid.SetHeight(height);
    }  


    /***************************************************************************/
    return {


        // #region Inicio - Requerimiento Mensual de Bienes y Servicios - Cabecera

        GrvRequerimientoMensual_OnGridSelectionChanged: grvRequerimientoMensual_OnGridSelectionChanged,

        BotonNuevoRequerimientoMensualGeneral_Click: botonNuevoRequerimientoMensualGeneral_Click,
        BotonEditarRequerimientoMensualGeneral_Click: botonEditarRequerimientoMensualGeneral_Click,
        BotonClonarRequerimientoMensualGeneral_Click: botonClonarRequerimientoMensualGeneral_Click,
        BotonAnularRequerimientoMensualGeneral_Click: botonAnularRequerimientoMensualGeneral_Click,
        BotonDetalleRequerimientoMensualGeneral_Click: botonDetalleRequerimientoMensualGeneral_Click,
        BotonRequerimientoMensualSeguimiento_Click: botonRequerimientoMensualSeguimiento_Click,
        BotonAprobarRequerimientoMensualGeneral_Click: botonAprobarRequerimientoMensualGeneral_Click,
        BotonVolverEstadoRequerimientoMensualGeneral_Click: botonVolverEstadoRequerimientoMensualGeneral_Click,
        BotonImprimirRequerimientoMensualGeneral_Click: botonImprimirRequerimientoMensualGeneral_Click,
        //BotonImprimirMensualDireccion_Click: botonImprimirMensualDireccion_Click,
        //BotonImprimirMensualReporte_Click: botonImprimirMensualReporte_Click,


        CbAnioListado_SelectedIndexChanged: cbAnioListado_SelectedIndexChanged,
        CbMesListado_SelectedIndexChanged: cbMesListado_SelectedIndexChanged,

        BotonGuardarRequerimientoMensualGeneral_Click: botonGuardarRequerimientoMensualGeneral_Click,
        BotonCancelarRequerimientoMensualGeneral_Click: botonCancelarRequerimientoMensualGeneral_Click,

        CbTipoRequerimiento_SelectedIndexChanged: cbTipoRequerimiento_SelectedIndexChanged,
        CbMesRegReqMensual_SelectedIndexChanged: cbMesRegReqMensual_SelectedIndexChanged,
        SeAnio_NumberChanged: seAnio_NumberChanged,
        CbDireccionReqMensual_SelectedIndexChanged: cbDireccionReqMensual_SelectedIndexChanged,
        CbSubdireccionReqMensual_EndCallback: cbSubdireccionReqMensual_EndCallback,
        CbSubdireccionReqMensual_SelectedIndexChanged: cbSubdireccionReqMensual_SelectedIndexChanged,
        CbAreaReqMensual_SelectedIndexChanged: cbAreaReqMensual_SelectedIndexChanged,
        CbAreaReqMensual_EndCallback: cbAreaReqMensual_EndCallback,


        CbDireccionReporte_SelectedIndexChanged: cbDireccionReporte_SelectedIndexChanged,
        CbSubdireccionReporte_EndCallback: cbSubdireccionReporte_EndCallback,
        CbDireccionReporteRRHHImp_SelectedIndexChanged: cbDireccionReporteRRHHImp_SelectedIndexChanged,
        CbSubdireccionReporteImp_EndCallback: cbSubdireccionReporteImp_EndCallback,

        BotonImprimirReporteMensual_Click: botonImprimirReporteMensual_Click,
        BotonMigraRequerimiento_Click: botonMigraRequerimiento_Click,
        BotonSalirReporteMensual_Click: botonSalirReporteMensual_Click,

        // #endregion





        //Lista y requerimiento general
        BotonNuevoRequerimientoGeneral_Click: botonNuevoRequerimientoGeneral_Click,
        BotonEditarRequerimientoGeneral_Click: botonEditarRequerimientoGeneral_Click,
        BotonClonarRequerimientoGeneral_Click: botonClonarRequerimientoGeneral_Click,
        BotonEditarRequerimientoRRHH_Click: botonEditarRequerimientoRRHH_Click,
        BotonAnularRequerimientoGeneral_Click: botonAnularRequerimientoGeneral_Click,
        BotonAnularRequerimientoRRHH_Click: botonAnularRequerimientoRRHH_Click,
        BotonDetalleRequerimientoGeneral_Click: botonDetalleRequerimientoGeneral_Click,
        BotonDetalleRequerimientoRH_Click: botonDetalleRequerimientoRH_Click,
        BotonDetallePac_Click: botonDetallePac_Click,
        BotonDetalleGastoRecurrente_Click: botonDetalleGastoRecurrente_Click,
        BotonDetalleCertificacion_Click: botonDetalleCertificacion_Click,
        BotonDetallePresupuestoMensual_Click: botonDetallePresupuestoMensual_Click,
        BotonImprimirRequerimientoGeneral_Click: botonImprimirRequerimientoGeneral_Click,
        BotonImprimirRequerimientoDetMen_Click: botonImprimirRequerimientoDetMen_Click,
        BotonImprimirRequerimientoRH_Click: botonImprimirRequerimientoRH_Click,
        BotonImprimirPacGeneral_Click: botonImprimirPacGeneral_Click,
        BotonImprimirPacGeneralDireccion_Click: botonImprimirPacGeneralDireccion_Click,
        BotonImprimirPacDireccion_Click: botonImprimirPacDireccion_Click,
        BotonImprimirReportePacDireccion_Click: botonImprimirReportePacDireccion_Click,
        BotonExportarExcelPac_Click: botonExportarExcelPac_Click,
        BotonExportarExcelEvaluacion_Click: botonExportarExcelEvaluacion_Click,
        BotonImprimirGasRecGeneral_Click: botonImprimirGasRecGeneral_Click,
        BotonImprimirReporteGasRecDireccion_Click: botonImprimirReporteGasRecDireccion_Click,
        BotonImprimirCertificacion_Click: botonImprimirCertificacion_Click,
        BotonImpReqRHDirArea_Click: botonImpReqRHDirArea_Click,
        BotonImpReqRHDirImp_Click: botonImpReqRHDirImp_Click,
        


        BotonGuardarRequerimientoGeneral_Click: botonGuardarRequerimientoGeneral_Click,
        BotonCancelarRequerimientoGeneral_Click: botonCancelarRequerimientoGeneral_Click,
        PopRequerimiento_EndCallback: popRequerimiento_EndCallback,

        CbDireccion_SelectedIndexChanged: cbDireccion_SelectedIndexChanged,
        //CbDireccionReporte_SelectedIndexChanged: cbDireccionReporte_SelectedIndexChanged,
        CbSubdireccion_EndCallback: cbSubdireccion_EndCallback,
        //CbSubdireccionReporte_EndCallback: cbSubdireccionReporte_EndCallback,
        CbPresupuesto_EndCallback: cbPresupuesto_EndCallback,
        CbSubPresupuesto_EndCallback: cbSubPresupuesto_EndCallback,


        CbSubdireccion_SelectedIndexChanged:cbSubdireccion_SelectedIndexChanged,
        CbArea_EndCallback: cbArea_EndCallback,

        //Detalle Requerimiento
        BotonNuevoRequerimientoDet_Click: botonNuevoRequerimientoDet_Click,
        BotonNuevoRequerimientoMensualDetalle_Click: botonNuevoRequerimientoMensualDetalle_Click,
        BotonEditarRequerimientoDet_Click: botonEditarRequerimientoDet_Click,
        BotonEditarRequerimientoMensualDetalle_Click: botonEditarRequerimientoMensualDetalle_Click,
        BotonAnularRequerimientoDet_Click: botonAnularRequerimientoDet_Click,
        BotonAnularRequerimientoMensualDetalle_Click: botonAnularRequerimientoMensualDetalle_Click,
        BotonSalirRequerimientoDet_Click: botonSalirRequerimientoDet_Click,
        BotonSalirRequerimientoMensualDet_Click: botonSalirRequerimientoMensualDet_Click,

        //Detalle Requerimiento recurso humano
        BotonNuevoRequerimientoDetRH_Click: botonNuevoRequerimientoDetRH_Click,
        BotonEditarRequerimientoDetRH_Click: botonEditarRequerimientoDetRH_Click,
        BotonAnularRequerimientoDetRH_Click: botonAnularRequerimientoDetRH_Click,
        BotonSalirRequerimientoDetRH_Click: botonSalirRequerimientoDetRH_Click,

        BotonGuardarRequerimientoDet_Click: botonGuardarRequerimientoDet_Click,
        BotonGuardarRequerimientoMenDet_Click: botonGuardarRequerimientoMenDet_Click,
        BotonGuardarRequerimientoDetRH_Click: botonGuardarRequerimientoDetRH_Click,
        BotonCancelarRequerimientoDet_Click: botonCancelarRequerimientoDet_Click,
        BotonCancelarRequerimientoDetRH_Click: botonCancelarRequerimientoDetRH_Click,
        PopReqDet_EndCallback: popReqDet_EndCallback,
        PopPuestoReq_EndCallback: popPuestoReq_EndCallback,
        

        BotonAyudaRequerimientoDet_Click: botonAyudaRequerimientoDet_Click,
        BotonAyudaPrecio_Click: botonAyudaPrecio_Click,
        BotonAyudaProductoPrecio_Click: botonAyudaProductoPrecio_Click,
        BotonAyudaPartidaPrecio_Click: botonAyudaPartidaPrecio_Click,
        BotonAyudaPersonal_Click: botonAyudaPersonal_Click,
        BotonAyudaCargo_Click: botonAyudaCargo_Click,
        GrvProducto_RowDblClick: grvProducto_RowDblClick,
        GrvPrecio_RowDblClick: grvPrecio_RowDblClick,
        GrvPersonal_RowDblClick: grvPersonal_RowDblClick,
        GrvCargo_RowDblClick: grvCargo_RowDblClick,
        GrvProductoPrecio_RowDblClick: grvProductoPrecio_RowDblClick,
        GrvProductoPrecioReqDet_RowDblClick: grvProductoPrecioReqDet_RowDblClick,
        GrvPartidaPrecio_RowDblClick: grvPartidaPrecio_RowDblClick,
        GrvPartidaPrecioReqDet_RowDblClick: grvPartidaPrecioReqDet_RowDblClick,
        GrvReqDet_BachEditEndEditing: grvReqDet_BachEditEndEditing,
        GrvDetalleMes_BachEditEndEditing: grvDetalleMes_BachEditEndEditing,
        GrvDetalleMes_EndCallback: grvDetalleMes_EndCallback,
        GrvReqMenDet_BachEditEndEditing: grvReqMenDet_BachEditEndEditing,
        GrvReqMenDet_EndCallback: grvReqMenDet_EndCallback,

        PopAyudaProducto_Shown: popAyudaProducto_Shown,
        PopAyudaPrecio_Shown: popAyudaPrecio_Shown,
        PopAyudaProductoPrecio_Shown: popAyudaProductoPrecio_Shown,
        PopAyudaPartidaPrecio_Shown: popAyudaPartidaPrecio_Shown,
        PopAyudaPartidaPrecioReqMen_Shown: popAyudaPartidaPrecioReqMen_Shown,
        PopAyudaPersonal_Shown: popAyudaPersonal_Shown,
        PopAyudaCargo_Shown: popAyudaCargo_Shown,
        CbTipo_SelectedIndexChanged: cbTipo_SelectedIndexChanged,
        ClbUnidad_CallbackComplete: clbUnidad_CallbackComplete,
        CbCuenta_SelectedIndexChanged: cbCuenta_SelectedIndexChanged,
        CbPartida_SelectedIndexChanged: cbPartida_SelectedIndexChanged,
        CbPartida_EndCallback: cbPartida_EndCallback,
        CeEsVacante_CheckedChanged: ceEsVacante_CheckedChanged,
        ChkConPartida_CheckedChanged: chkConPartida_CheckedChanged,
        ChkConPartidaReqMen_CheckedChanged: chkConPartidaReqMen_CheckedChanged,
        TxtBuscarProducto_onTextChanged: txtBuscarProducto_onTextChanged,
        TxtBuscarPartida_onTextChanged: txtBuscarPartida_onTextChanged,
        SePrecio_KeyPress: sePrecio_KeyPress,
        SePrecioReqDet_KeyPress: sePrecioReqDet_KeyPress,
        SePrecio_NumberChanged: sePrecio_NumberChanged,
        SePrecioReqDet_NumberChanged: sePrecioReqDet_NumberChanged,
        SeCantidadReqMen_KeyPress: seCantidadReqMen_KeyPress,
        SeCantidadReqMen_NumberChanged: seCantidadReqMen_NumberChanged,

        CbAnio_SelectedIndexChanged: cbAnio_SelectedIndexChanged,
        CbAnioPreMen_SelectedIndexChanged: cbAnioPreMen_SelectedIndexChanged,
        CbAnioRRHH_SelectedIndexChanged: cbAnioRRHH_SelectedIndexChanged,
        CbAnioCertificacion_SelectedIndexChanged: cbAnioCertificacion_SelectedIndexChanged,
        CbGruPre_SelectedIndexChanged: cbGruPre_SelectedIndexChanged,
        CbPresupuesto_SelectedIndexChanged: cbPresupuesto_SelectedIndexChanged,
        CbSubPresupuesto_SelectedIndexChanged: cbSubPresupuesto_SelectedIndexChanged,

        CbGruPreEje_SelectedIndexChanged: cbGruPreEje_SelectedIndexChanged,
        CbPreEje_EndCallback: cbPreEje_EndCallback,
        CbPreEje_SelectedIndexChanged: cbPreEje_SelectedIndexChanged,
        CbSubPreEje_EndCallback: cbSubPreEje_EndCallback,

        CbGruPre_PreMenFec_SelectedIndexChanged: cbGruPre_PreMenFec_SelectedIndexChanged,
        CbPre_PreMenFec_EndCallback: cbPre_PreMenFec_EndCallback,

        BotonImprimirReporte_Click: botonImprimirReporte_Click,
        BotonImprimirReporteRR_Click: botonImprimirReporteRR_Click,
        BotonImprimirReporteRRImp_Click: botonImprimirReporteRRImp_Click,
        BotonSalirReporte_Click: botonSalirReporte_Click,
        BotonImprimirDireccion_Click: botonImprimirDireccion_Click,
        
        //CbDir_SelectedIndexChanged: cbDir_SelectedIndexChanged,

        //Reporte
        PageViewerPopup_Shown: pageViewerPopup_Shown,
        PageViewerPopup_CloseUp: pageViewerPopup_CloseUp,
        //General
        CpPrincipal_EndCallback: cpPrincipal_EndCallback,

        CbAnioEva_SelectedIndexChanged: cbAnioEva_SelectedIndexChanged,
        CbMesEva_SelectedIndexChanged: cbMesEva_SelectedIndexChanged,
        CbAnioPopExpProAnuMas_SelectedIndexChanged: cbAnioPopExpProAnuMas_SelectedIndexChanged,
        CbAnioRea_SelectedIndexChanged: cbAnioRea_SelectedIndexChanged,
        CbMesRea_SelectedIndexChanged: cbMesRea_SelectedIndexChanged,
        CbAnioAyudaPrecio_SelectedIndexChanged: cbAnioAyudaPrecio_SelectedIndexChanged,
        CbAnioEvaRea_SelectedIndexChanged: cbAnioEvaRea_SelectedIndexChanged,

        BotonConsolidadoPorDirecciones_Click: botonConsolidadoPorDirecciones_Click,
        BotonResumenPorSubdirecciones_Click: botonResumenPorSubdirecciones_Click,
        BotonCalendarioPresAnual_Click:botonCalendarioPresAnual_Click,
        BotonImprimirCalendarioPresAnual_Click: botonImprimirCalendarioPresAnual_Click,
        BotonImprimirResumenPorSubdirecciones_Click: botonImprimirResumenPorSubdirecciones_Click,
        BotonSalirReporteCalendarioPres_Click: botonSalirReporteCalendarioPres_Click,
        BotonSalirReporteResumenPorSubdirecciones_Click: botonSalirReporteResumenPorSubdirecciones_Click,

        //ToolBars Grids
        GrvRequerimiento_ToolbarItemClick: grvRequerimiento_ToolbarItemClick,

        //
        BotonImprimirEvaluacion_Click: botonImprimirEvaluacion_Click,
        BotonPopExpProAnu_Click: botonPopExpProAnu_Click,
        BotonPopImprimirEvaluacionMensual_Click: botonPopImprimirEvaluacionMensual_Click,
        BotonPopExportarPresupuestoMensualMoneda_Click: botonPopExportarPresupuestoMensualMoneda_Click,
        BotonPopExpProAnuMas_Click: botonPopExpProAnuMas_Click,
        BotonExportarEvaluacionMoneda_Click: botonExportarEvaluacionMoneda_Click,
        BotonExportarEvaluacionReajuste_Click: botonExportarEvaluacionReajuste_Click,
        BotonConsolidadoPorDireccionesEvaReajuste_Click: botonConsolidadoPorDireccionesEvaReajuste_Click,
        BotonResumenPorSubdireccionesEvaReajuste_Click: botonResumenPorSubdireccionesEvaReajuste_Click,
        BotonPopImprimirEjePreMen_Click: botonPopImprimirEjePreMen_Click,
        BotonPopImprimirEjePreMenFec_Click: botonPopImprimirEjePreMenFec_Click,
        BotonCalendarioPresAnualEvaReajuste_Click: botonCalendarioPresAnualEvaReajuste_Click,
        BotonPopImprimirSalGru_Click: botonPopImprimirSalGru_Click,
        BotonImprimirResumenPorSubdirEvaReajuste_Click: botonImprimirResumenPorSubdirEvaReajuste_Click,
        BotonImprimirEjecucionPreMen_Click: botonImprimirEjecucionPreMen_Click,
        BotonImprimirEjecucionPreMenFec_Click: botonImprimirEjecucionPreMenFec_Click,
        BotonSalirResumenPorSubdirEvaReajuste_Click: botonSalirResumenPorSubdirEvaReajuste_Click,
        BotonImprimirCalendarioEvaReajuste_Click: botonImprimirCalendarioEvaReajuste_Click,
        BotonSalirReporteCalendarioEvaReajuste_Click: botonSalirReporteCalendarioEvaReajuste_Click,
        BotonImprimirConsolidadoEvaReajuste_Click: botonImprimirConsolidadoEvaReajuste_Click,
        BotonSalirReporteConsolidadoEvaReajuste_Click: botonSalirReporteConsolidadoEvaReajuste_Click,
        BotonImprimirEvaluacionSaldoPorGrupo_Click: botonImprimirEvaluacionSaldoPorGrupo_Click,

        CbMesEvaCal_SelectedIndexChanged: cbMesEvaCal_SelectedIndexChanged,
        CbMesEvaSub_SelectedIndexChanged: cbMesEvaSub_SelectedIndexChanged,
        CbMesEvaCon_SelectedIndexChanged: cbMesEvaCon_SelectedIndexChanged,
        CbMesEvaReaEva_SelectedIndexChanged: cbMesEvaReaEva_SelectedIndexChanged,
        CbMesEva_SalGru_SelectedIndexChanged: cbMesEva_SalGru_SelectedIndexChanged,

        GrvRequerimiento_OnGridSelectionChanged: grvRequerimiento_OnGridSelectionChanged,
        GrvReqRecursosHumanos_OnGridSelectionChanged: grvReqRecursosHumanos_OnGridSelectionChanged,
        GrvReqDet_OnGridSelectionChanged: grvReqDet_OnGridSelectionChanged,
        GrvReqMenDet_OnGridSelectionChanged: grvReqMenDet_OnGridSelectionChanged,
        GrvReajuste_OnGridSelectionChanged: grvReajuste_OnGridSelectionChanged,
        BotonDetalleReajusteGeneral_Click: botonDetalleReajusteGeneral_Click,
        BotonExportarReajuste_Click: botonExportarReajuste_Click,
        BotonDetallePresupuestoAnual_Click: botonDetallePresupuestoAnual_Click,
        BotonDetalleEvaluacionMensual_Click: botonDetalleEvaluacionMensual_Click,
        BotonExportarPresupuestoAnual_Click: botonExportarPresupuestoAnual_Click,
        BotonExportarPresupuestoAnualMasivo_Click: botonExportarPresupuestoAnualMasivo_Click,
        BotonExportarPresupuestoMensual_Click: botonExportarPresupuestoMensual_Click,
        BotonExportarEvaluacionMensual_Click: botonExportarEvaluacionMensual_Click,
        BotonExportarEvaluacionReajusteMensual_Click: botonExportarEvaluacionReajusteMensual_Click,
        GrvSubPresupuesto_OnGridSelectionChanged: grvSubPresupuesto_OnGridSelectionChanged,
        GrvProgramacionAnual_OnGridSelectionChanged: grvProgramacionAnual_OnGridSelectionChanged,
        GrvEvaluacion_OnGridSelectionChanged: grvEvaluacion_OnGridSelectionChanged,
        GrvDetalle_BachEditEndEditing: grvDetalle_BachEditEndEditing,
        InitMoreButton: initMoreButton,
        OnEndCallback: onEndCallback,
        OnInit: onInit
    };

})();