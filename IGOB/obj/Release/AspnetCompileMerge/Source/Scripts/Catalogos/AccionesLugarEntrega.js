$(document).ready(function () {
    $('#tableCatalogos').DataTable();
});

$("#map").on("click", function (e) {
    $(this).attr("isClicked", "true");
})

//Abrir modal editItem
$('#tableCatalogos').on('click', '.edit-item', function () {
    $('#MensajeForm').html('');
    placeMarker($(this).attr('data-locg').trim());
    $("#IdLugarEntregaFirma").val($(this).attr('data-idlef').trim());
    $("#IdDependencia").val($(this).attr('data-idep').trim()).attr("Selected",true);
    $("#Estado").val($(this).attr('data-clest').trim()).attr("Selected", true).attr("Selected", true);
    buscarMunicipio($(this).attr('data-idmp').trim());
    $("#IdTipoLugar").val($(this).attr('data-idtl').trim());
    $("#IdUsuarioRegistro").val($(this).attr('data-idur').trim());
    $("#Lugar").val($(this).attr('data-lg').trim());
    $("#Direccion").val($(this).attr('data-dir').trim());
    $("#Colonia").val($(this).attr('data-col').trim());
    $("#CodigoPostal").val($(this).attr('data-cp').trim());
    $("#Telefono").val($(this).attr('data-tel').trim());
    $("#LocalizacionGoogle").val($(this).attr('data-locg').trim());
    $("#FechaRegistro").val($(this).attr('data-fereg').trim());
    $("#submit").prop("value", "Editar");//cambiar el valor del imput en caso de editar
    $('#formEditCreate').text(`Editar`);//insertar datos en el header del modal
    $("#modalform").modal("show");//modal crear editar para desplegar
});

$('#create-item').on('click', function () {
    $('#MensajeForm').html('');
    $('.lugarEntrega')[0].reset();
    $("#IdMunicipio").val(0);
    $('#IdLugarEntregaFirma').val('0');
    $("#submit").prop("value", "Guardar");//cambiar las propiedades del boton
    $('#formEditCreate').text('Nuevo');//insertar datos en el header del modal
    $("#modalform").modal("show");//modal crear editar para desplegar
});

//Modal Confirmar Edicion de Eliminacion
$('#tableCatalogos').on('click', '.delet-item', function (d) {//tabla catalogo para recorrer cada elemento con clase delet-item

    var id_delete = $(this).attr("data-idlef");

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar el lugar de entrega <strong> " + $(this).attr('data-lugar') + "</strong>?",
        callback: function (e) {
            if (e) {

                $.post('/LugarEntrega/Delete/', { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: id_delete }, "JSON")
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

$("#modalform").on('submit', function (e) {//modal para editar crear
    e.preventDefault();
    let data = $('.lugarEntrega').serialize().trim();
    var tipo = $("#submit").prop("value");

    if (tipo === "Editar") {
        $.post("/LugarEntrega/Edit/",data.trim(),"JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#modalform").modal("hide");
                    }
                });
            });
    }
    if (tipo === "Guardar") {
        if ($("#map").attr("isClicked")) {
            $.post("/LugarEntrega/Create/", data.trim(), "JSON")
                .always(function (data) {
                    bootbox.alert({
                        size: "small",
                        title: data.success ? "Aviso" : "Error",
                        message: data.m,
                        callback: function () {
                            if (data.success)
                                location.reload();
                            else
                                $("#modalform").modal("hide");
                        }
                    });
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

$('.Entidad').on('change', function () {
    buscarMunicipio(0);
});

function buscarMunicipio(mun) {
    let id_entidad = $('.Entidad').val();
    let idmun = mun;

    $.get('/Dependencias/MunicipioById/',{ id: id_entidad },"JSON").done(function (response) {
        $('#IdMunicipio').empty();
        $('#IdMunicipio').append(`<option value="0">Seleccione Un Municipio</option>`);
        $.each(response, function (index, row) {
            if (idmun == 0)
                $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}">${row.Municipio}</option>`);
            else {
                if (row.IdMunicipio.trim() == idmun.trim())
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" selected="selected">${row.Municipio}</option>`);
                else
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}">${row.Municipio}</option>`);
            }
        });
    });

}
