$(document).ready(function () {
    $('#ReactivosConclusionEMTable').DataTable({
        scrollY: "450px",
        scrollX: true,
        scrollCollapse: true,
        "language": {
            "emptyTable": ""
        },
        initComplete: function (settings, json) {
            setTimeout(function () { $("#ReactivosConclusionEMTable").DataTable().draw(); }, 200);
        }
    }).draw();
    
});

function editReactivo(IdReactivoConclusionEM) {


    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        data: { pIdReactivosConclusionEM: IdReactivoConclusionEM, __RequestVerificationToken: token },
        url: '/ReactivosConclusionEM/getReactivo',
        type: 'post',
        beforeSend: function () {
            
        },
        success: function (response) {

            if (response != "") {

                $("#CargarReactivoResultado").html("");
                $("#CargarReactivoResultado").html(response);
                $("#modal_nuevo_reactivo").modal("show");
            }
            else {
                mensajeGenerico("Aviso", response.data, "");
              
            }

        }
    });


}
function saveEditLoteConfirm() {
    jQuery.validator.messages.required = 'Este campo es obligatorio.';
    jQuery.validator.messages.number = 'Este campo debe ser num&eacute;rico.';
    jQuery.validator.messages.email = 'La direcci&oacute;n de correo es incorrecta.';
    jQuery.validator.messages.text = 'Este campo es obligatorio';
    var validado = true;
    validado = $("#frmReactivo").valid();
    if (validado) {
        saveReactivo();
    }
}
function saveReactivo() {

    var IdReactivoConclusionEM_ = $("#IdReactivoConclusionEM").val();
    var url_ = "";
    if (IdReactivoConclusionEM_ == "0") {
        url_ = "/ReactivosConclusionEM/saveReactivosConclusionEM";
    }
    else {
        url_ = "/ReactivosConclusionEM/updateReactivosConclusionEM";
    }
    var activo_ = $('input:radio[name=Activo]:checked').val() == "0" ? false : true;
    var token = $("[name='__RequestVerificationToken']").val();
    var fileData = new FormData();
    fileData.append("IdReactivoConclusionEM", IdReactivoConclusionEM_)
    fileData.append("Reactivo", $("#Reactivo").val())
    fileData.append("Activo", activo_)
    fileData.append("__RequestVerificationToken", token)
  
    $.ajax({
        url: url_,
        type: "POST",
        processData: false,
        data: fileData,
        dataType: 'json',
        contentType: false,
        success: function (response) {
            
            if (response.success) {
                mensajeGenerico("Aviso", 'Datos guardados correctamente', "");
                $('#ReactivosConclusionEMTable').dataTable({
                    "bDestroy": true
                }).fnDestroy();

                $('#ReactivosConclusionEMTable').dataTable().fnDestroy();
                $("#ReactivosConclusionEMLoad").load(" #ReactivosConclusionEMLoad", function () {

                    $('#ReactivosConclusionEMTable').DataTable({
                        scrollY: "450px",
                        scrollX: true,
                        scrollCollapse: true,
                        "language": {
                            "emptyTable": ""
                        }
                    });
                    $("#modal_nuevo_reactivo").modal("hide");
                })
            }
            else {
                mensajeGenerico("Aviso", '<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >', "");
                
            }

        },
        error: function (response) {
            mensajeGenerico( "Aviso","Error pagina: " + response.responseText, "");
        }
    });
}
