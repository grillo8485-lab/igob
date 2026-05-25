$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $('#PresupuestoTabla').DataTable({
        paging: false,
        searching: false,
        info: false,
        scrollX: false,
        scrollCollapse: false,
        sort: false,
        "language": {
            "emptyTable": ""
        }
    });

    $('#tabla_asignar_proveedores').DataTable({
        scrollX: false,
        scrollCollapse: false,
        sort: false,
        "language": {
            "emptyTable": ""
        }
    });
    
    $('#CartaTabla').DataTable({
        scrollCollapse: true,
        sort: false,
        "language": {
            "emptyTable": ""
        },
        initComplete: function (settings, json) {
            setTimeout(function () { $("#CartaTabla").DataTable().draw(); }, 200);
        }
    }).draw();
    $('#liquidezTable').DataTable({
        sort: false,
        "language": {
            "emptyTable": ""
        }
    });
    $('#LotesTable').DataTable({
        pageLength: 5,
        lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, 100]],
        sort: false,
        "language": {
            "emptyTable": ""
        }

    });

    $('#tablaPagos').DataTable({
        
        "language": {
            "emptyTable": ""
        },
        sort: false,
        initComplete: function (settings, json) {
            setTimeout(function () { $("#tablaPagos").DataTable().draw(); }, 200);
        },
        
    });

    $('#condicionesDeEntragaTable').DataTable({
        "language": {
            "emptyTable": ""
        }
    });
    $(function () {
        var diferencia = numeral($("#Diferencia").val()).value();
        if (diferencia > 0 && parseInt($('#estatusreq').val())>40) {
            mensajeGenerico("Requisición", "El valor aproximado fue modificado por la Secretaría de Hacienda","")
        }
    });
    $(function () {
        var idEstatusRequisicion = parseInt($('#estatusreq').val());
        if (idEstatusRequisicion == 5) {

            confirmGenerico("¿Desea procesar está requisición para segunda licitación?", traerTokenCapturaGenerico, true, { title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveRequisicionSegundaVuelta, b: 0 })
        }
    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('.datetimepicker4').datetimepicker({
            language: 'es',
            format: "yyyy-mm-dd",
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            pickTime: false,
            inline: false,
            uiLibrary: 'bootstrap4'
        });
    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('.datetimepickerPago').datetimepicker({
            language: 'es',
            format: "yyyy-mm-dd",
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            pickTime: false,
            inline: false
        });
    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('#datetimepickerHorarioInicio').datetimepicker({
            language: 'es',
            format: "hh:ii",
            datepicker: false,
            ampm: true, // FOR AM/PM FORMAT
            format: 'hh:ii',
            startView: 0,
            minView: 0,
            autoclose: 1
        });
    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('#datetimepickerHorarioFin').datetimepicker({
            language: 'es',
            format: "hh:ii",
            datepicker: false,
            ampm: true, // FOR AM/PM FORMAT
            format: 'hh:ii',
            startView: 0,
            minView: 0,
            autoclose: 1,

        });
    });

    $('input[name=semana]').on('click', function () {
        if ($(this).is(':checked')) {
            var chk = $("#diasDelaSemana").val().trim();
            var arraySemana = chk.split(",");
            // Hacer algo si el checkbox ha sido seleccionado
            arraySemana.push($(this).val());
            var cadena = "";
            for (val of arraySemana) {
                //console.log(val);
                if (val != "") {
                    cadena += '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">' + val + '</span></button>';
                }

            }
            $("#SemanaSelect").html(cadena);
            $("#diasDelaSemana").val(arraySemana.join(','));

        } else {
            var chk = $("#diasDelaSemana").val().trim();
            var arraySemana = chk.split(",");
            var index = arraySemana.indexOf($(this).val());
            if (index > -1) {
                arraySemana.splice(index, 1);
                var cadena = "";
                for (val of arraySemana) {
                    //console.log(val);
                    if (val != "") {
                        cadena += '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">' + val + '</span></button>';
                    }
                }
                $("#SemanaSelect").html(cadena);
                $("#diasDelaSemana").val(arraySemana.join(','));
            }
        }
    });
    validarCheckAnticipo();

    $("#customRadio1").click(function () {
        validarCheckAnticipo()
    });
    $("#customRadio2").click(function () {
        validarCheckAnticipo()
    });
    getDireccionPago();
});


function getAllPartida_x_IdCapitulo() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdCapitulo = $("#Capitulos").val();

    var parametros = {
        pIdCapitulo: IdCapitulo,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Requisiciones/getAllPartidas_x_IdCapitulo/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                var informacion = response.objeto;
                $("#Partida").html("");
                $("#Partida").append('<option value="">Selecciona Partida</option>');
                $.each(informacion, function (rowIndex, r) {

                    var campoId = r["IdPartida"];
                    var campoA = r["Descripcion"];

                    $("#Partida").append('<option value=' + campoId + '>' + campoA + '</option>');
                });

            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function getPresupuestoPartida() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdPartida = $("#Partida").val();

    var parametros = {
        pIdPartida: IdPartida,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Requisiciones/getPresupuestoPartida/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                var informacion = response.objeto;
                if (informacion.MontoPresupuesto == 0) {
                    var textPartida = $("#Partida option:selected").text()
                    //$("#Pop-Up .modal-title").html("Requisición Monto");
                    //$("#titlePopUp").html("la partida " + textPartida + " no tiene monto suficiente para realizar el proceso de guardado.");
                    //$("#Pop-Up").modal("show");
                    $("#ValorAproximado").val("0.00");
                    $("#ValorAproximadoReal").val("0.00");
                    mensajeGenerico("Requisición Monto", "la partida " + textPartida + " no tiene monto suficiente para realizar el proceso de guardado.","");
                }
                else {
                    $("#ValorAproximado").val(informacion.MontoSaldo);
                    $("#ValorAproximadoReal").val(informacion.MontoSaldo);
                    $("#IdPresupuestoPartida").val(informacion.IdPresupuestoPartida);

                }
            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function validarFormulario() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.text = 'Este campo es obligatorio';
    var form = $("#Formulario").val();
    form = form.replace("TabPadre", "");
    var validado = true;
    if (form != "div_firmantes") {
        validado = $("#" + form + "Form").valid();
    }
    if (numeral($("#ValorAproximado").val())["_value"] <= 0) {
        validado = false;
        mensajeGenerico("Aviso","Valor aproximado tiene que ser mayor a cero","");
    }
    if (validado) {
        switch (form) {
            case "DatosGenerales":
                if (!$('#ValorAproximado').hasClass('disabledClick')) {
                    bootbox.confirm({
                        title: "Solicitar requisición",
                        message: "¿Desea solicitar la requisición?",
                        size: "small",
                        callback: function (res) {
                            if (res) {

                                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveRequisicion, b: undefined })
                                //traerTokenCapturaRecepcionPedido("Introduce token", validarTokenGenerico, saveRequisicion);
                                
                            }
                        }
                    }).find('.modal-dialog').addClass("modal-dialog-centered");
                }
                break;
            case "div_condiciones_entrega":
                saveCondcionesDeEntrega();
                break;
            case "div_condiciones_pago":
                saveCondicionPago();
                break;
            case "div_firmantes":
                bootbox.confirm({
                    title: "Enviar a revisión",
                    message: "¿Desea enviar a revisión?",
                    size: "small",
                    callback: function (res) {
                        if (res) {
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveFirmantes, b: undefined })
                            //traerTokenCapturaRecepcionPedido("Introduce token", validarTokenGenerico, saveFirmantes);
                            //saveFirmantes()
                        }
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");
                break;
        }

    }
}
function Procesar() {

}
$(document).ready(function () {
    $('.nav li a').click(function (e) {
        var i = $(this).attr('id');
        switch (i) {
            case "div_firmantesTabPadre":
                $("#btnGuardarValidaciones").html("Enviar a revisión");
                break;
            default:
                $("#btnGuardarValidaciones").html("Guardar");
                break;
        }
        $("#Formulario").val(i);
    });
});

