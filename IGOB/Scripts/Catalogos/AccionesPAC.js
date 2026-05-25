//Proveedores Acta Constitutiva

$(document).ready(function () {
    $('#tablePAC').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false
    });
});

$("#map").on("click", function (e) {
    $(this).attr("isClicked","true");
})

//$("#Proveedor").autocomplete({
//    minLength: 0,
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

$('.new-PAC').on('click', function () {
    $("input[type=text]").val("");
    $(".form-control").val("");

    initAutocomplete();

    $("#PACModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Guardar Acta Constitutiva");
    $("#PACModal").modal("show");
});


//Abrir modal editItem
$('#tablePAC').on('click', '.edit-PAC', function () {

    $("#IdActaConstitutiva").val($(this).attr('id'));
    $("#IdProveedor").val($(this).attr('data-IdProv'));
    $("#NoNotaria").val($(this).attr('data-NN').trim());
    $("#NoEscritura").val($(this).attr('data-NE'));
    $("#FechaEscritura").val($(this).attr('data-FE'));
    $("#FechaRegistroPublico").val($(this).attr('data-FRP'));
    $("#NoFolioRegistro").val($(this).attr('data-NFR'));
    $("#Actualizacion").val($(this).attr('data-act'));
    $("#Lugar").val($(this).attr('data-lugar'));
    $("#Proveedor").val($(this).attr('data-prov'));

    placeMarker($(this).attr('data-lugar'));

$("#PACModal input[type=submit]").prop("value", "Editar");
$(".modal-title").html("Editar Registro");

    $("#PACModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#PACModal").on('submit', function (e) {
    e.preventDefault();
    var form = $(".data-form");
    var tipo = $("#PACModal input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/ProveedoresActaConstitutiva/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);
            })
            .always(function () {
                $("#PACModal").modal("hide");
                console.log(form.serialize());
            });
    } else {
        if ($("#map").attr("isClicked")) {
            $.post("/ProveedoresActaConstitutiva/Create/", form.serialize(), "JSON")
                .done(function (response) {
                    location.reload();
                })
                .fail(function (resp) {
                    console.log(resp);
                })
                .always(function (resp) {
                    $("#PACModal").modal("hide");
                });
        } else {
            bootbox.alert({
                size: "small",
                title: "Aviso",
                message: "Debe seleccionar un lugar en el mapa."
            });
        }

    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tablePAC').on('click', ".delete-PAC", function () {

    var Id = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar el acta constitutiva?",
        callback: function(e){
            if(e){
                $.post("/ProveedoresActaConstitutiva/Delete/", { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: Id }, "JSON")
                    .done(function (response) {
                        location.reload();
                    })
                    .fail(function (resp) {
                        console.log(resp)
                    })
                    .always(function () {
                        $("#DeletePACModal").modal("hide");
                    });
            }
        }    
    });
});

