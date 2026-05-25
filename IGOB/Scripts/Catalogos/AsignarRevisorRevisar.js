$(document).ready(() => {
    $("input[type='radio']").on('change', function (e) {
        ($("input[name='ValidaLotesRevisor']:checked").val() == "true" && $("input[name='ValidaCondicionEntregaRevisor']:checked").val() == "true" && $("input[name='ValidaCondicionPagoRevisor']:checked").val() == "true") ? $('#btnRechazar').prop('disabled', true) : $('#btnRechazar').prop('disabled', false);
        let el = $(this)
        $(`#${el.prop('name')}`).prop("readonly", ((el.is(':checked') && el.val() == "true") ? true : false));
        (activateButtons()) ? $('#btnAutoriza').prop('disabled', false) : $('#btnAutoriza').prop('disabled', true);
    })

})

function activateButtons() {
    let activo = true;
    $("input[type='radio']:checked").each(function () {
        ($(this).val() == "false") ? activo = false : "";
    });
    return activo;
}

const validateRadio = () => ($("input[name='ValidaLotesRevisor']").is(':checked') && $("input[name='ValidaCondicionEntregaRevisor']").is(':checked') && $("input[name='ValidaCondicionPagoRevisor']").is(':checked')) ? true : false;

$('#DatosGeneralesTabPadre').on('click', () => { $('#btnAutoriza,#btnRechazar').addClass('d-none') })
$('#FirmanteTabPadre').on('click', () => { $('#btnAutoriza,#btnRechazar').removeClass('d-none') })

function validaObservaciones() {
    let validarCampos = "";
    $("input[type='radio']:checked").each(function () {
        if ($(this).val() == "false") {
            switch ($(this).prop('name')) {
                case "ValidaLotes":
                    ($("#ObservacionLotes").val().trim() == "") ? validarCampos += `Rellene: observación lotes <br\>` : ""
                    break;
                case "ValidaCondicionEntrega":
                    ($("#OnservacionCondicionEntrega").val().trim() == "") ? validarCampos += "Rellene: observación condición entrega <br\>" : ""
                    break;
                case "ValidaCondicionPago":
                    ($("#ObservacionCondicionPago").val().trim() == "") ? validarCampos += "Rellene: observación condición pago <br\>" : ""
                    break;
                default:
                    break;
            }
        }
    });
    return validarCampos;
}





$('#btnAsignarRev').on('click', function () {
    if ($('#IdUsuarioRevisor').val() != "") {
        bootbox.confirm({
            title: `<div class="text-center">Asignar revisor</div>`,
            message: "¿Desea asignar revisor a la adjudicación?",
            size: "small",
            callback: function (acepto) {
                if (acepto) {
                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAsignarRevisorRevisar, b: undefined })
                }
            }
        })
    } else {
        bootbox.alert({
            title: `<div class="text-center">Aviso</div>`,
            message: "No se tiene seleccionado a un revisor",
            size: "small"
        })
    }
    return false;
})

$('#btnAutoriza').on('click', function () {
    $("#tipo").val(1);
    const data = $(`#RevisorAutAdj,input[name="ValidaLotesRevisor"]:checked,textarea[name="ObservacionLotesRevisor"],input[name="ValidaCondicionEntregaRevisor"]:checked,textarea[name="ObservacionConEntregaRevisor"],input[name="ValidaCondicionPagoRevisor"]:checked,textarea[name="ObservacionCondPagoRevisor"],input[name="IdAdjudicacionFirmante"]`).serialize()
    bootbox.confirm({
        title: `<div class="text-center">Autorizar revisión</div>`,
        message: "¿Autorizar revisión de la adjudicación?",
        size: "small",
        callback: function (resp) {
            if (resp) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAceptarRevisorFirmante, b: data })
            }
        }
    })
})

$('#btnRechazar').on('click', function () {
    $("#tipo").val(2);
    const observacion = validaObservaciones()
    const data = $(`#RevisorAutAdj,input[name="ValidaLotesRevisor"]:checked,textarea[name="ObservacionLotesRevisor"],input[name="ValidaCondicionEntregaRevisor"]:checked,textarea[name="ObservacionConEntregaRevisor"],input[name="ValidaCondicionPagoRevisor"]:checked,textarea[name="ObservacionCondPagoRevisor"],input[name="IdAdjudicacionFirmante"]`).serialize()
    if ((observacion != null || observacion != "") && validateRadio()) {
        bootbox.confirm({
            title: `<div class="text-center">Rechazar revisión</div>`,
            message: "¿Desea rechazar revisión de la adjudicación?",
            size: "small",
            callback: function (resp) {
                if (resp) {
                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAceptarRevisorFirmante, b: data })
                }
            }
        })
    } else {
        bootbox.alert({
            title: "Aviso",
            message: observacion,
            size: "small"
        })
    }
})

$('#btnAsignarNumeroAcuerdo').on('click', function () {
    if ($('#AcuerdoAutorizacionComite').val().trim() != "") {
        bootbox.confirm({
            title: `<div class="text-center">Asignar número de acuerdo</div>`,
            message: `¿Desea asignar un número de autorización de comité <strong>${$('#AcuerdoAutorizacionComite').val()}</strong>?`,
            size: "small",
            callback: function (acepto) {
                if (acepto) {
                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAsignarNumeroAcuerdo, b: undefined })
                }
            }
        })
    } else {
        bootbox.alert({
            title: `<div class="text-center">Aviso</div>`,
            message: "Se tiene que asignar un número de autorización de comité",
            size: "small"
        })
    }
    return false;
})
function saveAsignarRevisorRevisar() {
    $.post('/AdjudicacionesAutorizadasConsulta/UpdateDirectorAdquisicion/',
        $('#AsignacionRevisorAdj').serialize(),
        "json")
        .done(function (data) {
            bootbox.alert({
                title: `<div class="text-center">Asignar revisor</div>`,
                message: data,
                size: "small",
                callback: function (reload) {
                    location.reload();
                }
            })
        })
        .fail(function (xhr, TextStatus, error) {
            bootbox.alert({
                title: `<div class="text-center">Aviso</div>`,
                message: `Error: ${xhr} ${TextStatus} ${error}`,
                size: 'small'
            })
        })
}
function saveAsignarNumeroAcuerdo() {
    $.post('/AdjudicacionesAutorizadasConsulta/UpdateDirectorAdquisicion/',
        $('#AsignacionRevisorAdj').serialize(),
        "json")
        .done(function (data) {
            bootbox.alert({
                title: `<div class="text-center">Asignar número de acuerdo</div>`,
                message: data,
                size: "small",
                callback: function (reload) {
                    location.reload();
                }
            })
        })
        .fail(function (xhr, TextStatus, error) {
            bootbox.alert({
                title: `<div class="text-center">Aviso</div>`,
                message: `Error: ${xhr} ${TextStatus} ${error}`,
                size: 'small'
            })
        })
}
function saveAceptarRevisorFirmante(data) {
    $.post(
        '/AdjudicacionesAutorizadasConsulta/UpdateAdjudicacionAutorizaRevisor/',
        data,
        "json"
    ).done(function (resp) {
        bootbox.alert({ title: "Aviso", message: resp, size: "small", callback: function (retorno) { location.reload() } })
    }).fail(function (xhr, TextStatus, status) {
        bootbox.alert({ title: "Error", message: `${xhr, TextStatus, status}`, size: 'small' })
    })
}
function retornoBack() {
    location.href = `/AdjudicacionesAutorizadasConsulta/Index/${$('#back').val()}`;
    return false;
}