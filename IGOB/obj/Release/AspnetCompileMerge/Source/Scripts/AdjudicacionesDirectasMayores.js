$(document).ready(function () {
    $("#IdLugarEntregaPago").length === 1 && $("#IdLugarEntregaPago").val() !== "" ? getDireccionPago() : false;
    if (Perfil === 3 && (Estatus == 10 || Estatus == 20 || Estatus == 0))
        $("#btnAutoriza").prop("disabled", ($("#btnAutoriza").val() > 5000 && $("#btnAutoriza").val() < 54000 ? false : true))
    if (Perfil === 2)
        compare(numeral($("#MontoPresupuestadoAutorizado").val())["_value"]);

    if (Perfil === 8) {
        $("#LotesTable").DataTable({
            paging: false,
            sort: false,
            language: {
                "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
            }
        });
    } else {
        $("#LotesTable").DataTable({
            pageLength: 5,
            scrollX: true,
            sort: false,
            lengthMenu: [5, 10, 25, 50, 100],
            language: {
                "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
            }
        });
    }

    $("#ValidaLotes1, #ValidaCondicionEntrega1, #ValidaCondicionPago1 ").prop("checked", "true");
    $("#ObservacionLotes, #OnservacionCondicionEntrega, #ObservacionCondicionPago").removeAttr("readonly");

    $('.datepicker, #FechaLimite, #FechaInicioPago').datetimepicker({
        language: 'es',
        format: "yyyy-m-dd",
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



    $('body').on("click", ".nav li a", function (e) {
        var i = $(this).attr('id');
        var idPerfil = Perfil;

        $(".tab-content").children("div").removeClass("active show");
        $(`#${$(this).attr('href').replace('#', '')}`).addClass("active show");

        if (idPerfil === 4) {

            switch (i) {
                case "div_firmantesTabPadre":
                    $("#btnAutoriza, #btnRechaza").show();
                    break;
                default:
                    $("#btnAutoriza, #btnRechaza").hide();
                    break;
            }
        } else if (idPerfil === 8) {
            switch (i) {
                case "div_propuesta_tecnicaTabPadre":
                    $("#btnProveedorAutorizaTec").show();
                    $("#sumario #div_condiciones_entrega, #sumario #div_condiciones_pago").remove();
                    $("#div_condiciones_entrega").clone().appendTo("#sumario");
                    $("#div_condiciones_pago").clone().appendTo("#sumario");

                    $('#div_propuesta_tecnica').find('input, textarea, button, select').attr('disabled', 'disabled');
                    $("#div_propuesta_tecnica #idNuevaCondicionDePago").hide();

                    $("#btnProveedorAutoriza").attr('disabled', 'disabled');

                    $("#aceptar_propuestaTec").find('input').removeAttr('disabled');

                    $("#div_propuesta_tecnica").find(".disabledClick").css({
                        "opacity": 1,
                        "pointer-events": "initial"
                    });
                    break;
                default:
                    $("#btnProveedorAutorizaTec").hide();
                    break;
            }

        } else if (idPerfil === 3 && Estatus === 50) {
            switch (i) {
                case "DatosGeneralesTabPadre":
                case "div_presupuesto_liquidezTabPadre":
                case "div_lotesTabPadre":
                    $("#btnAutoriza, #btnRechaza").hide();
                    break;
                case "div_asignar_proveedores":
                    $("#btnAutoriza").val("Autorizar");
                    break;
                default:
                    $("#btnAutoriza, #btnRechaza").show();
                    break;
            }

        } else {
            switch (i) {
                case "div_firmantesTabPadre":
                    $("#btnGuardarValidaciones").html("Enviar a revisión");

                    break;
                case "div_lotesTabPadre":
                //case "div_condiciones_pagoTabPadre":
                    $("#btnAutoriza").hide();
                    break;
                default:
                    $("#btnAutoriza").show();
                    $("#btnGuardarValidaciones").html("Guardar");
                    break;
            }

        }

        $("#Formulario").val(i);

    });

    if (Perfil !== 8) {
        $("#DatosGeneralesTabPadre").addClass("active show");
    } else {
        $(".tab-content").children("div").removeClass("active show");
        $("#div_lotes").addClass("active show");
    }

    $("#CondicionEntregaNotaEspecial").on("click", function () {
        $(".modal-title").html(`<div class="text-center">Nota especial</div>`);
        $("#modal_condcionesDePago_NotaEspecial").modal("show");
    });

});

function changestatus(input, status) {
    switch ($(input).prop('name')) {
        case "ValidaLotes":
            $("#ObservacionLotes").prop("readonly", status);
            break;
        case "ValidaCondicionEntrega":
            $("#OnservacionCondicionEntrega").prop("readonly", status);
            break;
        case "ValidaCondicionPago":
            $("#ObservacionCondicionPago").prop("readonly", status);
            break;
        default:
            break;
    }
}

function activateButtons() {
    let activo = true;
    $("input[type='radio']:checked").each(function () {
        $(this).val() == "false" ? activo = false : "";
    });
    return activo;
}

function validateRadio() {
    let validate = false;
    ($("input[name='ValidaLotes']").is(':checked') && $("input[name='ValidaCondicionEntrega']").is(':checked') && $("input[name='ValidaCondicionPago']").is(':checked')) ? validate = true : validate = false;
    return validate;
}

function validaRechazo() {
    ($("input[name='ValidaLotes']:checked").val() == "true" && $("input[name='ValidaCondicionEntrega']:checked").val() == "true" && $("input[name='ValidaCondicionPago']:checked").val() == "true") ? $('#Rechazar').prop('disabled', true) : $('#Rechazar').prop('disabled', false);
}

function validaObservaciones() {
    let validarCampos = "";
    $("input[type='radio']:checked").each(function () {
        if ($(this).val() == "false") {
            switch ($(this).prop('name')) {
                case "ValidaLotes":
                    $("#ObservacionLotes").val().trim() === "" ? validarCampos += `Rellene: Observación Lotes<br\>` : "";
                    break;
                case "ValidaCondicionEntrega":
                    $("#OnservacionCondicionEntrega").val().trim() === "" ? validarCampos += `Rellene: Observación Condición Entrega<br\>` : "";
                    break;
                case "ValidaCondicionPago":
                    $("#ObservacionCondicionPago").val().trim() === "" ? validarCampos += `Rellene: Observación Condición Pago<br\>` : "";
                    break;
                default:
                    break;
            }
        }
    });
    return validarCampos;
}

$("input[type='radio']").on('change', function (e) {
    e.preventDefault();
    validaRechazo();
    if ($(this).is(':checked') && $(this).val() == "true") {
        changestatus($(this), true);
    } else {
        if ($(this).val() == "false") {
            changestatus($(this), false);
        }
    }
    activateButtons() ? $('#Autorizar').prop('disabled', false) : $('#Autorizar').prop('disabled', true);
});

validarCheckAnticipo();


$("#customRadio1").click(function () {
    validarCheckAnticipo();
});

$("#customRadio2").click(function () {
    validarCheckAnticipo();
});

if (OrigenAdjudicacion) {
    $("#IdTipoSolicitud").attr("disabled", "disabled");
}

GetCapitulo_x_IdPartida(idPartida);

if ($("#IdTipoAdjudicacion").val() === "1") {
    $("#Camp1").empty();
    $("#Camp2").empty();

    $("#DBS, #STA").css("maxWidth", "100%");
} else {
    $("#DBS, #STA").css("maxWidth", "50%");
    var NoSolicitud = '<label>Número Oficio de Solicitud</label><input type="text" id="NumeroOficioSolicitud" class="form-control" readonly>';
    $("#Camp1").prepend(NoSolicitud);
    if (OficioSolicitud) {
        $("#NumeroOficioSolicitud").val(OficioSolicitud);
    }    

    var Justificacion = '<label>Justificación <a href="#" data-toggle="tooltip" data-placement="top" title="Elementos objetivos y subjetivos que justifiquen el procedimiento"><i class="fa fa-question-circle-o"></i></a></label><textarea required id="Justificacion" name="Justificacion" class="form-control" style = "resize: none;"></textarea>';
    $("#Camp2").append(Justificacion);
    if (justificacion) {
        $("#Justificacion").val(justificacion).attr("disabled","disabled");
    }
    
}

$("#IdCapitulo").on("change", function () {
    $.get("/AdjudicacionesDirectasMayores/getAllPartidas_x_IdCapitulo", { pIdCapitulo: $("#IdCapitulo").val() }, function (response) {
        if (response.success) {
            var informacion = response.objeto;
            $("#IdPartida").html("");
            $("#IdPartida").append('<option value="">Selecciona Partida</option>');
            $.each(informacion, function (rowIndex, r) {
                var campoId = r["IdPartida"];
                var campoA = r["Partida"];

                $("#IdPartida").append('<option value=' + campoId + '>' + campoA + '</option>');
            });
        }
        else {
            $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
        }
    });
});

function getImporteTotalConImpuesto() {

    var parametros = {
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.post("/AdjudicacionesDirectasMayores/getImporteTotalConImpuesto/", parametros, "JSON")
        .done(function (data) {
            if (data.success)
                $("#ImporteTotalConImpuesto").val(data.m.toLocaleString("en-US", { style: 'currency', currency: 'USD' }));
        })
        .fail(function (data) {
            console.log(data);
        });
}

function getLstLotesPorAsignar() {

    var parametros = {
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.post("/AdjudicacionesDirectasMayores/getLstLotesPorAsignar/", parametros, "JSON")
        .done(function (data) {
            if (data.success) {
                $("#IdAdjudicacionLote").empty();
                $.each(data.m, function (index, row) {
                    var text = row["Text"];
                    var value = row["Value"];

                    $('#IdAdjudicacionLote').append("<option value=" + value + " selected >" + text + "</option>");

                });
            }
        })
        .fail(function (data) {
            console.log(data);
        });
}
function resetform() {

    $("#GuardarLote").css({ "display": "" });
    $("#ActualizarLote").css({ "display": "none" });
    $(".modal-title").html(`<div class="text-center">Nuevo lote</div>`);
    $("#modal_nuevo_lote").modal("hide");
    $("#div_LotesForm")[0].reset();
    $("#ResultadoBuscar").html('');
    $("#IdLote").val(0);
    $("#ClavePantone").css('cssText', 'background-color: white !important');

    getImporteTotalConImpuesto();

    $("#navbarToggleExternalContent").load(" #navbarToggleExternalContent", function (data) {

        var idTab = $("#Formulario").val();
        if (idTab !== "DatosGeneralesTabPadre") {
            $("#" + idTab).addClass('active');
            $("#DatosGeneralesTabPadre").removeClass('active');
        }

        $('body').on("click", ".nav li a", function (e) {
            var i = $(this).attr('id');
            var idPerfil = Perfil;

            $(".tab-content").children("div").removeClass("active show");
            $(`#${$(this).attr('href').replace('#', '')}`).addClass("active show");

            if (idPerfil === 4) {

                switch (i) {
                    case "div_firmantesTabPadre":
                        $("#btnAutoriza, #btnRechaza").show();
                        break;
                    default:
                        $("#btnAutoriza, #btnRechaza").hide();
                        break;
                }
            } else if (idPerfil === 8) {
                switch (i) {
                    case "div_propuesta_tecnicaTabPadre":
                        $("#btnProveedorAutorizaTec").show();
                        $("#sumario #div_condiciones_entrega, #sumario #div_condiciones_pago").remove();
                        $("#div_condiciones_entrega").clone().appendTo("#sumario");
                        $("#div_condiciones_pago").clone().appendTo("#sumario");

                        $('#div_propuesta_tecnica').find('input, textarea, button, select').attr('disabled', 'disabled');
                        $("#div_propuesta_tecnica #idNuevaCondicionDePago").hide();

                        $("#btnProveedorAutoriza").attr('disabled', 'disabled');

                        $("#aceptar_propuestaTec").find('input').removeAttr('disabled');

                        $("#div_propuesta_tecnica").find(".disabledClick").css({
                            "opacity": 1,
                            "pointer-events": "initial"
                        });
                        break;
                    default:
                        $("#btnProveedorAutorizaTec").hide();
                        break;
                }

            } else if (idPerfil === 3 && Estatus === 50) {
                switch (i) {
                    case "DatosGeneralesTabPadre":
                    case "div_presupuesto_liquidezTabPadre":
                    case "div_lotesTabPadre":
                        $("#btnAutoriza, #btnRechaza").hide();
                        break;
                    default:
                        $("#btnAutoriza, #btnRechaza").show();
                        break;
                }

            } else {
                switch (i) {
                    case "div_firmantesTabPadre":
                        $("#btnGuardarValidaciones").html("Enviar a revisión");

                        break;
                    case "div_lotesTabPadre":
                        //case "div_condiciones_pagoTabPadre":
                        $("#btnAutoriza").hide();
                        break;
                    default:
                        $("#btnAutoriza").show();
                        $("#btnGuardarValidaciones").html("Guardar");
                        break;
                }

            }

            $("#Formulario").val(i);

        });
    });
}

function nuevoLote() {
    resetform();
    $("#GuardarLote").css({ "display": "" });
    $("#ActualizarLote").css({ "display": "none" });
    $(".modal-title").html(`<div class="text-center">Alta lote</div>`);
    $("#ClavePantone").val('NA');
    $("#modal_nuevo_lote").modal("show");

}

function getPresupuestoPartida() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdPartida = $("#IdPartida").val();

    var parametros = {
        pIdPartida: IdPartida,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/AdjudicacionesDirectasMayores/getPresupuestoPartida/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                var informacion = response.objeto;
                if (informacion === null) {

                    $("#btnAutoriza").attr("disabled", "disabled");
                    var textPartida = $("#IdPartida option:selected").text();

                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Aviso</div>`,
                        message: "La partida <strong>" + textPartida + "</strong> no tiene monto suficiente para realizar el proceso de guardado."
                    });

                    $("#ValorAproximado").val("0.00");
                    $("#pre").val("0.00");
                    $("#ValorAproximadoReal").val("0.00");

                }
                else {
                    $("#ValorAproximado").val(parseFloat(informacion.MontoSaldo)).attr('max',parseFloat(informacion.MontoSaldo));
                    
                    $("#pre").val(informacion.MontoSaldo);
                    $("#save, #btnAutoriza").removeAttr('disabled');
                    //$("#ValorAproximado").val(informacion.MontoPresupuesto);
                    $("#ValorAproximadoReal").val(informacion.MontoPresupuesto);
                    $("#IdPresupuestoPartida").val(informacion.IdPresupuestoPartida);

                }
            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >').delay(4500).fadeOut();
            }

        }
    });
}

function validarCheckAnticipo() {
    var check = $("#customRadio1");

    if (check.is(':checked')) {
        if ($("#IdAdjudicacionCondicionPago").val() === "0")
            $("#IdAnticipo").val(1);
        $("#IdAnticipo").removeClass('disabledClick');
        calcularPorcentaje();
        $('#tablaPagos').DataTable();

        $("#IdAnticipoBool").val(check.val());

    }
    check = $("#customRadio2");
    if (check.is(':checked')) {
        $("#IdAnticipo").val("");
        $("#IdAnticipo").addClass('disabledClick');
        calcularPorcentaje();
        $('#tablaPagos').DataTable();
        $("#IdAnticipoBool").val(check.val());
    }
}

$("#div_condiciones_pagoForm").on("submit", function (e) {
    e.preventDefault();
});

//$("#ValorAproximado").keyup(function () {
//    let val = parseInt($(this).val());
//    if ($(this).attr("data-tipoadj") == 1) {
//        $("#btnAutoriza").prop("disabled", (val > 5000 && val < 54000 ? false : true))
//    }
//    else {
//        $("#btnAutoriza").prop("disabled", (val >= 54000 ? false : true))
//    }
//});

function validarFormulario(value) {
    $("button.navbar-toggler").css("margin-right", "0");
    
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Esta campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor a 0.";
    jQuery.validator.messages.step = "Por favor, escribe un valor mayor a 0.";
    
    
    var form = $("#Formulario").val();
    form = form.replace("TabPadre", "");
    var validado = true;

    if (form === "div_lotes" ) {
        $("#div_condiciones_entregaTabPadre").removeClass('disabledClick');
        $(".nav-link, .tab-pane").removeClass("active show");

        $("#div_condiciones_entregaTabPadre, #div_condiciones_entrega").addClass("active show");
        
        return false;
    }

    if (form !== "div_presupuesto_liquidez" && form !== "div_firmantes" && form !== "div_asignar_proveedores") {
        validado = $("#" + form + "Form").valid();
    }

    if (validado) {
        switch (form) {
            case "DatosGenerales":
            case "div_presupuesto_liquidez":
                bootbox.confirm({
                    title: `<div class="text-center">Confirmar solicitud</div>`,
                    message: "¿Desea " + (value === true ? "autorizar" : "rechazar") + " solicitud?",
                    size: "small",
                    callback: function (res) {
                        if (res)
                            traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAdjudicacion, b: value })
                            //saveAdjudicacion(value);
                    }
                });
                break;
            case "div_condiciones_entrega":
                saveCondcionesDeEntrega(value);
                break;
            case "div_condiciones_pago":
                saveCondicionPago(value);
                break;
            case "div_asignar_proveedores":
                proveedores(value);
                break;
            case "div_firmantes":
                saveFirmantes(value);
                break;
        }

    }
}

function checkRadioFirmantes() {
    if ($("#ValidaLotes").is(":checked") && $("#ValidaCondicionEntrega").is(":checked") && $("#ValidaCondicionPago").is(":checked")) {
        $("#btnAutoriza").removeClass("disabledClick");
        $("#btnRechaza").addClass("disabledClick");
    } else {
        $("#btnAutoriza").addClass("disabledClick");
        $("#btnRechaza").removeClass("disabledClick");
    }
 
}

function saveFirmantes(value) {
    //console.log(`${validaObservaciones()}`)
    if (value ? validateRadio() : validaObservaciones()=="") {
        bootbox.confirm({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "¿Desea confirmar " + (value ? "autorización" : "rechazo") + " de la adjudicación?",
            callback: function (result) {
                if (result) {
                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveAutorizaRechazaAdjudicacionDirecta, b: value })
                }

            }
        });
    } else {
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: validaObservaciones() + " "
        });
    }

}
function saveAutorizaRechazaAdjudicacionDirecta(value) {
    var IdAdjudicacion = $("#IdAdjudicacion").val();
    var form = $("#AdjFirm").serializeArray();
    form.push({ name: "isApprove", value: value });
    form.push({ name: "IdAdjudicacion", value: IdAdjudicacion });

    $.post("/AdjudicacionesDirectasMayores/saveFirmantes", form, "JSON")
        .done(function () {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "Adjudicacion enviada correctamente",
                callback: function () {
                    location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion;
                }
            });
        }).fail(function (data) {
            console.log(data);
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Estatus Adjudicación</div>`,
                message: "No se ha podido enviar la adjudicación"
            });
        });
}
function proveedores(value) {

    var prov = $("#tabla_asignar_proveedores").children('tbody').children('tr').children('td').children('div').children('input[data-idadjudicacionproveedor!=0]').length;
    var asigprov = tipoAdjudicacion === 1 ? 1 : 3;


    if (prov < asigprov) {
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "Debe seleccionar al menos 3 proveedores"
        });
    } else {

        bootbox.confirm({
            title: `<div class="text-center">Enviar adjudicacion a revisión</div>`,
            message: "¿Desea enviar la adjudicación para su revisión?",
            size: "small",
            callback: function (result) {
                if (result) {
                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviarRevisionAdjudicacionDirecta, b: value })
                   
                }
            }
        });
    }
}
function saveEnviarRevisionAdjudicacionDirecta(value) {
    var cantidadLotes = $("#LotesTable").DataTable().rows().count();

    var parametros = {
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        IdEstatusAdjudicacion: 60,
        CantidadLotes: cantidadLotes,
        ImporteTotalLotes: numeral($("#ImporteTotalConImpuesto").val())["_value"],
        TotalLiquidez: numeral($("#liquidez").val())["_value"],
        isApprove: value
    };

    $.post("/AdjudicacionesDirectasMayores/saveAdjudicacion", parametros, "JSON")
        .done(function (data) {

            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: data.mensaje,
                callback: function () {
                    if (data.success) {
                        location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion;
                    }
                }
            });
        }).fail(function (data) {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "No se ha podido enviar la adjudicación"
            });
        });
}



