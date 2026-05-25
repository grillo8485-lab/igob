/**
* Autocomplete
*
*/

var IMAGEN;
var NEW_OPTIONS;
var REQUIRE_IDPADRE = "_IDPADRE";
var _IDPADRE = "";
var o=0;
var bandera = true;
var banComplete = true;

function autoCompleteData(ID,CAMPO_BUSQUEDA,ID_FORMCAMPO,evt,OPTIONS){
	var key = evt.keyCode;
	// console.log("key: "+key);
	// var IDCAMPO = $("#"+CAMPO_BUSQUEDA).val();
	if (key != 9 && key != 13 && key != 16 && key != 17 && key != 18 && key != 20 && key != 35 && key != 36 && key != 37 && key != 39) {
		$("#"+ID).val("");
	}
	// console.clear();
	/*console.log("banComplete: "+banComplete);
	console.log("key: "+key);*/

	/*$('#mensajeAlert1').html("");
	$('#mensajeAlert2').html("");
	$('#mensajeAlert3').html("");*/
	if(banComplete){
	banComplete = false;
	
	/*if(key == 13){
		// eventEnter(ID,CAMPO_BUSQUEDA,ID_FORMCAMPO);
		setTimeout ("eventEnter('"+ID+"','"+CAMPO_BUSQUEDA+"','"+ID_FORMCAMPO+"');", 1000);
			
	}*/

	// console.log("soy .autocomplete-suggestions: "+$(".autocomplete-suggestions .autocomplete-suggestion_"+ID).html());

	/*if (key != 38 && key != 40 && key!=13) {
		$( ".autocomplete-suggestions" ).remove();
	}*/
	if ($(".autocomplete-suggestions .autocomplete-suggestion_"+ID).html() == undefined) {
		// console.log('Entre a la condición == undefined');
		$('#'+CAMPO_BUSQUEDA).autoComplete({

			// minChars: 1,
			source: function(term, suggest){
			// console.log('Entre a la condición == source');
				// console.log("bandera 1: "+bandera);
				IMAGEN = '<img src="'+WEB_ROOT+'/js/autocomplete/img/cuadro.png" style="width:12px;">&nbsp;&nbsp;';

				if (term.trim() == "") {$('#'+$ID).val(""); return;}
				if (REQUIRE_IDPADRE == "_IDPADRE" || REQUIRE_IDPADRE == "") {
					_IDPADRE = "";
				}else{
					_IDPADRE = $("#"+REQUIRE_IDPADRE).val();
				}
				// console.log(_IDPADRE);
				// if (_IDPADRE > 0 || _IDPADRE != "") {
					// alert(REQUIRE_IDPADRE+": "+_IDPADRE);
				// }

				$.ajax({
					type: "POST",
					url: WEB_ROOT+"/ajax/autocomplete.php",
					data: {
						'type' : "autoBusqueda",
						'term' : term.trim(),
						'id' 	: ID,
						'campo' : CAMPO_BUSQUEDA,
						'ID_FORMCAMPO' : ID_FORMCAMPO,
						'_IDPADRE' : _IDPADRE
					},
					success: function(response) {
					// console.log('Entre a la condición == success');
						var splitResp = response.split("[#]");
						var choices, n, suggestions = [];

						// $('#mensajeAlert').html(response);
						// console.log(splitResp);

						//INICIO :: esto solo es cuando tenga un padre el bsucador
						if (splitResp[6] != "") {
							REQUIRE_IDPADRE = splitResp[6];

							if (_IDPADRE == "") {
								// alert(REQUIRE_IDPADRE+": "+_IDPADRE);
								if (_IDPADRE > 0) {
									autoCompleteData(ID,CAMPO_BUSQUEDA,ID_FORMCAMPO,evt,OPTIONS);
									return;
								}
							}
						}else{
							REQUIRE_IDPADRE = "_IDPADRE";
						}
						// FIN :: esto solo es cuando tenga un padre el bsucador

						if (splitResp[2] == "ok" && splitResp[3] != "") {
							choices = JSON.parse(splitResp[3]);
							n = choices.length;

							if (n > 0) {
								for (i=0;i<n;i++){
									suggestions.push(choices[i]);
								}
							}
							bandera = true;
							suggest(suggestions);

							// console.log("suggestions: "+suggestions);
							NEW_OPTIONS = splitResp[5];
						}
					},
					error:function(){
						// console.log('Entre a la condición == error');
						// console.log("Error de datos...");
						var suggestions = [];
						suggest(suggestions);
					}
				});

			},
			renderItem: function (item, search){
				// console.log('Entre a la condición == renderItem');
				// console.log(item);
				// console.log("bandera 2: "+bandera);
				search = search.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
				var re = new RegExp("(" + search.split(' ').join('|') + ")", "gi");

				var HTML_LIST = "";
				if(bandera && item[0]!=0){
					var DIV_INICIO = '<div class="autocomplete-suggestion selected autocomplete-suggestion_'+ID+'" data-id="'+item[0]+'" data-values="'+item[1]+'" data-val="'+search+'">';
				}else{
					var DIV_INICIO = '<div class="autocomplete-suggestion autocomplete-suggestion_'+ID+'" data-id="'+item[0]+'" data-values="'+item[1]+'" data-val="'+search+'">';
				}
				var DIV_FIN = '</div>';
				var LABEL = ' <o> '+item[1].replace(re, "<b>$1</b>")+'</o>';

				if (item[0] == 0) {
					HTML_LIST = DIV_INICIO +'<center>'+item[1].replace(re, "<b>$1</b>")+'</center>'+DIV_FIN;
				}else{
					HTML_LIST = DIV_INICIO + IMAGEN + LABEL + DIV_FIN;
				}
				bandera = false;
				return HTML_LIST;
			},
			focus: function( event, ui ) {
				// console.log('Entre a la condición == focus');
				event.preventDefault();
			},
			onSelect: function(e, term, item){
				// console.log('Entre a la condición == onSelect');
				$('.autocomplete-suggestions').hide();
				
				// alert(item.data('id'));
				// alert(item.data('values'));

				if (item.data('id') == 0) {
					$('#'+ID).val("");
					$('#'+CAMPO_BUSQUEDA).val("");
				}else{
					$('#'+ID).val(item.data('id'));
					$('#'+CAMPO_BUSQUEDA).val(item.data('values'));

					switch (NEW_OPTIONS) {
						case 'ASSING-QUERY-CAMPOS':
								Buscar(ID,ID_FORMCAMPO,item.data('id'));
							break;
					}
				}
			}
		});
	} //if undefined
	banComplete = true;
	bandera = true;
	// console.log("bandera 3: "+bandera);
	}
}

