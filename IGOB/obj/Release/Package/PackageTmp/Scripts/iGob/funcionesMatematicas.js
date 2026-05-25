function sumar(nameClass,inputTotal){

	var total = 0;

	$('.'+nameClass).each(function() {
		total += Number(extraerNumero($(this).val()));
	});
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
}

function multiplicar(nameClass,inputTotal){
	var total = 1;
	$('.'+nameClass).each(function() {
		total = Number(extraerNumero(total))*Number(extraerNumero($(this).val()));
	});
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
}

function restar(nameClass,inputTotal){
	var total = 0;
	var x=0;
	$('.'+nameClass).each(function() {
		if(x==0){
			total = (extraerNumero($(this).val()))-(extraerNumero(total));
			x=1;
		}
		else
		{
			total = (extraerNumero(total))-(extraerNumero($(this).val()));
		}
	});

	$("#"+inputTotal).val(extraerNumero(total));
}
function dividir(nameClass,inputTotal){
	var total = 1;
	var x=0;

	$('.'+nameClass).each(function() {
		if (x==0) {
		total = Number(extraerNumero($(this).val()))/Number(extraerNumero(total));
		x=1;
			}
		else{
		total = Number(extraerNumero(total))/Number(extraerNumero($(this).val()));
		}
	});
	$("#"+inputTotal).val(extraerNumero(total));
}
function fechas(nameClass,inputTotal){
    var total = 0;
    var cont=0;
    $('.'+nameClass).each(function() {
    // if(cont==1)
    if($(this).val()==""){
        $("#"+inputTotal).val(0);
        cont=1;
    }else if(cont==1){
        $("#"+inputTotal).val(0);
    }else
        {
        var aFecha = $(this).val().split('-');
            var fFecha = Date.UTC(aFecha[0],aFecha[1]-1,aFecha[2]);
        total = fFecha-total;
        var dias = Math.floor(total / (1000 * 60 * 60 * 24));

        if(dias<0){
            alert("No valido")
            $("#"+inputTotal).val(0);
        }else{
        $("#"+inputTotal).val(dias);
        }
        }
    });
        }

function dividir2(dividendo,divisor,inputTotal){
	var total = 0;
	var v1 = $("#"+dividendo).val();
	var v2 = $("#"+divisor).val();

	total = (Number(extraerNumero(v1))) / (Number(extraerNumero(v2)));
	total = Math.ceil(extraerNumero(total));
	$("#"+inputTotal).val(extraerNumero(total));
}
function PUpromedio(nameClass,inputTotal){
	var total = 0;
	$('.'+nameClass).each(function() {
		total += Number(extraerNumero($(this).val()));
	});
	total=total/2;
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
}
function importeTotal(cantidad,precio,descuento,inputTotal,descTotal){
	var subtotal=0;
	var total = 0;
	//alert("hola")
	var cant = $("#"+cantidad).val();
	var prec = $("#"+precio).val();
	var desc = $("#"+descuento).val();
	if (desc=="") {
		desc=0;
		$("#"+descuento).val(0);
	}
	Dtotal = (Number(extraerNumero(cant))) * (Number(extraerNumero(desc)));
	dxprod = (Number(extraerNumero(prec))) - (Number(extraerNumero(desc)));
	// alert(dxprod);
	subtotal = (Number(extraerNumero(cant))) * (Number(extraerNumero(dxprod)));
	if (subtotal<0) {
    Dtotal=0;
    total=(Number(extraerNumero(cant))) * (Number(extraerNumero(prec)));
    $("#"+descuento).val(0);
	}else{
	//$("#"+descuento).val(desc);
	total=subtotal;
	if (total<0) {
		total=0;
	}
	}
	$("#"+inputTotal).val(extraerNumero(total));
	$("#"+descTotal).val(extraerNumero(Dtotal));
}

function importe(cantidad,precio,inputTotal){
	var subtotal=0;
	var total = 0;

	var cant = $("#"+cantidad).val();
	var prec = $("#"+precio).val();

	subtotal = (Number(extraerNumero(cant))) * (Number(extraerNumero(prec)));
	if (subtotal<0) {
	total=0;
	}else{
    total=subtotal;
	}
	//var totalComas=extraerNumero(total.toFixed(2))
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
	
}

