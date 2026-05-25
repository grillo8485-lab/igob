$(document).ready(function () {
    $('#tablaRespuestaPreguntaSolicitante').DataTable({
        scrollY: 440,
        scrollCollapse: true,
        sort: false
    });
})

function actualizarPreguntaRespuesta(IdPregunta) {
    
    $("#IdPregunta").val(IdPregunta)
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion = $("#IdRequisicion").val();
    var parametros = {
        pIdPregunta: IdPregunta,
        pIdRequisicion: IdRequisicion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RespuestaPreguntaSolicitante/getPreguntaResPuesta/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
           
            if (response.success) {
                var objeto = response.objeto;
                $("#Pregunta").html(objeto.Pregunta);
                $("#Respuesta").val(objeto.Respuesta);
                $("#IdPregunta").val(objeto.IdPregunta);
                $("#IdRespuesta").val(objeto.IdRespuesta);
                $("#modal_CargarPreguntaRespuesta").modal("show");
            }
            else {
                
                mensaje("Respuesta", "Errror: "+ response.mensaje,"");
            }

        }
    });
}

function saveRespuesta() {
    bootbox.confirm({
        title: "<div class='col-12 text-center'>Confirmación<div>",
        closeButton: false,
        message: "¿Confirma que desea agregar respuesta?",
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
                procesar()
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function procesar() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRespuesta = $("#IdRespuesta").val();
    var Respuesta = $("#Respuesta").val();
    var parametros = {
        pIdRespuesta: IdRespuesta,
        pRespuesta: Respuesta,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RespuestaPreguntaSolicitante/savePreguntaResPuesta/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
               
                mensaje("Aviso", "La pregunta ha sido respondida","")

                $('#tablaRespuestaPreguntaSolicitante').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaRespuestaPreguntaSolicitante').dataTable().fnDestroy();
                $("#cargarTableRespuestas").load(" #cargarTableRespuestas", function () {
                    $('#tablaRespuestaPreguntaSolicitante').DataTable({
                        scrollY: 440,
                        scrollCollapse: true,
                        sort: false
                    });
                    $("#modal_CargarPreguntaRespuesta").modal("hide");
                });

            }
            else {

                mensaje("Respuesta", "Error: " + response.mensaje,"");
            }

        }
    });
}
function mensaje(titulo,mensaje,url_) {
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
            if (url_!="")
                location.href = url_;
        }
    })
}


function enviarRespuestas() {
    bootbox.confirm({
        title: "<div class='col-12 text-center'>Confirmación<div>",
        closeButton: false,
        message: "¿Confirma que desea enviar las respuesta?",
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
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: procesarEnviarRespuesta, b: undefined })
            }
                //procesarEnviarRespuesta()
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function procesarEnviarRespuesta() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion = $("#IdRequisicion").val();
    var parametros = {
        pIdRequisicion: IdRequisicion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RespuestaPreguntaSolicitante/setEnviarRespuestas/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                var pIdLicitacion = $("#IdLicitacion").val()
                var url_ = '/ListadoRequisicionLicitacion/Index/?id=' + pIdLicitacion;
                mensaje("Aviso ", "Las respuestas fueron enviadas correctamente", url_);

            }
            else {

                mensaje("Respuesta", "Errror: " + response.mensaje,"");
            }

        }
    });
}

function autorizaPreguntaRespuesta(IdPregunta) {

    $("#IdPregunta").val(IdPregunta)
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion = $("#IdRequisicion").val();
    var parametros = {
        pIdPregunta: IdPregunta,
        pIdRequisicion: IdRequisicion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RevicionPreguntaRespuesta/getPreguntaResPuesta/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                var objeto = response.objeto;
                $("#Pregunta").html(objeto.Pregunta);
                $("#Respuesta").html(objeto.Respuesta);
                $("#IdPregunta").val(objeto.IdPregunta);
                $("#IdRespuesta").val(objeto.IdRespuesta);

                $("#modal_CargarPreguntaRespuesta").modal("show");
            }
            else {

                mensaje("Respuesta", "Error: " + response.mensaje, "");
            }

        }
    });
}


function validarCheck() {
    var autorizar = $("input[name='customRadio']:checked").val();
    if (autorizar == 1) {
        $("#Observaciones").prop('disabled', true);
    }
    else
    {
        $("#Observaciones").prop('disabled', false);
    }
    $("#AutorizarRechazar").val(autorizar)
}

function saveAutorizar() {
    bootbox.confirm({
        title: "<div class='col-12 text-center'>Confirmación<div>",
        closeButton: false,
        message: "¿Confirma que desea " + ($('input[name="customRadio"]:checked').val() == "1" ? "autorizar" :"rechazar")+" la respuesta?",
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
                procesarAutorizar()
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function procesarAutorizar() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRespuesta = $("#IdRespuesta").val();
    var AutorizaRechaza = $("#AutorizarRechazar").val()
    var Observaciones = $("#Observaciones").val()
    var parametros = {
        pIdRespuesta: IdRespuesta,
        pAutorizaRechaza: AutorizaRechaza,
        pObservaciones: Observaciones,
        __RequestVerificationToken : token
    };

    $.ajax({
        data: parametros,
        url: '/RevicionPreguntaRespuesta/saveAutoriazaRechaza/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {

               

                $('#tablaRespuestaPreguntaSolicitante').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tablaRespuestaPreguntaSolicitante').dataTable().fnDestroy();
                $("#cargarTableRespuestas").load(" #cargarTableRespuestas", function () {
                    mensaje("Aviso", "La pregunta ha sido autorizada", "")
                    $('#tablaRespuestaPreguntaSolicitante').DataTable({
                        scrollY: 440,
                        scrollCollapse: true,
                        sort: false
                    });
                    $("#modal_CargarPreguntaRespuesta").modal("hide");
                });
                $("#btns").load(" #btns")
                

            }
            else {

                mensaje("Respuesta", "Errror: " + response.mensaje, "");
            }

        }
    });
}


function enviarAutorizarRespuestas() {
    bootbox.confirm({
        title: "<div class='col-12 text-center'>Confirmación<div>",
        closeButton: false,
        message: "¿Confirma que desea enviar las respuesta?",
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
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: procesarEnviarAutorizarRespuesta, b: undefined })
            }
                //procesarEnviarAutorizarRespuesta()
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function procesarEnviarAutorizarRespuesta() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion = $("#IdRequisicion").val();
    var parametros = {
        pIdRequisicion: IdRequisicion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RevicionPreguntaRespuesta/setEnviarRespuestas/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                var pIdLicitacion = $("#IdLicitacion").val()
                var pidTipoProveso = $("#IdTipoProveso").val()
                var url_ = '/ListadoRequisicionLicitacion/Index/?id=' + pIdLicitacion + "&idTipoProveso=" + pidTipoProveso;
                mensaje("Aviso ", "Las respuestas fueron enviadas correctamente", url_);

            }
            else {

                mensaje("Respuesta", "Errror: " + response.mensaje, "");
            }

        }
    });
}