function saveAdjudicacion(value) {

    var montoAutorizado = numeral($("#MontoPresupuestadoAutorizado").val())["_value"];
    var totalMontoComprometido = numeral($("#totalMontoComprometido").val())["_value"];
    var nMonto = Math.abs(montoAutorizado - totalMontoComprometido);
    var tipoAdjudicacion = parseInt($("#IdTipoAdjudicacion").val());

    if (Perfil === 2) {
        if (value) {
            if (montoAutorizado === totalMontoComprometido) {
                var parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    IdAdjudicacion: $("#IdAdjudicacion").val(),
                    MontoAproximadoAutorizado: $("#MontoPresupuestadoAutorizado").val(),
                    SaldoPartida: $("#saldo").val(),
                    isApprove: value
                };
            } else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Falta por asignar la cantidad total de <strong>" + nMonto.toLocaleString("en-US", { style: "currency", currency: "USD" }) + "</strong> del Monto presupuestado autorizado"
                });
            }
        } else {
            parametros = {
                __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                IdAdjudicacion: $("#IdAdjudicacion").val(),
                isApprove: value
            };
        }
    } else {
        var token = $("[name='__RequestVerificationToken']").val();
        var NumOficio = $("#NumeroOficioSolicitud").val();
        var Justificacion = $("#Justificacion").val();

        if (tipoAdjudicacion === 1) {
            NumOficio = "0";
            Justificacion = " - ";
        }

        parametros = {

            IdAdjudicacion: parseInt($("#IdAdjudicacion").val()),
            IdDependencia: 0,
            IdTipoAdjudicacion: parseInt($("#IdTipoAdjudicacion").val()),
            IdTipoSolicitud: parseInt($("#IdTipoSolicitud").val()),
            IdOrigenRecurso: 1,
            IdOrigenRecursoAutorizado: 1,//¿?
            IdEstatus: 10,
            IdEstatusAdjudicacion: 10,
            IdPartida: $("#IdPartida").val(),
            IdEjercicioFiscal: $("#IdEjercicioFiscal").val(),
            IdPresupuestoPartida: $("#IdPresupuestoPartida").val(),
            FechaAdjudicacion: "",
            AdjudicacionFolio: 0,
            ConsecutivoAdjudicacion: 0,
            //NumeroOficioSolicitud: $("#NumeroOficioSolicitud").val(),
            NumeroOficioCertificacion: $("#NumeroOficioCertificacion").val(),
            MontoAproximado: numeral($("#ValorAproximado").val())["_value"],
            MontoAproximadoAutorizado: $("#totalMontoComprometido").val(),//¿?
            CantidadLotes: 0,
            ImporteTotalLotes: 0,
            Observaciones: $("#Observacion").val(),
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
            NumeroOficioSolicitud: NumOficio,
            Justificacion: Justificacion,
            AcuerdoAutorizacionComite: 0,
            TotalLiquidez: 0,
            isApprove: value,
            __RequestVerificationToken: token

        };
    }

    $.ajax({
        data: parametros,
        url: '/AdjudicacionesDirectasMayores/saveAdjudicacion/',
        type: 'post',
        beforeSend: function () {
            $(".btn").attr('disabled','disabled');
        },
        success: function (response) {
            if (response.success) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Envío Adjudicación</div>`,
                    message: response.mensaje,
                    callback: function () {
                        location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion;
                    }
                });
            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >').delay(4500).fadeOut();
                
            }
        },
        complete: function (resp) {
            $(".btn").removeAttr('disabled');
        }
    });
}

function Monto() {
    let presupuesto = parseFloat($("#pre").val());
    var saldo = parseFloat(numeral($("#ValorAproximado").val())["_value"]);

    if (saldo > presupuesto) {
        $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"><strong> Advertencia! </strong> Ingrese una cantidad menor </div >').delay(4500).fadeOut();
        $("#btnAutoriza").attr('disabled', 'disabled');
    } else {
        $("#ResultadoBuscar").empty();
        $("#btnAutoriza").removeAttr('disabled');

    }
}

function GetCapitulo_x_IdPartida(IdPartida) {
    if (IdPartida) {
    $.get(
        "/PresupuestosPartidas/GetCapitulo_x_IdPartida", { IdPartida: IdPartida }, "JSON")
        .done(function (response) {
            $.each(response, function (index, row) {

                var CampoId = row["IdCapitulo"];
                var CAmpoVal = row["Capitulo"];

                $('#IdCapitulo').attr('disabled', 'disabled');
                $("#IdCapitulo").val(CampoId).attr('selected', true);

                $.get("/PresupuestosPartidas/getPartida_x_IdPartida", { IdPartida: IdPartida }, "JSON")
                    .done(function (response) {
                        $.each(response, function (index, row) {

                            var CampoIdP = row["Idpartida"];
                            var CAmpoValP = row["Partida"];

                            $('#IdPartida').empty().attr('disabled', 'disabled');
                            $('#IdPartida').append("<option value=" + CampoIdP + " selected >" + CAmpoValP + "</option>");
                        });
                    });

            });
        });
    }
}

$("#Producto").autocomplete({
    minLength: 0,
    mustMatch: true,
    source: function (request, response) {
        $.ajax({
            url: '/AdjudicacionesDirectasMayores/getProductos',
            dataType: 'JSON',
            type: 'post',
            data: { term: $("#Producto").val(), IdPartida: $("#IdPartida_").val() },
            success: function (data) {
                response($.map(data.data, function (item) {

                    return { label: item.string5, value: item.string5, id: item.entero };
                }));
            },
            error: function (data) {
                console.log(data);
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: "Ocurrio un error al momento de procesar la solicitud"
                })
            }
        });
    },
    select: function (e, ui) {
        $("#IdBienServicio").val(ui.item.id);
        getProducto_x_IdBienServicio(ui.item.id);
    },
    change: function (e, ui) {
        if (!ui.item) e.target.value = "";
    }
});

function getProducto_x_IdBienServicio(IdBienServicio_) {
    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        data: { IdBienServicio: IdBienServicio_, IdAdjudicacion: $("#IdAdjudicacion").val(), __RequestVerificationToken: token },
        url: '/AdjudicacionesDirectasMayores/getProducto',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {          
            if (response.success) {
                $("#Unidad").val(response.data.string3);
                $("#Caracteristica").val(response.data.string2);
                $("#Impuesto").val(response.data.string4);
                $("#TasaImpuesto").val(response.data.decimal2);
                var preciounitario = numeral(response.data.decimal1).format('0,0.00');
                $("#PrecioUnitarioListaSinImpuestoMensual").val(preciounitario);
                $("#ClavePantone").val("NA");//no se trae la ClavePantone del producto
                calcularValores();
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: response.data
                })
            }
        }
    });
}

function calcularValores() {
    var cantidad = $("#Cantidad").val();

    if (cantidad !== "") {
        var preciounitario = $("#PrecioUnitarioListaSinImpuestoMensual").val();
        preciounitario = numeral(preciounitario).value();
        var precioUnitarioListaSinImpuestoMensual = preciounitario;
        var tasaImpuesto = $("#TasaImpuesto").val();
        var periodo = $("#Meses").val();
        var importeConImpuesto = precioUnitarioListaSinImpuestoMensual * tasaImpuesto;
        var impuestoGenerado = importeConImpuesto * cantidad;
        var totalSinImpuesto = precioUnitarioListaSinImpuestoMensual * cantidad;
        var totalConImpuesto = totalSinImpuesto + impuestoGenerado;
        var totalPeriodo = totalConImpuesto * (periodo === "0" ? 1 : periodo);
        totalSinImpuesto = numeral(totalSinImpuesto).format('0,0.00');
        totalConImpuesto = numeral(totalConImpuesto).format('0,0.00');
        totalPeriodo = numeral(totalPeriodo).format('0,0.00');
        $("#ImporteSinImpuestoMensual").val(totalSinImpuesto);
        $("#ImporteConImpuestoMensual").val(totalConImpuesto);
        $("#ImporteTotalPeriodo").val(totalPeriodo);
        $("#importeConImpuesto").val(importeConImpuesto);
    }
    else {
        $("#ImporteSinImpuestoMensual").val(0.00);
        $("#ImporteConImpuestoMensual").val(0.00);
        $("#ImporteTotalPeriodo").val(0.00);
    }

}

function runScript(e) {
    calcularValores();
    return false;  
}

function validarFormularioLote() {
    $("button.navbar-toggler").css("margin-right", "0")

    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor 0.";
    jQuery.validator.messages.step = "Por favor, escribe un valor mayor a 0.";


    var validado = $("#div_LotesForm").valid();

    if (validado && validarValoresTotales()) {
        saveLote();
        $("#modal_nuevo_lote").modal("hide");
    }
}

function validarValoresTotales() {
    var idLote = $("#IdLote").val();
    var totalAltaLote = 0;
    var totalAnterior = 0;
    var totalGeneral = numeral($("#ImporteTotalConImpuesto").val()).value();
    if (idLote !== 0) {
        totalAnterior = numeral($("#ImporteTotalPeriodoActual").val()).value();

        totalGeneral = totalGeneral - totalAnterior;
    }

    totalAltaLote = numeral($("#ImporteTotalPeriodo").val()).value();
    var montoPresupuestoAutorizado = numeral($("#MontoPresupuestoAutorizado").val()).value();

    if ( (totalGeneral + totalAltaLote) >= montoPresupuestoAutorizado) {
        if (totalGeneral === "0.00") {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "El monto del lote <strong>$ " + numeral(totalAltaLote).format('0,0.00') + "</strong> sobrepasa lo autorizado: <strong>$" + numeral(montoPresupuestoAutorizado).format('0,0.00') +"</strong>."
            })
        } else {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "El monto del lote: <strong>$" + numeral(totalAltaLote).format('0,0.00') + "</strong>, más el monto capturado total: <strong>$" + numeral(totalGeneral).format('0,0.00') + "</strong> sobrepasa lo autorizado: <strong>$" + numeral(montoPresupuestoAutorizado).format('0,0.00') + "</strong>."
            })
        }

        return false;
    }
    else
        return true;
}

function cargarColumnas() {
    var idTipoSolicitud = $("#IdTipoSolicitud").val();

    var dataRow = Array();
    if (idTipoSolicitud === 2) {
        dataRow = [
            {
                mRender: function (data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarLote(' + row.IdLote + ')" ><span class="fa fa-pencil" ></span></button>' +
                        '<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarLoteModal(' + row.IdLote + ')"><span class="fa fa-trash-o" ></span></button></div>';
                }
            },
            { "data": "NoLote", sortable: true },
            { "data": "Pantone", sortable: true },
            { "data": "DescripcionMesInicial", sortable: true },
            { "data": "DescripcionMesFinal", sortable: true },
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
            { "data": "ImporteMensualCImpuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "MesesServicio", sortable: true },
            { "data": "Total", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') }
        ];

    }
    else {
        dataRow = [
            {
                mRender: function (data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarLote(' + row.IdLote + ')" ><span class="fa fa-pencil" ></span></button>' +
                        '<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarLoteModal(' + row.IdLote + ')" ><span class="fa fa-trash-o" ></span></button></div>';
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
            { "data": "ImporteMensualCImpuesto", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
            { "data": "Total", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') }
        ];
    }

    return dataRow;
}

function cargarColumnasCondicionEntregaDetalle() {
    var dataRow = Array();
    dataRow = [
        {
            mRender: function (data, type, row) {

                //return '<div class="btn-group"><button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="editarCondicinesEntregaDetalle(' + row.IdAdCondicionEntregaDetalle + ')" ><span class="fa fa-pencil" ></span></button>' +
                //'<button class="btn btn-secondary btn-sm" style="margin-right:5px;" onclick="eliminarCondicinesEntregaDetalle(' + row.IdAdCondicionEntregaDetalle + ')" ><span class="fa fa-trash-o" ></span></button></div>';
                return '<button class="btn btn-secondary btn-sm" style="margin-right:5px;margin-left:35%;" onclick="eliminarCondicinesEntregaDetalle(' + row.IdAdCondicionEntregaDetalle + ')" ><span class="fa fa-trash-o" ></span></button></div>';
            }
        },
       // { "data": "NumeroEntrega", sortable: false },
        { "data": "NoLote", sortable: false },
        { "data": "Cantidad", sortable: false },
        { "data": "Lugar", sortable: false },
        { "data": "Direccion", sortable: false },
        {
            mRender: function (data, type, row) {

                return '<div id="map-' + row.i + '" class="maps" style="width:150px;height:150px; border: 1px solid rgb(222, 220, 221); border-radius: 5px;position: relative; overflow: hidden;"></div >' +
                    '<input type="hidden" class="inpt" value="' + row.LocalizacionGoogle + '" />';
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
                cadena += row.Lunes === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge"> Lunes </span></button>' : '';
                cadena += row.Martes === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge">Martes</span></button>' : '';
                cadena += row.Miercoles === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge"> Miercoles </span></button>' : '';
                cadena += row.Jueves === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge">Jueves </span></button>' : '';
                cadena += row.Viernes === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge"> Viernes </span></button>' : '';
                cadena += row.Sabado === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge">Sabado </span></button>' : '';
                cadena += row.Domingo === 1 ? '<button style="margin-bottom: 5px;margin-top: 5px;margin-right:2px;" type="button" class="btn btn-outline-secondary btn-sm"><span class="badge">Domingo </span></button>' : '';

                return cadena;
            }
        }
    ];

    return dataRow;
}

function cargartablaLotes() {

    $("#container_tableLotes").empty();

    $("#container_tableLotes").load(" #container_tableLotes"//, function () {
    //    $("#container_tableLotes").children().first().remove();

    //    $("#LotesTable").DataTable({
    //       pageLength: 5,
    //        sort: false,
    //        scrollX: true,
    //        lengthMenu: [5, 10, 25, 50, 100],
    //        language: {
    //            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
    //        }

    //    });
    //}
);


    //$('#LotesTable').dataTable({
    //    "bDestroy": true
    //}).fnDestroy();

    //$('#LotesTable').dataTable().fnDestroy();

    //$('#LotesTable').DataTable({
    //    pageLength: 5,
    //    sort: false,
    //    scrollX: true,
    //    lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, 100]],
    //    language: {
    //        "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
    //    },
    //    data: data,
    //    columnDefs: [
    //        { targets: [-1, -2, -3, -4, -5, -6], className: "dt-body-right" }

    //    ],
    //    "columns": cargarColumnas()
    //}).draw();

}

function mesesActivos() {
    var de = $("#De").val();
    var al = $("#Al").val();
    var textDe = $("#De :selected").text().trim();
    var textAl = $("#Al :selected").text().trim();

    if (al === "") {
        return;
    }
    if (de === "") {
        return;
    }
    if (al - de < 0) {
        $("#De").val("");
        $("#Al").val("");

        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "El mes de Inicio <strong>" + textDe + "</strong> es mayor al mes final <strong>" + textAl +"</strong>."
        })

        return;
    }
    var total = al - de + 1;
    $("#Meses").val(total);
    calcularValores();

}

function saveLote() {
    
    var PrecioUnitarioListaSinImpuestoMensual = numeral($("#PrecioUnitarioListaSinImpuestoMensual").val()).value();
    var ImporteSinImpuestoMensual = numeral($("#ImporteSinImpuestoMensual").val()).value();
    var importeConImpuesto = numeral($("#importeConImpuesto").val()).value();
    var ImporteConImpuestoMensual = numeral($("#ImporteConImpuestoMensual").val()).value();
    var ImporteTotalPeriodo = numeral($("#ImporteTotalPeriodo").val()).value();
    var token = $("[name='__RequestVerificationToken']").val();
    var frecuencia = $("#Frecuencia").val();

    var pAdjudicacionLote = {
        IdLote: 0,
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        NoLote: 0,
        IdBienServicio: $("#IdBienServicio").val(),
        Pantone: $("#ClavePantone").val(),
        Cantidad: $("#Cantidad").val(),
        PrecioUnitario: PrecioUnitarioListaSinImpuestoMensual,
        Importe: ImporteSinImpuestoMensual,
        PorcentajeImpuesto: $("#TasaImpuesto").val(),
        ImporteCImpuesto: importeConImpuesto,
        ImporteMensualCImpuesto: ImporteConImpuestoMensual,
        MesesServicio: $("#Meses").val(),
        Total: ImporteTotalPeriodo,
        IdMesInicial: $("#De").val(),
        IdMesFinal: $("#Al").val(),
        IdFrecuencia: frecuencia,
        IdMuestra: $("#Requerimiento").val(),
        FechaRegistro: 0,
        IdUsuarioRegistro: 0,
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pAdjudicacionLote,
        url: '/AdjudicacionesDirectasMayores/saveLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {

                cargartablaLotes(response.data);
                $("#modal_nuevo_lote").modal("show");
                resetform();
                $(".nav-pills").load(" .nav-pills");
            }
            else {
               
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: response.data
                })
                
            }

            getLstLotesPorAsignar();

        }
    });
}

function saveEditLote() {

    var token = $("[name='__RequestVerificationToken']").val();

    var PrecioUnitarioListaSinImpuestoMensual = numeral($("#PrecioUnitarioListaSinImpuestoMensual").val()).value();
    var ImporteSinImpuestoMensual = numeral($("#ImporteSinImpuestoMensual").val()).value();
    var importeConImpuesto = numeral($("#importeConImpuesto").val()).value();
    var ImporteConImpuestoMensual = numeral($("#ImporteConImpuestoMensual").val()).value();
    var ImporteTotalPeriodo = numeral($("#ImporteTotalPeriodo").val()).value();
    var Idlote_ = $("#IdLote").val();

    var pAdjudicacionLote = {

        IdLote: Idlote_,
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        NoLote: 0,
        IdBienServicio: $("#IdBienServicio").val(),
        Pantone: $("#ClavePantone").val(),
        Cantidad: $("#Cantidad").val(),
        PrecioUnitario: PrecioUnitarioListaSinImpuestoMensual,
        Importe: ImporteSinImpuestoMensual,
        PorcentajeImpuesto: $("#TasaImpuesto").val(),
        ImporteCImpuesto: importeConImpuesto,
        ImporteMensualCImpuesto: ImporteConImpuestoMensual,
        MesesServicio: $("#Meses").val(),
        Total: ImporteTotalPeriodo,
        IdMesInicial: $("#De").val(),
        IdMesFinal: $("#Al").val(),
        IdFrecuencia: $("#Frecuencia").val(),
        IdMuestra: $("#Requerimiento").val(),
        FechaRegistro: 0,
        IdUsuarioRegistro: 0,
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pAdjudicacionLote,
        url: '/AdjudicacionesDirectasMayores/saveEditLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {

                resetform();
                cargartablaLotes(response.data);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error actualizar lote</div>`,
                    message: response.data
                })
            }

            getLstLotesPorAsignar();

        }
    });
}

