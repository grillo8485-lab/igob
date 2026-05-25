$(document).ready(function () {
    $('.table').DataTable();
});

//Abrir Modal saveItem
$('.new-Cap').on('click', function () {
    $("input[type=text]").val("");
    $(".form-control").val("");
    $("#CapModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nuevo Capítulo");
    $("#CapModal").modal("show");
});

//Abrir modal editItem
$('#tableCap').on('click', '.edit-Cap', function () {
    $("#Capitulo").val($(this).attr('data-Capitulo'));
    $("#ClaveCapitulo").val($(this).attr('data-title'));
    $("#IdCapitulo").val($(this).attr('id'));
    $("#Activo").val($(this).attr('data-Activo'));

    $("#CapModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Capítulo");

    $("#CapModal").modal("show");
});


// Confirmar Edición - Creación del Capitulo
$("#CapModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-Cap");
    var tipo = $("#form-Cap input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/Capitulos/Edit/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#CapModal").modal("hide");
                    }
                });
            });
    } else {
        $.post("/Capitulos/Create/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#CapModal").modal("hide");
                    }
                });
            });
    }
    return false;
});

// Alert - Modal Eliminar
$('#tableCap').on('click', ".delete-capitulo", function () {
    var IdCapitulo = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar el capítulo <strong>" + $(this).attr("data-title") + "</strong> ?",
        callback: function (e) {
            if (e) {

                $.post("/Capitulos/Delete/" + IdCapitulo, { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: IdCapitulo }, "JSON")
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


