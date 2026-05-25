
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

   

    $('#PresupuestoTabla').DataTable({
        paging: false,
        searching: false,
        info: false,
        scrollX: false,
        scrollCollapse: false,
        "language": {
            "emptyTable": ""
        }
    });

    $('#CartaTabla').DataTable({
        scrollCollapse: true,
        "language": {
            "emptyTable": ""
        },
        initComplete: function (settings, json) {
            setTimeout(function () { $("#CartaTabla").DataTable().draw(); }, 200); 
        }
    }).draw();
    $('#liquidezTable').DataTable({
        "language": {
            "emptyTable": ""
        }
    });
     $('#LotesTable').DataTable({
        scrollY: "450px",
        scrollCollapse: true,
        scrollX: true,
        sort: false,
       
    });
     $('#LotesTableValida').DataTable({
        scrollY: "450px",
        scrollCollapse: true,
        scrollX: true,
        sort: false,
        
    });
    var table = $('#tablaPricipalesCliente').DataTable();

    var data = table.rows().data();

    if (data.length > 0) {
        table.scrollY = "250px";
        table.language = {
            "emptyTable": ""
        };
       
    }
    else {
       
        table.language = {
            "emptyTable": ""
        };
    }

    var tablaCartaDeclaratoriaSolcitantes = $('#tablaCartaDeclaratoriaSolcitantes').DataTable();

    var data = tablaCartaDeclaratoriaSolcitantes.rows().data();

    if (data.length > 0) {
        tablaCartaDeclaratoriaSolcitantes.scrollY = "250px";
        tablaCartaDeclaratoriaSolcitantes.language = {
            "emptyTable": ""
        };

    }
    else {

        tablaCartaDeclaratoriaSolcitantes.language = {
            "emptyTable": ""
        };
    }

    $('#tablaPagos').DataTable({
        "language": {
            "emptyTable": ""
        }
    });

    $('#condicionesDeEntragaTable').DataTable({
        "language": {
            "emptyTable": ""
        }
    });
    $(function () {
        var diferencia = numeral($("#Diferencia").val()).value();
        if (diferencia > 0) {
            menssage("Requisición", "El valor aproximado fue modificado por la Secretaria de Hacienda")
        }
    });
    getDireccionPago();
    activarMejora();
    getDireccionPagoValida();
    mapsPropuestaTenica();
    mapsPropuestaTenicaValida();
    activarAplicaCapitalContable();
});

function agregarPropuestaTecnica(IdPropuestaTecnicaEconomica) {

}
function getDireccionPago() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntregaPago").val();
    var url_ = '/Requisiciones/getLugarEntrega_x_IdLugarEntrega/'
    $.ajax({
        data: { __RequestVerificationToken: token, IdLugarEntrega: IdLugarEntrega_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {

                //$("#Direccion").val(response.objeto.Direccion + ' ' + response.objeto.Colonia);
                if (response.objeto.LocalizacionGoogle != "" || response.objeto.LocalizacionGoogle != null) {
                    placeMarkerPorMapa(response.objeto.LocalizacionGoogle, "mapFirmaPago");
                }
            }
            else {

                menssage("Alta condiciones de entrega", "Error en el Guardado: " + response.mensaje)
            }

        }
    });
}
function getDireccionPagoValida() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntregaPago").val();
    var url_ = '/Requisiciones/getLugarEntrega_x_IdLugarEntrega/'
    $.ajax({
        data: { __RequestVerificationToken: token, IdLugarEntrega: IdLugarEntrega_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {

                //$("#Direccion").val(response.objeto.Direccion + ' ' + response.objeto.Colonia);
                if (response.objeto.LocalizacionGoogle != "" || response.objeto.LocalizacionGoogle != null) {
                    placeMarkerPorMapa(response.objeto.LocalizacionGoogle, "mapFirmaPagoValida");
                }
                //placeMarkerPorMapa(response.objeto.LocalizacionGoogle, "mapFirmaPagoValida");
            }
            else {

                menssage("Alta condiciones de entrega", "Error en el Guardado: " + response.mensaje)
            }

        }
    });
}
function validarFormulario() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    var form = $("#Formulario").val();
    form = form.replace("TabPadre", "");
    var validado = true;
    validado = $("#" + form + "Form").valid();

    if (validado) {
        switch (form) {
            case "div_Requisitos_Adicionales":
                saveManifiestoProveedorConfirm();
                break;
           
        }

    }
}

$(document).ready(function () {
    $('.nav li a').click(function (e) {
        var i = $(this).attr('id');
        $("#Formulario").val(i);
        switch (i) {
            case "div_lotesTabPadre":
                $("#btnEnviarDictamenTecnico").addClass("verSeccion");
                $("#btnGuardarValidacionesDictamenTecnico").addClass("verSeccion");
                $("#btnAceptarDictamenTecnico").addClass("verSeccion");
                $("#btnRechazarDictamenTecnico").addClass("verSeccion");
                break;
            case "div_Requisitos_AdicionalesTabPadre":
                $("#btnGuardarValidaciones").removeClass("verSeccion");
                $("#btnGEnviaPropuestaTecnica").addClass("verSeccion");
                $("#btnGEnviaPropuestaEconomica").addClass("verSeccion");
                $("#btnEnviarDictamenTecnico").addClass("verSeccion");
                $("#btnGuardarValidacionesDictamenTecnico").removeClass("verSeccion");
                $("#btnAceptarDictamenTecnico").addClass("verSeccion");
                $("#btnRechazarDictamenTecnico").addClass("verSeccion");
                break;
            case "div_Enviar_PropuestaTecnicaTabPadre":
                $("#btnGuardarValidaciones").addClass("verSeccion");
                $("#btnGEnviaPropuestaTecnica").removeClass("verSeccion");
                $("#btnGEnviaPropuestaEconomica").addClass("verSeccion");
                $("#btnEnviarDictamenTecnico").removeClass("verSeccion");
                $("#btnGuardarValidacionesDictamenTecnico").addClass("verSeccion");
                $("#btnAceptarDictamenTecnico").removeClass("verSeccion");
                $("#btnRechazarDictamenTecnico").removeClass("verSeccion");
                break;
            default:
                $("#btnGuardarValidaciones").addClass("verSeccion");
                $("#btnGEnviaPropuestaTecnica").addClass("verSeccion");
                $("#btnGEnviaPropuestaEconomica").addClass("verSeccion");
                $("#btnEnviarDictamenTecnico").addClass("verSeccion");
                $("#btnGuardarValidacionesDictamenTecnico").removeClass("verSeccion");
                $("#btnAceptarDictamenTecnico").addClass("verSeccion");
                $("#btnRechazarDictamenTecnico").addClass("verSeccion");
                break;
        }
    });
});



