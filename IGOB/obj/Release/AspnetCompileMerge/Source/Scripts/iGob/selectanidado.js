function selectmultiple(valor,ID_HIJO) {
	var id = valor;
	if (ID_HIJO == "") { return; }

	$.ajax({
		type: "POST",
		url: WEB_ROOT+"/ajax/selectanidado.php",
		data: "type=Buscar&id="+id+"&ID_HIJO="+ID_HIJO,
		beforeSend: function(){

		},
		success: function(response) {
			console.log(response);
			var splitResp = response.split("[#]");

			if(splitResp[0] == "ok") {
				var _disabled = $("#"+splitResp[2]).attr('disabled');
				var _readonly = $("#"+splitResp[2]).attr('readonly');
				var _class = $("#"+splitResp[2]).attr('class');
				var _required = $("#"+splitResp[2]).attr('required');

				$("#div"+splitResp[2]).html(splitResp[1]);
				if (splitResp[3] == "BUSQUEDATRUE") {
					var ONCHANGEANIDADO = $("#"+splitResp[2]).attr('onchange')+"Buscar('"+splitResp[4]+"','"+splitResp[5]+"',"+splitResp[6]+",'"+valor+"');";
					$("#"+splitResp[2]).attr( {'onchange' : ONCHANGEANIDADO} );
				}

				$("#"+splitResp[2]).attr( {'disabled': _disabled} );
				$("#"+splitResp[2]).attr( {'readonly': _readonly} );
				$("#"+splitResp[2]).attr( {'class': _class} );
				$("#"+splitResp[2]).attr( {'required': _required} );
			} else {
				alert("Error al cargar los datos. Intenta nuevamente...");
			}
		},
		error:function(){
			alert("Error de datos...");
		}
	});

}

