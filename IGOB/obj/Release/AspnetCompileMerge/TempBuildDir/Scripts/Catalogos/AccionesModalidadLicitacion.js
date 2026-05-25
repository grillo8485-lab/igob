$(document).ready(function () {
    $('.table').DataTable({
        scrollY: 340
    });
});

//Abrir Modal saveItem
$('.new-modalidadlicitacion').on('click', function () {
    $(".form-control").val("");
    $("#ModalidadLicitacionModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva modalidad licitación");

    $("#ModalidadLicitacionModal").modal("show");
});

//Abrir modal editItem
$('#tableML').on('click', '.edit-modalidadlicitacion', function () {

    $("#IdModalidadLicitacion").val($(this).attr('id'));
    $("#ModalidadLicitacion").val($(this).attr('data-title').trim());
    $("#Abreviatura").val($(this).attr('data-abreviatura').trim());
    $("#Activo").val($(this).attr('data-activo'));

    $("#ModalidadLicitacionModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar modalidad licitación");

    $("#ModalidadLicitacionModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#ModalidadLicitacionModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-ML");
    var tipo = $("#form-ML input[type=submit]").prop("value");

    var token = $("[name='__RequestVerificationToken']").val();

    if (tipo === "Editar") {
        $.post("/ModalidadLicitaciones/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                alert(resp);
            })
            .always(function () {
                $("#ModalidadLicitacionModal").modal("hide");
            });
    } else {
        $.post("/ModalidadLicitaciones/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                alert(resp);
                console.log(resp);
            })
            .always(function () {
                $("#ModalidadLicitacionModal").modal("hide");
                //console.log(form.serialize());
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableML').on('click', ".delete-modalidadlicitacion", function () {
    $(".IdModalidadLicitacion").val($(this).attr('id'));
    $(".modal-title").html("Eliminar modalidad licitación");

    $("#titleModalidadLicitacion").html("¿Desea eliminar la modalidad licitación " + $(this).attr('data-title') + " ?");
    $("#DeleteModalidadLicitacionModal input[type=submit]").prop("value", "Eliminar");

    $("#DeleteModalidadLicitacionModal").modal("show");
});

//Confirmar eliminación de Marca
$("#DeleteModalidadLicitacionModal").on('submit', function (e) {
    e.preventDefault();
    var IdModalidadLicitacion = $(".IdModalidadLicitacion").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/ModalidadLicitaciones/Delete/", { __RequestVerificationToken: token, Id: IdModalidadLicitacion }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            alert(resp);
        })
        .always(function () {
            $("#DeleteModalidadLicitacionModal").modal("hide");
        });
});