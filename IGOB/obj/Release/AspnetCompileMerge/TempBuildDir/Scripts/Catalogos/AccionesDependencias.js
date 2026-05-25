$(document).ready(function () {
    $('#tableDep').DataTable({
        scrollX: true,
        sort: false
    });
});

//Abrir modal editItem
$('#tableDep').on('click', '.edit-item', function () {
    $('#MensajeForm').html('');
    $('.table.table-striped').show();
    $("#IdDependencia").val($(this).attr('data-iddep').trim());
    $("#IdMunicipio").val($(this).attr('data-idmp').trim());
    ($(this).attr('data-idusreg').trim() == 0) ? $("#IdUsuarioRegistro").val('1') : $("#IdUsuarioRegistro").val($(this).attr('data-idusreg').trim());
    $("#IdGobierno").val($(this).attr('data-idgob').trim());
    $("#Dependencia").val($(this).attr('data-dep').trim());
    $("#Abreviatura").val($(this).attr('data-abv').trim());
    $("#Rfc").val($(this).attr('data-rfc').trim());
    $("#Calle").val($(this).attr('data-calle').trim());
    $("#NoExterior").val($(this).attr('data-NExt').trim());
    $("#NoInterior").val($(this).attr('data-Nint').trim());
    $("#Colonia").val($(this).attr('data-col').trim());
    $("#CodigoPostal").val($(this).attr('data-codpos').trim());
    $("#Telefono").val($(this).attr('data-tel').trim());
    $("#Email").val($(this).attr('data-email').trim());
    $("#Logo").val($(this).attr('data-logo').trim());
    $("#FechaRegistro").val($(this).attr('data-freg').trim());
    $("#Localidad").val($(this).attr('data-local').trim());
    $("#Sitiooficial").val($(this).attr('data-web').trim());
    $("#Titular").val($(this).attr('data-tt').trim());

    $("#ClaveEstado").val($(this).attr('data-cvest').trim());
    buscarMunicipio($(this).attr('data-idmp').trim());

    $("#modalDependencia input[type=submit]").prop("value", "Editar");//cambiar el valor del imput en caso de editar
    $('#formEditCreate').text(`Editar Dependencia`);//insertar datos en el header del modal
    $("#modalDependencia").modal("show");//modal crear editar para desplegar
});

$('#create-item').on('click', function () {
    $('#MensajeForm').html('');
    $('.table.table-striped').show();
    $('.DependenciaForm')[0].reset();
    $('#IdMunicipio').val(0);
    $("#modalDependencia input[type=submit]").prop("value", "Guardar");//cambiar las propiedades del boton
    $('#formEditCreate').text('Nueva Dependencias');//insertar datos en el header del modal
    $("#modalDependencia").modal("show");//modal crear editar para desplegar
});

//Modal Confirmar Edicion de Eliminacion
$('#tableDep').on('click', '.delet-item', function (d) {

    let id_delete = $(this).attr("data-iddep");

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar la dependencia: <strong>" + $(this).attr('data-dep').trim() + "</strong> ?",
        callback: function(e){
            if (e) {           
                $.post('/Dependencias/Delete/', { id: id_delete, __RequestVerificationToken: $("[name='__RequestVerificationToken']").val() }, "JSON")
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

$("#modalDependencia").on('submit', function (e) {//modal para editar crear
    e.preventDefault();
    let data = $('.DependenciaForm').serialize().trim();
    var tipo = $(".DependenciaForm input[type=submit]").prop("value");
    if (tipo === "Editar") {
        $.post("/Dependencias/Edit/", data.trim(),"JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#modalDependencia").modal("hide");
                    }
                });
            });
    }
    if (tipo === "Guardar") {
        $.post("/Dependencias/Create/", data.trim(),"JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#modalDependencia").modal("hide");
                    }
                });
            });
    }
    return false;
});

$('#ClaveEstado').on('change', function () {
    buscarMunicipio(0);
});

function buscarMunicipio(idmun) {
    let claveestado = $('#ClaveEstado').val();
    $.get('/Dependencias/MunicipioById/', { id: claveestado }, "JSON")
        .done(function (response) {
            $('#IdMunicipio').empty();
            $('#IdMunicipio').append(`<option value="0">Seleccione Un Municipio</option>`);
            $.each(response, function (index, row) {
                if (idmun == 0) {
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}">${row.Municipio}</option>`);
                } else {
                    if (row.IdMunicipio.trim() == idmun.trim()) {
                        $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" selected="selected">${row.Municipio}</option>`);
                    } else {
                        $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}">${row.Municipio}</option>`);
                    }
                }
            });
        });
}