function saveRequisicion() {
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        IdRequisicion: $("#IdRequisicion").val(),
        IdRequisicionOrigen: 0,
        IdDependencia: 0,//IdDependencia del usuario logueado
        IdTipoRequisicion: $("#Requisicion").val(),
        IdTipoSolicitud: $("#Solicitud").val(),
        IdOrigenRecurso: 1,
        IdOrigenRecursoAutorizado: 0,
        IdEstatus: 10,
        IdEstatusRequisicion: 10,
        NumeroLicitacion: $("#NumeroLicitacion").val(),
        IdTiempo: $("#Tiempo").val(),
        IdFormaAbastecimiento: $("#Abastecimiento").val(),
        IdPartida: $("#Partida").val(),
        IdEjercicioFiscal: $("#IdEjercicioFiscal").val(),
        IdPresupuestoPartida: $("#IdPresupuestoPartida").val(),
        FechaRequisicion: "",
        RequisicionFolio: 0,
        ConsecutivoRequisicion: 0,
        NumeroOficioSolicitud: $("#NumeroOficioSolicitud").val(),
        NumeroOficioCertificacion: $("#NumeroOficioCertificacion").val(),
        MontoAproximado: numeral($("#ValorAproximado").val())["_value"],
        MontoAproximadoAutorizado: numeral($("#ValorAproximado").val())["_value"],
        CantidadLotes: 0,
        ImporteTotalLotes: 0,
        Observaciones: $("#Observacion").val(),
        ObservacionesRechazo: "",
        TiempoRestante: "",
        ColorTiempoRestante: "Negro",
        SaldoPartida: numeral($("#ValorAproximado").val())["_value"],
        MontoPresupuestado: numeral($("#ValorAproximado").val())["_value"],
        IdUsuarioAsignante: 0,
        Acepta2daLicitacion: "",
        IdUsuarioRevisor: 0,
        FechaAsignaRevisor: "",
        FechaAutorizacion: "",
        Economia: 0,
        Ejercido: 0,
        IdUsuarioRegistro: 0,//IdUsuario Session
        FechaRegistro: "", //Date.Now 
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Requisiciones/saveRequisiciones/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                var a = $("#tipoRequisicion").val();
                var url_ = '/RequisicionConsulta/Index/' + a;
                mensajeGenerico("Aviso", "Se ha enviado la solicitud número " + response.objeto.RequisicionFolio +"  correctamente, para la autorización de presupuesto y liquidez, a partir de este momento cuenta con 24 horas para recibir una respuesta y pueda continuar con la captura de la solicitud", url_);
                //bootbox.alert({
                //    size: "small",
                //    title: "Alta requisición",
                //    message: "Requisición ha sido generada con el folio: " + response.objeto.RequisicionFolio,
                //    className: "",
                //    callback: function () {
                //        var a = $("#tipoRequisicion").val();
                //        location.href = '/RequisicionConsulta/Index/' + a;
                //    }
                //})
                //menssage("Guardar requisición", "Requisición ha sido generada con el folio: " + response.objeto.RequisicionFolio)
                //alert(response.objeto);

            }
            else {
                mensajeGenerico("Aviso", '<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >', "");
                //$("#ResultadoBuscar").html();
            }

        }
    });
}

$("#ValorAproximado").blur(function () {
    var a = parseFloat(numeral($("#ValorAproximado").val())["_value"]);
    var b = parseFloat(numeral($("#ValorAproximado").val())["_value"]);
    if (a > b) {
        $("#Pop-Up .modal-title").html("Requisición Monto");
        $("#titlePopUp").html("El valor aproximado capturado, es mayor al valor real de partida(" + b.toLocaleString(undefined, { maximumFractionDigits: 2 }) + ").");
        $("#Pop-Up").modal("show");
        $("#ValorAproximado").val("0.00")
    }
});



function retornarPagina(a) {
    location.href = '/RequisicionConsulta/Index/' + a;
}

function editarRequisicion(IdRequisicion) {

}
function nuevaCarta() {
    $("#CartasModal .modal-title").html("Alta Carta");
    $("#CartasModal").modal("show");
}

function validarFormularioCarta() {
    var validado = $("#div_CartasForm").valid();
    if (validado) {
        saveCarta();
    }
}

