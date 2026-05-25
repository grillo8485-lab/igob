$(document).ready(function () {
    $('.table').DataTable({
        "scrollY": "280px",
        scrollCollapse: true
    });
});

function nuevoPerfil() {
    $(".modal-title").html("Alta Perfil");
    $("#IdGuardar__").css({ "display": "" });
    $("#Actualizar__").css({ "display": "none" });
    $("#PerfilModal").modal("show");
}
function eliminarPerfil(IdPerfil, Descripcion) {

    $("#IdPerfil").val(IdPerfil);
    $("#titleFuncion").html("¿ Desea Eliminar el perfil " + Descripcion + " ?");
    $("#DeletePerfil").modal("show");
}
function editarPerfil(IdPerfil) {
    $(".modal-title").html("Editar Modulo");
    $("#IdGuardar__").css({ "display": "none" });
    $("#Actualizar__").css({ "display": "" });
    $("#IdPerfil").val(IdPerfil);

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdPerfil: IdPerfil,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Perfil/getPerfil/',
        type: 'post',
        beforeSend: function () {
            $("#PerfilModal").modal("show");
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                var objeto = response.objeto;
                $("#Perfil").val(objeto.Perfil);
                $("#Descripcion").val(objeto.Descripcion);
                $("#CodigoPerfil").val(objeto.CodigoPerfil);
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
    var Perfil = $("#Perfil").val();
    var Descripcion = $("#Descripcion").val();
    var CodigoPerfil = $("#CodigoPerfil").val();
    var Activo = $("#happy").val();

    if (Perfil == "") {
        alert("Falta Capturar Perfil");
        return;
    }
    if (Descripcion == "") {
        alert("Falta Capturar Descripcion");
        return;
    }
    if (CodigoPerfil == "") {
        alert("Falta Capturar Codigo Perfil");
        return;
    }
    altaPerfil();
}
function guardarEdicion() {

    var Perfil = $("#Perfil").val();
    var Descripcion = $("#Descripcion").val();
    var CodigoPerfil = $("#CodigoPerfil").val();
    var IdPerfil = $("#IdPerfil").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Perfil: Perfil,
        Descripcion: Descripcion,
        CodigoPerfil: CodigoPerfil,
        Activo: ($("#happy").val() == 'S' ? true : false),
        IdPerfil: IdPerfil,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Perfil/actualizarPerfil/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#PerfilModal").modal("hide");
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


function altaPerfil() {

    var Perfil = $("#Perfil").val();
    var Descripcion = $("#Descripcion").val();
    var CodigoPerfil = $("#CodigoPerfil").val();
    var Activo = $("#happy").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        Perfil: Perfil,
        Descripcion: Descripcion,
        CodigoPerfil: CodigoPerfil,
        Activo: ($("#happy").val() == 'S' ? true : false),
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Perfil/createPerfil/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#PerfilModal").modal("hide");
                location.reload();
            }
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function eliminarRegistro() {
    var IdPerfil = $("#IdPerfil").val();

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdPerfil: IdPerfil,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/Perfil/deletePerfil/',
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