function editarLote(Idlote_) {
    $("#IdLote").val(Idlote_);

    var pAdjudicacionLote = {
        IdLote: Idlote_,
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        data: pAdjudicacionLote,
        url: '/AdjudicacionesDirectasMayores/getAdjudicacionLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {

            if (response.success) {
                cargarValores(response.objeto);
            }
            else {
               
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error cargar lote</div> ${pAdjudicacionLote}`,
                    message: response.data+" "
                })
            }

            getLstLotesPorAsignar();
        }
    });
}

function cargarValores(data) {
    $("#GuardarLote").css({ "display": "none" });
    $("#ActualizarLote").css({ "display": "" });
    $(".modal-title").html(`<div class="text-center">Editar lote</div>`);
    $("#modal_nuevo_lote").modal("show");

    $("#PrecioUnitarioListaSinImpuestoMensual").val(numeral(data.PrecioUnitario).format('0,0.00'));
    $("#ImporteSinImpuestoMensual").val(numeral(data.Importe).format('0,0.00'));
    $("#importeConImpuesto").val(numeral(data.ImporteCImpuesto).format('0,0.00'));
    $("#ImporteConImpuestoMensual").val(numeral(data.ImporteMensualCImpuesto).format('0,0.00'));
    $("#ImporteTotalPeriodo").val(numeral(data.Total).format('0,0.00'));
    $("#Impuesto").val(data.Impuesto);
    $("#ClavePantone").val(data.Pantone.trim());
    $("#Cantidad").val(data.Cantidad);
    $("#Frecuencia").val(data.IdFrecuencia);
    $("#Producto").val(data.BienServicio);
    $("#Unidad").val(data.UnidadMedida);
    $("#IdBienServicio").val(data.IdBienServicio);
    $("#Caracteristica").val(data.Descripcion);

    $("#TasaImpuesto").val(data.PorcentajeImpuesto);

    $("#De").val(!data.IdMesInicial ? "0" : data.IdMesInicial);
    $("#Al").val(!data.IdMesFinal.trim() ? "0" : data.IdMesFinal.trim());
    $("#Meses").val(!data.MesesServicio ? "0" : data.MesesServicio);

    $("#Requerimiento").val(data.IdMuestra);
    $("#ImporteTotalPeriodoActual").val(data.Total);

    $("#tpeu").val(data.PrecioUnitario);
    $("#tpeuLabel").html(`Precio de referencia sin IVA: $${data.PrecioUnitario}`)
}

function eliminarLoteModal(IdLote) {
    bootbox.confirm({
        title: `<div class="text-center">Aviso</div>`,
        message: "¿Desea eliminar el lote?",
        size: "small",
        callback: function (res) {
            if (res) {
                eliminarLote(IdLote);
            }
        }
    })
}

function eliminarLote(IdLote) {
    var idLote = IdLote;
    var token = $("[name='__RequestVerificationToken']").val();

    var pAjudicacionLote = {
        IdLote: idLote,
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        __RequestVerificationToken: token
    };


    $.ajax({
        data: pAjudicacionLote,
        url: '/AdjudicacionesDirectasMayores/deleteLote',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                bootbox.alert({
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Se elimino lote correctamente",
                    size: "small"
                })
                resetform();
                cargartablaLotes(response.data);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Eliminar Lote</div>`,
                    message: "Error no se puede eliminar lote, ya que esta siendo usado en una condicion de entrega"
                })
            }

            getImporteTotalConImpuesto();
            getLstLotesPorAsignar();

        }
    });
}

