/**
* Datos generales
*
*/


var urlLoc = document.location.hostname;

if(urlLoc == "localhost" || urlLoc == "127.1.0.1") {
	//local desarrollo
	var WEB_ROOT = "http://" + urlLoc + "/erpapp";
} else if(urlLoc == "192.168.1.127" || urlLoc == "192.168.0.127" || urlLoc == "gokids.mx" || urlLoc == "www.gokids.mx"){
	//IP desarrollo
	var WEB_ROOT = "http://" + urlLoc + "/erpapp";
} else if(urlLoc == "189.129.106.244"){
	//IP desarrollo INTERNET
	var WEB_ROOT = "http://" + urlLoc + "/erpapp";
	//IP constructorApp INTERNET
} else if(urlLoc == "www.solestranet.com" || urlLoc == "www.solestra.bit360.mx" || urlLoc == "www.bit360.mx" || urlLoc == "solestranet.com" || urlLoc == "bit360.mx" || urlLoc == "189.129.191.239" || urlLoc == "189.129.203.174"){
	var WEB_ROOT = "http://" + urlLoc + "/erpapp";
}else if(urlLoc == "igob.mx" || urlLoc == "www.igob.mx"){
	//igob
	var WEB_ROOT = "http://" + urlLoc;
}else if(urlLoc == "sofimagen.com" || urlLoc == "www.sofimagen.com"){
	//igob
	var WEB_ROOT = "http://" + urlLoc;
}else if(urlLoc == "192.168.1.133"){
	//IP constructorApp INTERNET
	var WEB_ROOT = "http://" + urlLoc;
} else {
	// default INTERNET
	var WEB_ROOT = "http://" + urlLoc;
}


function DeleteReg(id) {
	if (id == "") {
		jAlert('No es posible eliminar, los datos estan <b>vacios</b> o ya fue <b>eliminado</b>!',"Alerta!!");
	} else {
		jConfirm("¿Está seguro de eliminar este registro?", 'Confirmación', function(r) {
			if (!r) {
				return;
			}else{
				
				$( "#form1" ).submit();
			}
		});
	}
}

function CancelarReg(id) {
	if (id == "") {
		jAlert('No es posible CANCELAR',"!Alerta!");
	} else {
		jConfirm("¿Está seguro de CANCELAR este registro?", 'Confirmación', function(r) {
			if (!r) {
				return;
			}else{

				$( "#BTN_CANCELAR" ).val('BTN_CANCELAR');
				$( "#form1" ).submit();
			}
		});
	}
}

function BackPage() {
	history.back();
}

function mayuscula(ID) {
	var cadena = $("#"+ID).val();
	var textmayuscula = cadena.toUpperCase();
	$("#"+ID).val(textmayuscula);
}

function minuscula(ID) {
	var cadena = $("#"+ID).val();
	var textmayuscula = cadena.toLowerCase();
	$("#"+ID).val(textmayuscula);
}

function onmouseoverVALORCAMPO(ID,VALOR) {
	$("#"+ID).val(VALOR);
}

function sumaCampos(e,CAMPO1,CAMPO2,RESULTADO) {

	if (e.id == 'RGCCANTIDADINSTRUINICIAL') {
		if (Number($("#"+CAMPO1).val()) >= Number($("#"+CAMPO2).val())) {
			$("#"+CAMPO2).val(Number($("#"+CAMPO1).val())+1);
		}
	}

	if ($("#"+CAMPO1).val() == "") {
		$("#"+CAMPO1).val(0);
	}

	if ($("#"+CAMPO2).val() == "") {
		$("#"+CAMPO2).val(0);
	}

	if (Number($("#"+CAMPO2).val()) <= Number($("#"+CAMPO1).val())) {
		if (e.id == 'RGCCANTIDADINSTRUFINAL') {
			jAlert('<b style="color:red;">Instrumento de medición final</b> debe ser mayor a <b style="color:red;">Instrumento de medición inicial</b>',"Alerta!!");
			$("#"+CAMPO2).val(Number($("#"+CAMPO1).val())+1);
		}
	}

	$("#"+RESULTADO).val(Number($("#"+CAMPO2).val())-Number($("#"+CAMPO1).val()));

	$("#"+CAMPO1).val(Number($("#"+CAMPO1).val()));
	$("#"+CAMPO2).val(Number($("#"+CAMPO2).val()));
}

function numerico(e){
	key = e.keyCode || e.which;
	// console.log(key);
	tecla = String.fromCharCode(key).toLowerCase();
	letras = "1234567890";
	especiales = [0,8,9,37,48,57,160];

	tecla_especial = false
	for(var i in especiales){
		if(key == especiales[i]){
			tecla_especial = true;
			break;
		}
	}

	if(letras.indexOf(tecla)==-1 && !tecla_especial){
		return false;
	}
}

function flotante(e){
	key = e.keyCode || e.which;
	tecla = String.fromCharCode(key).toLowerCase();
	letras = "1234567890";
	especiales = [0,8,9,37,48,57,160];

	tecla_especial = false
	for(var i in especiales){
		if(key == especiales[i]){
			tecla_especial = true;
			break;
		}
	}

	if(letras.indexOf(tecla)==-1 && !tecla_especial){
		return false;
	}
}

function numericoP(e){
	key = e.keyCode || e.which;
	// console.log(key);
	tecla = String.fromCharCode(key).toLowerCase();
	letras = "1234567890";
	especiales = [0,8,9,37,48,57,160];

	tecla_especial = false
	for(var i in especiales){
		if(key == especiales[i]){
			tecla_especial = true;
			break;
		}
	}

	if(letras.indexOf(tecla)==-1 && !tecla_especial){
		return false;
	}
}

function flotanteP(e,columna){
	var miValue=$("#"+columna).val();
	var buscarPunto = miValue.indexOf('.');

	key = e.keyCode || e.which;
	tecla = String.fromCharCode(key).toLowerCase();
	letras = "1234567890.";
	especiales = [0,8,9,37,48,57,160];

	tecla_especial = false
	for(var i in especiales){
		if(key == especiales[i]){
			tecla_especial = true;
			break;
		}
	}

	if(buscarPunto!=-1 && tecla=="."){
		return false;
	}else{
		if(letras.indexOf(tecla)==-1 && !tecla_especial){
			return false;
		}
	}
}


$(function() {
	$('.date-picker-div input').datepicker({
		format: "yyyy-mm-dd",
		daysOfWeekHighlighted: "0,6",
		calendarWeeks: true,
		autoclose: true,
		todayHighlight: true
	});

	habilitar();
	habilitarTipoAjuste();

	$('.horas').timepicker({ 'timeFormat': 'H:i' });

	$('#dataTables-CabeceraDetalle').DataTable({
		responsive: true,
		scrollX: true,
		order: [[0,"desc"]]
	});

});


function llenar(atributo){
	if(atributo.value == ""){
		$("#"+atributo.id).val(0);
	}
}

function habilitar(){

	var PKMPAVKILOMETRO = $("#PKMPAVKILOMETRO").val();
	var PKMTERKILOMETRO = $("#PKMTERKILOMETRO").val();

	var DAVPAVKILOMETRO = $("#DAVPAVKILOMETRO").val();
	var DAVTERKILOMETRO = $("#DAVTERKILOMETRO").val();

	var MDVPAVKILOMETRO = $("#MDVPAVKILOMETRO").val();
	var MDVTERKILOMETRO = $("#MDVTERKILOMETRO").val();

	if( PKMPAVKILOMETRO == 1 ){
			$(".bloque1B").attr( {'readonly' : true} );
			$(".bloque1B").val(0);
		}

	if( PKMTERKILOMETRO == 1 ){
			$(".bloque1A").attr( {'readonly' : true} );
			$(".bloque1A").val(0);
		}

	if( DAVPAVKILOMETRO == 19 ){
			$(".bloque2B").attr( {'readonly' : true} );
			$(".bloque2B").val(0);
		}
	if( DAVTERKILOMETRO == 19 ){
			$(".bloque2A").attr( {'readonly' : true} );
			$(".bloque2A").val(0);
		}

	if( (Number(PKMPAVKILOMETRO) + Number(PKMTERKILOMETRO)) == 1 ) {

		$(".bloque2").attr( {'readonly' : false} );
	}else{$(".bloque2").attr( {'readonly' : true});}


	if( (Number(DAVPAVKILOMETRO) + Number(DAVTERKILOMETRO)) == 19 ) {
		$(".bloque3").attr( {'readonly' : false} );
	}else{$(".bloque3").attr( {'readonly' : true} );}

}

function hidencampos(CLASS_HIDDEN) {
	if (document.getElementById("RGCCHECKVALES").checked) {
		$('.'+CLASS_HIDDEN).toggle();
	}else{
		$('.'+CLASS_HIDDEN).toggle();
		$('#MONTOVALES').val("");
		$('#FOLIOVALAES').val("");
	}
}

function hidencampos2(CLASS_HIDDEN) {
	if (document.getElementById("PARRENTADO").checked) {
		$('.'+CLASS_HIDDEN).toggle();
	}else{
		$('.'+CLASS_HIDDEN).toggle();
		$('#PARFECHAINICIO').val("");
		$('#PARFECHAFIN').val("");
	}
}

function hidencamposCondicionesPago(val,CLASS_HIDDEN) {
		var valor=val.value;
		var id=val.id;
	if (valor==1 && $("#"+id).hasClass("si")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#IDPORCENTAJEANTICIPOCABECERA").attr( {'required' : true});
		//$("#CNPNUMEROPAGOS").attr( {'required' : true});
		$("#"+id).removeClass('si');
		$("#"+id).addClass('no');
		$("#ID"+id).removeClass('col-xs-8 col-sm-8 col-md-4 col-lg-4');
		$("#ID"+id).addClass('col-xs-4 col-sm-4 col-md-2 col-lg-2');
	}else if (valor==2 && $("#"+id).hasClass("no")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#"+id).addClass('si');
		$("#"+id).removeClass('no');
		$("#ID"+id).removeClass('col-xs-4 col-sm-4 col-md-2 col-lg-2');
		$("#ID"+id).addClass('col-xs-8 col-sm-8 col-md-4 col-lg-4');
		$('#IDPORCENTAJEANTICIPOCABECERA').val("");
		$("#IDPORCENTAJEANTICIPOCABECERA").attr( {'required' : false});
		//$('#CNPNUMEROPAGOS').val("");
		//$("#CNPNUMEROPAGOS").attr( {'required' : false});
	}
}

function hidencamposMuestras(val,CLASS_HIDDEN) {
		var valor=val.value;
		var id=val.id;
		//alert(id)
	if (valor==1 && $("#"+id).hasClass("si")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#DGNDESMUESTRASCAT").attr( {'required' : true});	
		$("#"+id).removeClass('si');
		$("#"+id).addClass('no');
		$("#ID"+id).removeClass('col-xs-12');
		$("#ID"+id).addClass('col-xs-2');

	}else if (valor==2 && $("#"+id).hasClass("no")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#"+id).addClass('si');
		$("#"+id).removeClass('no');
		$("#ID"+id).removeClass('col-xs-2');
		$("#ID"+id).addClass('col-xs-12');
		$('#DGNDESMUESTRASCAT').val("");
		$("#DGNDESMUESTRASCAT").attr( {'required' : false});
		$('#DGNDESMUESTRASCATARCHIVO').val("");
	}
}

function hidencamposCatalogos(val,CLASS_HIDDEN) {
		var valor=val.value;
		var id=val.id;
	if (valor==1 && $("#"+id).hasClass("si")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#DGNCATALOGOSDESCRIPCION").attr( {'required' : true});
		$("#"+id).removeClass('si');
		$("#"+id).addClass('no');
		$("#ID"+id).removeClass('col-xs-12');
		$("#ID"+id).addClass('col-xs-2');
	}else if (valor==2 && $("#"+id).hasClass("no")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#"+id).addClass('si');
		$("#"+id).removeClass('no');
		$("#ID"+id).removeClass('col-xs-2');
		$("#ID"+id).addClass('col-xs-12');
		$('#DGNCATALOGOSDESCRIPCION').val("");
		$("#DGNCATALOGOSDESCRIPCION").attr( {'required' : false});
		$('#DGNCATALOGOSARCHIVO').val("");
	}
}

function hidencamposCertificaciones(val,CLASS_HIDDEN) {
		var valor=val.value;
		var id=val.id;
		//alert(valor)
	if (valor==1 && $("#"+id).hasClass("si")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#DGNCERTIFICACIONESDESCRIPCION").attr( {'required' : true});
		$("#"+id).removeClass('si');
		$("#"+id).addClass('no');
		$("#ID"+id).removeClass('col-xs-12');
		$("#ID"+id).addClass('col-xs-2');
	}else if (valor==2 && $("#"+id).hasClass("no")){
		$('.'+CLASS_HIDDEN).toggle();
		$("#"+id).addClass('si');
		$("#"+id).removeClass('no');
		$("#ID"+id).removeClass('col-xs-2');
		$("#ID"+id).addClass('col-xs-12');
		$('#DGNCERTIFICACIONESDESCRIPCION').val("");
		$("#DGNCERTIFICACIONESDESCRIPCION").attr( {'required' : false});
		$('#DGNCERTIFICACIONESARCHIVO').val("");
	}
}

function hiddenCampos(CLASS_HIDDEN,EDITA){
	var IDTIPOPRODUCTOUSOS = $("#IDTIPOPRODUCTOUSOS").val();

	if (IDTIPOPRODUCTOUSOS == 1){
		if(EDITA==1){
			$("#IDRUBRO").val('1');
		}
		$("#IDRUBRO").attr( {'disabled' : true});
		$("#IDLINEA").attr( {'required' : true});
		$("#PRDPESO").attr( {'required' : true});
		$("#PRDANCHOMTS").attr( {'required' : true});
		$("#PRDLARGOMTS").attr( {'required' : true});
		$("#PRDALTOMTS").attr( {'required' : true});
		$("#PRDVOLUMEN").attr( {'required' : true});
		$('.'+CLASS_HIDDEN).show();
	}else{
		if(EDITA==1){
			$("#IDRUBRO").val('');
		}
		$("#IDRUBRO").attr( {'disabled' : false});
		$("#IDLINEA").attr( {'required' : false});
		$("#PRDPESO").attr( {'required' : false});
		$("#PRDANCHOMTS").attr( {'required' : false});
		$("#PRDLARGOMTS").attr( {'required' : false});
		$("#PRDALTOMTS").attr( {'required' : false});
		$("#PRDVOLUMEN").attr( {'required' : false});
		$('.'+CLASS_HIDDEN).hide();
	}
		$("#IDRUBRO").selectpicker("refresh");
}

function hiddenDependenciasCLT(CLASS_HIDDEN){

	var IDTIPOCLIENTE = $("#IDTIPOCLIENTE").val();

	if (IDTIPOCLIENTE == 1){
		$('.'+CLASS_HIDDEN).hide();
	}else if(IDTIPOCLIENTE==2){
		$('.'+CLASS_HIDDEN).show();
	}
}

function validacion(atributo){

	var PKMPAVKILOMETRO = $("#PKMPAVKILOMETRO").val();
	var PKMTERKILOMETRO = $("#PKMTERKILOMETRO").val();

	var DAVPAVKILOMETRO = $("#DAVPAVKILOMETRO").val();
	var DAVTERKILOMETRO = $("#DAVTERKILOMETRO").val();

	var MDVPAVKILOMETRO = $("#MDVPAVKILOMETRO").val();
	var MDVTERKILOMETRO = $("#MDVTERKILOMETRO").val();

	if( PKMPAVKILOMETRO > 1 ) { $("#PKMPAVKILOMETRO").val(1); PKMPAVKILOMETRO=1; }
	//else if( PKMPAVKILOMETRO < 1 && PKMPAVKILOMETRO != "" && PKMPAVKILOMETRO != 0) { $("#PKMPAVKILOMETRO").val(1); PKMPAVKILOMETRO=1; }
	else if( PKMTERKILOMETRO > 1 ) { $("#PKMTERKILOMETRO").val(1); PKMTERKILOMETRO=1;}
	//else if( PKMTERKILOMETRO < 1 && PKMTERKILOMETRO != "" && PKMTERKILOMETRO != 0) { $("#PKMTERKILOMETRO").val(1); PKMTERKILOMETRO=1;}


	if( (Number(DAVPAVKILOMETRO) + Number(DAVTERKILOMETRO)) > 0 ){
		if(atributo.id == 'PKMPAVKILOMETRO'){
			if( PKMPAVKILOMETRO < 1){
			$("#PKMTERKILOMETRO").val(1);
			PKMTERKILOMETRO = 1;
			$(".bloque1A").val(0);
			$(".bloque1A").attr( {'readonly' : true});
			$(".bloque1B").attr( {'readonly' : false});
			}
		}

	if(atributo.id == 'PKMTERKILOMETRO'){
			if( PKMTERKILOMETRO < 1){
			$("#PKMPAVKILOMETRO").val(1);
			PKMPAVKILOMETRO=1;
			$(".bloque1B").val(0);
			$(".bloque1B").attr( {'readonly' : true});
			$(".bloque1A").attr( {'readonly' : false});
		}
	}
	}else{
		if( (Number(PKMPAVKILOMETRO) + Number(PKMTERKILOMETRO)) > 1 ) { $("#"+atributo.id).val(0); return; }

		if( PKMPAVKILOMETRO == 1 ){
			$(".bloque1B").attr( {'readonly' : true} );
			$(".bloque1B").val(0);
		}
		else{
			$(".bloque1B").attr( {'readonly' : false} );
		}

		if( PKMTERKILOMETRO == 1 ){
			$(".bloque1A").attr( {'readonly' : true} );
			$(".bloque1A").val(0);
		}
		else{
			$(".bloque1A").attr( {'readonly' : false} );
		}

	}


if( DAVPAVKILOMETRO > 19 ) { $("#DAVPAVKILOMETRO").val(19); DAVPAVKILOMETRO=19;}
else if( DAVTERKILOMETRO > 19 ) { $("#DAVTERKILOMETRO").val(19);DAVTERKILOMETRO=19;}

if( (Number(MDVPAVKILOMETRO) + Number(MDVTERKILOMETRO)) > 0) {
	if(atributo.id == 'DAVPAVKILOMETRO'){
		DAVTERKILOMETRO = 19 - Number(DAVPAVKILOMETRO);
		$("#DAVTERKILOMETRO").val(DAVTERKILOMETRO);
	}
	else if(atributo.id == 'DAVTERKILOMETRO'){
		DAVPAVKILOMETRO = 19 - Number(DAVTERKILOMETRO);
		$("#DAVPAVKILOMETRO").val(DAVPAVKILOMETRO);
	}

}
else{

	if( DAVPAVKILOMETRO == 19 ){
			$(".bloque2B").attr( {'readonly' : true} );
			$(".bloque2B").val(0);
			$(".bloque3").attr( {'readonly' : false} );
			return;
		}
		else{
			$(".bloque2B").attr( {'readonly' : false} );
		}

	if( DAVTERKILOMETRO == 19 ){
			$(".bloque2A").attr( {'readonly' : true} );
			$(".bloque2A").val(0);
			$(".bloque3").attr( {'readonly' : false} );
			return;
		}
		else{
			$(".bloque2A").attr( {'readonly' : false} );
		}
	if( (Number(DAVPAVKILOMETRO) + Number(DAVTERKILOMETRO)) > 19 ) { $("#"+atributo.id).val(0); return; }
}


	if( (Number(PKMPAVKILOMETRO) + Number(PKMTERKILOMETRO)) == 1 ) {
		$(".bloque2").attr( {'readonly' : false} );
	}else{$(".bloque2").attr( {'readonly' : true} );}
	if( (Number(DAVPAVKILOMETRO) + Number(DAVTERKILOMETRO)) == 19 ) {
		$(".bloque3").attr( {'readonly' : false} );
	}else{$(".bloque3").attr( {'readonly' : true} );}


}

