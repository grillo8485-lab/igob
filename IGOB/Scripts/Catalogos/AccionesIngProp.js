$(document).ready(function () {
    $('#tableCtaBan').DataTable({
        scrollY: 340
    });
});

//Abrir Modal saveItem
$('#create-ctaban').on('click', function () {
    $("#form-IngresosPropios")[0].reset();
    $("#subtmi-createdit").prop("value", "Guardar");
    $("#titlemodal").html("Crear Ingreso Propio");
    $("#CtasBancariasModal").modal("show");
});

// Confirmar Edición - Creación de Marca
$("#CtasBancariasModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-IngresosPropios").serialize();

    $.post("/CuentasBancarias/Create/", form, "JSON")
        .done(function (response) {
            $('#MensajeForm').html(`<h4>${response}</h4>`)
            setTimeout(function () { location.reload() }, 2000)
        })
        .fail(function (resp) {
            $('#MensajeForm').html(resp)
            console.log(resp);
        })

    return false;
});

