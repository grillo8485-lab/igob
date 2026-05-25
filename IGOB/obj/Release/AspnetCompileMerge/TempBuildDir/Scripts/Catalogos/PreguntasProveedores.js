$(document).ready(function () {
    
    $('#tableProvPreguntas').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false,
        info: false,
        fnDrawCallback: function (oSettings) {
            $('.dataTables_empty').css('display','none')
        }
    });
    $('#create-Pregunta').on('click', function () {
        $('#formPregunta')[0].reset()

        $("#submitform").prop("value", "Guardar");
        $('#formEditCreate').html('Nueva pregunta');
        $('#modalProvPreguntas').modal('show');
    })
    $('#tableProvPreguntas').on('click', '.edit-item', function () {
        $('#IdProveedorRqInvitacion').val($(this).attr('data-idProvReqIn'))
        $('#IdPregunta').val($(this).attr('data-idpreg'))
        $('#Pregunta').val($(this).attr('data-preg'))
        $('#NoPregunta').val($(this).attr('data-nopreg'))        

        $("#submitform").prop("value", "Editar");
        $('#formEditCreate').html('Editar pregunta');
        $('#modalProvPreguntas').modal('show');
    })
    $('#tableProvPreguntas').on('click', '.delet-item', function () {
        let IdCond = $(this).attr('data-idpreg').trim()
        let pregunta = $(this).attr('data-preg').trim()
        let token = $("input[name='__RequestVerificationToken']").val();
        bootbox.confirm({
            title: "<div class='col-12 text-center'>Aviso<div>",
            message: `¿Desea eliminara la pregunta: "${pregunta}"?`,
            size: "small",
            callback: function (res) {
                if (res) {
                    $.post('/PreguntasProveedor/Delete',
                        { id: IdCond, __RequestVerificationToken: token },
                        "json"
                    ).done(function (response) {
                        $('#DeleteProvPreguntas').modal('hide');
                        //bootbox.alert({
                        //    title: "Eliminar Pregunta",
                        //    message: response,
                        //    size: 'small',
                        //    callback: function () {
                        //        location.reload()
                        //    }
                        //})
                        mensajeGenerico("Aviso", response, "1")
                    }).fail(function (jqXHR, textStatus, errorThrown) {
                        $('#DeleteProvPreguntas').modal('hide');
                        //bootbox.alert({
                        //    title: "Aviso",
                        //    message: `${jqXHR} ${textStatus} ${errorThrown}`,
                        //    size: 'small',
                        //    callback: function () {
                        //        location.reload()
                        //    }
                        //})
                        mensajeGenerico("Aviso", `${jqXHR} ${textStatus} ${errorThrown}`, "1")
                    });
                }
            }
        }).find('.modal-dialog').addClass("modal-dialog-centered");
    })
    $('#formPregunta').on('submit', function () {
        let data = $('#formPregunta').serialize()
        let tipo = $('#submitform').val()
        if ($('#Pregunta').val().trim() != "") {
            if (tipo.trim() == "Guardar") {
                $.post(
                    '/PreguntasProveedor/Create',
                    data,
                    "json"
                ).done(function (data) {
                    $('#modalProvPreguntas').modal('hide');
                    //bootbox.alert({
                    //    title: "Nueva pregunta",
                    //    message: data,
                    //    size: 'small',
                    //    callback: function () {
                    //        location.reload()
                    //    }
                    //})
                    mensajeGenerico("Aviso", data, "1")
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    $('#modalProvPreguntas').modal('hide');
                    //bootbox.alert({
                    //    title: "Aviso",
                    //    message: `${jqXHR} ${textStatus} ${errorThrown}`,
                    //    size: 'small',
                    //    callback: function () {
                    //        location.reload()
                    //    }
                    //})
                    mensajeGenerico("Aviso", `${jqXHR} ${textStatus} ${errorThrown}`, "1")
                })
            }
            if (tipo.trim() == "Editar") {
                $.post(
                    '/PreguntasProveedor/Edit',
                    data,
                    "json"
                ).done(function (data) {
                    $('#modalProvPreguntas').modal('hide');
                    //bootbox.alert({
                    //    title: "Editar pregunta",
                    //    message: data,
                    //    size: 'small',
                    //    callback: function () {
                    //        location.reload()
                    //    }
                    //})
                    mensajeGenerico("Aviso", data, "1")
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    $('#modalProvPreguntas').modal('hide');
                    //bootbox.alert({
                    //    title: "Aviso",
                    //    message: `${jqXHR} ${textStatus} ${errorThrown}`,
                    //    size: 'small'
                    //})
                    mensajeGenerico("Aviso", `${jqXHR} ${textStatus} ${errorThrown}`, "")
                })
            }
        } else {
            //bootbox.alert({
            //    title: "Aviso",
            //    message: "Debe de llenar el campo de pregunta",
            //    size: 'small'
            //})
            mensajeGenerico("Aviso", "Debe de llenar el campo de pregunta", "")
        }
        
        return false;
    })
    $("#DeleteProvPreguntas").on('submit', function (dl) {
        dl.preventDefault();
        
    })
    $('#EnviarPreguntas').on('click', function () {
        let data = `__RequestVerificationToken=${$("[name='__RequestVerificationToken']").val()}&`;
        $('#tableProvPreguntas a.edit-item').each(function () {
            data += `IdPregunta=${$(this).attr('data-idpreg').trim()}&`
        })
        data += `id=${$('#IdProveedorRqInvitacion').val()}`
        if ($('#tableProvPreguntas a.edit-item').length > 0) {
            bootbox.confirm({
                title: "<div class='col-12 text-center'>Aviso<div>",
                message: "¿Desea enviar " + ($('#tableProvPreguntas a.edit-item').length>1?"las preguntas":"la pregunta") +"?",
                size: 'small',
                callback: function (res) {
                    if (res) {
                        traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviarPreguntasProveedor, b: data })
                    }
                }
            }).find('.modal-dialog').addClass("modal-dialog-centered");
        } else {
            mensajeGenerico("Aviso", "Aun no se han realizado preguntas", "")
        }

    })
})
function saveEnviarPreguntasProveedor(data) {
    $.post(
        "/PreguntasProveedor/EditListaPregunta/",
        data,
        "json"
    ).done(function (data_) {
        mensajeGenerico("Aviso", data_, "1")
    }).fail(function (jqXHR, textStatus, errorThrown) {
        mensajeGenerico("Aviso", `${jqXHR} ${textStatus} ${errorThrown}`, "1")
    })
}
function showModalView(header, msm) {
    $('#modaldiv').html(modalview(header, msm))
    $('#alertaModal').modal('show')
}
function modalview(title, body) {
    return modal = `<div class="modal fade" id="alertaModal" tabindex="-1" role="dialog" aria-hidden="true">
                      <div class="modal-dialog" style="max-width:500px">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title"><strong>${title}</strong></h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                          <div class="modal-body" style="word-wrap:break-word">
                            <h6><strong>${body}</strong></h6>
                          </div>
                          <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                          </div>
                        </div>
                      </div>
                    </div>`
}