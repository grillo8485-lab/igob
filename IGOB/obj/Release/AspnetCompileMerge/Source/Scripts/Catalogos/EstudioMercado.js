
$("#BienServicio").autocomplete({
    minLength: 2,
    source: async function (request, response) {
        let servicio = await getsourcebienservicio();
        response($.map(servicio, function (item) {
            return { label: item.BienServicio, id: item.IdBienServicio, CodigoScian: item.CodigoScian, Descripcion: item.Descripcion };
        }));
    },
    select: function (e, ui) {
        $('#IdBienServicio').val(ui.item.id);
        $("input[name='BienServicio']").val(ui.item.label);
        $("textarea[name='DescripcionBS']").val(ui.item.Descripcion ? ui.item.Descripcion : "Sin descripción");
        $("input[name='CodigoSCIAN']").val(ui.item.CodigoScian ? ui.item.CodigoScian : "Sin codigo");
        if (ui.item.CodigoScian) getscian(ui.item.CodigoScian);
        else $("input[name='ClasificacionSCIAN']").val("Clasificacion no existente");
    },
    change: function (e, ui) {
        if (!ui.item) e.target.value = "";
    }
});

async function getsourcebienservicio() {
    try {
        return await fetch('/EstudioMercado/bienesservicios?str=' + $("#BienServicio").val()).then(response => response.json()).then(json => json.success ? json.data : undefined);
    } catch (err) {
        console.log(err);
    }
}

async function getscian(str) {
    try {
        let scian = await fetch('/EstudioMercado/getscian?str=' + str).then(response => response.json()).then(json => json.success ? json.data : undefined);
        if (scian) {
            $("input[name='ClasificacionSCIAN']").val(scian.Titulo ? scian.Titulo : "Clasificacion no existente");
        }
    } catch (err) {
        console.log(err);
    }
}

async function getmunicipios() {
    try {
        let municipios = await fetch('/EstudioMercado/GetMunicipios?claveestado=' + $('#Estado').val()).then(response => response.json()).then(json => json.success ? json.data : undefined);
        if (municipios)
        {
            let options = '<option value="0" disabled selected> Seleccione un Municipio</option>';
            municipios.map(item => options += `<option value="${item.IdMunicipio.trim()}"> ${item.Municipio} </option>`);
            $('#Municipio').html(options);
        }
    } catch (err) {
        console.log(err);
    }
}

async function getColonias() {
    try {
        let colonias = await fetch('/EstudioMercado/GetColonias?IdMunicipio=' + $('#Municipio').val()).then(response => response.json()).then(json => json.success ? json.data : undefined);
        if (colonias) {
            let options = '<option value="0" disabled selected> Seleccione una colonia </option>';
            colonias.map(item => options += `<option value="${item.IdColonia.trim()}"> ${item.Colonia} </option>`);
            $('#Localidad').html(options);
        }
    } catch (err) {
        console.log(err);
    }
}

async function getUEidenticicada() {
    try {
        $('#TamannoUnidades').val($('#UEIdentificadas').val())
        let num = $("#CodigoSCIAN").val();
        let str = document.getElementById('UEIdentificadas').options[document.getElementById('UEIdentificadas').selectedIndex].text;
        if (num && num != 'Sin codigo') {
            let uei = await fetch(`/EstudioMercado/GetUEIdentificadas?num=${num}&str=${str}`).then(response => response.json()).then(json => json.success ? json.data : json.data/*undefined*/);
            $("#NoUnidadesEconomicas,#Poblacion").val(uei);
        } else {
            if (num == 'Sin codigo') {
                bootbox.alert({
                    title: 'Aviso',
                    message: 'El bien o servicio no cuenta con una codigo SCIAN',
                    size: 'small'
                });
            } else {
                bootbox.alert({
                    title: 'Aviso',
                    message: 'No se ha seleccionado bien o servicio',
                    size: 'small'
                });
            }
            document.getElementById('UEIdentificadas').options[0].selected = true;
        }
    } catch (err) {
        //console.log(err)
    }
}