function Pantone(Color) {   
    $("#ClavePantone").css('cssText','border-color: '+ Color + ' !important');
    $("#ClavePantone").css('cssText', 'background-color: ' + Color + ' !important');
}

function validarFormularioLoteEdit() {
    $("button.navbar-toggler").css("margin-right", "0")

    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Esta campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor 0.";
    jQuery.validator.messages.step = "Por favor, escribe un valor mayor a 0.";

    var validado = $("#div_LotesForm").valid();
    if (validado && validarValoresTotales())
        saveEditLote();
}

function addZeroes(num) {
    var value = Number(num);
    var res = num.split(".");
    if (res.length === 1 || res[1].length < 3) {
        value = value.toFixed(2);
    }
    return value;
}

$("#section__liquidez").on('click', '.new-liquidez', function (e) {

    var montoAutorizado = $("#MontoPresupuestadoAutorizado").val();
    montoAutorizado = addZeroes(montoAutorizado);

    var totalMontoComprometido = $("#totalMontoComprometido").val();

    document.getElementById("form-Liquidez").reset();

    $("#IdcuentaBancaria").empty();
    var nMonto = montoAutorizado - totalMontoComprometido;

    if (montoAutorizado === totalMontoComprometido) {
        $("#alertMonto").html('<div class="alert alert-danger" role="alert"><strong>Advertencia! </strong> Se asignó la cantidad total del Monto presupuestado autorizado </div >');

    } else if (nMonto > 0) {
        $("#MontoComprometido").attr({
            'value': nMonto,
            'max': nMonto
        });
        $(".modal-title").html(`<div class="text-center">Agregar</div>`);
        $("#form-Liquidez :input[type=submit]").val("Guardar");
        $("#LiquidezModal").modal("show");
    } else {
        $("#alertMonto").html('<div class="alert alert-danger" role="alert"><strong>Advertencia! </strong> Ingrese una cantidad a Monto presupuestado autorizado </div >');
    }

});

function compare(value) {
    var saldo = parseFloat($("#saldo").val());
    var MontoSolicitado = parseFloat($("#MontoSolicitadoH").val());
    var totalMontoComprometido = parseFloat($("#totalMontoComprometido").val());
    value = numeral(value)["_value"];

    if (saldo < value || value > MontoSolicitado) {
        $(".new-liquidez, #btnAutoriza").attr('disabled', 'disabled');
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "Ingrese una cantidad igual o menor a la del " + (saldo < value ? "saldo presupuestado autorizado" : "monto solicitado")
        })
    } else if (value < totalMontoComprometido) {
        $(".new-liquidez, #btnAutoriza").attr('disabled', 'disabled');

        if (value  === "" || value === "0") {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "No se ha capturado el monto presupuestado autorizado"
            })
            return false;
        }
        $(".new-liquidez, #btnAutoriza").attr('disabled', 'disabled');
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "El Monto presupuestado autorizado <strong> $" + parseFloat(value) + "</strong> no puede ser menor al total del monto comprometido <strong> $" + totalMontoComprometido + "</strong>."
        })

    } else {
        $(".new-liquidez, #btnAutoriza").removeAttr('disabled');

        var nsaldo = new Number(saldo - value).toLocaleString("en-US");
        $("#SaldoPresupuestadoAutorizado").val(nsaldo);
    }
}

