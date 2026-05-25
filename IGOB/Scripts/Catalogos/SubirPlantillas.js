function NuevaPlantilla() {
    $("#formPlantilla")[0].reset();
    $("#IdPlantilla").val('0');

    $("#modal_editar_plantilla").modal("show");
    $("#IdTipoUsoPlantilla").attr('required', '');
    $("#IdTipoUsoPlantilla").show();

    //ocultamos el input informativo
    $("#TipoUso").hide();
}


function TraerPlantilla(IdPlantilla) {

    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdPlantilla: IdPlantilla,
        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/SubirPlantillas/TraerPlantilla/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                var objeto = response.objeto;
               
                //$("#IdTipoUsoPlantilla").val(objeto.IdTipoUsoPlantilla);
                $('#IdTipoUsoPlantilla').removeAttr('required');
                $("#IdTipoUsoPlantilla").hide();

                $("#IdPlantilla").val(objeto.IdPlantilla);
                $("#TipoUso").val(objeto.TipoUso);
                $("#TipoUso").show();

                $("#NombreArchivo").val(objeto.NombreArchivo);
                $("#Descripcion").val(objeto.Descripcion);

                $("#modal_editar_plantilla").modal("show");
            }
            else {
                $("#MensajeForm").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}


function validarFormularioPlantilla() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser numérico.';
    jQuery.validator.messages.email = 'La dirección de correo es incorrecta.';
    //revisamos que se llenaron los campos requeridos
    var validado = $("#formPlantilla").valid();

    if (validado) {
        //guardamos los datos y el archivo
        var fileUpload = $("#FileUpload1").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append("HelpSectionImages", files[i]);
        }  


        
        var IdPlantilla = $("#IdPlantilla").val();
        //var TipoUso = $("#TipoUso").val();


        //obtenemos el tipo de uso a enviar dependiendo si es una plantilla existente
        if (IdPlantilla > 0) {
            var IdTipoUsoPlantilla = 0;
        } else {
            var IdTipoUsoPlantilla = $("#IdTipoUsoPlantilla").val();
        }        

        var NombreArchivo = $("#NombreArchivo").val();
        var Descripcion = $("#Descripcion").val();
        var token = $("[name='__RequestVerificationToken']").val();

        fileData.append("IdTipoUsoPlantilla", IdTipoUsoPlantilla);
        fileData.append("IdPlantilla", IdPlantilla);
        //fileData.append("TipoUso", TipoUso);
        fileData.append("NombreArchivo", NombreArchivo);
        fileData.append("Descripcion", Descripcion);
        fileData.append("__RequestVerificationToken", token);

        console.log(fileData);
        //enviamos los datos
        $.ajax({
            url: '/SubirPlantillas/UploadFiles/', type: "POST", processData: false,
            data: fileData, dataType: 'json',
            contentType: false,
            success: function (response) {
                if (response.success) {
                    $("#modal_guardar_plantilla").modal("hide");
                    $("#MensajeForm").html('<div class="alert alert-success" role="alert"> Plantilla actualizada</div >');
                    setTimeout(function () { location.reload(); }, 1000);
                }
                else {
                    $("#MensajeForm").html('<div class="alert alert-danger" role="alert"> Error: ' + response.Mensaje + '</div >');
                    $("#modal_guardar_plantilla").modal("hide");
                }

            },
            error: function (response) {
                $("#MensajeForm").html('<div class="alert alert-danger" role="alert"> Error: ' + response.responseText + '</div >');
                $("#modal_guardar_plantilla").modal("hide");
            }

        });

    } else {
        //hace falta validar algun campo
        $("#modal_guardar_plantilla").modal("hide");
    }
}


function BorraPlantilla() {
    var token = $("[name='__RequestVerificationToken']").val();
    var parametros = {
        pIdPlantilla: $("#IdPlantillaBorrar").val(),

        __RequestVerificationToken: token
    };

    $.ajax({
        data: parametros,
        url: '/SubirPlantillas/EliminarPlantilla/',
        type: 'post',
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response);
            if (response.success) {
                $("#MensajeDelete").html('<div class="alert alert-danger" role="alert"> Plantilla eliminada</div >');
                setTimeout(function () { location.reload(); }, 1000);
            }
            else {
                $("#MensajeDelete").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}

function confirmaEliminarPlantilla(IdPlantilla,TipoUso) {
    $("#IdPlantillaBorrar").val(IdPlantilla);
    $("#TipoUsoBorrar").html(TipoUso);
}