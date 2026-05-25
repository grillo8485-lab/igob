$(document).ready(function () {
    $('#tableUL').DataTable({
        scrollY: 340
    });
});

//Abrir Modal saveItem
$('.new-UL').on('click', function () {
    $(".data-form")[0].reset();
    $("#ULModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Unidad Licitadora");

    $("#ULModal").modal("show");
});

//Abrir modal editItem
$('#tableUL').on('click', '.edit-UL', function () {
    $("#IdUnidadLicitadora").val($(this).attr('id'));
    $("#UnidadLicitadora").val($(this).attr('data-title').trim());
    $("#IdDependencia").val($(this).attr('data-dependencia').trim());

    $("#ULModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Unidad Licitadora");

    $("#ULModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#ULModal").on('submit', function (e) {
    e.preventDefault();
    var form = $(".data-form");
    var tipo = $("#ULModal input[type=submit]").prop("value").trim();
    if (tipo === "Editar") {
        $.post("/UnidadesLicitadoras/Edit/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#ULModal").modal("hide");
                    }
                });
            });
    } else {
        $.post("/UnidadesLicitadoras/Create/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#ULModal").modal("hide");
                    }
                });
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableUL').on('click', ".delete-UL", function () {
    var IdUnidadLicitadora = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar la unidad de medidad <strong>" + $(this).attr('data-title') + "</strong> ?",
        callback: function (e) {
            if (e) {
                $.post("/UnidadesLicitadoras/Delete/", { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), Id: IdUnidadLicitadora }, "JSON")
                    .always(function (data) {
                        bootbox.alert({
                            size: "small",
                            title: data.success ? "Aviso" : "Error",
                            message: data.m,
                            callback: function () {
                                if (data.success)
                                    location.reload();
                                else
                                    $("#ULModal").modal("hide");
                            }
                        });
                    });
            }
        }
    });
});