$("#IdOrigenRecurso").on("change", function () {
    $.get("/AsignacionPresupuestos/GetCuentas_x_IdOrigenRecurso", { idOrigenRecurso: $("#IdOrigenRecurso").val() }, function (data) {
        $("#IdcuentaBancaria").empty();
        $("#IdcuentaBancaria").append("<option value='N/A' disabled selected>Seleccionar</option>");
        $("#NombreCuenta, #Banco, #SaldoCuenta").val("");
        $.each(data, function (index, row) {
            var campoA = row["NumeroCuenta"];
            var campoId = row["IdCuentaBancaria"];
            $("#IdcuentaBancaria").append("<option value='" + campoId + "'>" + campoA + "</option>");
        });
    });
});

$("#IdcuentaBancaria").on("change", function () {
    $.get("/AsignacionPresupuestos/GetNombreCuenta_x_IdCuenta", { idCuenta: $("#IdcuentaBancaria").val() }, function (data) {

        var nMonto = new Number(data.MontoDisponible).toLocaleString("en-US");

        $("#NombreCuenta").val(data.NombreCuenta);
        $("#SaldoCuenta").val(nMonto);

        $.get("/AsignacionPresupuestos/GetNombreBanco_x_IdBanco", { idBanco: data.IdBanco }, function (data) {
            $("#Banco").val(data);
        });
    });
});

$("#form-Liquidez").on("submit", function (e) {
    e.preventDefault();
    var form = $("#form-Liquidez");
    var tipo = $("#form-Liquidez input[type=submit]").prop("value");

    if (tipo === "Guardar") {

        var saldoCuenta = $("#SaldoCuenta").val().replace(/\,/g, '');
        var MontoComprometido = parseFloat($("#MontoComprometido").val());

        if (saldoCuenta > MontoComprometido) {
            $.post("/AdjudicacionesDirectasMayores/saveLiquidez", form.serialize(), "JSON")
                .done(function (data) {
                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Liquidez</div>`,
                        message: "Añadido Correctamente"
                    })
                    $("#LiquidezModal").modal('hide');
                    $("#section__liquidez").load(" #section__liquidez");
                })
                .fail(function (data) {
                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Liquidez</div>`,
                        message: "No se ha podido procesar la solicitud"

                    })
                    $("#LiquidezModal").modal('hide');
                });
        } else {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Liquidez</div>`,
                message: "El saldo de la cuenta no puede ser  igual o menor al monto comprometido"

            })
        }
    } else if (tipo === "Editar") {
        $.post("/AdjudicacionesDirectasMayores/UpdateAdjudicacionLiquidez", form.serialize(), "JSON")
            .done(function (data) {
                if (data.success) {
                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Aviso</div>`,
                        message: "Editado Correctamente",
                        callback: function () {
                            $("#LiquidezModal").modal('hide');
                            $("#btnAutoriza").removeAttr('disabled');
                            $("#section__liquidez").load(" #section__liquidez");
                        }
                    })
                } else {
                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Aviso</div>`,
                        message: "No se ha podido editar"
                    })
                }
            })
            .fail(function (data) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "No se ha podido procesar la solicitud",
                    callback: function () {
                        $("#LiquidezModal").modal('hide');

                    }
                })
            });
    }
});

function delete__item(IdAdjudicacionLiquidez) {
    bootbox.confirm({
        size: "small",
        title: `<div class="text-center">Aviso</div>`,
        message: "¿Desea eliminar el cuenta?",
        callback: function (result) {
            if (result) {
                var parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    idAdjudicacionLiquidez: IdAdjudicacionLiquidez
                };

                $.post("/AdjudicacionesDirectasMayores/DeleteAdjudicacionLiquidez", parametros, "JSON")
                    .done(function (data) {
                        $("#section__liquidez").load(" #section__liquidez");
                    })
                    .fail(function (data) {

                        bootbox.alert({
                            size: "small",
                            title: `<div class="text-center">Aviso</div>`,
                            message: "No se ha podido procesar la solicitud",
                            callback: function () {
                                $("#LiquidezModal").modal('hide');

                            }
                        })

                    });
            }
        }
    })

}

function EditModal(IdAdjudicacionLiquidez) {

    var parametros = {
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        idAdjudicacionLiquidez: IdAdjudicacionLiquidez
    };

    $.post("/AdjudicacionesDirectasMayores/TraerAdjudicacionLiquidez", parametros, "JSON")
        .done(function (data) {

            var IdcuentaBancaria = $("#IdOrigenRecurso").val(data.mensaje.IdOrigenRecurso);
            $("#NumeroOperacion").val(data.mensaje.NumeroOperacion);
            $("#MontoComprometido").val(data.mensaje.MontoComprometido);
            $("#IdAdjudicacionLiquidez").val(data.mensaje.IdAdjudicacionLiquidez);
            var IdCuentaBancaria = data.mensaje.IdCuentaBancaria;

            var montoAutorizado = $("#MontoPresupuestadoAutorizado").val();
            montoAutorizado = addZeroes(montoAutorizado);

            var totalMontoComprometido = $("#totalMontoComprometido").val();
            var nMonto = montoAutorizado - totalMontoComprometido;

            var rest = data.mensaje.MontoComprometido + nMonto;

            var nowDate = new Date(parseInt(data.mensaje.FechaDeposito.substr(6))).format("yyyy-mm-dd HH:mm:ss");
            $("#FechaDeposito").val(nowDate);

            $.get("/AsignacionPresupuestos/GetNombreBanco_x_IdCuentaBancaria", { IdCuentaBancaria: data.mensaje.IdCuentaBancaria }, "JSON").done(function (data) {
                $("#Banco").val(data);
            });

            $.get("/AsignacionPresupuestos/GetCuentas_x_IdOrigenRecurso", { idOrigenRecurso: data.mensaje.IdOrigenRecurso }, function (data) {
                $("#IdcuentaBancaria").empty();
                $("#IdcuentaBancaria").append("<option value='N/A' disabled selected>Seleccionar</option>");
                $("#NombreCuenta, #SaldoCuenta").val("");

                $.each(data, function (index, row) {
                    var campoA = row["NumeroCuenta"];
                    var campoId = row["IdCuentaBancaria"];
                    if (campoId === IdCuentaBancaria) {
                        $("#IdcuentaBancaria").append("<option selected='selected' value='" + campoId + "'>" + campoA + "</option>");
                        $("#NombreCuenta").val(row["NombreCuenta"]);
                        $("#MontoComprometido").attr({
                            'max': rest,
                            'placeholder': '$' + rest + ' faltantes'
                        });

                        $("#SaldoCuenta").val(new Number(row["MontoDisponible"]).toLocaleString("en-US"));
                    } else {
                        $("#IdcuentaBancaria").append("<option value='" + campoId + "'>" + campoA + "</option>");
                    }
                });

            });

            $(".modal-title").html(`<div class="text-center">Editar</div>`);
            $("#form-Liquidez :input[type=submit]").val("Editar");
            $("#LiquidezModal").modal('show');
        })
        .fail(function (data) {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "No se ha podido procesar la solicitud",
                callback: function () {
                    $("#LiquidezModal").modal('hide');

                }
            })

        });
}

function saveCondcionesDeEntrega() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdAdjudicacionCondicionEntrega = $("#IdAdjudicacionCondicionEntrega").val();
    var url_ = "";
    var parametros = {
        IdAdjudicacionCondicionEntrega: $("#IdAdjudicacionCondicionEntrega").val(),
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        IdTipoDia: $("#IdTipoDia").val(),
        IdPlazoEntegra: $("#IdPlazoEntegra").val(),
        PlazoEntregaCantidad: $("#PlazoEntregaCantidad").val(),
        FechaLimite: $("#FechaLimite").val(),
        IdTipoEntrega: $("#IdTipoEntrega").val(),
        Observaciones: "-------",
        NotaEspecial: $("#NotaEspecial").val() === "" ? " " : $("#NotaEspecial").val(),
        IdEstatus: 1,
        IdUsuarioRegistro: 0,
        FechaRegistro: "",
        IdPlazoTiempo: $("#IdPlazoTiempo").val(),
        __RequestVerificationToken: token

    };
    if (IdAdjudicacionCondicionEntrega === "0")
        url_ = '/AdjudicacionesDirectasMayores/saveCondicionesDeEntrega/';  
    else
        url_ = '/AdjudicacionesDirectasMayores/saveEditCondiconesDeEntrega/';
    
    $.ajax({
        data: parametros,
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
           
            if (response.success) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Datos " + (IdAdjudicacionCondicionEntrega === "0" ? "guardados": "editados") +" correctamente"
                })

                $("#idNuevaCondicionDePago, #btnNuevaCondicionPago").removeClass('disabledClick');

                $("#IdAdjudicacionCondicionEntrega").val(IdAdjudicacionCondicionEntrega === "0" ? response.id : IdAdjudicacionCondicionEntrega);

                $("#div_condiciones_pagoTabPadre").removeClass("disabledClick");
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: "Error en el Guardado: " + response.mensaje
                })
            }

        }
    });
}

function saveCondicionPago() {
    var table = $('#tablaPagos').DataTable();

    if (!table.data().count()) {
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Error</div>`,
            message: "Error en el guardado, falta generar desglose de pagos"
        })

        return;
    }

    var importeTotalPagosPendiente_ = numeral($(".importeTotalPagosPendiente").val()).value();
    var token = $("[name='__RequestVerificationToken']").val();
    var IdAdjudicacionCondicionPago_ = $("#IdAdjudicacionCondicionPago").val();

    var parametro = {
        IdAdjudicacionCondicionPago: IdAdjudicacionCondicionPago_,
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        Anticipo: $("#IdAnticipoBool").val(),
        IdAnticipo: $("#IdAnticipo").val(),
        PorcentajeAnticipo: $(".porcentajeAplicado").val(),
        ImporteAnticipo: numeral($("#ImporteAnticipo").val())["_value"],
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
    var url_ = '/AdjudicacionesDirectasMayores/saveCondicionesPago/';
    if (IdAdjudicacionCondicionPago_ !== "0") {
        url_ = '/AdjudicacionesDirectasMayores/saveEditCondicionPago/';
    }
    $.ajax({
        data: parametro,
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
          
            if (response.success) {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Datos guardados correctamente"
                })

                cargartablaPagos(response.lst);
                getDireccionPago();
            }
            else {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: "Error en el Guardado: " + response.mensaje
                })
            }

        }
    });
}

function validarFomCondiconesDeEntregaDetalle() {
    $("button.navbar-toggler").css("margin-right", "0")

    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Esta campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor 0.";
    jQuery.validator.messages.step = "Por favor, escribe un valor mayor a 0.";


    var validado = $("#CondicionesDeEntregaDetalleForm").valid();
    var countCheckedCheckboxes = $('#CondicionesDeEntregaDetalleDiv .col-10 input[type="checkbox"]').filter(':checked').length;
    var valido = true;

    if (countCheckedCheckboxes === 0) {

        bootbox.alert({
            size: "small",
            title: "Aviso",
            message: "Falta seleccionar días de entrega"
        });
        valido = false;
    }

    if (!validarCantidadesCondiconesEntregaDetalle()) {

        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "La cantidad que desea asignar es mayor a la cantidad por asignar."
        })
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

    if (idCondicionEntregaDetalle !== "0") {
        CantidadLoteXAsignar = CantidadLoteXAsignar + parseFloat(CantidadDetalleReal);
    }

    if (CantidadLoteXAsignar - CantidadDetalle < 0) {
        return false;
    }
    else {
        return true;
    }
}

