//impresión de reportes
function ImprimirReporteAclaracionDudas() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLic_").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };
    

    $.ajax({
        data: parametros,
        url: '/LicitacionesAclaracionDudas/ImprimirSolicitud/',
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
function validarGenerarPublicarActaAclaraciónDudas() {
    bootbox.confirm({
        title: "<div class='col-12 text-center'>Confirmación<div>",
        closeButton: false,
        message: "¿Confirma que desea generar y publicar acta de aclaración de dudas?",
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
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveGenerarPublicarActaAclaraciónDudas, b: undefined })
                //saveGenerarPublicarActaAclaraciónDudas();
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}


//Guardar y publicar
function saveGenerarPublicarActaAclaraciónDudas() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLic_").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/LicitacionesAclaracionDudas/saveGenerarPublicarActaAclaraciónDudas/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                mensaje("Aviso", "Se generó acta de aclaración de dudas correctamente", "/LicitacionesAclaracionDudas/Index/?pIdLic=" + IdLic);
            }
            else {
                mensaje("Aviso", "Error: " + response.mensaje, "");
            }

        }
    });
}

function mensaje(titulo, mensaje, url_) {
    bootbox.alert({
        title: "<div class='col-12 text-center'>" + titulo+"<div>" ,
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
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}