function saveCarta() {
    var token = $("[name='__RequestVerificationToken']").val();
    var pCartas = {
        IdCarta: 0,
        Numero: 0,
        Inciso: $("#Inciso").val(),
        Nombre: $("#NombreCarta").val(),
        Carta: $("#Carta").val(),
        Solicitada: $("#Descripcion").val(),
        IdEstatus: 0,
        IdTipoCarta: 2,
        Obligada: 0,
        IdRequisicion: $("#IdRequisicion").val(),
        IdTipoSolicitud: $("#IdTipoSolicitud").val(),
        __RequestVerificationToken: token
    };

    $.ajax({
        data: pCartas,
        url: '/Requisiciones/saveCarta',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {

                //Recargar Tabla para que actualize el sistema.
                $("#CartasModal").modal("hide");
                $("#idNuevaCarta").load(" #idNuevaCarta");
                $("#idNuevoLote").load(" #idNuevoLote");
                $("#navbarToggleExternalContent").load(" #navbarToggleExternalContent", function (data) {

                    var idTab = $("#Formulario").val();
                    if (idTab != "DatosGeneralesTabPadre") {
                        $("#" + idTab).addClass('active')
                        $("#DatosGeneralesTabPadre").removeClass('active')
                    }

                    $('.nav li a').click(function (e) {
                        var i = $(this).attr('id');
                        switch (i) {
                            case "div_firmantesTabPadre":
                                $("#btnGuardarValidaciones").html("Enviar a revisión");
                                break;
                            default:
                                $("#btnGuardarValidaciones").html("Guardar");
                                break;
                        }
                        $("#Formulario").val(i);
                    });
                });
                var table = $('#CartaTabla').DataTable();
                var rows = table.rows().remove().draw();
                $.each(response.data, function (rowIndex, r) {
                    table.row.add([
                        r.Numero,
                        r.Inciso,
                        r.NombreCarta,
                        r.CartaTexto,
                        r.Descripcion
                    ]).draw(false);
                });

            }
            else {
                mensajeGenerico("Aviso", '<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >', "");
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function nuevoLote() {
    resetform();
    $("#GuardarLote").css({ "display": "" });
    $("#ActualizarLote").css({ "display": "none" });
    $("#modal_nuevo_lote .modal-title").html("Alta Lote");
    $("#modal_nuevo_lote").modal("show");

}

$("#Producto").autocomplete({
    minLength: 2,
    mustMatch: true,
    maxShowItems: 5,
    source: function (request, response) {
        $.ajax({
            url: '/Requisiciones/getProductos',
            dataType: 'JSON',
            type: 'post',
            data: { term: $("#Producto").val(), IdPartida: $("#IdPartida_").val() },
            success: function (data) {
                response($.map(data.data, function (item) {
                   
                    return { label: item.string5, value: item.string5, id: item.entero };
                }))
            },
            error: function (data) {
                
                bootbox.alert({
                    title: "Aviso",
                    message: "Error: "+data,
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

function getProducto_x_IdBienServicio(IdBienServicio_) {
    var token = $("[name='__RequestVerificationToken']").val();
    //var pCartas = {
    //    IdBienServicio: IdBienServicio,
    //    __RequestVerificationToken: token
    //};

    $.ajax({
        data: { IdBienServicio: IdBienServicio_, IdRequisicion: $("#IdRequisicion").val(), __RequestVerificationToken: token },
        url: '/Requisiciones/getProducto',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                $("#Unidad").val(response.data.string3);
                $("#Caracteristica").val(response.data.string2);
                $("#Impuesto").val(response.data.string4);
                $("#TasaImpuesto").val(response.data.decimal2);
                var preciounitario = numeral(response.data.decimal1).format('0,0.00');
                $("#PrecioUnitarioListaSinImpuestoMensual").val(preciounitario);
                calcularValores()


            }
            else {
                $("#Pop-Up .modal-title").html("Error en agregar bien");
                $("#titlePopUp").html(response.data);
                $("#Pop-Up").modal("show");

            }

        }
    });
}

function mesesActivos() {
    var de = $("#De").val();
    var al = $("#Al").val();
    var textDe = $("#De :selected").text();
    var textAl = $("#Al :selected").text();

    if (al == "") {
        return;
    }
    if (de == "") {
        return;
    }
    if ((al - de) < 0) {
        $("#De").val("")
        $("#Al").val("")
        
        $("#Pop-Up .modal-title").html("Requisición fecha inicio-fin");
        $("#titlePopUp").html("El mes Inio (" + textDe + ") es mayor al mes fin (" + textAl + ").");
        $("#Pop-Up").modal("show");
        return;
    }
    var total = al - de + 1;
    $("#Meses").val(total);
    calcularValores();
}
function runScript(e) {
    calcularValores()
    return false;
}
function calcularValores() {
    var cantidad = $("#Cantidad").val();
    if (cantidad != "") {
        var preciounitario = $("#PrecioUnitarioListaSinImpuestoMensual").val();
        preciounitario = numeral(preciounitario).value();
        var precioUnitarioListaSinImpuestoMensual = preciounitario;
        var tasaImpuesto = $("#TasaImpuesto").val();


        var periodo = $("#Meses").val();
        var importeConImpuesto = precioUnitarioListaSinImpuestoMensual * tasaImpuesto;
        var impuestoGenerado = importeConImpuesto * cantidad;
        var totalSinImpuesto = precioUnitarioListaSinImpuestoMensual * cantidad;
        var totalConImpuesto = totalSinImpuesto + impuestoGenerado;
        var totalPeriodo = totalConImpuesto * (periodo == 0 ? 1 : periodo);
        totalSinImpuesto = numeral(totalSinImpuesto).format('0,0.00');
        totalConImpuesto = numeral(totalConImpuesto).format('0,0.00');
        totalPeriodo = numeral(totalPeriodo).format('0,0.00');
        $("#ImporteSinImpuestoMensual").val(totalSinImpuesto)
        $("#ImporteConImpuestoMensual").val(totalConImpuesto)
        $("#ImporteTotalPeriodo").val(totalPeriodo);
        $("#importeConImpuesto").val(importeConImpuesto);

    }
    else {
        $("#ImporteSinImpuestoMensual").val(0.00)
        $("#ImporteConImpuestoMensual").val(0.00)
        $("#ImporteTotalPeriodo").val(0.00)
    }

}

function validarFormularioLote() {
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor 0."

    var validado = $("#div_LotesForm").valid();
    var validarValores = validarValoresTotales();
    if (!validarValores) {
        validado = $("#div_LotesForm").valid();
    }
    if (validado && validarValores) {
        saveLote();
    }
}

function eliminarLoteModal(IdLote) {
    $("#IdLote").val(IdLote)
    $("#modal_eliminar_lote").modal("show");
}

function eliminarLote() {
    var idLote = $("#IdLote").val()
    var token = $("[name='__RequestVerificationToken']").val();
    var pRequisicionLote = {
        IdLote: idLote,
        IdRequisicion: $("#IdRequisicion").val(),
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pRequisicionLote,
        url: '/Requisiciones/deleteLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                $("#modal_eliminar_lote").modal("hide");
                resetform();
                cargartablaLotes(response.data);
                $("#LoteCOndiconEntregaDetalle").load(" #LoteCOndiconEntregaDetalle");
                calcularPorcentaje();
            }
            else {
                $("#modal_eliminar_lote").modal("hide");
                //bootbox.alert({
                //    title: "Eliminar Lote",
                //    message: "Error no se puede eliminar lote, ya que esta siendo usado en una condicion de entrega.",
                //    size: "small"
                //});
                mensajeGenerico("Aviso", '<div class="alert alert-danger" role="alert">Error no se puede eliminar lote, ya que esta siendo usado en una condicion de entrega.</div >', "");
                //menssage("Eliminar Lote", "Error no se puede eliminar lote, ya que esta siendo usado en una condicion de entrega.")
            }

        }
    });
}
function cargarColumnas() {
    var idTipoSolicitud = $("#IdTipoSolicitud").val();

    var dataRow = Array();
    if (idTipoSolicitud == 2) {
        dataRow = [
            {
                mRender: function (data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarLote(' + row.IdLote + ')" ><span class="fa fa-pencil" ></span></button>' +
                        '<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarLoteModal(' + row.IdLote + ')"><span class="fa fa-trash-o" ></span></button></div>'
                }
            },
            { "data": "NoLote", sortable: true },
            { "data": "Pantone", sortable: true },
            { "data": "DesCricionMesInicial", sortable: true },
            { "data": "DesCricionMesFinal", sortable: true },
            { "data": "BienServicio", sortable: true },
            { "data": "UnidadMedida", sortable: true },
            { "data": "Descripcion", sortable: true },
            { "data": "DescripcionFrecuencia", sortable: true },
            { "data": "Muestra", sortable: true },
            { "data": "Impuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "PrecioUnitario", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "ImporteCImpuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "Cantidad", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2) },
            { "data": "Importe", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "ImporteMesnsualCImpuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "MesesServicio", sortable: true },
            { "data": "Total", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') }
        ];

    }
    else {
        dataRow = [
            {
                mRender: function (data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarLote(' + row.IdLote + ')" ><span class="fa fa-pencil" ></span></button>' +
                        '<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarLoteModal(' + row.IdLote + ')" ><span class="fa fa-trash-o" ></span></button></div>'
                }
            },
            { "data": "NoLote", sortable: true },
            { "data": "Pantone", sortable: true },
            { "data": "BienServicio", sortable: true },
            { "data": "UnidadMedida", sortable: true },
            { "data": "Descripcion", sortable: true },
            { "data": "Muestra", sortable: true },
            { "data": "Impuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "PrecioUnitario", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "ImporteCImpuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "Cantidad", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2) },
            { "data": "Importe", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "ImporteMesnsualCImpuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "Total", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') }
        ];
    }

    return dataRow;
}
function cargartablaLotes(data) {
    $('#LotesTable').dataTable({
        "bDestroy": true
    }).fnDestroy();

    $('#LotesTable').dataTable().fnDestroy();

    var table = $('#LotesTable').DataTable({
        scrollY: "280px",
        scrollX: true,
        data: data,
        columnDefs: [
            { targets: [-1, -2, -3, -4, -5, -6], className: "dt-body-right" },

        ],
        "columns": cargarColumnas(),
        "language": {
            "emptyTable": ""
        }
    });

}
function saveLote() {

    var PrecioUnitarioListaSinImpuestoMensual = numeral($("#PrecioUnitarioListaSinImpuestoMensual").val()).value();
    var ImporteSinImpuestoMensual = numeral($("#ImporteSinImpuestoMensual").val()).value();
    var importeConImpuesto = numeral($("#importeConImpuesto").val()).value();
    var ImporteConImpuestoMensual = numeral($("#ImporteConImpuestoMensual").val()).value();
    var ImporteTotalPeriodo = numeral($("#ImporteTotalPeriodo").val()).value();
    var token = $("[name='__RequestVerificationToken']").val();
    var frecuencia = $("#Frecuencia").val();
    var pRequisicionLote = {
        IdLote: 0,
        IdRequisicion: $("#IdRequisicion").val(),
        NoLote: 0,
        IdBienServicio: $("#IdBienServicio").val(),
        Pantone: $("#ClavePantone").val(),
        Cantidad: $("#Cantidad").val(),
        PrecioUnitario: PrecioUnitarioListaSinImpuestoMensual,
        Importe: ImporteSinImpuestoMensual,
        PorcentajeImpuesto: $("#TasaImpuesto").val(),
        ImporteCImpuesto: importeConImpuesto,
        ImporteMesnsualCImpuesto: ImporteConImpuestoMensual,
        MesesServicio: $("#Meses").val(),
        Total: ImporteTotalPeriodo,
        MesInicial: $("#De").val(),
        MesFinal: $("#Al").val(),
        Frecuencia: frecuencia,
        IdMuestra: $("#Requerimiento").val(),
        FechaRegistro: 0,
        IdUsuarioRegistro: 0,
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pRequisicionLote,
        url: '/Requisiciones/saveLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {

                cargartablaLotes(response.data);
                resetform();
                $("#LoteCOndiconEntregaDetalle").load(" #LoteCOndiconEntregaDetalle");
                calcularPorcentaje();
            }
            else {
                $("#Pop-Up .modal-title").html("Error alta lote");
                $("#titlePopUp").html(response.data);
                $("#Pop-Up").modal("show");
            }

        }
    });
}
function validarFormularioLoteEdit() {
    var validado = $("#div_LotesForm").valid();
    var validarCantidades = validarValoresTotales();
    if (!validarCantidades) {
        validado = $("#div_LotesForm").valid()
    } 
    if (validado && validarCantidades) {
        saveEditLote();
    }
}
function editarLote(Idlote_) {
    $("#IdLote").val(Idlote_)

    var token = $("[name='__RequestVerificationToken']").val();
    var pRequisicionLote = {
        IdLote: Idlote_,
        IdRequisicion: $("#IdRequisicion").val(),
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pRequisicionLote,
        url: '/Requisiciones/getRequisicionLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                cargarValores(response.objeto);
            }
            else {
                $("#Pop-Up .modal-title").html("Error cargar lote");
                $("#titlePopUp").html(response.data);
                $("#Pop-Up").modal("show");
            }

        }
    });


}

function cargarValores(data) {
    $("#GuardarLote").css({ "display": "none" });
    $("#ActualizarLote").css({ "display": "" });
    $("#modal_nuevo_lote .modal-title").html("Editar lote");
    $("#modal_nuevo_lote").modal("show");

    $("#PrecioUnitarioListaSinImpuestoMensual").val(numeral(data.PrecioUnitario).format('0,0.00'));
    $("#ImporteSinImpuestoMensual").val(numeral(data.Importe).format('0,0.00'));
    $("#importeConImpuesto").val(numeral(data.ImporteCImpuesto).format('0,0.00'));
    $("#ImporteConImpuestoMensual").val(numeral(data.ImporteMesnsualCImpuesto).format('0,0.00'));
    $("#ImporteTotalPeriodo").val(numeral(data.Total).format('0,0.00'));
    $("#Impuesto").val(data.Impuesto);
    $("#ClavePantone").val(data.Pantone)
    $("#Cantidad").val(data.Cantidad)
    $("#Frecuencia").val(data.Frecuencia)
    $("#Producto").val(data.BienServicio)
    $("#Unidad").val(data.UnidadMedida)
    $("#IdBienServicio").val(data.IdBienServicio)
    $("#Caracteristica").val(data.Descripcion)

    $("#TasaImpuesto").val(data.PorcentajeImpuesto)

    $("#De").val(data.MesInicial)
    $("#Al").val(data.MesFinal)
    $("#Meses").val(data.MesesServicio)

    $("#Requerimiento").val(data.IdMuestra)
    $("#ImporteTotalPeriodoActual").val(data.Total)

}

function saveEditLote() {

    var PrecioUnitarioListaSinImpuestoMensual = numeral($("#PrecioUnitarioListaSinImpuestoMensual").val()).value();
    var ImporteSinImpuestoMensual = numeral($("#ImporteSinImpuestoMensual").val()).value();
    var importeConImpuesto = numeral($("#importeConImpuesto").val()).value();
    var ImporteConImpuestoMensual = numeral($("#ImporteConImpuestoMensual").val()).value();
    var ImporteTotalPeriodo = numeral($("#ImporteTotalPeriodo").val()).value();
    var token = $("[name='__RequestVerificationToken']").val();
    var Idlote_ = $("#IdLote").val();
    var pRequisicionLote = {
        IdLote: Idlote_,
        IdRequisicion: $("#IdRequisicion").val(),
        NoLote: 0,
        IdBienServicio: $("#IdBienServicio").val(),
        Pantone: $("#ClavePantone").val(),
        Cantidad: $("#Cantidad").val(),
        PrecioUnitario: PrecioUnitarioListaSinImpuestoMensual,
        Importe: ImporteSinImpuestoMensual,
        PorcentajeImpuesto: $("#TasaImpuesto").val(),
        ImporteCImpuesto: importeConImpuesto,
        ImporteMesnsualCImpuesto: ImporteConImpuestoMensual,
        MesesServicio: $("#Meses").val(),
        Total: ImporteTotalPeriodo,
        MesInicial: $("#De").val(),
        MesFinal: $("#Al").val(),
        Frecuencia: $("#Frecuencia").val(),
        IdMuestra: $("#Requerimiento").val(),
        FechaRegistro: 0,
        IdUsuarioRegistro: 0,
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pRequisicionLote,
        url: '/Requisiciones/saveEditLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {

                resetform();
                cargartablaLotes(response.data);
                $("#LoteCOndiconEntregaDetalle").load(" #LoteCOndiconEntregaDetalle");
                calcularPorcentaje();
            }
            else {
                $("#Pop-Up .modal-title").html("Error actualizar lote");
                $("#titlePopUp").html(response.data);
                $("#Pop-Up").modal("show");
            }

        }
    });
}