function estimacion(atributo){

		var ESTIMACIONCOBRO = $("#ESTIMACIONCOBRO").val();
		var ESTIMACIONPAGADA = $("#ESTIMACIONPAGADA").val();
		var ESTIMACION = $("#"+atributo.id).val();
		// ESTFECHAPAGO

		if (atributo.id=="ESTIMACIONCOBRO"){
			if (ESTIMACION > 0){
				$("#ESTIMACIONPAGADA").attr( {'readonly' : true});
				$("#ESTIMACIONPAGADA").val(0);
				$("#ESTFECHAPAGO").attr( {'readonly' : true});
				$("#ESTFECHAPAGO").val(0);
			}else{
				$("#ESTIMACIONPAGADA").attr( {'readonly' : false} );
				$("#ESTFECHAPAGO").attr({'readonly' : false} );
			}
		}

		if (atributo.id=="ESTIMACIONPAGADA"){
			if (ESTIMACION > 0){
				$("#ESTIMACIONCOBRO").attr( {'readonly' : true} );
				$("#ESTIMACIONCOBRO").val(0);
				$("#ESTFECHAPAGO").attr( {'required' : true} );

				$("#ESTFECHAPAGO").attr( {'readonly' : false} );
				$('#ESTFECHAPAGO').val(datetoday());
			}else{
				$("#ESTIMACIONCOBRO").attr( {'readonly' : false} );
				$("#ESTFECHAPAGO").attr( {'required' : false} );
			}
		}

		if (ESTIMACIONPAGADA <= 0 && ESTIMACIONCOBRO <= 0){
			$("#ESTFECHAPAGO").attr( {'readonly' : true});
			$("#ESTFECHAPAGO").val(0);
		}

	}



function datetoday () {
	var now = new Date();
	var dd = now.getDate();
	var mm = now.getMonth()+1;
	var yyyy = now.getFullYear();

	if(dd<10){
		dd='0'+dd
	}
	if(mm<10){
		mm='0'+mm
	}
	var today = yyyy + '-' + mm + '-' + dd;
	return today;
}

function ExportPdfExcelForClt(info, typeExport){
	jPrompt('A quien corresponda:', 'Publico en general', 'Confirmación!', function(r) {
		if( r ) {
			$("#CLT_COTIZA").val(r);
			ExportPdfExcel(info, typeExport);
		}else{
			$("#CLT_COTIZA").val("");
			ExportPdfExcel(info, typeExport);
		}
	});
}

function ExportPdfExcel2(info, typeExport){ //Solo para Excel para cabecera detalle
	
	var page = WEB_ROOT+"/ajax/exportexcelpdf.php";
	var htmlCampos = $('#TablaHtmlCampos').html();
	var htmlDatos = $('#TablaHtmlDatos').html();
	var htmlEtiqueta = $('#TablaHtmlEtiqueta').html();
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlEtiquetaCabecera = $('#etiquetaexportCabecera').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var ENUMERATEPDFINFUNCION = $("#TablaHtmlEnumeratePDF").html();
	var CLT_COTIZA = $("#CLT_COTIZA").val();

	var DATOS_GET = "";
	var typeExportPDF="";
	var Title = "";

	if(typeExport=="mailPDF"){
		typeExportPDF= "PDF";
		Title=info;
	}else{
		typeExportPDF=typeExport;
		if(info == 'NULL'){
			if(typeExport=='PDF'){
				Title = $("#DescargarPDF").attr("title");
			}else if(typeExport=='EXCEL'){
				Title = $("#ExportPdfExcel").attr("title");
			}
		}else if(info=='DescargarExcel'){
			Title = $("#DescargarExcel").attr("title");
		}else{
			Title = info.title;
		}		
	}

	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : typeExportPDF,
			'name' : Title,
			//'html' : html,
			'htmlCampos' : htmlCampos,
			'htmlDatos' : htmlDatos,
			'htmlEtiqueta' : htmlEtiqueta,
			'htmlEtiquetaCabecera' : htmlEtiquetaCabecera,
			'htmlIDF' : htmlIDF,
			'htmlIMM_accion' : htmlIMM_accion,
			'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
			'CLT_COTIZA' : CLT_COTIZA,
		},
		success: function(response){
			if(typeExport!="mailPDF"){
				DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+"&htmlIDF="+htmlIDF+"&htmlIMM_accion="+htmlIMM_accion+"&CLT_COTIZA="+CLT_COTIZA+"&ENUMERATEPDFINFUNCION="+ENUMERATEPDFINFUNCION;
				web = WEB_ROOT+"/ajax/exportexcelpdf.php" + DATOS_GET;
				myWindow = window.open(web, 'windowOpenTab');
			}
		}
	});

}

function ExportPdfExcel(info, typeExport){// Crear PDFExcel
	
	if (typeExport == 'EXCEL'){
		var page = WEB_ROOT+"/ajax/exportexcelpdf.php";
		var htmlCampos = $('#TablaHtmlCampos').html();
		var htmlDatos = $('#TablaHtmlDatos').html();
		var htmlEtiqueta = $('#TablaHtmlEtiqueta').html();
		var htmlIDF = $('#TablaHtmlIDF').html();
		var htmlEtiquetaCabecera = $('#etiquetaexportCabecera').html();
		var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
		var ENUMERATEPDFINFUNCION = $("#TablaHtmlEnumeratePDF").html();
		var CLT_COTIZA = $("#CLT_COTIZA").val();

		var DATOS_GET = "";
		var typeExportPDF="";
		var Title = "";

		if(typeExport=="mailPDF"){
			typeExportPDF= "PDF";
			Title=info;
		}else{
			typeExportPDF=typeExport;
			if(info == 'NULL'){
				if(typeExport=='PDF'){
					Title = $("#DescargarPDF").attr("title");
				}else if(typeExport=='EXCEL'){
					Title = $("#DescargarExcel").attr("title");
				}
			}else if(info=='DescargarExcel'){
				Title = $("#DescargarExcel").attr("title");
			}else{
				Title = info.title;
			}		
		}
		if(Title == undefined){
			Title = info;
		}

		$.ajax({
			type: "POST",
			url: page,
			data: {
				'type' : typeExportPDF,
				'name' : Title,
				//'html' : html,
				'htmlCampos' : htmlCampos,
				'htmlDatos' : htmlDatos,
				'htmlEtiqueta' : htmlEtiqueta,
				'htmlEtiquetaCabecera' : htmlEtiquetaCabecera,
				'htmlIDF' : htmlIDF,
				'htmlIMM_accion' : htmlIMM_accion,
				'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
				'CLT_COTIZA' : CLT_COTIZA,
			},
			success: function(response){
				if(typeExport!="mailPDF"){
					DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+"&htmlIDF="+htmlIDF+"&htmlIMM_accion="+htmlIMM_accion+"&CLT_COTIZA="+CLT_COTIZA+"&ENUMERATEPDFINFUNCION="+ENUMERATEPDFINFUNCION;
					web = WEB_ROOT+"/ajax/exportexcelpdf.php" + DATOS_GET;
					myWindow = window.open(web, 'windowOpenTab');
				}
			}
		});
}else{
		var page = WEB_ROOT+"/ajax/exportexcelpdfP.php";
		
		var htmlIDF = $('#TablaHtmlIDF').html();
		var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
		var HtmlIdCstClt = $('#HtmlIdCstClt').html();
		var datosForm = '';

		Title = info.title;
		if(info == 'NULL'){
				if(typeExport=='PDF'){
					Title = $("#DescargarPDF").attr("title");
				}else if(typeExport=='EXCEL'){
					Title = $("#DescargarExcel").attr("title");
				}
			}
		else if(Title == undefined){
			Title = info;
		}
		
		if(htmlIMM_accion!=''){
			datosForm = datosForm+"&MM_accion="+htmlIMM_accion;
		}
		if(htmlIDF!='')	{
			datosForm = datosForm+"&IDF="+htmlIDF;
		}
		if(HtmlIdCstClt!=''){
			datosForm = datosForm+"&IdCstClt="+HtmlIdCstClt;
		}

		DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+datosForm;
		web = WEB_ROOT+"/ajax/exportexcelpdfP.php" + DATOS_GET;
		myWindow = window.open(web, 'windowOpenTab');
	}
}

function ExportPdfExcelFormat(info,typeExport,accion,IDF,IdCstClt,ENUMERATEPDFINFUNCION,VENDESGLOSEIVA){// Crear PDFExcel con formato
	
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var HtmlIdCstClt = $('#HtmlIdCstClt').html();
	var datosForm = '';
	
	Title = info;
	
	if(accion!=''){
		datosForm = datosForm+"&MM_accion="+accion;
	}
	if(IDF!='')	{
		datosForm = datosForm+"&IDF="+IDF;
	}
	if(IdCstClt!=''){
		datosForm = datosForm+"&IdCstClt="+IdCstClt;
	}
	if(ENUMERATEPDFINFUNCION!=''){
		datosForm = datosForm+"&ENUMERATEPDFINFUNCION="+ENUMERATEPDFINFUNCION;
	}
	if(VENDESGLOSEIVA!=''){
		datosForm = datosForm+"&VDI="+VENDESGLOSEIVA;
	}

	DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+datosForm;
	web = WEB_ROOT+"/ajax/exportexcelpdfP.php" + DATOS_GET;
	myWindow = window.open(web, 'windowOpenTab');
}
function ExportPdfExcelFormatC(info,typeExport,accion,IDF,IdCstClt,ENUMERATEPDFINFUNCION,VENDESGLOSEIVA){// Crear PDFExcel con formato
	
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var HtmlIdCstClt = $('#HtmlIdCstClt').html();
	var datosForm = '';
	
	Title = info;
	
	if(accion!=''){
		datosForm = datosForm+"&MM_accion="+accion;
	}
	if(IDF!='')	{
		datosForm = datosForm+"&IDF="+IDF;
	}
	if(IdCstClt!=''){
		datosForm = datosForm+"&IdCstClt="+IdCstClt;
	}
	if(ENUMERATEPDFINFUNCION!=''){
		datosForm = datosForm+"&ENUMERATEPDFINFUNCION="+ENUMERATEPDFINFUNCION;
	}
	if(VENDESGLOSEIVA!=''){
		datosForm = datosForm+"&VDI="+VENDESGLOSEIVA;
	}

	DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+datosForm;
	web = WEB_ROOT+"/ajax/exportexcelpdfC.php" + DATOS_GET;
	myWindow = window.open(web, 'windowOpenTab');
}

function pruebasPDF(typeExport,info,accion,IDF,IdCstClt){
	var page = WEB_ROOT+"/ajax/exportexcelpdfP.php";
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var datosForm = '';
	Title = info.title;
	
	if(accion!=''){
		datosForm = datosForm+"&MM_accion="+accion;
	}
	if(IDF!='')	{
		datosForm = datosForm+"&IDF="+IDF;
	}
	if(IdCstClt!=''){
		datosForm = datosForm+"&IdCstClt="+IdCstClt;
	}

	DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+datosForm;
	web = WEB_ROOT+"/ajax/exportexcelpdfP.php" + DATOS_GET;
	myWindow = window.open(web, 'windowOpenTab');
}

function ExportPdfExcelPrueba(info,typeExport){ //pruebas borrar
	// typeExport - tipo de archivo (PDF,EXCEL)
	// info - titulo/nombre de archivo
	// IDF 
	// accion 
	// numFu - numero de configuracion en la tabla ENUMERATEPDFINFUNCION
	var page = WEB_ROOT+"/ajax/exportexcelpdfP.php";
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	Title = info.title;

	DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+"&htmlIDF="+htmlIDF+"&htmlIMM_accion="+htmlIMM_accion;
	web = WEB_ROOT+"/ajax/exportexcelpdfP.php" + DATOS_GET;
	myWindow = window.open(web, 'windowOpenTab');
	
	/*var DATOS_GET = "";
	var typeExportPDF="";
	var Title = "";

	if(typeExport=="mailPDF"){
		typeExportPDF= "PDF";
		Title=info;
	}else{
		typeExportPDF=typeExport;
		if(info == 'NULL'){
			if(typeExport=='PDF'){
				Title = $("#DescargarPDF").attr("title");
			}else if(typeExport=='EXCEL'){
				Title = $("#ExportPdfExcel").attr("title");
			}
		}else if(info=='DescargarExcel'){
			Title = $("#DescargarExcel").attr("title");
		}else{
			Title = info.title;
		}		
	}*/



	// $.ajax({
	// 	type: "POST",
	// 	url: page,
	// 	data: {
	// 		'type' : 'PRINTPDF',
	// 		'name' : Title,
	// 		//'html' : html,
	// 		'htmlIDF' : htmlIDF,
	// 		'htmlIMM_accion' : htmlIMM_accion
	// 	},
	// 	success: function(response){
	// 		// console.log(response);
	// 		if(typeExport!="mailPDF"){
	// 			DATOS_GET = "?type=PRINT"+typeExport+"&name="+Title+"&htmlIDF="+htmlIDF+"&htmlIMM_accion="+htmlIMM_accion+"&CLT_COTIZA="+CLT_COTIZA+"&ENUMERATEPDFINFUNCION="+ENUMERATEPDFINFUNCION;
	// 			web = WEB_ROOT+"/ajax/exportexcelpdf.php" + DATOS_GET;
	// 			myWindow = window.open(web, 'windowOpenTab');
	// 		}
	// 	}
	// });

}


function PrintTicket(id,status,tipovista){
	if (status == "2") {
		page = WEB_ROOT+"/ajax/printticket.php?type=PrintTicket&id="+id+"&tipovista="+tipovista;
		window.open(page, this.target, 'width=750,height=650'); return false;
	} else {
		jAlert('Finalice la venta para poder ver el <b class="red">ticket</b>!',"Alerta!!");
	}
}

function PrintTicketComandero(id,status,tipovista){
	if (status == "2") {
		page = WEB_ROOT+"/ajax/printticketComandero.php?type=PrintTicket&id="+id+"&tipovista="+tipovista;
		window.open(page, this.target, 'width=750,height=650'); return false;
	} else {
		jAlert('Finalice la venta para poder ver el <b class="red">ticket</b>!',"Alerta!!");
	}
}

function ExportarZipAll(info) {

	var page = WEB_ROOT+"/ajax/compresszip.php";
	var CNXZIP = $('#CNXZIP').html();
	var CAMPOSFILEZIP = $('#CAMPOSFILEZIP').html();
	var SQLZIP = $('#SQLZIP').html();
	var NAMEZIP = info.title;
	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : "CreateZip",
			'CNXZIP' : CNXZIP,
			'SQLZIP' : SQLZIP,
			'CAMPOSFILEZIP' : CAMPOSFILEZIP,
			'NAMEZIP' : NAMEZIP
		},
		success: function(response){
			console.log(response);
			if (response == "vacio") {
				jAlert('No se encontraron archivos para descargar!',"Alerta!!");
			} else {
				window.open(response, 'windowOpenTab');
			}
		}
	});

}

function existeentabla(tabla,columna,dato){
	// alert(tabla+" "+columna+" "+dato);
	if (dato != "") {
		var page = WEB_ROOT+"/ajax/existeentabla.php";

		$.ajax({
			type: "POST",
			url: page,
			data: {
				'type' : "existe",
				'tabla' : tabla,
				'columna' : columna,
				'dato' : dato
			},
			beforeSend: function(){
				$("#existe"+columna).hide();
			},
			success: function(response){
				//alert(response)
				$("#existe"+columna).html(response);
				$("#existe"+columna).show();
			}
		});
	}else{
		$("#existe"+columna).hide();
		$("#existe"+columna).html("");
	}
}
function cerrarExisteTabla(columna){
		$("#existe"+columna.id).hide();
}

function hidenExistente(id) {
	$("#"+id).hide();
}

function ModalComanderoOrden(id){
	var page = WEB_ROOT+"/ajax/ordenComandero.php";
	$.ajax({
			type: "POST",
			url: page,
			data: {
				'IdCstClt' : id
			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				if(response==1){
					jAlert("Existe una orden abierta.","¡No puedes terminar venta!");
				}else{
					ModalGeneralComandero(id);
				}
			}
		});
}

function ModalGeneralComandero(id){
	if(id==""){
	var VNTID = $("#IDVNT").val();
	}else{
	var VNTID = id;
	}
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ModalGeneral.php";
	var VENFECHA = $('#VENFECHA').val();
	var CLTRAZONSOCIAL = $('#CLTRAZONSOCIAL').val();
	var IDALMACEN = $('#IDALMACEN').val();
	var IDCLIENTE = $('#IDCLIENTE').val();


	if(VENFECHA != '' && IDALMACEN != '' &&  IDCLIENTE != ''){
		$.ajax({
			type: "GET",
			url: page,
			data: {
				'MM_accion' : "editar",
				'ID' : 6,
				'IDF' : 287,
				'IdCstClt' : VNTID,
				'VENFECHA' : VENFECHA,
				'CLTRAZONSOCIAL' : CLTRAZONSOCIAL,
				'IDALMACEN' : IDALMACEN,
				'IDCLIENTE' : IDCLIENTE,
				'MODAL' : 'SI'

			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				//imprimit todo el formulario
				$('#contenidoModalHidden').html(response);
				//obtener los html del formulario
				// var frmAction = $('#formGeneral').attr('action');
				var headerModal = $('#TITULOAccionModal').html();
				var footerModal = $('#BTNAccionModal').html();
				var frmContenido = $('#formGeneral').html();
				// alert(frmContenido);

				//limpiar contenido
				$('#contenidoModalHidden').html("");

				//asignar y construir nuevo formulario
				// $('#formModalGeneral').attr({
				// 	'action' : frmAction
				// });
				$('#headerModal').html(headerModal);
				$('#footerModal').html(footerModal);

				$('#contenidoModal').html(frmContenido);
				$('#HeaderForm').remove();
				//mostrar el modal
				$('#myModal').modal();
			}
		});
	}else{
		if(VENFECHA == ''){
			var alertVenta = 'Ingrese *Fecha';
		}else if(IDCLIENTE== ''){
			var alertVenta = 'Ingrese *Cliente';
		}else if(IDALMACEN == ''){
			var alertVenta = 'Ingrese *Almacén';
		}
		jAlert(alertVenta,"¡Alerta!");
	}
}

