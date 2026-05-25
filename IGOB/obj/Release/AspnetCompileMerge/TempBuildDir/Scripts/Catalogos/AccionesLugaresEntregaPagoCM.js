$(document).ready(function () {
    $('#tableLugares').DataTable({
        scrollX: true
    });
});


//Abrir modal editItem
$('#tableLugares').on('click', '.edit-lugar', function () {
    let IdLugarEntregaPago = $(this).attr('data-IdLugarEntregaPago').trim()
    $.get(
        "/LugaresEntregaPagoCM/TraerLugaresEntregaPago",
        { pIdLugarEntregaPago: IdLugarEntregaPago },
        "json"
    ).done(function (data) {
        $('#formLugar').find(':input').each(function () {
            var elemento = this;
            if (data[elemento.id] != null) {
                switch (elemento.id) {
                    case "IdMunicipio":
                        buscarMunicipio((data[elemento.id]).trim())
                        break;
                    default:
                        elemento.value = data[elemento.id]
                        break;
                }
            }
        });
        console.log(data);
    })
    $("#submitform").prop("value", "Editar");
    $('#formEditCreate').text(`Editar Lugar Entrega/Pago`);
    $("#EditLugarModal").modal("show");
});

$('#create-item').on('click', function () {
    $("#formLugar")[0].reset()
    $("#submitform").prop("value", "Guardar");
    $('#formEditCreate').text(`Nuevo Lugar Entrega/Pago`)
    $("#EditLugarModal").modal("show");
});

$("#EditLugarModal").on('submit', function (e) {//modal para editar crear
    e.preventDefault();
    let data = $('#formLugar').serialize().trim();
    var tipo = $("#submitform").prop("value");
    //console.log(`entro ${tipo}`)
    if (tipo === "Editar") {
        //console.log(`entro a editar ${data}`)
        $.post("/LugaresEntregaPagoCM/Edit/", //url del metodo editar
            data.trim(),
            "JSON")
            .done(function (response) {
                $('#MensajeForm').text(response)
                setTimeout(function () { location.reload(); }, 1000)
                //$("#EditLugarModal").modal("hide");//ocultar modal
            })
    }
    if (tipo === "Guardar") {
        //console.log(`entro a Crear ${data}`)
        $.post("/LugaresEntregaPagoCM/Create/", //url del metodo crear
            data.trim()
            , "JSON")
            .done(function (response) {
                $('#MensajeForm').text(response)
                setTimeout(function () { location.reload(); }, 1000)
                //$("#EditLugarModal").modal("hide");//ocultar el modal editar crear
            })
    }
    return false;
})

//Modal Confirmar Edicion de Eliminacion
$('#tableLugares').on('click', '.delete-lugar', function (d) {//tabla catalogo para recorrer cada elemento con clase delet-item
    d.preventDefault();
    $("#delete_IdLugarEntregaPago").val($(this).attr('data-IdLugarEntregaPago').trim());
    $('#DeleteTitle').text(`Eliminar Lugar de Entrega/Pago`);//insertar datos en el header del modal
    $('#titleLugar').html(`¿Desea Eliminar el Lugar "${$(this).attr('data-Lugar')}"?`)
    $("#DeleteLugarModal").modal("show");
})

$('#DeleteLugarModal').on('submit', function () {
    //console.log(`entro a eliminar`)
    let id_delete = $("#delete_IdLugarEntregaPago").val();//valor del id para eliminar
    var token = $("[name='__RequestVerificationToken']").val();
    //console.log(id_delete)
    $.post('/LugaresEntregaPagoCM/Delete/',//direccion o url del metodo delete
        { pIdLugarEntregaPago: id_delete, __RequestVerificationToken: token },
        "json"
    ).done(function (response) {
        $('#MensajeDelete').html(response)//colocar mensaje de response
        setTimeout(function () { location.reload(); }, 1000)
        //$("#DeleteLugarModal").modal("hide");//esconder modal
    })
    return false;
})


$("#ClaveEstado").on("change", function () {
    buscarMunicipio(0)
})

function buscarMunicipio(idmun) {

    $.get("/LugaresEntregaPagoCM/MunicipioByClaveEstado/",
        { pClaveEstado: $("#ClaveEstado").val().trim() },
        "json"
    ).done(function (result) {
        $('#IdMunicipio').empty();
        $('#IdMunicipio').append(`<option value="0">Seleccione un Municipio</option>`)
        $.each(result, function (index, row) {
            if (idmun == 0) {
                $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" data-ClaveEstado="${row.ClaveEstado}">${row.Municipio}</option>`)
            } else {
                if (row.IdMunicipio.trim() == idmun.trim()) {
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" data-ClaveEstado="${row.ClaveEstado}" selected="selected">${row.Municipio}</option>`)
                } else {
                    $('#IdMunicipio').append(`<option value="${row.IdMunicipio.trim()}" data-ClaveEstado="${row.ClaveEstado}">${row.Municipio}</option>`)
                }
            }
        })
    })
}