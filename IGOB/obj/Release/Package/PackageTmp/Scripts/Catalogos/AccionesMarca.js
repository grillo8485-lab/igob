$(document).ready(function () {
    $('.table').DataTable({
        scrollY: 340
    });
});

//Abrir Modal saveItem
$('.new-marca').on('click', function () {
    $(".form-control").val("");
    $("#MarcasModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Marca");

    $("#MarcasModal").modal("show");
});

//Abrir modal editItem
$('#tableCatalogos').on('click', '.edit-marca', function () {
    $("#IdMarca").val($(this).attr('id'));
    $("#Marca").val($(this).attr('data-title').trim());
    $("#Abreviatura").val($(this).attr('data-abreviatura').trim());
    $("#MarcasModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Marca");

    $("#MarcasModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#MarcasModal").on('submit', function (e) {
    e.preventDefault();
    var form = $(".data-form");
    var tipo = $(".data-form input[type=submit]").prop("value");

    var token = $("[name='__RequestVerificationToken']").val();

    if (tipo === "Editar") {
        $.post("/Marcas/Edit/" , form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#CertModal").modal("hide");
                    }
                });
            });
    } else {
        $.post("/Marcas/Create/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#CertModal").modal("hide");
                    }
                });
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableCatalogos').on('click', ".delete-marca", function () {

    var IdMarca = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar la marca <strong>" + $(this).attr('data-title') +"</strong> ?",
        callback: function (e) {
            if (e) {
                $.post("/Marcas/Delete/", { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), Id: IdMarca }, "JSON")
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
