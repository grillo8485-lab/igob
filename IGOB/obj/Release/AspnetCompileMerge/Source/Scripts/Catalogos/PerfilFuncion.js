

function cargarModulosFunciones() {
    var text = $("#IdPerfil option:selected").text()
    var idPerfil = $("#IdPerfil").val()
    $("#IdGuardarPerfilFunciones").prop("disabled", false);
    $("#lbPerfil").html("");
    $("#lbPerfil").html(text);
    $("#IdPerfil_").val(idPerfil);
    var parametros = {
        pIdPerfil: idPerfil
    };
    $.ajax({
        data: parametros,
        url: '/PerfilFunciones/getMenu_x_IdPerfil/',
        type: 'post',
        beforeSend: function () {
            $(".accordion").html("");
        },
        success: function (response) {
            if (response.success) {
                var cadena = "";
                response.lista.forEach(function (current_value) {
                    cadena = cadena +
                        '<div class="card" > ' +
                            '<div class="card-header cabezera">' +
                                '<a class="card-link cabezera" data-toggle="collapse" href="#' + current_value.Modulos.IdModulo + '">' + current_value.Modulos.Descripcion + '</a>'+
                            '</div>' +
                        '<div id="' + current_value.Modulos.IdModulo + '" class="collapse" data-parent="#accordion">'

                    current_value.Funciones.forEach(function (current_value2) {
                        cadena = cadena +
                            '<div class="card-body row_" id="row_">' +
                                '<div class="col-md-4 text-left col_" > <label class="container">' +
                                    '<input type="checkbox" name="MenuTodo" value="' + current_value2.IdFuncion + '" ' + (current_value2.ActivoMenu ? "checked" : "") + ' onclick="validar(this)">' + current_value2.Descripcion+
                                '<span class="checkmark"></span></label></div>' +
                                '<div class="col-md-8 text-left">' +
                            '<div class="col_"><label class="container">Nuevo<input type="checkbox" id="Nuevo_' + current_value2.IdFuncion + '" name="MenuTodo" value="Nuevo_' + current_value2.IdFuncion + '"' + (current_value2.btnNuevo ? "checked" : "") + '><span class="checkmark"></span></label></div>' +
                            '<div class="col_"><label class="container">Editar<input type="checkbox" id="Editar_' + current_value2.IdFuncion + '" name="MenuTodo" value="Editar_' + current_value2.IdFuncion + '" ' + (current_value2.btnEditar ? "checked" : "") + '><span class="checkmark"></span></label></div>' +
                            '<div class="col_"><label class="container">Eliminar<input type="checkbox" id="Eliminar_' + current_value2.IdFuncion + '" name="MenuTodo" value="Eliminar_' + current_value2.IdFuncion + '"' + (current_value2.btnEliminar ? "checked" : "") + '><span class="checkmark"></span></label></div>' +
                            '<div class="col_"><label class="container">Consultar<input type="checkbox" id="Consultar_' + current_value2.IdFuncion + '" name="MenuTodo" value="Consultar_' + current_value2.IdFuncion + '"' + (current_value2.btnConsultar ? "checked" : "") + '><span class="checkmark"></span></label></div>' +
                                '</div>' +
                            '</div>' 
                    });
                    cadena = cadena + '</div>' + '</div>'

                        
                });

                $(".accordion").html(cadena);
            }
           
            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function ValidatePetSelection() {
    var checkboxes = document.getElementsByName("MenuTodo");
    var numberOfCheckedItems = Array();
    for (var i = 0; i < checkboxes.length; i++) {
        var objetoCheck = checkboxes[i];
        if (objetoCheck.checked) {
            var valor = parseInt(objetoCheck.value)
            //Compruebo si es un valor numérico 
            if (!isNaN(valor)) {
                var $n = $("#Nuevo_" + valor)
                var $ed = $("#Editar_" + valor)
                var $el = $("#Eliminar_" + valor)
                var $c = $("#Consultar_" + valor)

                var perfilesFunciones = new Object();
                perfilesFunciones.IdPerfilFuncion = 0;
                perfilesFunciones.IdFuncion = valor;
                perfilesFunciones.IdPerfil = $("#IdPerfil_").val();
                perfilesFunciones.btnNuevo = $n.is(":checked");
                perfilesFunciones.btnEditar = $ed.is(":checked");
                perfilesFunciones.btnEliminar = $el.is(":checked"); 
                perfilesFunciones.btnConsultar = $c.is(":checked"); 

                numberOfCheckedItems.push(perfilesFunciones)
                

            } 
        }
            
    }
    var parametros = {
        pLstPerfilFunciones: numberOfCheckedItems
    };
    $.ajax({
        data: parametros,
        url: '/PerfilFunciones/createPerfilFunciones/',
        type: 'post',
        beforeSend: function () {
            //$(".accordion").html("");
        },
        success: function (response) {
            if (response.success) {
                $(".accordion").html("");
                $("#lbPerfil").html("");
                $("#IdPerfil_").val("0");
                $("#IdGuardarPerfilFunciones").prop("disabled", true);
            }

            else {
                $("#ResultadoBuscar").html('<div class="alert alert-danger" role="alert"> ' + response.mensaje + '</div >');
            }

        }
    });
}
function validar(check) {
    if (check.checked) {
        var valor = check.value
        $("#Nuevo_" + valor).prop('checked', true);
        $("#Editar_" + valor).prop('checked', true);
        $("#Eliminar_" + valor).prop('checked', true);
        $("#Consultar_" + valor).prop('checked', true);
    }
    else {
        var valor = check.value
        $("#Nuevo_" + valor).prop('checked', false);
        $("#Editar_" + valor).prop('checked', false);
        $("#Eliminar_" + valor).prop('checked', false);
        $("#Consultar_" + valor).prop('checked', false);
    }
}