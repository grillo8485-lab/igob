$(document).ready(function () {
    $('#tablePresupuestos').DataTable({
        scrollY: 340,
        scrollX: true
    });
});

//Abrir Modal saveItem
$('.new-Presupuestos').on('click', function () {
    $("#form-Presupuestos")[0].reset();
    var FechaRegistro = new Date().toLocaleString();
    $("#FechaRegistro").val(FechaRegistro);
    $("#PresupuestosModal input[type=submit]").prop("value", "Guardar");
    $(".modal-title").html("Nueva Clave Presupuestal");

    $("#PresupuestosModal").modal("show");
});

//Abrir modal editItem
$('#tablePresupuestos').on('click', '.edit-Presupuestos', function () {
    $("#IdPresupuestoPartida").val($(this).attr('data-prep'));
    $("#IdPresupuesto").val($(this).attr('data-pre'));
    $("#IdDependencia").val($(this).attr('data-dependencia'));
    getPartidas($(this).attr('data-capitulo').trim());
    $("#IdCapitulo").val($(this).attr('data-capitulo'));
    $("#IdEjercicioFiscal").val($(this).attr('data-ejercicio'));
    $("#FechaRegistro").val($(this).attr('data-fr'));
    $("#MontoPresupuesto").val($(this).attr('data-montoprep'));
    $("#MontoComprometido").val($(this).attr('data-montocomp'));
    $("#MontoEjecutadoTotal").val($(this).attr('data-montoejet'));
    $("#MontoSaldo").val($(this).attr('data-saldo'));
    $("#MontoEconomia").val($(this).attr('data-economia'));
    $("#IdEjercicioFiscal").val($(this).attr('data-idEjercicio'));
    $("#NumeroMinistracion").val($(this).attr('data-numminis'));

    $("#PresupuestosModal input[type=submit]").prop("value", "Editar");
    $(".modal-title").html("Editar Clave Presupuestal");

    $("#PresupuestosModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#PresupuestosModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-Presupuestos");
    var tipo = $("#form-Presupuestos input[type=submit]").prop("value");
    
    if (tipo === "Editar") {
        $.post("/Presupuestos/Edit/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                alert(resp);
            })
            .always(function () {
                $("#PresupuestosModal").modal("hide");
            });
    } else {
        $.post("/Presupuestos/Create/", form.serialize(), "JSON")
            .done(function (response) {
                location.reload();
            })
            .fail(function (resp) {
                console.log(resp);

                alert(resp);
            })
            .always(function (resp) {
                $("#PresupuestosModal").modal("hide");
                console.log(resp);
                console.log(form.serialize());
            });
    }
    return false;
});

//Abrir AlertModal Eliminar
$('#tablePresupuestos').on('click', ".delete-Presupuestos", function () {
    $("#IdPresupuesto").val($(this).attr('data-prep'));
    $("#DeletePresupuestosModal input[type=submit]").prop("value", "Eliminar");
    $(".modal-title").html("Eliminar Clave Presupuestal");

    $("#titlePresupuesto").html("¿Desea Eliminar Clave Presupuestal ?");
    $("#DeletePresupuestosModal").modal("show");
});

//Confirmar eliminación de Marca
$("#DeletePresupuestosModal").on('submit', function (e) {
    e.preventDefault();
    var IdPresupuesto = $(".IdPresupuesto").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("Presupuestos/Delete/" + IdPresupuesto, { __RequestVerificationToken: token, id: IdPresupuesto }, "JSON")
        .done(function (response) {
            location.reload();
        })
        .fail(function (resp) {
            alert(resp);
        })
        .always(function () {
            $("#DeletePresupuestosModal").modal("hide");
        });
});

$('#IdCapitulo').on("change", function () {
    getPartidas(0);
});

function getPartidas(idcap) {
    let idCapitulo = $('#IdCapitulo').val();
    $.get(
        "/Presupuestos/getPartidas",
        { idCap: idCapitulo },
        "json"
    ).done(function (response) {
        console.log(response);
        $('#IdPartida').empty();
        $('#IdPartida').append(`<option value="0">Seleccione Una Partida</option>`);
        $.each(response, function (index, row) {
            if (idcap == 0) {
                $('#IdPartida').append(`<option value="${row.IdPartida}">${row.Partida}</option>`);
            } else {
                if (row.IdPartida == idcap.trim()) {
                    $('#IdPartida').append(`<option value="${row.IdPartida}" selected="selected">${row.Partida}</option>`);
                } else {
                    $('#IdPartida').append(`<option value="${row.IdPartida}">${row.Partida}</option>`);
                }
            }
        });
    });
}