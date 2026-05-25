$(document).ready(function () {
    $("#SearchUserForm").keypress(function (e) {
        if (e.which == 13) {
            return false;
        }
    });

    $('#UsuarioTabla').DataTable({
        scrollY: "280px"
    });
});

function nuevoUsuario() {
    $(".modal-title").html("Alta Usuario");
    $("#IdBuscar__").css({ "display": "" });
    $("#usuarioPassword").css({ "display": "" });
    $("#IdGuardar__").css({ "display": "" });
    $("#Actualizar__").css({ "display": "none" });
    $("#UsuarioModal").modal("show");
}
function validarForm() {
    var Usuario = $("#Usuario").val();
    var Password = $("#Password").val();
    var IdPerfil = $("#IdPerfil").val();
    var IdPersona = $("#IdPersona").val();
    var CorreoElectronico = $("#CorreoElectronico").val();
    var Activo = $("#happy").val();

    if (Usuario == "") {
        mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12"><span class="fa fa-exclamation-triangle fa-1x"></span>Falta capturar usuario</div>', "")
        //alert("Falta Capturar Usuario");
        return;
    }
    if (Password == "") {
        mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12"><span class="fa fa-exclamation-triangle fa-1x"></span>Falta capturar contraseña</div>', "")
        //alert("Falta Capturar Contraseña");
        return;
    }
    if (IdPerfil == "") {
        mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12"><span class="fa fa-exclamation-triangle fa-1x"></span>Falta seleccionar perfil</div>', "")
        //alert("Falta Seleccionar Perfil");
        return;
    }
    if (IdPersona == "") {
        mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12"><span class="fa fa-exclamation-triangle fa-1x"></span>Falta seleccionar persona</div>', "")
        //alert("Falta Seleccionar Persona");
        return;
    }
    if (CorreoElectronico == "") {
        mensajeGenerico("Aviso", '<div id="login-alert" class="alert alert-danger col-sm-12"><span class="fa fa-exclamation-triangle fa-1x"></span>Falta Capturar Correo Electronico</div>',"")
        //alert("Falta Capturar Correo Electronico");
        return;
    }

    confirmGenerico("¿Desea guardar el usuario: " + Usuario + " ?", traerTokenCapturaGenerico, false, { title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: altaUsuario, b: "--" })
    //altaUsuario();
}

function altaUsuario() {
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        IdUsuario : 0,
        Usuario : $("#Usuario").val(),
        Password: $("#Password").val(),
        Apellidos: "",
        Nombres: "",
        IdPerfil: $("#IdPerfil").val(),
        IdEstatusUsuario : 0,
        IdDependencia : 0,
        IdProveedor :0,
        IdPersona : $("#IdPersona").val(),
        CorreoElectronico: $("#CorreoElectronico").val(),
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdUsuarioRegistro:0,
        FechaRegistro: "",
        __RequestVerificationToken: token
    };

    $.ajax({
            data:  parametros,
        url: '/Usuario/createUsuario/',
            type:  'post',
            beforeSend: function () {

            },
        success: function (response) {
            console.log(response);
                if (response.success) {
                    $("#UsuarioModal").modal("hide");
                    location.reload();
            	}
            	else{
                    $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            	}

            }
    });
}