function nuevaCondicionDePagoDetalle() {
    resetformConcionesDeEntregaDetalle();
    $(".modal-title").html(`<div class="text-center">Detalle entrega condición</div>`);
    getCantidad_x_Idlote();
    $("#modal_condiciones_entrega").modal("show");
}

function resetformConcionesDeEntregaDetalle() {

    $("#GuardarCondicionesDeEntrega").css({ "display": "" });
    $("#ActualizarCondicionesDeEntrega").css({ "display": "none" });
    $(".modal-title").html(`<div class="text-center">Alta Condición entrega</div>`);
    $("#modal_condiciones_entrega").modal("hide");
    $("#CondicionesDeEntregaDetalleForm")[0].reset();
    $("#IdCondicionEntregaDetalle").val(0);
    $('#datetimepickerHorarioInicio, #datetimepickerHorarioFin').datetimepicker({
        language: "es",
        format: "H:ii",
        timeFormat: 'H:ii',
        startView: 0,
        minView: 0,
        autoclose: 1

    });
}

function saveCondiconesDeEntregaDetalle() {
    var IdCondicionEntregaDetalle = $("#IdCondicionEntregaDetalle").val();

    var parametro = {
        IdCondicionEntregaDetalle: IdCondicionEntregaDetalle,
        IdAdjudicacionCondicionEntrega: $("#IdAdjudicacionCondicionEntrega").val(), 
        IdLugarEntrega: $("#IdLugarEntrega").val(),
        NumeroEntrega: 0,
        IdAdjudicacionLote: $("#IdAdjudicacionLote").val(),
        Cantidad: $("#CantidadDetalle").val(),
        HorarioInicio: $("#HorarioInicio").val(),
        HorarioFinal: $("#HorarioFinal").val(),
        Lunes: $("#checkLunes").is(":checked") ? 1 :0,
        Martes: $("#checkMartes").is(":checked") ? 1 : 0,
        Miercoles: $("#checkMiercoles").is(":checked") ? 1 : 0,
        Jueves: $("#checkJueves").is(":checked") ? 1 : 0,
        Viernes: $("#checkViernes").is(":checked") ? 1 : 0,
        Sabado: $("#checkSabado").is(":checked") ? 1 : 0,
        Domingo: $("#checkDomingo").is(":checked") ? 1 : 0,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };
    var url_ = '/AdjudicacionesDirectasMayores/saveCondicionesDeEntregaDetalle/';
    if (IdCondicionEntregaDetalle !== "0") {
        url_ = '/AdjudicacionesDirectasMayores/saveEditCondicionesDeEntregaDetalle/';
    }
    $.ajax({
        data: parametro,
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
          
            if (response.success) {
                nuevaCondicionDePagoDetalle();
                cargartablaCondicionesDeEntrega(response.lst);
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Datos guardados correctamente"
                })

                getLstLotesPorAsignar();
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Error en el guardado: " + response.mensaje
                })
            }

        }
    });
}

/*
function editarCondicinesEntregaDetalle(IdCondicionEntregaDetalle_) {
    $('#SemanaSelect').html("");
    
    var token = $("[name='__RequestVerificationToken']").val();
    $("#IdCondicionEntregaDetalle").val(IdCondicionEntregaDetalle_);
    var url_ = '/AdjudicacionesDirectasMayores/getCondicionEntregaDetalle/';
    $.ajax({
        data: { IdCondicionEntregaDetalle: IdCondicionEntregaDetalle_, __RequestVerificationToken: token },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
         
            if (response.success) {

                $("#IdAdjudicacionCondicionEntrega").val(response.objeto.IdAdjudicacionCondicionEntrega);
                $("#IdLugarEntrega").val(response.objeto.IdLugarEntrega);
                $("#IdAdjudicacionLote").val(response.objeto.IdAdjudicacionLote);
                $("#CantidadDetalle").val(response.objeto.Cantidad);
                $("#HorarioInicio").val(response.objeto.HorarioInicio.Hours + ":" + response.objeto.HorarioInicio.Minutes);
                $("#CantidadDetalleReal").val(response.objeto.Cantidad);
                $("#HorarioFinal").val(response.objeto.HorarioFinal.Hours + ":" + response.objeto.HorarioFinal.Minutes);
                $("#GuardarCondicionesDeEntrega").css({ "display": "none" });
                $("#ActualizarCondicionesDeEntrega").css({ "display": "" });
                $(".modal-title").html("Actualizar Condición entrega Detalle");
                $("#modal_condiciones_entrega").modal("show");
                getDireccion();
                var cadena = "";
                $.each($(".dropdown-menu input[name=semana]"), function () {
                    switch ($(this).val()) {
                        case "Lunes":
                            $(this).attr('checked', response.objeto.Lunes === 1 ? true : false);
                            break;
                        case "Martes":
                            $(this).attr('checked', response.objeto.Martes === 1 ? true : false);
                            break;
                        case "Miercoles":
                            $(this).attr('checked', response.objeto.Miercoles === 1 ? true : false);
                            break;
                        case "Jueves":
                            $(this).attr('checked', response.objeto.Jueves === 1 ? true : false);
                            break;
                        case "Viernes":
                            $(this).attr('checked', response.objeto.Viernes === 1 ? true : false);
                            break;
                        case "Sabado":
                            $(this).attr('checked', response.objeto.Sabado === 1 ? true : false);
                            break;
                        case "Domingo":
                            $(this).attr('checked', response.objeto.Domingo === 1 ? true : false);
                            break;
                    }
                });

                var values = new Array();
                cadena = "";
                $.each($(".dropdown-menu input[name=semana]:checked"), function () {
                    if (values.length < $("input[name=semana]:checked").length / 2) {
                        values.push($(this).val());
                        cadena += '<button type="button" class="btn btn-outline-primary btn-sm" style="margin-right:2%"><span class="badge">' + $(this).val() + '</span></button>';
                    }

                });
                
                $("#diasDelaSemana").val(values.join(','));
                $("#SemanaSelect").html(cadena);
                getCantidad_x_Idlote();
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Aviso",
                    message: "Error en el Guardado: " + response.mensaje
                });
            }

        }
    });
}

*/

function eliminarCondicinesEntregaDetalle(IdCondicionEntregaDetalle_) {
    bootbox.confirm({
        title: "Aviso",
        message: "¿Desea eliminar la condición entrega?",
        size: "small",
        callback: function (result) {
            if (result)
            {
                var token = $("[name='__RequestVerificationToken']").val();
                var url_ = '/AdjudicacionesDirectasMayores/eliminarCondicionEntregaDetalle/';
                $.ajax({
                    data: { IdCondicionEntregaDetalle: IdCondicionEntregaDetalle_, IdAdjudicacionCondicionEntrega: $("#IdAdjudicacionCondicionEntrega").val(), __RequestVerificationToken: token },
                    url: url_,
                    type: 'post',
                    beforeSend: function () {

                    },
                    success: function (response) {

                        if (response.success) {

                            cargartablaCondicionesDeEntrega(response.lst);

                            bootbox.alert({
                                size: "small",
                                title: `<div class="text-center">Aviso</div>`,
                                message: "Se elimino la condición entrega"
                            })

                            getLstLotesPorAsignar();
                        }
                        else {
                            bootbox.alert({
                                size: "small",
                                title: `<div class="text-center">Error</div>`,
                                message: "Error en el Guardado: " + response.mensaje
                            })

                        }

                    }
                });
            }
        }
    });

}

function cargartablaCondicionesDeEntrega(data) {

    $('#condicionesDeEntragaTable').dataTable({
        "bDestroy": true
    }).fnDestroy();

    $('#condicionesDeEntragaTable').dataTable().fnDestroy();

    $('#condicionesDeEntragaTable').DataTable({
        scrollY: "280px",
        scrollX: true,
        sort: false,
        data: data,
        "columns": cargarColumnasCondicionEntregaDetalle()
    });
    initAutocomplete();
}

function getCantidad_x_Idlote() {
    var token = $("[name='__RequestVerificationToken']").val();
    var url_ = '/AdjudicacionesDirectasMayores/getCantidad_x_Idlote/';
    var IdAdjudicacionLote = $("#IdAdjudicacionLote").val();
    $.ajax({
        data: { IdAdjudicacionLote: IdAdjudicacionLote, IdAdjudicacion: $("#IdAdjudicacion").val(), __RequestVerificationToken: token },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                $("#CantidadDetalle").attr("max", response.objeto.CantidadxAsignar);
                $("#CantidadLoteAsignado").val(response.objeto.CantidadLoteAsignado);
                $("#CantidadLoteXAsignar").val(response.objeto.CantidadxAsignar);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Error en el Cargar cantidades: " + response.mensaje

                })
            }
        }
    });
}

function getDireccion() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntrega").val();
    var url_ = '/AdjudicacionesDirectasMayores/getLugarEntrega_x_IdLugarEntrega/';
    $.ajax({
        data: { __RequestVerificationToken: token, IdLugarEntrega: IdLugarEntrega_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
        
            if (response.success) {

                $("#Direccion").val(response.objeto.Direccion + ' ' + response.objeto.Colonia);
                placeMarker(response.objeto.LocalizacionGoogle);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: "Error en el Guardado: " + response.mensaje
                })

            }

        }
    });
}

function getDireccionPago() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLugarEntrega_ = $("#IdLugarEntregaPago").val();
    var url_ = '/AdjudicacionesDirectasMayores/getLugarEntrega_x_IdLugarEntrega/';
    $.ajax({
        data: { __RequestVerificationToken: token, IdLugarEntrega: IdLugarEntrega_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
        
            if (response.success) {

                //$("#Direccion").val(response.objeto.Direccion + ' ' + response.objeto.Colonia);
                placeMarkerPorMapa(response.objeto.LocalizacionGoogle, "mapFirmaPago");
            }
            else {
                bootbox.aler({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: "Error en el guardado: " + response.mensaje
                })
            }

        }
    });
}

