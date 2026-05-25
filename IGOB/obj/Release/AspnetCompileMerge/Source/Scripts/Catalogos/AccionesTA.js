$(document).ready(function () {
    $('#tableTA').DataTable({
        scrollY: 340,
        scrollX: true
    });
});

//Abrir Modal saveItem
$('.new-TA').on('click', function () {
    $("input[type=text]").val("");
    $(".form-control").val("");
    $("#TAModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Guardar Tipo de Adjudicación");
    $("#TAModal").modal("show");
});

//Abrir modal editItem
$('#tableTA').on('click', '.edit-TA', function () {

    $("#IdTipoAdjudicacion").val($(this).attr('id'));
    $("#TipoAdjudicacion").val($(this).attr('data-title'));
    $("#Abreviatura").val($(this).attr('data-abreviatura').trim());
    $("#MontoMinimo").val($(this).attr('data-MMin'));
    $("#MontoMaximo").val($(this).attr('data-MMax'));

    $("#TAModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Registro");

    $("#TAModal").modal("show");
});

// Confirmar Edición - Creación de Actividad
$("#TAModal").on('submit', function (e) {
    e.preventDefault();
    var form = $(".data-form");
    var tipo = $("#TAModal input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/ModalidadAdjudicacionesDirectas/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function () {
                $("#TAModal").modal("hide");
            });
    } else {
        $.post("/ModalidadAdjudicacionesDirectas/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: "Error al procesar la solicitud"
                });
            })
            .always(function (resp) {
                $("#TAModal").modal("hide");
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableTA').on('click', ".delete-TA", function () {
    $(".IdTipoAdjudicacion").val($(this).attr('id'));
    $("#DeleteTAModal input[type=submit]").prop("value", "Eliminar");


    $("#titleTA").html("¿Desea Eliminar el registro " + $(this).attr('data-title') + " ?");
    $("#DeleteTAModal").modal("show");
});

//Confirmar eliminación de Actividad
$("#DeleteTAModal").on('submit', function (e) {
    e.preventDefault();
    var IdTipoAdjudicacion = $(".IdTipoAdjudicacion").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/ModalidadAdjudicacionesDirectas/Delete/", { __RequestVerificationToken: token, id: IdTipoAdjudicacion }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            bootbox.alert({
                size: "small",
                title: "Error",
                message: "Error al procesar la solicitud"
            });
        })
        .always(function () {
            $("#DeleteTAModal").modal("hide");
        });
});
