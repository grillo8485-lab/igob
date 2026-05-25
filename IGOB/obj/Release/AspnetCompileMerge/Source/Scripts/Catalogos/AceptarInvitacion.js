function saveAceptacionInvitacion() {
    bootbox.confirm({
        title: "<div class='col-12 text-center'>!Aviso importante¡ </div>",
        closeButton: false,
        message: "¿Confirma que desea aceptar invitación?<br>Considere enviar su recibo de pago de bases, con la debida anticipación (48 horas antes de la fecha de apertura de propuestas técnicas y económicas), por proceso de validación",
       
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
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: procesar, b: undefined })
                
            }
                
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");

    

}
function procesar() {
    var idInvitacion = $("#IdInvitacion").val();
    var aceptar = parseInt($('input[name=aceptar]:checked').val());

    aceptar = aceptar == 0 ? false : true;
    var token = $("[name='__RequestVerificationToken']").val();

    var url_ = '/AceptarInvitacion/saveAceptacionInvitacion/'
    $.ajax({
        data: { pIdInvitacion: idInvitacion, pAceptacion: aceptar, __RequestVerificationToken: token },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                
                mensajeGenerico("Aceptar invitación", "Se acepto invitación","/LicitacionesListadoInvitaciones/Index/")
            }
            else {
                bootbox.alert({

                    title: "Aceptar Invitación",

                    message: "Error al aceptar invitación: " + response.mensaje,

                    size: "small",
                    callback: function () {

                        location.href = '/LicitacionesListadoInvitaciones/Index/';
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");

            }

        }
    });
}

//impresión de bases
function ImprimirBases() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLicitacion").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };
  

    $.ajax({
        data: parametros,
        url: '/AceptarInvitacion/ImprimirBases/',
        type: 'post',
        beforeSend: function () {
            //mostrar modal loading
            $("#modal_loading").modal('show');
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                //éxito
                //ocultar modal loading
                $('#modal_loading').modal('hide');
                window.setTimeout(function () { window.open("../Files/Reportes/" + response.Descarga); }, 1000);
                
            }
            else {
                //ocultar modal loading
                $('#modal_loading').modal('hide');
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
                
            }
            
        }
    });
}

//impresión de Convocatoria
function ImprimirConvocatoria() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLicitacion").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };
    

    $.ajax({
        data: parametros,
        url: '/AceptarInvitacion/ImprimirConvocatoria/',
        type: 'post',
        beforeSend: function () {
            //mostrar modal loading
            $("#modal_loading").modal('show');
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                //éxito
                //ocultar modal loading
                $('#modal_loading').modal('hide');
                window.setTimeout(function () { window.open("../Files/Reportes/" + response.Descarga); }, 1000);
            }
            else {
                //ocultar modal loading
                $('#modal_loading').modal('hide');
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }
            
        }
    });
}