function resetform() {

    $("#GuardarLote").css({ "display": "" });
    $("#ActualizarLote").css({ "display": "none" });
    $("#modal_nuevo_lote .modal-title").html("Nuevo Lote");
    $("#modal_nuevo_lote").modal("hide");
    $("#div_LotesForm")[0].reset();
    $("#ResultadoBuscar").html('');
    $("#IdLote").val(0);
    $("#ImporteTotalConImpuestoDiv").load(" #ImporteTotalConImpuestoDiv");
    $("#navbarToggleExternalContent").load(" #navbarToggleExternalContent", function (data) {

        var idTab = $("#Formulario").val();
        if (idTab != "DatosGeneralesTabPadre") {
            $("#" + idTab).addClass('active')
            $("#DatosGeneralesTabPadre").removeClass('active')
        }

        $('.nav li a').click(function (e) {
            var i = $(this).attr('id');
            switch (i) {
                case "div_firmantesTabPadre":
                    $("#btnGuardarValidaciones").html("Enviar a revisión");
                    break;
                default:
                    $("#btnGuardarValidaciones").html("Guardar");
                    break;
            }
            $("#Formulario").val(i);
        });

    });

}

function validarValoresTotales() {
    var idLote = $("#IdLote").val();
    var totalAltaLote = 0;
    var totalAnterior = 0;
    var totalGeneral = numeral($("#ImporteTotalConImpuesto").val()).value();
    var canidad = numeral($("#Cantidad").val()).value();
    if (canidad == null) {
        $("#Cantidad").val(0)
        return false;
    }
    if (idLote != 0) {
        totalAnterior = numeral($("#ImporteTotalPeriodoActual").val()).value();

        totalGeneral = totalGeneral - totalAnterior;
    }

    totalAltaLote = numeral($("#ImporteTotalPeriodo").val()).value();
    var montoPresupuestoAutorizado = numeral($("#MontoPresupuestoAutorizado").val()).value();

    if ((montoPresupuestoAutorizado - (totalGeneral + totalAltaLote)) < 0) {
        $("#Pop-Up .modal-title").html("Error en monto autorizado lote");
        $("#titlePopUp").html("El monto lote($" + numeral(totalAltaLote).format('0,0.00') + ") más el monto capturado($" + numeral(totalGeneral).format('0,0.00') + ") sobre pasa lo autorizado($" + numeral(montoPresupuestoAutorizado).format('0,0.00') + ") ");
        $("#Pop-Up").modal("show");
        return false;
    }
    else {
        return true;
    }
}

function nuevaCondicionDePago() {
    resetformConcionesDeEntrega();
    $("#modal_condiciones_entrega .modal-title").html("Alta condición entrega");
    $("#modal_condiciones_entrega").modal("show");

}
function resetformConcionesDeEntrega() {

    $("#GuardarCondicionesDeEntrega").css({ "display": "" });
    $("#ActualizarCondicionesDeEntrega").css({ "display": "none" });
    $("#modal_condiciones_entrega .modal-title").html("Alta condición entrega");
    $("#modal_condiciones_entrega").modal("hide");
    $("#div_condiciones_entregaForm")[0].reset();
    $("#ResultadoBuscar").html('');
}
function saveCondcionesDeEntrega() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicionCondicionEntrega = $("#IdRequisicionCondicionEntrega").val();
    var url_ = "";
    var parametros = {
        IdRequisicionCondicionEntrega: $("#IdRequisicionCondicionEntrega").val(),
        IdRequisicion: $("#IdRequisicion").val(),
        IdTipoDia: $("#IdTipoDia").val(),
        IdPlazoEntegra: $("#IdPlazoEntegra").val(),
        PlazoEntregaCantidad: $("#PlazoEntregaCantidad").val(),
        FechaLimite: $("#FechaLimite").val(),
        IdTipoEntrega: $("#IdTipoEntrega").val(),
        Observaciones: " ",
        NotaEspecial: $("#NotaEspecial").val(),
        IdEstatus: 1,
        IdUsuarioRegistro: 0,
        FechaRegistro: "",
        IdPlazoTiempo: $("#IdPlazoTiempo").val(),
        __RequestVerificationToken: token

    };
    if (IdRequisicionCondicionEntrega == 0) {
        url_ = '/Requisiciones/saveCondiconesDeEntrega/'
    }
    else {
        url_ = '/Requisiciones/saveEditCondiconesDeEntrega/'
    }
    $.ajax({
        data: parametros,
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
           
            if (response.success) {
                //bootbox.alert({
                //    title: "Alta condiciones de entrega",
                //    message: "Datos guardados correctamente",
                //    size: "small"
                //})
                mensajeGenerico("Aviso", 'Datos guardados correctamente', "");
                $("#cargarLoadCondicionesDeEntrega").load(" #cargarLoadCondicionesDeEntrega");
            }
            else {
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>', "");
                //bootbox.alert({
                //    title: "Alta condiciones de entrega",
                //    message: "Error en el Guardado: " + response.mensaje,
                //    size: "small"
                //})
                
            }

        }
    });
}