function multiplicar30(cantidad,precio,inputTotal){
	var subtotal=0;
	var total = 0;

	var cant = $("#"+cantidad).val();
	var prec = $("#"+precio).val();

	subtotal = (Number(extraerNumero(cant))) * (Number(extraerNumero(prec))) *30;
	if (subtotal<0) {
	total=0;
	}else{
    total=subtotal;
	}
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
	
}

function multiplicar2(cantidad,precio,inputTotal){
	var subtotal=0;
	var total = 0;

	var cant = $("#"+cantidad).val();
	var prec = $("#"+precio).val();
	prec=(Number(extraerNumero(prec))) / 100;
	subtotal = (Number(extraerNumero(cant))) * (Number(extraerNumero(prec)));
	if (subtotal<0) {
	total=0;
	}else{
    total=subtotal;
	}
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
	
}

function multiplicar3(cantidad,precio,inputTotal,TA){
	var subtotal=0;
	var total = 0;
	var totalA=0;

	var cant = $("#"+cantidad).val();
	var prec = $("#"+precio).val();
	prec=(Number(extraerNumero(prec))) / 100;
	subtotal = (Number(extraerNumero(cant))) * (Number(extraerNumero(prec)));
	if (subtotal<0) {
	total=0;
	}else{
    total=subtotal;
	}
	totalA=total*12;
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);

	var totA=formatomonedaFM(totalA.toFixed(2));
	$("#"+TA).val(totA);
}

function Mmens(dato1,dato2,dato3,inputTotal){
	var total=0;
	var subtotal=0
	var D1 = $("#"+dato1).val();
	var D2 = $("#"+dato2).val();
	var D3 = $("#"+dato3).val();
	D3=(Number(extraerNumero(D3))) / 100;
	//alert(D1+"-"+D2+"-"+D3)
	subtotal=((Number(extraerNumero(D2)))*(Number(extraerNumero(D3))));
	total= (Number(extraerNumero(D1)))- subtotal;
	//alert(total)
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
}