function getCalculoPartida() {
    var IdPeriodicidad_ = $("#IdPeriodicidad").val();
    var cantidadPagos_ = $("#numeroPagosAGenerar").val();
    var importeRestante_ = numeral($(".importeTotalPagosPendiente").val()).value();
    var porcentajeAplicado_ = $(".porcentajeAplicado").val();
    var token = $("[name='__RequestVerificationToken']").val();
    var FechaInicioPago_ = $("#FechaInicioPago").val();
    var url_ = '/AdjudicacionesDirectasMayores/getCalculoPartida/';

    $.ajax({
        data: { __RequestVerificationToken: token, IdPeriodicidad: IdPeriodicidad_, cantidadPagos: cantidadPagos_, importeRestante: importeRestante_, porcentajeAplicado: porcentajeAplicado_, FechaInicioPago: FechaInicioPago_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
        
            if (response.success) {

                cargartablaPagos(response.lst);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error</div>`,
                    message: "Error consultar anticipo: " + response.mensaje
                })
            }

        }
    });
}

function calcularPorcentaje() {
    var IdAnticipo_ = $("#IdAnticipo").val();
    if (IdAnticipo_ === "" || IdAnticipo_ === undefined) {
        IdAnticipo_ = 0;
    }
    var token = $("[name='__RequestVerificationToken']").val();
    var url_ = '/AdjudicacionesDirectasMayores/getAnticipo/';
    $.ajax({
        data: { __RequestVerificationToken: token, IdAnticipo: IdAnticipo_ },
        url: url_,
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                var porcentaje = parseFloat(response.objeto.PorcentajeValor);
                $(".porcentajeAplicado").val(porcentaje);
                var ImporteTotalConImpuesto = numeral($("#ImporteTotalConImpuesto").val())["_value"];
                var impuestoCalculado = ImporteTotalConImpuesto * porcentaje;
                var importeTotalPagosPendiente = ImporteTotalConImpuesto - impuestoCalculado;
                $("#ImporteAnticipo").val(numeral(impuestoCalculado).format('0,0.00'));
                $(".importeTotalPagosPendiente").val(numeral(importeTotalPagosPendiente).format('0,0.00'));
                $("#ImporteTotalPago").val(numeral(ImporteTotalConImpuesto).format('0,0.00'));

            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: "Error consultar anticipo: " + response.mensaje
                });
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
        data: data,
        order: [[1, "asc"]],
        columnDefs: [
            { targets: [2, 3], className: "dt-body-right"},
            { targets: [0], className: "dt-body-center"}

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
            var totalMoney = $("#ImporteTotalPago").val();
            $(api.column(2).footer()).html(
                'subtotal: <strong>$' + numpageTotal.toFixed(2) + '</strong> \n de total <strong>$' + totalMoney + '</strong>'
            );
            // Update footer
            var numpageTotalPorcentaje = parseFloat(pageTotalPorcentaje);
            var numtotalPorcentaje = parseFloat(totalPorcentaje);
            $(api.column(3).footer()).html( numpageTotalPorcentaje.toFixed(2) + '%');
        }
    });
}

function cargarColumnasPago() {
    dataRow = [
        {
            mRender: function (data, type, row) {
                var disable = row.bool1 ? "" : "disabledClick";
                return '<div class="btn-group"><button class="btn btn-secondary btn-sm ' + disable + '" style="margin-right:5px;" onclick="editarLote(' + row.id2 + ')" ><span class="fa fa-pencil" ></span></button></div>';
            }
        },
        { "data": "id", sortable: true },
        { "data": "decimal1", sortable: true, render: $.fn.dataTable.render.number(',', '.', 2, '$') },
        {
            "data": "decimal2", sortable: true, render: function (data, type, row) {
                return data.toFixed(2) + "%";

            }
        }, // $.fn.dataTable.render.number(',', '.', 2, '%') },  
        { "data": "string1", sortable: true },
        { "data": "string2", sortable: true }
    ];
    return dataRow;
}

function editarCondicionPagoDetalle(id) {
    bootbox.prompt(`<div class="text-center">Agrega nuevo valor para guardar</div>`, function (result) {
        if (result) {

            var token = $("[name='__RequestVerificationToken']").val();
            var IdAdjudicacionCondicionPago_ = $("#IdAdjudicacionCondicionPago").val();
            var parametro = {
                IdAdCondicionPagoDetalle: id,
                IdAdjudicacionCondicionPago: IdAdjudicacionCondicionPago_,
                FechaPago: "",
                PorcentajePago: "",
                NumeroPago: id,
                ImportePago: result,
                __RequestVerificationToken: token
            };
            var url_ = '/AdjudicacionesDirectasMayores/saveEditCondicionPagoDetalle/';
            $.ajax({
                data: parametro,
                url: url_,
                type: 'post',
                beforeSend: function () {

                },
                success: function (response) {
                
                    if (response.success) {
                        bootbox.alert({
                            size: "small",
                            title: `<div class="text-center">Aviso</div>`,
                            message: "Condiciones de Pago detalle guardados correctamente"
                        })

                        cargartablaPagos(response.lst);
                        getDireccionPago();
                    }
                    else {
                        bootbox.alert({
                            size: "small",
                            title: `<div class="text-center">Aviso</div>`,
                            message: "Error en el Guardado: " + response.mensaje
                        })
                    }

                }
            });
        }
    });


}

function asignarProveedor(IdProveedor) {

    var check = $("#" + IdProveedor);

    var parametros = {

        //IdAdjudicacionProveedor
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        IdProveedor: IdProveedor,
        IdEstatusAdjudicacionProveedor: 10,

        /* 
        PROPUESTA TECNICA
            IdEstatusEnvioPropuestaTecnica,
            IdUsuaroEnviaPropuestaTecnica
            FechaEnvioPropuestaTecnica

        PROPUESTA ECONOMICA
            IdEstatusEnvioPropuestaEconomica,
            IdUsuaroEnviaPropuestaEconomica,
            FechaEnvioPropuestaEconomica,

        CARTAS Y MANIFIESTOS  (posible uso)
            CartasDependenciaCumple,
            CartaFundamento,
            CartaAdquisicionCumple,
            CartasAdqObservacion,
            ManifiestoDependenciaCumple,
            ManifiestoFundamento,
            ManifiestoAdquisicionCumple,
            ManifiestoAdqObservacion,

        CONDICION ENTREGA
            CondicionEntregaDependenciaCumple,
            CondicionEntregaFundamento,
            CondicionEntregaAdquisicionCumple,
            CondicionEntregaAdqObservacion,

        CONDICION PAGO
            CondicionPagoDependenciaCumple,
            CondicionPagoFundamento,
            CondicionPagoAdquisicionCumple,
            CondicionPagoAdqObservacion, 

        REVISOR 
            ValidaLotesRevisor,
            ObservacionConEntregaRevisor,
            ValidaCondicionEntregaRevisor,
            ObservacionCondPagoRevisor,
            ValidaCondicionPagoRevisor,
            ObservacionDoctosRevisor,
            ValidaDocumentosRevisor
        */

        IdUsuarioRegistro: 0,
        FechaRegistro: 0,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    if (check.is(':checked')) {

        $.post("/AdjudicacionesDirectasMayores/AsignarProveedor/", parametros, "JSON")
            .done(function (data) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Proveedor Asignado correctamente"
                })

                $("#" + IdProveedor).attr("data-IdAdjudicacionProveedor", data.mensaje);

            }).fail(function (data) {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error al asignar Proveedor</div>`,
                    message: "Error producido por: " + data.mensaje
                })
            });
    } else {

        var IdAdjudicacionProveedor = $("#" + IdProveedor).attr("data-IdAdjudicacionProveedor");

        var parameters = {
            IdAdjudicacionProveedor: IdAdjudicacionProveedor,
            __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
        };

        $.post("/AdjudicacionesDirectasMayores/QuitarProveedor/", parameters, "JSON")
            .done(function (data) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "Proveedor eliminado correctamente de la adjudicación"
                })

                $("#" + IdProveedor).attr("data-IdAdjudicacionProveedor", "0");

            }).fail(function (data) {

                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error al eliminar Proveedor</div>`,
                    message: "Error producido por: " + data.mensaje
                })
            });
    }

}

function actualizarProv(Idlote_) {

    $("#IdLote").val(Idlote_);

    var pAdjudicacionLote = {
        IdLote: Idlote_,
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        data: pAdjudicacionLote,
        url: '/AdjudicacionesDirectasMayores/getAdjudicacionLoteProv',
        type: 'post',
        beforeSend: function () {
        },
        success: function (response) {

            if (response.success) {
                cargarValoresProv(response);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Error cargar lote</div>`,
                    message: response.data
                })
            }
        }
    });
}

function cargarValoresProv(data) {

    console.log(data);

    $("#GuardarLote").css({ "display": "none" });
    $("#ActualizarLote").css({ "display": "" });
    $(".modal-title").html(`<div class="text-center">Editar lote</div>`);

    $("#PrecioUnitarioListaSinImpuestoMensual").removeAttr('readonly').attr("max", data.objeto.PrecioUnitario);
    $("#ImporteSinImpuestoMensual").val(numeral(data.dp.ImporteOfertado).format('0,0.00'));
    $("#importeConImpuesto").val(numeral(data.objeto.ImporteCImpuesto).format('0,0.00'));
    $("#ImporteConImpuestoMensual").val(numeral(data.dp.ImpuestoImporte).format('0,0.00'));
    $("#ImporteTotalPeriodo").val(numeral(data.dp.TotalOfertado).format('0,0.00'));
    $("#Impuesto").val(data.objeto.Impuesto);
    $("#ClavePantone").val(data.objeto.Pantone.trim()).attr('readonly', 'true');
    $("#Cantidad").val(data.objeto.Cantidad).attr('readonly', 'true');
    $("#Frecuencia").val(data.objeto.IdFrecuencia).attr('readonly', 'true');
    $("#Producto").val(data.objeto.BienServicio).attr('readonly', 'true');
    $("#Unidad").val(data.objeto.UnidadMedida);
    $("#IdBienServicio").val(data.objeto.IdBienServicio);
    $("#Caracteristica").val(data.objeto.Descripcion).attr('readonly', 'true');
    $("#TasaImpuesto").val(data.objeto.PorcentajeImpuesto);
    $("#De").val(!data.objeto.IdMesInicial ? "0" : data.objeto.IdMesInicial).attr('disabled', 'true');
    $("#Al").val(!data.objeto.IdMesFinal.trim() ? "0" : data.objeto.IdMesFinal.trim()).attr('disabled', 'true');
    $("#Meses").val(!data.objeto.MesesServicio ? "0" : data.objeto.MesesServicio);
    $("#Requerimiento").val(data.objeto.IdMuestra).attr('readonly', 'true');
    $("#ImporteTotalPeriodoActual").val(data.objeto.Total);
    $("#tpeu").val(data.objeto.PrecioUnitario);
    $("#tpeuLabel").html(`Precio de referencia sin IVA: $${data.objeto.PrecioUnitario}`)

    $("#PrecioUnitarioListaSinImpuestoMensual").val(data.dp.PrecioUnitarioOfertado);
    //precioProv(this, data.objeto.PrecioUnitario !== 0 ? data.objeto.BsPrecioUnitario : "0.00");
    $("#ImporteTotalPeriodo").val(data.objeto.MesesServicio !== 0 ? $("#ImporteTotalPeriodo").val() * data.objeto.MesesServicio : $("#ImporteTotalPeriodo").val());
    
    $("#modal_nuevo_lote").modal("show");
}

function precioProv(e, value) {
    var cantidad = parseFloat($("#Cantidad").val());
    var meses = parseInt($("#Meses").val()) === 0 ? 1 : parseInt($("#Meses").val());
    var imp = $("#PrecioUnitarioListaSinImpuestoMensual").val() * $("#TasaImpuesto").val() * cantidad;

    var importeSImp = value * cantidad;
    var importeCImp = value * cantidad + imp;
    var importeTotal = importeCImp * meses; 

    $("#ImporteSinImpuestoMensual").val(numeral(importeSImp).format('0,0.00'));
    $("#ImporteConImpuestoMensual").val(numeral(importeCImp).format('0,0.00'));
    $("#ImporteTotalPeriodo").val(numeral(importeTotal).format('0,0.00'));
    
}
 
function validarFormularioProv() {
    $("button.navbar-toggler").css("margin-right", "0")

    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Esta campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.min = "Por favor, escribe un valor mayor 0.";
    jQuery.validator.messages.max = "Por favor, escribe un valor menor a $${0}";
    jQuery.validator.messages.step = "Por favor, escribe un valor mayor a 0.";

    var validado = $("#div_LotesForm").valid();

    if (validado && $("#PrecioUnitarioListaSinImpuestoMensual").val() !== "0") {

        savePropEcoProv();
    }// else {
    //    bootbox.alert({
    //        size: "small",
    //        title: "Aviso",
    //        message: "El precio unitario sin impuestos del " + (solicitud === 1 ? "bien" : "servicio") + " debe ser mayor a cero."
    //    });
    //}

}