function getProducto_x_IdBienServicio(IdBienServicio_) {
    var token = $("[name='__RequestVerificationToken']").val();
    $.ajax({
        data: { IdBienServicio: IdBienServicio_, IdRequisicion: $("#IdRequisicion").val(), __RequestVerificationToken: token },
        url: '/Requisiciones/getProducto',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#Unidad").val(response.data.string3);
                $("#Caracteristica").val(response.data.string2);
                $("#Impuesto").val(response.data.string4);
                $("#TasaImpuesto").val(response.data.decimal2);
                var preciounitario = numeral(response.data.decimal1).format('0,0.00');
                $("#PrecioUnitarioListaSinImpuestoMensual").val(preciounitario);
                calcularValores()


            }
            else {
                $(".modal-title").html("Error en agregar bien");
                $("#titlePopUp").html(response.data);
                $("#Pop-Up").modal("show");

            }

        }
    });
}


function runScript(e) {
    calcularValores()
    return false;
}

function validarFormularioLote() {
    var validado = $("#div_LotesForm").valid();
    if (validado && validarValoresTotales()) {
        saveLote();
    }
}




function validarFormularioLoteEdit() {
    var validado = $("#div_LotesForm").valid();
    if (validado && validarValoresTotales()) {
        saveEditLote();
    }
}
function editarLote(IdPropuestaTecnicaEconomica, IdProveedorRqInvitacion) {
    

    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion= $("#IdRequisicion").val();
    $("#IdPropuestaTecnicaEconomica").val(IdPropuestaTecnicaEconomica)
    $("#IdProveedorRqInvitacion").val(IdProveedorRqInvitacion)
    
    $.ajax({
        data: { pIdProveedorRqInvitacion: IdProveedorRqInvitacion, pIdPropuestaTecnicaEconomica: IdPropuestaTecnicaEconomica, pIdRequisicion: IdRequisicion, __RequestVerificationToken: token},
        url: '/PropuestaTecnicaEconomica/getRequisicionLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response!="") {
                
                $("#CargarLotePropuestaTecnicaEconomica").html("");
                $("#CargarLotePropuestaTecnicaEconomica").html(response);
                $("#modal_nuevo_lote").modal("show");
                mesesActivos();
                calcularValores();
                activarMejora();
                validaLoteOfertado();
                validaDependenciaCumple();
            }
            else {
                $(".modal-title").html("Error cargar lote");
                $("#titlePopUp").html(response.data);
                $("#Pop-Up").modal("show");
            }

        }
    });


}

function activarMejora() {
    var mejora = $("#EstatusMejora");
    if (mejora.is(':checked')) {
        $("#Mejora").removeAttr("readonly");
        
        $("#EstatusMejora").val("1");
    }
    else {
        $("#Mejora").attr('readonly', 'readonly');
        
        $("#EstatusMejora").val("0");
    }
    
}

function validaLoteOfertado() {
    var mejora = $("#LoteOfertado");
    if (mejora.is(':checked')) {
        $("#LoteOfertado").val("1");
    }
    else {
        $("#LoteOfertado").val("0");
    }
}
function mesesActivos() {
    var de = $("#De").val();
    var al = $("#Al").val();
    var textDe = $("#De :selected").text();
    var textAl = $("#Al :selected").text();

    if (al == "") {
        return;
    }
    if (de == "") {
        return;
    }
    if ((al - de) < 0) {
        $("#De").val("")
        $("#Al").val("")



        $(".modal-title").html("Requisición Fecha inicio-fin");
        $("#titlePopUp").html("El mes Inio (" + textDe + ") es mayor al mes fin (" + textAl + ").");
        $("#Pop-Up").modal("show");
        return;
    }
    var total = al - de + 1;
    $("#Meses").val(total);
    calcularValores();

}
function calcularValores() {
    var cantidad = $("#Cantidad").val();
    if (cantidad != "") {
        var preciounitario = $("#PrecioUnitarioListaSinImpuestoMensual").val();
        preciounitario = numeral(preciounitario).value();
        var precioUnitarioListaSinImpuestoMensual = preciounitario;
        var tasaImpuesto = $("#TasaImpuesto").val();


        var periodo = $("#Meses").val();
        var importeConImpuesto = precioUnitarioListaSinImpuestoMensual * tasaImpuesto;
        var impuestoGenerado = importeConImpuesto * cantidad;
        var totalSinImpuesto = precioUnitarioListaSinImpuestoMensual * cantidad;
        var totalConImpuesto = totalSinImpuesto + impuestoGenerado;
        var totalPeriodo = totalConImpuesto * (periodo == 0 ? 1 : periodo);
        totalSinImpuesto = numeral(totalSinImpuesto).format('0,0.00');
        totalConImpuesto = numeral(totalConImpuesto).format('0,0.00');
        totalPeriodo = numeral(totalPeriodo).format('0,0.00');
        $("#ImporteSinImpuestoMensual").val(totalSinImpuesto)
        $("#ImporteConImpuestoMensual").val(totalConImpuesto)
        $("#ImporteTotalPeriodo").val(totalPeriodo);
        $("#importeConImpuesto").val(importeConImpuesto);

    }
    else {
        $("#ImporteSinImpuestoMensual").val(0.00)
        $("#ImporteConImpuestoMensual").val(0.00)
        $("#ImporteTotalPeriodo").val(0.00)
    }

}