async function saveDetPre() {
    let data = new FormData();
    data.append('IdDeterminaPrecioBienServicio', $('#IdDeterminaPrecioBienServicio').val());
    data.append('IdBienServicio', $('#IdBienServicio').val());
    data.append('Poblacion', ($('#NoProbabilistico').is(':checked') ? $('#MuestraNoProbabilistica').val() : $('#Poblacion').val()));
    data.append('NivelConfianza', $('#NivelConfianza').val());
    data.append('ConstanteNivelConfianza', 0);
    data.append('IdDatoEstudioMercado', $('#IdBienServicioEstMerc').val());
    data.append('Varianza', $('#Varianza').val());
    data.append('MargenError', $('#MargenError').val());
    let mr = $('#muestra_n').val()
    data.append('MuestraRedondeada', mr != "" && mr != 0 ? mr : ($('#NoProbabilistico').is(':checked') ? $('#MuestraNoProbabilistica').val() : $('#Poblacion').val()));
    let m = $('#muestra_no_r').val()
    data.append('Muestra', m != "" && m != 0 ? m : ($('#NoProbabilistico').is(':checked') ? $('#MuestraNoProbabilistica').val() : $('#Poblacion').val()));
    data.append('Promedio', 0);
    data.append('Maximo', 0);
    data.append('Minimo', 0);
    data.append('Moda', 0);
    data.append('Mediana', 0);
    data.append('PrecioAplicado', 0);
    data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());
    let result = await fetch('/EstudioMercado/saveDeterminacionPrecio', { method: 'POST', body: data }).then((response) => response.json()).then((json) => json);
    $('#IdDeterminaPrecioBienServicio').val(result.data.scalar)
    return result.data.message;
}

async function UpDetPre() {
    let data = new FormData();
    data.append('IdDeterminaPrecioBienServicio', $('#IdDeterminaPrecioBienServicio').val());
    data.append('IdBienServicio', $('#IdBienServicio').val());
    data.append('Poblacion', $('#Poblacion').val());
    data.append('NivelConfianza', $('#NivelConfianza').val());
    data.append('ConstanteNivelConfianza', 0);
    data.append('IdDatoEstudioMercado', $('#IdBienServicioEstMerc').val());
    data.append('Varianza', $('#Varianza').val());
    data.append('MargenError', $('#MargenError').val());
    data.append('MuestraRedondeada', $('#muestra_n').val());
    data.append('Muestra', $('#muestra_no_r').val());

    let Promedio = $('#Promedio').val();
    let Maximo = $('#Maximo').val();
    let Minimo = $('#Minimo').val();
    let Moda = $('#Moda').val();
    let Mediana = $('#Mediana').val();

    if (Promedio && Maximo && Minimo && Moda && Mediana) {
        data.append('Promedio', Promedio);
        data.append('Maximo', Maximo);
        data.append('Minimo', Minimo);
        data.append('Moda', Moda);
        data.append('Mediana', Mediana);
        data.append('PrecioAplicado', $("input[name='NuevoPrecio']:checked").val());
        data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());

        let m = await fetch('/EstudioMercado/saveUpDeterminacionPrecio', { method: 'POST', body: data }).then((response) => response.json()).then((json) => json);
        if (m.success) {
            $("#DatosEstadisticosEstMerc,#btncalcularcotizacionesMMM,#listaProveedoresPreciosProb,#genListNotProb,#genListProb").addClass('disabledClick')
        }
        return m.data.message;
    } else {
        return 'No se ha calculado el precio';
    }
}

