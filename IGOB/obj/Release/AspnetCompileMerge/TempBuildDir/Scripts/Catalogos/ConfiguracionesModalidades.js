$(document).ready(function () {
    $('#ConfiguracionesModalidadesTable').DataTable({
        scrollY: "280px",
        scrollX: true,
        scrollCollapse: true,
        bAutoWidth: false
    });
});
function validarFormulario() {
    jQuery.validator.messages.required = 'Esta campo es obligatorio.';
    jQuery.validator.messages.number = 'Esta campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    var validado = $("#configuracionesModalidadesForm").valid();
    if (validado) {
        saveConfiguracionesModalidades();
    }
}

function menssage(title, cuerpo) {
    $(".modal-title").html(title);
    $("#titlePopUp").html(cuerpo);
    $("#Pop-Up").modal("show");
}
function altaConfiguracionesModalidades() {
    $("#div_configuracionesModalidades").html("");
    $("#div_configuracionesModalidades").load("/ConfiguracionesModalidades/getAllModelo/", {
        IdConfiguracionModalidad: 0
    });
    $("#ConfiguracionesModalidadesModal").modal("show");
}



function saveConfiguracionesModalidades() {
    var id = parseInt($("#IdConfiguracionModalidad").val());
    var form = $("#configuracionesModalidadesForm");
    var url_ = "/ConfiguracionesModalidades/saveConfiguracionesModalidades/";
    if (id != 0) {
        url_ = "/ConfiguracionesModalidades/saveEditConfiguracionesModalidades/";
    }
    $.post(url_, form.serialize(), "JSON")
        .done(function (response) {
            if (response.success) {
                $('#ConfiguracionesModalidadesTable').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#ConfiguracionesModalidadesTable').dataTable().fnDestroy();

                var table = $('#ConfiguracionesModalidadesTable').DataTable({
                    scrollY: "280px",
                    scrollX: true,
                    scrollCollapse: true,
                    bAutoWidth: false,
                    data: response.lst,
                    columnDefs: [
                        { targets: [-1, -2, -3, -4, -5, -6, -7, -8], className: "dt-body-right" },

                    ],
                    "columns": cargarColumnas()

                });
               
                $("#ConfiguracionesModalidadesModal").modal("hide");
                menssage("Alta Configuraciones Modalidades", "Datos actualizados correctamente");
            }
            else {
                menssage("Alta Configuraciones Modalidades", "Error: " + response.mensaje);
            }
            
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function () {
            
        });
}

function cargarColumnas() {
  
        dataRow = [
            {
                mRender: function (data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarConfiguracionModalidad(' + row.IdConfiguracionModalidad + ')"><span class="fa fa-pencil"></span></button>' +
                        '<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarConfiguracionModalidad(' + row.IdConfiguracionModalidad + ')"><span class="fa fa-trash-o"></span></button></div>'
                }
            },
            { "data": "Tiempo", sortable: true },
            { "data": "TipoLicitacion", sortable: true},
            { "data": "ModalidadesLicitaciones", sortable: true},
            { "data": "PublicacionConvocatoriaDia", sortable: true},
            { "data": "DisposicionBasesDias", sortable: true},
            { "data": "LimiteEnvioPreguntasHoras", sortable: true},
            { "data": "LimiteEnvioRespuestasHoras", sortable: true},
            { "data": "AclaracionDudasDias", sortable: true},
            { "data": "EnvioProuestaTecEcoDias", sortable: true},
            { "data": "EntregaDictamenDias", sortable: true},
            { "data": "FalloDias", sortable: true }
        ];

   

    return dataRow;
}

function editarConfiguracionModalidad(id_) {
    $("#div_configuracionesModalidades").html("");
    $("#div_configuracionesModalidades").load("/ConfiguracionesModalidades/getAllModelo/", {
        IdConfiguracionModalidad: id_
    });
    $("#ConfiguracionesModalidadesModal").modal("show");
}

function porcesoEliminarConfiguracionModalidad(id_) {
    var token = $("[name='__RequestVerificationToken']").val();

    var parametros = {
        IdConfiguracionModalidad: id_,
        __RequestVerificationToken: token
    };
    $.ajax({
        data: parametros,
        url: '/ConfiguracionesModalidades/deleteConfiguracionesModalidades/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $('#ConfiguracionesModalidadesTable').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#ConfiguracionesModalidadesTable').dataTable().fnDestroy();

                var table = $('#ConfiguracionesModalidadesTable').DataTable({
                    scrollY: "280px",
                    scrollX: true,
                    scrollCollapse: true,
                    bAutoWidth: false,
                    data: response.lst,
                    columnDefs: [
                        { targets: [-1, -2, -3, -4, -5, -6, -7, -8], className: "dt-body-right" },

                    ],
                    "columns": cargarColumnas()

                });

                
                menssage("Eliminar Configuraciones Modalidades", "Datos eliminados correctamente");
            }
            else {
                menssage("Eliminar Configuraciones Modalidades", "Error: " + response.mensaje);
            }

        }
    });
}

function eliminarConfiguracionModalidad(id_) {
    bootbox.confirm({
        title: "Configuración de modalidades",
        closeButton: false,
        message: "¿Desea eliminar la configuración?",
        buttons: {
            confirm: {
                label: 'SI',
                className: "btn-secondary"
            },
            cancel: {
                label: 'No',
                className: "btn-secondary"
            }
        },
        callback: function (result) {
            if (result) {
                porcesoEliminarConfiguracionModalidad(id_);
            }
           
        }
    });

}