$(document).ready(function () {

    $("#mydiv").addClass("disabledbutton");
    $("#Formulario").val("DatosGenerales");

    $('.nav li a').click(function (e) {
        var i = $(this).attr('id');
        var IdRequisicionCompraMenor_ = $("#IdCompramenor_").val();
        var IdEstatusCM = $("#IdEstatusCM").val();


        //desbloquea tabs
        if (IdEstatusCM == 10) {
            switch (i) {
                case "div_lotesTabPadre":
                case "DatosGeneralesTabPadre":
                    $("#btnSave").addClass("disabledbutton");
                    $("#btn_terminar").addClass("disabledbutton");
                    break;
                default:
                    $("#btnSave").removeClass("disabledbutton");
                    $("#btn_terminar").removeClass("disabledbutton");
                    break;
            }

        }
        else if (IdEstatusCM == 15) {
            $("#btnSave").addClass("disabledbutton");
            $("#btn_terminar").addClass("disabledbutton");
        }
        else {
            switch (i) {

                case "div_condiciones_entrega_pagoTabPadre":
                    $("#btnSave").removeClass("disabledbutton");
                    $("#btn_terminar").removeClass("disabledbutton");
                    break;
                default:
                    if (IdRequisicionCompraMenor_ == 0) {
                        $("#btnSave").removeClass("disabledbutton");
                        $("#btn_terminar").addClass("disabledbutton");
                    }
                    else {
                        $("#btnSave").removeClass("disabledbutton");
                        $("#btn_terminar").removeClass("disabledbutton");
                    }
                    break;
            }
        }
        
        $("#Formulario").val(i);
    });

    $('#tablaRequisiconComprasMenores').DataTable({
        scrollX: true
    });

    if ($("#IdCompramenor_").val() != 0)
        TraerRequisicionCM($("#IdCompramenor_").val());

    $("#FechaEntrega, #FechaPago").datetimepicker({
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

function getAllPartida_x_IdCapitulo(IdCapitulo,IdPartida) {
    //definimos si hay argumentos enviados para asignar valor directo
    if (IdCapitulo === undefined)
        IdCapitulo = $("#IdCapitulo").val();
    
    if (IdPartida === undefined) 
        IdPartida = "";
    
    var parametros = {
        pIdCapitulo: IdCapitulo,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/GetAllPartidas_x_IdCapitulo/',
        type: 'post',
        success: function (response) {
            if (response.success) {
                //variable para seleccionar partida actual
                var selected = "";
                $("#IdPartida").html("<option>Seleccione Partida</option>");
                $.each(response.objeto, function (rowIndex, r) {
  
                    var campoId = r["IdPartida"];
                    var campoA = r["Partida"];
                    if (IdPartida == campoId)
                        selected = "selected";
                    else
                        selected = "";
                    
                    $("#IdPartida").append('<option ' + selected + ' value=' + campoId + '>' + campoA + '</option>');
                });          
            }
            else
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');           
        }
    });
}

function checkMonto(value) {
    $.post("/RequisicionesComprasMenores/GetMonto/", { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: value }, "JSON")
        .always(function (data) {
            if (data.mensaje === 0 || !data.success) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: "La partida no cuenta con saldo",
                    callback: function () {
                        $("#btnSave").attr("disabled", "disabled");
                        $("#SaldoPartida").val("0");
                    }
                });
            } else {
                $("#btnSave").removeAttr("disabled");
                $("#SaldoPartida").val(data.mensaje);
            }
        });
}