function saveMarketReseach() {
    if (($("#NivelConfianza").val() != "" && $("#MargenError").val != "" && $("#Varianza").val() != "") || ($('#NoProbabilistico').is(':checked') && $('#MuestraNoProbabilistica').val() != "" && $('input[name="SeleccionProveedores"]').is(':checked'))) {
        bootbox.confirm({
            size: 'small',
            message: '¿Desea guardar cambios en estudio de mercado?',
            title: 'Aviso',
            callback: async function (is) {
                if (is) {
                    let data = new FormData(document.getElementById('EstudioMercado'));
                    let add = await fetch('/EstudioMercado/addBienServEstudioMercado/', { method: 'POST', body: data }).then(response => response.json()).then(json => json);
                    $('#IdBienServicioEstMerc').val(add.data.scalar);
                    let addDetP = await saveDetPre()
                    bootbox.alert({
                        title: 'Aviso',
                        message: add.data.message,
                        size: 'small'
                    });
                    $('#saveDatosBSEM').prop('disabled', true)
                    $('.div_DatosGeneralesSeleccionBienServicio,#div_determinarMuestra').addClass('disabledClick')
                    if ($('#TipoDeterminacion').val() == 1) {
                        $('#genListProb').prop('hidden',false)
                        $('#genListNotProb').prop('hidden', true)
                    } else {
                        $('#genListNotProb').prop('hidden', false)
                        $('#genListProb').prop('hidden', true)
                    }
                }
            }
        });
    } else {
        bootbox.alert({
            size: 'small',
            message: 'Faltan campos por rellenar',
            title: 'Aviso',
        });
    }
}

async function generarlistaUE() {
    let iddetermipbs = $('#IdDeterminaPrecioBienServicio').val()
    if (iddetermipbs != 0 && iddetermipbs != "" && iddetermipbs) {
        let TamanoEU = document.getElementById('UEIdentificadas').options[document.getElementById('UEIdentificadas').selectedIndex].text;
        let urlPUE = `/EstudioMercado/GetProviderSample?Codigo=${$('#CodigoSCIAN').val()}&CveEstado=${$('#Estado').val()}&TamanoEU=${TamanoEU}&NoUnidadesEconomicas=${$('#Poblacion').val()}&TamanoMuestra=${$('#muestra_n').val()}`;
        let providers = await fetch(urlPUE).then(response => response.json()).catch(err => console.log(err)).then(json => json);
        if (providers.success) {
            let dataDisM = {
                '__RequestVerificationToken': $("input[name='__RequestVerificationToken']").val(),
                'obj': providers.data.body,
                'tipo': $("input[name='TipoMuestra']:checked").val(),
                'iddetpbs': iddetermipbs,
            };
            $.ajax({
                dataType: 'json',
                type: 'POST',
                url: '/EstudioMercado/addDispeM',
                data: dataDisM,
                success: function (registros) {
                    if (registros.success) {
                        let inputsProviderMuestra = "";
                        registros.data.forEach((item) => {
                            inputsProviderMuestra += `<label for"UE_${item.IdRegisted}">Proveedor: ${item.Nom_estab}</label>
                            <input type="text" name="" value="" id="UE_${item.IdRegisted}" placeholder="Inserte precio con impuesto" class="form-control" /><br/>
                            <button type="button" onclick="savecotizacionindividual(${item.IdRegisted})" class="btn btn-secondary">Guardar cotización</button><br/>`;
                        });
                        inputsProviderMuestra += `<button type="button" class="btn btn-secondary" onclick="calcularCotizacionesMMM()">Calcular</button>`;
                        $('#listaProveedoresPreciosProb').html(inputsProviderMuestra);
                        $('#genListProb').prop('disabled', true)
                    } else {
                        bootbox.alert({
                            title: 'Aviso',
                            message: 'No se encontro registro de proveedores',
                            size: 'small'
                        });
                    }
                }
            });
        } else {
            bootbox.alert({
                title: 'Aviso',
                message: 'No se encontro registro de proveedores',
                size: 'small'
            });
        }
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'Debe de guardar los datos del estudio',
            size: 'small'
        });
    }
}

