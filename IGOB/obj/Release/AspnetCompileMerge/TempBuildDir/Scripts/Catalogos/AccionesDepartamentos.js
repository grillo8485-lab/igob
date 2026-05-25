$(document).ready(function () {
    $('#tableDeptos').DataTable({
        scrollY: "280px",
        scrollX: true,
        scrollCollapse: true,
        "bSort": false
    });
});


//Abrir modal editItem
$('#tableDeptos').on('click', '.edit-depto', function () {
    let idDepartamento = $(this).attr('data-IdDepartamento').trim()
    $.get(
        "/Departamentos/TraerDepartamento",
        { pidDepartamento:idDepartamento },
        "json"
    ).done(function (data) {
        $('#formDepto').find(':input').each(function () {
            var elemento = this;
            if (data[elemento.id] != null) {
                switch (elemento.id) {
                    
                    default:
                        elemento.value = data[elemento.id]
                        break;
                }
            }
        });
    })
    $("#submitform").prop("value", "Editar");
    $('#formEditCreate').text(`Editar Departamento`);
    $("#EditDeptoModal").modal("show");
});

$('#create-item').on('click', function () {
    $("#formDepto")[0].reset()
    $("#submitform").prop("value", "Guardar");
    $('#formEditCreate').text(`Nuevo Departamento`)
    $("#EditDeptoModal").modal("show");
});

$("#EditDeptoModal").on('submit', function (e) {//modal para editar crear
    e.preventDefault();
    let data = $('#formDepto').serialize().trim();
    var tipo = $("#submitform").prop("value");
    //console.log(`entro ${tipo}`)
    if (tipo === "Editar") {
        //console.log(`entro a editar ${data}`)
        $.post("/Departamentos/Edit/", //url del metodo editar
            data.trim(),
            "JSON")
            .done(function (response) {
                $('#MensajeForm').text(response)
                setTimeout(function () { location.reload(); }, 1000)
                //$("#EditDeptoModal").modal("hide");//ocultar modal
            })
    }
    if (tipo === "Guardar") {
        //console.log(`entro a Crear ${data}`)
        $.post("/Departamentos/Create/", //url del metodo crear
            data.trim()
            , "JSON")
            .done(function (response) {
                $('#MensajeForm').text(response)
                setTimeout(function () { location.reload(); }, 1000)
                //$("#EditDeptoModal").modal("hide");//ocultar el modal editar crear
            })
    }
    return false;
})

//Modal Confirmar Edicion de Eliminacion
$('#tableDeptos').on('click', '.delete-depto', function (d) {//tabla catalogo para recorrer cada elemento con clase delet-item
    d.preventDefault();
    $("#delete_IdDepartamento").val($(this).attr('data-IdDepartamento').trim());
    $('#DeleteTitle').text(`Eliminar Departamento`);//insertar datos en el header del modal
    $('#titleDepto').html(`¿Desea Eliminar el Departamento "${$(this).attr('data-Departamento')}"?`)
    $("#DeleteDeptoModal").modal("show");
})

$('#DeleteDeptoModal').on('submit', function () {
    //console.log(`entro a eliminar`)
    let id_delete = $("#delete_IdDepartamento").val();//valor del id para eliminar
    var token = $("[name='__RequestVerificationToken']").val();
    //console.log(id_delete)
    $.post('/Departamentos/Delete/',//direccion o url del metodo delete
        { pIdDepartamento: id_delete, __RequestVerificationToken: token },
        "json"
    ).done(function (response) {
        $('#MensajeDelete').html(response)//colocar mensaje de response
        setTimeout(function () { location.reload(); }, 1000)
        //$("#DeleteDeptoModal").modal("hide");//esconder modal
    })
    return false;
})

/*





$("#ClaveEstado").on("change", function () {
    buscarMunicipio(0)
})

function buscarMunicipio(idmun) {

    $.get("/ProveedoresMenores/MunicipioById/",
        { id: $("#ClaveEstado").val().trim() },
        "json"
    ).done(function (result) {
        $('#IdMunicipio').empty();
        $('#IdMunicipio').append(`<option value="0">Seleccione Un Municipio</option>`)
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
*/