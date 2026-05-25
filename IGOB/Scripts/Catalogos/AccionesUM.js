$(document).ready(function () {
    $('#tableUM').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false
    });

    $("#FechaVigenciaInicial").datetimepicker({
        language: 'es',
        format: "dd MM yyyy",
        pickerPosition: "bottom-left",
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0,
        pickTime: false,
        inline: false,
        startDate: new Date()
    });

});

//Abrir modal editItem
$('#tableUM').on('click', '.edit-item', function () {
    $(`#rowEdit`).show();
    $('#MensajeForm').empty();
    $("#IdUnidadMedida").val($(this).attr('data-id'));
    $("#ClaveUnidadMedida").val($(this).attr('data-clave').trim());
    $("#UnidadMedida").val($(this).attr('data-um').trim());
    $("#Descripcion").val($(this).attr('data-descripcion').trim());
    var fecha = $(this).attr('data-fechavigencia').trim();
    if (fecha == null || fecha == "") {
        var newDateTime = "";
    } else {
        var newDateTime = formatDateTimeLocal(fecha, 1);
    }
    document.getElementById("FechaVigenciaInicial").defaultValue = newDateTime;
    $("#Simbolo").val($(this).attr('data-simbolo').trim());
    $("#Version").val($(this).attr('data-version').trim());
    $("#Formato").val($(this).attr('data-formato').trim()).attr('selected', true);

    $("#submit").prop("value", "Editar");
    $('#formEditCreate').html('Editar Unidad de Medida');
    $("#UnidadesMedidaModal").modal("show");
});

$('#create-item').on('click', function () {
    $('#MensajeForm').empty();
    $('.UMForm')[0].reset();
    $(`#rowEdit`).hide();
    $('#IdUnidadMedida').val('0');
    $('#FechaVigenciaInicial').val(new Date().toLocaleString());
    $('#Simbolo').val('N/A');
    $('#Version').val('1.0');
    $("#submit").prop("value", "Guardar");
    $('#formEditCreate').html('Nueva Unidad de Medida');
    $("#UnidadesMedidaModal").modal("show");
});

//Modal Eliminacion
$('#tableUM').on('click', '.delet-item', function () {
    let idum = $(this).attr('data-id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea Eliminar La Unidad de Medida <strong>" + $(this).attr('data-um').trim() + "</strong>",
        callback: function (e) {
            if (e) {
                $.post('/UnidadesMedida/Delete/', { id: idum }, "JSON")
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

$("#UnidadesMedidaModal").on('submit', function (e) {
    e.preventDefault();
    var tipo = $("#submit").prop("value").trim();
    if (tipo === "Editar") {
        $.post("/UnidadesMedida/Edit/", $('.UMForm').serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#UnidadesMedidaModal").modal("hide");
                    }
                });
            });
    }else if (tipo === "Guardar") {
        $.post("/UnidadesMedida/Create/",$('.UMForm').serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#UnidadesMedidaModal").modal("hide");
                    }
                });
            });
    }
    return false;
});

function formatDateTimeLocal(cadena,tipo) {
    var ncad = cadena.split(" ");//console.log(ncad);
    var fecha = ncad[0].split("/");//console.log(fecha)
    /*
    tipo 1 es un tipo de datos date
    tipo 2 es un tipo de datos datetime-local
    */
    var newfecha = `${fecha[2]}-${fecha[1]}-${fecha[0]}`;
    if (tipo==1) {
        return newfecha;
    }
    if(tipo==2){
        return `${newfecha} ${ncad[1]}`;
    }
}