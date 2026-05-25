$(document).ready(function () {
    $('#tableprovmen').DataTable({
        scrollY: 340,
        scrollX: true,
        sort: false
     });
});

function verProv(idProveedor) {
    $(".addIdProv").removeClass("d-none");

    $(".addIdProv").each(function () {
        var $this = $(this);
        var _href = $this.attr("href");
        let route = _href.trim().split("/");
        let newroute = "/" + route[1] + "/" + route[2] + "/" + idProveedor;
        console.log(newroute);
        $this.attr("href", newroute);
    });
} 


function rfcValido(rfc, aceptarGenerico = true) {

    var TipoPersona = $("#TipoPersona").val();
    

    const re =  /^([a-zñ&A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([a-zA-Z\d]{2})([aA\d])$/;
    var   validado = rfc.match(re);

    if (!validado)  //Coincide con el formato general del regex?
    {
        bootbox.alert({
            size: "small",
            title: "Aviso",
            message: "Ingrese un RFC valido",
            callback: function () {
                $("#submitform").attr("disabled", "disabled");
            }
        });
    } else
        $("#submitform").removeAttr("disabled");

    
    ////Separar el dígito verificador del resto del RFC
    //const digitoVerificador = validado.pop(),
    //      rfcSinDigito      = validado.slice(1).join(''),
    //      len               = rfcSinDigito.length,

    ////Obtener el digito esperado
    //      diccionario       = "0123456789ABCDEFGHIJKLMN&OPQRSTUVWXYZ Ñ",
    //      indice            = len + 1;
    //var   suma,
    //      digitoEsperado;

    //if (len == 12) suma = 0;
    //else suma = 481; //Ajuste para persona moral

    //for(var i=0; i<len; i++)
    //    suma += diccionario.indexOf(rfcSinDigito.charAt(i)) * (indice - i);
    //digitoEsperado = 11 - suma % 11;
    //if (digitoEsperado == 11) digitoEsperado = 0;
    //else if (digitoEsperado == 10) digitoEsperado = "A";

    ////El dígito verificador coincide con el esperado?
    //// o es un RFC Genérico (ventas a público general)?
    //if ((digitoVerificador != digitoEsperado) && (!aceptarGenerico || rfcSinDigito + digitoVerificador != "XAXX010101000"))
    //    return false;
    //else if (!aceptarGenerico && rfcSinDigito + digitoVerificador == "XEXX010101000")
    //    return false;
    //return rfcSinDigito + digitoVerificador;
}

//Abrir modal editItem
$('#tableprovmen').on('click', '.edit-prov', function () {
    let prov = $(this).attr('data-idProveedor').trim();
    $("#ClaveEstado").val($(this).attr('data-estado').trim());
    $.get(
        "/ProveedoresMenores/getProvedores",
        { id: prov },
        "json"
    ).done(function (data) {
        $('#formProvMen').find(':input').each(function () {
            var elemento = this;
            if (data[elemento.id] != null) {
                switch (elemento.id) {
                    case "IdMunicipio":
                        buscarMunicipio($.trim(data[elemento.id]));
                        break;
                    case "CodigoPostal":
                        elemento.value = parseInt($.trim(data[elemento.id]));
                        break;
                    default:
                        elemento.value = data[elemento.id];
                        break;
                }
            }
        });
        });

    $("#submitform").prop("value", "Editar");
    let titulo = $('#TipoProveedor').val() == 1 ? 'Menor' : 'General';
    $('#formEditCreate').text(`Editar Proveedor ${titulo}`);
    $("#ProvModal").modal("show");
});

$('#create-item').on('click', function () {
    $("#formProvMen")[0].reset();
    $("#submitform").prop("value", "Guardar");
    let titulo = $('#TipoProveedor').val() == 1 ? 'Menor' : 'General';
    $('#formEditCreate').text(`Nuevo Proveedor ${titulo}`);
    $("#ProvModal").modal("show");
});

$('#tableprovmen').on('click', '.delete-prov', function (d) {//tabla catalogo para recorrer cada elemento con clase delet-item
    d.preventDefault();
    $("#deleteId").val($(this).attr('data-idProveedor').trim());
    let titulo = $('#TipoProveedor').val() == 1 ? 'Menor' : 'General';
    bootbox.confirm({
        title: "Eliminar proveedor " + titulo,
        message: `¿Desea Eliminar Proveedor menor "${$(this).attr('data-nombre')}"?`,
        size: 'small',
        callback: function (res) {
            if (res) {
                let id_delete = $("#deleteId").val();
                var token = $("[name='__RequestVerificationToken']").val();
                $.post('/ProveedoresMenores/Delete/',
                    { id: id_delete, __RequestVerificationToken: token },
                    "json"
                ).done(function (response) {
                    bootbox.alert({
                        title: "Eliminar proveedor " + titulo,
                        message: response,
                        size: 'small',
                        callback: function () {
                            location.reload();
                        }
                    });
                });
            }
        }
    });
});

$("#ProvModal").on('submit', function (e) {
    e.preventDefault();
    let data = $('#formProvMen').serialize().trim();
    var tipo = $("#submitform").prop("value");
    if (tipo === "Editar") {
        $.post("/ProveedoresMenores/Edit/",data,"JSON")
            .done(function (response) {
                let titulo = $('#TipoProveedor').val() == 1 ? 'Menor' : 'General';
                $("#ProvModal").modal("hide");
                bootbox.alert({
                    title: "Editar proveedor " + titulo,
                    message: response,
                    size: "small",
                    callback: function () {
                        location.reload();
                    }
                });
            });
    }
    if (tipo === "Guardar") {
        $.post("/ProveedoresMenores/Create/",data, "JSON")
            .done(function (response) {
                let titulo = $('#TipoProveedor').val() == 1 ? 'Menor' : 'General';
                $("#ProvModal").modal("hide");
                bootbox.alert({
                    title: "Nuevo proveedor " + titulo,
                    message: response,
                    size: "small",
                    callback: function () {
                        location.reload();
                    }
                });
            });
    }
    return false;
});

$("#ClaveEstado").on("change", function () {
    buscarMunicipio(0);
});

function buscarMunicipio(idmun) {

    $.get("/ProveedoresMenores/MunicipioById/",
        { id: $("#ClaveEstado").val().trim() },
        "json"
    ).done(function (result) {
        $('#IdMunicipio').empty();
        $('#IdMunicipio').append(`<option value="0">Seleccione Un Municipio</option>`);
        $.each(result, function (index, row) {
            if (idmun == 0) {
                $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" data-ClaveEstado="${row.ClaveEstado}">${row.Municipio}</option>`);
            } else {
                if (row.IdMunicipio.trim() == idmun.trim()) {
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" data-ClaveEstado="${row.ClaveEstado}" selected="selected">${row.Municipio}</option>`);
                } else {
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" data-ClaveEstado="${row.ClaveEstado}">${row.Municipio}</option>`);
                }
            }
        });
    });
}
