$(document).ready(function () {
    $('.table').DataTable({
        scrollY: 340
    });
});

//Abrir Modal saveItem
$('.new-Cert').on('click', function () {
    $("#form-Cert")[0].reset();
    $("#CertModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Certificacion");
    var FechaRegistro = new Date().toLocaleString();
    $("#FechaRegistro").val(FechaRegistro);
    $("#CertModal").modal("show");
});

//Abrir modal editItem
$('#tableCert').on('click', '.edit-Cert', function () {
    $("#IdCertificacion").val($(this).attr('id'));
    $("#Certificacion").val($(this).attr('data-title'));
    $("#NoCertificacion").val($(this).attr('data-NoCertificacion'));   

    $("#CertModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Certificacion");

    $("#CertModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#CertModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-Cert");
    var tipo = $("#form-Cert input[type=submit]").prop("value");

    if (tipo === "Editar") {
        $.post("/Certificaciones/Edit/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#CertModal").modal("hide");
                    }
                });
            });
    } else {
        $.post("/Certificaciones/Create/", form.serialize(), "JSON")
            .always(function (data) {
                bootbox.alert({
                    size: "small",
                    title: data.success ? "Aviso" : "Error",
                    message: data.m,
                    callback: function () {
                        if (data.success)
                            location.reload();
                        else
                            $("#CertModal").modal("hide");
                    }
                });
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tableCert').on('click', ".delete-Certificacion", function () {
    var IdCertificacion = $(this).attr('id');

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea Eliminar la certificación <strong>" + $(this).attr('data-title') + "</strong> ?",
        callback: function (e) {
            if (e) {
                $.post("/Certificaciones/Delete/", { __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(), id: IdCertificacion }, "JSON")
                    .always(function (data) {
                        bootbox.alert({
                            size: "small",
                            title: data.success ? "Aviso" : "Error",
                            message: data.m,
                            callback: function () {
                                if (data.success)
                                    location.reload();
                            }
                        });
                    });
            }
        }
    });
});