function savePropEcoProv() {

    var parametros = {
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        IdAdjudicacion: $("#IdAdjudicacion").val(),
        IdAdjudicacionProveedor: $("#IdAdjudicacionProveedor").val(),
        IdLote: $("#IdLote").val(),
        PrecioUnitarioRefencia: numeral($("#tpeu").val())["_value"],
        PrecioUnitarioOfertado: numeral($("#PrecioUnitarioListaSinImpuestoMensual").val())["_value"],
        ImpuestoPorcentaje: numeral($("#TasaImpuesto").val())["_value"],
        ImporteOfertado: numeral($("#ImporteSinImpuestoMensual").val())["_value"],
        ImpuestoImporte: numeral($("#ImporteConImpuestoMensual").val())["_value"],
        ImportePeriodo: numeral($("#ImporteSinImpuestoMensual").val())["_value"],
        ImpuestoPeriodo: numeral($("#ImporteConImpuestoMensual").val())["_value"],
        TotalPeriodo: numeral($("#ImporteTotalPeriodo").val())["_value"],
        TotalOfertado: numeral($("#ImporteTotalPeriodo").val())["_value"]


    };

    if (solicitud === 2) {
         parametros = {
             __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
             IdAdjudicacion: $("#IdAdjudicacion").val(),
             IdLote: $("#IdLote").val(),
             PrecioUnitarioRefencia: numeral($("#tpeu").val())["_value"],
             PrecioUnitarioOfertado: numeral($("#PrecioUnitarioListaSinImpuestoMensual").val())["_value"],
             ImpuestoPorcentaje: numeral($("#TasaImpuesto").val())["_value"],
             ImportePeriodo: numeral($("#ImporteSinImpuestoMensual").val())["_value"],
             ImpuestoPeriodo: numeral($("#ImporteConImpuestoMensual").val())["_value"],
             TotalPeriodo: numeral($("#ImporteTotalPeriodo").val())["_value"],
             ImporteOfertado: numeral($("#ImporteSinImpuestoMensual").val())["_value"],
             ImpuestoImporte: numeral($("#ImporteConImpuestoMensual").val())["_value"],
             IdMesInicial: numeral($("#De").val())["_value"],
             IdMesFinal: numeral($("#Al").val())["_value"]
        };
    }

    $.post("/AdjudicacionesDirectasMayores/savePropuestaEconomica", parametros, "JSON")
        .done(function () {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "Se ofertó lote",
                callback: function () {
                    $("#modal_nuevo_lote").modal("hide");
                }
            })
        }).fail(function (data) {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "Error al guardar los datos. " + data.mensaje
            })
        });
}

$('#LotesTable').on('click', '.editPropTec', function () {
    //
    document.getElementById("URLFileMuestraCatalogo").value = ""
    document.getElementById("URLFileCertificacion").value = ""
    $("#formPropTec")[0].reset();
    
    $('#Product').val($(this).attr('data-Produ'));
    $('#Unidad').val($(this).attr('data-unidad'));
    $('#Caracteristica').val($(this).attr('data-req'));
    $('#Requerimiento').val($(this).attr('data-carc'));//mostrar tipo de requerimiento
    $('#IdAdjudicionPropuestaTecEco').val($(this).attr('data-IdAdjProTecEco'));
    $.get(
        '/AdjudicacionesDirectasMayores/buscarPropuestaEconomica/',
        {
            id: $(this).attr('data-IdAdjProTecEco')
        },
        "json"
    ).done(function (data) {
        $('#lblURLFileMuestraCatalogo').text(cleanName(data.URLFileMuestraCatalogo));
        $('#lblURLFileCertificacion').text(cleanName(data.URLFileCertificacion));
        $('#EstatusMejora').prop('checked', data.EstatusMejora);
        if (data.EstatusMejora) {
            $('#Mejora').removeAttr('readonly');
            $('#EstatusMejora').val(1);
        } else {
            $('#Mejora').prop('readonly', true);
            $('#EstatusMejora').val(0);
        }
        $('#Mejora').val(data.Mejora);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: `Error: ${jqXHR} ${textStatus} ${errorThrown}`
        })
    });

    $("#PropTecnica").modal('show');
});

$('#GuardarPropTec').click(function (e) {
    $("button.navbar-toggler").css("margin-right", "0")
    //document.getElementById("URLFileMuestraCatalogo").value = ""
    //document.getElementById("URLFileCertificacion").value = ""
    e.preventDefault();

    // Create FormData object
    var fileData = new FormData();

    let estatus = $("#EstatusMejora").val();
    let mejora = $("#Mejora").val();
    let fileUpload = $("#URLFileMuestraCatalogo").get(0);
    let fileUpload2 = $("#URLFileCertificacion").get(0);
    let idadjproptec = $("#IdAdjudicionPropuestaTecEco").val();

    //bootbox.alert({ title: "asdasdasda", message: `${fileUpload.files[0]} ${fileUpload2.files[0]}` })

    fileData.append("IdAdjudicionPropuestaTecEco", idadjproptec);
    fileData.append("ArchivoUno", fileUpload.files[0]);
    fileData.append("ArchivoDos", fileUpload2.files[0]);
    fileData.append("EstatusMejora", estatus);
    fileData.append("Mejora", mejora);
    fileData.append("__RequestVerificationToken", $('input[name="__RequestVerificationToken"]').val());

    if (mejora == "" && estatus == 0 || mejora != "" && estatus == 1) {
        $.ajax({
            url: '/AdjudicacionesDirectasMayores/savePropuestaTecnica/', type: "POST", processData: false,
            data: fileData, dataType: 'json',
            contentType: false,
            success: function (response) {
                if (response.success) {
                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Aviso</div>`,
                        message: `${response.mensaje}`,
                        callback: function () {
                            $("#PropTecnica").modal('hide');
                            location.href = `/AdjudicacionesDirectasMayores/Tecnica?${$('#keepMe').val()}`;
                        }
                    })
                }
                else {
                    bootbox.alert({
                        size: "small",
                        title: `<div class="text-center">Aviso</div>`,
                        message: `${response.mensaje}`
                    })
                    $("#PropTecnica").modal('hide');
                }
            },
            error: function (er) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: `${er}`
                })
            }
        });
    } else {
        bootbox.alert({
            title: `<div class="text-center">Aviso</div>`,
            message: mejora == "" ? "Falta llenar el campo de mejora" : mejora != "" ? "Seleccione mejora para poder enviar mejora" : "Verifique la información",
            size: "small"
        })
    }

    return false;
});

$('#EstatusMejora').on('change', function () {
    if ($(this).is(':checked')) {
        $('#Mejora').removeAttr('readonly');
        $(this).val(1);
    } else {
        $('#Mejora').prop('readonly', true);
        $(this).val(0);
    }
});

$('input[name="id"]').on('change', function () {
    if (!($("#Formulario").val() === "div_propuesta_tecnicaTabPadre")) {
        if ($(this).is(':checked')) {
            //$(`button[name="${$(this).val()}"]`).prop("disabled", false)
            $.post(
                '/AdjudicacionesDirectasMayores/savePropuestaTecnicaEconomicaCheckBox/',
                {
                    id: $(this).val(),
                    idAdj: $(this).attr('data-adj')
                }
            ).done(function (data) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: "" + data.mensaje,
                    callback: function () {
                        location.href = `/AdjudicacionesDirectasMayores/Tecnica?${$('#keepMe').val()}`;
                    }
                })

            }).fail(function (jqXHR, textStatus, errorThrown) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: `Error: ${jqXHR} ${textStatus} ${errorThrown}`
                })
            });
        } else {
            //$(`button[name="${$(this).val()}"]`).prop("disabled", true)
            $.post(
                '/AdjudicacionesDirectasMayores/deletePropuestaTecnicaEconomicaCheckBox',
                {
                    id: $(this).attr('data-IdAdjProTecEco')
                }
            ).done(function (data) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: `${data.mensaje}`,
                    callback: function () {
                        location.href = `/AdjudicacionesDirectasMayores/Tecnica?${$('#keepMe').val()}`;
                    }
                })
            }).fail(function (jqXHR, textStatus, errorThrown) {
                bootbox.alert({
                    size: "small",
                    title: `<div class="text-center">Aviso</div>`,
                    message: `Error: ${jqXHR} ${textStatus} ${errorThrown}`
                })
            });
        }
    } else {

        if ($(this).is(":checked")) {
            $(this).prop("checked", false);

        } else {
        $(this).prop("checked", true);
        }
    }
});

function changeName(input, resultname) {
    $('#' + resultname).text(input.files[0].name);
}

function cleanName(url) {
    let parts = url.split("\\");
    let name = parts[parts.length - 1];
    return name;
}

function validarCheckAceptarPropTecnica() {

    if ($("#aceptarPropTec").is(':checked')) {
        $("#btnProveedorAutorizaTec").removeAttr('disabled');

        $("#IdAceptoProvBool").val("1");
    } else {
        $("#btnProveedorAutorizaTec").attr('disabled', 'disabled');

        $("#IdAceptoProvBool").val("0");
    }

}

function propuestaTec() {

    var lotesCheck = $("#LotesTable").children('tbody').children('tr').children('td').children('div').children('input[type=checkbox]').filter(":checked").length;
    var lotesTotal = $("#LotesTable").DataTable().rows().count();
    
    if (lotesTotal === lotesCheck) {
        bootbox.confirm({
            size: "small",
            title: `<div class="text-center">Enviar propuesta técnica</div>`,
            message: "¿Desea enviar propuesta técnica para su revisión? ",
            callback: function (result) {
                if (result) {

                    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviarpropuestaTec, b: undefined })

                }

            }

        })
    } else {
        bootbox.alert({
            size: "small",
            title: `<div class="text-center">Aviso</div>`,
            message: "Debe ofertar todos los lotes"
        })
    }


}
function saveEnviarpropuestaTec() {
    var parametros = {
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        IdAdjudicacion: $("#IdAdjudicacion").val()
    };

    $.post("/AdjudicacionesDirectasMayores/updateEstatusPropuestaTecnicaEconomica", parametros, "JSON")
        .done(function (data) {

            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: data.mensaje,
                callback: function () {
                    location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion;
                }
            })

        }).fail(function (data) {

            console.log(data);
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "No se ha podido enviar la propuesta técnica"
            })
        });
}
function propuestaEco() {

    bootbox.confirm({
        size: "small",
        title: `<div class="text-center">Enviar propuesta económica</div>`,
        message: "¿Desea enviar propuesta económica para su revisión? ",
        callback: function (result) {
            if (result) {

                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEnviarPropuestaEco, b: undefined })
            }
        }
    })

}

function saveEnviarPropuestaEco() {
    var parametros = {
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        IdAdjudicacion: $("#IdAdjudicacion").val()
    };

    $.post("/AdjudicacionesDirectasMayores/updateEstatusPropuestaTecnicaEconomica", parametros, "JSON")
        .done(function (data) {

            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: data.mensaje,
                callback: function () {
                    location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion;
                }
            })

        }).fail(function (data) {
            bootbox.alert({
                size: "small",
                title: `<div class="text-center">Aviso</div>`,
                message: "No se ha podido enviar la propuesta técnica"
            })
        });
}