function ModalGeneral(id){
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ModalGeneral.php";
	var VENFECHA = $('#VENFECHA').val();
	var CLTRAZONSOCIAL = $('#CLTRAZONSOCIAL').val();
	var IDALMACEN = $('#IDALMACEN').val();
	var IDCLIENTE = $('#IDCLIENTE').val();

	if(id==""){
	var VNTID = $("#IDFORM").val();
	}else{
	var VNTID = id;
	}

	if(VENFECHA != '' && IDALMACEN != '' &&  IDCLIENTE != ''){ 
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'MM_accion' : "editar",
					'ID' : 5,
					'IDF' : 233,
					'IdCstClt' : VNTID,
					'VENFECHA' : VENFECHA,
					'CLTRAZONSOCIAL' : CLTRAZONSOCIAL,
					'IDALMACEN' : IDALMACEN,
					'IDCLIENTE' : IDCLIENTE,
					'MODAL' : 'SI'

				},
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					//imprimit todo el formulario
					$('#contenidoModalHidden').html(response);
					//obtener los html del formulario
					// var frmAction = $('#formGeneral').attr('action');
					var headerModal = $('#TITULOAccionModal').html();
					var footerModal = $('#BTNAccionModal').html();
					var frmContenido = $('#formGeneral').html();
					// alert(frmContenido);

					//limpiar contenido
					$('#contenidoModalHidden').html("");

					//asignar y construir nuevo formulario
					// $('#formModalGeneral').attr({
					// 	'action' : frmAction
					// });
					$('#headerModal').html(headerModal);
					$('#footerModal').html(footerModal);

					$('#contenidoModal').html(frmContenido);
					$('#HeaderForm').remove();
					//mostrar el modal
					$('#myModal').modal();
					$("#myModal").on('shown.bs.modal', function () {
						$("#formModalGeneral #VENEFECTIVO").focus();
					});
				}
			});
	}else{
		if(VENFECHA == ''){
			var alertVenta = 'Ingrese *Fecha';
		}else if(IDCLIENTE== ''){
			var alertVenta = 'Ingrese *Cliente';
		}else if(IDALMACEN == ''){
			var alertVenta = 'Ingrese *Almacén';
		}
		jAlert(alertVenta,"¡Alerta!");
	}
}
function ajustarprecio(){
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ajustarPrecio.php";
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'MM_accion' : "nuevo",
					'ID' : 2,
					'IDF' : 492,
					'MODAL' : 'SI'

				},
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					//imprimit todo el formulario
					$('#contenidoModalHidden').html(response);
					var headerModal = $('#TITULOAccionModal').html();
					var footerModal = $('#BTNAccionModal').html();
					var frmContenido = $('#formGeneral').html();
					// alert(frmContenido);

					//limpiar contenido
					$('#contenidoModalHidden').html("");
					$('#headerModal').html(headerModal);
					$('#footerModal').html(footerModal);

					$('#contenidoModal').html(frmContenido);
					$('#HeaderForm').remove();
					//mostrar el modal
					$('#myModal').modal();
				}
			});
}

function ajusteP(IDF){
	var IDFAMILIA = $('#IDFAMILIA').val();
	var IDTIPOAJUSTE = $('#IDTIPOAJUSTE').val();
	var PORCENTAJE = $('#PORCENTAJE').val();
//var FUNID = $("#FUNID").val();
var boton = $("#ACEPTARAP").val();
if(IDFAMILIA == ""){
jAlert('¡Ingrese familia!',"¡Alerta!", function(){
    	$("#FAMILIA").focus();
		});
}else if(IDTIPOAJUSTE == ""){ 
jAlert('¡Ingrese tipo de ajuste!',"¡Alerta!", function(){
    	$("#IDTIPOAJUSTE").focus();
		});
}else if(PORCENTAJE == ""){ 
jAlert('¡Ingrese porcentaje!',"¡Alerta!", function(){
    	$("#PORCENTAJE").focus();
		});
}else{
var page = WEB_ROOT+"/ajax/Ajusteprecio.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'FUNID' : IDF,
		'IDFAMILIA' : IDFAMILIA,
		'IDTIPOAJUSTE' : IDTIPOAJUSTE,
		'PORCENTAJE' : PORCENTAJE,
		'MM_accion' : boton,
		'valor' : 1
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);

		var msj=respuestaphp.msj;
		//$('#mensajeAlert').html(msj);
		$('#myModal').modal('toggle');
		location.reload();
		//$('#mensajeAlert').html(respuestaphp.va);
		//$('#mensajeAlert').html(respuestaphp.va);
		//alert(respuestaphp.va)
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

}
function ModalAjustarMonto(id){
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ModalGeneral.php";

			$.ajax({
				type: "GET",
				url: page,
				data: {
					'MM_accion' : "editar",
					'ID' : 4,
					'IDF' : 381,
					'IdCstClt' : id,
					'MODAL' : 'SI'

				},
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					//imprimit todo el formulario
					$('#contenidoModalHidden').html(response);
					//obtener los html del formulario
					// var frmAction = $('#formGeneral').attr('action');
					var headerModal = $('#TITULOAccionModal').html();
					var footerModal = $('#BTNAccionModal').html();
					var frmContenido = $('#formGeneral').html();
					// alert(frmContenido);

					//limpiar contenido
					$('#contenidoModalHidden').html("");

					$('#headerModal').html(headerModal);
					$('#footerModal').html(footerModal);

					$('#contenidoModal').html(frmContenido);
					$('#HeaderForm').remove();
					//mostrar el modal
					$('#myModal').modal();
					$("#myModal").on('shown.bs.modal', function () {
						//$("#formModalGeneral #VENEFECTIVO").focus();
					});
				}
			});
	
}

function AddClt(id){
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-AddClt.php";
	/*var VENFECHA = $('#VENFECHA').val();
	var CLTRAZONSOCIAL = $('#CLTRAZONSOCIAL').val();
	var IDALMACEN = $('#IDALMACEN').val();
	var IDCLIENTE = $('#IDCLIENTE').val();*/

	/*if(id==""){
	var VNTID = $("#IDFORM").val();
	}else{
	var VNTID = id;
	}*/

	if(VENFECHA != '' && IDALMACEN != '' &&  IDCLIENTE != ''){ 
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'MM_accion' : "editar",
					'ID' : 6,
					'IDF' : 308,
					/*'IdCstClt' : VNTID,
					'VENFECHA' : VENFECHA,
					'CLTRAZONSOCIAL' : CLTRAZONSOCIAL,
					'IDALMACEN' : IDALMACEN,
					'IDCLIENTE' : IDCLIENTE,*/
					'MODAL' : 'SI'

				},
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					//imprimit todo el formulario
					$('#contenidoModalHidden').html(response);
					//obtener los html del formulario
					// var frmAction = $('#formGeneral').attr('action');
					var headerModal = $('#TITULOAccionModal').html();
					var footerModal = $('#BTNAccionModal').html();
					var frmContenido = $('#formGeneral').html();
					// alert(frmContenido);

					//limpiar contenido
					$('#contenidoModalHidden').html("");

					//asignar y construir nuevo formulario
					// $('#formModalGeneral').attr({
					// 	'action' : frmAction
					// });
					$('#headerModal').html(headerModal);
					$('#footerModal').html(footerModal);

					$('#contenidoModal').html(frmContenido);
					$('#HeaderForm').remove();
					//mostrar el modal
					$('#myModal').modal();
				}
			});
	}else{
		if(VENFECHA == ''){
			var alertVenta = 'Ingrese *Fecha';
		}else if(IDCLIENTE== ''){
			var alertVenta = 'Ingrese *Cliente';
		}else if(IDALMACEN == ''){
			var alertVenta = 'Ingrese *Almacén';
		}
		jAlert(alertVenta,"¡Alerta!");
	}
}


function saveClt(){	
var FUNID = $("#FUNID").val();
var boton = $("#ACEPTARCLT").val();
var direccion =$("#CLTCALLE").val();
var nombre = $("#CLTNOMBRECOMERCIAL").val();
var TelCel =$("#CLTCNTCEL").val();
var TCliente =$("#IDTIPOCLIENTE").val();

if(nombre == ""){
jAlert('¡Ingrese nombre comercial!',"¡Alerta!")
$("#CLTNOMBRECOMERCIAL").focus();
}else if(direccion == ""){ 
jAlert('¡Ingrese apellido dirección!',"¡Alerta!")
$("#CLTCALLE").focus();
}else if(TelCel == ""){ 
jAlert('¡Ingrese número de teléfono celular!',"¡Alerta!")
$("#CLTCNTCEL").focus();
}else{
var page = WEB_ROOT+"/ajax/addCLT.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'FUNID' : FUNID,
		'nombre' : nombre,
		'direccion' : direccion,
		'TelCel' : TelCel,
		'TCliente' : TCliente,
		'MM_accion' : boton,
		'valor' : 1
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);

		var msj=respuestaphp.msj;
		//$('#mensajeAlert').html(msj);
		$('#myModal').modal('toggle');
		//$('#mensajeAlert').html(respuestaphp.va);
		$('#mensajeAlert').html(msj);
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

}

function ModalGeneralCompras(id){
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ModalGeneralCompras.php";
	var CMPFECHA = $('#CMPFECHA').val();
	var IDPROVEEDOR = $('#IDPROVEEDOR').val();
	var IDALMACEN = $('#IDALMACEN').val();
	var IDCLIENTE = $('#IDCLIENTE').val();

	$.ajax({
		type: "GET",
		url: page,
		data: {
			'MM_accion' : "editar",
			'ID' : 5,
			'IDF' : 243,
			'IdCstClt' : id,
			'CMPFECHA' : CMPFECHA,
			'IDPROVEEDOR' : IDPROVEEDOR,
			'IDALMACEN' : IDALMACEN,
			'IDCLIENTE' : IDCLIENTE,
			'MODAL' : 'SI',


		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//imprimit todo el formulario
			$('#contenidoModalHidden').html(response);
			//obtener los html del formulario
			// var frmAction = $('#formGeneral').attr('action');
			var headerModal = $('#TITULOAccionModal').html();
			var footerModal = $('#BTNAccionModal').html();
			var frmContenido = $('#formGeneral').html();
			// alert(frmContenido);

			//limpiar contenido
			$('#contenidoModalHidden').html("");

			//asignar y construir nuevo formulario
			// $('#formModalGeneral').attr({
			// 	'action' : frmAction
			// });
			$('#headerModal').html(headerModal);
			$('#footerModal').html(footerModal);

			$('#contenidoModal').html(frmContenido);
			$('#HeaderForm').remove();
			//mostrar el modal
			$('#myModal').modal();
		}
	});
}

function modalEnviarMail(tipo,DG,IdCstClt){
	/*DG = ocultar o mostrar IVA*/
	var page = WEB_ROOT+"/pages/envioMailModal.php";
	var CMPFECHA = $('#CMPFECHA').val();
	var IDPROVEEDOR = $('#IDPROVEEDOR').val();
	var IDALMACEN = $('#IDALMACEN').val();
	var COM = '';
	if(tipo=='VENTA' || tipo=='VENTAD'){
		var id = $('#IDCLIENTE').val();
	}else if(tipo=='VENTAC' || tipo=='VENTADC'){
		var id = $('#IDCLIENTE').val();
		COM = '1';
	}else if(tipo=='COMPRA' || tipo=='COMPRAD' || tipo=='COMPRAOFM' || tipo=='COMPRAOFMD'){
		var id = $('#IDPROVEEDOR').val();	
	}

	$.ajax({
		type: "GET",
		url: page,
		data: {
			'MM_accion' : "editar",
			'MODAL' : 'SI',
			'tipo' : tipo,
			'id' : id,
			'DG' : DG,
			'IdCstClt' : IdCstClt,
			'COM' : COM
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//imprimit todo el formulario
			$('#contenidoModalHidden').html(response);
			//obtener los html del formulario
			// var frmAction = $('#formGeneral').attr('action');
			var headerModal = $('#TITULOAccionModal').html();
			var footerModal = $('#BTNAccionModal').html();
			var frmContenido = $('#formGeneral').html();
			// alert(frmContenido);

			//limpiar contenido
			$('#contenidoModalHidden').html("");

			//asignar y construir nuevo formulario
			// $('#formModalGeneral').attr({
			// 	'action' : frmAction
			// });
			$('#headerModal').html(headerModal);
			$('#footerModal').html(footerModal);

			$('#contenidoModal').html(frmContenido);
			$('#HeaderForm').remove();
			//mostrar el modal
			$('#myModal').modal();
		}
	});
}

function ModalVb(){
var id= $("#ventaid").val();
	var page = WEB_ROOT+"/pages/ventaBModal.php";
	$.ajax({
		type: "GET",
		url: page,
		data: {
			'MM_accion' : "editar",
			'ID' : 5,
			'IDF' : 242,
			'IdCstClt' : id,
			'MODAL' : 'SI'

		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//imprimit todo el formulario
			$('#contenidoModalHidden').html(response);
			//obtener los html del formulario
			// var frmAction = $('#formGeneral').attr('action');
			var headerModal = $('#TITULOAccionModal').html();
			var footerModal = $('#BTNAccionModal').html();
			var frmContenido = $('#formGeneral').html();
			// var frmScript = $('#frmScript').html();
			// alert(frmContenido);

			//limpiar contenido
			$('#contenidoModalHidden').html("");

			//asignar y construir nuevo formulario
			// $('#formModalGeneral').attr({
			// 	'action' : frmAction
			// });
			$('#headerModal').html(headerModal);
			$('#footerModal').html(footerModal);
			// $('#modalScript').html(frmScript);

			$('#contenidoModal').html(frmContenido);
			$('#HeaderForm').remove();
			//mostrar el modal
			$('#myModal').modal();
			$("#myModal").on('shown.bs.modal', function () {
				$('#efectivo').focus();
			});
			$("#myModal").on('hidden.bs.modal', function () {
            	$('#CODIGOPRODUCTOUNIDAD').focus();
    		});
		}
	});
}

function ModalPantone(){
	var page = WEB_ROOT+"/ajax/PantoneModal.php";
	$.ajax({
		type: "GET",
		url: page,
		data: {
			/*'MM_accion' : "editar",
			'ID' : 5,
			'IDF' : 242,
			'IdCstClt' : id,*/
			'MODAL' : 'SI'

		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//imprimit todo el formulario
			$('#contenidoModalHidden').html(response);
			//obtener los html del formulario
			// var frmAction = $('#formGeneral').attr('action');
			var headerModal = $('#TITULOAccionModal').html();
			var footerModal = $('#BTNAccionModal').html();
			var frmContenido = $('#formGeneral').html();
			// var frmScript = $('#frmScript').html();
			// alert(frmContenido);

			//limpiar contenido
			$('#contenidoModalHidden').html("");

			//asignar y construir nuevo formulario
			// $('#formModalGeneral').attr({
			// 	'action' : frmAction
			// });
			$('#headerModal').html(headerModal);
			$('#footerModal').html(footerModal);
			// $('#modalScript').html(frmScript);

			$('#contenidoModal').html(frmContenido);
			$('#HeaderForm').remove();
			//mostrar el modal
			$('#myModal').modal();
			$("#myModal").on('shown.bs.modal', function () {
				$('#efectivo').focus();
			});
			$("#myModal").on('hidden.bs.modal', function () {
            	$('#CODIGOPRODUCTOUNIDAD').focus();
    		});
		}
	});
}

