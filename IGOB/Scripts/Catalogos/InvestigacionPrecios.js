$(document).ready(function () {
    $('#InvetigacionPrecioS').DataTable({
        scrollCollapse: true,
        sort: false,
        "language": {
            "emptyTable": ""
        },
        initComplete: function (settings, json) {
            setTimeout(function () { $("#InvetigacionPrecioS").DataTable().draw(); }, 200);
        }
    }).draw();
});



function nuevoInvestigacionPrecios() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdDeterminaPrecioBienServicio_ = 0;

    $.ajax({
        data: { IdDeterminaPrecioBienServicio: IdDeterminaPrecioBienServicio_, __RequestVerificationToken: token },
        url: '/InvestigacionPrecios/getInvestigacionPrecio',
        type: 'post',
        beforeSend: function () {
            $("#ContenedorResultado").append("");
        },
        success: function (response) {

            if (response != "") {
                $("#ContenedorResultado").html(response);
                $("#modal_InvestigacionPrecios").modal("show");
                
                $("#Producto").autocomplete({
                    minLength: 2,
                    mustMatch: true,
                    maxShowItems: 5,
                    source: function (request, response) {
                        $.ajax({
                            url: '/InvestigacionPrecios/getProductos',
                            dataType: 'JSON',
                            type: 'post',
                            data: { term: $("#Producto").val() },
                            success: function (data) {
                                response($.map(data.data, function (item) {

                                    return { label: item.string5, value: item.string5, id: item.entero };
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
                        $("#IdBienServicio").val(ui.item.id);
                        getProducto_x_IdBienServicio(ui.item.id);
                    },
                    change: function (e, ui) {
                        if (!(ui.item)) e.target.value = "";
                    }
                });
            }
            else {
                mensajeGenerico("Aviso", response.data, "")
            }

        }
    });


}
function editarInvestigacionPrecios(IdPropuestaTecnicaEconomica_) {
    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        data: { IdDeterminaPrecioBienServicio: IdPropuestaTecnicaEconomica_, __RequestVerificationToken: token },
        url: '/InvestigacionPrecios/getInvestigacionPrecio',
        type: 'post',
        beforeSend: function () {
            $("#ContenedorResultado").append("");
        },
        success: function (response) {

            if (response != "") {
                $("#ContenedorResultado").html(response);
                $("#modal_InvestigacionPrecios").modal("show");
                getProducto_x_IdBienServicio($("#IdBienServicio").val());
                $("#NivelConfianza").val($("#IdNivelConfianza").val());
                


                $("#Producto").autocomplete({
                    minLength: 2,
                    mustMatch: true,
                    maxShowItems: 5,
                    source: function (request, response) {
                        $.ajax({
                            url: '/InvestigacionPrecios/getProductos',
                            dataType: 'JSON',
                            type: 'post',
                            data: { term: $("#Producto").val() },
                            success: function (data) {
                                response($.map(data.data, function (item) {

                                    return { label: item.string5, value: item.string5, id: item.entero };
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
                        $("#IdBienServicio").val(ui.item.id);
                        getProducto_x_IdBienServicio(ui.item.id);
                    },
                    change: function (e, ui) {
                        if (!(ui.item)) e.target.value = "";
                    }
                });
            }
            else {
                mensajeGenerico("Aviso", response.data, "")
            }

        }
    });


}
function getProducto_x_IdBienServicio(IdBienServicio_) {
    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        data: { IdBienServicio: IdBienServicio_, __RequestVerificationToken: token },
        url: '/InvestigacionPrecios/getProducto',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                $("#Caracteristica").val(response.data.Descripcion);
                $("#Producto").val(response.data.BienServicio);
            }
            else {
                mensajeGenerico("Aviso", response.data,"")
               
            }

        }
    });
}

function calcular() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.text = 'Este campo es obligatorio';
    var valido = false;
    valido = $("#InvestigacionPrecios").valid();
    if (valido) {
        var determinacionPrecios_ = $("#InvestigacionPrecios").serializeArray();
        //var dataWithAntiforgeryToken = $.extend({ 'determinacionPrecios': determinacionPrecios_ });
        $.ajax({
            dataType: 'json',
            data: determinacionPrecios_,
            url: '/InvestigacionPrecios/getCalcularVarianza',
            type: 'post',
            beforeSend: function () {

            },
            success: function (response) {
                if (response.success) {
                    $("#Muestra").val(response.data.Muestra);
                    $("#MuestraRedondeada").val(response.data.MuestraRedondeada);
                    $("#btnActualizar").prop("disabled", false);
                    $("#btnGuardar").prop("disabled", false);
                }
                else {
                    mensajeGenerico("Aviso", response.data, "")

                }

            }
        });
    }
}

function saveInvestigacionPrecio() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.text = 'Este campo es obligatorio';
    var valido = false;
    valido = $("#InvestigacionPrecios").valid();
    if (valido) {
        var determinacionPrecios_ = $("#InvestigacionPrecios").serializeArray();
        //var dataWithAntiforgeryToken = $.extend({ 'determinacionPrecios': determinacionPrecios_ });
        $.ajax({
            dataType: 'json',
            data: determinacionPrecios_,
            url: '/InvestigacionPrecios/saveInvestigacionPrecio',
            type: 'post',
            beforeSend: function () {
                $("#btnActualizar").prop("disabled", true);
            },
            success: function (response) {
                if (response.success) {
                    mensajeGenerico("Aviso", "Información guardada correctamente", "1")
                }
                else {
                    mensajeGenerico("Aviso", response.data, "")
                }

            }
        });
    }
}