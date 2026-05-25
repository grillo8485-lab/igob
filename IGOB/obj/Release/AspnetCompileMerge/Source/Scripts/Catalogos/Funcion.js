$(document).ready(function () {
    $('.table').DataTable({
        "scrollY": "280px"
    });
});

function nuevaFuncion() {
    $(".modal-title").html("Alta Funcion");
    $("#IdGuardar__").css({ "display": "" });
    $("#Actualizar__").css({ "display": "none" });
    $("#FuncionModal").modal("show");
}
function eliminarFuncion(IdFuncion, Descripcion) {

    $("#IdFuncion").val(IdFuncion);
    $("#titleFuncion").html("¿ Desea Eliminar la función " + Descripcion + " ?");
    $("#DeleteFuncion").modal("show");
}
function editarFuncion(IdFuncion) {
    $(".modal-title").html("Editar Modulo");
    $("#IdGuardar__").css({ "display": "none" });
    $("#Actualizar__").css({ "display": "" });
    $("#IdFuncion").val(IdFuncion);

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdFuncion: IdFuncion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Funcion/getFuncion/',
        type: 'post',
        beforeSend: function () {
            $("#FuncionModal").modal("show");
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                var objeto = response.objeto;
                $("#Funcion").val(objeto.Funcion);
                $("#Descripcion").val(objeto.Descripcion);
                $("#Formulario").val(objeto.Formulario);
                $("#Orden").val(objeto.Orden);
                $("#Icono").val(objeto.Icono);
                $("#IdModulo").val(objeto.IdModulo);
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
    var Funcion = $("#Funcion").val();
    var Descripcion = $("#Descripcion").val();
    var IdModulo = $("#IdModulo").val();
    var Formulario = $("#Formulario").val();
    var Orden = $("#Orden").val();
    var Icono = $("#Icono").val();
    var Activo = $("#happy").val();

    if (Funcion == "") {
        alert("Falta Capturar Funcion");
        return;
    }
    if (Descripcion == "") {
        alert("Falta Capturar Descripcion");
        return;
    }
    if (Formulario == "") {
        alert("Falta Capturar Formulario");
        return;
    }
    if (IdModulo == "") {
        alert("Falta Seleccionar Modulo");
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


    altaFuncio();
}
function guardarEdicion() {

    var Funcion = $("#Funcion").val();
    var Descripcion = $("#Descripcion").val();
    var IdModulo = $("#IdModulo").val();
    var Formulario = $("#Formulario").val();
    var Orden = $("#Orden").val();
    var Icono = $("#Icono").val();
    var Activo = $("#happy").val();
    var IdFuncion = $("#IdFuncion").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Funcion: Funcion,
        Descripcion: Descripcion,
        Formulario: Formulario,
        Orden: Orden,
        Icono: Icono,
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdModulo: IdModulo,
        IdFuncion: IdFuncion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Funcion/actualizarFuncion/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#FuncionModal").modal("hide");
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


function altaFuncio() {

    var Funcion = $("#Funcion").val();
    var Descripcion = $("#Descripcion").val();
    var IdModulo = $("#IdModulo").val();
    var Formulario = $("#Formulario").val();
    var Orden = $("#Orden").val();
    var Icono = $("#Icono").val();
    var Activo = $("#happy").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Funcion: Funcion,
        Descripcion: Descripcion,
        Formulario: Formulario,
        Orden: Orden,
        Icono: Icono,
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdModulo: IdModulo,
        IdFuncion: 0,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Funcion/createFuncion/',
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
    var IdFuncion = $("#IdFuncion").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdFuncion: IdFuncion,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Funcion/deleteFuncion/',
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