function Rest(dato1,dato2,inputTotal,TA){
	var total=0;
	totalA=0;
	var D1 = $("#"+dato1).val();
	var D2 = $("#"+dato2).val();	
	total= (Number(extraerNumero(D1)))-(Number(extraerNumero(D2)));
	totalA=total*12;

	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);

	var totA=formatomonedaFM(totalA.toFixed(2));
	$("#"+TA).val(totA);
}
function rst(dato1,dato2,inputTotal){
	var total=0;
	totalA=0;
	var D1 = $("#"+dato1).val();
	var D2 = $("#"+dato2).val();	
	total= (Number(extraerNumero(D1)))-(Number(extraerNumero(D2)));
	
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
}
function evaluar(dato1,dato2,dato3,dato4,inputTotal){
	var total=0;
	var D1 = $("#"+dato1).val();
	var D2 = $("#"+dato2).val();
	var D3 = $("#"+dato3).val();
	if((Number(extraerNumero(D1)))<(Number(extraerNumero(D2)))){
	var totalC=formatomonedaFM(Number(extraerNumero(D2)).toFixed(2));
	$("#"+dato1).val(totalC);
	total= (Number(extraerNumero(D3)))-(Number(extraerNumero(D2)));
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
	$("#"+dato4).val("0.00");
	}
}
function diferencia(dato1,dato2,inputTotal,bandera){
	var total=0;
	var suma=0;
	var saldo=0;
	var residuo=0;
	var D1 = $("#"+dato1).val();
	var D2 = $("#"+dato2).val();
	var autorizado = $("#CRCAUTORIZADOIGOB").val();
	var comprometido = $("#CRCMONTOCOMPROMETIDO").val();

	if((Number(extraerNumero(D2)))<=(Number(extraerNumero(D1)))){
	total= (Number(extraerNumero(D1)))-(Number(extraerNumero(D2)));

	if((Number(extraerNumero(total)))<(Number(extraerNumero(comprometido))) && bandera==1){
		total=(Number(extraerNumero(comprometido)));
		residuo = (Number(extraerNumero(D1)))-(Number(extraerNumero(total)));
		var totalCom=formatomonedaFM(residuo.toFixed(2));
		$("#"+dato2).val(totalCom);
	}else if(bandera==2){
		//total=(Number(extraerNumero(comprometido)));
		residuo = (Number(extraerNumero(D1)))-(Number(extraerNumero(total)));
		var totalCom=formatomonedaFM(residuo.toFixed(2));
		$("#"+dato2).val(totalCom);
	}
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);

	if(bandera==1){
		saldo = (Number(extraerNumero(total)))-(Number(extraerNumero(comprometido)));
	}else if(bandera==2){
		saldo = (Number(extraerNumero(autorizado)))-(Number(extraerNumero(comprometido)));
	}
	
	var totalComasSaldo=formatomonedaFM(saldo.toFixed(2));
	$("#CRCMONTOSALDOIGOB").val(totalComasSaldo);

	}else{
	if(bandera==1){
	totalAutorizado=(Number(extraerNumero(comprometido)));
	var totalComasComprometido=formatomonedaFM(totalAutorizado.toFixed(2));
	$("#"+inputTotal).val(totalComasComprometido);
	total= (Number(extraerNumero(D1)))-(Number(extraerNumero(totalAutorizado)));
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+dato2).val(totalComas);
	saldo = (Number(extraerNumero(totalAutorizado)))-(Number(extraerNumero(comprometido)));
	}else if(bandera==2){
	var AUTIgob = Number(extraerNumero(D1));
	var totalComas=formatomonedaFM(AUTIgob.toFixed(2));
	$("#"+dato2).val(totalComas);
	$("#"+inputTotal).val("0.00");
	saldo = (Number(extraerNumero(AUTIgob)))-(Number(extraerNumero(comprometido)));
	}
	var totalComasSaldo=formatomonedaFM(saldo.toFixed(2));
	$("#CRCMONTOSALDOIGOB").val(totalComasSaldo);
	}
}

//Mmens("PLZCOSTOMANTENIMINETOMENSUAL","PLZINGRESOMENSUALMINIMO","PLZPORCENTAJECUOTAMANTO","PLZMANTOMENSUALGHR");

function cambio(total,efectivo,inputTotal){
	var totalc = 0;
	var importe = $("#"+total).val();
	var efect = $("#"+efectivo).val();
	totalc = (Number(extraerNumero(efect))) - (Number(extraerNumero(importe)));
// alert(totalc);
	if (totalc<0) {
		totalc=0;
	}
	
	$("#"+inputTotal).val(extraerNumero(totalc.toFixed(2)));
}
function cambioVR(total,efectivo,inputTotal){
	var totalc = 0;
	var importe = $("#"+total).val();
	var efect = $("#"+efectivo).val();
	totalc = (Number(extraerNumero(efect))) - (Number(extraerNumero(importe)));
// alert(totalc);
	if (totalc<0) {
		totalc=0;
	}
	
	$("#"+inputTotal).html("<b style='color: #4999de;'>Cambio:</b> <b style='color:#2067a4;'>$"+extraerNumero(totalc.toFixed(2))+"</b>");
}
function impuesto(costo,tiva,inputTotal){
	
	var cost = $("#"+costo).val();	
	var Civa = $("#"+tiva+" option:selected").text();
	var res = Civa.split("/");
	var iva = Number(res[1]);
	//alert(cost);
	//alert(iva);
	
	var total = ((Number(extraerNumero(cost))*Number(extraerNumero(iva))) + Number(extraerNumero(cost)));
	//alert(total);

	$("#"+inputTotal).val(extraerNumero(total.toFixed(2)));
}

