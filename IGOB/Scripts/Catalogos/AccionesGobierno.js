$(document).ready(function () {
    $('#tabla_Gobierno').DataTable({
        scrollY: 440,
        scrollX: true,
        scrollCollapse: true,
        sort: false
    });
    $('.input-time').on('click', function () {
        $('.datetimepicker.datetimepicker-inline').css('display', 'none')
    });
    $('.input-time').val('');
    $('.input-time').datetimepicker({
        language: 'es',
        autoclose: true,
        format: "hh:ii:ss",
        startView: 0,
        minView: 0,
        maxView: 0,
        minuteStep: 10
    });
});

function readURL(input, resultname, resultcod, label) {
    $('#' + label).text(input.files[0].name)
    $('#' + resultname).val(input.files[0].name);
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#falseinput').attr('src', e.target.result);
            $('#' + resultcod).val(e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

//Abrir modal editItem
$('#tabla_Gobierno').on('click', '.edit-item', function () {

    $('#MensajeForm').html('');
    $("#IdGobierno").val($(this).attr('data-idgob').trim());
    $("#IdUsuarioRegistro").val($(this).attr('data-idur').trim());
    $("#Gobierno").val($(this).attr('data-gob').trim());
    //console.log(`idgobierno: ${$(this).attr('data-idgob').trim()}`)
    if ($(this).attr('data-cobb').trim()!="False") {
        $('#Cobrobases').prop('checked', true)
        $('#MontoBases').attr('disabled', false)
    } else {
        $('#Cobrobases').prop('checked', false)
        $('#MontoBases').attr('disabled', true)
    }
    $("#MontoBases").val($(this).attr('data-monb').trim());
    if ($(this).attr('data-repa').trim() != "False") {
        $('#RepertirAccionistas').prop('checked', true)
    } else {
        $('#RepertirAccionistas').prop('checked', false)
    }
    if ($(this).attr('data-apfc').trim() != "False") {
        $('#AplicarFechasCedula').prop('checked', true)
    } else {
        $('#AplicarFechasCedula').prop('checked', false)
    }
    $("#AplicarRestriccionCedula").val($(this).attr('data-aprc').trim());
    $("#LimiteGirosProveedor").val($(this).attr('data-ligp').trim());
    $("#HorarioLaboralInicio").val($(this).attr('data-hrli').trim());
    $("#HorarioLaboralFin").val($(this).attr('data-hrlf').trim());
    $("#AlertaVerde").val($(this).attr('data-alve').trim());
    $("#AlertaAmarilla").val($(this).attr('data-alam').trim());
    $("#AlertaRoja").val($(this).attr('data-alro').trim());
    $("#DiasCancelarNoAtendida").val($(this).attr('data-dcan').trim());
    $("#DiasEnvioCorreo2daVuelta").val($(this).attr('data-decdv').trim());
    $("#TiempoValidaPago").val($(this).attr('data-hrvp').trim());
    $("#TiempoExtraValidaPago").val($(this).attr('data-hrep').trim());
    $("#Banner").val($(this).attr('data-banner').trim());
    $("#UrlBanner").val($(this).attr('data-bnnr').trim());
    $("#lblbanner").text($(this).attr('data-bnnr').trim());
    $("#lbllogo").text($(this).attr('data-urlg').trim());
    $("#UrlLogo").val($(this).attr('data-urlg').trim());
    $("#Logo").val($(this).attr('data-logo').trim());
    $("#FechaRegistro").val(formatDateTimeLocal($(this).attr('data-freg').trim(), 2));
    

    $("#submitform").prop("value", "Editar");
    $('#formEditCreate').text(`Editar Gobierno`);
    $("#ModalForm").modal("show");
});

$('#create-item').on('click', function () {
    $('#MensajeForm').html('');
    $('.GobForm')[0].reset()
    $("#IdGobierno").val(0);
    $('#MontoBases').attr('disabled', false)
    $("#submitform").prop("value", "Guardar");
    $('#formEditCreate').text('Nuevo Gobierno');
    $("#ModalForm").modal("show");
});

//Modal Confirmar Edicion de Eliminacion
$('#tabla_Gobierno').on('click', '.delet-item', function (d) {
    d.preventDefault();
    $("#deleteId").val($(this).attr('data-idgob').trim());
    $('#DeleteTitle').text('Eliminar Unidad de Medida');
    $('#ConfirDelete').html(`<h4>¿Desea Eliminar Gobierno "${$(this).attr('data-gob').trim()}"?</h4>`)
    $("#FormDelete").modal("show");
})

$('#FormDelete').on('submit', function () {
    //console.log(`entro a eliminar`)
    let id_delete = $("#deleteId").val();
    var token = $("[name='__RequestVerificationToken']").val();

    //console.log(id_delete)
    $.post('/Gobierno/Delete/',
        { id: id_delete, __RequestVerificationToken: token  },
        "json"
    ).done(function (response) {
        $('#MensajeDelete').html(response)
        $("#FormDelete").modal("hide");
        setTimeout(function () { location.reload(); }, 1000)
    })
    return false;
})

$("#ModalForm").on('submit', function (e) {
    e.preventDefault();
    let data = $('.GobForm').serialize().trim();
    var tipo = $("#submitform").prop("value").trim();
    console.log(data)
    if (tipo === "Editar") {
        $.post("/Gobierno/Edit/", 
            data.trim(),
            "JSON")
            .done(function (response) {
                bootbox.alert({
                    title: 'Aviso',
                    message: response,
                    size: 'small',
                    callback: () => {
                        if (response.success) {
                            location.reload();
                        }
                    }
                })
            })
    }
    if (tipo === "Guardar") {
        $.post("/Gobierno/Create/", 
            data.trim()
            , "JSON")
            .done(function (response) {
                bootbox.alert({
                    title: 'Aviso',
                    message: response.message,
                    size: 'small',
                    callback: () => {
                        if (response.success) {
                            location.reload();
                        }
                    }
                })
            })
    }
    return false;
})

$('#Cobrobases').on('change', function () {
    if ($('#Cobrobases').is(':checked')) {
        $('#MontoBases').attr('disabled', false)
        $('#Cobrobases').prop('checked', true)
    } else {
        $('#MontoBases').attr('disabled', true)
        $('#Cobrobases').prop('checked', false)
    }  
})

function formatDateTimeLocal(cadena, tipo) {
    var ncad = cadena.split(" ");//console.log(ncad);
    var fecha = ncad[0].split("/");//console.log(fecha)
    /*
    tipo 1 es un tipo de datos date
    tipo 2 es un tipo de datos datetime-local
    */
    var newfecha = `${fecha[2]}-${fecha[1]}-${fecha[0]}`;
    if (tipo == 1) {
        return newfecha;
    }
    if (tipo == 2) {
        return `${newfecha} ${ncad[1]}`;
    }
}