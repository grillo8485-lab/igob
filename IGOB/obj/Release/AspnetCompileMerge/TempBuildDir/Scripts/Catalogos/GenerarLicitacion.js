$(document).ready(function () {
    $(function () {
        // Bootstrap DateTimePicker v4
        $('.ssss').datetimepicker({
            language: 'es',
            format: "mm/dd/yyyy",
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            pickTime: false,
            inline: false
        });
    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('.datetimepickerHoraAclaracionDuda').datetimepicker({
            language: 'es',
            format: "mm/dd/yyyy HH:ii:ss",
            timeFormat: 'hh:ii:ss',
            startView: 0,
            minView: 0,
            autoclose: 1,
            defaultDate: new Date(),
            pickDate: false
        }).on('changeDate', function (e) {
            var dateTime = $('#FechaHoraAclaracionDudas').val();
            var array = dateTime.split(' ')

            var nuevaFecha = e.date;
            var h = addZero(nuevaFecha.getHours());
            var m = addZero(nuevaFecha.getMinutes());
            var s = addZero(nuevaFecha.getSeconds());
            var time = h + ':' + m + ':' + s
            $('#FechaHoraAclaracionDudas').val(array[0] + ' ' + time)
        });
    });

    $(function () {

        // Bootstrap DateTimePicker v4
        $('.datetimepickerHoraFallo').datetimepicker({
            language: 'es',
            format: "mm/dd/yyyy HH:ii:ss",
            pickDate: false,
            pickTime: true,
            timeFormat: 'hh:ii:ss',
            startView: 0,
            minView: 0,
            autoclose: 1
        }).on('changeDate', function (e) {
            var dateTime = $('#FechaFallo').val();
            var array = dateTime.split(' ')

            var nuevaFecha = e.date;
            var h = addZero(nuevaFecha.getHours());
            var m = addZero(nuevaFecha.getMinutes());
            var s = addZero(nuevaFecha.getSeconds());
            var time = h + ':' + m + ':' + s
            $('#FechaFallo').val(array[0] + ' ' + time)
        });

    });
});
function addZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}