function validarfileimagen(idfcampo,columna,tipo){
	var data  = new FormData();
	$.each($('.tipofileimagenpdf'), function(index, value) {
		var id = $(this).attr('id');
		var inputFile = document.getElementById(id);
		if($(inputFile).val()!=""){
			var filea = inputFile.files[0];
			data.append(id,filea);
		}
	});
	
	$.ajax({
		url: "../ajax/validararchivo.php?idfcampo="+idfcampo+"&columna="+columna+"&tipo="+tipo,
		data: data,
		processData: false,
		contentType: false,
		cache:true,
		type: 'POST',
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//$("#pruebaimpresion").html(response);
			if(response=="noarchivo"){
			jAlert('El archivo que intenta subir no es valido!',"Alerta!!");
			/*$("#mensaje").html("<div class='alert alert-danger alert-dismissable hiddenalertfadeout_info_1'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>Archivo no valido, solo puede adjuntar imanenes de extensión (jpg,png).</div>");	
			window.setTimeout(function() {
			$(".hiddenalertfadeout_info_1").hide("slow");
			}, 6800);*/			
			}else if(response=="noextension"){
			jAlert('El archivo no se cargo porque la extensión no es permitido!',"Alerta!!");
			}else if(response=="notamanio"){
			jAlert('Archivo no se cargo porque sobrepaso el tamaño maximo permitido!',"Alerta!!");
			}
			
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

function validarfile(idfcampo,columna,tipo){
	var data  = new FormData();
	$.each($('.tipofileimagenpdf'), function(index, value) {
		var id = $(this).attr('id');
		var inputFile = document.getElementById(id);
		if($(inputFile).val()!=""){
			var filea = inputFile.files[0];
			data.append(id,filea);
		}
	});
	
	$.ajax({
		url: "../ajax/validararFile.php?idfcampo="+idfcampo+"&columna="+columna+"&tipo="+tipo,
		data: data,
		processData: false,
		contentType: false,
		cache:true,
		type: 'POST',
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//$("#pruebaimpresion").html(response);
			//alert(response);
			if(response=="noarchivo"){
			jAlert('El archivo que intenta subir no es valido!',"Alerta!!");
			/*$("#mensaje").html("<div class='alert alert-danger alert-dismissable hiddenalertfadeout_info_1'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>Archivo no valido, solo puede adjuntar imanenes de extensión (jpg,png).</div>");	
			window.setTimeout(function() {
			$(".hiddenalertfadeout_info_1").hide("slow");
			}, 6800);*/			
			}else if(response=="noextension"){
			jAlert('El archivo no se cargo porque la extensión no es permitido!',"Alerta!!");
			}else if(response=="notamanio"){
			jAlert('Archivo no se cargo porque sobrepaso el tamaño maximo permitido!',"Alerta!!");
			}
			
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

function validarfileRTF(idfcampo,columna,tipo){
	var data  = new FormData();
	$.each($('.tipofileimagenpdf'), function(index, value) {
		var id = $(this).attr('id');
		var inputFile = document.getElementById(id);
		if($(inputFile).val()!=""){
			var filea = inputFile.files[0];
			data.append(id,filea);
		}
	});
	
	$.ajax({
		url: "../ajax/validarFileRTF.php?idfcampo="+idfcampo+"&columna="+columna+"&tipo="+tipo,
		data: data,
		processData: false,
		contentType: false,
		cache:true,
		type: 'POST',
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//$("#pruebaimpresion").html(response);
			//alert(response);
			if(response=="noarchivo"){
			jAlert('El archivo que intenta subir no es valido!',"Alerta!!");
			/*$("#mensaje").html("<div class='alert alert-danger alert-dismissable hiddenalertfadeout_info_1'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>Archivo no valido, solo puede adjuntar imanenes de extensión (jpg,png).</div>");	
			window.setTimeout(function() {
			$(".hiddenalertfadeout_info_1").hide("slow");
			}, 6800);*/			
			}else if(response=="noextension"){
			jAlert('El archivo no se cargo porque la extensión no es permitido!',"Alerta!!");
			}else if(response=="notamanio"){
			jAlert('Archivo no se cargo porque sobrepaso el tamaño maximo permitido!',"Alerta!!");
			}
			
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
function ModoMenu(modo) {

	var page = WEB_ROOT+"/ajax/menutoggle.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : "ModoMenu",
			'modo' : modo
		},
		success: function(response){
			location.reload(true);
		}
	});

}

function ocultarcampos(id){
	//var id = $("#"+id).val();
	if (id != 3){
		$('.CLASS_HIDDEN').hide();
	}else{
		$('.CLASS_HIDDEN').show();
	}
}

/*function archivoTabla(){
	var data  = new FormData();
	$.each($('.filePlantillaClass'), function(index, value) {
		var id = $(this).attr('id');
		var inputFile = document.getElementById(id);
		if($(inputFile).val()!=""){
			var filea = inputFile.files[0];
			data.append(id,filea);
		}
	});

	$.ajax({
		url: "archivo.php",
		data: data,
		processData: false,
		contentType: false,
		cache:true,
		type: 'POST',
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
			console.log(response);
			$("#DIV_CONTENEDOR").html(splitResp[1]);
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});

}*/



function exportarPlantilla(){

	var page = WEB_ROOT+"/ajax/exportexcelpdf.php";
	var html = $('#ShowColumnHtmlP').html();

	web = WEB_ROOT+"/ajax/exportexcelpdf.php?type=Plantilla&html="+html;
	window.open(web, 'windowOpenTab');
}

function nuevoDetalleCompra(){
	$("#valorD").val(1);
	$(".D1").attr( {'readonly' : false,'disabled':false});
	//$("#BTN_ACEPT_DTALLE").attr( {'type': 'submit'});
	$("#BTN_ACEPT_DTALLE").remove( 'onclick');
	$("#spanNuevo").html("");
	$("#cancelarNuevoBtn").removeAttr("style");
	//$("#BTN_ACEPT_CABECERA").attr( {'readonly' : true, 'disabled':true});
	//$("#cancelar").attr( {'readonly' : true, 'disabled':true});
	//$("#cancelar").removeAttr("href");
	//$("#DescargarExcel").attr( {'readonly' : true, 'disabled':true});
	selectPikerSearch('D1');
}

function nuevoDetalleCompraDisabled(tipo){
	if (tipo == 0) {
		nuevoDetalleCompra();
	} else {
		$("#valorD").val(0);
		$(".D1").attr( {'readonly' : true});
		$("#BTN_ACEPT_DTALLE").attr({'type': 'button'});
		$("#BTN_ACEPT_DTALLE").attr({'onclick': 'nuevoDetalleCompra()'});
		$("#spanNuevo").html(" Nuevo");


	}
}

function nuevoDetalle(){
	var tmv = $("#IDTIPOMOVIMIENTOALMACEN option:selected").text();
	//alert(tmv)
	if(typeof(tmv) != "undefined" && tmv=="Seleccionar"){
		$("#IDTIPOMOVIMIENTOALMACEN").css("border-color", "#b30707");;
		$("#IDTIPOMOVIMIENTOALMACEN").focus();
		$("#nuevoD").attr( {'type': 'submit'});
	}else if(tmv=="STOCK"){		
	$("#valorD").val(1);
	$("#MOACCANTIDAD").val(0);
	$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : false, 'disabled':false});
	$("#MOAMAXIMO").attr( {'readonly' : false, 'disabled':false});
	$("#MOAMINIMO").attr( {'readonly' : false, 'disabled':false});
	$("#ENVIADO").attr( {'readonly' : true, 'disabled':true});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	$("#ENVIARREV").attr( {'readonly' : true, 'disabled':true});
	$("#CODIGOPRODUCTOUNIDAD").focus();
	$("#nuevoD").attr( {'type': 'submit'});
	$("#nuevoD").remove( 'onclick');
	$("#spanNuevo").html(" ");
	$("#cancelarNuevoBtn").removeAttr("style");
	selectPikerSearch('D1');
	}else{
	$("#valorD").val(1);
	$(".D1").attr( {'readonly' : false, 'disabled':false});
	$("#ENVIADO").attr( {'readonly' : true, 'disabled':true});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	$("#ENVIARREV").attr( {'readonly' : true, 'disabled':true});
	// $("#cancelar").attr( {'readonly' : true, 'disabled':true});
	// $("#terminarventa").attr( {'readonly' : true, 'disabled':true});
	// $("#DescargarExcel").attr( {'readonly' : true, 'disabled':true});
	// $("#modalEnviarMail").attr( {'readonly' : true, 'disabled':true});
	$("#CODIGOPRODUCTOUNIDAD").focus();

	// $("#cancelar").removeAttr("href");
	// $("#terminarventa").removeAttr("onclick");
	// $("#DescargarExcel").removeAttr("onclick");
	
	$("#nuevoD").attr( {'type': 'submit'});
	$("#nuevoD").remove( 'onclick');
	//$("#nuevoD").attr( {'onclick': 'enviarajax()'});
	$("#spanNuevo").html(" ");
	$("#spanNuevo").addClass('icon-save');
	$("#cancelarNuevoBtn").removeAttr("style");


	selectPikerSearch('D1');
}
}

function habilitarDetalle(idf){
	
	$("#valorD").val(1);
	$(".D1").attr( {'readonly' : false, 'disabled':false});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	$("#COMPRAR").attr( {'readonly' : true, 'disabled':true});
	$("#DescargarPDF").attr( {'readonly' : true, 'disabled':true});
	$("#enviarCotiza_CD").attr( {'readonly' : true, 'disabled':true});

	if(idf=="357"){
		$("#CCDCOSTO").attr({'readonly' : true});
	}
	$("#CODIGOPRODUCTOUNIDAD").focus();
	
	$("#nuevoD").attr( {'type': 'submit'});
	$("#nuevoD").removeAttr('onclick');
	$("#spanNuevo").html(" ");
	$("#cancelarNuevoBtn").removeAttr("style");


	selectPikerSearch('D1');

}

function detalleNuevo(){
	$("#valorD").val(1);
	$(".D1").attr( {'readonly' : false, 'disabled':false});
	$("#ENVIADO").attr( {'readonly' : true, 'disabled':true});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	// $("#cancelar").attr( {'readonly' : true, 'disabled':true});
	// $("#terminarventa").attr( {'readonly' : true, 'disabled':true});
	// $("#DescargarExcel").attr( {'readonly' : true, 'disabled':true});
	// $("#modalEnviarMail").attr( {'readonly' : true, 'disabled':true});
	$("#CODIGOPRODUCTOUNIDAD").focus();

	// $("#cancelar").removeAttr("href");
	// $("#terminarventa").removeAttr("onclick");
	// $("#DescargarExcel").removeAttr("onclick");
	
	//$("#nuevoD").attr( {'type': 'submit'});
	$("#nuevoD").remove( 'onclick');
	//$("#nuevoD").attr( {'onclick': 'enviarajax()'});
	$("#spanNuevo").html(" ");
	$("#cancelarNuevoBtn").removeAttr("style");


	selectPikerSearch('D1');

}
//----------------------------------------------------------------------------------------------------------
function ajaxCompra(){
if($("#IDCOMPRA").val()!=""){
var IDCMP = $("#IDCOMPRA").val();	
}else{
var IDCMP = $("#IDCMP").val();
}	
var FUNID = $("#FUNID").val();
var idcDet = $("#idcDet").val();

var FechaCompra = $("#CMPFECHA").val();
var prv = $("#IDPROVEEDOR").val();
var almacen = $("#IDALMACEN").val();
var Idprod = $("#IDPRODUCTO").val();
var cant = $("#CPDCANTIDAD").val();
var precio = $("#CPDPRECIO").val();
var descprod = $("#CPDDESCUENTO").val();
var importedesc = $("#CPDDESCUENTOTOTAL").val();
var importeTotal = $("#CPDCOSTO").val();
var obs = $("#CPDOBSERVACIONES").val();

var boton = $("#BTN_ACEPT_DTALLE").val();
if(FechaCompra == ""){
jAlert('¡Ingrese una fecha!',"¡Alerta!")
$("#CMPFECHA").focus();
}else if(prv == ""){ 
jAlert('¡Ingrese un proveedor!',"¡Alerta!")
$("#IDPROVEEDOR").focus();
}else if(almacen == ""){ 
jAlert('¡Ingrese un almacén!',"¡Alerta!")
$("#IDALMACEN").focus();
}else if(Idprod == ""){ 
jAlert('¡Ingrese un producto!',"¡Alerta!")
$("#CODIGOPRODUCTOUNIDAD").focus();
}else if(cant == "" || cant<=0){
jAlert('¡Cantidad debe ser mayor de cero!',"¡Alerta!")
$("#CPDCANTIDAD").val(1);
}else if(precio == ""){ 
jAlert('¡Ingrese precio del producto!',"¡Alerta!")
$("#VTDPRECIO").focus();
}else{
var page = WEB_ROOT+"/ajax/compraAjax.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDCMP' : IDCMP,
		'FUNID' : FUNID,
		'idcDet' : idcDet,
		'FechaCompra' : FechaCompra,
		'prv' : prv,
		'almacen' : almacen,
		'Idprod' : Idprod,
		'cant' : cant,
		'precio' : precio,
		'descprod' : descprod,
		'importedesc' : importedesc,
		'importeTotal' : importeTotal,
		'obs' : obs,
		'MM_accion' : boton,
		'valorD' : 1
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		var  regresoidcompra= respuestaphp.regresoidcompra;
  		var  tablacompra= respuestaphp.tablacompra;
  		var msj=respuestaphp.msj;
		$("#IDVNT").attr( {'value': regresoidcompra});
		$("#datos").html(tablacompra);

  		$("#CMPFOLIOCOTIZA").val(respuestaphp.Fcotiza);
  		$("#CMPFECHA").val(respuestaphp.FC);
  		$("#IDPROVEEDOR").val(respuestaphp.prov);
  		$("#IDALMACEN").val(respuestaphp.alm);

		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#CPDCANTIDAD").val(1);
		$("#CPDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#CPDPRECIO").val("");
		$("#CPDDESCUENTO").val("");
		$("#CPDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#CPDDESCUENTOTOTAL").val("");
		$("#CPDCOSTO").val("");
		$("#CPDOBSERVACIONES").val("");
		$("#CPDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});

  		$("#BTN_ACEPT_CABECERA").removeAttr("disabled");
  		$("#modalEnviarmail").removeAttr("disabled");
  		$("#DescargarExcel").removeAttr("disabled");
		$('#mensajeAlert').html(msj);
		//$('#mensajeAlert').html(respuestaphp.dato1);
		//$('#pruebaimpresion').html(respuestaphp.dato2);

		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
}
//----------------------------------------------------------------------------------------------------------
function ajaxVenta(){
if($("#IDVENTA").val()!=""){
var IDVNT = $("#IDVENTA").val();	
}else{
var IDVNT = $("#IDVNT").val();
}	
var FUNID = $("#FUNID").val();
var idvDet = $("#idvDet").val();

var FechaVenta = $("#VENFECHA").val();
var Clt = $("#IDCLIENTE").val();
var almacen = $("#IDALMACEN").val();
var Idprod = $("#IDPRODUCTO").val();
var cant = $("#VTDCANTIDAD").val();
var precio = $("#VTDPRECIO").val();
var descprod = $("#VTDDESCUENTO").val();
var importedesc = $("#VTDDESCUENTOTOTAL").val();
var importeTotal = $("#VTDCOSTO").val();
var obs = $("#VTDOBSERVACIONES").val();
//alert(precio)
var boton = $("#nuevoD").val();
//alert(boton)
if(FechaVenta == ""){
jAlert('¡Ingrese una fecha!',"¡Alerta!")
$("#VENFECHA").focus();
}else if(Clt == ""){ 
jAlert('¡Ingrese un cliente!',"¡Alerta!")
$("#CLTRAZONSOCIAL").focus();
}else if(almacen == ""){ 
jAlert('¡Ingrese un almacén!',"¡Alerta!")
$("#IDALMACEN").focus();
}else if(Idprod == ""){ 
jAlert('¡Ingrese un producto!',"¡Alerta!")
$("#CODIGOPRODUCTOUNIDAD").focus();
}else if(cant == "" || cant<=0){
jAlert('¡Cantidad debe ser mayor de cero!',"¡Alerta!")
//FechaVenta.focus();
$("#VTDCANTIDAD").val(1);
}else if(precio == ""){ 
jAlert('¡Ingrese precio del producto!',"¡Alerta!")
$("#VTDPRECIO").focus();
}else{
var page = WEB_ROOT+"/ajax/ventaAjax.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDVNT' : IDVNT,
		'FUNID' : FUNID,
		'idvDet' : idvDet,
		'FechaVenta' : FechaVenta,
		'Clt' : Clt,
		'almacen' : almacen,
		'Idprod' : Idprod,
		'cant' : cant,
		'precio' : precio,
		'descprod' : descprod,
		'importedesc' : importedesc,
		'importeTotal' : importeTotal,
		'obs' : obs,
		'MM_accion' : boton,
		'valorD' : 1
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		//alert(respuestaphp.p)
		var  regresoidventa= respuestaphp.regresoidventa;
  		var  tablaventa= respuestaphp.tablaventa;
  		var msj=respuestaphp.msj;
		$("#IDVNT").attr( {'value': regresoidventa});
		$("#datos").html(tablaventa);

  		$("#VENFOLIOCOTIZA").val(respuestaphp.Fcotiza);
  		$("#VENFECHA").val(respuestaphp.FV);
  		$("#IDCLIENTE").val(respuestaphp.clte);
  		$("#IDALMACEN").val(respuestaphp.alm);

		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#VTDCANTIDAD").val(1);
		$("#VTDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#VTDPRECIO").val("");
		$("#VTDDESCUENTO").val("");
		$("#VTDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#VTDDESCUENTOTOTAL").val("");
		$("#VTDCOSTO").val("");
		$("#VTDOBSERVACIONES").val("");
		$("#VTDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});

  		$("#terminarventa").removeAttr("disabled");
  		$("#modalEnviarmail").removeAttr("disabled");
  		$("#DescargarPDF").removeAttr("disabled");
		$('#mensajeAlert').html(msj);

		//Inicio Desarrollador 1
			if(regresoidventa!=""){
				$("#DescargarPDF").attr({'href' : "index.php?MM_accion=editar&ID=6&IDF=168&IdCstClt="+regresoidventa+"&IdPdf=1"});
				$("#form1").attr({'action' : "index.php?MM_accion=editar&ID=6&IDF=168&IdCstClt="+regresoidventa});
				$("#formModalGeneral").attr({'action' : "index.php?MM_accion=editar&ID=6&IDF=168&IdCstClt="+regresoidventa});
			}
		//Fin Desarrollador 1

		//$('#mensajeAlert').html(respuestaphp.dato1);
		//$('#pruebaimpresion').html(respuestaphp.dato2);

		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
}

function ajaxVentaComandero(){
if($("#IDVENTA").val()!=""){
var IDVNT = $("#IDVENTA").val();	
}else{
var IDVNT = $("#IDVNT").val();
}	
var FUNID = $("#FUNID").val();
var idvDet = $("#idvDet").val();


var FRMORIGEN = $("#VENFRMORIGEN").val();
// var REGIDEMPLEADO = $("#REGIDEMPLEADO").val();
var FechaVenta = $("#VENFECHA").val();
var Clt = $("#IDCLIENTE").val();
var almacen = $("#IDALMACEN").val();
var Idprod = $("#IDPRODUCTO").val();
var cant = $("#VTDCANTIDAD").val();
var precio = $("#VTDPRECIO").val();
var descprod = $("#VTDDESCUENTO").val();
var importedesc = $("#VTDDESCUENTOTOTAL").val();
var importeTotal = $("#VTDCOSTO").val();
var obs = $("#VTDOBSERVACIONES").val();
//alert(precio)
var boton = $("#nuevoD").val();
//alert(boton)
if(FechaVenta == ""){
jAlert('¡Ingrese una fecha!',"¡Alerta!")
$("#VENFECHA").focus();
}else if(Clt == ""){ 
jAlert('¡Ingrese un cliente!',"¡Alerta!")
$("#CLTRAZONSOCIAL").focus();
}else if(almacen == ""){ 
jAlert('¡Ingrese un almacén!',"¡Alerta!")
$("#IDALMACEN").focus();
}else if(Idprod == ""){ 
jAlert('¡Ingrese un producto!',"¡Alerta!")
$("#CODIGOPRODUCTOUNIDAD").focus();
}else if(cant == "" || cant<=0){
jAlert('¡Cantidad debe ser mayor de cero!',"¡Alerta!")
//FechaVenta.focus();
$("#VTDCANTIDAD").val(1);
}else if(precio == ""){ 
jAlert('¡Ingrese precio del producto!',"¡Alerta!")
$("#VTDPRECIO").focus();
}else{
var page = WEB_ROOT+"/ajax/ventaAjaxComandero.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDVNT' : IDVNT,
		'FUNID' : FUNID,
		'FRMORIGEN' : FRMORIGEN,
		// 'REGIDEMPLEADO' : REGIDEMPLEADO,
		'idvDet' : idvDet,
		'FechaVenta' : FechaVenta,
		'Clt' : Clt,
		'almacen' : almacen,
		'Idprod' : Idprod,
		'cant' : cant,
		'precio' : precio,
		'descprod' : descprod,
		'importedesc' : importedesc,
		'importeTotal' : importeTotal,
		'obs' : obs,
		'MM_accion' : boton,
		'valorD' : 1
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		//alert(respuestaphp.p)
		var  regresoidventa= respuestaphp.regresoidventa;
  		var  tablaventa= respuestaphp.tablaventa;
  		var msj=respuestaphp.msj;
		$("#IDVNT").attr( {'value': regresoidventa});
		$("#datos").html(tablaventa);

  		$("#VENFOLIOCOTIZA").val(respuestaphp.Fcotiza);
  		$("#VENFECHA").val(respuestaphp.FV);
  		$("#IDCLIENTE").val(respuestaphp.clte);
  		$("#IDALMACEN").val(respuestaphp.alm);

		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#VTDCANTIDAD").val(1);
		$("#VTDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#VTDPRECIO").val("");
		$("#VTDDESCUENTO").val("");
		$("#VTDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#VTDDESCUENTOTOTAL").val("");
		$("#VTDCOSTO").val("");
		$("#VTDOBSERVACIONES").val("");
		$("#VTDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});

  		$("#terminarventa").removeAttr("disabled");
  		$("#modalEnviarmail").removeAttr("disabled");
  		$("#DescargarPDF").removeAttr("disabled");
		$('#mensajeAlert').html(msj);
		// $('#mensajeAlert').html(response);

		//Inicio Desarrollador 1
			if(regresoidventa!=""){
				$("#DescargarPDF").attr({'href' : "index.php?MM_accion=editar&ID=6&IDF=280&IdCstClt="+regresoidventa+"&IdPdf=1"});
				$("#form1").attr({'action' : "index.php?MM_accion=editar&ID=6&IDF=280&IdCstClt="+regresoidventa});
				$("#formModalGeneral").attr({'action' : "index.php?MM_accion=editar&ID=6&IDF=280&IdCstClt="+regresoidventa});
			}
		//Fin Desarrollador 1

		//$('#mensajeAlert').html(respuestaphp.dato1);
		//$('#pruebaimpresion').html(respuestaphp.dato2);

		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
}

function EliminarEditarRegistro(id,accion) {
	if(accion==1){
	if (id == "") {
		jAlert('No es posible eliminar, los datos estan <b>vacios</b> o ya fue <b>eliminado</b>!',"Alerta!!");
	} else {
		jConfirm("¿Está seguro de eliminar este registro?", 'Confirmación', function(r) {
			if (!r) {
				$("#CODIGOPRODUCTOUNIDAD").focus();
				return;
			}else{		
		elimEditar(id,"eliminar");
	}
	});
	}
}else if(accion==2){
	elimEditar(id,"editar");
	}
}

function elimEditar(ID,BtnAccion){
//var boton = $("#nuevoD").val();

	if($("#IDVENTA").val()!=""){
	var IDVNT = $("#IDVENTA").val();	
	}else{
	var IDVNT = $("#IDVNT").val();
	}

	//var IDVNT = $("#IDVNT").val();
	var FUNID = $("#FUNID").val();

	var FechaVenta = $("#VENFECHA").val();
	var Clt = $("#IDCLIENTE").val();
	var almacen = $("#IDALMACEN").val();

	var Idprod = $("#IDPRODUCTO").val();
	var cant = $("#VTDCANTIDAD").val();
	var precio = $("#VTDPRECIO").val();
	var descprod = $("#VTDDESCUENTO").val();
	var importedesc = $("#VTDDESCUENTOTOTAL").val();
	var importeTotal = $("#VTDCOSTO").val();
	var obs = $("#VTDOBSERVACIONES").val();

	if(BtnAccion=="editar" && (cant == "" || cant<=0)){
	jAlert('Cantidad debe ser mayor de cero!',"Alerta!!")
	$("#VTDCANTIDAD").focus();
	$("#VTDCANTIDAD").val(1);
	}else{
	var page = WEB_ROOT+"/ajax/ventaAjax.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDVNT' : IDVNT,
		'FUNID' : FUNID,
		'FechaVenta' : FechaVenta,
		'Clt' : Clt,
		'almacen' : almacen,
		'Idprod' : Idprod,
		'cant' : cant,
		'precio' : precio,
		'descprod' : descprod,
		'importedesc' : importedesc,
		'importeTotal' : importeTotal,
		'obs' : obs,
		'idvDet' : ID,
		'MM_accion' : BtnAccion,
		'valorD' : 0
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
  		//$("#terminarventa").removeAttr("disabled");

		var respuestaphp= $.parseJSON(response);
		var regresoidventa= respuestaphp.regresoidventa;
  		var tablaventa= respuestaphp.tablaventa;
  		var msj=respuestaphp.msj;
		$("#IDVNT").attr( {'value': regresoidventa});
		$("#datos").html(tablaventa);

		$("#VENFOLIOCOTIZA").val(respuestaphp.Fcotiza);
  		$("#VENFECHA").val(respuestaphp.FV);
  		$("#IDCLIENTE").val(respuestaphp.clte);
  		$("#IDALMACEN").val(respuestaphp.alm);

		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : false, 'disabled':false});
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#VTDCANTIDAD").attr({'class' : 'form-control'});
		$("#VTDCANTIDAD").val(1);
		$("#VTDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#VTDPRECIO").val("");
		$("#VTDDESCUENTO").val("");
		$("#VTDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#VTDDESCUENTOTOTAL").val("");
		$("#VTDCOSTO").val("");
		$("#VTDOBSERVACIONES").val("");
		$("#VTDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});
		$("#nuevoD").attr({'onclick' : 'ajaxVenta()'});
  		$('#mensajeAlert').html(msj);
  		//$('#mensajeAlert').html(respuestaphp.dato1);
		//$('#pruebaimpresion').html(respuestaphp.dato2);
		$("#spanNuevo").removeClass('glyphicon-pencil');
		$("#spanNuevo").addClass('glyphicon-floppy-saved');
		$("#nuevoD").removeClass('btn-primary');
		$("#nuevoD").addClass('btn-success');
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
		});
}
}

function actualizar(id){
	if(id!=""){
var page = WEB_ROOT+"/ajax/editarRegistro.php";
$.ajax({
		type: "POST",
		url: page,
		data: {
		'regid' : id
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
		var respuestaphp= $.parseJSON(response);

		$("#idvDet").val(respuestaphp.idvDet);
		$("#IDPRODUCTO").val(respuestaphp.Idprod);
		$("#CODIGOPRODUCTOUNIDAD").val(respuestaphp.producto);
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : true, 'disabled':true});
		$("#VTDCANTIDAD").val(respuestaphp.cant);
		$("#VTDCANTIDAD").attr({'class' : 'form-control cantpro'});
		$("#VTDCANTIDAD").attr({'readonly' : false, 'disabled':false});
		$("#VTDPRECIO").val(respuestaphp.precio);
		$("#VTDDESCUENTO").val(respuestaphp.descprod);
		$("#VTDDESCUENTO").attr({'readonly' : false, 'disabled':false});
		$("#VTDDESCUENTOTOTAL").val(respuestaphp.importedesc);
		$("#VTDCOSTO").val(respuestaphp.importeTotal);
		$("#VTDOBSERVACIONES").val(respuestaphp.obs);
		$("#VTDOBSERVACIONES").attr({'readonly' : false, 'disabled':false});
		$("#spanNuevo").removeClass('glyphicon-floppy-saved');
		$("#spanNuevo").addClass('glyphicon-pencil');
		$("#nuevoD").removeClass('btn-success');
		$("#nuevoD").addClass('btn-primary');

		$("#nuevoD").attr({'onclick' : 'EliminarEditarRegistro('+respuestaphp.idvDet+',2)'});
		$("#VTDCANTIDAD").focus();
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
		});
}else{
		$("#idvDet").val("");
		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : false, 'disabled':false});
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#VTDCANTIDAD").attr({'class' : 'form-control'});
		$("#VTDCANTIDAD").val(1);
		$("#VTDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#VTDPRECIO").val("");
		$("#VTDDESCUENTO").val("");
		$("#VTDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#VTDDESCUENTOTOTAL").val("");
		$("#VTDCOSTO").val("");
		$("#VTDOBSERVACIONES").val("");
		$("#VTDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});

		$("#spanNuevo").removeClass('glyphicon-pencil');
		$("#spanNuevo").addClass('glyphicon-floppy-saved');
		$("#nuevoD").removeClass('btn-primary');
		$("#nuevoD").addClass('btn-success');
}
}

function EliminarEditarRegistroComandero(id,accion) {
	if(accion==1){
	if (id == "") {
		jAlert('No es posible eliminar, los datos estan <b>vacios</b> o ya fue <b>eliminado</b>!',"Alerta!!");
	} else {
		jConfirm("¿Está seguro de eliminar este registro?", 'Confirmación', function(r) {
			if (!r) {
				$("#CODIGOPRODUCTOUNIDAD").focus();
				return;
			}else{		
		elimEditarComandero(id,"eliminar");
	}
	});
	}
}else if(accion==2){
	elimEditarComandero(id,"editar");
	}
}

function elimEditarComandero(ID,BtnAccion){
//var boton = $("#nuevoD").val();

	if($("#IDVENTA").val()!=""){
	var IDVNT = $("#IDVENTA").val();	
	}else{
	var IDVNT = $("#IDVNT").val();
	}

	//var IDVNT = $("#IDVNT").val();
	var FUNID = $("#FUNID").val();

	var FechaVenta = $("#VENFECHA").val();
	var Clt = $("#IDCLIENTE").val();
	var almacen = $("#IDALMACEN").val();

	var Idprod = $("#IDPRODUCTO").val();
	var cant = $("#VTDCANTIDAD").val();
	var precio = $("#VTDPRECIO").val();
	var descprod = $("#VTDDESCUENTO").val();
	var importedesc = $("#VTDDESCUENTOTOTAL").val();
	var importeTotal = $("#VTDCOSTO").val();
	var obs = $("#VTDOBSERVACIONES").val();

	if(BtnAccion=="editar" && (cant == "" || cant<=0)){
	jAlert('Cantidad debe ser mayor de cero!',"Alerta!!")
	$("#VTDCANTIDAD").focus();
	$("#VTDCANTIDAD").val(1);
	}else{
	var page = WEB_ROOT+"/ajax/ventaAjaxComandero.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDVNT' : IDVNT,
		'FUNID' : FUNID,
		'FechaVenta' : FechaVenta,
		'Clt' : Clt,
		'almacen' : almacen,
		'Idprod' : Idprod,
		'cant' : cant,
		'precio' : precio,
		'descprod' : descprod,
		'importedesc' : importedesc,
		'importeTotal' : importeTotal,
		'obs' : obs,
		'idvDet' : ID,
		'MM_accion' : BtnAccion,
		'valorD' : 0
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
  		//$("#terminarventa").removeAttr("disabled");

		var respuestaphp= $.parseJSON(response);
		var regresoidventa= respuestaphp.regresoidventa;
  		var tablaventa= respuestaphp.tablaventa;
  		var msj=respuestaphp.msj;
		$("#IDVNT").attr( {'value': regresoidventa});
		$("#datos").html(tablaventa);

		$("#VENFOLIOCOTIZA").val(respuestaphp.Fcotiza);
  		$("#VENFECHA").val(respuestaphp.FV);
  		$("#IDCLIENTE").val(respuestaphp.clte);
  		$("#IDALMACEN").val(respuestaphp.alm);

		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : true, 'disabled':false});
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#VTDCANTIDAD").attr({'class' : 'form-control'});
		$("#VTDCANTIDAD").val(1);
		$("#VTDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#VTDPRECIO").val("");
		$("#VTDDESCUENTO").val("");
		$("#VTDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#VTDDESCUENTOTOTAL").val("");
		$("#VTDCOSTO").val("");
		$("#VTDOBSERVACIONES").val("");
		$("#VTDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});
		$("#nuevoD").attr({'onclick' : 'ajaxVentaComandero()'});
  		$('#mensajeAlert').html(msj);
  		// $('#mensajeAlert').html(respuestaphp.SQL);
  		//$('#mensajeAlert').html(respuestaphp.dato1);
		//$('#pruebaimpresion').html(respuestaphp.dato2);
		$("#spanNuevo").removeClass('glyphicon-pencil');
		$("#spanNuevo").addClass('glyphicon-floppy-saved');
		$("#nuevoD").removeClass('btn-primary');
		$("#nuevoD").addClass('btn-success');
		$("#nuevoD").attr({'disabled':true});
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
		});
}
}

function actualizarComandero(id){
	if(id!=""){
var page = WEB_ROOT+"/ajax/editarRegistroComandero.php";
$.ajax({
		type: "POST",
		url: page,
		data: {
		'regid' : id
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
		var respuestaphp= $.parseJSON(response);

		$("#idvDet").val(respuestaphp.idvDet);
		$("#IDPRODUCTO").val(respuestaphp.Idprod);
		$("#CODIGOPRODUCTOUNIDAD").val(respuestaphp.producto);
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : true, 'disabled':true});
		$("#VTDCANTIDAD").val(respuestaphp.cant);
		$("#VTDCANTIDAD").attr({'class' : 'form-control cantpro'});
		$("#VTDCANTIDAD").attr({'readonly' : false, 'disabled':false});
		$("#VTDPRECIO").val(respuestaphp.precio);
		$("#VTDDESCUENTO").val(respuestaphp.descprod);
		$("#VTDDESCUENTO").attr({'readonly' : false, 'disabled':false});
		$("#VTDDESCUENTOTOTAL").val(respuestaphp.importedesc);
		$("#VTDCOSTO").val(respuestaphp.importeTotal);
		$("#VTDOBSERVACIONES").val(respuestaphp.obs);
		$("#VTDOBSERVACIONES").attr({'readonly' : false, 'disabled':false});
		$("#spanNuevo").removeClass('glyphicon-floppy-saved');
		$("#spanNuevo").addClass('glyphicon-pencil');
		$("#nuevoD").removeClass('btn-success');
		$("#nuevoD").removeAttr('disabled');
		$("#nuevoD").addClass('btn-primary');

		$("#nuevoD").attr({'onclick' : 'EliminarEditarRegistroComandero('+respuestaphp.idvDet+',2)'});
		$("#VTDCANTIDAD").focus();
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
		});
}else{
		$("#idvDet").val("");
		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : true, 'disabled':false});
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#VTDCANTIDAD").attr({'class' : 'form-control'});
		$("#VTDCANTIDAD").val(1);
		$("#VTDCANTIDAD").attr({'readonly' : true, 'disabled':true});
		$("#VTDPRECIO").val("");
		$("#VTDDESCUENTO").val("");
		$("#VTDDESCUENTO").attr({'readonly' : true, 'disabled':true});
		$("#VTDDESCUENTOTOTAL").val("");
		$("#VTDCOSTO").val("");
		$("#VTDOBSERVACIONES").val("");
		$("#VTDOBSERVACIONES").attr({'readonly' : true, 'disabled':true});

		$("#spanNuevo").removeClass('glyphicon-pencil');
		$("#spanNuevo").addClass('glyphicon-floppy-saved');
		$("#nuevoD").removeClass('btn-primary');
		$("#nuevoD").attr({'disabled':true});
		$("#nuevoD").addClass('btn-success');
}
}
//----------------------------------------------------------------------------------------------------------
function enviarajax(){
var FVenta = $("#fechadeventa").val();
var cantidad = $("#cantidad").val();
var idproducto = $("#IDPRODUCTO").val();
var observaciones = $("#observaciones").val();
var boton = $("#nuevoDetalle").val();
var ventaid = $("#ventaid").val();
var idfun = $("#idf").val();
if(idproducto == ""){
jAlert('¡Ingrese un producto!',"¡Alerta!")
$("#CODIGOPRODUCTOUNIDAD").focus();
$("#cantidad").val(1);
}else if(cantidad == "" || cantidad<=0){
jAlert('¡Cantidad debe ser mayor de cero!',"¡Alerta!")
$("#CODIGOPRODUCTOUNIDAD").focus();
$("#cantidad").val(1);
}else{
var page = WEB_ROOT+"/ajax/insertupdatedeleteAjax.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'ventaid' : ventaid,
		'idf' : idfun,
		'fventa' : FVenta,
		'cantidad' : cantidad,
		'idproducto' : idproducto,
		'observaciones' : observaciones,
		'MM_accion' : boton,
		'valorD' : 1
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		//$("#pruebaimpresion").html(procedimiento);
		var respuestaphp= $.parseJSON(response);
		var  regresoidventa= respuestaphp.regresoidventa;
  		var  tablaventa= respuestaphp.tablaventa;
  		var msj=respuestaphp.msj;
  		$("#terminarventa").removeAttr("disabled");
		$("#imprimirtabla").html(tablaventa);
		$("#ventaid").attr( {'value': regresoidventa});
		$("#cantidad").val(1);
		$("#IDPRODUCTO").val("");
		$("#TablaHtmlIMM_accion").val("editar");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#observaciones").val("");
		$('#mensajeAlerta').html(msj);
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
}

function DeleteUpdateRegistro(id,accion) {
	if(accion==1){
	if (id == "") {
		jAlert('No es posible eliminar, los datos estan <b>vacios</b> o ya fue <b>eliminado</b>!',"Alerta!!");
	} else {
		jConfirm("¿Está seguro de eliminar este registro?", 'Confirmación', function(r) {
			if (!r) {
				$("#CODIGOPRODUCTOUNIDAD").focus();
				return;
			}else{		
		deleteupdate(id,"eliminar");
	}
	});
	}
}else if(accion==2){
	deleteupdate(id,"editar");
	}
}

function deleteupdate(ID,BtnAccion){
	//alert(ID)
	//alert(BtnAccion)
	var idproducto = $("#IDPRODUCTO").val();
	var ventaid = $("#ventaid").val();
	var FVenta = $("#fechadeventa").val();
	var cantidad = $("#cantidad").val();
	var observaciones = $("#observaciones").val();
	var idfun = $("#idf").val();
	if(BtnAccion=="editar" && (cantidad == "" || cantidad<=0)){
	jAlert('Cantidad debe ser mayor de cero!',"Alerta!!")
	$("#cantidad").val(1);
	$("#cantidad").focus();
	}else{
	var page = WEB_ROOT+"/ajax/insertupdatedeleteAjax.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'ventaid' : ventaid,
		'idf' : idfun,
		'fventa' : FVenta,
		'cantidad' : cantidad,
		'idproducto' : idproducto,
		'idvd' : ID,
		'observaciones' : observaciones,
		'MM_accion' : BtnAccion,
		'valorD' : 0
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
  		//$("#pruebaimpresion").html(procedimiento);
		var respuestaphp= $.parseJSON(response);
		var regresoidventa= respuestaphp.regresoidventa;
  		var tablaventa= respuestaphp.tablaventa;
  		var msj=respuestaphp.msj;
		$("#imprimirtabla").html(tablaventa);
		$("#ventaid").attr( {'value': regresoidventa});
		$("#cantidad").val(1);
		$("#IDPRODUCTO").val("");
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : false, 'disabled':false});
		$("#cantidad").attr({'class' : 'form-control'});
		$("#nuevoDetalle").attr({'style' : 'display: block;'});
		$("#botones").attr({'style' : 'display: none;'});
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#observaciones").val("");
  		$('#mensajeAlerta').html(msj);
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
		});
}
}

