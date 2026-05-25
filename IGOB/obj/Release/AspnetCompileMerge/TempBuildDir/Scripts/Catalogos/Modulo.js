$(document).ready(function () {
    $('.table').DataTable({
        "scrollY": "280px"
    });
});

function nuevoModulo() {
    $(".modal-title").html("Alta Modulo");
    $("#IdGuardar__").css({ "display": "" });
    $("#Actualizar__").css({ "display": "none" });
    $("#ModuloModal").modal("show");
}
function eliminarModulo(IdModulo, Descripcion) {

    $("#IdModulo").val(IdModulo);
    $("#titleModulo").html("¿ Desea Eliminar el modulo " + Descripcion + " ?");
    $("#DeleteModulo").modal("show");
}
function editarModulo(IdModulo) {
    $(".modal-title").html("Editar Modulo");
    $("#IdGuardar__").css({ "display": "none" });
    $("#Actualizar__").css({ "display": "" });
    $("#IdModulo").val(IdModulo);

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdModulo: IdModulo,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Modulo/getModulo/',
        type: 'post',
        beforeSend: function () {
            $("#ModuloModal").modal("show");
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                var objeto = response.objeto;
                $("#Modulo").val(objeto.Modulo);
                $("#Descripcion").val(objeto.Descripcion);
                $("#Clave").val(objeto.Clave);
                $("#Orden").val(objeto.Orden);
                $("#Icono").val(objeto.Icono);
                if (objeto.Activo) {
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
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function validarForm() {
    var Modulo = $("#Modulo").val();
    var Descripcion = $("#Descripcion").val();
    var Clave = $("#Clave").val();
    var Orden = $("#Orden").val();
    var Icono = $("#Icono").val();
    var Activo = $("#happy").val();

    if (Modulo == "") {
        alert("Falta Capturar Modulo");
        return;
    }
    if (Descripcion == "") {
        alert("Falta Capturar Descripcion");
        return;
    }
    if (Clave == "") {
        alert("Falta Capturar Clave");
        return;
    }
    if (Orden == "") {
        alert("Falta Capturar Orden");
        return;
    }
    if (Icono == "") {
        alert("Falta Capturar Icono");
        return;
    }


    altaUsuario();
}
function guardarEdicion() {

    var Modulo = $("#Modulo").val();
    var Descripcion = $("#Descripcion").val();
    var Clave = $("#Clave").val();
    var Orden = $("#Orden").val();
    var Icono = $("#Icono").val();
    var Activo = $("#happy").val();
    var IdModulo = $("#IdModulo").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Modulo: Modulo,
        Descripcion: Descripcion,
        Clave: Clave,
        Orden: Orden,
        Icono: Icono,
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdModulo: IdModulo,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Modulo/actualizarModulo/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#ModuloModal").modal("hide");
                location.reload();
            }
            else {
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


function altaUsuario() {

    var Modulo = $("#Modulo").val();
    var Descripcion = $("#Descripcion").val();
    var Clave = $("#Clave").val();
    var Orden = $("#Orden").val();
    var Icono = $("#Icono").val();
    var Activo = $("#happy").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Modulo: Modulo,
        Descripcion: Descripcion,
        Clave: Clave,
        Orden: Orden,
        Icono: Icono,
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdModulo: 0,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Modulo/createModulo/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#ModuloModal").modal("hide");
                location.reload();
            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function eliminarRegistro() {
    var IdModulo = $("#IdModulo").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdModulo: IdModulo,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Modulo/deleteModulo/',
        type: 'post',
        beforeSend: function () {
            
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#DeleteModulo").modal("hide");
                location.reload();
            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}