function generarListaNoProbabilistica() {
    if ($("input[name='SeleccionProveedores']:checked").length > 0) {
        let IdD = $('#IdDeterminaPrecioBienServicio').val();
        if (IdD && IdD != 0 && IdD != "") {
            if ($("input[name='SeleccionProveedores']:checked").val() == 'cat') {
                let inputsproviders = $('#listaProveedoresPreciosProb input').length + 1;
                if (inputsproviders <= $('#MuestraNoProbabilistica').val()) {
                    $('#ModalsearchUE').modal('show');
                } else {
                    $('#genListNotProb').prop('disabled', true)
                }
            } else {
                bootbox.confirm({
                    title: 'Aviso',
                    message: '¿Desea agregar las unidades economicas?',
                    size: 'small',
                    callback: function (i) {
                        if (i) {
                            addproviders();
                        }
                    }
                });
            }
        } else {
            $("input[name='SeleccionProveedores']:checked").prop('checked', false)
            bootbox.alert({
                title: 'Aviso',
                message: 'Debe de guardar los datos primero',
                size: 'small'
            })
        }
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'Debe determinar una muestra',
            size: 'small'
        })
    }
}

async function GetInputsTableCon() {
    let inputs = $('#conclusionesEstMerc input[type=radio]');
    let inputsC = $('#conclusionesEstMerc input[type=radio]:checked');
    if (inputs.length / 2 == inputsC.length) {
        bootbox.confirm({
            title: 'Aviso',
            message: '¿Desea guardar las conclusiones?',
            size: 'small',
            callback: function (res) {
                if (res) {
                    var listaConclusion = [];
                    $('#conclusionesEstMerc input[type=radio]:checked').each(function () {
                        let obj = {};
                        obj['IdReactivoConclusionEM'] = $(this).prop('name');
                        obj['IdDatoEstudioMercado'] = $('#IdBienServicioEstMerc').val();
                        obj['Respuesta'] = ($(this).val() == 1 ? true : false);
                        listaConclusion.push(obj);
                    });
                    let data = { '__RequestVerificationToken': $("input[name='__RequestVerificationToken']").val(), 'obj': listaConclusion };
                    $.ajax({
                        dataType: 'json',
                        type: 'POST',
                        url: '/EstudioMercado/saveConclusionesEstudio',
                        data: data,
                        success: function (response) {
                            if (response.success) {
                                $('#saveconclusionestable,#conclusionesEstMerc').addClass('disabledClick')
                            }
                            bootbox.alert({
                                title: 'Aviso',
                                message: response.data.message,
                                size: 'small'
                            });
                        }
                    });
                }
            }
        })
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'No se han seleccionado todas las conclusiones',
            size: 'small'
        });
    }
}

async function SearchUE() {
    let texto = $('#searchprovider').val();
    if (texto && texto != "") {
        let data = new FormData();
        data.append('texto', $('#searchprovider').val());
        data.append('cve_ent', $('#Estado').val());
        //data.append('cve_mun', $('#Municipio').val());
        let ue = await fetch('/EstudioMercado/GetUE', { method: 'POST', body: data }).then(response => response.json()).catch(err => console.log(err)).then(json => json);
        if (ue) {
            var table = '';
            ue.data.map((item) => {
                table += `<tr>
                        <td>${item.Nom_estab}</td>
                        <td>${item.Raz_social}</td>
                        <td>${item.Codigo_act}</td>
                        <td>${item.Nombre_act}</td>
                        <td><div><button data-id="${item.Id}" data-nomest="${item.Nom_estab}" data-razsoc="${item.Raz_social}" data-codact="${item.Codigo_act}" data-nomact="${item.Nombre_act}" class="btn btn-secondary addTableUE"><i class="fa fa-plus" aria-hidden="true"></i></button></div></td>
                    </tr>`;
            });
            $('#bodyUnidadesEcSearchModal').html(table);
            $('#listaProveedoresPreciosProb').html('');
        }
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'Debe llenar el campo de texto',
            size: 'small'
        });
    }
}

