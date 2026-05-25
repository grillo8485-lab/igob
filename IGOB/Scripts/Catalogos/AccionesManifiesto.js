$(document).ready(function () {
    $('.table').DataTable({
        scrollY: 340,
        sort: false
    });
});

//Abrir Modal saveItem
$('.new-Manifiesto').on('click', function () {
    $("#form-Manifiesto")[0].reset();
    $("#ManifiestoModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nuevo Manifiesto");
    $("#ManifiestoModal").modal("show");
});

//Abrir modal editItem
$('#tableManifiesto').on('click', '.edit-Manifiesto', function () {

    $("#IdManifiesto").val($(this).attr('id'));
    $("#IdGobierno").val($(this).attr('data-gob'));
    $("#Manifiesto").val($(this).attr('data-title'));
    $("#ManifiestoModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Manifiesto");

    $("#ManifiestoModal").modal("show");
});

// Confirmar Edición - Creación de Actividad
$("#ManifiestoModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-Manifiesto");
    var tipo = $("#form-Manifiesto input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/Manifiestos/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                alert(resp);
            })
            .always(function () {
                $("#ManifiestoModal").modal("hide");
                console.log(form.serialize());
            });
    } else {
        $.post("/Manifiestos/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableManifiesto').on('click', ".delete-Manifiesto", function () {
    $(".IdManifiesto").val($(this).attr('id'));
    $("#DeleteManifiestoModal input[type=submit]").prop("value", "Eliminar");
    $(".modal-title").html("Eliminar Manifiesto");


    $("#titleManifiesto").html("¿Desea Eliminar el registro " + $(this).attr('data-title') + " ?");
    $("#DeleteManifiestoModal").modal("show");
});

//Confirmar eliminación de Actividad
$("#DeleteManifiestoModal").on('submit', function (e) {
    e.preventDefault();
    var Manifiesto = $(".IdManifiesto").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/Manifiestos/Delete/", { __RequestVerificationToken: token, id: Manifiesto }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function () {
            $("#DeleteManifiestoModal").modal("hide");
        });
});