function menssage(title, cuerpo) {
    $("#Pop-Up .modal-title").html(title);
    $("#titlePopUp").html(cuerpo);
    $("#Pop-Up").modal("show");
}

function getDireccion() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntrega").val();
    var url_ = '/Requisiciones/getLugarEntrega_x_IdLugarEntrega/'
    $.ajax({
        data: { __RequestVerificationToken: token, IdLugarEntrega: IdLugarEntrega_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {

                $("#Direccion").val(response.objeto.Direccion + ' ' + response.objeto.Colonia);
                placeMarker(response.objeto.LocalizacionGoogle);
            }
            else {
                //bootbox.alert({
                //    title: "Alta condiciones de entrega",
                //    message: "Error en el Guardado: " + response.mensaje,
                //    size: "small"
                //});
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>', "");
                //menssage("Alta condiciones de entrega", "Error en el Guardado: " + response.mensaje)
            }
        }
    });
}

function validarFomCondiconesDeEntregaDetalle() {
    var validado = $("#CondicionesDeEntregaDetalleForm").valid();
    var Semana = $("#SemanaSelect").html()
    var valido = true


    if (Semana == "") {
        //bootbox.alert({
        //    title: "Alta condiciones de entrega detalle",
        //    message: "Falta seleccionar días de entrega",
        //    size: "small"
        //});
        mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">Falta seleccionar días de entrega</div>', "");
        //menssage("Alta condiciones de entrega detalle", "Falta seleccionar días de entrega")
        valido = false;
    }
    if (!validarCantidadesCondiconesEntregaDetalle()) {
        //bootbox.alert({
        //    title: "Condiciones de entrega detalle",
        //    message: "La cantidad que desea asignar es mayor a la cantidad por asignar.",
        //    size: "small"
        //});
        //menssage("Condiciones de entrega detalle", "La cantidad que desea asignar es mayor a la cantidad por asignar.")
        mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">La cantidad que desea asignar es mayor a la cantidad por asignar.</div>', "");
        valido = false;
    }
    if (validado && valido) {
        saveCondiconesDeEntregaDetalle();
    }
}
function validarCantidadesCondiconesEntregaDetalle() {
    var idCondicionEntregaDetalle = parseFloat($("#IdCondicionEntregaDetalle").val());
    var CantidadLoteXAsignar = parseFloat($("#CantidadLoteXAsignar").val());
    var CantidadDetalleReal = parseFloat($("#CantidadDetalleReal").val());
    var CantidadDetalle = parseFloat($("#CantidadDetalle").val());

    if (idCondicionEntregaDetalle != 0) {
        CantidadLoteXAsignar = CantidadLoteXAsignar + parseFloat(CantidadDetalleReal);
    }

    if ((CantidadLoteXAsignar - CantidadDetalle) < 0) {
        return false;
    }
    else {
        return true;
    }
}
function nuevaCondicionDePagoDetalle() {
    resetformConcionesDeEntregaDetalle();
    $("#modal_condiciones_entrega .modal-title").html("Alta condición entrega detalle");
    $("#modal_condiciones_entrega").modal("show");

}
function resetformConcionesDeEntregaDetalle() {

    $("#GuardarCondicionesDeEntrega").css({ "display": "" });
    $("#ActualizarCondicionesDeEntrega").css({ "display": "none" });
    $("#modal_condiciones_entrega .modal-title").html("Alta condición entrega");
    $("#modal_condiciones_entrega").modal("hide");
    $("#CondicionesDeEntregaDetalleForm")[0].reset();
    $("#SemanaSelect").html("")
    $("#diasDelaSemana").val("")
    $("#IdCondicionEntregaDetalle").val(0)
    $.each($("input[name=semana]"), function () {
        $(this).attr('checked', false);
        $(this).prop('checked', false);
    });
    $('#Semanascheckbox input[name=semana]').prop('checked', false)

    $('#datetimepickerHorarioInicio').datetimepicker({
        language: 'es',
        format: "H:ii",
        timeFormat: 'H:ii',
        startView: 0,
        minView: 0,
        autoclose: 1
    });
    $('#datetimepickerHorarioFin').datetimepicker({
        language: 'es',
        format: "H:ii",
        timeFormat: 'H:ii',
        startView: 0,
        minView: 0,
        autoclose: 1,

    });
}
function saveCondiconesDeEntregaDetalle() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntrega").val();
    var IdCondicionEntregaDetalle = $("#IdCondicionEntregaDetalle").val()
    var parametro = {
        IdCondicionEntregaDetalle: IdCondicionEntregaDetalle,
        IdRequisicionCondicionEntrega: $("#IdRequisicionCondicionEntrega").val(),
        IdLugarEntrega: $("#IdLugarEntrega").val(),
        NumeroEntrega: 0,
        IdRequisicionLote: $("#IdRequisicionLote").val(),
        Cantidad: $("#CantidadDetalle").val(),
        HorarioInicio: $("#HorarioInicio").val(),
        HorarioFinal: $("#HorarioFinal").val(),
        Lunes: buscarSemana("Lunes"),
        Martes: buscarSemana("Martes"),
        Miercoles: buscarSemana("Miercoles"),
        Jueves: buscarSemana("Jueves"),
        Viernes: buscarSemana("Viernes"),
        Sabado: buscarSemana("Sabado"),
        Domingo: buscarSemana("Domingo"),
        __RequestVerificationToken: token
    };
    var url_ = '/Requisiciones/saveCondicionesDeEntregaDetalle/'
    if (IdCondicionEntregaDetalle != 0) {
        var url_ = '/Requisiciones/saveEditCondicionesDeEntregaDetalle/'
    }
    $.ajax({
        data: parametro,
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                nuevaCondicionDePagoDetalle()
                cargartablaCondicionesDeEntraga(response.lst);
                //bootbox.alert({
                //    title: "Alta condiciones de entrega detalle",
                //    message: "Datos guardados correctamente",
                //    size: "small"
                //})
                mensajeGenerico("Aviso", 'Datos guardados correctamente', "");
                //menssage("Alta condiciones de entrega detalle", "Datos guardados correctamente")
                $("#LoteCOndiconEntregaDetalle").load(" #LoteCOndiconEntregaDetalle");



            }
            else {
                //bootbox.alert({
                //    title: "Alta condiciones de entrega detalle",
                //    message: "Error en el Guardado: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje+'.</div>', "");
                //menssage("Alta condiciones de entrega detalle", "Error en el Guardado: " + response.mensaje)
            }

        }
    });
}

