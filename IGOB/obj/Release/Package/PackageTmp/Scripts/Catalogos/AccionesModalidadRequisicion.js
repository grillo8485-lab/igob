$(document).ready(function () {
    $('.table').DataTable({
        scrollY: 340
    });
});

//Abrir Modal saveItem
$('.new-modalidadrequisicion').on('click', function () {
    $(".form-control").val("");
    $("#ModalidadRequisicionModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Modalidad requisicion");

    $("#ModalidadRequisicionModal").modal("show");
});

//Abrir modal editItem
$('#tableMR').on('click', '.edit-ModalidadRequisicion', function () {
    $("#IdModalidadRequisicion").val($(this).attr('id'));
    $("#ModalidadRequisicion").val($(this).attr('data-title').trim());
    $("#Abreviatura").val($(this).attr('data-abreviatura').trim());
    $("#Activo").val($(this).attr('data-activo').trim());

    $("#ModalidadRequisicionModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Modalidad Requisicion");

    $("#ModalidadRequisicionModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#ModalidadRequisicionModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-MR");
    var tipo = $("#form-MR input[type=submit]").prop("value");


    if (tipo === "Editar") {
        $.post("/ModalidadRequisiciones/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                alert(resp);
            })
            .always(function () {
                $("#ModalidadRequisicionModal").modal("hide");
                console.log(form.serialize());

            });
    } else {
        $.post("/ModalidadRequisiciones/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                alert(resp);
                console.log(resp);
            })
            .always(function () {
                $("#ModalidadRequisicionModal").modal("hide");
                console.log(form.serialize());
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableMR').on('click', ".delete-ModalidadRequisicion", function () {
    $(".IdModalidadRequisicion").val($(this).attr('id'));
    $(".modal-title").html("Eliminar Modalidad requisicion");

    $("#titleModalidadRequisicion").html("¿Desea Eliminar la Modalidad Requisicion " + $(this).attr('data-title') + " ?");
    $("#DeleteModalidadRequisicionModal input[type=submit]").prop("value", "Eliminar");

    $("#DeleteModalidadRequisicionModal").modal("show");
});

//Confirmar eliminación de Marca
$("#DeleteModalidadRequisicionModal").on('submit', function (e) {
    e.preventDefault();
    var IdModalidadRequisicion = $(".IdModalidadRequisicion").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/ModalidadRequisiciones/Delete/", { __RequestVerificationToken: token, Id: IdModalidadRequisicion }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            alert(resp);
        })
        .always(function () {
            $("#DeleteModalidadRequisicionModal").modal("hide");
        });
});