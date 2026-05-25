var urlLoc = document.location.hostname;

if(urlLoc == "192.168.100.128" || urlLoc == "192.168.1.127" || urlLoc == "gokids.mx" || urlLoc == "www.gokids.mx"){
	var WEB_ROOT = "http://" + urlLoc + "/erpapp";
}else if(urlLoc == "www.solestranet.com" || urlLoc == "www.solestra.bit360.mx" || urlLoc == "www.bit360.mx" || urlLoc == "solestranet.com" || urlLoc == "bit360.mx" || urlLoc == "189.129.191.239" || urlLoc == "189.129.203.174"){
	var WEB_ROOT = "http://" + urlLoc + "/erpapp";
}else if(urlLoc == "igob.mx" || urlLoc == "www.igob.mx"){
	var WEB_ROOT = "http://" + urlLoc;
}else{
	var WEB_ROOT = "http://" + urlLoc;
}

function PDFLicita(IDL){
	DATOS_GET = "?IDS="+IDL;
	web = WEB_ROOT+"/ajax/PDFLicita.php"+DATOS_GET;
	myWindow = window.open(web, 'windowOpenTab');
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

function generarActaDudas(id){
	web = WEB_ROOT+"/ajax/PDFActaDudas.php?IDL="+id;
	myWindow = window.open(web, 'windowOpenTab');
}

function generarAperturaProp(id){
	web = WEB_ROOT+"/ajax/PDFAperturaProp.php?IDL="+id;
	myWindow = window.open(web, 'windowOpenTab');
}

function generarAdjudicacionProv(id){
	web = WEB_ROOT+"/ajax/PDFAdjudicacionProv.php?IDL="+id;
	myWindow = window.open(web, 'windowOpenTab');
}

function generarDictamen(id){
	web = WEB_ROOT+"/ajax/PDFDictamen.php?IDL="+id;
	myWindow = window.open(web, 'windowOpenTab');
}

function generarFallo(id){
	web = WEB_ROOT+"/ajax/PDFFallo.php?IDL="+id;
	myWindow = window.open(web, 'windowOpenTab');
}

function generarPedido(id){
	web = WEB_ROOT+"/ajax/PDFPedido.php?IDC="+id;
	myWindow = window.open(web, 'windowOpenTab');
}

function generarRecepcion(id){
	web = WEB_ROOT+"/ajax/PDFRecepcion.php?IDR="+id;
	myWindow = window.open(web, 'windowOpenTab');
}


