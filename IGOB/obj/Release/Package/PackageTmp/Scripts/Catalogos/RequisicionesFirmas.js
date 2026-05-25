$(document).ready(function () {
    deshabilitarmeses()
    function changestatus(input, status) {
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
        ($("input[name='ValidaLotes']").is(':checked') && $("input[name='ValidaCondicionEntrega']").is(':checked') && $("input[name='ValidaCondicionPago']").is(':checked')) ? validate = true : validate = false;
        return validate;
    }
    function validaRechazo() {
        ($("input[name='ValidaLotes']:checked").val() == "true" && $("input[name='ValidaCondicionEntrega']:checked").val() == "true" && $("input[name='ValidaCondicionPago']:checked").val() == "true") ? $('#Rechazar').prop('disabled', true) : $('#Rechazar').prop('disabled', false);
    }
    function validaObservaciones() {
        let validarCampos = "";
        $("input[type='radio']:checked").each(function () {
            if ($(this).val() == "false") {
                switch ($(this).prop('name')) {
                    case "ValidaLotes":
                        ($.trim($("#ObservacionLotes").val()) == "") ? validarCampos += `Rellene: observación lotes <br\>` : ""
                        break;
                    case "ValidaCondicionEntrega":
                        ($.trim($("#OnservacionCondicionEntrega").val()) == "") ? validarCampos += "Rellene: observación condición entrega <br\>" : ""
                        break;
                    case "ValidaCondicionPago":
                        ($.trim($("#ObservacionCondicionPago").val()) == "") ? validarCampos += "Rellene: observación condición pago <br\>" : ""
                        break;
                    default:
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
        (activateButtons()) ? $('#Autorizar').prop('disabled', false) : $('#Autorizar').prop('disabled', true);
    })
    $('#Autorizar').on('click', function () {
        if (activateButtons() && validateRadio()) {
            let data = $('#RequFirm').serialize()
            bootbox.confirm({
                title: "<div class='col-12 text-center'>Autorizar requisición<div>",
                message: "¿Desea autorizar la requisición?",
                size: "small",
                callback: function (resp) {
                    if (resp) {
                        traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: autorizacionRequisicionFirmantes, b: data })
                    }
                }
            }).find('.modal-dialog').addClass("modal-dialog-centered");
        } else {
            mensajeGenerico("Aviso", "Autoriza todos los elementos", "")
        }
    })
    $('#Rechazar').on('click', function () {
        if (validateRadio()) {
            let Observaciones = validaObservaciones().trim()
            if (Observaciones == "") {
                let data = $('#RequFirm').serialize()
                bootbox.confirm({
                    title: "Rechazar requisición",
                    message: "¿Desea rechazar la requisición?",
                    size: "small",
                    callback: function (resp) {
                        if (resp) {
                            //$.post('/RequisicionFirmante/Create', data, "json")
                            //    .done(function (result) {
                            //        bootbox.confirm({
                            //            title: "Rechazar requisición",
                            //            message: result,
                            //            size: "small",
                            //            callback: function () {
                            //                location.reload();
                            //            }
                            //        })
                            //    });
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: autorizacionRequisicionFirmantes, b: data })
                        }
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");

            } else {
                mensajeGenerico("Aviso", Observaciones, "")
            }
        } else {
            mensajeGenerico("Aviso", "Selecciona los campos","")
        }
    })
})
function autorizacionRequisicionFirmantes(data) {
    $.post('/RequisicionFirmante/Create', data, "json")
        .done(function (result) {
            if (result.success) {
                mensajeGenerico("Aviso", result, "1")
            } else {
                mensajeGenerico("Aviso", result, "1");
            }
            
        });
}
function deshabilitarmeses() {
    var de = $("#De").children()
    var al = $("#Al").children()
    buscarMesesPasados(de)
    buscarMesesPasados(al)
}
function buscarMesesPasados(elemento) {
    var n = new Date().getMonth() + 1;
    elemento.each(function (item, val) {
        if (val.value != "" && val.value < n) {
            $(val).css('display','none')
        }
    })
}
$('#AutorizarRevision').on('click', function () {
    if (activateButtons() && validateRadio()) {
        let data = $('#RequFirm').serialize()
        bootbox.confirm({
            title: "<div class='col-12 text-center'>" + "Autorizar revisión" + "<div>",
            message: "¿Desea autorizar revisión?",
            callback: function (res) {
                if (res) {
                    $.ajax({
                        data: data,
                        url: '/RequisicionesPorRevisar/aceptarRequisicion',
                        type: 'post',
                        dataType: 'json',
                        contentType: 'application/json',
                        beforeSend: function () {

                        },
                        success: function (response) {
                            if (response.success) {
                                bootbox.confirm({
                                    title: "Autorizar revisión?",
                                    message: "Datos guardados correctamente",
                                    callback: function (res) {
                                        location.reload();
                                    }
                                })
                            }
                            else {
                                bootbox.alert({
                                    title: "Aviso",
                                    message: response.mensaje,
                                })
                            }
                        }
                    });
                }
            }
        }).find('.modal-dialog').addClass("modal-dialog-centered");
    } else {
        bootbox.alert({
            title: "Aviso",
            message: "Autoriza todos los elementos",
        })
    }
})
$('#RechazarRevision').on('click', function () {
    if (validateRadio()) {
        let Observaciones = validaObservaciones().trim()
        if (Observaciones == "") {
            let data = $('#RequFirm').serialize()
            bootbox.confirm({
                title: "<div class='col-12 text-center'>" + "Rechazar revisión" + "<div>" ,
                message: "¿Desea rechazar la revisión?",
                callback: function (res) {
                    if (res) {
                        $.ajax({
                            data: data,
                            url: '/RequisicionesPorRevisar/aceptarRequisicion',
                            type: 'post',
                            dataType: 'json',
                            contentType: 'application/json',
                            beforeSend: function () {
                            },
                            success: function (response) {
                                if (response.success) {
                                    bootbox.confirm({
                                        title: "Rechazar revisión",
                                        message: "Datos guardados correctamente",
                                        callback: function () {
                                            location.reload();
                                        }
                                    })
                                }
                                else {
                                    bootbox.alert({
                                        title: "Aviso",
                                        message: "Error: " + response.mensaje,
                                    })
                                }

                            }
                        });
                    }
                }
            }).find('.modal-dialog').addClass("modal-dialog-centered");
        } else {
            bootbox.alert({
                title: "Aviso",
                message: Observaciones,
            })
        }
    } else {
        bootbox.alert({
            title: "Aviso",
            message: "Selecciona los campos",
        })
    }
   
})