function edicion(id){
	if(id!=""){
var page = WEB_ROOT+"/ajax/actualizarRegistro.php";
$.ajax({
		type: "POST",
		url: page,
		data: {
		'regid' : id
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
		var respuestaphp= $.parseJSON(response);
		var  idvd=respuestaphp.idvd;
		var  idp=respuestaphp.id;
  		var  cantidad= respuestaphp.cantidad;	
		var  producto= respuestaphp.producto;
		$("#IDPRODUCTO").val(idp);
		$("#cantidad").val(cantidad);
		$("#idvd").val(idvd);
		$("#observaciones").val(respuestaphp.obsDetalle);
		$("#cantidad").attr({'class' : 'form-control cantpro'});
		$("#CODIGOPRODUCTOUNIDAD").val(producto);
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : true, 'disabled':true});
		$("#nuevoDetalle").attr({'style' : 'display: none;'});
		$("#botones").attr({'style' : 'display: block;'});
		$("#editar2").attr({'onclick' : 'DeleteUpdateRegistro('+idvd+',2)'});
		$("#cantidad").focus();
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
		});
}else{
		$("#IDPRODUCTO").val("");
		$("#cantidad").val(1);
		$("#CODIGOPRODUCTOUNIDAD").val("");
		$("#idvd").val("");
		$("#CODIGOPRODUCTOUNIDAD").attr( {'readonly' : false, 'disabled':false});
		$("#CODIGOPRODUCTOUNIDAD").focus();
		$("#nuevoDetalle").attr({'style' : 'display: block;'});
		$("#botones").attr({'style' : 'display: none;'});
		$("#cantidad").attr({'class' : 'form-control'});
		$("#observaciones").val("");
}
}