function resetform() {

    $("#GuardarLote").css({ "display": "" });
    $("#ActualizarLote").css({ "display": "none" });
    $(".modal-title").html("Nuevo Lote");
    $("#modal_nuevo_lote").modal("hide");
    $("#div_LotesForm")[0].reset();
    $("#ResultadoBuscar").html('');
    $("#IdLote").val(0);
    $("#ImporteTotalConImpuestoDiv").load(" #ImporteTotalConImpuestoDiv");
    $("#navbarToggleExternalContent").load(" #navbarToggleExternalContent", function (data) {

        var idTab = $("#Formulario").val();
        if (idTab != "DatosGeneralesTabPadre") {
            $("#" + idTab).addClass('active')
            $("#DatosGeneralesTabPadre").removeClass('active')
        }

        $('.nav li a').click(function (e) {
            var i = $(this).attr('id');
            switch (i) {
                case "div_firmantesTabPadre":
                    $("#btnGuardarValidaciones").html("Enviar a revisión");
                    break;
                default:
                    $("#btnGuardarValidaciones").html("Guardar");
                    break;
            }
            $("#Formulario").val(i);
        });

    });

}




function menssage(title, cuerpo) {
    $(".modal-title").html(title);
    $("#titlePopUp").html(cuerpo);
    $("#Pop-Up").modal("show");
}

