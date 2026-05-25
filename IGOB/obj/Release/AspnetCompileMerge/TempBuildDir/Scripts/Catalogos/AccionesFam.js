$(document).ready(function () {
    cargarTabla();
});

function cargarTabla() {
    $.post('/CatFamilias/Getfamilias', "JSON").
        done(function (data) {

            $('#tableCatalogos').dataTable().fnDestroy();
            $('#tableCatalogos tbody').empty();

            $("#tableCatalogos").DataTable({
                data: data.mensaje,
                scrollY: 340,
                scrollCollapse: true,
                columnDefs: [
                    {
                        "width": "5.67%",
                        "className": 'dt-body-center',
                        "targets": [0, 1]
                    }
                ],
                columns: [
                    {
                        mRender: function (data, type, row) {
                            return '<div class="form-group" style="min-width:100px;"><a style="margin-right:3px;" title="Eliminar registro" id="' + row.IdFamilia + '" data-title="' + row.Familia + '" class="btn btn-secondary btn-circle delete-fam btn-sm" ><span class="icon-garbage-2"></span></a ><a title="Editar registro" id="' + row.IdFamilia + '" data-title="' + row.Familia + '" data-abreviatura="' + row.Descripcion + '" data-activo="' + row.Activo + '" class="btn btn-secondary btn-circle edit-fam btn-sm"><span class="icon-edit"></span></a></div >';
                        }
                    },
                    { 'data': 'Familia' },
                    { 'data': 'Descripcion' }
                ]
            });

        });


}

//Abrir Modal saveItem
$('.new-fam').on('click', function () {
    $(".form-control").val("");
    $("#FamiliasModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Familia");

    $("#FamiliasModal").modal("show");
});

//Abrir modal editItem
$('#tableCatalogos').on('click', '.edit-fam', function () {
    $("#IdFamilia").val($(this).attr('id'));
    $("#Familia").val($(this).attr('data-title').trim());
    $("#Descripcion").val($(this).attr('data-abreviatura').trim());
    $("#FamiliasModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Familia");

    $("#FamiliasModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#FamiliasModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-Fam");
    var tipo = $("#form-Fam input[type=submit]").prop("value");

    var token = $("[name='__RequestVerificationToken']").val();

    if (tipo === "Editar") {
        $.post("/CatFamilias/Edit/", form.serialize(), "JSON")
            .always(function (response) {
                bootbox.alert({
                    size: "small",
                    title: response.success ? "Aviso" : "Error",
                    message: response.m,
                    callback: function () {
                        if (response.success)
                            cargarTabla();
                    }
                });
            });
    } else {
        $.post("/CatFamilias/Create/", form.serialize(), "JSON")
            .always(function (response) {
                bootbox.alert({
                    size: "small",
                    title: response.success ? "Aviso" : "Error",
                    message: response.m,
                    callback: function () {
                        if (response.success)
                            cargarTabla();
                    }
                });
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableCatalogos').on('click', ".delete-fam", function () {
    var IdFamilia = $(this).attr("id");

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea Eliminar la Familia <strong>" + $(this).attr('data-title') + "</strong> ?",
        callback: function (e) {
            if (e) {
                $.post("/CatFamilias/Delete/" + IdFamilia, { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), Id: IdFamilia }, "JSON")
                    .always(function (response) {
                        bootbox.alert({
                            size: "small",
                            title: response.success ? "Aviso" : "Error",
                            message: response.m,
                            callback: function () {
                                if (response.success)
                                    cargarTabla();
                            }
                        });
                    });
            }
        }
    });
});
