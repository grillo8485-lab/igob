//Proveedores Accionistas

$(document).ready(function () {
    $('#tablePA').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false

    });
});

$("#Persona").autocomplete({
    minLength: 2,
    mustMatch: true,
    source: function (request, response) {
        $.ajax({
            url: '/ProveedoresAccionistas/getPersonas',
            dataType: 'JSON',
            data: { term: $("#Persona").val() },
            success: function (data) {
                response($.map(data, function (item) {
                    return { label: item.Nombres + " " + item.Apellidos, value: item.Nombres + " " + item.Apellidos, id: item.IdPersona };
                }))
            },
            error: function (data) {
                alert("Error");
            }
        });
    },
    select: function (e, ui) {
        $("#IdPersona").val(ui.item.id);
    },
    change: function (e, ui) {
        if (!(ui.item)) e.target.value = "";
    }
});

//$("#Proveedor").autocomplete({
//    minLength: 2,
//    mustMatch: true,
//    source: function (request, response) {
//        $.ajax({
//            url: '/ProveedoresAccionistas/getProveedores',
//            dataType: 'JSON',
//            data: { term: $("#Proveedor").val() },
//            success: function (data) {
//                response($.map(data, function (item) {
//                    return { label: item.NombreComercial, value: item.NombreComercial, id: item.IdProveedor };
//                }))
//            },
//            error: function (data) {
//                alert("Error");
//            }
//        });
//    },
//    select: function (e, ui) {
//        $("#IdProveedor").val(ui.item.id);
//    },
//    change: function (e, ui) {
//        if (!(ui.item)) e.target.value = "";
//    }
//});


//Abrir Modal saveItem
$('.new-PA').on('click', function () {
    $("input[type=text]").val("");
    $(".form-control").val("");
    $("#PAModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Guardar Proveedor Accionista");

    $("#PAModal").modal("show");
});

//Abrir modal editItem
$('#tablePA').on('click', '.edit-PA', function () {
    $("#IdProveedorAccionista").val($(this).attr('id'));

    $("#Persona").val($(this).attr('data-per'));
    $("#Proveedor").val($(this).attr('data-prov'));

    $("#IdPersona").val($(this).attr('data-IdPer'));
    $("#IdProveedor").val($(this).attr('data-IdProv'));

    $("#IdTipoRepresentacion").val($(this).attr('data-TR'));

    $("#PAModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Registro");

    $("#PAModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#PAModal").on('submit', function (e) {
    e.preventDefault();
    var form = $(".data-form");
    var tipo = $("#PAModal input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/ProveedoresAccionistas/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function () {
                $("#PAModal").modal("hide");
            });
    } else {
        $.post("/ProveedoresAccionistas/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function (resp) {
                $("#PAModal").modal("hide");

            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tablePA').on('click', ".delete-PA", function () {
    $(".IdProveedorAccionista").val($(this).attr('id'));
    $("#DeletePAModal input[type=submit]").prop("value", "Eliminar");


    $("#titlePA").html("¿Desea Eliminar el Proveedor Accionista " + $(this).attr('data-title') + " ?");
    $("#DeletePAModal").modal("show");
});

//Confirmar eliminación de Marca
$("#DeletePAModal").on('submit', function (e) {
    e.preventDefault();
    var Id = $(".IdProveedorAccionista").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/ProveedoresAccionistas/Delete/", { __RequestVerificationToken: token, id: Id }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function () {
            $("#DeletePAModal").modal("hide");
        });
});