function editarCondicinesEntregaDetalle(IdCondicionEntregaDetalle_) {
    var token = $("[name='__RequestVerificationToken']").val();
    $("#IdCondicionEntregaDetalle").val(IdCondicionEntregaDetalle_)
    var url_ = '/Requisiciones/getCondicionEntregaDetalle/'
    $.ajax({
        data: { IdCondicionEntregaDetalle: IdCondicionEntregaDetalle_, __RequestVerificationToken: token },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {

                $("#IdRequisicionCondicionEntrega").val(response.objeto.IdRequisicionCondicionEntrega)
                $("#IdLugarEntrega").val(response.objeto.IdLugarEntrega)
                $("#IdRequisicionLote").val(response.objeto.IdRequisicionLote)
                $("#CantidadDetalle").val(response.objeto.Cantidad)
                $("#HorarioInicio").val(response.objeto.HorarioInicio.Hours + ":" + response.objeto.HorarioInicio.Minutes)
                $("#CantidadDetalleReal").val(response.objeto.Cantidad)
                $("#HorarioFinal").val(response.objeto.HorarioFinal.Hours + ":" + response.objeto.HorarioFinal.Minutes)
                $("#GuardarCondicionesDeEntrega").css({ "display": "none" });
                $("#ActualizarCondicionesDeEntrega").css({ "display": "" });
                $("#modal_condiciones_entrega .modal-title").html("Actualizar Condición entrega Detalle");
                $("#modal_condiciones_entrega").modal("show");
                getDireccion()
                var cadena = "";
                $.each($("input[name=semana]"), function () {
                    switch ($(this).val()) {
                        case "Lunes":
                            $(this).attr('checked', response.objeto.Lunes == 1 ? true : false);


                            break;
                        case "Martes":
                            $(this).attr('checked', response.objeto.Martes == 1 ? true : false);

                            break;
                        case "Miercoles":
                            $(this).attr('checked', response.objeto.Miercoles == 1 ? true : false);

                            break;
                        case "Jueves":
                            $(this).attr('checked', response.objeto.Jueves == 1 ? true : false);

                            break;
                        case "Viernes":
                            $(this).attr('checked', response.objeto.Viernes == 1 ? true : false);

                            break;
                        case "Sabado":
                            $(this).attr('checked', response.objeto.Sabado == 1 ? true : false);

                            break;
                        case "Domingo":
                            $(this).attr('checked', response.objeto.Domingo == 1 ? true : false);

                            break;
                    }
                });

                var values = new Array();
                var cadena = "";
                $.each($("input[name=semana]:checked"), function () {
                    values.push($(this).val());
                    cadena += '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">' + $(this).val() + '</span></button>';
                });
                $("#diasDelaSemana").val(values.join(','));
                $("#SemanaSelect").html(cadena);
                getCantidad_x_Idlote();
            }
            else {
                //bootbox.alert({
                //    title: "Actualizar condición de entrega detalle",
                //    message: "Error en el guardado: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Actualizar condición de entrega detalle", "Error en el guardado: " + response.mensaje)
            }

        }
    });
}

function eliminarCondicinesEntregaDetalle(IdCondicionEntregaDetalle_) {
    bootbox.confirm({
        message: "¿Desea elimnar el registro?",
        buttons: {
            confirm: {
                label: 'SI'
            },
            cancel: {
                label: 'No'
            }
        },
        callback: function (result) {
            if (!result) return false;
            var token = $("[name='__RequestVerificationToken']").val();
            var url_ = '/Requisiciones/eliminarCondicionEntregaDetalle/'
            $.ajax({
                data: { IdCondicionEntregaDetalle: IdCondicionEntregaDetalle_, IdRequisicionCondicionEntrega: $("#IdRequisicionCondicionEntrega").val(), __RequestVerificationToken: token },
                url: url_,
                type: 'post',
                beforeSend: function () {

                },
                success: function (response) {

                    if (response.success) {

                        cargartablaCondicionesDeEntraga(response.lst);
                        bootbox.alert({
                            title: "Elimnar condiciones de entrega detalle",
                            message: "Datos eliminado correctamente",
                            size: "small"
                        })
                        mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-success col-sm-12">Datos eliminado correctamente.</div>', "");
                        //menssage("Elimnar condiciones de entrega detalle", "Datos eliminado correctamente")
                        $("#LoteCOndiconEntregaDetalle").load(" #LoteCOndiconEntregaDetalle");
                    }
                    else {
                        //bootbox.alert({
                        //    title: "Actualizar condición de entrega detalle",
                        //    message: "Error en el guardado: " + response.mensaje,
                        //    size: "small"
                        //})
                        mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                        //menssage("Actualizar condición de entrega detalle", "Error en el guardado: " + response.mensaje)
                    }

                }
            });
        }
    });

}
function buscarSemana(dia) {
    arraySemana = $("#diasDelaSemana").val().split(',');
    var index = arraySemana.indexOf(dia);
    if (index > -1) {
        return 1;
    }
    else {
        return 0;
    }
}
function cargarColumnasCondicionEntregaDetalle() {
    var dataRow = Array();
    dataRow = [
        {
            mRender: function (data, type, row) {
                return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarCondicinesEntregaDetalle(' + row.IdCondicionEntregaDetalle + ')" ><span class="fa fa-pencil" ></span></button>' +
                    '<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarCondicinesEntregaDetalle(' + row.IdCondicionEntregaDetalle + ')" ><span class="fa fa-trash-o" ></span></button></div>'
            }
        },
        { "data": "NumeroEntrega", sortable: true },
        { "data": "NoLote", sortable: true },
        { "data": "CantidadEntregaDetalle", sortable: true },
        { "data": "Lugar", sortable: true },
        { "data": "DomicilioEntrega", sortable: true },
        {
            mRender: function (data, type, row) {

                return '<div id="map-' + row.i + '" class="maps" style="width:150px;height:150px"></div >' +
                    '<input type="hidden" class="inpt" value="' + row.LocalizacionGoogle + '" />'
            }
        },

        {
            "data": "HorarioInicio", sortable: true, render:
                function (data, type, row) {
                    var dt = row.HorarioInicio;

                    var hours = dt.Hours;
                    var minutes = dt.Minutes;
                    var seconds = dt.Seconds;

                    // the above dt.get...() functions return a single digit
                    // so I prepend the zero here when needed
                    if (hours < 10)
                        hours = '0' + hours;

                    if (minutes < 10)
                        minutes = '0' + minutes;

                    if (seconds < 10)
                        seconds = '0' + seconds;

                    return hours + ":" + minutes + ":" + seconds;
                }
        },
        {
            "data": "HorarioFinal", sortable: true, render:
                function (data, type, row) {
                    var dt = row.HorarioFinal;

                    var hours = dt.Hours;
                    var minutes = dt.Minutes;
                    var seconds = dt.Seconds;

                    // the above dt.get...() functions return a single digit
                    // so I prepend the zero here when needed
                    if (hours < 10)
                        hours = '0' + hours;

                    if (minutes < 10)
                        minutes = '0' + minutes;

                    if (seconds < 10)
                        seconds = '0' + seconds;

                    return hours + ":" + minutes + ":" + seconds;
                }
        },

        {
            mRender: function (data, type, row) {
                var cadena = "";
                cadena += row.Lunes == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light"> Lunes </span></button>' : '';
                cadena += row.Martes == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">Martes</span></button>' : '';
                cadena += row.Miercoles == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light"> Miercoles </span></button>' : '';
                cadena += row.Jueves == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">Jueves </span></button>' : '';
                cadena += row.Viernes == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light"> Viernes </span></button>' : '';
                cadena += row.Sabado == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">Sabado </span></button>' : '';
                cadena += row.Domingo == 1 ? '<button type="button" class="btn btn-secondary btn-sm"><span class="badge badge-light">Domingo </span></button>' : '';

                return cadena;
            }
        }
    ];

    return dataRow;
}
function cargartablaCondicionesDeEntraga(data) {
    $('#condicionesDeEntragaTable').dataTable({
        "bDestroy": true
    }).fnDestroy();

    $('#condicionesDeEntragaTable').dataTable().fnDestroy();

    var table = $('#condicionesDeEntragaTable').DataTable({
        scrollY: "280px",
        scrollX: true,
        data: data,
        "columns": cargarColumnasCondicionEntregaDetalle(),
        "language": {
            "emptyTable": ""
        }
    });
    initAutocomplete()
}
function getCantidad_x_Idlote() {
    var token = $("[name='__RequestVerificationToken']").val();
    var url_ = '/Requisiciones/getCantidad_x_Idlote/';
    var IdRequisicionLote = $("#IdRequisicionLote").val()
    $.ajax({
        data: { IdRequisicionLote: IdRequisicionLote, IdRequisicion: $("#IdRequisicion").val(), __RequestVerificationToken: token },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {

                $("#CantidadLoteAsignado").val(response.objeto.CantidadLoteAsignado)
                $("#CantidadLoteXAsignar").val(response.objeto.CantidadxAsignar)
            }
            else {
                //bootbox.alert({
                //    title: "Actualizar Condición de entrega detalle",
                //    message: "Error en el Cargar cantidades: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Actualizar Condición de entrega detalle", "Error en el Cargar cantidades: " + response.mensaje)
            }

        }
    });
}

