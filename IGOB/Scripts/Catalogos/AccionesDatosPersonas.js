$(document).ready(function () {
    $('#tableDatosPersona').DataTable({
        scrollY: 340,
        scrollCollapse: true,
        sort: false
    });

    $('#FechaNacimiento').datetimepicker({
        language: 'es',
        todayHighlight: true,
        todayBtn: true,
        autoclose: true,
        format: "yyyy-mm-dd",
        startView: 4,
        minView: 2,
        maxView: 4,
    });
});
$('#tableDatosPersona').on('click', '.edit-datper', function () {
    $('#DivDependencia,#DivProveedor').css('display', 'none')
    $('#formDatosPersona')[0].reset()
    $('#IdPersona').val($(this).attr('data-IdPersona').trim());
    $('#Apellidos').val($(this).attr('data-Apellidos').trim());
    $('#Nombres').val($(this).attr('data-Nombres').trim());
    $('#FechaNacimiento').val(formatDateTimeLocal($(this).attr('data-FechaNacimiento').trim(), 1));
    checkradio($(this).attr('data-Sexo').trim(),'Sexo')
    $('#EntFedNacimiento').val($(this).attr('data-EntFedNacimiento').trim());
    buscarMunicipio(0)
    $('#Curp').val($(this).attr('data-Curp').trim());
    $('#Rfc').val($(this).attr('data-Rfc').trim());
    $('#Telefono').val($(this).attr('data-Telefono').trim());
    $('#Celular').val($(this).attr('data-Celular').trim());
    $('#CorreoElectronico').val($(this).attr('data-CorreoElectronico').trim());
    $('#Calle').val($(this).attr('data-Calle').trim());
    $('#NoExterior').val($(this).attr('data-NoExterior').trim());
    $('#NoInterior').val($(this).attr('data-NoInterior').trim());
    $('#Localidad').val($(this).attr('data-Localidad').trim());
    getMuniniciobycol($(this).attr('data-IdColonia').trim())
    $('#CodigoPostal').val($(this).attr('data-CodigoPostal').trim());
    checkradio($(this).attr('data-EstadoCivil').trim().toUpperCase(), 'EstadoCivil')
    checkradio($(this).attr('data-Nacionalidad').trim(), 'Nacionalidad')
    $('#IdDependencia').val($(this).attr('data-IdDependencia').trim());
    $('#IdProveedor').val($(this).attr('data-IdProveedor').trim());
    $('#IdEstatus').val($(this).attr('data-IdEstatus').trim());
    $('#IdTipoPersona').val($(this).attr('data-IdTipoPersona').trim());
    $('#IdUsuarioRegistro').val($(this).attr('data-IdUsuarioRegistro').trim());
    $('#FechaRegistro').val(formatDateTimeLocal($(this).attr('data-FechaRegistro').trim(), 1));
    
    if ($(this).attr('data-IdTipoPersona').trim() == 2) {
        $('#DivDependencia').css('display', 'block')
    }
    if ($(this).attr('data-IdTipoPersona').trim() == 3) {
        $('#DivProveedor').css('display','block')
    }

    $("#submit").prop("value", "Editar");
    $('#formEditCreate').html('Editar Persona');
    $("#ModalDatosPersona").modal({ backdrop: 'static', keyboard: false },"show");
});

$('#create-item').on('click', function () {
    $('#formDatosPersona')[0].reset()
    $('#DivDependencia,#DivProveedor').css('display', 'none')
    $("#submit").prop("value", "Guardar");
    $('#formEditCreate').html('Nueva Persona');
    $("#ModalDatosPersona").modal({ backdrop: 'static', keyboard: false },"show");
});

$('#tableDatosPersona').on('click', '.delete-datper', function (d) {
    d.preventDefault();
    const id = $(this).attr('data-id').trim()
    bootbox.confirm({
        title: "Aviso",
        message: `¿Desea eliminara La Persona: ${$(this).attr('data-name')}?`,
        size: "small",
        callback: function (res) {
            if (res) {
                const token = $("input[name='__RequestVerificationToken']").val();
                $.post('/DatosPersonas/Delete',
                    { id: id, __RequestVerificationToken: token },
                    "json"
                )
                    .done(function (response) {
                        bootbox.alert({
                            title:"Aviso",
                            message: response.message,
                            size: "small",
                            callback: function () {
                                location.reload()
                            }
                        })
                    })
                    .fail(function (jqXHR, textStatus, errorThrown) {
                        bootbox.alert({
                            title: "Aviso",
                            message: `${jqXHR} ${textStatus} ${errorThrown}`,
                            size: "small",
                            callback: function () {
                                location.reload()
                            }
                        })
                    });
            }
        }
    })

})

