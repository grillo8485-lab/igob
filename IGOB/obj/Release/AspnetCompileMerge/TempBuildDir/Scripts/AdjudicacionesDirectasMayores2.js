//$('#div_propuesta_tecnica').find('input, textarea, button, select').attr('disabled', 'disabled');

//$("#div_propuesta_tecnica").find(".disabledClick").css({
//    "opacity": 1,
//    "pointer-events": "initial"
//});

//$("#btnProveedorAutoriza").attr('disabled', 'disabled');

//$("#aceptar_propuestaTec").find('input').removeAttr('disabled');

//function validarCheckAceptarPropTecnica() {

//    if ($("#aceptarPropTec").is(':checked')) {
//        $("#btnProveedorAutorizaTec").removeAttr('disabled');

//        $("#IdAceptoProvBool").val("1");
//    } else {
//        $("#btnProveedorAutorizaTec").attr('disabled', 'disabled');

//        $("#IdAceptoProvBool").val("0");
//    }

//}

//function propuestaTec() {

//    bootbox.confirm({
//        size: "large",
//        title: "Enviar Propuesta Técnica",
//        message: "Desea enviar propuesta técnica para su revision? ",
//        buttons: {
//            cancel: {
//                label: '<i class="fa fa-times"></i> Cancelar'
//            },
//            confirm: {
//                label: '<i class="fa fa-check"></i> Confimar'
//            }
//        },
//        callback: function (result) {
//            if (result) {

//                var parametros = {
//                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
//                    IdAdjudicacion: $("#IdAdjudicacion").val()
//                }

//                $.post("/AdjudicacionesDirectasMayores/updateEstatusPropuestaTecnicaEconomica", parametros, "JSON")
//                    .done(function (data) {

//                        bootbox.alert({
//                            size: "small",
//                            title: "Aviso",
//                            message: data.mensaje,
//                            callback: function () {
//                                location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion
//                            }
//                        });

//                    }).fail(function (data) {

//                        console.log(data)
//                        bootbox.alert({
//                            size: "small",
//                            title: "Aviso",
//                            message: "No se ha podido enviar la propuesta técnica"
//                        });
//                    });

//            }

//        }

//    });

//}

//function propuestaEco(){

//    bootbox.confirm({
//        size: "large",
//        title: "Enviar Propuesta Económica",
//        message: "Desea enviar propuesta Económica para su revision? ",
//        buttons: {
//            cancel: {
//                label: '<i class="fa fa-times"></i> Cancelar'
//            },
//            confirm: {
//                label: '<i class="fa fa-check"></i> Confimar'
//            }
//        },
//        callback: function (result) {
//            if (result) {

//                var parametros = {
//                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
//                    IdAdjudicacion: $("#IdAdjudicacion").val()
//                }

//                $.post("/AdjudicacionesDirectasMayores/updateEstatusPropuestaTecnicaEconomica", parametros, "JSON")
//                    .done(function (data) {

//                        bootbox.alert({
//                            size: "small",
//                            title: "Aviso",
//                            message: data.mensaje,
//                            callback: function () {
//                                location.href = "/AdjudicacionConsulta/Index/" + tipoAdjudicacion
//                            }
//                        });

//                    }).fail(function (data) {
//                        bootbox.alert({
//                            size: "small",
//                            title: "Aviso",
//                            message: "No se ha podido enviar la propuesta técnica"
//                        });
//                    });
//            }
//        }
//    });

//}



