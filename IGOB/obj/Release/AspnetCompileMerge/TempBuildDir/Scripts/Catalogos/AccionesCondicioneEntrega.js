$(document).ready(function () {
    $('#tableCondicionEntrega').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false
    });
});

//Abrir modal editItem
$('#tableCondicionEntrega').on('click', '.edit-item', function () {
    //$('#').show();//campos para visualizar en caso de que se oculten al crear
    
    $("#IdCondicion").val($(this).attr('data-idCond').trim());//campos a  vaciar
    $("#IdTipoCondicion").val($(this).attr('data-idTipoCond').trim());//campos a  vaciar
    $("#Condicion").val($(this).attr('data-cond').trim());//campos a  vaciar
    $("#Activo").val($(this).attr('data-activ').trim());//campos a  vaciar

    $("#submit").prop("value", "Editar");//cambiar el valor del imput en caso de editar
    $('#formEditCreate').html('Editar Condiciones Entrega');//insertar datos en el header del modal
    $("#modalCondicionesEntrega").modal("show");//modal crear editar para desplegar
});

$('#create-item').on('click', function () {
    //$("#").val("");//campos a  vaciar
    //$('#').hide();//campos para ocultar en caso de que se oculten al crear
    $("#submit").prop("value", "Guardar");//cambiar las propiedades del boton
    $('#formEditCreate').html('Nuevo Condiciones Entrega');//insertar datos en el header del modal
    $("#modalCondicionesEntrega").modal("show");//modal crear editar para desplegar
});

//Modal Confirmar Edicion de Eliminacion
$('#tableCondicionEntrega').on('click', '.delet-item', function (d) {//tabla catalogo para recorrer cada elemento con clase delet-item
    d.preventDefault();
    $('#formDelete').html('Eliminar Condiciones De Entrega')
    $("#deleteId").val($(this).attr('data-idCond').trim());//traer el id y guardarlo en un input type hidden
    $("#ConfirDelete").html(`Se eliminara La condicion: ${$(this).attr('data-cond').trim()}`);//mostar datos del elemento a eliminar
    $("#DeleteCondionesEntrega").modal("show");//mostar modal delete

})

$("#modalCondicionesEntrega").on('submit', function (e) {//modal para editar crear
    e.preventDefault();
    let datos = $('.FormCondiciones').serialize();//obtener datos y guardar los datos
    var tipo = $("#submit").prop("value");
    //console.log(datos)
    if (tipo === "Editar") {
        //console.log('Entro a editar')
        $.post("/CondicionesEntrega/Edit/", //url del metodo editar
            datos
            , "JSON")
            .done(function (response) {
                $('#MensajeForm').html(response)//id del DOM para insertar el mensaje
                $("#modalCondicionesEntrega").modal("hide");//ocultar modal
                setTimeout(function () { location.reload() }, 1000)//tiempo de ejecucion
                
            })
    }
    if (tipo === "Guardar") {
        //console.log('Entro a Crear')
        $.post("/CondicionesEntrega/Create/", //url del metodo crear
            datos
            , "JSON")
            .done(function (response) {
                $('#MensajeForm').html(response)//mostrar mensaje en un div
                $("#modalCondicionesEntrega").modal("hide");//ocultar el modal editar crear
                setTimeout(function () { location.reload() }, 1000)//tiempo para la ejecucion
            })
    }
    return false;
})

//Eliminar
$("#DeleteCondionesEntrega").on('submit', function (dl) {//id del modal eliminar
    dl.preventDefault();
    var IdCond = $("#deleteId").val();//valor del id para eliminar
    //console.log(`Entro a Eliminar con id:  ${IdCond}`)
    $.post('/CondicionesEntrega/Delete/',//direccion o url del metodo delete
        { id:IdCond },
        "json"
    ).done(function (response) {
        $('#MensajeDelete').html(response)//colocar mensaje de response
        $("#DeleteCondionesEntrega").modal("hide");//esconder modal
        setTimeout(function () { location.reload(); }, 1000)//tiempo para mostrar un texto
    })
})
