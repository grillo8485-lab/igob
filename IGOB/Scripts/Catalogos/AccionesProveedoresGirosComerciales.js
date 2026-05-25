$(document).ready(function () {
    $('#tabla_pgc').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false
    });
});

//Abrir modal editItem
$('#tabla_pgc').on('click', '.edit-item', function () {
    $('#MensajeForm').html('');
    $("#IdProveedorGiroComercial").val($(this).attr('data-idpgc').trim());
    $("#IdProveedor").val($(this).attr('data-idpro').trim());
    $("#IdActividadEconomica").val($(this).attr('data-idace').trim());

    $("#Proveedor").val($(this).attr('data-rasoc').trim());
    $("#ActividadEconomica").val($(this).attr('data-descr').trim());
    
    $("#submitform").prop("value", "Editar");
    $('#formEditCreate').text(`Editar Proveedores Giros Comerciales`);
    $("#ModalForm").modal({ backdrop: 'static', keyboard: false },"show");
});

$('.create-item').on('click', function () {
    $(".PGCForm")[0].reset();
    $('#MensajeForm').html('');
    $("#submitform").prop("value", "Guardar");
    $('#formEditCreate').text('Guardar Proveedores Giros Comerciales');
    $("#ModalForm").modal({ backdrop: 'static', keyboard: false },"show");
});

//Modal Confirmar Edicion de Eliminacion
$('#tabla_pgc').on('click', '.delet-item', function () {
    var id_delete = $(this).attr('data-idpgc').trim();
    bootbox.confirm({
        size:"small",
        title: "Confirmar",
        message: "¿Desea eliminar el giro comercial <strong>"+ $(this).attr("data-descr") +"</strong>?",
        callback: function(e){
            if(e){
                $.post('/ProveedoresGirosComerciales/Delete/',{ id: id_delete, __RequestVerificationToken: $("[name='__RequestVerificationToken']").val() }, "JSON")
                    .done(function (response) {
                        if (response.success) {
                            bootbox.alert({
                                title: 'Aviso',
                                message: response.message,
                                size: 'small',
                                callback: function () { location.reload() }
                            })
                        } else {
                            bootbox.alert({
                                title: 'Aviso',
                                message: response.message,
                                size: 'small'
                            })
                        }
                })
            }
        }
    })
    

})

$("#ModalForm").on('submit', function (e) {
    e.preventDefault();
    let data = $('.PGCForm').serialize().trim();
    var tipo = $("#submitform").prop("value");
    if (tipo === "Editar") {
        $.post("/ProveedoresGirosComerciales/Edit/", 
            data.trim(),
            "JSON")
            .done(function (response) {
                if (response.success) {
                    bootbox.alert({
                        title: 'Aviso',
                        message: response.message,
                        size: 'small',
                        callback: function () { location.reload() }
                    })
                } else {
                    bootbox.alert({
                        title: 'Aviso',
                        message: response.message,
                        size: 'small'
                    })
                }
            })
    }
    if (tipo === "Guardar") {
        $.post("/ProveedoresGirosComerciales/Create/", data.trim(), "JSON")
            .done(function (response) {
                if (response.success) {
                    bootbox.alert({
                        title: 'Aviso',
                        message: response.message,
                        size: 'small',
                        callback: function () { location.reload() }
                    })
                } else {
                    bootbox.alert({
                        title: 'Aviso',
                        message: response.message,
                        size: 'small'
                    })
                }
            })
    }
    return false;
})

$("#ActividadEconomica").autocomplete({
    minLength: 1,
    source: function (request, response) {
        $.ajax({
            url: '/ProveedoresGirosComerciales/ListActividadEconomica',
            dataType: 'JSON',
            data: { descripcion: $("#ActividadEconomica").val() },

            success: function (data) {
                response($.map(data, function (item) {
                    return { label: item.Codigo+" - "+item.Descripcion, value: item.Codigo+" - "+item.Descripcion, id: item.IdActividadEconomica };
                }))
                //console.log(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    },
    select: function (e, ui) {
        $("#IdActividadEconomica").val(ui.item.id);
    },
    change: function (e, ui) {
        if (!(ui.item)) e.target.value = "";
    }
});