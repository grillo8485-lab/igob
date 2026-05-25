$(document).ready(function () {
    $('.table').DataTable({
        sort: false,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
        }
    });

    $('.datepicker').datetimepicker({
        language: 'es',
        format: "yyyy-mm-dd",
        pickerPosition: "bottom-left",
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

$("#section__liquidez").on('click','.new-liquidez',function (e) {

    var montoAutorizado = parseFloat(numeral($("#MontoPresupuestadoAutorizado").val())["_value"]);

    var totalMontoComprometido = parseFloat($("#totalMontoComprometido").val());

    document.getElementById("form-Liquidez").reset();

    $("#IdcuentaBancaria").empty();
    var nMonto = montoAutorizado - totalMontoComprometido;

    if (montoAutorizado == totalMontoComprometido) {
        $("#alertMonto").html('<div class="alert alert-danger" role="alert"><strong>Advertencia! </strong> Se asignó la cantidad total del Monto presupuestado autorizado </div >');

    }else if(nMonto > 0) {
        $("#MontoComprometido").attr({
            'value': nMonto,
            'max': nMonto
        });
        $(".modal-title").html("Presupuesto");
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
        mensajeGenerico("Aviso", "Ingrese una cantidad igual o menor a la del " + (saldo < value ? "saldo presupuestado autorizado" : "monto solicitado"),"");
    } else if (value < totalMontoComprometido) {
        $(".new-liquidez, #btnAutoriza").attr('disabled', 'disabled');

        if (value === "" || value === "0") {
            mensajeGenerico("Aviso", "No se ha capturado el monto presupuestado autorizado", "");
            return false;
        }
        $(".new-liquidez, #btnAutoriza").attr('disabled', 'disabled');
        mensajeGenerico("Aviso", "El Monto presupuestado autorizado <strong> $" + parseFloat(value) + "</strong> no puede ser menor al total del monto comprometido <strong> $" + totalMontoComprometido + "</strong>.", "");

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
        $("#NombreCuenta").val(data.NombreCuenta);
        var MontoDisponible = new Number(data.MontoDisponible).toLocaleString("en-US");
        $("#SaldoCuenta").val(MontoDisponible);

        $.get("/AsignacionPresupuestos/GetNombreBanco_x_IdBanco", { idBanco: data.IdBanco }, function (data) {
            $("#Banco").val(data);
        });
    });
});

$("#form-Liquidez").on("submit", function (e) {
    e.preventDefault();
    $("#SaldoCuenta").val().replace(/\,/g,'');
    var form = $("#form-Liquidez");
    var tipo = $("#form-Liquidez input[type=submit]").prop("value");
    $.ajaxSetup({
        beforeSend: function () {
            $(".btn").attr('disabled', 'disabled');

        },
        complete: function () {
            $(".btn").removeAttr('disabled');
        }
    });
    if (tipo === "Guardar") {
        var saldoCuenta = parseFloat(numeral($("#SaldoCuenta").val())["_value"]);
        var MontoComprometido = parseFloat(numeral($("#MontoComprometido").val())["_value"]);

        if (saldoCuenta > MontoComprometido) {

            $.post("/AsignacionPresupuestos/saveLiquidez", form.serialize(), "JSON")
                .done(function (data) {
                    if (data.success) {
                        $("#LiquidezModal").modal('hide');
                        $("#section__liquidez").load(" #section__liquidez");
                    } else
                        mensajeGenerico("Liquidez", data.objeto, "");

                })
                .fail(function (data) {
                    mensajeGenerico("Liquidez", "No se ha podido procesar la solicitud", "");
                    $("#LiquidezModal").modal('hide');
                });
        } else
            mensajeGenerico("Liquidez", "El saldo de la cuenta no puede ser menor al monto comprometido", "");
        
    } else if (tipo == "Editar") {
        $.post("/AsignacionPresupuestos/UpdateRequisicionLiquidez", form.serialize(), "JSON")
            .done(function (data) {
                if (data.success) {
                    $("#LiquidezModal").modal('hide');
                    $("#section__liquidez").load(" #section__liquidez");
                } else
                    mensajeGenerico("Aviso", data.objeto, "");        
            })
            .fail(function (data) {
                mensajeGenerico("Aviso", "No se ha podido procesar la solicitud", "");
                $("#LiquidezModal").modal('hide');

            });
    }




});

function confirmar(value) {
    bootbox.confirm({
        title: "Confirmar solicitud",
        message: "¿Desea " + (value === true ? "autorizar" : "rechazar") + " presupuesto con el monto de $" + $("#MontoPresupuestadoAutorizado").val() + " ?",
        size: "small",
        callback: function (res) {
            if (res)
                //traerTokenCapturaRecepcionPedido("Introduce token", validarTokenGenerico, savePresupuestoLiquidez, value);      
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: savePresupuestoLiquidez, b: value })
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function savePresupuestoLiquidez(value) {

    var montoAutorizado = numeral($("#MontoPresupuestadoAutorizado").val())["_value"];
    var montoSolicitado = numeral($("#MontoSolicitado").val())["_value"];
    var totalMontoComprometido = numeral($("#totalMontoComprometido").val())["_value"];
    var nMonto = montoAutorizado - totalMontoComprometido;
    var IdPerfil = $("#IdPerfil").val();

    var response = false;

    switch (IdPerfil) {
        case "2":
            if (value) {
                response = true;

                if (montoAutorizado == totalMontoComprometido && (montoAutorizado <= montoSolicitado)) {
                    var parametros = {
                        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                        IdRequisicion: $("#IdRequisicion").val(),
                        MontoAproximadoAutorizado: numeral($("#MontoPresupuestadoAutorizado").val())["_value"],
                        SaldoPartida: $("#saldo").val(),
                        IdEstatusRequisicion: 30
                    };
                } else {
                    response = false;
                    mensajeGenerico("Aviso", "<strong>Advertencia! </strong> Falta por asignar la cantidad total de $" + nMonto + " del Monto presupuestado autorizado", "1");
                }
            } else {
                response = true;
                parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    IdRequisicion: $("#IdRequisicion").val(),
                    IdEstatusRequisicion: 20
                };
            }
            break;
        case "6":
            if (value) {
                response = true;
                parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    IdRequisicion: $("#IdRequisicion").val(),
                    IdEstatusRequisicion: 50
                };
            } else {
                response = true;
                parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    IdRequisicion: $("#IdRequisicion").val(),
                    IdEstatusRequisicion: 40
                };
            }
            break;
        case "4":
            if (value) {
                response = true;
                parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    IdRequisicion: $("#IdRequisicion").val(),
                    IdEstatusRequisicion: 70
                };
            } else {
                response = true;
                parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    IdRequisicion: $("#IdRequisicion").val(),
                    IdEstatusRequisicion: 75
                };
            }
            break;
    }
    if (response) {

        $.post("/AsignacionPresupuestos/Confirmar", parametros, "JSON")
            .done(function (data) {
                if (data.success) {
                    mensajeGenerico("Aviso", "El presupuesto ha sido " + (value === true ? "autorizado" : "rechazado") , "1");
                }
                else {
                    mensajeGenerico("Aviso", data.mensaje, "1");
                }
            })
            .fail(function (jqxhr, ErrorTextStatus, status) {
                mensajeGenerico("Aviso", `Error: ${jqxhr.message} ${ErrorTextStatus} ${status}`, "");
            })
            .always(function (data) {
                $("#LiquidezModal").modal('hide');
                $("#controls__Confirmar").load(" #controls__Confirmar");
            });
    }

}