async function getMuestreo() {
    try {
        let Poblacion = $("#Poblacion").val();
        let NivelConfianza = $('#NivelConfianza').val();
        let MargenError = $('#MargenError').val();
        let Varianza = $('#Varianza').val();
        let data = new FormData();
        if (Poblacion && NivelConfianza && MargenError && Varianza) {
            $('#saveDatosBSEM').prop('disabled', false);
            data.append('Poblacion', Poblacion);
            data.append('NivelConfianza', NivelConfianza);
            data.append('MargenError', MargenError);
            data.append('Varianza', Varianza);
            data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());
            let varianza = await fetch('/EstudioMercado/GetCalculoMuestra', { method: 'POST', body: data }).then(response => response.json()).then(json => json.success ? json.data : undefined);
            if (varianza) {
                $('#muestra_n').val(varianza.MuestraRedondeada);
                $('#muestra_no_r').val(varianza.Muestra.toFixed(2));
            }
        } else {
            bootbox.alert({
                title: 'Aviso',
                message: 'Debe llenar los campos de la muestra',
                size: 'small'
            });
        }
    } catch (err) {
        console.log(err);
    }
}

function savecotizacionindividual(inp) {
    let tipo = $("input[name='TipoMuestra']:checked").val()
    let vienecat = $('#UEVieneCatalogo').val();
    if ($(`#UE_${inp}`).val() != 0 && $(`#UE_${inp}`).val() != "") {
        bootbox.confirm({
            title: 'Aviso',
            message: '¿Desea guardar la cotización?',
            size: 'small',
            callback: async function (res) {
                if (res) {
                    if (tipo == 1 || vienecat=="true") {
                        let smp = await saveDispMPInd(inp)
                        if (smp) {
                            bootbox.alert({
                                title: 'Aviso',
                                message: smp.message,
                                size: 'small'
                            })
                            if (smp.success) {
                                $(`#UE_${inp}`).addClass('disabledClick')
                                $(`#UE_${inp}`).next().next('button').addClass('disabledClick')
                            }
                        }
                    } else {
                        $('#iddispercionmuestraueform').val(inp)
                        $('#ex1,#ex2').val("")
                        $('#SaveDispMUEForm').modal('show')
                    }
                }
            }
        })
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'Campo de precio requerido',
            size: 'small'
        })
    }
}

async function saveNoProbCatalogo(inp) {
    let data = new FormData()
    data.append('IdDispercionMuestraPrecio', 0)
    data.append('IdDeterminaPrecioBienServicio', $('#IdDeterminaPrecioBienServicio').val())
    data.append('IdUnidadEconomica', inp)
    data.append('PrecioSinImpuesto', 0)
    data.append('Precio', 0)
    data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());
    return await fetch('/EstudioMercado/saveDispMP', { method: 'POST', body: data }).then((response) => response.json()).then((json) => json);
}

async function saveNoProbCaptura() {
    let data = new FormData()
    data.append('IdDispercionMuestraUE', 0)
    data.append('IdDeterminaPrecioBienServicio', $('#IdDeterminaPrecioBienServicio').val())
    data.append('UnidadEconomica', "--")
    data.append('Direccion', "--")
    data.append('PrecioSinImpuesto', 0)
    data.append('Precio', 0)
    data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());
    return await fetch('/EstudioMercado/saveUENoCatalogo', { method: 'POST', body: data }).then((response) => response.json()).then((json) => json);
}

async function saveDispMPInd(inp) {
    let data = new FormData()
    data.append('IdDispercionMuestraPrecio', inp)
    data.append('PrecioSinImpuesto', $(`#UE_${inp}`).val())
    data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());
    return await fetch('/EstudioMercado/saveDispMuePrec', { method: 'POST', body: data }).then((response) => response.json()).then((json) => json);
}

async function saveDispMUEInd() {//modal dispercion muestra unidad economica
    if ($('#ex1').val() != "" && $('#ex2').val() != "") {
        let inp = $('#iddispercionmuestraueform').val()
        let data = new FormData()
        data.append('IdDispercionMuestraUE', inp)
        data.append('UnidadEconomica', $('#ex1').val())
        data.append('Direccion', $('#ex2').val())
        data.append('PrecioSinImpuesto', $(`#UE_${inp}`).val())
        data.append('__RequestVerificationToken', $("input[name='__RequestVerificationToken']").val());
        let smue = await fetch('/EstudioMercado/saveDispMueUE', { method: 'POST', body: data }).then((response) => response.json()).then((json) => json);
        $('#SaveDispMUEForm').modal('hide')
        if (smue) {
            bootbox.alert({
                title: 'Aviso',
                message: smue.message,
                size: 'small'
            })
            if (smue.success) {
                $(`#UE_${inp}`).addClass('disabledClick')
                $(`#UE_${inp}`).next().next('button').addClass('disabledClick')
            }
        }
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'Debe de llenar los campos',
            size: 'small'
        })
    }
}

