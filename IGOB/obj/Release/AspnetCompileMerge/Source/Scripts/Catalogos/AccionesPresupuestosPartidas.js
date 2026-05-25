$(document).ready(function () {

    var EjercicioFiscal = $("#EjercicioFiscal").val();
    var date = "12/31/" + EjercicioFiscal;
    var lastDate = new Date(date);
    
    $('.table').DataTable({
        scrollX: true,
        "scrollY": "340px"
    });

    $('#MesInicio').datetimepicker({
        language: 'es',
        format: "MM yyyy",
        startDate: new Date(),
        endDate: lastDate,
        pickerPosition: "bottom-left",
        weekStart: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 3,
        minView: 3,
        forceParse: 0,
        pickTime: false,
        inline: false,
        linkField: "IdMesInicio",
        linkFormat: "m"
    });

    $('#MesFinal').datetimepicker({
        language: 'es',
        format: "MM yyyy",
        startDate: new Date(),
        endDate: lastDate,
        pickerPosition: "bottom-left",
        weekStart: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 3,
        minView: 3,
        forceParse: 0,
        pickTime: false,
        inline: false,
        linkField: "IdMesFinal",
        linkFormat: "m"
    });
});

//Abrir Modal saveItem
$('.new-Presupuestos').on('click', function () {
    $("#form-Presupuestos")[0].reset();
    $("#IdPartida").val("");
    $("#IdDependencia,#IdCapitulo,#IdPartida").removeAttr('disabled');

    $('.tableDetails').dataTable().fnClearTable();
    $('.tableDetails').dataTable().fnDestroy();

    var FechaRegistro = new Date().toLocaleString();
    $("#FechaRegistro").val(FechaRegistro);
    $("#PresupuestosModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Partida Presupuestal");

    $(".expand").attr('disabled','disabled');

    $("#PresupuestosModal").modal("show");
});

//Abrir modal editItem
$('#tablePresupuestos').on('click', '.edit-Presupuestos', function () {

    var parametros = {
        IdPresupuestoPartida: $(this).attr('data-prep'),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    cargarTablaDetails(parametros);

    $(".IdPresupuestoPartida").val($(this).attr('data-prep'));
    $("#IdDependencia").val($(this).attr('data-dependencia')).attr('disabled','disabled');
    $("#IdPartida").val($(this).attr('data-idpartida'));
    $("#IdCapitulo").val($(this).attr('data-capitulo'));
    $("#EjercicioFiscal").val($(this).attr('data-ejercicio'));
    $("#FechaRegistro").val($(this).attr('data-fr'));
    $("#MontoPresupuesto").val($(this).attr('data-montoprep'));
    $("#MontoComprometido").val($(this).attr('data-montocomp'));
    $("#MontoEjecutadoTotal").val($(this).attr('data-montoejet'));
    $("#MontoSaldo").val($(this).attr('data-saldo'));
    $("#MontoEconomia").val($(this).attr('data-economia'));
    $("#IdEjercicioFiscal").val($(this).attr('data-idEjercicio'));
    $("#NumeroMinistracion").val($(this).attr('data-numminis').trim());

    GetCapitulo_x_IdPartida($(this).attr('data-idpartida'));

    $("#PresupuestosModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Clave Presupuestal");

    $(".expand").removeAttr('disabled');

    $("#PresupuestosModal").modal("show");
});

$(".expand").on("click", function () {
    $("#add-monto").modal("show");
});

// Confirmar Edición - Creación de PresupuestoPartida
$("#PresupuestosModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-Presupuestos");
    var tipo = $("#form-Presupuestos input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/PresupuestosPartidas/Edit/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#PresupuestosModal").modal("hide");
                    }
                });
            });

    } else{
        $.post("/PresupuestosPartidas/Create/", form.serialize(), "JSON")
            .done(function (response) {
                bootbox.alert({
                    size: "small",
                    title: response.success ? "Aviso" : "Error",
                    message: response.m
                });

                if (response.success) {
                    $(".expand").removeAttr('disabled');
                    $("#PresupuestosModal input[type=submit]").attr('disabled', 'disabled');
                    $(".IdPresupuestoPartida").val(response.id);
                }
            })
            .fail(function (resp) {
                alert(resp.m);
            });
    }
    return false;
});