function delete__item(IdRequisicionLiquidez) {
    bootbox.confirm({
        title: "Aviso",
        message: "¿Desea eliminar esta cuenta?",
        size: 'small',
        callback: function (res) {
            if (res) {
                var parametros = {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    idRequisicionLiquidez: IdRequisicionLiquidez
                };

                $.post("/AsignacionPresupuestos/DeleteRequisicionLiquidez", parametros, "JSON")
                    .done(function (data) {
                        $("#section__liquidez").load(" #section__liquidez");
                    })
                    .fail(function (data) {
                        alert("No se ha podido procesar la solicitud");
                    });
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}

function EditModal(IdRequisicionLiquidez) {

    var parametros = {
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
        idRequisicionLiquidez: IdRequisicionLiquidez
    };

    $.post("/AsignacionPresupuestos/TraerRequisicionLiquidez", parametros, "JSON")
        .done(function (data) {

            $("#IdOrigenRecurso").val(data.mensaje.IdOrigenRecurso);
            $("#NumeroOperacion").val(data.mensaje.NumeroOperacion);
            $("#MontoComprometido").val(data.mensaje.MontoComprometido);
            $("#IdRequisicionLiquidez").val(data.mensaje.IdRequisicionLiquidez);

            var IdCuentaBancaria = data.mensaje.IdCuentaBancaria;
            var montoAutorizado = parseFloat(numeral($("#MontoPresupuestadoAutorizado").val())["_value"]);
            var totalMontoComprometido = parseFloat($("#totalMontoComprometido").val());
            var nMonto = montoAutorizado - totalMontoComprometido;
            var rest = data.mensaje.MontoComprometido - nMonto;
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
                    if (campoId == IdCuentaBancaria) {
                        $("#IdcuentaBancaria").append("<option selected='selected' value='" + campoId + "'>" + campoA + "</option>");
                        $("#NombreCuenta").val(row["NombreCuenta"]);
                        $("#MontoComprometido").attr('max', rest);
                        $("#SaldoCuenta").val(row["MontoDisponible"]);
                    } else
                        $("#IdcuentaBancaria").append("<option value='" + campoId + "'>" + campoA + "</option>");
                });
            });

            $(".modal-title").html("Editar");
            $("#form-Liquidez :input[type=submit]").val("Editar");
            $("#LiquidezModal").modal('show');
        })
        .fail(function (data) {
            alert("No se ha podido procesar la solicitud");
        });

}