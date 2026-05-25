$(document).ready(function () {
    cargarTabla();
});

function cargarTabla(IdCapitulo) {

    if (typeof IdCapitulo === 'undefined')
        IdCapitulo = 0;

    $.post('/BienesServicios/GetAll', { id: IdCapitulo},"JSON").
        done(function (data) {

            $('#tableBS').dataTable().fnDestroy();
            $('#tableBS tbody').empty();

            $("#tableBS").DataTable({
                data: data.mensaje,
                scrollY: "340px",
                scrollX:true,
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
                            return '<div class="form-group" style="min-width:100px;"><a title="Eliminar registro" id="' + row.IdBienServicio + '" data-title="' + row.BienServicio + '" class="btn btn-secondary btn-circle delete-marca btn-sm" style="margin-right:5px;" ><span class="icon-garbage-2"></span></a ><a title="Editar registro" id="' + row.IdBienServicio + '" data-capitulo="' + row.IdCapitulo + '" class="btn btn-secondary btn-circle edit-BS btn-sm"><span class="icon-edit"></span></a></div >';
                        }
                    },
                    { 'data': 'CodigoScian' },
                    { 'data': 'Capitulo' },
                    { 'data': 'Partida' },
                    { 'data': 'BienServicio' },
                    { 'data': 'Familia' },
                    { 'data': 'UnidadMedida' },
                    { 'data': 'Marca' },
                    { 'data': 'Modificador' },
                    { 'data': 'TipoProducto' },
                    { 'data': 'ClaveCubs' },
                    { 'data': 'Impuesto' },
                    { 'data': 'Descripcion' },
                    { 'data': 'PrecioUnitario' },
                    { 'data': 'Certificacion' }
                ]
            });

        });
}

$("#IdCapitulo").on("change", function () {
    $.get("/BienesServicios/getAllPartidas_x_IdCapitulo", { pIdCapitulo: $("#IdCapitulo").val() }, function (data) {
        $("#IdPartida").empty();
        $.each(data.objeto, function (index, row) {
            $("#IdPartida").append("<option value='" + row["IdPartida"] + "'>" + row["Partida"] + "</option>");
        });
    });
});

$('.new-BS').on('click', function () {
    $("#GuardarBienServicio").prop("value", "Guardar");
    $(".modal-title").html("Nuevo Bien o Servicio");
    var FechaRegistro = new Date().toLocaleString();
    $("#FechaRegistro").val(FechaRegistro);

    var parametros = {
        pIdBienServicio: 0,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        data: parametros,
        url: '/BienesServicios/getBienServicio/',
        type: 'post',
        success: function (response) {
            $("#cargarBienServicio").html("");
            $("#cargarBienServicio").html(response);
            $("#BSModal").modal("show");
            $("#IdCapitulo").on("change", function () {
                $.get("/BienesServicios/getAllPartidas_x_IdCapitulo", { pIdCapitulo: $("#IdCapitulo").val() }, function (data) {
                    $("#IdPartida").empty();
                    $.each(data.objeto, function (index, row) {
                        $("#IdPartida").append("<option value='" + row["IdPartida"] + "'>" + row["Partida"] + "</option>");
                    });
                });
            });
            $("#DescripcionScian").autocomplete({
                minLength: 2,
                mustMatch: true,
                maxShowItems: 5,
                source: function (request, response) {
                    $.ajax({
                        url: '/BienesServicios/getAllCodigoScian',
                        dataType: 'JSON',
                        type: 'post',
                        data: { term: $("#DescripcionScian").val() },
                        success: function (data) {
                            response($.map(data.data, function (item) {

                                return { label: item.Titulo, value: item.Titulo, id: item.CodigoScian };
                            }))
                        },
                        error: function (data) {

                            bootbox.alert({
                                title: "Aviso",
                                message: "Error: " + data,
                                size: "small"
                            });
                        }
                    });
                },
                select: function (e, ui) {
                    $("#CodigoScian").val(ui.item.id);
                },
                change: function (e, ui) {
                    if (!(ui.item)) e.target.value = "";
                }
            });
        }
    });
});