function getMontoSaldo(IdPresupuestoPartida) {

    var parametros = {
        IdPresupuestoPartida: IdPresupuestoPartida,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.post("/PresupuestosPartidas/getMontoSaldo/", parametros, "JSON").
        done(function (data) {
            $("#MontoSaldo").val(data.m);
        }).fail(function (data) {
            console.log(data);
        });
}

// Confirmar Creación de ClavesPresupuestalesDetalles
$("#Detalles").on('submit', function (e) {
    e.preventDefault();

    var form = $("#Detalles");
    var Inicio = parseInt($("#IdMesInicio").val());
    var Final = parseInt($("#IdMesFinal").val());
    var IdPresupuestopartida = $(".IdPresupuestoPartida").val();

    if (Inicio > Final) {
        bootbox.alert({
            size: "small",
            title: "Aviso",
            message: "El Mes Inicial no puede ser mayor al final"
        });
    } else {
        $.post("/PresupuestosPartidas/saveDetails/", form.serialize(), "JSON")
            .done(function (response) {

                var parametros = {
                    IdPresupuestoPartida: IdPresupuestopartida,
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                };

                cargarTablaDetails(parametros);
                getMontoSaldo(IdPresupuestopartida);

                bootbox.alert({
                    size: "small",
                    title: "Aviso",
                    message: response.m,
                    callback: function () {
                        $("#add-monto").modal('hide');
                        $("#Detalles")[0].reset();
                    }
                });

            });
    }
});

// Alert - Modal Eliminar
$('#tablePresupuestos').on('click', ".delete-Presupuestos", function () {

    var IdPresupuestoPartida = $(this).attr('data-prep');

    bootbox.confirm({
        title: "Confirmar",
        message: "¿Desea eliminar la partida presupuestal?",
        callback: function (e) {
            if (e) {
                var parametros = {
                    IdPresupuestoPartida: IdPresupuestoPartida,
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                };

                $.post("/PresupuestosPartidas/Delete/", parametros, "JSON")
                    .done(function (response) {
                        location.reload();
                    })
                    .fail(function (resp) {
                        console.log(resp);
                    })
                    .always(function () {
                        $("#DeletePresupuestosModal").modal("hide");
                    });
            }
        }
    });
});

$('#form-Presupuestos').on("change","#IdCapitulo", function () {
    getPartidas(0);
});

function GetCapitulo_x_IdPartida(IdPartida) {
    $.get(
        "/PresupuestosPartidas/GetCapitulo_x_IdPartida", { IdPartida: IdPartida }, "JSON")
        .done(function (response) {
            $.each(response, function (index, row) {

                var CampoId = row["IdCapitulo"];

                $('#IdCapitulo').attr('disabled', 'disabled');
                $("#IdCapitulo").val(CampoId).attr('selected', true);

                $.get("/PresupuestosPartidas/getPartida_x_IdPartida", { IdPartida: IdPartida }, "JSON")
                    .done(function (response) {
                        $.each(response, function (index, row) {

                            var CampoIdP = row["Idpartida"];
                            var CAmpoValP = row["Partida"];

                            $('#IdPartida').empty().attr('disabled', 'disabled');
                            $('#IdPartida').append("<option value=" + CampoIdP + " selected >" + CAmpoValP + "</option>");
                        });
                    });
            });
        });
}

function getPartidas(idcap) {
    let idCapitulo = $('#IdCapitulo').val();
    $.get("/PresupuestosPartidas/getAllPartidas_x_IdCapitulo", { pIdCapitulo: idCapitulo }, "JSON").
        done(function (response) {
            $('#IdPartida').empty();
            $('#IdPartida').append(`<option value="0">Seleccionar</option>`);
            $.each(response.objeto, function (index, row) {
                if (idcap == 0)
                    $('#IdPartida').append(`<option value="${row.IdPartida}">${row.Partida}</option>`);
                else {
                    if (row.IdPartida == idcap.trim())
                        $('#IdPartida').append(`<option value="${row.IdPartida}" selected="selected">${row.Partida}</option>`);
                    else
                        $('#IdPartida').append(`<option value="${row.IdPartida}">${row.Partida}</option>`);                   
                }
            });
    });
}

function cargarTablaDetails(parametros) {
    $.post('/PresupuestosPartidas/GetClavesPresupuestalesDetalles_x_IdPresupuestoPartida', parametros, "JSON").
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
                data: data.r,
                columns: [
                    {
                        mRender: function (data, type, row) {
                            return '<button type="button" class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="AbrirEliminarModalDetalles(' + row.IdClavePresupuestalDetalle + ')"><span class="fa fa-trash-o"></span></button></div>';
                        }
                    },
                    { 'data': 'OrigenRecurso', sortable: false },
                    { 'data': 'ClavePresupuestal', sortable: false },
                    { 'data': 'MontoPresupuestado', 'render': function (MontoPresupuestado) { return "$ " + MontoPresupuestado;}, sortable: false },
                    { 'data': 'MesInicial', sortable: false },
                    { 'data': 'MesFinal', sortable: false }
                ]
            });
            $('.sorting_asc').removeClass('sorting_asc');
        });
}

function AbrirEliminarModalDetalles(IdClavePresupuestalDetalle) {

    bootbox.confirm({
        size: "small",
        title: "Confimar",
        message: "¿Desea eliminar clave presupuestal?",
        callback: function (e) {
            if (e) {
                var parametros = {
                    IdClavePresupuestalDetalle: IdClavePresupuestalDetalle,
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                };

                $.post("/PresupuestosPartidas/EliminarClavePresupuestalDetalles", parametros, "JSON")
                    .done(function (response) {
                        var IdPresupuestoPartida = $(".IdPresupuestoPartida").val();
                        var parametros = {
                            IdPresupuestoPartida: IdPresupuestoPartida,
                            __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                        };

                        $("#EliminarModalDetalles").modal("hide");

                        getMontoSaldo(IdPresupuestoPartida);
                        cargarTablaDetails(parametros);
                    });
            }
        }
    });
}