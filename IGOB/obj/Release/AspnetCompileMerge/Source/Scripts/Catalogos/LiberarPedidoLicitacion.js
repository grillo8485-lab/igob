$(document).ready(function () {
    $('#liberarPedidoDetalle').DataTable({
        scrollX: false,
        scrollCollapse: false,
        sort: false,
        "language": {
            "emptyTable": ""
        }
    });
});
function liberarPedidoFirmaConfirm(IdFirmantePedido) {
    bootbox.confirm({
        message: "¿Confirma que desea liberar pedido?",
        title: "<div class='col-12 text-center'>Aviso<div>",
        size: 'small',
        closeButton: false,
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
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveFirmateLiberarPedido, b: IdFirmantePedido })
               // traerTokenCaptura(IdFirmantePedido);
            }
            else {
                var activo = $("#" + IdFirmantePedido);
                if (activo.is(':checked')) {
                    activo.prop('checked', false);
                }
                else {
                    activo.prop('checked', true);
                }
            }
        }
    });
}
function traerTokenCaptura(IdFirmantePedido) {
    var displayButton = "hide";
    bootbox.prompt({
        title: "<div class='col-12 text-center'>Introduce token<div>",
        size: 'small',
        closeButton: false,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Cancel',
                className: displayButton,
            },
            confirm: {
                label: 'Aceptar'
            }
        },
        callback: function(result) {
            if ( result!="") {
                saveFirmateLiberarPedido(IdFirmantePedido);
            }
            else {
                var activo = $("#" + IdFirmantePedido);
                if (activo.is(':checked')) {
                    activo.prop('checked', false);
                }
                else {
                    activo.prop('checked', true);
                }
                mensaje("Aviso","Debe capturar token para poder continuar","");
            }
        }
        });

}

function saveFirmateLiberarPedido(IdFirmantePedido_) {
    var PerfilText = $("#PerfilText").val();
    var token = $("[name='__RequestVerificationToken']").val();
    var data = {
        IdFirmantePedido: IdFirmantePedido_,
        __RequestVerificationToken: token
    }
    $.ajax({
        data: data,
        url: '/LiberarPedidoLicitacionRequisicion/saveFirmateLiberarPedido/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                mensaje("Aviso", "El pedido ha sido firmado por <strong>" + PerfilText +"</strong>", "/LiberarPedidoLicitacionRequisicion/Index/")
            }
            else {

                mensaje("Error en el guardado: " + response.mensaje, "Aviso", "")
            }
        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
        }
    });
}

function mensaje(title_, mensaje_, url_=""){

    bootbox.alert({
        message:  mensaje_ ,
        size: 'small',
        title: "<div class='col-12 text-center'>" + title_ + "<div>",
        closeButton: false,
        callback: function () {
            if (url_ != "") {
                location.href = url_
            }
        }
    })
}
function recepcionPedidoFirmaConfirm() {
    //validarFormulario();

        bootbox.confirm({
            message: "¿Confirma que desea recepcionar pedido?",
            title: "<div class='col-12 text-center'>Aviso<div>",
            size: 'small',
            closeButton: false,
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
                    //traerTokenCapturaRecepcionPedido_();
                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveRecepcionPedido, b: undefined })
                }

            }
        });
}
function traerTokenCapturaRecepcionPedido_() {
    var displayButton = "hide";
    $("#btnRecepcionarPedidoDetalle").attr('disabled', 'disabled');
    bootbox.prompt({
        title: "<div class='col-12 text-center'>Introduce token<div>",
        size: 'small',
        closeButton: false,
        buttons: {
            cancel: {
                
                className: displayButton,
            },
            confirm: {
                label: 'Aceptar'
            }
        },
        callback: function (result) {
            if (result != "") {
                
                saveRecepcionPedido();
            }
            else {
                
                mensaje("Aviso", "Debe capturar token para poder continuar", "");
            }
        }
    });

}
function saveRecepcionPedido() {
   
    var token = $("[name='__RequestVerificationToken']").val();
    var objetoArray = Array();
    $("#LiberarPedidoDetalleCaptura tr").each(function (index, element) {

        var inputs = $(element).find("input, select,textarea");
        if (inputs.length > 1) {
            var data = {}
                IdRecepcionDetalle: parseInt(0),
                inputs.each(function () {
                    var objeto1 = this;
                    data[objeto1.id] = objeto1.value;
                });
            objetoArray.push(data);
        }
        
    })
    var dataWithAntiforgeryToken = $.extend({ 'lstrecepcionPedido': objetoArray }, { '__RequestVerificationToken': token });
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/RecepcionarPedidoDetalle/saveRecepcionPedido/',
        data: dataWithAntiforgeryToken,
        beforeSend: function () {
            
            $("#btnRecepcionarPedidoDetalle").attr('disabled', 'disabled');
        },
        success: function (response) {
           
            if (response.success) {
               
                mensaje("Aviso", response.mensaje, "/RecepcionarPedidoDetalle/Index/")
                $("#btnRecepcionarPedidoDetalle").removeAttr('disabled');
            }
            else {
                
                mensaje("Aviso", response.mensaje, "")
                $("#btnRecepcionarPedidoDetalle").removeAttr('disabled');
            }
            
        },
        failure: function (response) {
            mensaje("#btnRecepcionarPedidoDetalle", response.responseText, "")
            $("input").removeAttr('disabled');
        },
        error: function (response) {
            mensaje("Error pagina: " + response.responseText, "Aviso", "");
            $("#btnRecepcionarPedidoDetalle").removeAttr('disabled');
        }

    }); 
}

//impresión de reportes
function ImprimirPedido() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdPedido = $("#IdPedido_").val();
    var parametros = {
        pIdPedido: IdPedido,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/LiberarPedidoLicitacionRequisicion/ImprimirSolicitud/',
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