$('#tableBS').on('click', '.edit-BS', function () {
 
    var IdCapitulo = $(this).attr('data-capitulo');
    var parametros = {
        pIdBienServicio: $(this).attr('id'),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $("#BSModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Bien o Servicio");

    $.ajax({
        data: parametros,
        url: '/BienesServicios/getBienServicio/',
        type: 'post',
        success: function (response) {
            $("#cargarBienServicio").html("");
            $("#cargarBienServicio").html(response);
            $("#BSModal").modal("show");
            $("#IdCapitulo").val(IdCapitulo);
            $("#IdCapitulo").on("change", function () {
                $.get("/BienesServicios/getAllPartidas_x_IdCapitulo", { pIdCapitulo: $("#IdCapitulo").val() }, function (data) {
                    $("#IdPartida").empty();
                    $.each(data.objeto, function (index, row) {
                        $("#IdPartida").append("<option value='" + row["IdPartida"] + "'>" + row["Partida"] + "</option>");
                    });
                });
            });
            
            $("#DescripcionScian").autocomplete({
                minLength: 2,
                mustMatch: true,
                maxShowItems: 5,
                source: function (request, response) {
                    $.ajax({
                        url: '/BienesServicios/getAllCodigoScian',
                        dataType: 'JSON',
                        type: 'post',
                        data: { term: $("#DescripcionScian").val() },
                        success: function (data) {
                            response($.map(data.data, function (item) {

                                return { label: item.Titulo, value: item.Titulo, id: item.CodigoScian };
                            }))
                        },
                        error: function (data) {

                            bootbox.alert({
                                title: "Aviso",
                                message: "Error: " + data,
                                size: "small"
                            });
                        }
                    });
                },
                select: function (e, ui) {
                    $("#CodigoScian").val(ui.item.id);
                },
                change: function (e, ui) {
                    if (!(ui.item)) e.target.value = "";
                }
            });
            getProducto_x_IdBienServicio();
        }
    });   
});

$("#GuardarBienServicio").on('click', function (e) {
    e.preventDefault();
    var form = $("#form-BS");
    var tipo = $("#GuardarBienServicio").prop("value");
    var BienServicio = $("#BienServicio").val();
    if (tipo === "Editar") {
        confirmGenerico("¿Desea guardar el bien o servicio: " + BienServicio + "?", traerTokenCapturaGenerico, false, { title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: editBienServicio, b: form })

    } else {

        confirmGenerico("¿Desea guardar el bien o servicio: " + BienServicio + "?", traerTokenCapturaGenerico, false, { title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: createBienServicio, b: form })

    }
    return false;
});

function createBienServicio(form) {
    $.post("/BienesServicios/Create/", form.serialize(), "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function (resp) {
            $("#BSModal").modal("hide");
            console.log(resp);
        });
}
function editBienServicio(form) {
    $.post("/BienesServicios/Edit/", form.serialize(), "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function (resp) {
            $("#BSModal").modal("hide");
            console.log(resp);
        });
}
$('#tableBS').on('click', ".delete-marca", function () {
    var IdMarca = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea Eliminar <strong>" + $(this).attr('data-title') + "</strong>?",
        callback: function (e) {
            if (e) {

                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: deleteBienServicio, b: IdMarca })
            }
        }

    });

});
function deleteBienServicio(IdMarca) {
    $.post("/BienesServicios/Delete/", { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: IdMarca }, "JSON")
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

$("#IdBuscarPorCapitulo").on("click", function () {
    var IdCapitulo = $("#IdCapituloBuscar").val();

    cargarTabla(IdCapitulo);

});
function getProducto_x_IdBienServicio() {
    var CodigoScian_ = $("#CodigoScian").val();
    var parametros = {
        pCodigoScian: CodigoScian_,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };
    $.ajax({
        data: parametros,
        url: '/BienesServicios/getCodigoScian',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                var objeto = response.data;
                
                $("#DescripcionScian").val(objeto.Titulo);
            }
            else {
                mensajeGenerico("Aviso", response.data, "");
                

            }

        }
    });
}