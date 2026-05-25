$(document).ready(function () {
    $('.table').DataTable({
        scrollY: 340,
        sort: false
    });
});

//Abrir Modal saveItem
$('.new-DI').on('click', function () {
    $(".form-control").val("");
    $("#DIModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nuevo Día Inhabil");

    $("#DIModal").modal("show");
});

//Abrir modal editItem
$('#tableDI').on('click', '.edit-DI', function () {
    $("#IdDiaInhabil").val($(this).attr('id'));
    $("#Evento").val($(this).attr('data-title').trim());
    $("#Fecha").val($(this).attr('data-abreviatura').trim());
    $("#DIModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Día Inhabil");

    $("#DIModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#DIModal").on('submit', function (e) {
    e.preventDefault();
    var form = $(".data-form");
    var tipo = $(".data-form input[type=submit]").prop("value");

    var token = $("[name='__RequestVerificationToken']").val();

    if (tipo === "Editar") {
        $.post("/DiasInhabiles/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function (resp) {
                $("#DIModal").modal("hide");
                console.log(resp);
            });
    } else {
        $.post("/DiasInhabiles/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function () {
                $("#DIModal").modal("hide");
                console.log(form.serialize());
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableDI').on('click', ".delete-DI", function () {
    $(".IdDiaInhabil").val($(this).attr('id'));
    $(".modal-title").html("Eliminar Día Inhabil");

    $("#titleDI").html(`¿Desea Eliminar Día Inhabil "${$(this).attr('data-title')}"?`);
    $("#DeleteDIModal input[type=submit]").prop("value", "Eliminar");

    $("#DeleteDIModal").modal("show");
});

//Confirmar eliminación de Marca
$("#DeleteDIModal").on('submit', function (e) {
    e.preventDefault();
    var id = $(".IdDiaInhabil").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/DiasInhabiles/Delete/", { __RequestVerificationToken: token, id: id }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function () {
            $("#DeleteDIModal").modal("hide");
        });
});