$("input[name='TipoMuestra']").on('change', function tipomuestra() {
    if ($("input[name='TipoMuestra']:checked").val() == 1) {
        $("#MuestraNoProbabilistica,input[name='SeleccionProveedores']").prop('disabled', true);
        $("#NoUnidadesEconomicas2,#NivelConfianza,#MargenError,#Varianza,#muestra,#ConstanteNivelConfianza, #calcular").prop('disabled', false);
        $('#TipoDeterminacion').val(1)
        $('#genListProb').prop('hidden', false)
        $('#genListNotProb').prop('hidden', true)
        $('#saveDatosBSEM').prop('disabled', true)
    } else {
        $("#MuestraNoProbabilistica,input[name='SeleccionProveedores']").prop('disabled', false);
        $("#NoUnidadesEconomicas2,#NivelConfianza,#MargenError,#Varianza,#muestra,#ConstanteNivelConfianza, #calcular").prop('disabled', true);
        $('#TipoDeterminacion').val(0)
        $('#saveDatosBSEM').prop('disabled', false)
        $('#genListProb').prop('hidden', true)
        $('#genListNotProb').prop('hidden', false)
    }
});

$("input[name='SeleccionProveedores']").on('change', function seleccionProveedores() {
    if ($('#MuestraNoProbabilistica').val() != "" && $('#MuestraNoProbabilistica').val() != 0) {
        $('#inputsProviders').html('');
        if ($(this).val() == 'cat') {
            $('#UEVieneCatalogo').val(true)
        } else {
            $('#UEVieneCatalogo').val(false)
        }
        $('#saveDatosBSEM').prop('disabled', false);
    } else {
        $("input[name='SeleccionProveedores']:checked").prop('checked', false)
        bootbox.alert({
            title: 'Aviso',
            message: 'Debe determinar una muestra',
            size: 'small'
        });
    }
});

async function addproviders() {
    if ($("input[name='SeleccionProveedores']:checked").val() == 'cap') {
        let cantidadinputs = $('#MuestraNoProbabilistica').val();
        if (cantidadinputs != 0 && cantidadinputs != "") {
            $('#listaProveedoresPreciosProb').html('');
            let saveNoProCap = true;
            for (let i = 0; i < cantidadinputs; i++) {
                var idata = await saveNoProbCaptura()
                $('#listaProveedoresPreciosProb').append(`<label for="UE_${idata.data.body}">Proveedor ${i + 1}:</label><br/>
                    <input type="text" id="UE_${idata.data.body}" placeholder="Inserte precio" name="" value="" class="form-control" /><br />
                    <button type="button" class="btn btn-secondary" onclick="savecotizacionindividual(${idata.data.body})">Guardar cotización</button><br /><br />`);
                if (saveNoProCap) {
                    saveNoProCap = idata.success;
                }
            }
            $('#listaProveedoresPreciosProb').append(`<button type="button" class="btn btn-secondary" onclick="calcularCotizacionesMMM()">Calcular</button>`);
            $('#genListNotProb').prop('disabled',true)
            bootbox.alert({
                title: 'Aviso',
                message: saveNoProCap ? 'Se agregaron los las unidades economicas':'No se pudieron agregar las unidades economicas',
                size: 'small'
            })
            if (saveNoProCap) { $("input[name='SeleccionProveedores']").prop('disabled',true)}
        }
    }
}

