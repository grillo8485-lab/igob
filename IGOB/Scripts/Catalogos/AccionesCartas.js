$(document).ready(function () {
    $('#tableCartas').DataTable({
        scrollY: 340,
        scrollX: true,
        scrollCollapse: true,
        sort: false
    });
});

//Abrir Modal saveItem
$('.new-Carta').on('click', function () {
    $("input[type=text]").val("");
    $(".form-control").val("");
    var FechaRegistro = new Date().toLocaleString();
    $("#FechaRegistro").val(FechaRegistro);
    $("#CartasModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Carta");
    $("#CartasModal").modal("show");
});


//Abrir modal editItem
$('#tableCartas').on('click', '.edit-Carta', function () {
    $("#IdCarta").val($(this).attr('id'));   
    $("#Nombre").val($(this).attr('data-nombre'));
    $("#Carta").val($(this).attr('data-title'));
    $("#IdTipoCarta").val($(this).attr('data-TC'));
    $("#Solicitada").val($(this).attr('data-solicitada'));
    var FechaRegistro = new Date().toLocaleString();
    $("#FechaRegistro").val(FechaRegistro);
    $("#Inciso").val($(this).attr('data-inciso').trim());
    $("#Obligada").val($(this).attr('data-obligada'));
    $("#CartasModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Carta");

    $("#CartasModal").modal("show");
});


// Confirmar Edición - Creación del Capitulo
$("#CartasModal").on('submit', function (e) {
    e.preventDefault();
    var tipo = $("#form-Cartas input[type=submit]").prop("value");
    //if (tipo === "Editar") {
    //    //$.post("/Cartas/Edit/", form.serialize(), "JSON")
    //    //    .done(function (response) {
    //    //        location.reload();
    //    //    })
    //    //    .fail(function (resp) {
    //    //        console.log(resp);
    //    //    })
    //    //    .always(function () {
    //    //        $("#CartasModal").modal("hide");
    //    //    });
        
    //} else {
    //    //$.post("/Cartas/Create/", form.serialize(), "JSON")
    //    //    .done(function (response) {
    //    //        location.reload();
    //    //    })
    //    //    .fail(function (resp) {
    //    //        console.log(resp);
    //    //    });
    //}
    var url = tipo === "Editar" ? "/Cartas/Edit/" : "/Cartas/Create/";
    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEditarCreate, b: url })
    return false;
});

//Abrir AlertModal Eliminar
$('#tableCartas').on('click', ".delete-Carta", function () {
    $(".IdCarta").val($(this).attr('id'));
    $("#DeleteCartasModal input[type=submit]").prop("value", "Eliminar");
    $(".modal-title").html("Eliminar Carta");

    $("#titleCarta").html(`¿Desea Eliminar la Carta "${$(this).attr('data-title')}"?`);
    $("#DeleteCartasModal").modal("show");
});

//Confirmar eliminación de Marca
$("#DeleteCartasModal").on('submit', function (e) {
    e.preventDefault();
    traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveEliminarAutorizarRechazar, b: undefined })
});
function saveEditarCreate(url) {
    var form = $("#form-Cartas");
    $.post(url, form.serialize(), "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            console.log(resp);
        })
        .always(function () {
            $("#CartasModal").modal("hide");
        });
}

function saveEliminarAutorizarRechazar() {
    var IdCarta = $(".IdCarta").val();
    var token = $("[name='__RequestVerificationToken']").val();
    var url = "";
    switch ($("#DeleteCartasModal input[type=submit]").val()) {
        case "Eliminar":
            url = "/Cartas/Delete/";
            break;
        case "Autorizar":
            url = "/Cartas/Autorizar/";
            break;
        case "Rechazar":
            url = "/Cartas/Rechazar/";
            break;
    }

    $.post(url, { __RequestVerificationToken: token, Id: IdCarta }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            //console.log(resp);
        })
        .always(function () {
            $("#DeleteCartasModal").modal("hide");
        });
}
function autorizarCarta(cartas) {
    $(".IdCarta").val($(cartas).attr('id'));
    $("#DeleteCartasModal input[type=submit]").prop("value", "Autorizar");
    $(".modal-title").html("Autorizar Carta");

    $("#titleCarta").html(`¿Desea Autorizar la Carta "${$(cartas).attr('data-title')}"?`);
    $("#DeleteCartasModal").modal("show");
}
function rechazarCarta(cartas) {
    $(".IdCarta").val($(cartas).attr('id'));
    $("#DeleteCartasModal input[type=submit]").prop("value", "Rechazar");
    $(".modal-title").html("Rechazar Carta");

    $("#titleCarta").html(`¿Desea Rechazar la Carta "${$(cartas).attr('data-title')}"?`);
    $("#DeleteCartasModal").modal("show");
}