//----------------------------------------------------------------------------------------------------------
function nuevoDetalle2(){
	$("#valorD").val(1);
	$(".D1").attr( {'readonly' : false, 'disabled':false});
	$("#ENVIADO").attr( {'readonly' : true, 'disabled':true});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	$("#cancelar").attr( {'readonly' : true, 'disabled':true});
	$("#terminarventa").attr( {'readonly' : true, 'disabled':true});
	$("#DescargarExcel").attr( {'readonly' : true, 'disabled':true});

	$("#cancelar").removeAttr("href");
	$("#terminarventa").removeAttr("onclick");
	$("#DescargarExcel").removeAttr("onclick");
	
	$("#nuevoD").attr( {'type': 'submit'});
	$("#nuevoD").remove( 'onclick');
	$("#spanNuevo").html("");
	$("#cancelarNuevoBtn").removeAttr("style");


	selectPikerSearch('D1');

}

function selectPikerSearch(clase) {
	$("."+clase).each(function() {
		if ($(this).hasClass('selectpicker')){
			var id = $(this).attr('id');
			if (id !== undefined) {
				var tipo = this.type;
				if (tipo === "select-one") {
					$("#"+id).selectpicker("refresh");
				}
			}
		}
	});
}


function habilitarTipoAjuste(){
	var tipodeajuste = $("#IDTIPOMOVIMIENTOALMACEN").val();
	if (tipodeajuste==3){
		$(".almD").attr( {'disabled' : false});
		$(".almD").attr( {'readonly' : false});
		$("#IDALMACENDESTINO").attr( {'required' : true});
	}else{
		$(".almD").attr( {'disabled' : true});
		$(".almD").attr( {'readonly' : true});
		$("#IDALMACENDESTINO").attr( {'required' : false});
		$("#IDALMACENDESTINO").val("");
		//var almid.length = document.getElementById("IDALMACEN");
    		//almid.length=0;
		//$("#IDALMACEN").length(0);
	}
}

function formatCurrency(total) {
	var neg = false;
	if(total < 0) {
		neg = true;
		total = Math.abs(total);
	}
	return (neg ? "-$" : '$') + parseFloat(total, 10).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();
}

function extraerNumero(value) {
	var res,espace,result;
	espace = replaceAll(value,' ','');
	res = replaceAll(espace,'$','');
	result = replaceAll(res,',','');
	return result;
}

function replaceAll(text,busca,reemplaza){
	while (text.toString().indexOf(busca) != -1){
		text = text.toString().replace(busca,reemplaza);
	}
	return text;
}


function formatomoneda(atributo){
	var coin1,coin2,coin3,coin4,coin5;
	//alert(atributo)
	coin1 = atributo.value;
	coin2 = extraerNumero(coin1);
	if (!isNaN(coin2) && coin2 !="") {
		coin3 = formatCurrency(coin2);
		coin4 = replaceAll(coin3,'$','');
		// coin5 = replaceAll(coin4,'.00','');
		// console.log(coin5);
		// $('#'+atributo.id).val(coin5);
		$('#'+atributo.id).val(coin4);
	}else{
		// $('#'+atributo.id).val(0);
	}

}

function formatomoneda2(atributo){
	var coin1,coin2,coin3,coin4,coin5;

	coin1 = atributo;
	coin2 = extraerNumero(coin1);
	if (!isNaN(coin2) && coin2 !="") {
		coin3 = formatCurrency(coin2);
		coin4 = replaceAll(coin3,'$','');
		coin5 = replaceAll(coin4,'.00','');
		console.log(coin5);
		$('#'+atributo.id).val(coin5);
	}else{
		// $('#'+atributo.id).val(0);
	}

}


function focusFCD(MM_ACCION){
	if(MM_ACCION!="nuevo"){
	$("#BTN_ACEPT_DTALLE").focus();
	$("#nuevoD").focus();
	}
}

function actualizarMasivo(){
	var page = WEB_ROOT+"/ajax/actualizarMasivo.php";

	$.ajax({
		type: "POST",
		url: page,
		success: function(response){
			alert(response);
		}
	});
	
}

function envioMailPDF(setTo,setSubject,mensaje,archivo){
	
	var page = WEB_ROOT+"/ajax/envioCotiza.php";
	var progressbar = "<div id='progressBar' align='center'><a style='font-size: 17px;'>Enviando correo...</a><div class='progressbar-sm progress-rounded progress-striped progress ng-isolate-scope active' value='34' type='success'><div class='progress-bar progress-bar-success' ng-class='type &amp;&amp; progress-bar-type' role='progressbar' aria-valuenow='34' aria-valuemin='0' aria-valuemax='100' ng-style='{width: percent + '%'}' aria-valuetext='34%' ng-transclude='' style='width: 100%;'></div></div></div>";
	$.ajax({
		type: "POST",
		url: page,
		data: {
			'setTo' : setTo,
			'setSubject' : setSubject,
			'mensaje' : mensaje,
			'archivo':archivo
		},
		beforeSend: function(){
			$('#mensajeAlert').html(progressbar);
			},
		success: function(response){
			$('#mensajeAlert').html(response);			
			window.setTimeout(function() {
			$(".hiddenalertfadeout_info_1").hide("slow");
			}, 6800);
		}
	});
}

function validaEnvioCotiza(){
	var setTo =	$("#mailDestinatario").val();
	var setSubject = $("#mailAsunto").val(); 
	
	if(setTo != "" && setSubject != ""){
		$("#ACEPTARMAIL").attr( {'disabled' : false});
		$("#ACEPTARMAIL").attr({'onclick' : 'envioCotizaAjax()'});
	}else{
		$("#ACEPTARMAIL").attr( {'disabled' : true});
	}
	
}
function envioCotizaAjaxC(DG,ID,TIPO){
	var setTo =	$("#mailDestinatario").val();
	var setSubject = $("#mailAsunto").val(); 
	var mensaje = $("#mailMensaje").val(); 
	var alertModal="";

/*Inicio de titulos*/
	if(TIPO == 'VENTAC' || TIPO == 'COMPRAC' || TIPO == 'VENTADC' || TIPO == 'COMPRADC'){
		if (TIPO == 'VENTAC') {
			var Title = 'Cotización';
		}else if(TIPO == 'COMPRAC'){
			var Title = 'Orden de compra';
		}else if(TIPO == 'VENTADC'){
			var Title = 'Detalle de venta';
		}else if(TIPO == 'COMPRADC'){
			var Title = 'Detalle de compra';
		}

	}else{
		var Title = TIPO;
	}
/*Fin de titulos*/

	if(setTo != "" && setSubject != ""){
		$("#mailDestinatario").removeAttr("style");
		$("#mailAsunto").removeAttr("style");

		var page = WEB_ROOT+"/ajax/exportexcelpdfC.php";
		/*Inicio crear PDF*/
		var type = 'PRINTmailPDF';
		var accion = 'editar';
		var IDF = $('#TablaHtmlIDF').html();
		var IdCstClt = ID;
		var ENUMERATEPDFINFUNCION = '';
		var VENDESGLOSEIVA = DG;

			$.ajax({
				type: "GET",
				url: page,
				data: {
					'type' : type,
					'name' : Title,
					'MM_accion' : accion,
					'IDF' : IDF,
					'IdCstClt' : IdCstClt,
					'VDI' : VENDESGLOSEIVA,
				},
				success: function(response){ /*Inicio crear PDF*/
					// console.log(response);

					if(TIPO == 'VENTADC' || TIPO == 'COMPRADC'){
					var namePDF = response.trim();
					// $("#alertModal").html(ID);
					// console.log(namePDF);

					//INICIO CREA TICKET
					var tipovista = "Guardar";
					page = WEB_ROOT+"/ajax/printticketComandero.php";
					$.ajax({
						type: "GET",
						url: page,
						data: {
							'type' : "PrintTicket",
							'id' : ID,
							'tipovista': tipovista,
							'archivo':namePDF
						},
						success: function(response2){
							$('#myModal').modal('toggle');
							if(response2 == '0_N'){ //Ticket tamaño carta solo envia un archivo.
								envioMailPDF(setTo,setSubject,mensaje,namePDF);
							}else{
								envioMailPDF(setTo,setSubject,mensaje,response+','+response2.trim());
							}
							// $("#alertModal").html(response2);
						}
					});
					//FIN CREA TICKET
					}else{
						$('#myModal').modal('toggle');
						envioMailPDF(setTo,setSubject,mensaje,response);
					}
			}
		});
	}else{
		if(setTo == ""){
			$("#mailDestinatario").css("border-color", "#d60707");
			$("#mailDestinatario").focus();
		}else{
			$("#mailAsunto").css("border-color", "#d60707");
			$("#mailAsunto").focus();
		}
		alertModal = "<div align='center' class='alert alert-danger alert-dismissable hiddenalertfadeout_danger'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>¡Llenar campo!</div>";	
	}
	$("#alertModal").html(alertModal);
	window.setTimeout(function() {
		$(".hiddenalertfadeout_danger").hide("slow");
	}, 2800);
}

function envioCotizaAjax(DG,ID,TIPO){
	var setTo =	$("#mailDestinatario").val();
	var setSubject = $("#mailAsunto").val(); 
	var mensaje = $("#mailMensaje").val(); 
	var alertModal="";

/*Inicio de titulos*/
	if(TIPO == 'VENTA' || TIPO == 'COMPRA' || TIPO == 'VENTAD' || TIPO == 'COMPRAD' || TIPO == 'COMPRAOFM' || TIPO == 'COMPRAOFMD' || TIPO == 'REQOFM' || TIPO == 'REQOFMD'){
		if (TIPO == 'VENTA') {
			var Title = 'Cotización';
		}else if(TIPO == 'COMPRA'){
			var Title = 'Orden de compra';
		}else if(TIPO == 'VENTAD'){
			var Title = 'Detalle de venta';
		}else if(TIPO == 'COMPRAD'){
			var Title = 'Detalle de compra';
		}else if(TIPO == 'COMPRAOFM'){
			var Title = 'Compra';
		}else if(TIPO == 'COMPRAOFMD'){
			var Title = 'Compra';
		}else if(TIPO == 'REQOFM'){
			var Title = 'Requisición';
		}else if(TIPO == 'REQOFMD'){
			var Title = 'Requisición';
		}

	}else{
		var Title = TIPO;
	}
/*Fin de titulos*/

	if(setTo != "" && setSubject != ""){
		$("#mailDestinatario").removeAttr("style");
		$("#mailAsunto").removeAttr("style");

		var page = WEB_ROOT+"/ajax/exportexcelpdfP.php";
		/*Inicio crear PDF*/
		var type = 'PRINTmailPDF';
		var accion = 'editar';
		var IDF = $('#TablaHtmlIDF').html();
		var IdCstClt = ID;
		var ENUMERATEPDFINFUNCION = '';
		var VENDESGLOSEIVA = DG;

			$.ajax({
				type: "GET",
				url: page,
				data: {
					'type' : type,
					'name' : Title,
					'MM_accion' : accion,
					'IDF' : IDF,
					'IdCstClt' : IdCstClt,
					'VDI' : VENDESGLOSEIVA,
				},
				success: function(response){ /*Inicio crear PDF*/
					// console.log(response);

					if(TIPO == 'VENTAD'){
					var namePDF = response.trim();
					// $("#alertModal").html(ID);
					// console.log(namePDF);

					//INICIO CREA TICKET
					var tipovista = "Guardar";
					page = WEB_ROOT+"/ajax/printticket.php";
					$.ajax({
						type: "GET",
						url: page,
						data: {
							'type' : "PrintTicket",
							'id' : ID,
							'tipovista': tipovista,
							'archivo':namePDF
						},
						success: function(response2){
							$('#myModal').modal('toggle');
							if(response2 == '0_N'){ //Ticket tamaño carta solo envia un archivo.
								envioMailPDF(setTo,setSubject,mensaje,namePDF);
							}else{
								envioMailPDF(setTo,setSubject,mensaje,response+','+response2.trim());
							}
							// $("#alertModal").html(response2);
						}
					});
					//FIN CREA TICKET
					}else{
						$('#myModal').modal('toggle');
						envioMailPDF(setTo,setSubject,mensaje,response);
					}
			}
		});
	}else{
		if(setTo == ""){
			$("#mailDestinatario").css("border-color", "#d60707");
			$("#mailDestinatario").focus();
		}else{
			$("#mailAsunto").css("border-color", "#d60707");
			$("#mailAsunto").focus();
		}
		alertModal = "<div align='center' class='alert alert-danger alert-dismissable hiddenalertfadeout_danger'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>¡Llenar campo!</div>";	
	}
	$("#alertModal").html(alertModal);
	window.setTimeout(function() {
		$(".hiddenalertfadeout_danger").hide("slow");
	}, 2800);
}

function envioCotizaAjax2(DG,id){
	// $('#myModal').modal('toggle');
	var setTo =	$("#mailDestinatario").val();
	var setSubject = $("#mailAsunto").val(); 
	var mensaje = $("#mailMensaje").val(); 
	
	var Title = "Cotización" ;
	var page = WEB_ROOT+"/ajax/exportexcelpdf.php";

//Inicio crea variables para PDF
	var htmlCampos = $('#TablaHtmlCampos').html();
	var htmlDatos = $('#TablaHtmlDatos').html();
	var htmlEtiqueta = $('#TablaHtmlEtiqueta').html();
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlEtiquetaCabecera = $('#etiquetaexportCabecera').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var ENUMERATEPDFINFUNCION = $("#TablaHtmlEnumeratePDF").html();
	var CLT_COTIZA = $("#CLT_COTIZA").val();
	var info = 'Cotización';
	var typeExport = 'mailPDF';
	var DATOS_GET = "";
	var typeExportPDF="";
	// var Title = "";

	if(typeExport=="mailPDF"){
		typeExportPDF= "PDF";
		// Title=info;
	}else{
		typeExportPDF=typeExport;
		Title = info.title;
	}

	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : typeExportPDF,
			'name' : Title,
			'htmlCampos' : htmlCampos,
			'htmlDatos' : htmlDatos,
			'htmlEtiqueta' : htmlEtiqueta,
			'htmlEtiquetaCabecera' : htmlEtiquetaCabecera,
			'htmlIDF' : htmlIDF,
			'htmlIMM_accion' : htmlIMM_accion,
			'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
			'CLT_COTIZA' : CLT_COTIZA,
		},
		success: function(response){
		//Inicio Crear PDF
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'type' :"PRINTmailPDF",
					'name' : Title,
					'htmlIDF' : htmlIDF,
					'htmlIMM_accion' : htmlIMM_accion,
					'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
					'CLT_COTIZA' : CLT_COTIZA,
				},
				success: function(response){
					envioMailPDF(setTo,setSubject,mensaje,response);
				}
			});
		//Fin crear PDF
		}
	});
//Fin crea variables para PDF
}

function envioCotiza(setTo,setSubject,mensaje,Title){

	var page = WEB_ROOT+"/ajax/exportexcelpdf.php";

//Inicio crea variables para PDF
	var htmlCampos = $('#TablaHtmlCampos').html();
	var htmlDatos = $('#TablaHtmlDatos').html();
	var htmlEtiqueta = $('#TablaHtmlEtiqueta').html();
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlEtiquetaCabecera = $('#etiquetaexportCabecera').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var ENUMERATEPDFINFUNCION = $("#TablaHtmlEnumeratePDF").html();
	var CLT_COTIZA = $("#CLT_COTIZA").val();
	var info = 'Cotización';
	var typeExport = 'mailPDF';
	var DATOS_GET = "";
	var typeExportPDF="";
	// var Title = "";

	if(typeExport=="mailPDF"){
		typeExportPDF= "PDF";
		// Title=info;
	}else{
		typeExportPDF=typeExport;
		Title = info.title;
	}

	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : typeExportPDF,
			'name' : Title,
			'htmlCampos' : htmlCampos,
			'htmlDatos' : htmlDatos,
			'htmlEtiqueta' : htmlEtiqueta,
			'htmlEtiquetaCabecera' : htmlEtiquetaCabecera,
			'htmlIDF' : htmlIDF,
			'htmlIMM_accion' : htmlIMM_accion,
			'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
			'CLT_COTIZA' : CLT_COTIZA,
		},
		success: function(response){
		//Inicio Crear PDF
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'type' :"PRINTmailPDF",
					'name' : Title,
					'htmlIDF' : htmlIDF,
					'htmlIMM_accion' : htmlIMM_accion,
					'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
					'CLT_COTIZA' : CLT_COTIZA,
				},
				success: function(response){
					envioMailPDF(setTo,setSubject,mensaje,response);
				}
			});
		//Fin crear PDF
		}
	});
//Fin crea variables para PDF
}

function envioDetalleTicket(setTo,setSubject,mensaje,Title,id){
	

	var page = WEB_ROOT+"/ajax/exportexcelpdf.php";

//Inicio crea variables para PDF
	var htmlCampos = $('#TablaHtmlCampos').html();
	var htmlDatos = $('#TablaHtmlDatos').html();
	var htmlEtiqueta = $('#TablaHtmlEtiqueta').html();
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlEtiquetaCabecera = $('#etiquetaexportCabecera').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var ENUMERATEPDFINFUNCION = $("#TablaHtmlEnumeratePDF").html();
	var CLT_COTIZA = $("#CLT_COTIZA").val();
	var info = 'Venta';
	var typeExport = 'mailPDF';
	var DATOS_GET = "";
	var typeExportPDF="";
	// var Title = "";

	if(typeExport=="mailPDF"){
		typeExportPDF= "PDF";
		// Title=info;
	}else{
		typeExportPDF=typeExport;
		Title = info.title;
	}

	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : typeExportPDF,
			'name' : Title,
			'htmlCampos' : htmlCampos,
			'htmlDatos' : htmlDatos,
			'htmlEtiqueta' : htmlEtiqueta,
			'htmlEtiquetaCabecera' : htmlEtiquetaCabecera,
			'htmlIDF' : htmlIDF,
			'htmlIMM_accion' : htmlIMM_accion,
			'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
			'CLT_COTIZA' : CLT_COTIZA,
		},
		success: function(response){
		//Inicio crear PDF DETALLE
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'type' :"PRINTmailPDF",
					'name' : Title,
					'htmlIDF' : htmlIDF,
					'htmlIMM_accion' : htmlIMM_accion,
					'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
					'CLT_COTIZA' : CLT_COTIZA,
				},
				success: function(response){
				//INICIO CREA PDF TICKET
					var tipovista = "Guardar";
					page = WEB_ROOT+"/ajax/printticket.php";
					$.ajax({
						type: "GET",
						url: page,
						data: {
							'type' : "PrintTicket",
							'id' : id,
							'tipovista': tipovista,
							'archivo':response
						},
						success: function(response2){
							envioMailPDF(setTo,setSubject,mensaje,response2);
						}
					});
				//INICIO CREA PDF TICKET
				}
			});
		//FIN CREAR PDF DETALLE
		}
	});
//Fin crea variables para PDF
}