$('#TableUEstMer').on('click', '.addTableUE', async function () {
    let s = $('#IdDeterminaPrecioBienServicio').val()
    if (s != 0 && s != "" && s) {
        let inputsproviders = $('#listaProveedoresPreciosProb input').length + 1;
        let sizesample = $('#MuestraNoProbabilistica').val();
        if (inputsproviders <= sizesample) {
            let nid = $(this).attr('data-id');
            let nomest = $(this).attr('data-nomest');
            var idata = await saveNoProbCatalogo(nid)
            $('#listaProveedoresPreciosProb').append(`<label for="UE_${idata.data.body}">Proveedor: ${nomest}</label><br/>
            <input type="text" name="name" value="" id="UE_${idata.data.body}" placeholder="Inserte precio" class="form-control" /><br />
            <button type="button" class="btn btn-secondary" onclick="savecotizacionindividual(${idata.data.body})">Guardar cotización</button><br /><br />`);
            if (inputsproviders == sizesample) {
                $('#listaProveedoresPreciosProb').append(`<button type="button" class="btn btn-secondary" onclick="calcularCotizacionesMMM()">Calcular</button>`);
            }
        } else {
            bootbox.alert({
                title: 'Aviso',
                message: 'Se alcanzo el limite de unidades economicas',
                size: 'small'
            });
        }
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'Debe de guardar los datos del estudio mercado',
            size: 'small'
        });
    }
});

function calcularCotizacionesMMM() {
    let array = convertInpustToArray();
    $("#Promedio").val(Promedio(array));
    $("#Promedio").next().val(Promedio(array));
    $("#Moda").val(Moda(array));
    $("#Moda").next().val(Moda(array));
    $("#Mediana").val(Mediana(array));
    $("#Mediana").next().val(Mediana(array));
    $("#Maximo").val(Maximo(array));
    $("#Maximo").next().val(Maximo(array));
    $("#Minimo").val(Minimo(array));
    $("#Minimo").next().val(Minimo(array));
    $('#actualizarPrecio').prop('disabled', false);
}

function convertInpustToArray() {
    let arrayvalues = [];
    $('#listaProveedoresPreciosProb input').each(function () {
        if ($(this).val() != 0 && $(this).val() != "") {
            arrayvalues.push(parseFloat($(this).val()));
        }
    });
    return arrayvalues;
}

function Promedio(array) {
    let suma = 0, lenght = 0;
    array.map(function (item) {
        suma += parseFloat(item);
        lenght++;
    });
    return (suma / lenght).toFixed(2);
}

function Moda(array) {
    const map = new Map();
    let maxFreq = 0;
    let mode;
    for (const item of array) {
        let freq = map.has(item) ? map.get(item) : 0;
        freq++;
        if (freq > maxFreq) {
            maxFreq = freq;
            mode = item;
        }
        map.set(item, freq);
    }
    return mode;
}

function ordenar(array) {
    return array.sort(function (a, b) { return a - b;});
}

function Maximo(array) {
    let orderA = ordenar(array);
    return orderA[orderA.length - 1];
}

function Minimo(array) {
    let orderA = ordenar(array);
    return orderA[0];
}

function Mediana(array) {
    if (array.lenght > 1) {
        let orderA = ordenar(array);
        return orderA[Math.round(array.length / 2)];
    } else {
        return array[0];
    }
}

$('#actualizarPrecio').on('click', function () {
    if ($("input[name='NuevoPrecio']:checked").length == 1) {
        bootbox.confirm({
            title: 'Aviso',
            message: 'Desea guardar datos',
            size: 'small',
            callback: async function (is) {
                if (is) {
                    let iBienEstMer = $('#IdBienServicioEstMerc').val();
                    if (iBienEstMer != 0 && iBienEstMer != "" && iBienEstMer) {
                        let saveprecio = await UpDetPre()
                        bootbox.alert({
                            title: 'Aviso',
                            message: saveprecio,
                            size: 'small'
                        });
                    }
                }
            }
        });
    } else {
        bootbox.alert({
            title: 'Aviso',
            message: 'No se ha seleccionado el precio',
            size: 'small'
        });
    }
});

