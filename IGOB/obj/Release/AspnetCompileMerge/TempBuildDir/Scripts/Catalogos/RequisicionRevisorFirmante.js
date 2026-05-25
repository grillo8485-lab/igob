$(document).ready(function () {

    (activateButtons()) ? "" : $('#AutorizarRevision').prop('disabled', true);

    function changestatus(input, status) {
        switch (parseInt($("#IdEstatusRequisicion").val())) {
            case 80:
                switch ($(input).prop('name')) {
                    case "ValidaLotes":
                        $("#ObservacionLotes").prop("readonly", status)
                        break;
                    case "ValidaCondicionEntrega":
                        $("#OnservacionCondicionEntrega").prop("readonly", status)
                        break;
                    case "ValidaCondicionPago":
                        $("#ObservacionCondicionPago").prop("readonly", status)
                        break;
                    default:
                        break;
                }
            case 90:
                switch ($(input).prop('name')) {
                    case "ValidaLotes":
                        $("#ObservacionLotes").prop("readonly", status)
                        break;
                    case "ValidaCondicionEntrega":
                        $("#OnservacionCondicionEntrega").prop("readonly", status)
                        break;
                    case "ValidaCondicionPago":
                        $("#ObservacionCondicionPago").prop("readonly", status)
                        break;
                    case "ValidaDocumentosRevisor":
                        $("#ObservacionDoctosRevisor").prop("readonly", status)
                        break;
                    default:
                        break;
                }
                
                break;
        }  
    }
    function activateButtons() {
        let activo = true;
        $("input[type='radio']:checked").each(function () {
            ($(this).val() == "false") ? activo = false : "";
        });
        return activo;
    }
    function validateRadio() {
        let validate = false;
        switch (parseInt($("#IdEstatusRequisicion").val())) {
            case 80:
                ($("input[name='ValidaLotes']").is(':checked') && $("input[name='ValidaCondicionEntrega']").is(':checked') && $("input[name='ValidaCondicionPago']").is(':checked')) ? validate = true : validate = false;
                break;
            case 90:
                ($("input[name='ValidaLotes']").is(':checked') && $("input[name='ValidaCondicionEntrega']").is(':checked') && $("input[name='ValidaCondicionPago']").is(':checked') && $("input[name='ValidaDocumentosRevisor']").is(':checked')) ? validate = true : validate = false;
                break;
        }
        return validate;
    }
    function validaRechazo() {
        switch (parseInt($("#IdEstatusRequisicion").val())) {
            case 80:
                ($("input[name='ValidaLotes']:checked").val() == "true" && $("input[name='ValidaCondicionEntrega']:checked").val() == "true" && $("input[name='ValidaCondicionPago']:checked").val() == "true") ? $('#RechazarRevision').prop('disabled', true) : $('#RechazarRevision').prop('disabled', false);
                break;
            case 90:
                ($("input[name='ValidaLotes']:checked").val() == "true" && $("input[name='ValidaCondicionEntrega']:checked").val() == "true" && $("input[name='ValidaCondicionPago']:checked").val() == "true" && $("input[name='ValidaDocumentosRevisor']:checked").val() == "true") ? $('#RechazarRevision').prop('disabled', true) : $('#RechazarRevision').prop('disabled', false);
                break;
        }
    }
    function validaObservaciones() {
        let validarCampos = "";
        $("input[type='radio']:checked").each(function () {
            if ($(this).val() == "false") {
                switch (parseInt($("#IdEstatusRequisicion").val())) {
                    case 80:
                        switch ($(this).prop('name')) {
                            case "ValidaLotes":
                                ($.trim($("#ObservacionLotes").val()) == "") ? validarCampos += `Rellene: Observacion Lotes<br/>` : ""
                                break;
                            case "ValidaCondicionEntrega":
                                ($.trim($("#ObservacionConEntregaRevisor").val()) == "") ? validarCampos += `Rellene: Observacion Condicion Entrega<br/>` : ""
                                break;
                            case "ValidaCondicionPago":
                                ($.trim($("#ObservacionCondPagoRevisor").val()) == "") ? validarCampos += `Rellene: Observacion Condicion Pago<br/>` : ""
                                break;
                            default:
                                break;
                        }
                        break;
                    case 90:
                        switch ($(this).prop('name')) {
                            case "ValidaLotes":
                                ($.trim($("#ObservacionLotes").val()) == "") ? validarCampos += `Rellene: Observacion Lotes<br/>` : ""
                                break;
                            case "ValidaCondicionEntrega":
                                ($.trim($("#OnservacionCondicionEntrega").val()) == "") ? validarCampos += `Rellene: Observacion Condicion Entrega<br/>` : ""
                                break;
                            case "ValidaCondicionPago":
                                ($.trim($("#ObservacionCondicionPago").val()) == "") ? validarCampos += `Rellene: Observacion Condicion Pago<br/>` : ""
                                break;
                            case "ValidaDocumentosRevisor":
                                ($.trim($("#ObservacionDoctosRevisor").val()) == "") ? validarCampos += `Rellene: Observacion Documentos<br/>` : ""
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        });
        return validarCampos;
    }
    $("input[type='radio']").on('change', function (e) {
        e.preventDefault()
        validaRechazo()
        if ($(this).is(':checked') && $(this).val() == "true") {
            //changestatus($(this), true)
        } else {
            if ($(this).val() == "false") {
                //changestatus($(this), false)
            }
        }
        (activateButtons()) ? $('#AutorizarRevision').prop('disabled', false) : $('#AutorizarRevision').prop('disabled', true);
    })

    $('#AutorizarRevision').on('click', function () {
        if (activateButtons() && validateRadio()) {
            bootbox.confirm({
                title: "<div class='col-12 text-center'>" + "Autorizar solicitud" + "<div>" ,
                message: "¿Desea autorizar la solicitud?",
                size: "small",
                callback: function (res) {
                    if (res) {
                        let data = $('#RequFirm').serialize()
                        traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: aceptarRequisicionRevisor, b: data })
                        //aceptarRequisicionRevisor(data)
                    }
                }
            }).find('.modal-dialog').addClass("modal-dialog-centered");
        } else {
            mensajeGenerico("Aviso", "Autoriza todos los elementos", "")
        }
    })
    $('#RechazarRevision').on('click', function () {
        if (validateRadio()) {
            let Observaciones = validaObservaciones().trim()
            if (Observaciones == "") {
                bootbox.confirm({
                    title: "<div class='col-12 text-center'>" + "Rechazar solicitud" + "<div>",
                    message: "¿Desea rechazar la solicitud?",
                    size: "small",
                    callback: function (res) {
                        if (res) {
                            let data = $('#RequFirm').serialize()
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: rechazarRequisicionRevisor, b: data })
                            //rechazarRequisicionRevisor(data)
                        }
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");
            } else {
                mensajeGenerico("Aviso", Observaciones, "")
            }
        } else {
            mensajeGenerico("Aviso", "Falta autorizar en firmantes", "")
        }
    })
    $('#btnAutorizarDirector').on('click', function () {
        validarAccion("Realmente desea Autorizar la requisición", '/RequisicionesPorRevisar/autorizarRequisicionDirector/',"Autorizado");
    })
    $('#btnCancelarDirector').on('click', function () {
        validarAccion("Realmente desea cancelar la requisición", '/RequisicionesPorRevisar/cancelarRequisicionDirector/', "Cancelado");
    })
})
function aceptarRequisicionRevisor(data) {
    
    $.post('/RequisicionesPorRevisar/aceptarRequisicion', data, "json")
        .done(function (result) {
            mensajeGenerico("Aviso", (result.success ? "Se autorizó requisición" : result.mensaje), "1")
        })
        .fail(function (jqxhr, TextStatus, status) {
            mensajeGenerico("Aviso", `${jqxhr} ${TextStatus} ${status}`, "")
        })
}
function rechazarRequisicionRevisor(data) {
    
    $.post('/RequisicionesPorRevisar/rechazoRequisicion', data, "json")
        .done(function (result) {
            mensajeGenerico("Aviso", (result.success ? "Se rechazó requisición" : result.mensaje), "1")
        })
        .fail(function (jqxhr, TextStatus, status) {
            mensajeGenerico("Aviso", `${jqxhr} ${TextStatus} ${status}`, "")
        })
}
function validarAccion(mensaje,url,proceso) {
    bootbox.confirm({
        title: proceso + " requisición",
        message: mensaje,
        size: "small",
        callback: function (result) {
            if (result) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveDirectorAdquisciones, b: { url: url, proceso: proceso } })
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");;
}
function saveDirectorAdquisciones(b) {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion_ = $("#IdRequisicion").val();

    var parametros = {
        pIdRequisicion: IdRequisicion_,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: b.url,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                var a = $("#tipoRequisicion").val();
                mensajeGenerico("Aviso", b.proceso + " por director de adquisiciones", '/RequisicionConsulta/Index/' + a,"1")
            }
            else {
                mensajeGenerico("Aviso", "Error en autorizar:" + response.mensaje, '/RequisicionConsulta/Index/' + a, "1")
            }

        }
    });
}
function menssage(title, cuerpo) {
    $(".modal-title").html(title);
    $("#titlePopUp").html(cuerpo);
    $("#Pop-Up").modal("show");
}