function envioDetalleTicketComandero(setTo,setSubject,mensaje,Title,id){
	

	var page = WEB_ROOT+"/ajax/exportexcelpdf.php";

//Inicio crea variables para PDF
	var htmlCampos = $('#TablaHtmlCampos').html();
	var htmlDatos = $('#TablaHtmlDatos').html();
	var htmlEtiqueta = $('#TablaHtmlEtiqueta').html();
	var htmlIDF = $('#TablaHtmlIDF').html();
	var htmlEtiquetaCabecera = $('#etiquetaexportCabecera').html();
	var htmlIMM_accion = $('#TablaHtmlIMM_accion').html();
	var ENUMERATEPDFINFUNCION = $("#TablaHtmlEnumeratePDF").html();
	var CLT_COTIZA = $("#CLT_COTIZA").val();
	var info = 'Venta';
	var typeExport = 'mailPDF';
	var DATOS_GET = "";
	var typeExportPDF="";
	// var Title = "";

	if(typeExport=="mailPDF"){
		typeExportPDF= "PDF";
		// Title=info;
	}else{
		typeExportPDF=typeExport;
		Title = info.title;
	}

	$.ajax({
		type: "POST",
		url: page,
		data: {
			'type' : typeExportPDF,
			'name' : Title,
			'htmlCampos' : htmlCampos,
			'htmlDatos' : htmlDatos,
			'htmlEtiqueta' : htmlEtiqueta,
			'htmlEtiquetaCabecera' : htmlEtiquetaCabecera,
			'htmlIDF' : htmlIDF,
			'htmlIMM_accion' : htmlIMM_accion,
			'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
			'CLT_COTIZA' : CLT_COTIZA,
		},
		success: function(response){
		//Inicio crear PDF DETALLE
			$.ajax({
				type: "GET",
				url: page,
				data: {
					'type' :"PRINTmailPDF",
					'name' : Title,
					'htmlIDF' : htmlIDF,
					'htmlIMM_accion' : htmlIMM_accion,
					'ENUMERATEPDFINFUNCION' : ENUMERATEPDFINFUNCION,
					'CLT_COTIZA' : CLT_COTIZA,
				},
				success: function(response){
				//INICIO CREA PDF TICKET
					var tipovista = "Guardar";
					page = WEB_ROOT+"/ajax/printticketComandero.php";
					$.ajax({
						type: "GET",
						url: page,
						data: {
							'type' : "PrintTicket",
							'id' : id,
							'tipovista': tipovista,
							'archivo':response
						},
						success: function(response2){
							envioMailPDF(setTo,setSubject,mensaje,response2);
						}
					});
				//INICIO CREA PDF TICKET
				}
			});
		//FIN CREAR PDF DETALLE
		}
	});
//Fin crea variables para PDF
}

function validaRFC(rfcStr,tipo) {
	var strCorrecta;
	var rfcStrID;
	if(rfcStr.value == 1 || rfcStr.value == 2 || rfcStr.value == 3 || rfcStr.value == 4){
		strCorrecta = $("#"+tipo).val();
		var tipoPersona = rfcStr.value;
		var rfcStrID = tipo;
	}else{
		strCorrecta = rfcStr.value;
		var tipoPersona = $("#"+tipo).val();
		var rfcStrID = rfcStr.id;
	}
	if(tipoPersona == 3 || tipoPersona == 4){
		$("#"+rfcStrID).removeAttr("required");
		$("#"+rfcStrID).removeAttr("style");
	}else{
		$("#"+rfcStrID).attr( {'required' : true} );
	}
	if(tipoPersona !=""){
		if(strCorrecta != ""){
			if (tipoPersona == 1 && strCorrecta.length == 12){ //persona moral
				var valid = '^(([A-Z]|[a-z]){3})([0-9]{2})(1[0-2]|0[1-9])([0-3][0-9])(([A-Z0-9]|[a-z0-9]){3})';
			}else if(tipoPersona == 2 && strCorrecta.length == 13){ // persona fisica
				var valid = '^(([A-Z]|[a-z]){4})([0-9]{2})(1[0-2]|0[1-9])([0-3][0-9])(([A-Z0-9]|[a-z0-9]){3})';
			}

			if(tipoPersona != 3 && tipoPersona != 4){ // Otro
				if(valid){
					var validRfc = new RegExp(valid);
					var matchArray=strCorrecta.match(validRfc);
				}
				if (matchArray==null) {
					// console.log('Cadena incorrecta '+ strCorrecta+" "+tipoPersona+" "+rfcStr.length);
					$("#"+rfcStrID).val("");
					$("#"+rfcStrID).css("border-color", "#d60707");
					jAlert('RFC NO VALIDO',"!Alerta!");
				}else{
					$("#"+rfcStrID).removeAttr("style");
				}
			}
		}
	}
}

function RFCEXISTE(rfc) {
	var  vrfc= $("#"+rfc).val();
	alert(vrfc)
}

function validarMenorVenta(valor,cantidad,control){
	var valorD = valor;
	var cantidadD = cantidad;
	var controlD = control;

	var Menor = validarMenor(valorD,cantidadD);

	if(Menor){
		$("#"+cantidadD).val('');
		$("#"+cantidadD).css("border-color", "#d60707");
		$("#"+cantidadD).focus();
		alertModal = "<div align='center' class='alert alert-danger alert-dismissable hiddenalertfadeout_danger'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>¡El efectivo debe ser igual o mayor al total!</div>";
		$("#"+controlD).html(alertModal);

		window.setTimeout(function() {
		$(".hiddenalertfadeout_danger").hide("slow");
		}, 3800);

	}else{
		$("#"+cantidadD).removeAttr("style");
	}

}

function limpiarArch(id){
	$("#Rarchivo"+id).val("");
	$("#label"+id).html("");
}

$(document).ready(function() {
$(".foco").focus();
});

function ModalCheckList(idf){
	if(idf==292){
		var idfn=309;
	}
	if(idf==295){
		var idfn=322;
	}
	if(idf==297){
		var idfn=323;
	}
	if(idf==299){
		var idfn=324;
	}
	if(idf==301){
		var idfn=325;
	}
	if(idf==294){
		var idfn=326;
	}
	if(idf==296){
		var idfn=327;
	}
	if(idf==293){
		var idfn=328;
	}

	if(idf==318){
		var idfn=329;
	}
	if(idf==319){
		var idfn=330;
	}
	if(idf==320){
		var idfn=331;
	}
	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-CheckList.php";

			$.ajax({
				type: "GET",
				url: page,
				data: {
					'MM_accion' : "nuevo",
					'ID' : 34,
					'IDF' : idfn,
					'MODAL' : 'SI'
				},
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					//imprimit todo el formulario
					$('#contenidoModalHidden').html(response);
					//obtener los html del formulario
					// var frmAction = $('#formGeneral').attr('action');
					var headerModal = $('#TITULOAccionModal').html();
					var footerModal = $('#BTNAccionModal').html();
					var frmContenido = $('#formGeneral').html();
					// alert(frmContenido);

					//limpiar contenido
					$('#contenidoModalHidden').html("");

					//asignar y construir nuevo formulario
					// $('#formModalGeneral').attr({
					// 	'action' : frmAction
					// });
					$('#headerModal').html(headerModal);
					$('#footerModal').html(footerModal);

					$('#contenidoModal').html(frmContenido);
					$('#HeaderForm').remove();
					//mostrar el modal
					$('#myModal').modal();
				}
			});
	
}


function lotesAlert(){
	var MM_accion = $('#TablaHtmlIMM_accion').html();
	if(MM_accion=='editar'){
		jAlert('Si la PARTIDA se edita, los LOTES serán borrados.',"¡Alerta!");
	}
}

function limpiarInputs(CAMPOS_A_LIMPIAR,event,CAMPO_CONDICION){
	var key = event.keyCode;
	var array = CAMPOS_A_LIMPIAR.split(",");
	if (key != 9 && key != 13 && key != 16 && key != 17 && key != 18 && key != 20 && key != 35 && key != 36 && key != 37 && key != 39) {
	   for (var i=0; i < array.length; i++) {
			$("#"+array[i]).val("");
	   }
	}
}

function describePartida(valor){
	var IDPARTIDA = valor.value;
	var id=valor.id;
	var page = WEB_ROOT+"/ajax/iGobconsultarPartidas.php";

			$.ajax({
				type: "POST",
				url: page,
				data: {
					'IDPARTIDA' : IDPARTIDA 
				},
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					var iconAyuda ='Descripción de partida :\n'+response; 
					$('#msjIconAyuda'+id).val(iconAyuda);
				}
			});

}

function iGobModalRSol(){

	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ModalGeneral.php";
	$.ajax({
		type: "GET",
		url: page,
		data: {
			'MM_accion' : "nuevo",
			'ID' : 2,
			'IDF' : 363,
			'MODAL' : 'SI'

		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//imprimit todo el formulario
			$('#contenidoModalHidden').html(response);

			//obtener los html del formulario
			var headerModal = $('#TITULOAccionModal').html();
			var footerModal = $('#BTNAccionModal').html();
			var frmContenido = $('#formGeneral').html();

			//limpiar contenido
			$('#contenidoModalHidden').html("");

			$('#headerModal').html(headerModal);
			$('#footerModal').html(footerModal);

			$('#contenidoModal').html(frmContenido);
			$('#HeaderForm').remove();
			//mostrar el modal
			$('#myModal').modal();
			/*$("#myModal").on('shown.bs.modal', function () {
				$('#efectivo').focus();
			});
			$("#myModal").on('hidden.bs.modal', function () {
            	$('#CODIGOPRODUCTOUNIDAD').focus();
    		});*/
		}
	});
}


/*Inicio iGob mapa*/
function myMap(coords,id_campo,draggable,marcador) {
		var marker;
		var mapProp= {
			center:new google.maps.LatLng(coords.lat,coords.lng),
			zoom:13,
		};
		var map=new google.maps.Map(document.getElementById("googleMap_"+id_campo),mapProp);

		if(marcador==null || marcador==true){	
			marker = new google.maps.Marker({
	      	map: map,
	      	draggable: draggable,
	      	animation: google.maps.Animation.DROP,
	      	position: new google.maps.LatLng(coords.lat,coords.lng),
	      	});
		}

		if(draggable){
			// marker.addListener('click', toggleBounce);
			 marker.addListener( 'dragend', function (event){
	        //escribimos las coordenadas de la posicion actual del marcador dentro del input #coords
	        	document.getElementById(id_campo).value = this.getPosition().lat()+","+ this.getPosition().lng();
	    	});
		}
	}

//callback al hacer clic en el marcador lo que hace es quitar y poner la animacion BOUNCE
function toggleBounce() {
	if (marker.getAnimation() !== null) {
		marker.setAnimation(null);
	} else {
		marker.setAnimation(google.maps.Animation.BOUNCE);
	}
}
/*Fin iGob mapa*/

function iGobModalEntrega(){

	var page = WEB_ROOT+"/pages/ADMFrmDinamicoAbcV8-ModalEntrega.php";
	$.ajax({
		type: "GET",
		url: page,
		data: {
			'MM_accion' : "nuevo",
			'ID' : 2,
			'IDF' : 379,
			'MODAL' : 'SI'

		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response){
			//imprimit todo el formulario
			$('#contenidoModalHidden').html(response);

			//obtener los html del formulario
			var headerModal = $('#TITULOAccionModal').html();
			var footerModal = $('#BTNAccionModal').html();
			var frmContenido = $('#formGeneral').html();

			//limpiar contenido
			$('#contenidoModalHidden').html("");

			$('#headerModal').html(headerModal);
			$('#footerModal').html(footerModal);

			$('#contenidoModal').html(frmContenido);
			$('#HeaderForm').remove();
			//mostrar el modal
			$('#myModal').modal();
		}
	});
	
}

function iGobMensajeAlert(msj){
	jAlert(msj,'¡Alerta!');
}

function iGobBloqueaPresupuesto(value){
	if(value==3){
		$("#IDCATCLAVEPRESUPUESTALDETALLE").attr( {'disabled' : true} );
		$("#CLVNUMMINISTRACION").attr( {'disabled' : true} );
		$("#IDMESESDE").attr( {'disabled' : true} );
		$("#IDMESESAL").attr( {'disabled' : true} );
		$("#CLVMONTOPRESUPUESTADO").attr( {'disabled' : true} );

		$("#IDCATCLAVEPRESUPUESTALDETALLE").val('');
		$("#CLVNUMMINISTRACION").val('');
		$("#IDMESESDE").val('');
		$("#IDMESESAL").val('');
		$("#CLVMONTOPRESUPUESTADO").val('');
	}else{
		$("#IDCATCLAVEPRESUPUESTALDETALLE").attr( {'disabled' : false} );
		$("#CLVNUMMINISTRACION").attr( {'disabled' : false} );
		$("#IDMESESDE").attr( {'disabled' : false} );
		$("#IDMESESAL").attr( {'disabled' : false} );
		$("#CLVMONTOPRESUPUESTADO").attr( {'disabled' : false} );

	}
}

function selectComplete(VALUE,CAMPOVALUE,QUERY,CAMPOSQUERY){
	var page = WEB_ROOT+"/ajax/selectComplete.php";
	if(VALUE>0){
		$.ajax({
			type: "POST",
			url: page,
			data: {
				'value' : VALUE, 
				'campovalue' : CAMPOVALUE, 
				'query' : QUERY
			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				var arrayQuery = $.parseJSON(response);
				var arrayCampos = CAMPOSQUERY.trim().split(',');
				arrayCampos.forEach(function(value,index) {
					$("#"+value.trim()).val(arrayQuery[value.trim()]);
				});
			}
		});
	}
}

function iGobselectCompleteC_Entrega(VALUE,CAMPOVALUE,QUERY,CAMPOSQUERY){
	var page = WEB_ROOT+"/ajax/selectComplete.php";
	if(VALUE>0){
		$.ajax({
			type: "POST",
			url: page,
			data: {
				'value' : VALUE, 
				'campovalue' : CAMPOVALUE, 
				'query' : QUERY
			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				var arrayQuery = $.parseJSON(response);
				var arrayCampos = CAMPOSQUERY.trim().split(',');
				arrayCampos.forEach(function(value,index) {
					if(value=='IDTIPODIA'){
						if(arrayQuery[value.trim()]==1){
							document.getElementById("CNDDIALUNES").checked=true;
							document.getElementById("CDNDIAMARTES").checked=true;
							document.getElementById("CDNDIAMIERCOLES").checked=true;
							document.getElementById("CDNDIAJUEVES").checked=true;
							document.getElementById("CDNDIAVIERNES").checked=true;
							document.getElementById("CDNDIASABADO").checked=false;
							document.getElementById("CDNDIADOMINGO").checked=false;
							document.getElementById("CDNDIASABADO").disabled=true;
							document.getElementById("CDNDIADOMINGO").disabled=true;
						}else if(arrayQuery[value]==2){
							document.getElementById("CNDDIALUNES").checked=true;
							document.getElementById("CDNDIAMARTES").checked=true;
							document.getElementById("CDNDIAMIERCOLES").checked=true;
							document.getElementById("CDNDIAJUEVES").checked=true;
							document.getElementById("CDNDIAVIERNES").checked=true;
							document.getElementById("CDNDIASABADO").checked=true;
							document.getElementById("CDNDIADOMINGO").checked=true;
							document.getElementById("CDNDIASABADO").disabled=false;
							document.getElementById("CDNDIADOMINGO").disabled=false;
						}
					}else{
						$("#"+value.trim()).val(arrayQuery[value.trim()]);
					}
				});
			}
		});
	}
}

function selectCompleteMapa(VALUE,CAMPOVALUE,QUERY,CAMPOSQUERY){
	var page = WEB_ROOT+"/ajax/selectComplete.php";
	var arrayCampos = CAMPOSQUERY.trim().split(',');
	if(VALUE>0){
		$.ajax({
			type: "POST",
			url: page,
			data: {
				'value' : VALUE, 
				'campovalue' : CAMPOVALUE, 
				'query' : QUERY
			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				var arrayQuery = $.parseJSON(response);
				arrayCampos.forEach(function(value,index) {
					$("#"+value.trim()).val(arrayQuery[value.trim()]);
					var arrayCords = arrayQuery[value.trim()];
					arrayCords = arrayCords.split(',');
					var coords = {
						lat: arrayCords[0],
						lng: arrayCords[1]
					};
					myMap(coords,value,false);
				});
			}
		});
	}else{
		arrayCampos.forEach(function(value,index) {
			$("#"+value.trim()).val("");
			var coords = {
				lat: 16.7519751, 
				lng: -93.1182458 
			}; 
			myMap(coords,value,false,false);
		});
	}
}

function modal(){
	$('#miModal').modal();
	$("#miModal").on('shown.bs.modal', function () {
		$(".pop-required").attr({'required' : true});
		banderaSub = 1;
		$("#CNECONDICIONESENTREGA").focus();
		$("#IDRECHAZO").focus();

    });
    $("#miModal").on('hidden.bs.modal', function () {
		$(".pop-required").attr({'required' : false});
    });

}

function enviaSubmit(){

	var intputElements = document.getElementById("IDRECHAZO");
	intputElements.target.setCustomValidity("The field 'Username' cannot be left blank");
    /*for (var i = 0; i < intputElements.length; i++) {
        intputElements[i].oninvalid = function (e) {
            e.target.setCustomValidity("");
            if (!e.target.validity.valid) {
                if (e.target.name == "IDRECHAZO") {
                    e.target.setCustomValidity("The field 'Username' cannot be left blank");
                }
                else {
                    e.target.setCustomValidity("The field 'Password' cannot be left blank");
                }
            }
        };
    }*/
	/*banderaSub = 1;
	$('#form1').submit();*/
	/*var INPUT = document.getElementById('IDRECHAZO');
	INPUT.setCustomValidity("Debe ingresar al menos 3 LETRAS");  */
}

function iGobhabilitarDetalle(idf){
	
	$("#valorD").val(1);
	$(".D1").attr( {'readonly' : false, 'disabled':false});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	$("#COMPRAR").attr( {'readonly' : true, 'disabled':true});
	$("#DescargarPDF").attr( {'readonly' : true, 'disabled':true});
	$("#enviarCotiza_CD").attr( {'readonly' : true, 'disabled':true});

	if(idf=="357"){
		$("#CCDCOSTO").attr({'readonly' : true});
	}
	$("#CODIGOPRODUCTOUNIDAD").focus();
	
	$("#nuevoD").attr( {'type': 'submit'});
	$("#nuevoD").attr( {'onclick': 'setTitleBtn(this);'});
	// $("#nuevoD").removeAttr('onclick');
	$("#spanNuevo").html(" ");
	$("#spanNuevo").addClass('icon-save');
	$("#cancelarNuevoBtn").removeAttr("style");


	selectPikerSearch('D1');

}
function iGobhabilitarDetalle2(idf){

	$("#valorD").val(2);
	$(".D2").attr( {'readonly' : false, 'disabled':false});
	$("#ACEPTAR").attr( {'readonly' : true, 'disabled':true});
	$("#COMPRAR").attr( {'readonly' : true, 'disabled':true});
	$("#DescargarPDF").attr( {'readonly' : true, 'disabled':true});
	$("#enviarCotiza_CD").attr( {'readonly' : true, 'disabled':true});
	
	$("#nuevoD2").attr( {'type': 'submit'});
	$("#nuevoD2").attr( {'onclick': 'setTitleBtn(this);'});
	// $("#nuevoD").removeAttr('onclick');
	$("#spanNuevo2").html(" ");
	$("#cancelarNuevoBtn2").removeAttr("style");


	selectPikerSearch('D2');

}

