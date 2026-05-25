$(document).ready(function () {
    $('#tableCtaBan').DataTable({
        sort: false,
        "lengthMenu": [[5,10, 25, 50, -1], [5,10, 25, 50, 100]],
        pageLength: 5

    });

    $("#tableCtaBanGroup").DataTable({
        sort: false,
        "lengthMenu": [[5,10, 25, 50, -1], [5,10, 25, 50, 100]],
        pageLength: 5
    })
});

$('#tableCtaBanGroup').on('click', '.cuentaBanc', function () {
    location.href = `/CuentasBancarias/CuentasPorDependencias/${$(this).attr('data-ictaband').trim()}`
})

$('#create-ctaban').on('click', function () {
    $('#form-CtasBancarias')[0].reset()
    $("#subtmi-createdit").prop("value", "Guardar");
    $("#titlemodal").html("Nueva Cuenta Bancaria");
    $("#CtasBancariasModal").modal("show");
});

$('#tableCtaBan').on('click', '.edit-cuentabancaria', function () {

    $("#IdCuentaBancaria").val($(this).attr('data-ictaband'))
    $("#IdDependencia").val($(this).attr('data-iddep')).attr('selected', true);
    $("#IdOrigenRecurso").val($(this).attr('data-idorigen')).attr('selected', true);
    $("#IdBanco").val($(this).attr('data-idbanco')).attr('selected', true);
    $("#NumeroCuenta").val($(this).attr('data-numerocta'))
    $("#NombreCuenta").val($(this).attr('data-nomcta'))
    $("#MontoDisponible").val($(this).attr('data-disponible'))
    $("#MontoDisponibleEntidad").val($(this).attr('data-disponibleEnt'))
    $("#AutorizadoIgob").val($(this).attr('data-autorizadoigob'))
    $("#MontoComprometido").val($(this).attr('data-moncomprometido'))
    $("#MontoSaldoIgob").val($(this).attr('data-monsaldigob'))
    $("#MontoEjecutado").val($(this).attr('data-monejecutado'))
    $("#MontoEconomia").val($(this).attr('data-moneconomia'))
    $("#FechaMovimiento").val($(this).attr('data-fechaMovimiento'))
    $("#FechaRegistro").val($(this).attr('data-fechareg'))
    $("#IdUsuarioRegistro").val($(this).attr('data-idusreg'))

    validarEdicion($(this).attr('data-moncomprometido'))

    $("#subtmi-createdit").prop("value", "Editar");
    $("#titlemodal").html("Editar Cuenta Bancaria");
    $("#CtasBancariasModal").modal("show");
});

$('#tableCtaBan').on('click', '.delete-cuentabancaria', function () {
    $("#MensajeDelete").html(`<h4><stronge>¿Desea Eliminar La Cuenta "${$(this).attr('data-nomcta')}"?</stronge><h4>`);
    $("#IdCtasBanc").val($(this).attr('data-ictaband'));
    $("#titledelete").html("Eliminar Cuenta Bancaria");
    $("#DeleteModal").modal("show");
});

$("#CtasBancariasModal").on('submit', function (e) {
    e.preventDefault();
    var form = $("#form-CtasBancarias").serialize();
    var tipo = $("#subtmi-createdit").prop("value").trim();

    bootbox.confirm({
        size: "small",
        title: "Confirmar",
        message: "¿Desea " + tipo + " la cuenta bancaria por el monto de <strong> $" + numeral($("#MontoDisponible").val())["_value"].toLocaleString("en-US") + "</strong> ?",
        callback: function (result) {
            if (result){
                if (tipo === "Editar") {
                    $.post("/CuentasBancarias/Edit/", form, "JSON")
                        .done(function (response) {
                            if (response.trim() == "Cuenta Existente") {
                                $('#MensajeForm').html(`<h4>${response}</h4>`)
                            } else {
                                $('#MensajeForm').html(`<h4>${response}</h4>`)
                                setTimeout(function () { location.reload() }, 1000)
                            }
                        })
                        .fail(function (resp) {
                            $('#MensajeForm').html(resp)
                            alert(resp);
                        })
                } else {
                    $.post("/CuentasBancarias/Create/", form, "JSON")
                        .done(function (response) {
                            $('#MensajeForm').html(`<h4>${response}</h4>`)
                            setTimeout(function () { location.reload() }, 1000)
                        })
                        .fail(function (resp) {
                            $('#MensajeForm').html(resp)
                            alert(resp);
                        })
                }
            }
        }

    });


    return false;
});

$("#DeleteModal").on('submit', function (e) {
    e.preventDefault();
    var IdCuentaBancaria = $("#IdCtasBanc").val();
    var token = $("[name='__RequestVerificationToken']").val();

    $.post("/CuentasBancarias/Delete/", { __RequestVerificationToken: token, id: IdCuentaBancaria }, "JSON")
        .done(function (response) {
            $('#MensajeResponde').html(`<h6><stronge>${response}</stronge></h6>`)
            setTimeout(function () { location.reload() }, 1000)
        })
        .fail(function (resp) {
            $('#MensajeResponde').html(response)
        })
});

function validarEdicion(monto) {
    if (monto > 0) {
        $(`#NombreCuenta,#MontoDisponible`).addClass('disabledClick')
    } else {
        $(`#NombreCuenta,#MontoDisponible`).removeClass('disabledClick')
    }
}