function getDireccionPago() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntregaPago").val();
    var url_ = '/Requisiciones/getLugarEntrega_x_IdLugarEntrega/'
    if (IdLugarEntrega_ == "") {
        IdLugarEntrega_ = 0;
    }
    $.ajax({
        data: { __RequestVerificationToken: token, IdLugarEntrega: IdLugarEntrega_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {

                //$("#Direccion").val(response.objeto.Direccion + ' ' + response.objeto.Colonia);
                placeMarkerPorMapa(response.objeto.LocalizacionGoogle, "mapFirmaPago");
            }
            else {
                //bootbox.alert({
                //    title: "Alta condiciones de entrega",
                //    message: "Error en el guardado: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Alta condiciones de entrega", "Error en el guardado: " + response.mensaje)
            }

        }
    });
}

function validarCheckAnticipo() {
    var check = $("#customRadio1");

    if (check.is(':checked')) {
        if ($("#IdRequisicionCondicionPago").val() == 0)
            $("#IdAnticipo").val(1)
        $("#IdAnticipo").removeClass('disabledClick')
        calcularPorcentaje()
        var table = $('#tablaPagos').DataTable();

        $("#IdAnticipoBool").val(check.val())

    }
    var check = $("#customRadio2");
    if (check.is(':checked')) {
        $("#IdAnticipo").val("")
        $("#IdAnticipo").addClass('disabledClick')
        calcularPorcentaje()
        var table = $('#tablaPagos').DataTable();

        $("#IdAnticipoBool").val(check.val())
    }
}

function calcularPorcentaje() {
    var IdAnticipo_ = $("#IdAnticipo").val();
    if (IdAnticipo_ == "") {
        IdAnticipo_ = 0;
    }
    var token = $("[name='__RequestVerificationToken']").val();
    var url_ = '/Requisiciones/getAnticipo/'
    $.ajax({
        data: { __RequestVerificationToken: token, IdAnticipo: IdAnticipo_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                var porcentaje = parseFloat(response.objeto.PorcentajeValor);
                $("#porcentajeAplicado").val(porcentaje);
                var ImporteTotalConImpuesto = parseFloat(numeral($("#ImporteTotalConImpuesto").val()).value());
                var impuestoCalculado = ImporteTotalConImpuesto * porcentaje;
                var importeTotalPagosPendiente = ImporteTotalConImpuesto - impuestoCalculado
                $("#ImporteAnticipo").val(numeral(impuestoCalculado).format('0,0.00'));
                $("#importeTotalPagosPendiente").val(numeral(importeTotalPagosPendiente).format('0,0.00'));
                $("#ImporteTotalPago").val(numeral(ImporteTotalConImpuesto).format('0,0.00'));

            }
            else {
                //bootbox.alert({
                //    title: "Condiciones de entrega",
                //    message: "Error concultar anticipo: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Condiciones de entrega", "Error concultar anticipo: " + response.mensaje)
            }

        }
    });
}

function getCalculoPartida() {
    var IdPeriodicidad_ = $("#IdPeriodicidad").val();
    var cantidadPagos_ = $("#numeroPagosAGenerar").val();
    var importeRestante_ = numeral($("#importeTotalPagosPendiente").val()).value();
    var porcentajeAplicado_ = $("#porcentajeAplicado").val()
    var token = $("[name='__RequestVerificationToken']").val();
    var FechaInicioPago_ = $("#FechaInicioPago").val();
    var url_ = '/Requisiciones/getCalculoPartida/'
    $.ajax({
        data: { __RequestVerificationToken: token, IdPeriodicidad: IdPeriodicidad_, cantidadPagos: cantidadPagos_, importeRestante: importeRestante_, porcentajeAplicado: porcentajeAplicado_, FechaInicioPago: FechaInicioPago_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {

                cargartablaPagos(response.lst)
            }
            else {
                //bootbox.alert({
                //    title: "Condiciones de entrega",
                //    message: "Error concultar anticipo: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Condiciones de entrega", "Error concultar anticipo: " + response.mensaje)
            }

        }
    });
}
function cargartablaPagos(data) {
    $('#tablaPagos').dataTable({
        "bDestroy": true
    }).fnDestroy();

    $('#tablaPagos').dataTable().fnDestroy();

    var table = $('#tablaPagos').DataTable({
        scrollY: "280px",
        scrollX: true,
        sort: false,
        "language": {
            "emptyTable": ""
        },
        data: data,
        order: [[1, "asc"]],
        columnDefs: [
            { targets: [2, 3], className: "dt-body-right" },

        ],
        "columns": cargarColumnasPago(),
        "footerCallback": function (row, data, start, end, display) {
            var api = this.api(), data;

            // Remove the formatting to get integer data for summation
            var intVal = function (i) {
                return typeof i === 'string' ?
                    i.replace(/[\$,]/g, '') * 1 :
                    typeof i === 'number' ?
                        i : 0;
            };
            var intValPorcentaje = function (i) {
                return typeof i === 'string' ?
                    i.replace(/[\%,]/g, '') * 1 :
                    typeof i === 'number' ?
                        i : 0;
            };

            // Total over all pages
            totalPorcentaje = api
                .column(3)
                .data()
                .reduce(function (a, b) {
                    return intValPorcentaje(a) + intValPorcentaje(b);
                }, 0);

            // Total over all pages
            total = api
                .column(2)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Total over this page
            pageTotalPorcentaje = api
                .column(3, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intValPorcentaje(a) + intValPorcentaje(b);
                }, 0);
            // Total over this page
            pageTotal = api
                .column(2, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Update footer
            var numpageTotal = parseFloat(pageTotal);
            var numtotal = parseFloat(total);
            $(api.column(2).footer()).html(
                //'subtotal: $' + numeral(numpageTotal).format('0,0.00') + '\n de Total( $' + numeral(numtotal).format('0,0.00') + ')'
                '$'+numeral(numtotal).format('0,0.00')
            );
            // Update footer
            var numpageTotalPorcentaje = parseFloat(pageTotalPorcentaje);
            var numtotalPorcentaje = parseFloat(totalPorcentaje);
            $(api.column(3).footer()).html(
                /*'%' + numpageTotalPorcentaje.toFixed(2) + */  numtotalPorcentaje.toFixed(2) + ' %'
            );
        }
    });
}
function cargarColumnasPago() {
    dataRow = [
        {
            mRender: function (data, type, row) {
                var disable = row.bool1 ? "" : "disabledClick";
                return '<div class="btn-group"><button class="btn btn-secondary btn-sm ' + disable + '" style="margin-right:5px;" onclick="editarLote(' + row.id2 + ')" ><span class="fa fa-pencil" ></span></button></div>'
            }
        },
        { "data": "id", sortable: true },
        { "data": "decimal1", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
        { "data": "decimal2", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '%') },
        { "data": "string1", sortable: true },
        { "data": "string2", sortable: true },
    ];
    return dataRow;
}

function saveCondicionPago() {
    var table = $('#tablaPagos').DataTable();

    if (!table.data().count()) {
        bootbox.alert({
            title: "Alta condiciones de pago",
            message: "Error en el guardado, falta generar desglose de pagos",
            size: "small"
        })
        //menssage("Alta condiciones de pago", "Error en el Guardado, falta generar desglose de pagos")
        return;
    }
    var importeTotalPagosPendiente_ = numeral($("#importeTotalPagosPendiente").val()).value();
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicionCondicionPago_ = $("#IdRequisicionCondicionPago").val();
    var ImporteAnticipo_ = numeral($("#ImporteAnticipo").val()).value();
    var parametro = {
        IdRequisicionCondicionPago: IdRequisicionCondicionPago_,
        IdRequisicion: $("#IdRequisicion").val(),
        Anticipo: $("#IdAnticipoBool").val() == 1 ? true : false,
        IdAnticipo: $("#IdAnticipo").val(),
        PorcentajeAnticipo: $("#porcentajeAplicado").val(),
        ImporteAnticipo: ImporteAnticipo_,
        IdPeriodicidad: $("#IdPeriodicidad").val(),
        NumeroPagos: $("#numeroPagosAGenerar").val(),
        ImporteTotalPagos: importeTotalPagosPendiente_,
        IdEstatus: 0,
        Observaciones: "",
        IdUsuarioRegistro: 0,
        FechaRegistro: "",
        IdTipoCondicionPago: $("#IdCondicionPago").val(),
        IdTipoDia: $("#IdTipoDiaPago").val(),
        IdPlazoTiempo: $("#IdPlazoTiempoPago").val(),
        IdLugarFirma: $("#IdLugarEntregaPago").val(),
        PlazoPagoCantidad: $("#PlazoPagoCantidad").val(),
        FechaInicioPago: $("#FechaInicioPago").val(),
        __RequestVerificationToken: token
    };
    var url_ = '/Requisiciones/saveCondicionesPago/'
    if (IdRequisicionCondicionPago_ != 0) {
        var url_ = '/Requisiciones/saveEditCondicionPago/'
    }
    $.ajax({
        data: parametro,
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                //bootbox.alert({
                //    title: "Alta condiciones de Pago",
                //    message: "Datos guardados correctamente",
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-success col-sm-12">Datos guardados correctamente.</div>', "");
                //menssage("Alta condiciones de Pago", "Datos guardados correctamente")
                $("#cargarLoadCondicionesDePgo").load(" #cargarLoadCondicionesDePgo");
                cargartablaPagos(response.lst);
                getDireccionPago();
            }
            else {
                //bootbox.alert({
                //    title: "Alta condiciones de pago",
                //    message: "Error en el Guardado: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Alta condiciones de pago", "Error en el Guardado: " + response.mensaje)
            }

        }
    });
}


