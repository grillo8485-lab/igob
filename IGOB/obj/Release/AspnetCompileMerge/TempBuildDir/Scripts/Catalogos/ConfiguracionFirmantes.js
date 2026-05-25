$(document).ready(function () {
    $('#ConfiguraacionFirmantesTbl').DataTable({
        paging: false,
        searching: false,
        info: false,
        scrollX: false,
        scrollCollapse: false,
        sort: false,
        "language": {
            "emptyTable": ""
        }
    });
});
function saveConfirmFirmanteConfiguracion(IdConfigFirmantePedido, IdPerfil, Ordenamiento) {

    if (validarTexbos("Cargo_" + IdPerfil)) {
        bootbox.confirm({
            title: "Aviso",
            message: "¿Desea agregar perfil a la configuración?",
            size: "small",
            callback: function (res) {
                if (res) {
                    saveFirmante(IdConfigFirmantePedido, IdPerfil, Ordenamiento)
                }
                else {
                    var activo = $("#" + IdPerfil);
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
    else {
        var activo = $("#" + IdPerfil);
        if (activo.is(':checked')) {
            activo.prop('checked', false);
        }
        else {
            activo.prop('checked', true);
        }
    }
        
}
function validarTexbos(id) {
    var text = $.trim($("#" + id).val());
    if (text == "") {
        mensajeGenerico("Aviso", "Falta llenar cargo, para continuar", "");
        return false
    }
    else {
        return true;
    }
}
function saveFirmante(IdConfigFirmantePedido_, IdPerfil_, Ordenamiento_) {

    var token = $("[name='__RequestVerificationToken']").val();
    var activo = $("#" + IdPerfil_);
    var value = false;
    if (activo.is(':checked')) {
        value = true;
    }
    else {
        value = false;
    }
    var text = $.trim($("#Cargo_" + IdPerfil_).val());
    var data = {
        IdConfigFirmantePedido: IdConfigFirmantePedido_,
        Ordenamiento: Ordenamiento_,
        IdPerfil: IdPerfil_,
        Activo: value,
        Cargo: text,
        IdModalidadLicitacion: $("#IdModalidadLicitacion").val(),
        __RequestVerificationToken: token
    }
    $.ajax({
        data: data,
        url: '/ConfiguracionFirmantesModalidades/saveConfiguracionFirmante/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                var IdModalidadLicitacion_ = $("#IdModalidadLicitacion").val();
                mensajeGenerico("Aviso", "Firmante guardado correctamente", '/ConfiguracionFirmantesModalidades/Index/?IdModalidadLicitacion=' + IdModalidadLicitacion_)
            }
            else {

                mensajeGenerico("Aviso", "Error en el guardado: " + response.mensaje, "")
            }
        },
        error: function (response) {
            mensajeGenerico("Aviso", "Error pagina: " + response.responseText, "");
        }
    });
}
function getModalidadLicitacion() {
    var IdModalidadLicitacion_ = $("#IdModalidadLicitacion").val();
    location.href = '/ConfiguracionFirmantesModalidades/Index/?IdModalidadLicitacion=' + IdModalidadLicitacion_;
}