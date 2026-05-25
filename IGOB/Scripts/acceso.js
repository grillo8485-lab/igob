function mensajeGenerico(title_, mensaje_, url_ = "") {

    bootbox.alert({
        message: "<div class='col-12' style=' color: black'>" + mensaje_ + "<div>",
        //message: "<div class='col-12' style=' color: #adcb60'>" + mensaje_ + "<div>",
        size: 'small',
        title: "<div class='col-12 text-center'>" + title_ + "<div>",
        closeButton: false,
        callback: function () {
            if (url_ != "") {
                if (url_ == "1") {
                    location.reload()
                }
                else {
                    location.href = url_
                }

            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function mensajeGenericoConCallBack(title_, mensaje_, url_ = "",CallBack,Parametro) {

    bootbox.alert({
        message: "<div class='col-12' style=' color: black'>" + mensaje_ + "<div>",
        size: 'small',
        title: "<div class='col-12 text-center'>" + title_ + "<div>",
        closeButton: false,
        callback: function () {
            if (url_ != "") {
                switch (url_) {
                    case "1":
                        location.reload()
                        break;
                    case "2":
                        if (typeof Parametro === 'undefined') {
                            CallBack();
                        }
                        else {
                            CallBack(Parametro);
                        }
                        
                        break;
                    default:
                        location.href = url_
                        break;
                }
                

            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function confirmGenerico( message_, CallBack,activarCallbackCancel,parametro) {
    bootbox.confirm({
        title: "Aviso",
        message: message_,
        size: "small",
        closeButton: false,
        buttons: {
            confirm: {
                label: 'SI',
               
            },
            cancel: {
                label: 'No',
                
            }
        },
        callback: function (res) {
            if (res) {
                if (typeof parametro.b === 'undefined') {
                    CallBack();
                }
                else {
                    if (parametro.b == 0) {
                        parametro.b = res
                        CallBack(parametro);
                    }
                    else {
                        CallBack(parametro);
                    }
                }
            }
            else {
                if (activarCallbackCancel) {
                    if (typeof parametro.b === 'undefined') {
                        CallBack();
                    }
                    else {
                        if (parametro.b == 0) {
                            parametro.b = res
                            CallBack(parametro);
                        }
                        else {
                            CallBack(parametro);
                        }
                    }
                }
                else {

                }
            }
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function traerTokenCapturaRecepcionPedido(title = "Introduce token", CallBack, CallBackPersonalizado, b) {
    var displayButton = "hide";
    bootbox.prompt({
        title: "<div class='col-12 text-center'>" + title + "<div>",
        size: 'small',
        closeButton: false,
        onEscape: false,
        buttons: {
            cancel: {
                className: displayButton
            },
            confirm: {
                label: 'Aceptar'
            }
        },
        callback: function (result) {
            if (result.length === 0 || result === null) {
                mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12">' + "Debe capturar token para poder continuar" + '</div>', "");
            }
            else {
                CallBack(result, CallBackPersonalizado, b);
            }
                
        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function traerTokenCapturaGenerico(parametro) {
    //title = "Introduce token", CallBack, CallBackPersonalizado, b
    var displayButton = "hide";
    bootbox.prompt({
        title: "<div class='col-12 text-center'>" + parametro.title + "<div>",
        size: 'small',
        closeButton: false,
        onEscape: false,
        buttons: {
            cancel: {
                className: displayButton
            },
            confirm: {
                label: 'Aceptar'
            }
        },
        callback: function (result) {
            if (result.length === 0 || result === null) {
                mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12">' + "Debe capturar token para poder continuar" + '</div>', "");
            }
            else {
                parametro.CallBack(result, parametro.CallBackPersonalizado, parametro.b);
            }

        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function introducirNumeroToken(parametro) {
    //title = "Introduce token", CallBack, CallBackPersonalizado, b
    var displayButton = "hide";
    bootbox.prompt({
        title: "<div class='col-12 text-center'>" + parametro.title + "<div>",
        size: 'small',
        closeButton: false,
        onEscape: false,
        buttons: {
            cancel: {
                className: displayButton
            },
            confirm: {
                label: 'Aceptar'
            }
        },
        callback: function (result) {
            if (result.length === 0 || result === null) {
                mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12">' + "Debe capturar token para poder continuar" + '</div>', "");
            }
            else {
                parametro.CallBack(result, parametro.CallBackPersonalizado, parametro.b);
            }

        }
    }).find('.modal-dialog').addClass("modal-dialog-centered");
}
function validarAccesoSistema() {
    $("#ErrorMSG").html('');
    var token = $("[name='__RequestVerificationToken']").val();
    var Usuario = $("#Usuario").val();
    var Password = $("#Password").val();
    var FormAcces = FormAcces
    var dataWithAntiforgeryToken = $.extend({ 'Usuario': Usuario }, { 'password': Password }, { '__RequestVerificationToken': token });
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Home/Login/',
        data: dataWithAntiforgeryToken,

        success: function (response) {
            if (response.success) {
                traerTokenCapturaRecepcionPedido("Introduce token", validarToken);
            }
            else {
                if (response.idError == 4) {
                    confirmGenerico('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + "<br>¿Desea desbloquear usuario?</div>", introducirNumeroToken, false, { title: "Introduce serial del token", CallBack: validarNumeroToken, CallBackPersonalizado: traerTokenCapturaRecepcionPedido, b: "-----" })
                }
                else {
                    $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>');
                }
                
            }
        },
        failure: function (response) {
            $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');

        },
        error: function (response) {
            $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');

        }

    });
}
function validarToken(tokenValido) {
    $("#ErrorMSG").html('');
    var token = $("[name='__RequestVerificationToken']").val();

    var attemptResponseCode = $("#attemptResponseCode").val();

    var dataWithAntiforgeryToken = $.extend({ 'tokenValido': tokenValido }, { 'attemptResponseCode': attemptResponseCode }, { '__RequestVerificationToken': token });
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Home/validarToken/',
        data: dataWithAntiforgeryToken,

        success: function (response) {
            switch (response.success) {
                case 0:
                case 100:
                    $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>');
                    $("#attemptResponseCode").val(response.attemptResponseCode)
                    break;
                case 1:
                    //mensajeGenerico("Aviso", "Acceso correcto", "/Home/accesoValido/");
                    location.href = '/Home/accesoValido/';
                    $("#attemptResponseCode").val("")
                    break;
                case 3:
                case 4:
                    traerTokenCapturaRecepcionPedido(response.mensaje, validarToken)
                    $("#attemptResponseCode").val(response.attemptResponseCode)
                    $("#authnAttemptId").val(response.authnAttemptId)

                    break;
                case 99:
                    mensajeGenerico("Aviso", response.mensaje, "/Home/Index/");
                    $("#attemptResponseCode").val(response.attemptResponseCode)
                    $("#authnAttemptId").val(response.authnAttemptId)

                    break;
            }

        },
        failure: function (response) {
            $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');

        },
        error: function (response) {
            $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');

        }

    });
}

function validarNumeroToken(numeroToken, CallBackPersonalizado, b) {
    $("#ErrorMSG").html('');
    var token = $("[name='__RequestVerificationToken']").val();

    var dataWithAntiforgeryToken = $.extend({ 'numeroToken': numeroToken }, { '__RequestVerificationToken': token });
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Home/validarNumeroToken/',
        data: dataWithAntiforgeryToken,

        success: function (response) {
            if (response.success) {
                validarAccesoSistema()
            }
            else {
                $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>');
            }
        },
        failure: function (response) {
           // mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>', "");
            $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');
        },
        error: function (response) {
            $("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');
            //mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>', "");

        }

    });
}

function validarTokenGenerico(tokenValido, CallBackPersonalizado, b) {
    $("#ErrorMSG").html('');
    var token = $("[name='__RequestVerificationToken']").val();

    var attemptResponseCode = $("#attemptResponseCode").val();

    var dataWithAntiforgeryToken = $.extend({ 'tokenValido': tokenValido }, { 'attemptResponseCode': attemptResponseCode }, { '__RequestVerificationToken': token });
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Home/validarToken/',
        data: dataWithAntiforgeryToken,

        success: function (response) {
            switch (response.success) {
                case 0:
                case 100:
                    //$("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>');
                    mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.mensaje + '</div>', "");
                    //$("#attemptResponseCode").val(response.attemptResponseCode)
                    break;
                case 1:
                    if (typeof b === 'undefined') {
                        CallBackPersonalizado();
                    }
                    else {
                        CallBackPersonalizado(b);
                    }
                    $("#attemptResponseCode").val("")
                    break;
                case 3:
                case 4:
                    traerTokenCapturaRecepcionPedido(response.mensaje, validarTokenGenerico, CallBackPersonalizado, b)
                    $("#attemptResponseCode").val(response.attemptResponseCode)
                    $("#authnAttemptId").val(response.authnAttemptId)

                    break;
                case 99:
                    mensajeGenerico("Aviso", response.mensaje, "/Home/CerrarSecision/");
                    $("#attemptResponseCode").val(response.attemptResponseCode)
                    $("#authnAttemptId").val(response.authnAttemptId)

                    break;
            }
            return response.success;
        },
        failure: function (response) {
            //$("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');
            mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>', "");

        },
        error: function (response) {
            //$("#ErrorMSG").html('<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>');
            mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>', "");

        }

    });
}
$('#submitupdate').click(function (e) {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.text = 'Este campo es obligatorio';
    $("#FormAcceso").validate({
        wrapper: 'span',
        errorPlacement: function (error, element) {
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px' });
            error.addClass("arrow")
            error.insertAfter(element);
        },
        submitHandler: function (form) {
            e.preventDefault();
            validarAccesoSistema();

        }
    });
});


function bodyUnload() {

    //                    var request = GetRequest();      
    //                    request.open("POST", "../LogOut.aspx", false);
    //                    request.send();
    //console.log("ajkshd");

    //$.ajax({
    //    dataType: 'json',
    //    type: 'POST',
    //    url: '/Home/CerrarSecisionVenta/',
    //    data: null,

    //    success: function (response) {
    //        switch (response.success) {

    //        }

    //    },
    //    failure: function (response) {

    //        mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>', "");

    //    },
    //    error: function (response) {

    //        mensajeGenerico("Aviso", '<div id="login-alert" class=" alert alert-danger col-sm-12">' + response.responseText + '</div>', "");

    //    }

    //});

}