$("#ModalDatosPersona").on('submit', function (e) {
    bootbox.confirm({
        title: "Aviso",
        message: "¿Desea agregar persona?",
        size: "small",
        callback: function (res) {
            if (res) {
                e.preventDefault();
                let datos = $('#formDatosPersona').serialize();
                var tipo = $("#submit").prop("value");
                if (tipo === "Editar") {
                    $.post("/DatosPersonas/Edit/",
                        datos
                        , "JSON")
                        .done(function (response) {
                            if (response.success) {
                                bootbox.alert({
                                    title: "Aviso",
                                    message: response.message,
                                    size: "small",
                                    callback: function () {
                                        location.reload()
                                    }
                                })
                            } else {
                                bootbox.alert({
                                    title: "Aviso",
                                    message: response.message,
                                    size: "small",
                                    callback: function () {
                                        location.reload()
                                    }
                                })
                            }

                        })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                            bootbox.alert({
                                title: "Aviso",
                                message: `${jqXHR} ${textStatus} ${errorThrown}`,
                                size: "small",
                                callback: function () {
                                    location.reload()
                                }
                            })
                        });
                }
                if (tipo === "Guardar") {
                    $.post("/DatosPersonas/Create/",
                        datos
                        , "JSON")
                        .done(function (response) {
                            bootbox.alert({
                                title: "Aviso",
                                message: response.message,
                                size: "small",
                                callback: function () {
                                    location.reload()
                                }
                            })
                        })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                            bootbox.alert({
                                title: "Aviso",
                                message: `${jqXHR} ${textStatus} ${errorThrown}`,
                                size: "small",
                                callback: function () {
                                    location.reload()
                                }
                            })
                        });
                }
            }
        }
    })
    return false;
})

$('#EntFedNacimiento').on('change', function () {
    buscarMunicipio(0)
})

function buscarMunicipio(idmun) {
    let claveestado = $('#EntFedNacimiento').val();
    $.get('/DatosPersonas/GetMunicipios/',
        { claveestado: claveestado },
        "json"
    ).done(function (response) {
        $('#Municipio').empty();
        $('#Municipio').append(`<option value="0">Seleccione Un Municipio</option>`)
        $.each(response, function (index, row) {
            if (idmun == 0) {
                $('#Municipio').append(`<option value="${row.IdMunicipio.trim()}">${row.Municipio}</option>`)
            } else {
                if (row.IdMunicipio.trim() == idmun.trim()) {
                    $('#Municipio').append(`<option value="${row.IdMunicipio.trim()}" selected="selected">${row.Municipio}</option>`)
                } else {
                    $('#Municipio').append(`<option value="${row.IdMunicipio.trim()}">${row.Municipio}</option>`)
                }
            }
        })
    })
}

$('#Municipio').on('change', function () {
    buscarColonia(0)
})

function buscarColonia(idCol) {
    let idmun = $('#Municipio').val();
    if (idmun) {
        $.get('/DatosPersonas/GetColonias/',
            { IdMunicipio: (idmun).trim() },
            "json"
        ).done(function (response) {
            $('#IdColonia').empty();
            $('#IdColonia').append(`<option value="0">Seleccione Una Colonia</option>`)
            $.each(response, function (index, row) {
                if (idCol == 0) {
                    $('#IdColonia').append(`<option value="${row.IdColonia.trim()}">${row.Colonia}</option>`)
                } else {
                    if (row.IdColonia.trim() == idCol.trim()) {
                        $('#IdColonia').append(`<option value="${row.IdColonia.trim()}" selected="selected">${row.Colonia}</option>`)
                    } else {
                        $('#IdColonia').append(`<option value="${row.IdColonia.trim()}">${row.Colonia}</option>`)
                    }
                }
            })
        })
    }
}

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

function checkradio(dato,nameInput) {
    $(`input[name='${nameInput}']`).each(function () { ($(this).val() == dato) ? $(this).prop('checked', 'checked') : "" })
}

function getMuniniciobycol(col) {
    $.get('/DatosPersonas/GetMunicipio_idColonia', { idColonia: col }, "json")
        .done(function (resp) {
            if (resp != 0) {
                $('#Municipio').val(resp.trim()).attr('selected', true)
                buscarColonia(col)
            }
        })
}

$('#IdTipoPersona').on('change', function () {
    let tipoPer = $('#IdTipoPersona').val();
    switch (tipoPer.trim()) {
        case "1":
            $('#DivDependencia,#DivProveedor').css('display', 'none');
            $('#IdDependencia,#IdProveedor').removeAttr('name');
            $('#datnull').html(`<input type="hidden" id="IdDependencia2" name="IdDependencia" value="0" /><input type="hidden" id="IdProveedor2" name="IdProveedor" value="0" />`)
            break;
        case "2":
            $('#DivDependencia').css('display', 'block');
            $('#DivProveedor').css('display', 'none');
            $('#IdProveedor').attr('name', 'IdProveedor');
            $('#datnull').html(`<input type="hidden" id="IdProveedor2" name="IdProveedor" value="0" />`)
            break;
        case "3":
            $('#DivProveedor').css('display', 'block');
            $('#DivDependencia').css('display', 'none');
            $('#IdDependencia').attr('name', 'IdDependencia');
            $('#datnull').html(`<input type="hidden" id="IdDependencia2" name="IdDependencia" value="0" />`)
            break;
        default:
            break;
    }
})