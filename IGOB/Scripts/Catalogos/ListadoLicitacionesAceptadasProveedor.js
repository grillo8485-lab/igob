$(document).ready(function () {
    $('#LicitacionesListadoAceptadasProveedores').DataTable({
        scrollY: "450",
        scrollX: true,
        scrollCollapse: true,
        sort: false

    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('#datetimepickerFechaPago').datetimepicker({
            language: 'es',
            format: "yyyy-mm-dd",
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            pickTime: false,
            inline: false
        });
    });


    $('#btnGuardar').click(function () {
        jQuery.validator.messages.required = 'Este campo es obligatorio.';
        jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
        jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
        $valido = $("#enviarPagosForm").valid();
        if ($valido) {
            bootbox.confirm({
                 title: "<div class='col-12 text-center'>Aviso<div>",
                size: "small",
                message: "¿Confirma que desea enviar pago?",

                buttons: {
                    confirm: {
                        label: 'SI'
                    },
                    cancel: {
                        label: 'No'
                    }
                },
                callback: function (result) {
                    if (result) {
                        traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: enviarPagos, b: undefined })
                        //enviarPagos();
                    }

                }
            }).find('.modal-dialog').addClass("modal-dialog-centered");
        }
        return false;
    });

$('#btnValido').click(function () {
    bootbox.confirm({
         title: "<div class='col-12 text-center'>Aviso<div>",
        message: "¿Confirma que desea guardar el registro?",
        buttons: {
            confirm: {
                label: 'SI'
            },
            cancel: {
                label: 'No'
            }
        },
        callback: function (result) {
            if (result) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: enviar, b: "/EnviarPagosProveedor/Valido/" })
            } //enviar("/EnviarPagosProveedor/Valido/");

        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
    return false;
});
$('#btnNoValido').click(function () {
    bootbox.confirm({
         title: "<div class='col-12 text-center'>Aviso<div>",
        message: "¿Confirma que desea guardar el registro?",
        buttons: {
            confirm: {
                label: 'SI'
            },
            cancel: {
                label: 'No'
            }
        },
        callback: function (result) {
            if (result) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: enviar, b: "/EnviarPagosProveedor/NoValido/" })
            } //enviar("/EnviarPagosProveedor/NoValido/");

        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
});
})
function mensaje(mensaje_, url_) {
    bootbox.alert({
        size: "small",
        title: "<div class='col-12'>Aviso<div>",
        message: mensaje_,
        className: "",
        callback: function () {

            location.href = url_ //'/ListadoLicitacionesInvitacionAceptadasProveedor/Index/';
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function enviar(url_) {
    var fileData = new FormData();
    var IdInvitacion = $("#IdInvitacion").val();
    var IdLicitacion = $("#IdLicitacion").val();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("IdInvitacion", IdInvitacion);
    fileData.append("__RequestVerificationToken", token);
    $.ajax({
        url: url_, //'/EnviarPagosProveedor/NoValido/', 
        type: "POST", processData: false,
        data: fileData, dataType: 'json',
        contentType: false,
        success: function (response) {
            if (response.success) {
                mensaje("Pago validado correctamente", '/LicitacionesRequisicionesRevicion/Index/?pIdLicitacion=' + IdLicitacion);
            }
            else {
                mensaje("Error pago: " + response.Mensaje);
            }

        },
        error: function (er) {
            mensaje("Error pago: " + response.Mensaje);
        }

    });
    return false;
}
function enviarPagos() {
    var fileUpload = $("#FileUpload1").get(0);
    var files = fileUpload.files;

    // Create FormData object  
    var fileData = new FormData();

    // Looping over all files and add it to FormData object  
    for (var i = 0; i < files.length; i++) {
        fileData.append("HelpSectionImages", files[i]);
    }
    var FolioOficial = $("#FolioOficial").val();
    var FechaPago = moment($('#FechaPago').val()).format('YYYY-MM-DD');
    var IdInvitacion = $("#IdInvitacion").val();
    var token = $("[name='__RequestVerificationToken']").val();

    fileData.append("FolioOficial", FolioOficial);
    fileData.append("FechaPago", FechaPago);
    fileData.append("IdInvitacion", IdInvitacion);
    fileData.append("__RequestVerificationToken", token);
    $.ajax({
        url: '/EnviarPagosProveedor/UploadFiles/', type: "POST", processData: false,
        data: fileData, dataType: 'json',
        contentType: false,
        success: function (response) {
            if (response.success) {
                mensaje("Pago enviado correctamente", '/ListadoLicitacionesInvitacionAceptadasProveedor/Index/');
            }
            else {
                mensaje("Error pago: " + response.Mensaje, '/ListadoLicitacionesInvitacionAceptadasProveedor/Index/');
            }

        },
        error: function (response) {
            mensaje("Error pago: " + response.Mensaje, '/ListadoLicitacionesInvitacionAceptadasProveedor/Index/');
        }

    });
}

function generarPedidoConfirm(idLicitacion, Licitacion) {
    bootbox.confirm({
         title: "<div class='col-12 text-center'>Aviso<div>",
        message: "¿Confirma que desea generar pedido para la licitación " + Licitacion+"?",
        buttons: {
            confirm: {
                label: 'SI'
            },
            cancel: {
                label: 'No'
            }
        },
        callback: function (result) {
            if (result) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveGenerarPedido, b: idLicitacion })
                //saveGenerarPedido(idLicitacion)
            }

        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function saveGenerarPedido(idLicitacion) {
    var fileData = new FormData();
    var token = $("[name='__RequestVerificationToken']").val();
    fileData.append("pIdLicitacion", idLicitacion);
    fileData.append("__RequestVerificationToken", token);
    $.ajax({
        url:'/ListadoLicitacionesInvitacionAceptadasProveedor/saveGenerarPedido/', 
        type: "POST", processData: false,
        data: fileData, dataType: 'json',
        contentType: false,
        success: function (response) {
            if (response.success) {
                mensaje("Pedido generado correctamente", '/ListadoLicitacionesInvitacionAceptadasProveedor/Index');
            }
            else {
                mensaje("Error pago: " + response.Mensaje);
            }

        },
        error: function (response) {
            mensaje("Error pago: " + response.responseText);
        }

    });
    return false;
}