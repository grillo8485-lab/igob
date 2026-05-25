$(document).ready(function () {
    $('#tableCondicionPago').DataTable();
});

//Abrir modal editItem
$('#tableCondicionPago').on('click', '.edit-item', function () {

    $("#IdCondicion").val($(this).attr('data-idCond').trim());
    $("#IdTipoCondicion").val($(this).attr('data-idTipoCond').trim());
    $("#Condicion").val($(this).attr('data-cond').trim());
    $("#Activo").val($(this).attr('data-activ').trim());

    $("#submit").prop("value", "Editar");
    $('#formEditCreate').html('Editar Condiciones Pago');
    $("#modalCondicionesPago").modal("show");
});

$('#create-item').on('click', function () {
    $("#submit").prop("value", "Guardar");
    $('#formEditCreate').html('Nueva Condiciones Pago');
    $("#modalCondicionesPago").modal("show");
});

//Modal Confirmar Edicion de Eliminacion
$('#tableCondicionPago').on('click', '.delet-item', function (d) {
    var IdCond = $(this).attr('data-idcond');


    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar la condición de pago <strong>" + $(this).attr('data-cond').trim() + "</strong>?",
        callback: function (e) {
            if (e) {
                $.post('/CondicionesPago/Delete/', { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: IdCond }, "JSON")
                    .always(function (data) {
                        bootbox.alert({
                            size: "small",
                            title: data.success ? "Aviso" : "Error",
                            message: data.m,
                            callback: function () {
                                if (data.success)
                                    location.reload();
                            }
                        });
                    });
            }
        }
    });

});

$("#modalCondicionesPago").on('submit', function (e) {
    e.preventDefault();
    let datos = $('.FormCondiciones').serialize();
    var tipo = $("#submit").prop("value");

    if (tipo === "Editar") {
        $.post("/CondicionesPago/Edit/",datos, "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#modalCondicionesPago").modal("hide");
                    }
                });
            });
    }
    if (tipo === "Guardar") {
        $.post("/CondicionesPago/Create/",datos, "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#modalCondicionesPago").modal("hide");
                    }
                });
            });
    }
    return false;
});