function Buscar(ID,ID_FORMCAMPO,idReg,valorPadre){

	if (idReg == "") { return;}
	$.ajax({
		type: "POST",
		url: WEB_ROOT+"/ajax/autocomplete.php",
		data: {
			'type' : "BuscarDatos",
			'idReg' 	: idReg,
			'ID' 	: ID,
			'ID_FORMCAMPO' : ID_FORMCAMPO,
			'valorPadre': valorPadre
		},
		beforeSend: function(){
		},
		success: function(response) {
			// console.log(response);
			var splitResp = response.split("[#]");

			if(splitResp[0] == "ok") {
				$("#VTDCANTIDAD").attr( {'readonly' : false, 'disabled':false});
				$("#VTDDESCUENTO").attr( {'readonly' : false, 'disabled':false});
				$("#CPDCANTIDAD").attr( {'readonly' : false, 'disabled':false});
				$("#CPDDESCUENTO").attr( {'readonly' : false, 'disabled':false});
				$("#CPDPRECIO").attr( {'readonly' : false, 'disabled':false});
				$("#VTDOBSERVACIONES").attr( {'readonly' : false, 'disabled':false});
				$("#CPDOBSERVACIONES").attr( {'readonly' : false, 'disabled':false});

				/*$("#IDTIPOPERSONA").attr( {'readonly' : true, 'disabled':true});
				$("#EMPNOMBRECOMERCIAL").attr( {'readonly' : true, 'disabled':true});
				$("#EMPRAZONSOCIAL").attr( {'readonly' : true, 'disabled':true});
				$("#EMPCALLE").attr( {'readonly' : true, 'disabled':true});
				$("#EMPNUMEROEXT").attr( {'readonly' : true, 'disabled':true});
				$("#EMPCOLONIA").attr( {'readonly' : true, 'disabled':true});
				
				$("#EMPCODIGOPOSTAL").attr( {'readonly' : true, 'disabled':true});
				$("#IDPAIS").attr( {'readonly' : true, 'disabled':true});
				$("#IDESTADO").attr( {'readonly' : true, 'disabled':true});
				$("#IDMUNICIPIO").attr( {'readonly' : true, 'disabled':true});
				$("#EMPLOCALIDAD").attr( {'readonly' : true, 'disabled':true});
				$("#EMPTEL").attr( {'readonly' : true, 'disabled':true});
				$("#EMPCORREO").attr( {'readonly' : true, 'disabled':true});
				$("#EMPLOGO").attr( {'readonly' : true, 'disabled':true});
				$("#EMPPAGINAWEB").attr( {'readonly' : true, 'disabled':true});*/
				//,,,,,,,,,,,,,,
				var DATOS_CAMPOS = JSON.parse(splitResp[1]);
				var NAME_CAMPOS = JSON.parse(splitResp[2]);

				$.each(NAME_CAMPOS, function (i_NC, val_NC) {
					$.each(DATOS_CAMPOS, function(i_DC, val_DC) {
						if (val_NC == i_DC) {
							$("#"+val_NC).val(val_DC);
						}
					});
				});

			} else {
				jAlert("<div class='pre-scrollable'>Error al cargar los datos...\n" + response+"<div>","Alerta!");
			}
		},
		error:function(){
			alert("Error de datos...");
		}
	});
}

function eventEnter(ID,CAMPO_BUSQUEDA,ID_FORMCAMPO){
	// alert(ID);
	var IDCAMPO = $('#'+ID).val();
	var valueCAMPO = $('#'+CAMPO_BUSQUEDA).val();
	if(IDCAMPO == ""){
		var IDCM = $(".autocomplete-suggestion").data('id');
    	var VALUECM = $(".autocomplete-suggestion").data('values');

		if (IDCM == 0) {
			$('#'+ID).val("");
			$('#'+CAMPO_BUSQUEDA).val("");
		}else{
			$('#'+ID).val(IDCM);
			$('#'+CAMPO_BUSQUEDA).val(VALUECM);
			Buscar(ID,ID_FORMCAMPO,IDCM);		
		}
	}
	

}