function validarFormulario() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser numérico.';
    jQuery.validator.messages.email = 'La dirección de correo es incorrecta.';
    var form = $("#Formulario").val();
    form = form.replace("TabPadre", "");
    var validado = $("#" + form + "Form").valid();
    //var validado = $("#DatosGeneralesForm").valid();
    if (validado) {
        if (form == 'DatosGenerales') {
            if ( $("#IdRequisicionCompraMenor").val() == 0)
                validarForm();
            else
                EditaRequisicionCM();           
        }
        if (form == "div_condiciones_entrega_pago")
            EditaReqCMEntregaConfirm();
    }
}
function EditaReqCMEntregaConfirm() {
    bootbox.confirm({
        title: "Aviso",
        message: "¿Desea guardar condición de entrega?",
        size: "small",
        callback: function (res) {
            if (res) {
                EditaReqCMEntrega();
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function validarForm() {
    bootbox.confirm({
        title: "Aviso",
        message: "¿Desea guardar compra menor?",
        size: "small",
        callback: function (res) {
            if (res) {
                NuevaRequisicionCM();
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function NuevaRequisicionCM() {
    var parametros = {
        IdRequisicionCompraMenor: 0,
        IdDepartamento: $("#IdDepartamento").val(),
        IdOrigenRecurso: $("#IdOrigenRecurso").val(),
        IdPartida: $("#IdPartida").val(),
        IdEjercicioFiscal: $("#IdEjercicioFiscal").val(),
        IdTipoSolicitud: $("#IdTipoSolicitud").val(),
        Observaciones: $("#Observaciones").val(),
        Justificacion: $("#Justificacion").val(),
        IdProveedor: $("#IdProveedor").val(),
        SaldoPartida: $("#SaldoPartida").val(),
        __RequestVerificationToken:$("[name='__RequestVerificationToken']").val() 
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/GuardarRequisicionesCM/',
        type: 'post',
        success: function (response) {
            if (response.success) {
                TraerRequisicionCM(response.idComprasMenores);
                mensajeGenerico("Aviso", "Se ha enviado la solicitud número " + response.folio + " correctamente, para la autorización de presupuesto y liquidez, a partir de este momento cuenta con 24 horas para recibir una respuesta y pueda continuar con la captura de la solicitud", "");
                //listacomprasmenores("/RequisicionesComprasMenoresConsulta/");
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
            }
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' +  + '</div >');
        }
    });
}

function retornarPagina() {
    location.href = "/RequisicionesComprasMenores/Index";
}

function returnToIndex() {
    location.href = "/RequisicionesComprasMenoresConsulta/Index";
}

/*
function editCompramenor(IdCompramenor) {
    //var url = '@Url.Action("Index","RequisicionesComprasMenores", new {IdCompramenor="xxxx"})';
    //url = url.replace("IdCompramenor", IdCompramenor);
    ////listacomprasmenores(url);
    //window.open(url, "blank");
    window.location.href = "@(Url.RouteUrl('SurveyWelcomeRoute', new { id = Model.CampaignGuid, languageName = UrlParameter.Optional }))/" + 1
}*/

function EditaRequisicionCM() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicionCompraMenor = $("#IdRequisicionCompraMenor").val();
    var parametros = {
        IdRequisicionCompraMenor: $("#IdRequisicionCompraMenor").val(),
        IdDependencia: 0,//IdDependencia del usuario logueado
        IdDepartamento: $("#IdDepartamento").val(),
        IdOrigenRecurso: $("#IdOrigenRecurso").val(),
        IdEstatusCM: 10,
        IdPartida: $("#IdPartida").val(),
        IdEjercicioFiscal: $("#IdEjercicioFiscal").val(),
        IdTipoSolicitud: $("#IdTipoSolicitud").val(),
        IdPresupuesto: 2,
        FechaRequisicion: "", //Date.Now 
        RequisicionFolio: 0,
        ConsecutivoRequisicion: 0,
        MontoAproximado: 0,
        CantidadLotes: 0,
        ImporteTotalLotes: 0,
        Observaciones: $("#Observaciones").val(),
        Justificacion: $("#Justificacion").val(),
        FechaEntrega: "", //Date.Now 
        IdLugarEntrega: 0,
        FechaPago: "", //Date.Now 
        IdLugarPago: 0,
        SaldoPartida: 0,
        MontoPresupuestado: 0,
        IdUsuarioAutoriza: 0,
        IdProveedor: $("#IdProveedor").val(),
        Economia: 0,
        Ejercido: 0,
        IdUsuarioRegistro: 0,//IdUsuario Session
        FechaRegistro: "", //Date.Now 
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/EditarRequisicionesCM/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                TraerRequisicionCM(IdRequisicionCompraMenor);
                //listacomprasmenores("/RequisicionesComprasMenoresConsulta/");
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function EditaReqCMEntrega() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicionCompraMenor = $("#IdRequisicionCompraMenor").val();
    var parametros = {
        IdRequisicionCompraMenor: $("#IdRequisicionCompraMenor").val(),
        IdDependencia: 0,//IdDependencia del usuario logueado
        IdDepartamento: $("#IdDepartamento").val(),
        IdOrigenRecurso: $("#IdOrigenRecurso").val(),
        IdEstatusCM: 10,
        IdPartida: $("#IdPartida").val(),
        IdEjercicioFiscal: $("#IdEjercicioFiscal").val(),
        IdTipoSolicitud: $("#IdTipoSolicitud").val(),
        IdPresupuesto: 2,
        FechaRequisicion: "", //Date.Now 
        RequisicionFolio: 0,
        ConsecutivoRequisicion: 0,
        MontoAproximado: 0,
        CantidadLotes: 0,
        ImporteTotalLotes: 0,
        Observaciones: $("#Observaciones").val(),
        Justificacion: $("#Justificacion").val(),
        FechaEntrega: $("#FechaEntrega").val(),
        IdLugarEntrega: $("#IdLugarEntrega").val(),
        FechaPago: $("#FechaPago").val(), 
        IdLugarPago: $("#IdLugarPago").val(),
        SaldoPartida: 0,
        MontoPresupuestado: 0,
        IdUsuarioAutoriza: 0,
        IdProveedor: $("#IdProveedor").val(),
        Economia: 0,
        Ejercido: 0,
        IdUsuarioRegistro: 0,//IdUsuario Session
        FechaRegistro: "", //Date.Now 
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/EditarReqCMEntrega/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                TraerRequisicionCM(IdRequisicionCompraMenor);
                mensajeGenerico("Aviso","Condición de entrega guardado correctamente.");
                //listacomprasmenores("/RequisicionesComprasMenoresConsulta/");
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function tokenTerminarReqCM(){
    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: TerminarReqCM, b: undefined })
}
function TerminarReqCM() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicionCompraMenor = $("#IdRequisicionCompraMenor").val();
    var parametros = {
        IdRequisicionCompraMenor: $("#IdRequisicionCompraMenor").val(),
        IdDependencia: 0,//IdDependencia del usuario logueado
        IdDepartamento: $("#IdDepartamento").val(),
        IdOrigenRecurso: $("#IdOrigenRecurso").val(),
        IdEstatusCM: 15,  //cambiamos el idEstatusCM por 11 = terminado
        IdPartida: $("#IdPartida").val(),
        IdEjercicioFiscal: $("#IdEjercicioFiscal").val(),
        IdTipoSolicitud: $("#IdTipoSolicitud").val(),
        IdPresupuesto: 2,
        FechaRequisicion: "", //Date.Now 
        RequisicionFolio: 0,
        ConsecutivoRequisicion: 0,
        MontoAproximado: 0,
        CantidadLotes: 0,
        ImporteTotalLotes: 0,
        Observaciones: $("#Observaciones").val(),
        Justificacion: $("#Justificacion").val(),
        FechaEntrega: $("#FechaEntrega").val(),
        IdLugarEntrega: $("#IdLugarEntrega").val(),
        FechaPago: $("#FechaPago").val(),
        IdLugarPago: $("#IdLugarPago").val(),
        SaldoPartida: 0,
        MontoPresupuestado: 0,
        IdUsuarioAutoriza: 0,
        IdProveedor: $("#IdProveedor").val(),
        Economia: 0,
        Ejercido: 0,
        IdUsuarioRegistro: 0,//IdUsuario Session
        FechaRegistro: "", //Date.Now 
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/TerminarReqCM/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                //TraerRequisicionCM(IdRequisicionCompraMenor)
                mensajeGenericoConCallBack("Aviso", "Proceso terminado correctamente", "2", TraerRequisicionCM, IdRequisicionCompraMenor);
                //listacomprasmenores("/RequisicionesComprasMenoresConsulta/");
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Aviso",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function TraerRequisicionCM(IdReqCM) {
    
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdReqCM: IdReqCM,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/TraerRequisicionesCM/',
        type: 'post',
        beforeSend: function () {
            
        },
        success: function (response) {
            if (response.success) {
                var objeto = response.objeto;
                
                var FechaEntrega = getFechaJSON(objeto.FechaEntrega);
                var FechaPago = getFechaJSON(objeto.FechaPago);

                $("#IdTipoSolicitud").val(objeto.IdTipoSolicitud);
                $("#IdDepartamento").val(objeto.IdDepartamento);
                $("#IdOrigenRecurso").val(objeto.IdOrigenRecurso);
                $("#OrigenRecurso").val(objeto.OrigenRecurso);
                $("#IdCapitulo").val(objeto.IdCapitulo);
                $("#RequisicionFolio").val(objeto.RequisicionFolio);
                $("#IdRequisicionCompraMenor").val(objeto.IdRequisicionCompraMenor);
                getAllPartida_x_IdCapitulo(objeto.IdCapitulo, objeto.IdPartida);
                $("#Observaciones").val(objeto.Observaciones);
                $("#Justificacion").val(objeto.Justificacion);
                $("#IdProveedor").val(objeto.IdProveedor);             
                $("#FechaEntrega").val(FechaEntrega);
                $("#IdLugarEntrega").val(objeto.IdLugarEntrega);
                $("#FechaPago").val(FechaPago);
                $("#IdLugarPago").val(objeto.IdLugarPago);
                $("#IdEstatusCM").val(objeto.IdEstatusCM);


                //desbloquea tabs
                if (objeto.IdEstatusCM == 10) {
                    var IdRequisicionCompraMenor_ = $("#IdRequisicionCompraMenor").val();
                    $("#div_lotesTabPadre").removeClass("disabledbutton");
                    $("#div_condiciones_entrega_pagoTabPadre").removeClass("disabledbutton");

                    var form = $("#Formulario").val();

                    switch (form) {
                        case "div_lotes":
                        case "DatosGenerales":
                            $("#btnSave").addClass("disabledbutton");
                            $("#btn_terminar").addClass("disabledbutton");
                            break;
                        case "div_condiciones_entrega_pagoTabPadre":
                            $("#btnSave").removeClass("disabledbutton");
                            $("#btn_terminar").removeClass("disabledbutton");
                            break;
                    }


                    $("#DatosGeneralesDiv").addClass("disabledbutton");

                }
                else {
                    $("#lotesDiv").addClass("disabledbutton");
                    $("#condicionEntregaDiv").addClass("disabledbutton");
                    $("#btn_terminar").addClass("disabledbutton");
                    $("#btnSave").addClass("disabledbutton");
                    $("#DatosGeneralesDiv").addClass("disabledbutton");
                }
                
                
                getAllLotes_x_IdReqCM(objeto.IdRequisicionCompraMenor);
                
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function getFechaJSON(objson){
    var Fecha = (new Date(parseInt(objson.substr(6)))).toJSON();
    var date = new Date(Fecha);
    var fechaFormateada = (date.getFullYear() + '-' + padzero((date.getMonth() + 1),2) + '-' + padzero(date.getDate(),2) );

    return fechaFormateada;
}

function padzero(str, max) {
    str = str.toString();
    return str.length < max ? padzero("0" + str, max) : str;
}

function NuevaReqCMLote() {
    var IdRequisicionCompraMenor = $("#IdRequisicionCompraMenor").val();
    var parametros = {
        IdRequisicionCompraMenor: $("#IdRequisicionCompraMenor").val(),
        IdBienServicio: 0,
        Concepto: $("#Concepto").val(),
        IdTipoBienServicio: $("#IdTipoSolicitud").val(),
        Cantidad: $("#Cantidad").val(),
        PrecioUnitario: $("#PrecioUnitario").val(),
        Importe: 0,
        PorcentajeImpuesto: 0,
        ImporteImpuesto: 0,
        Total: 0,
        TotalFinal: $("#total").val(),
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/GuardarReqCMLote/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                getAllLotes_x_IdReqCM(IdRequisicionCompraMenor);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function EditaReqCMLote() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdRequisicionCompraMenor = $("#IdRequisicionCompraMenor").val();
    var parametros = {
        IdLoteCompraMenor: $("#IdLoteCompraMenor").val(),
        IdRequisicionCompraMenor: $("#IdRequisicionCompraMenor").val(),
        NoLote: 0,
        IdBienServicio: 0,
        Concepto: $("#Concepto").val(),
        IdTipoBienServicio: $("#IdTipoSolicitud").val(),
        Cantidad: $("#Cantidad").val(),
        PrecioUnitario: $("#PrecioUnitario").val(),
        Importe: 0,
        PorcentajeImpuesto: 0,
        ImporteImpuesto: 0,
        Total: 0,
        TotalFinal: $("#total").val(),
        FechaRegistro: "", //Date.Now 
        IdUsuarioRegistro: 0,//IdUsuario Session

        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/EditarReqCMLote/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                getAllLotes_x_IdReqCM(IdRequisicionCompraMenor);
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function GuardaReqCMLote() {
    var IdLoteCompraMenor = $("#IdLoteCompraMenor").val();

    if (IdLoteCompraMenor == 0) {
        //es un nuevo lote
        NuevaReqCMLote();
    } else {
        //es un lote existente
        EditaReqCMLote();
    }
}

function TraerLoteCM(IdLoteCM) {
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdLoteCM: IdLoteCM,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/TraerLotesCM/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                var objeto = response.objeto;
                $("#IdTipoSolicitud").val(objeto.IdTipoBienServicio);
                $("#IdLoteCompraMenor").val(objeto.IdLoteCompraMenor);
                $("#IdRequisicionCompraMenor").val(objeto.IdRequisicionCompraMenor);
                $("#Concepto").val(objeto.Concepto);
                $("#Cantidad").val(objeto.Cantidad);
                $("#PrecioUnitario").val(objeto.PrecioUnitario);

                
            }
            else {
                bootbox.alert({
                    size: "small",
                    title: "Error",
                    message: response.mensaje
                });
                //$("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }
        }
    });
}

function MuestraLoteCM(IdLoteCM) {
    if (IdLoteCM === undefined) {
        //es nuevo lote
        $("#IdLoteCompraMenor").val('0');
        $("#Concepto").val('');
        $("#Cantidad").val('');
        $("#PrecioUnitario").val('');
    } else {
        //es un lote existente
        TraerLoteCM(IdLoteCM);
    }
}

function BorraReqCMLote(IdLote) {

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea eliminar el lote?",
        callback: function (e) {
            if (e) {
                var IdRequisicionCompraMenor = $("#IdRequisicionCompraMenor").val();
                var parametros = {
                    IdLote: IdLote,
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
                };

                $.ajax({
                    data: parametros,
                    url: '/RequisicionesComprasMenores/EliminarLote/',
                    type: 'POST',
                    success: function (response) {
                        if (response.success)
                            getAllLotes_x_IdReqCM(IdRequisicionCompraMenor);
                        else
                            $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
                    }
                });
            }
        }
    });
}

function getAllLotes_x_IdReqCM(IdReqCM) {

    //$('#TableLotes').dataTable().fnDestroy();
    //$('#TableLotes tbody').empty();

    //var parametros = {
    //    pIdLoteCompraMenor: IdReqCM,
    //    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    //};

    //$("#TableLotes").DataTable({
        
    //    ajax: {
    //        url: '/RequisicionesComprasMenores/GetAllLotes_xIdLoteCompraMenor/',
    //        data: parametros,
    //        type: 'post',
    //        dataType: "JSON"
    //    },
    //    columns: [
    //        {
    //            mRender: function (data, type, row) {
    //                return '<div class="form-group" style="min-width:100px;text-align:center;"><a style="margin-right:3px;" title="Eliminar registro" class="btn btn-secondary btn-sm" onclick="BorraReqCMLote(' + row.IdLote + ')" > <span class="icon-garbage-2"></span></a><a title="Editar registro" class="btn btn-secondary btn-sm" data-toggle="modal" data-target="#modal_nuevo_lote" onclick="MuestraLoteCM(' + row.IdLote + ')"><span class="icon-edit"></span></a></div >';
    //            }
    //        },
    //        { "data": "NoLote"},
    //        { "data": "Cantidad"},
    //        { "data": "Concepto"},
    //        { "data": "PrecioUnitario"},
    //        { "data": "Importe"},
    //        { "data": "PorcentajeImpuesto"},
    //        { "data": "ImporteImpuesto"}

    //    ]

    //});
    
    var parametros = {
        pIdLoteCompraMenor: IdReqCM,
        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        data: parametros,
        url: '/RequisicionesComprasMenores/GetAllLotes_xIdLoteCompraMenor/',
        type: 'post',
        success: function (response) {
            if (response.success) {
                var informacion = response.data;

                //variable para seleccionar partida actual
                
                $("#tabla_lotes").html("");

                var importetotal = 0;
                var ivatotal = 0;
                var totalFinal = 0;
                $.each(informacion, function (rowIndex, row) {

                    var IdLote = row["IdLoteCompraMenor"];
                    var Lote = row["NoLote"];
                    var Cantidad = row["Cantidad"];
                    var Concepto = row["Concepto"];
                    var PrecioUnitario = row["PrecioUnitario"];
                    var Importe = row["Importe"];
                    var PorcentajeImpuesto = row["PorcentajeImpuesto"];
                    var ImporteImpuesto = row["ImporteImpuesto"];
                    var Total = row["Total"];

                    importetotal =importetotal+Importe;
                    ivatotal =ivatotal+ImporteImpuesto;
                    totalFinal =totalFinal+Total;

                    var texto = '<tr style="text-align:center">' +
                        '<td style="min-width:100px;">' +                        
                        '<button style="margin:1px;" type="button" class="btn btn-secondary btn-sm" onclick="BorraReqCMLote(' + IdLote + ')"><span class="icon-garbage-2"></span></button>' +
                        '<button style="margin:1px;" type="button" class="btn btn-secondary btn-circle btn-sm" data-toggle="modal" data-target="#modal_nuevo_lote" onclick="MuestraLoteCM(' + IdLote + ')"><span class="icon-edit"></span></button>' +
                        '</td>' +
                        '<td>' + Lote + '</td>' +
                        '<td>' + Cantidad + '</td>' +
                        '<td>' + Concepto + '</td>' +
                        '<td> $' + PrecioUnitario.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td>' +
                        '<td> $' + Importe.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td>' +
                        '<td>' + PorcentajeImpuesto + '% </td>' +
                        '<td> $' + ImporteImpuesto.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td>' +
                        '</tr>';                      
                     
                    $("#tabla_lotes").append(texto);
                });


                //colocamos los totales
                var texto =
                    '<tr><td colspan="7" style="text-align: right;">IMPORTE</td>' +
                    '<td style="text-align:center"> $' + importetotal.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td>' +
                    '</tr><tr><td colspan="7" style="text-align: right;">IVA</td>' +
                    '<td style="text-align:center"> $' + ivatotal.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td>' +
                    '</tr><tr><td colspan="7" style="text-align: right;">TOTAL</td>' +
                    '<td style="text-align:center"> $' + totalFinal.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td>' +
                    '</tr>';
                $("#tabla_lotes").append(texto);
            }
            else
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
        }
    });

}
