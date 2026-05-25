$(document).ready(function () {
    cargarTabla();

    $('.tableDetails').DataTable({
        sort: false,
        lengthChange: false,
        searching: false,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
        }
    });
});

function addPartida() {

    var Idpartida = $("#IdPartida").val();

    if (Idpartida === '') {
        bootbox.alert({
            size: "small",
            title: "Aviso",
            message: "Debe de seleccionar una partida"
        });
        return false;
    }
    var parametros = {
        IdPartida: Idpartida,
        IdActividadEconomica: $("#IdActividadEconomica").val(),
        Activo: true,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.post("/ActividadesEconomicas/AddPartida_x_IdActividadEconomica", parametros, "JSON").
        done(function (data) {

            if (data.success) {
                var parametros = {
                    IdActividadEconomica: $("#IdActividadEconomica").val(),
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                };

                cargarTablaDetails(parametros);

            } else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: data.mensaje
                });
            }


        }).fail(function (data) {
            console.log(data);
        });

}

//Abrir Modal saveItem
$('.new-AE').on('click', function () {
    $("#form-AE input[type=text], .form-control, #IdActividadEconomica").val("");
    $("#Codigo, #Descripcion").removeAttr('disabled');

    $("#IdPartida, .expand").attr('disabled', 'disabled');

    var parametros = {
        IdActividadEconomica: 0,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    cargarTablaDetails(parametros);

    $("#AEModal input[type=submit]").prop("value", "Guardar");
    $(".modal-AE").html("Nueva Actividad Economica");
    $("#AEModal").modal("show");
});

//Abrir modal editItem
$('#tableAE').on('click', '.edit-AE', function () {

    var parametros = {
        IdActividadEconomica: $(this).attr('id'),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    cargarTablaDetails(parametros);

    $("#Codigo, #Descripcion").attr('disabled', 'disabled');
    $("#IdPartida, .expand").removeAttr('disabled');

    $("#IdActividadEconomica").val($(this).attr('id'));
    $("#Codigo").val($(this).attr('data-Codigo'));
    $("#Descripcion").val($(this).attr('data-title'));
    $("#Activo").val($(this).attr('data-Activo'));


    $("#AEModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Registro");

    $("#AEModal").modal("show");
});

// Confirmar Edición - Creación de Actividad
$("#AEModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-AE");
    var tipo = $("#form-AE input[type=submit]").prop("value");

    var parametros = {
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        Descripcion: $("#Descripcion").val(),
        Activo: true,
        IdActividadEconomica: $("#IdActividadEconomica").val(),
        Codigo: $("#Codigo").val()
    };

    if (tipo === "Editar") {
        $.post("/ActividadesEconomicas/Edit/", parametros, "JSON")
            .done(function (response) {
                cargarTabla();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function () {
                $("#AEModal").modal("hide");
            });
    } else {
        $.post("/ActividadesEconomicas/Create/", form.serialize(), "JSON")
            .done(function (response) {

                bootbox.alert({
                    size: "small",
                    title: "Aviso",
                    message: "Actividad económica agregada",
                    callback: function () {
                        $(".expand, #IdPartida").removeAttr('disabled');
                        $("#Descripcion, #Codigo").attr("disabled", "disabled");
                        $("#saveEdit").attr('disabled', 'disabled');
                        $("#IdActividadEconomica").val(response.mensaje);
                    }
                });

                var parametros = {
                    IdActividadEconomica: $("#IdActividadEconomica").val(),
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                };

                cargarTabla();

            })
            .fail(function (resp) {
                console.log(resp.mensaje);
            });
    }
    return false;
});

function cargarTablaDetails(parametros) {
    $.post('/ActividadesEconomicas/GetPartidasActividadesEconomicas_x_IdActividadEconomica', parametros, "JSON").
        done(function (data) {
            $('.tableDetails').dataTable({
                "bDestroy": true
            }).fnDestroy();

            $('.tableDetails').dataTable().fnDestroy();

            $(".tableDetails").DataTable({
                order: [[1, "asc"]],
                searching: false,
                ordering: false,
                paging: false,
                sortable: false,
                bInfo: false,
                data: data.mensaje,
                columnDefs: [
                    {
                        "width": "20%",
                        "className": 'dt-body-center',
                        "targets": 0
                    }
                ],
                columns: [
                    {
                        mRender: function (data, type, row) {
                            return '<button type="button" class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="AbrirEliminarModalDetalles(' + row.IdPartidaActEconomica + ')"><span class="fa fa-trash-o"></span></button></div>';
                        }
                    },
                    { 'data': 'Partida', sortable: false }


                ]
            });

            $('.sorting_asc').removeClass('sorting_asc');
        });
}

function AbrirEliminarModalDetalles(IdPartidaActEconomica) {

    $(".IdPartidaActEconomica").val(IdPartidaActEconomica);
    $("#titleIdPartidaActEconomica").html("¿ Eliminar Partida ?");
    $(".DeleteDetails").prop("value", "Eliminar");
    $(".modal-title").html("Eliminar Partida");
    $("#EliminarModalDetalles").modal("show");
}

function cargarTabla() {

    $.post('/ActividadesEconomicas/GetActividadesEconomicas', "JSON").
        done(function (data) {
            $('#tableAE').dataTable({
                "bDestroy": true
            }).fnDestroy();

            $('#tableAE').dataTable().fnDestroy();

            $("#tableAE").DataTable({
                data: data.mensaje,
                scrollY: 340,
                scrollCollapse: true,
                columnDefs: [
                    {
                        "width": "5.67%",
                        "className": 'dt-body-center',
                        "targets": [0, 1]
                    }
                ],
                columns: [
                    {

                        mRender: function (data, type, row) {
                            return '<div class="form-group" style="min-width:100px;text-align:center"><a title = "Eliminar registro" id = "' + row.IdActividadEconomica + '" data-title="' + row.Descripcion + '" class="btn btn-secondary btn-circle delete-AE btn-sm" > <span class="icon-garbage-2"></span></a > <a title="Editar registro" id="' + row.IdActividadEconomica + '" data-codigo="' + row.Codigo + '" data-title="' + row.Descripcion + '" data-activo="' + row.Activo + '" class="btn btn-secondary btn-circle edit-AE btn-sm"><span class="icon-edit"></span></a></div > ';
                        }
                    },
                    { 'data': 'Codigo' },
                    { 'data': 'Descripcion'}
                ]
            });
            
        });

}

$("#EliminarModalDetalles").on('submit', function (e) {
    e.preventDefault();

    var parametros = {
        IdPartidaActEconomica: $(".IdPartidaActEconomica").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.post("/ActividadesEconomicas/EliminarPartidaActEconomica", parametros, "JSON")
        .done(function (response) {

            var parametros = {
                IdActividadEconomica: $("#IdActividadEconomica").val(),
                __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
            };

            $("#EliminarModalDetalles").modal("hide");
            cargarTablaDetails(parametros);
        });
});

//Abrir AlertModal Eliminar
$('#tableAE').on('click', ".delete-AE", function () {
    var ActividadEconomica = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar la actividad económica <strong>" + $(this).attr('data-title') + "</strong>?",
        callback: function (e) {
            if (e) {

                $.post("/ActividadesEconomicas/Delete/" + ActividadEconomica, { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: ActividadEconomica }, "JSON")
                    .done(function (response) {
                        cargarTabla();
                        //location.reload();
                    })
                    .fail(function (resp) {
                        console.log(resp);
                    })
                    .always(function () {
                        $("#DeleteAEModal").modal("hide");
                    });
            }
        }

    });
});