function editarCondicionPagoDetalle(id) {
    bootbox.prompt("Agrega nuevo valor para guardar", function (result) {
        if (!result) return false;

        var token = $("[name='__RequestVerificationToken']").val();
        var IdRequisicionCondicionPago_ = $("#IdRequisicionCondicionPago").val()
        var parametro = {
            IdRqCondicionPagoDetalle: id,
            IdRequiscionCondicionPago: IdRequisicionCondicionPago_,
            FechaPago: "",
            PorcentajePago: "",
            NumeroPago: id,
            ImportePago: result,
            __RequestVerificationToken: token
        };
        var url_ = '/Requisiciones/saveEditCondcionPagoDetalle/'
        $.ajax({
            data: parametro,
            url: url_,
            type: 'post',
            beforeSend: function () {

            },
            success: function (response) {
                //console.log(response);
                if (response.success) {
                    //bootbox.alert({
                    //    title: "Condiciones de Pago detalle",
                    //    message: "Datos guardados correctamente",
                    //    size: "small"
                    //})
                    mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-success col-sm-12">Datos guardados correctamente.</div>', "");
                    //menssage("Condiciones de Pago detalle", "Datos guardados correctamente")
                    $("#cargarLoadCondicionesDePgo").load(" #cargarLoadCondicionesDePgo");
                    cargartablaPagos(response.lst);
                    getDireccionPago();
                }
                else {
                    //bootbox.alert({
                    //    title: "Condiciones de pago detalle",
                    //    message: "Error en el Guardado: " + response.mensaje,
                    //    size: "small"
                    //})
                    mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                    //menssage("Condiciones de pago detalle", "Error en el Guardado: " + response.mensaje)
                }

            }
        });
    });


}

function saveFirmantes() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion_ = $("#IdRequisicion").val()
    var url_ = '/Requisiciones/saveFirmantes/'
    $.ajax({
        data: { IdRequisicion: IdRequisicion_, __RequestVerificationToken: token },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                //bootbox.alert({
                //    size: "small",
                //    title: "Enviar a revisión",
                //    message: "Requisición ha sido enviada a revisión",
                //    className: "",
                //    callback: function () {
                //        var a = $("#tipoRequisicion").val();
                //        location.href = '/RequisicionConsulta/Index/' + a;
                //    }
                //})
                var a = $("#tipoRequisicion").val();
                var url_ = '/RequisicionConsulta/Index/' + a;
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-success col-sm-12">Requisición ha sido enviada a revisión.</div>', url_);

            }
            else {
                //bootbox.alert({
                //    title: "Requisición",
                //    message: "Error al enviar requisición a revisión: " + response.mensaje,
                //    size: "small"
                //})
                mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '.</div>', "");
                //menssage("Requisición", "Error al enviar requisición a revisión: " + response.mensaje)
            }

        }
    });
}

function ImprimirDictamen() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicion = $("#IdRequisicion").val();
    var parametros = {
        pIdRequisicion: IdRequisicion,
        __RequestVerificationToken: token
    };
    var boox = bootbox;
    $.ajax({
        data: parametros,
        url: '/Requisiciones/ImprimirSolicitud/',
        type: 'post',
        beforeSend: function () {
            boox.dialog(
                {
                    message: '<div class="text-center"><h1><i class="fa fa-spin fa-spinner"></i> Loading...</h1></div>',
                    title: "<div class='col-12 text-center'>Descargando archivo</div>",
                    closeButton: false
                })
        },
        success: function (response) {
           // console.log(response);
            if (response.success) {
                $('.bootbox.modal').modal('hide');
               
                window.open(document.location.origin + "/Files/Reportes/" + response.Descarga, "_blank");
            }
            else {
                bootbox.alert({
                    title: "Alta condiciones de entrega",
                    message: "Error descargar documento: " + response.mensaje,
                    size: "small"
                });
                $('.bootbox.modal').modal('hide');
            }
        }
    });
}
function asignarProveedor(IdProveedor) {

    var check = $("#" + IdProveedor);

    var parametros = {

        //IdRequisicionProveedorInvitacion
        IdRequisicion: $("#IdRequisicion").val(),
        IdProveedor: IdProveedor,
        IdRequisicionProveedorInvitacion: 0,

       

        IdUsuarioRegistro: 0,
        FechaRegistro: '',
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    if (check.is(':checked')) {

        $.post("/Requisiciones/AsignarProveedor/", parametros, "JSON")
            .done(function (data) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Proveedor asignado correctamente"
                })
                $('#tabla_asignar_proveedores').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tabla_asignar_proveedores').dataTable().fnDestroy();
                $("#cargarAsignacionProveedor").load(" #cargarAsignacionProveedor", function () {

                    $('#tabla_asignar_proveedores').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    $("#modal_nuevo_lote").modal("hide");
                })

               

            }).fail(function (data) {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error al asignar Proveedor</div>`,
                    message: "Error producido por: " + data.mensaje
                })
            });
    } else {

        var IdRequisicionProveedorInvitacion_ = $("#" + IdProveedor).attr("data-IdAdjudicacionProveedor");

        var parameters = {
            IdRequisicionProveedorInvitacion: IdRequisicionProveedorInvitacion_,
            __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
        };

        $.post("/Requisiciones/QuitarProveedor/", parameters, "JSON")
            .done(function (data) {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Proveedor eliminado correctamente de la requisición"
                })
                $('#tabla_asignar_proveedores').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#tabla_asignar_proveedores').dataTable().fnDestroy();
                $("#cargarAsignacionProveedor").load(" #cargarAsignacionProveedor", function () {

                    $('#tabla_asignar_proveedores').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    $("#modal_nuevo_lote").modal("hide");
                })
               

            }).fail(function (data) {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error al eliminar Proveedor</div>`,
                    message: "Error producido por: " + data.mensaje
                })
            });
    }

}

function saveRequisicionSegundaVuelta(aceptarRechazar) {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdEstatusRequisicion_ = aceptarRechazar ? 10 : 150;
    var parametros = {
        IdRequisicion: $("#IdRequisicion").val(),
        IdEstatusRequisicion: IdEstatusRequisicion_,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Requisiciones/saveRequisicionSegundaVuelta/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            //console.log(response);
            if (response.success) {
                var url_ = '/RequisicionesSegundaVueltaConsulta/Index/';
                var mensaje_ = IdEstatusRequisicion_ == 10 ? "Se ha aceptado la requisición " + response.objeto.RequisicionFolio + ", para procesar segunda vuelta.<br>Se ha enviado la solicitud número " + response.objeto.RequisicionFolio +"  correctamente, para la autorización de presupuesto y liquidez, a partir de este momento cuenta con 24 horas para recibir una respuesta y pueda continuar con la captura de la solicitud" : "Se ha rechazado la requisición " + response.objeto.RequisicionFolio + " correctamente, ya no se podra procesar para segunda vuelta";
                mensajeGenerico("Aviso", mensaje_, url_);

            }
            else {
                mensajeGenerico("Aviso", '<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >', "");
                //$("#ResultadoBuscar").html();
            }

        }
    });
}