function impuesto2(can,pre,tiv,importesd,inputTotal){
	//var total = 1;
	var cantidad = $("#"+can).val();
	var precio = $("#"+pre).val();	
	var Civa = $("#"+tiv+" option:selected").text();
	var res = Civa.split("/");
	var iva = Number(res[1]);
	
	var t1 = Number(extraerNumero(cantidad))*Number(extraerNumero(precio));

	var t2 = Number(extraerNumero(t1))*Number(extraerNumero(iva));
	var total = Number(extraerNumero(t1))+Number(extraerNumero(t2));
	$("#"+importesd).val(extraerNumero(t1.toFixed(2)));
	$("#"+inputTotal).val(extraerNumero(total.toFixed(2)));
}

function validarMenor(valor,cantidad){
	var valorD = Number(extraerNumero($("#"+valor).val()));
	var cantidadD =Number(extraerNumero($("#"+cantidad).val())); 

	if(cantidadD < valorD){
		return true;
	}
}

function preciolista(civa,flete,gastoO,porcentaje,inputTotal){
	var total=0;
	var civa=$("#"+civa).val();
	var flete=$("#"+flete).val();
	var gastoO=$("#"+gastoO).val();
	var porcentaje=$("#"+porcentaje).val();
	var fleteI=(100-Number(extraerNumero(flete)))/100;
	var gastoOI=(100-Number(extraerNumero(gastoO)))/100;
	var porcentajeI=(100-Number(extraerNumero(porcentaje)))/100;
	total=((((Number(extraerNumero(civa)))/(Number(extraerNumero(fleteI))))/(Number(extraerNumero(gastoOI))))/(Number(extraerNumero(porcentajeI))));
	var totalComas=formatomonedaFM(total.toFixed(2));
	$("#"+inputTotal).val(totalComas);
}

function formatomonedaFM(atributo){
	var coin1,coin2,coin3,coin4,coin5;
	coin1 = atributo;
	coin2 = extraerNumero(coin1);
	if (!isNaN(coin2) && coin2 !="") {
		coin3 = formatCurrency(coin2);
		coin4 = replaceAll(coin3,'$','');
		return coin4;
	}
}
function reglaT(monto,importeTotal,inputTotal){
	var subtotal=0;
	var total=0;
	var montoTotal = $("#"+monto).val();
	var importe = $("#"+importeTotal).val();

	subtotal = ((Number(extraerNumero(montoTotal))) * 100) / (Number(extraerNumero(importe)));
	var totalComas=formatomonedaFM(subtotal.toFixed(2));
	$("#"+inputTotal).val(totalComas);
	/*if (subtotal<0) {
	total=0;
	}else{
    total=subtotal;
	}*/
	
}
/*function formatCurrency(total) {
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
}*/

/*function fechas(nameClass,inputTotal){
    var total = 0;
	$('.'+nameClass).each(function() {
        var aFecha = $(this).val().split('-');
            var fFecha = Date.UTC(aFecha[0],aFecha[1]-1,aFecha[2]);
        total = fFecha-total;
        var dias = Math.floor(total / (1000 * 60 * 60 * 24));
        $("#"+inputTotal).val(dias);
    });
    }*/

/*function myTotal(nameClass,inputTotal,operacion){

	switch(operacion){
	case 'multiplicar':
	var total = 1;
	$('.'+nameClass).each(function() {
		total = Number(total)*Number($(this).val());
	});
	$("#"+inputTotal).val(total);
	break;
	case 'sumar':
	var total = 0;
	$('.'+nameClass).each(function() {
		total += Number($(this).val());
	});
	$("#"+inputTotal).val(total);
	break;
	case 'restar':
	var total = 0;
	var x=0;

	$('.'+nameClass).each(function() {
		if(x==0){
		total = ($(this).val())-(total);
		x=1;
	}
	else
	{
		total = (total)-($(this).val());
	}
	});
	$("#"+inputTotal).val(total);
	break;
	case 'dividir':
	var total = 1;
	var x=0;

	$('.'+nameClass).each(function() {
		if (x==0) {
		total = Number($(this).val())/Number(total);
		x=1;
			}
		else{
		total = Number(total)/Number($(this).val());
		}
	});
	$("#"+inputTotal).val(total);
	break;
}
}*/