$('#radioBtn a').on('click', function () {
    var sel = $(this).data('title');
    var tog = $(this).data('toggle');
    $('#' + tog).prop('value', sel);

    $('a[data-toggle="' + tog + '"]').not('[data-title="' + sel + '"]').removeClass('active').addClass('notActive');
    $('a[data-toggle="' + tog + '"][data-title="' + sel + '"]').removeClass('notActive').addClass('active');
})
function buscarPersona() {
    $("#titleModalPersona").html("Buscar Usuario");
    $("#BuscarPersonaModal").modal("show");
}
function buscarPersonas() {
        var token = $("[name='__RequestVerificationToken']").val();
        var pTexto = $("#texto").val()
        var parametros = {
            pTexto: pTexto,
            __RequestVerificationToken: token
        };

        $.ajax({
            data: parametros,
            url: '/Usuario/buscarUsuario/',
            type: 'post',
            beforeSend: function () {

            },
        success: function (response) {
            if (response.success) {
                   
                    RenderizarTabla(response.objeto);
                   
                }
                else {
                    $("#ResultadoBuscar").html(response);
                }

            }
        });
}
function RenderizarTabla(informacion) {
    var table = $("#renderizando");
    table.children().remove();
    var i = 1;
    $.each(informacion, function (rowIndex, r) {
        var row = $("<tr/>");

        var campoId = r["id"];
        var campoA = r["string2"];
        var campoB = r["string1"];
        var campoC = r["string3"];
        var campoD = r["string4"];
        //En caso necesites que haya algun enlace que ejecute una acción:
        row.append($("<td/>")
            .append('<button type="button" class="btn btn-secondary btn-circle " onclick="agregarPersona(' + campoId + ',\'' + campoB +'\')"><span class="icon-add-3"></span></button >')
        );
        row.append($("<td/>").text(i));
        row.append($("<td/>").text(campoA));
        row.append($("<td/>").text(campoB));
        row.append($("<td/>").text(campoC));
        row.append($("<td/>").text(campoD));
        table.append(row);
        i++;
    });
}
function agregarPersona(IdPersona, NombreCompleto) {
    $("#Persona").val(NombreCompleto);
    $("#IdPersona").val(IdPersona);
    $("#BuscarPersonaModal").modal("hide");
}

function elimnarUsuario(IdUsuario, NombreCOmpleto) {
    $(".modal-title").html("Eliminar Usuario");
    $("#IdUsuario_").val(IdUsuario);
    $("#titleUsuario").html("¿ Desea Eliminar Usuario " + NombreCOmpleto + " ?");
    $("#DeleteUsuario").modal("show");
}

function eliminarRegistro() {
    var IdUsuario = $("#IdUsuario_").val() ;
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Id: IdUsuario,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Usuario/Eliminar/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                $("#DeleteUsuario").modal("hide");
                location.reload();
            }
            else {
                $("#ResultadoBuscar").html(response);
            }

        }
    });
}
function editarUsuario(idUsuario) {
    $("#IdUsuario_").val(idUsuario);
    $("#IdBuscar__").css({ "display": "none" });
    $("#usuarioPassword").css({ "display": "none" });
    $(".modal-title").html("Editar Usuario");
    $("#IdGuardar__").css({ "display": "none" });
    $("#Actualizar__").css({ "display": "" });
    $("#UsuarioModal").modal("show");

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdUsuario: idUsuario,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Usuario/getUsuario_x_IdUsuario/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            if (response.success) {
                var objeto = response.objeto;
                $("#IdUsuario").val(objeto.id1)
                $("#IdPerfil").val(objeto.id2)
                $("#Persona").val(objeto.string1)
                $("#CorreoElectronico").val(objeto.string2)
                if (objeto.bool1) {
                    $("#happy").val('S')
                    $('#InActivo').removeClass('active').addClass('notActive');
                    $('#Activo').removeClass('notActive').addClass('active');
                }
                else {
                    $("#happy").val('N')
                    $('#Activo').removeClass('active').addClass('notActive');
                    $('#InActivo').removeClass('notActive').addClass('active');
                }
                
            }
            else {
                $("#ResultadoBuscar").html(response);
            }

        }
    });
}

function guardarEdicion() {
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        IdUsuario: $("#IdUsuario_").val(),
        Usuario: "",
        Password: "",
        Apellidos: "",
        Nombres: "",
        IdPerfil: $("#IdPerfil").val(),
        IdEstatusUsuario: 0,
        IdDependencia: 0,
        IdProveedor: 0,
        IdPersona: 0,
        CorreoElectronico: $("#CorreoElectronico").val(),
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdUsuarioRegistro: 0,
        FechaRegistro: "",
        __RequestVerificationToken: token
    };


    $.ajax({
        data: parametros,
        url: '/Usuario/Editar/',
        type: 'post',
        beforeSend: function () {
            $("#UsuarioModal").modal("hide");
            location.reload();
        },
        success: function (response) {
            if (response.success) {
                $("#DeleteUsuario").modal("hide");
                location.reload();
            }
            else {
                $("#ResultadoBuscar").html(response);
            }

        }
    });
}