function saveEditLoteConfirm(IdEstatusEnvioPropuestaEconomica) {
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor 0."
    var PrecioUnitarioRefencia = $("#PrecioUnitarioRefencia").val();
    jQuery.validator.messages.max = jQuery.validator.format("Por favor, escribe un valor menor o igual " + PrecioUnitarioRefencia)
    jQuery.validator.messages.required = "Por favor, este valor es requerido."
    jQuery.validator.messages.number = "Por favor, ingresar un número valido."
    var validado = $("#div_LotesForm").valid();
    if (validado) {

        bootbox.confirm({
            title: "Confirmación",
            closeButton: false,
            message: "¿Confirma que desea editar lote?",
            size: "small",
            buttons: {
                confirm: {
                    label: 'ACEPTAR',
                    className: 'btn-secondary'
                },
                cancel: {
                    label: 'CANCELAR',
                    className: 'btn-secondary'
                }
            },
            callback: function (result) {
                if (result) {
                    switch (IdEstatusEnvioPropuestaEconomica) {
                        case 1:
                            savePropuestaTecnicaLote();
                            break;
                        case 2:
                            var a = parseFloat($("#ImporteSinImpuestoMensual").val());
                            if (a == 0.00) {
                                mensaje("Precio unitario de lista debe ser mayor que 0", "Aviso", "");
                            }
                            else {
                                saveEditLoteEconomica();
                            }
                            break;
                        case 4:
                        case 5:
                            saveEditLoteDictamenPropuestaTecnicaSolictante();
                            break;
                    }
                }

            }
        }).find('.modal-dialog').addClass("modal-dialog-centered");
    }
}
function savePropuestaTecnicaLote() {

    // Create FormData object  
    var fileData = new FormData();
    var IdMuestra = $("#IdMuestra").val();

    if (IdMuestra != 3) {
        var URLFileMuestraCatalogo = $("#URLFileMuestraCatalogo").get(0);
        var files = URLFileMuestraCatalogo.files;
        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append("URLFileMuestraCatalogo", files[i]);
        }
        fileData.append("URLFileMuestraCatalogo", $("#URLFileMuestraCatalogoLabel").val())
    }
    else {
        fileData.append("URLFileMuestraCatalogo", "")
    }

    var URLFileCertificacion = $("#URLFileCertificacion").get(0);
    files = URLFileCertificacion.files;

    // Looping over all files and add it to FormData object  
    for (var i = 0; i < files.length; i++) {
        fileData.append("URLFileCertificacion", files[i]);
    }
    var token = $("[name='__RequestVerificationToken']").val();

    fileData.append("IdPropuestaTecnicaEconomica", $("#IdPropuestaTecnicaEconomica").val())
    fileData.append("LoteOfertado", $("#LoteOfertado").val() == 1 ? true : false)
    fileData.append("Mejora", $("#Mejora").val())
    fileData.append("EstatusMejora", $("#EstatusMejora").val())
    fileData.append("__RequestVerificationToken", token)
    fileData.append("IdProveedorRqInvitacion", $("#IdProveedorRqInvitacion").val())
    fileData.append("IdRequisicion", $("#IdRequisicion").val())
    fileData.append("URLFileCertificacion", $("#URLFileCertificacionLabel").val())
   

    $.ajax({
        url: '/PropuestaTecnicaEconomica/savePropuestaTecnica/',
        type: "POST",
        processData: false,
        data: fileData,
        dataType: 'json',
        contentType: false,
        success: function (response) {
            if (response.success) {
                
                $('#LotesTable').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#LotesTable').dataTable().fnDestroy();
                $("#cargarLotesTable").load(" #cargarLotesTable", function () {
                    
                    $('#LotesTable').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    $("#modal_nuevo_lote").modal("hide");
                })

                $('#LotesTableValida').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#LotesTableValida').dataTable().fnDestroy();
                $("#cargarLotesTableValida").load(" #cargarLotesTableValida", function () {

                    $('#LotesTableValida').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                })
                mensaje("El registro se actualizó correctamente.", "Aviso", "");
            }
            else {
                mensaje("Error actualización: " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
    return false;
}
function mensaje(mensaje_,titulo, url_) {
    bootbox.alert({
        size: "small",
        title: "<div class='col-12 text-center'>" + titulo + "<div>" ,
        message: mensaje_,
        className: "modal-dialog-centered",
        callback: function () {
            if (url_ != "") {
                location.href = url_ 
            }
            
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered")
}

function aceptarCarta(IdProveedorCarta, IdProveedorRqInvitacion) {
    var mejora = $("#cd_" + IdProveedorCarta);
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: "¿Confirma que desea " + (!mejora.is(':checked')?"aceptar":"rechazar")+ " carta?",
        size: "small",
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                saveAceptarCarta(IdProveedorCarta, IdProveedorRqInvitacion)
            }
            else {
                
                if (!mejora.is(':checked')) {
                    mejora.prop('checked', false); 
                }
                else {
                    mejora.prop('checked', true); 
                }
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function saveAceptarCarta(IdProveedorCarta, IdProveedorRqInvitacion) {

    var mejora = $("#cd_" + IdProveedorCarta);
    var aceptar = false;
    if (!mejora.is(':checked')) {
        aceptar = true;
    }
    else {
        aceptar = false;
    }

    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("IdProveedorRqInvitacion", IdProveedorRqInvitacion)
    fileData.append("IdRequisicion", $("#IdRequisicion").val())
    fileData.append("__RequestVerificationToken", token)
    fileData.append("IdProveedorCarta", IdProveedorCarta)
    fileData.append("AceptacionCarta", aceptar)

    $.ajax({
        url: '/PropuestaTecnicaEconomica/saveAceptarCarta/', type: "POST", processData: false,
        data: fileData, dataType: 'json',
        contentType: false,
        success: function (response) {
            if (response.success) {
                mensaje("El registro se actualizó correctamente.", "Aviso", "");
                $('#CartaTabla').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#CartaTabla').dataTable().fnDestroy();
                $("#cargarTablaCarta").load(" #cargarTablaCarta", function () {

                    $('#CartaTabla').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    
                })
                $('#CartaTablaValida').dataTable({
                    "bDestroy": true
                }).fnDestroy();
                var nuevoCSS = { "width": '100%'};
                $('#CartaTablaValida').dataTable().fnDestroy();
                $("#cargarTablaCartaValida").append('');
                $("#cargarTablaCartaValida").load(" #cargarTablaCartaValida", function () {

                 
                    $('#CartaTablaValida').DataTable({
                        scrollY: "450px",
                        "language": {
                            "emptyTable": ""
                        },
                    initComplete: function (settings, json) {
                        setTimeout(function () { $("#CartaTablaValida").DataTable().draw(); }, 200);
                        }
                    }).draw();

                })


            }
            else {
                mensaje("Error aceptar carta: " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina aceptar carta: " + response.responseText, "Aviso", "");
        }

    });

}
function activarAplicaCapitalContable() {
    var mejora = $("#AplicaCapitalContable");
    if (mejora.is(':checked')) {
        $("#CapitalContable").removeAttr("readonly");
        $("#AplicaCapitalContable").val("1");
    }
    else {
        $("#CapitalContable").attr('readonly', 'readonly');
        $("#AplicaCapitalContable").val("0");
    }

}

function nuevoClienteProveedor(IdManifiestoProveedorCliente) {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    
    fileData.append("IdProveedorRqInvitacion", $("#IdProveedorRqInvitacion").val())
    fileData.append("IdManifiestoProveedor", $("#IdManifiestoProveedor").val())
    fileData.append("IdRequisicion", $("#IdRequisicion").val())
    fileData.append("__RequestVerificationToken", token)
    fileData.append("IdManifiestoProveedorCliente", IdManifiestoProveedorCliente)

    $.ajax({
        url: '/PropuestaTecnicaEconomica/getManifiestoProveedoresClientes/', type: "POST", processData: false,
        data: fileData, 
        contentType: false,
        success: function (response) {
            if (response != "") {
                $("#CargarDatosCliente").html("");
                $("#CargarDatosCliente").html(response);
                $("#modal_Nuevo_Cliente").modal("show");
            }
            else {
                mensaje("Error : " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}

function saveManifiestoProveedorConfirm() {
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: "¿Confirma que desea guardar requisitos adicionales?",
        size: "small",
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result)
                saveManifiestoProveedor();
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function saveManifiestoProveedor() {
  
    let data = $('#div_Requisitos_AdicionalesForm').serialize()

    $.post('/PropuestaTecnicaEconomica/saveManifiestoProveedor', data, "json")
        .done(function (result) {
            $("#cargarRequisitosAdicionales").load(" #cargarRequisitosAdicionales");
            $("#cargarBtnNuevo").load(" #cargarBtnNuevo");
            $("#cargarRequisitosAdicionalesValida").load(" #cargarRequisitosAdicionalesValida");
            
        });
}

function saveManifiestoProveedorCliente() {
    
        let data = $('#div_Requisitos_Adicionales_CLienteForm').serialize()

        $.post('/PropuestaTecnicaEconomica/saveManifiestoProveedorCliente', data, "json")
            .done(function (result) {
                $("#modal_Nuevo_Cliente").modal("hide");
                mensaje("El registro se actualizó correctamente.", "Aviso", "");
                $('#tablaPricipalesCliente').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaPricipalesCliente').dataTable().fnDestroy();
                $("#cargarTablaPricipalesCliente").load(" #cargarTablaPricipalesCliente", function () {

                    $('#tablaPricipalesCliente').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });

                })
                $('#tablaPricipalesClienteValida').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaPricipalesClienteValida').dataTable().fnDestroy();
                $("#cargarTablaPricipalesClienteValida").load(" #cargarTablaPricipalesClienteValida", function () {

                    $('#tablaPricipalesClienteValida').DataTable({

                        "language": {
                            "emptyTable": ""
                        }
                    });

                })

            });
    
}
function validarFormularioProveedorCLiente() {
    jQuery.validator.messages.required = 'Esta campo es obligatorio.';
    jQuery.validator.messages.number = 'Esta campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    var validado = true;
    validado = $("#div_Requisitos_Adicionales_CLienteForm").valid();
    
    if (validado && validatePhone("TelefonoCliente")) {
        bootbox.confirm({
            title: "Confirmación",
            closeButton: false,
            message: "¿Confirma que desea guardar cliente?",
            size: "small",
            buttons: {
                confirm: {
                    label: 'ACEPTAR',
                    className: 'btn-secondary'
                },
                cancel: {
                    label: 'CANCELAR',
                    className: 'btn-secondary'
                }
            },
            callback: function (result) {
                if (result)
                    saveManifiestoProveedorCliente();
            }
        }).find('.modal-dialog').addClass("modal-dialog-centered");
        

        }

}

function eliminarManifiestoProveedorClienteConfirm(IdManifiestoProveedorCliente) {
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: "¿Confirma que desea elimnar cliente?",
        size: "small",
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result)
                eliminarClienteProveedor(IdManifiestoProveedorCliente)
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function eliminarClienteProveedor(IdManifiestoProveedorCliente) {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();

    fileData.append("IdProveedorRqInvitacion", $("#IdProveedorRqInvitacion").val())
    fileData.append("IdManifiestoProveedor", $("#IdManifiestoProveedor").val())
    fileData.append("IdRequisicion", $("#IdRequisicion").val())
    fileData.append("__RequestVerificationToken", token)
    fileData.append("IdManifiestoProveedorCliente", IdManifiestoProveedorCliente)

    $.ajax({
        url: '/PropuestaTecnicaEconomica/deleteManifiestoProveedorCliente/', type: "POST", processData: false,
        data: fileData,
        contentType: false,
        success: function (response) {
            if (response != "") {
                mensaje("El registro se elimino correctamente ", "Aviso", "");
                $('#CartaTabla').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#CartaTabla').dataTable().fnDestroy();
                $("#cargarTablaPricipalesCliente").load(" #cargarTablaPricipalesCliente", function () {

                    $('#CartaTabla').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });

                })
                $('#tablaPricipalesClienteValida').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaPricipalesClienteValida').dataTable().fnDestroy();
                $("#cargarTablaPricipalesClienteValida").load(" #cargarTablaPricipalesClienteValida", function () {

                    $('#tablaPricipalesClienteValida').DataTable({

                        "language": {
                            "emptyTable": ""
                        }
                    });

                })
            }
            else {
                mensaje("Error : " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}

function aceptarManifiestoConfirm(IdManifiestoProveedorDeclaratoria) {
    var activo = $("#cm_" + IdManifiestoProveedorDeclaratoria);
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: "¿Confirma que desea " + (!activo.is(':checked') ? "aceptar":"rechazar")+" el manifiesto?",
        size: "small",
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                aceptarManifiesto(IdManifiestoProveedorDeclaratoria)
            }
            else {
                
                if (activo.is(':checked')) {
                    activo.prop('checked', false);
                }
                else {
                    activo.prop('checked', true);
                }
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}


function aceptarManifiesto(IdManifiestoProveedorDeclaratoria) {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    var activo = $("#cm_" + IdManifiestoProveedorDeclaratoria);
    var aceptar = false;
    if (!activo.is(':checked')) {
        aceptar = true;
    }
    else {
        aceptar = false;
    }

    fileData.append("IdProveedorRqInvitacion", $("#IdProveedorRqInvitacion").val())
    fileData.append("IdRequisicion", $("#IdRequisicion").val())
    fileData.append("__RequestVerificationToken", token)
    fileData.append("IdManifiestoProveedorDeclaratoria", IdManifiestoProveedorDeclaratoria)
    fileData.append("Aceptacion", aceptar)
    
    $.ajax({
        url: '/PropuestaTecnicaEconomica/saveAceptarManifiestoProveedoresDeclaratorias/', type: "POST", processData: false,
        data: fileData,
        contentType: false,
        success: function (response) {
            if (response != "") {
                mensaje("El registro se actualizó correctamente ", "Aviso", "");
                $('#tablaCartaDeclaratoriaSolcitantes').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaCartaDeclaratoriaSolcitantes').dataTable().fnDestroy();
                $("#CargarTablaCartaDeclaratoriaSolcitantes").load(" #CargarTablaCartaDeclaratoriaSolcitantes", function () {

                    $('#tablaCartaDeclaratoriaSolcitantes').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });

                })
                $('#tablaCartaDeclaratoriaSolcitantesValida').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaCartaDeclaratoriaSolcitantesValida').dataTable().fnDestroy();
                $("#CargarTablaCartaDeclaratoriaSolcitantesValida").load(" #CargarTablaCartaDeclaratoriaSolcitantesValida", function () {

                    $('#tablaCartaDeclaratoriaSolcitantesValida').DataTable({
                       
                        "language": {
                            "emptyTable": ""
                        }
                    });

                })
            }
            else {
                mensaje("Error : " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}

function validarEnviaPropuestaTecnica() {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("__RequestVerificationToken", token)

    $.ajax({
        url: '/PropuestaTecnicaEconomica/validarPropuestaTecnica/', type: "POST", processData: false,
        data: fileData,
        contentType: false,
        success: function (response) {
            if (response.success) {
                bootbox.confirm({
                    title: "Confirmación",
                    closeButton: false,
                    message: "¿Confirma que desea enviar propuesta técnica?",
                    size: "small",
                    buttons: {
                        confirm: {
                            label: 'ACEPTAR',
                            className: 'btn-secondary'
                        },
                        cancel: {
                            label: 'CANCELAR',
                            className: 'btn-secondary'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviaPropuestaTecnica, b: undefined })
                            //saveEnviaPropuestaTecnica();
                        }
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");
            }
            else {
                bootbox.confirm({
                    title: "Confirmación",
                    closeButton: false,
                    message: response.mensaje+ "<br> ¿Confirma que desea enviar propuesta técnica?",
                    size: "small",
                    buttons: {
                        confirm: {
                            label: 'ACEPTAR',
                            className: 'btn-secondary'
                        },
                        cancel: {
                            label: 'CANCELAR',
                            className: 'btn-secondary'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviaPropuestaTecnica, b: undefined })
                            //saveEnviaPropuestaTecnica();
                        }
                            
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}

function saveEnviaPropuestaTecnica() {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("__RequestVerificationToken", token)


    $.ajax({
        url: '/PropuestaTecnicaEconomica/savevalidarPropuestaTecnica/', type: "POST", processData: false,
        data: fileData,
        contentType: false,
        success: function (response) {
            if (response != "") {
                mensaje("El registro se actualizó correctamente ", "Aviso", "/ListadoRequisicionLicitacion/Index");
                //location.href = ;
            }
            else {
                mensaje("Error : " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}

function saveEditLoteEconomica() {

    var PrecioUnitarioListaSinImpuestoMensual = numeral($("#PrecioUnitarioListaSinImpuestoMensual").val()).value();
    var ImporteSinImpuestoMensual = numeral($("#ImporteSinImpuestoMensual").val()).value();
    var importeConImpuesto = numeral($("#importeConImpuesto").val()).value();
    var ImporteConImpuestoMensual = numeral($("#ImporteConImpuestoMensual").val()).value();
    var ImporteTotalPeriodo = numeral($("#ImporteTotalPeriodo").val()).value();
    var token = $("[name='__RequestVerificationToken']").val();
    var frecuencia = $("#Frecuencia").val();
    var pRequisicionLote = {
        IdRequisicion: $("#IdPropuestaTecnicaEconomica").val(),
        PrecioUnitario: PrecioUnitarioListaSinImpuestoMensual,
        Importe: ImporteSinImpuestoMensual,
        ImporteCImpuesto: importeConImpuesto,
        ImporteMesnsualCImpuesto: ImporteConImpuestoMensual,
        MesesServicio: $("#Meses").val(),
        Total: ImporteTotalPeriodo,
        Cantidad: $("#Cantidad").val(),
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pRequisicionLote,
        url: '/PropuestaTecnicaEconomica/saveEditLotePropuestaEconomica',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                mensaje("Se ofertó lote", "Aviso", "");
                $('#LotesTable').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#LotesTable').dataTable().fnDestroy();
                $("#cargarLotesTable").load(" #cargarLotesTable", function () {

                    $('#LotesTable').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    $("#modal_nuevo_lote").modal("hide");
                })
            }
            else {

            }

        }
    });
}

function validarEnviaPropuestaEconomica() {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("__RequestVerificationToken", token)

    $.ajax({
        url: '/PropuestaTecnicaEconomica/validarPropuestaEconomica/', type: "POST", processData: false,
        data: fileData,
        contentType: false,
        success: function (response) {
            if (response.success) {
                bootbox.confirm({
                    title: "Confirmación",
                    closeButton: false,
                    message: "¿Confirma que desea enviar propuesta económica?",
                    size: "small",
                    buttons: {
                        confirm: {
                            label: 'ACEPTAR',
                            className: 'btn-secondary'
                        },
                        cancel: {
                            label: 'CANCELAR',
                            className: 'btn-secondary'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviaPropuestaEconomica, b: undefined })
                            //saveEnviaPropuestaEconomica();
                        }
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");
            }
            else {
                mensaje("Error: <br>" + response.mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}

function saveEnviaPropuestaEconomica() {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("__RequestVerificationToken", token)


    $.ajax({
        url: '/PropuestaTecnicaEconomica/savePropuestaEconomica/', type: "POST", processData: false,
        data: fileData,
        contentType: false,
        success: function (response) {
            if (response != "") {
                mensaje("El registro se actualizó correctamente ", "Aviso", '/ListadoRequisicionLicitacion/Index');
                //location.href = '/ListadoRequisicionLicitacion/Index';
            }
            else {
                mensaje("Error : " + response.Mensaje, "Aviso", "");
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }

    });
}


//Autorizar revision revisor
function AutorizarPropTecEcoRevisor(tipoProp) {
    let idprovreqinv = $("#IdProveedorRqInvitacion").val().trim()
    bootbox.confirm({
        title: "Confirmación",
        message: "¿Desea guardar propuesta " + (tipoProp ==3? "técnica": "económica") + "?",
        callback: function (resp) {
            if (resp) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAutorizarPropTecEcoRevisor, b: { id: idprovreqinv, tipo: tipoProp } })

                //{ id: idprovreqinv, tipo: tipoProp }
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered")
}

function saveAutorizarPropTecEcoRevisor(data) {
    $.get('/PropuestaTecnicaEconomica/AutorizarRevisorPropuestaTecnicaEconomica/',
        data,
        "json")
        .done(function (data) {
            mensajeGenerico("Aviso", data, "1")
        })
        .fail(function (xhr, ErroTextStatus, status) {
            mensajeGenerico("Aviso", `${xhr} ${ErroTextStatus} ${status}`, "")
        })
}

function validaDependenciaCumple(name,componente) {
    //var input = $('input[name=DependenciaCumple
    if ($('input:radio[name=' + name + ']:checked').val() == "0") {
        $("#" + componente).prop('disabled', false);
        
    }
    else {
        $("#" + componente).prop('disabled', true);
        
    }

}
function guardarProveedoresRequisicionesInvitacion() {
    var token = $("[name='__RequestVerificationToken']").val();

    var data = {
        IdProveedorRqInvitacion: $("#IdProveedorRqInvitacion").val(),
        CartasDependenciaCumple: $('input:radio[name=CartasDependenciaCumple]:checked').val() == "0" ? false : true,
        CartaFundamento: $("#CartaFundamento").val(),
        CartaAdquisicionCumple: $('input:radio[name=CartaAdquisicionCumple]:checked').val() == "0" ? false : true,
        CartasAdqObservacion: $("#CartasAdqObservacion").val(),
        CondicionEntregaDependenciaCumple: $('input:radio[name=CondicionEntregaDependenciaCumple]:checked').val() == "0" ? false : true,
        CondicionEntregaFundamento: $("#CondicionEntregaFundamento").val(),
        CondicionEntregaAdquisicionCumple: $('input:radio[name=CondicionEntregaAdquisicionCumple]:checked').val() == "0" ? false : true,
        CondicionEntregaAdqObservacion: $("#CondicionEntregaAdqObservacion").val(),
        CondicionPagoDependenciaCumple: $('input:radio[name=CondicionPagoDependenciaCumple]:checked').val() == "0" ? false : true,
        CondicionPagoFundamento: $("#CondicionPagoFundamento").val(),
        CondicionPagoAdquisicionCumple: $('input:radio[name=CondicionPagoAdquisicionCumple]:checked').val() == "0" ? false : true,
        CondicionPagoAdqObservacion: $("#CondicionPagoAdqObservacion").val(),
        ManifiestoDependenciaCumple: $('input:radio[name=ManifiestoDependenciaCumple]:checked').val() == "0" ? false : true,
        ManifiestoFundamento: $("#ManifiestoFundamento").val(),
        ManifiestoAdquisicionCumple: $('input:radio[name=ManifiestoAdquisicionCumple]:checked').val() == "0" ? false : true,
        ManifiestoAdqObservacion: $("#ManifiestoAdqObservacion").val(),
        __RequestVerificationToken: token
    }
    var validido = true;
    var idperfil = $("#idPerfil").val();
    if (idperfil == "3") {
        switch ($("#Formulario").val()) {
            case "div_cartasTabPadre":
                validido = validarObjetoOfertado(data, "CartasDependenciaCumple", "CartaFundamento", "cartas");
                break;
            case "div_condiciones_entregaTabPadre":
                validido = validarObjetoOfertado(data, "CondicionEntregaDependenciaCumple", "CondicionEntregaFundamento", "condiciones de entrega");
                break;
            case "div_condiciones_pagoTabPadre":
                validido = validarObjetoOfertado(data, "CondicionPagoDependenciaCumple", "CondicionPagoFundamento", "condiciones de pago");
                break;
            case "div_Requisitos_AdicionalesTabPadre":
                validido = validarObjetoOfertado(data, "ManifiestoDependenciaCumple", "ManifiestoFundamento", "requisitos adicionales");
                break;
        }
    }
    if (idperfil == "7") {
        switch ($("#Formulario").val()) {
            case "div_cartasTabPadre":
                validido = validarObjetoAdquisicion(data, "CartaAdquisicionCumple", "CartasAdqObservacion", "cartas");
                break;
            case "div_condiciones_entregaTabPadre":
                validido = validarObjetoAdquisicion(data, "CondicionEntregaAdquisicionCumple", "CondicionEntregaAdqObservacion", "condiciones de entrega");
                break;
            case "div_condiciones_pagoTabPadre":
                validido = validarObjetoAdquisicion(data, "CondicionPagoAdquisicionCumple", "CondicionPagoAdqObservacion", "condiciones de pago");
                break;
            case "div_Requisitos_AdicionalesTabPadre":
                validido = validarObjetoAdquisicion(data, "ManifiestoAdquisicionCumple", "ManifiestoAdqObservacion", "requisitos adicionales");
                break;
        }
    }
    if (validido) {
        $.ajax({
            data: data,
            url: '/PropuestaTecnicaEconomica/saveDictamenPropuestaTecnicaSolictante/',
            type: 'post',
            beforeSend: function () {

            },
            success: function (response) {
                console.log(response);
                if (response.success) {
                    mensaje("El registro se actualizó correctamente ", "Aviso", "");
                    $("#CargarCartasPanel1").load(" #CargarCartasPanel1");
                    $("#CargarCartasPanel2").load(" #CargarCartasPanel2");
                    $("#CargaCondcionesPago1").load(" #CargaCondcionesPago1");
                    $("#CargaCondcionesPago2").load(" #CargaCondcionesPago2");
                    $("#CargaCondicionesEntregaPanel1").load(" #CargaCondicionesEntregaPanel1");
                    $("#CargaCondicionesEntregaPanel2").load(" #CargaCondicionesEntregaPanel2");
                    $("#CargarRequisitosAdicionalesPanel1").load(" #CargarRequisitosAdicionalesPanel1");
                    $("#CargarRequisitosAdicionalesPanel2").load(" #CargarRequisitosAdicionalesPanel2");
                }
                else {

                    mensaje("Error en el Guardado: " + response.mensaje, "Alta condiciones de entrega", "")
                }

            }
        });
    }
}
function validarObjetoOfertado(objeto,propiedad1, propiedad2,mensaje_) {
    var result = true;
    if (!objeto[propiedad1] && objeto[propiedad2]=="") {
       
        mensaje("Falta llenar Observaciones y fundamentación legal (" + mensaje_+")", "Aviso", "");
        result = false;
    }
    return result;
}
function validarObjetoAdquisicion(objeto, propiedad1, propiedad2, mensaje_) {
    var result = true;
    if (objeto[propiedad1] && objeto[propiedad2] == "") {
        result = false;
        mensaje("Falta llenar Observaciones adquisición (" + mensaje_+")", "Aviso", "");
    }
    return result;
}

function validarDatosDictamenTecnicoSolictante() {
    var idperfil = $("#idPerfil").val();
    var mensaje = "";
    if (idperfil == "3") {
        mensaje = "¿Cumple con lo ofertado (";
    }
    if (idperfil == "7") {
        mensaje = "¿Desea guardar registro rechazo si/no (";
    } 
        switch ($("#Formulario").val()) {
            case "div_cartasTabPadre":
                mensaje +="cartas";
                break;
            case "div_condiciones_entregaTabPadre":
                mensaje +="condiciones de entrega";
                break;
            case "div_condiciones_pagoTabPadre":
                mensaje +="condiciones de pago";
                break;
            case "div_Requisitos_AdicionalesTabPadre":
                mensaje +="requisitos adicionales";
                break;
        }
        mensaje +=")?";
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: mensaje ,
        size: "small",
        className: "modal-dialog-centered",
        centerVertical: true,
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                guardarProveedoresRequisicionesInvitacion();
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function validarDictamenTecnicoSolictante() {
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: "¿Desea guardar dictamen técnico?",
        size: "small",
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveDictamenTecnicoSolicitante, b: undefined })
                //saveDictamenTecnicoSolicitante();
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function saveEditLoteDictamenPropuestaTecnicaSolictante() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdPropuestaTecnicaEconomica_ = $("#IdPropuestaTecnicaEconomica").val();
    var DependenciaCumple_ = $('input:radio[name=DependenciaCumple]:checked').val() == "0" ? false : true;
    var FundamentoLegal_ = $("#FundamentoLegal").val();
    var AdquisicionCumple_ = $('input:radio[name=AdquisicionCumple]:checked').val() == "0" ? false : true;
    var AdquisicionObserva_ = $("#AdquisicionObserva").val();
    var data = {
        IdPropuestaTecnicaEconomica: IdPropuestaTecnicaEconomica_,
        DependenciaCumple: DependenciaCumple_,
        FundamentoLegal: FundamentoLegal_,
        AdquisicionCumple: AdquisicionCumple_,
        AdquisicionObserva: AdquisicionObserva_,
        __RequestVerificationToken: token
    }
    $.ajax({
        data: data,
        url: '/PropuestaTecnicaEconomica/saveEditLoteDictamenPropuestaTecnicaSolicitante/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                mensaje("El registro se actualizó correctamente ", "Aviso", "");
                $('#LotesTable').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#LotesTable').dataTable().fnDestroy();
                $("#cargarLotesTable").load(" #cargarLotesTable", function () {

                    $('#LotesTable').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    $("#modal_nuevo_lote").modal("hide");
                })

                $('#LotesTableValida').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#LotesTableValida').dataTable().fnDestroy();
                $("#cargarLotesTableValida").load(" #cargarLotesTableValida", function () {

                    $('#LotesTableValida').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                })
            }
            else {

                menssage("Alta condiciones de entrega", "Error en el Guardado: " + response.mensaje)
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }
    });
}


function saveDictamenTecnicoSolicitante() {
    //cargarBtnDictamenTecnicoSolicitante
    var token = $("[name='__RequestVerificationToken']").val();
    var data = {
        IdProveedorRqInvitacion: $("#IdProveedorRqInvitacion").val(),
        __RequestVerificationToken: token
    }
    $.ajax({
        data: data,
        url: '/PropuestaTecnicaEconomica/saveEnviarDictamenPropuestaTecnicaSolictante/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                mensaje("El registro se actualizó correctamente ", "Aviso", "/PropuestaTecnicaEconomica/Index/");
               
                //$("#cargarBtnDictamenTecnicoSolicitante").load(" #cargarBtnDictamenTecnicoSolicitante")
            }
            else {

                mensaje("Error en el Guardado: " + response.mensaje,"Aviso","")
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }
    });
}

function validaCumpleRevisor(name, componente) {
    //var input = $('input[name=DependenciaCumple
    if ($('input:radio[name=' + name + ']:checked').val() == "1") {
        $("#" + componente).prop('disabled', false);

    }
    else {
        $("#" + componente).prop('disabled', true);

    }

}
function validarAceptarDictamenTecnico(tipo) {
bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
    message: tipo == 1 ? "¿Confirma que desea guardar el registro?" :"¿Confirma que desea rechazar el registro?",
        size: "small",
        buttons: {
            confirm: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            },
            cancel: {
                label: 'CANCELAR',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAceptarDictamenTecnico, b: tipo })
                //saveAceptarDictamenTecnico(tipo);
            }
        }
}).find('.modal-dialog').addClass("modal-dialog-centered");
}

function saveAceptarDictamenTecnico(tipo) {
    var token = $("[name='__RequestVerificationToken']").val();
    var data = {
        IdProveedorRqInvitacion: $("#IdProveedorRqInvitacion").val(),
        IdEstatusEnvioPropuestaEconomica: tipo==0?7:6,
        IdEstatusEnvioPropuestaTecnica: tipo == 0 ? 7 : 6,
        __RequestVerificationToken: token
    }
    $.ajax({
        data: data,
        url: '/PropuestaTecnicaEconomica/saveAceptarDictamenTecnico/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                mensaje("El dictamen ha sido "+ (tipo == 0 ? "rechazado" :"autorizado"), "Aviso", "/PropuestaTecnicaEconomica/Index/");
                
            }
            else {

                mensaje("Error en el Guardado: " + response.mensaje, "Aviso", "")
            }

        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }
    });
}
function validatePhone(txtPhone) {
    var a = $("#" + txtPhone).val();
    var filter =/^[0-9]{3}-[0-9]{3}-[0-9]{4}/;
    if (filter.test(a)) {

        return true;
    }
    else {
        mensajeGenerico("Aviso", "Telefono erroneo", "");
        return false;
    }
}