function actualizarFecha() {
    var array = Array()
    let data_ = $('#GenerarLiquidacionForm').serialize()
    ////console.log(data);
    var token = $("[name='__RequestVerificationToken']").val();
    var data = {
        FechaAutorizacion: moment($('#FechaAutorizacion').val()).format('YYYY-MM-DD'),
        FechaHoraAclaracionDudas: moment($('#FechaHoraAclaracionDudas').val()).format('YYYY-MM-DD hh:mm:ss'),
        IdLicitacion: $('#IdLicitacion').val(),
        IdUnidadLicitadora: $('#IdUnidadLicitadora').val(),
        IdTiempo: $('#IdTiempo').val(),
        IdEjercicioFiscal: $('#IdEjercicioFiscal').val(),
        FechaFallo: moment($('#FechaFallo').val()).format('YYYY-MM-DD hh:mm:ss'),
        __RequestVerificationToken: token
    }

    $.post('/GenerarLicitacion/updateDates/', data, "json")
        .done(function (response) {
            if (response.success) {
                var param1 = $("#IdRequisisicones").val();
                var dat = param1.split(',').join("&id=")
                
                var param2 = $("#IdLicitacion").val();
                var param3 = $("#IdEjercicioFiscal").val();
              

                location.href = '/GenerarLicitacion/Index/?IdLicitacion=' + param2 + '&IdEjercicioFiscal=' + param3 + "&id=" + dat 
            }
            else {
                menssage("Actualizar fechas", "Error: " + response.mensaje);
            }
            
        })
        .fail(function (resp) {
            menssage("Actualizar fechas", "Error: " + response.mensaje);
        })
        .always(function () {

        });
}
function menssage(title, cuerpo) {
    $(".modal-title").html(title);
    $("#titlePopUp").html(cuerpo);
    $("#Pop-Up").modal("show");
}
function configuracionVista() {
    $(function () {
        // Bootstrap DateTimePicker v4
        $('#ssss').datetimepicker({
            language: 'es',
            format: "mm/dd/yyyy",
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            pickTime: false,
            inline: false
        });
    });
    $(function () {
        // Bootstrap DateTimePicker v4
        $('#datetimepickerHoraAclaracionDuda').datetimepicker({
            language: 'es',
            format: "mm/dd/yyyy HH:ii:ss",
            timeFormat: 'hh:ii:ss',
            startView: 0,
            minView: 0,
            autoclose: 1,
            defaultDate: new Date(),
            pickDate: false
        }).on('changeDate', function (e) {
            var dateTime = $('#FechaHoraAclaracionDudas').val();
            var array = dateTime.split(' ')

            var nuevaFecha = e.date;
            var h = addZero(nuevaFecha.getHours());
            var m = addZero(nuevaFecha.getMinutes());
            var s = addZero(nuevaFecha.getSeconds());
            var time = h + ':' + m + ':' + s
            $('#FechaHoraAclaracionDudas').val(array[0] + ' ' + time)
        });
    });

    $(function () {

        // Bootstrap DateTimePicker v4
        $('#datetimepickerHoraFallo').datetimepicker({
            language: 'es',
            format: "mm/dd/yyyy HH:ii:ss",
            pickDate: false,
            pickTime: true,
            timeFormat: 'hh:ii:ss',
            startView: 0,
            minView: 0,
            autoclose: 1
        }).on('changeDate', function (e) {
            var dateTime = $('#FechaFallo').val();
            var array = dateTime.split(' ')

            var nuevaFecha = e.date;
            var h = addZero(nuevaFecha.getHours());
            var m = addZero(nuevaFecha.getMinutes());
            var s = addZero(nuevaFecha.getSeconds());
            var time = h + ':' + m + ':' + s
            $('#FechaFallo').val(array[0] + ' ' + time)
        });

    });
}
function publicar() {

    bootbox.confirm({
        title: "aviso",
        message: "¿Desea publicar la licitación?",
        size: "small",
        callback: function (res) {
            if (res) {
                traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: generarPublicacionLicitacion, b: undefined })
               // traerTokenCapturaGenerico({ "Introduce token", validarTokenGenerico, generarPublicacionLicitacion });
            }
        }
    })

    
}
function generarPublicacionLicitacion() {
    var array = Array()
    let data_ = $('#GenerarLiquidacionForm').serialize()
    ////console.log(data);
    var token = $("[name='__RequestVerificationToken']").val();
    var data = {
        FechaAutorizacion: moment($('#FechaAutorizacion').val()).format('YYYY-MM-DD'),
        FechaHoraAclaracionDudas: moment($('#FechaHoraAclaracionDudas').val()).format('YYYY-MM-DD hh:mm:ss'),
        IdLicitacion: $('#IdLicitacion').val(),
        IdUnidadLicitadora: $('#IdUnidadLicitadora').val(),
        IdTiempo: $('#IdTiempo').val(),
        IdEjercicioFiscal: $('#IdEjercicioFiscal').val(),
        FechaFallo: moment($('#FechaFallo').val()).format('YYYY-MM-DD hh:mm:ss'),
        __RequestVerificationToken: token
    }

    $.post('/GenerarLicitacion/publicar/', data, "json")
        .done(function (response) {
            if (response.success) {
                mensajeGenerico("Aviso", "Se ha generado la solicitud número " + response.objeto.FolioOficial+" correctamente.","1")
            }
            else {
                menssage("Publicar", "Error: " + response.mensaje);
            }

        })
        .fail(function (resp) {
            menssage("Publicar", "Error: " + response.mensaje);
        })
        .always(function () {

        });
}
function regresar() {
    location.href = '/ListadoLicitaciones/Index/';
}

//impresión de bases
function ImprimirBases() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLicitacion").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };
    

    $.ajax({
        data: parametros,
        url: '/GenerarLicitacion/ImprimirBases/',
        type: 'post',
        beforeSend: function () {
            //mostrar modal loading
            $("#modal_loading").modal('show');
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                //éxito
              
                var base_url = window.location.origin + "/Files/Reportes/" + response.Descarga;
                window.setTimeout(function () { $('#modal_loading').modal('hide'); window.open(base_url); }, 1000);
            }
            else {
                
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');      
                //ocultar modal loading
                $('#modal_loading').modal('hide');
            }
            
        }
    });
}

//impresión de Convocatoria
function ImprimirConvocatoria() {
    var token = $("[name='__RequestVerificationToken']").val();
    var IdLic = $("#IdLicitacion").val();
    var parametros = {
        pIdLic: IdLic,
        __RequestVerificationToken: token
    };
 

    $.ajax({
        data: parametros,
        url: '/GenerarLicitacion/ImprimirConvocatoria/',
        type: 'post',
        beforeSend: function () {
            //mostrar modal loading
            $("#modal_loading").modal('show');
        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                //éxito
                var base_url = window.location.origin + "/Files/Reportes/" + response.Descarga;
                window.setTimeout(function () { $('#modal_loading').modal('hide'); window.open(base_url); }, 1000);
            }
            else {
                //ocultar modal loading
                $('#modal_loading').modal('hide');
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');                
            }
            
        }
    });
}