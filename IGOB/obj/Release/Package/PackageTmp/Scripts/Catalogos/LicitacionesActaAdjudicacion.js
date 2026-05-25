//impresión de reportes
function ImprimirReporteActaAdjudicacion() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLic_").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/LicitacionesActaAdjudicacion/ImprimirSolicitud/',
        type: 'post',
        beforeSend: function () {
            //mostrar modal loading
            $("#modal_loading").modal('show');
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                //éxito
                var base_url = window.location.origin + "/Files/Reportes/" + response.Descarga;
                window.setTimeout(function () { $('#modal_loading').modal('hide'); window.open(base_url); }, 1000);
            }
            else {
                //ocultar modal loading
                $('#modal_loading').modal('hide');
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');                
            }
            
        }
    });
}

function validarGenerarActaAdjudicacionProveedores() {
    bootbox.confirm({
        title: "Confirmación",
        closeButton: false,
        message: "¿Confirma que desea generar adjudicación?",
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
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveGenerarActaAdjudicacionProveedores, b: undefined })
                //saveGenerarActaAdjudicacionProveedores();
            }
        }
    });
}


//Guardar y publicar
function saveGenerarActaAdjudicacionProveedores() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLic_").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/LicitacionesActaAdjudicacion/saveGenerarActaAdjudicacionProveedores/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                mensaje("Aviso", "La adjudicación generada correctamente", "/LicitacionesActaAdjudicacion/Index/?pIdLic=" + IdLic);
            }
            else {
                mensaje("Aviso", "Error: " + response.mensaje, "");
            }

        }
    });
}

function mensaje(titulo, mensaje, url_) {
    bootbox.alert({
        title: titulo,
        closeButton: false,
        message: mensaje,

        size: "small",
        buttons: {
            ok: {
                label: 'ACEPTAR',
                className: 'btn-secondary'
            }
        },
        callback: function () {
            if (url_ != "")
                location.href = url_;
        }
    })
}