function iGobDescargarS(IDS){
	DATOS_GET = "?IDS="+IDS;
	web = WEB_ROOT+"/ajax/export_PDF.php" + DATOS_GET;
	myWindow = window.open(web, 'windowOpenTab');
}

function myTicket(value){
	var page = WEB_ROOT+"/ajax/myTicket.php";

	$.ajax({
			type: "POST",
			url: page,
			data: {
				'ID':value
			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				var ficha=response;
				var ventimp=window.open(' ','popimpr');
				
				ventimp.document.write(ficha);
				ventimp.document.close();
				ventimp.print();
				ventimp.close();
			}
		});

}

function iGobOriRecur(value){
	if(value==3){
		var page = WEB_ROOT+"/ajax/iGobConsultaMontoComprometido.php";

		$.ajax({
				type: "POST",
				url: page,
				beforeSend: function(){
					//ejecutar antes de cargar el archivo
				},
				success: function(response){
					$("#CLVMONTOAFECTADO").val(response);
				}
			});
	}
}

function OFMVentaCompraLimpiar(){
	$("#VTDCANTIDAD").val('');
	$("#VTDIMPORTE").val('0.00');
	$("#VTDCANTIDAD").focus();

	$("#CCDCANTIDAD").val('');
	$("#CCDIMPORTE").val('0.00');
	$("#CCDCANTIDAD").focus();

	$("#CANTIDAD").val('');
	$("#IMPORTE").val('0.00');
	$("#CANTIDAD").focus();
	
}
function tipoorigen(columna){
	if(columna.value!=3){
	$("#CLVMONTOENCUENTA").attr({'disabled' : false});
	$("#CLVSALDOIGOB").attr({'disabled':true});
	$("#CLVNUMEROOPRBANCARIA").attr({'readonly' : false, 'disabled':false});
	}else{
	$("#CLVMONTOENCUENTA").attr({'disabled':true});
	$("#CLVSALDOIGOB").attr({'disabled' : false});
	$("#CLVNUMEROOPRBANCARIA").attr({'readonly' : true, 'disabled':true});
	}
}
function origenR(partida){
	var page = WEB_ROOT+"/ajax/completarCampos.php";
		$.ajax({
			type: "POST",
			url: page,
			data: {
				'value' : partida.value
			},
			beforeSend: function(){
				//ejecutar antes de cargar el archivo
			},
			success: function(response){
				var arrayQuery = $.parseJSON(response);
				if(arrayQuery.IDORIGENRECURSO!=null){
				$("#IDORIGENRECURSO").val(arrayQuery.IDORIGENRECURSO);
				$("#ORIGENRECURSO").val(arrayQuery.ORIGENRECURSO);
				$("#DGNVALORAPROXIMADO").val(arrayQuery.MONTOSALDO);
				$("#IDEJERCICIO").val(arrayQuery.IDEJERCICIO);
				$("#EJERCICIO").val(arrayQuery.EJERCICIO);
				}else{
				$("#IDORIGENRECURSO").val("");
				$("#ORIGENRECURSO").val("");
				$("#DGNVALORAPROXIMADO").val("");
				$("#IDEJERCICIO").val("");
				$("#EJERCICIO").val("");
				jAlert('No tiene recurso presupuestado para la partida seleccionada',"Aviso!!");
			}
			}
		});
}

function iGobValidarRespuesta(valor,campo){
	var STATUS = valor.value;
	if(STATUS ==4){
		$('#'+campo).val('');
		$("#"+campo).attr({'readonly' : true, 'required' : false});
	}else{
		$("#"+campo).attr({'readonly' : false, 'required' : true});
	}
}
function iGobHabilitarCheck(campoCheck,campoHabilitar){
	var STATUS = document.getElementById(campoCheck).checked;
	if(STATUS == true){
		$("#"+campoHabilitar).attr({'readonly' : false, 'required' : true});
	}else{
		$("#"+campoHabilitar).attr({'readonly' : true, 'required' : false});
		$("#"+campoHabilitar).val('');
	}
}

function unlock(valor,campo){
	if(valor.value==0){
		$("#"+campo).attr({'readonly' : false});
		$("#"+campo).attr({'required' : true});
	}else{
		$("#"+campo).attr({'readonly' : true});
		$("#"+campo).attr({'required' : false});
    	$("#"+campo).val("");
	}
}
function unlockR(valor,campo){
	if(valor.value==0){
		$("#"+campo).attr({'readonly' : true});
		$("#"+campo).attr({'required' : false});
		$("#"+campo).val("");
	}else{
		$("#"+campo).attr({'readonly' : false});
		$("#"+campo).attr({'required' : true});
	}
}

function comparaValor(me,campo){
	var ME = $("#"+me.id).val();
	var campo = $("#"+campo).val();
	if(ME==1 && campo==2){
		jAlert('No puede elegir rubro "No Aplica" para un tipo de producto de "Compra Interna"','¡Alerta!', function(){
		$("#"+me.id).val("");
		$("#IDRUBRO").selectpicker("refresh");
		});
	}
}

function saveAjax(CADENAVALUES){
	//idregistro,tabla,campoid,forprocedure,campos,typeCampos,IDF
var value = CADENAVALUES.split("_;-");
var idregistro = value[0];
var tabla = value[1];
var campoid = value[2];
var forprocedure = value[3];
var campos = value[4];
var typeCampos = value[5];
var IDF = value[6];
//alert(idregistro+"-"+tabla+"-"+campoid+"-"+forprocedure"-"+campos+"-"+typeCampos+"-"+IDF)
var campoAjax = "";
var cadenaCampos = "";
var columnas=campos.split(",");
var type=typeCampos.split(",");
for (var i = 0; i <= columnas.length-1; i++){
	if(type[i]=='checkbox'){
	campoAjax = document.getElementById(columnas[i]+idregistro).checked;
	if(campoAjax==false){
		campoAjax = "";
	}else{
		campoAjax = $("#"+columnas[i]+idregistro).val();
	}
	}else{
	campoAjax = $("#"+columnas[i]).val();
	}
	cadenaCampos = cadenaCampos+columnas[i]+"='"+campoAjax+"',";
	}
	cadenaCampos=cadenaCampos.slice(0,-1);
	//alert(cadenaCampos)
	var page = WEB_ROOT+"/ajax/updateRegistro.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDF' : IDF,
		'FORPROCEDURE' : forprocedure,
		'TABLA' : tabla,
		'CAMPOID' : campoid,
		'IDREGISTRO' : idregistro,
		'CAMPOS' : campos,
		'CADENACAMPOS' : cadenaCampos
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		var msj =respuestaphp.msj;
		jAlert(msj,'Aviso');
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

function saveAjaxCD(CADENAVALUES){
	//idregistro,tabla,campoid,forprocedure,campos,typeCampos,IDF
var value = CADENAVALUES.split("_;-");
var idregistroC = value[0];
var tablaC = value[1];
var campoidC = value[2];
var forprocedure = value[3];
var camposC = value[4];
var typeCamposC = value[5];
var IDF = value[6];
var idregistroD = value[7];
var tablaD = value[8];
var campoidD = value[9];
var camposD = value[10];
var typeCamposD = value[11];
var iddeclaratoria = value[12];

//alert(idregistro+"-"+tabla+"-"+campoid+"-"+forprocedure"-"+campos+"-"+typeCampos+"-"+IDF)
var campoAjaxC = "";
var cadenaCamposC = "";
var columnasC=camposC.split(",");
var typeC=typeCamposC.split(",");
for (var i = 0; i <= columnasC.length-1; i++){
	if(typeC[i]=='checkbox'){
		campoAjaxC = document.getElementById(columnasC[i]).checked;
		if(campoAjaxC==false){
			campoAjaxC = "";
		}else{
			campoAjaxC = $("#"+columnasC[i]).val();
		}
	}else{
		campoAjaxC = $("#"+columnasC[i]).val();
	}
	cadenaCamposC = cadenaCamposC+columnasC[i]+"='"+campoAjaxC+"',";
}
cadenaCamposC=cadenaCamposC.slice(0,-1);

var campoAjaxD = "";
	var cadenaCamposD = "";
	var columnasD=camposD.split(",");
	var typeD=typeCamposD.split(",");
	for (var i = 0; i <= columnasD.length-1; i++){
		if(columnasD[i]=="IDDECLARATORIA"){
			campoAjaxD = iddeclaratoria;
		}else{
		if(typeD[i]=='checkbox'){
			campoAjaxD = document.getElementById(columnasD[i]+idregistroD).checked;
			if(campoAjaxD==false){
				campoAjaxD = "";
			}else{
				campoAjaxD = $("#"+columnasD[i]+idregistroD).val();
			}
		}else if(typeD[i]=='number'){
			campoAjaxD = $("#"+columnasD[i]+idregistroD).val();
		}else{
			campoAjaxD = $("#"+columnasD[i]).val();
		}
	}
		cadenaCamposD = cadenaCamposD+columnasD[i]+"='"+campoAjaxD+"',";
}
	cadenaCamposD=cadenaCamposD.slice(0,-1);
	//alert(cadenaCamposD)
	var page = WEB_ROOT+"/ajax/updateRegistroCD.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDF' : IDF,
		'FORPROCEDURE' : forprocedure,
		'TABLAC' : tablaC,
		'CAMPOIDC' : campoidC,
		'IDREGISTROC' : idregistroC,
		'CAMPOSC' : camposC,
		'CADENACAMPOSC' : cadenaCamposC,
		'TABLAD' : tablaD,
		'CAMPOIDD' : campoidD,
		'IDREGISTROD' : idregistroD,
		'CAMPOSD' : camposD,
		'CADENACAMPOSD' : cadenaCamposD
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		var msj =respuestaphp.msj;
		var back =respuestaphp.back;
		jAlert(msj,'Aviso');
		//alert(back)
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
function saveAjaxT1y2(CADENAVALUES){
	//idregistro,tabla,campoid,forprocedure,campos,typeCampos,IDF
var value = CADENAVALUES.split("_;-");
var forprocedure = value[0];
var IDF = value[1];
var idregistro = value[2];
var tabla = value[3];
var campoid = value[4];
var campos = value[5];
//alert($('input:radio[id='+campos+idregistro+'si]:checked').val());
campoAjaxSi = document.getElementById(campos+idregistro+"si");
campoAjaxNo = document.getElementById(campos+idregistro+"no");
//alert(campoAjaxSi.checked +" -- "+campoAjaxNo.checked)
if(campoAjaxSi.checked==false && campoAjaxNo.checked==true){
	cadenaCampos =campos+"='2'";
}else if(campoAjaxSi.checked==true && campoAjaxNo.checked==false){
	cadenaCampos =campos+"='"+$("#"+campos+idregistro+"si").val()+"'";
}
//alert(idregistro+"-"+tabla+"-"+campoid+"-"+forprocedure"-"+campos+"-"+typeCampos+"-"+IDF)
/*var campoAjaxC = "";
var cadenaCamposC = "";
var columnasC=camposC.split(",");
var typeC=typeCamposC.split(",");
for (var i = 0; i <= columnasC.length-1; i++){
	if(typeC[i]=='checkbox'){
		campoAjaxC = document.getElementById(columnasC[i]).checked;
		if(campoAjaxC==false){
			campoAjaxC = "";
		}else{
			campoAjaxC = $("#"+columnasC[i]).val();
		}
	}else{
		campoAjaxC = $("#"+columnasC[i]).val();
	}
	cadenaCamposC = cadenaCamposC+columnasC[i]+"='"+campoAjaxC+"',";
}
cadenaCamposC=cadenaCamposC.slice(0,-1);*/

/*var campoAjaxD = "";
	var cadenaCamposD = "";
	var columnasD=camposD.split(",");
	var typeD=typeCamposD.split(",");
	for (var i = 0; i <= columnasD.length-1; i++){
		if(columnasD[i]=="IDDECLARATORIA"){
			campoAjaxD = iddeclaratoria;
		}else{
		if(typeD[i]=='checkbox'){
			campoAjaxD = document.getElementById(columnasD[i]+idregistroD).checked;
			if(campoAjaxD==false){
				campoAjaxD = "";
			}else{
				campoAjaxD = $("#"+columnasD[i]+idregistroD).val();
			}
		}else if(typeD[i]=='number'){
			campoAjaxD = $("#"+columnasD[i]+idregistroD).val();
		}else{
			campoAjaxD = $("#"+columnasD[i]).val();
		}
	}
		cadenaCamposD = cadenaCamposD+columnasD[i]+"='"+campoAjaxD+"',";
}
	cadenaCamposD=cadenaCamposD.slice(0,-1);*/
	//alert(cadenaCamposD)
	var page = WEB_ROOT+"/ajax/updateRegistroT1y2.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDF' : IDF,
		'FORPROCEDURE' : forprocedure,
		'TABLA' : tabla,
		'CAMPOID' : campoid,
		'IDREGISTRO' : idregistro,
		'CAMPOS' : campos,
		'CADENACAMPOS' : cadenaCampos
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		var msj =respuestaphp.msj;
		var back =respuestaphp.back;
		//alert(respuestaphp.error)
		//jAlert(msj,'Aviso');
		jAlert(msj,'Aviso', function(){
		location.reload();
		});
		//alert(respuestaphp.CADENA)
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}
function iGobAlertaActas(values,mensaje){
	var title = values.title;
	if(mensaje!='' && mensaje!=undefined){
		jAlert(mensaje, 'Aviso');
	}else{
		jAlert(title+' aún no disponible', 'Aviso');
	}
}

function saveACD(CADENAVALUES){
var value = CADENAVALUES.split("_;_");
var idregistroC = value[0];
var tablaC = value[1];
var campoidC = value[2];
var forprocedure = value[3];
var camposC = value[4];
var typeCamposC = value[5];
var IDF = value[6];
var idregistroD = value[7];
var tablaD = value[8];
var campoidD = value[9];
var camposD = value[10];
var typeCamposD = value[11];
var iddeclaratoria = value[12];

//alert(idregistro+"-"+tabla+"-"+campoid+"-"+forprocedure"-"+campos+"-"+typeCampos+"-"+IDF)
var campoAjaxC = "";
var cadenaCamposC = "";
var columnasC=camposC.split(",");
var typeC=typeCamposC.split(",");
for (var i = 0; i <= columnasC.length-1; i++){
	if(typeC[i]=='checkbox'){
		campoAjaxC = document.getElementById(columnasC[i]).checked;
		if(campoAjaxC==false){
			campoAjaxC = "";
		}else{
			campoAjaxC = $("#"+columnasC[i]).val();
		}
	}else{
		campoAjaxC = $("#"+columnasC[i]).val();
	}
	cadenaCamposC = cadenaCamposC+columnasC[i]+"='"+campoAjaxC+"',";
}
cadenaCamposC=cadenaCamposC.slice(0,-1);

var campoAjaxD = "";
	var cadenaCamposD = "";
	var columnasD=camposD.split(",");
	var typeD=typeCamposD.split(",");
	for (var i = 0; i <= columnasD.length-1; i++){
		if(columnasD[i]=="IDDECLARATORIA"){
			campoAjaxD = iddeclaratoria;
		}else{
		if(typeD[i]=='checkbox'){
			campoAjaxD = document.getElementById(columnasD[i]+idregistroD).checked;
			if(campoAjaxD==false){
				campoAjaxD = "";
			}else{
				campoAjaxD = $("#"+columnasD[i]+idregistroD).val();
			}
		}else if(typeD[i]=='numbertext'){
			campoAjaxD = $("#"+columnasD[i]+idregistroD).val();
			campoAjaxD = replaceAll(campoAjaxD,',','');
		}else{
			campoAjaxD = $("#"+columnasD[i]).val();
		}
	}
		cadenaCamposD = cadenaCamposD+columnasD[i]+"='"+campoAjaxD+"',";
}
	cadenaCamposD=cadenaCamposD.slice(0,-1);
	var page = WEB_ROOT+"/ajax/updateRegistroCD.php";
	$.ajax({
		type: "POST",
		url: page,
		data: {
		'IDF' : IDF,
		'FORPROCEDURE' : forprocedure,
		'TABLAC' : tablaC,
		'CAMPOIDC' : campoidC,
		'IDREGISTROC' : idregistroC,
		'CAMPOSC' : camposC,
		'CADENACAMPOSC' : cadenaCamposC,
		'TABLAD' : tablaD,
		'CAMPOIDD' : campoidD,
		'IDREGISTROD' : idregistroD,
		'CAMPOSD' : camposD,
		'CADENACAMPOSD' : cadenaCamposD
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
		var respuestaphp= $.parseJSON(response);
		var msj = respuestaphp.msj;
		var numMsj = respuestaphp.back;
		console.log(respuestaphp.CADENA);
		if(msj!=null){
			jAlert(msj,'Aviso');
		}
		if(numMsj==4){
			$("#REDCANTIDADRECIBIENDO"+idregistroD).val(0);
		}
		//alert(back)
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

function evalValue(campo){
	if(campo.value=="" || campo.value=="." || campo.value==".0"){
		$("#"+campo.id).val("0.00");
	}
}

function validaMejora(){
	var PTLESTATUSMEJORA =  document.getElementById("PTLESTATUSMEJORA").checked;

	if(PTLESTATUSMEJORA){
		$("#PTLMEJORAS").attr( {'readonly' : false} );
	}else{
		$("#PTLMEJORAS").attr( {'readonly' : true} );
		$("#PTLMEJORAS").val('');
	}
}

function iGobModal(){
	$('#exampleModal').modal();
	$("#exampleModal").on('shown.bs.modal', function () {
		$(".pop-required").attr({'required' : true});
		banderaSub = 1;
		$("#CNECONDICIONESENTREGA").focus();
		$("#IDRECHAZO").focus();

    });
    $("#exampleModal").on('hidden.bs.modal', function () {
		$(".pop-required").attr({'required' : false});
    });

}

function validaCobroBases(value,column){
	if (document.getElementById(value.id).checked) {
		$("#"+column).val('');
		$("#"+column).attr( {'readonly' : false} );
	}else{
		$("#"+column).val(0);
		$("#"+column).attr( {'readonly' : true} );
	}
}


function token(colum_pass){
	var user = $("#USER").val();
	var pass = $("#"+colum_pass).val();
	var progressbar='';
	//alert(user + ' ' + pass);
	var page = WEB_ROOT+"/examples/sample/token.php";

	$.ajax({
		type: "POST",
		url: page,
		data: {
		'userName' : user,
		'passCode' : pass
		},
		beforeSend: function(){
			//ejecutar antes de cargar el archivo
		},
		success: function(response) {
			var array = response.split(",");
			if(array[0]==2){
				$( "#form1" ).submit();
			}else{
				jAlert(array[1],'¡Alerta!', function(){
				$('#barraP').html(progressbar);

		});
			}
		},
		error:function(){
			jAlert(msgError, 'Alert Dialog');
		}
	});
}

$('#form1').keypress(function(e) {
        if (e.which == 13) {
            return false;
        }
});