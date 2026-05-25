function miResize(){
	anchoContainer= $('.panel-fixed-primary').width();
	$('.panel-fixed-block').attr('style', 'width:'+anchoContainer+'px;');
	if ( $(window).scrollTop() > $('.panel-fixed-primary').offset().top){
		$('.panel-fixed-block').show();
	}else{
		$('.panel-fixed-block').hide();
	}
}

var anchoContainer= $('.panel-fixed-primary').width();
var alturaform = $('.panel-fixed-primary').offset().top;
	
$(document).ready(function() {
	// var altura = $('.menuarriba').offset().top;
	var id_Resize;
	$(window).on('scroll', function(){
		console.clear();
		console.log($(window).scrollTop()+' - '+$('.panel-fixed-primary').offset().top);
		if ( $(window).scrollTop() > $('.panel-fixed-primary').offset().top){
			$('.panel-fixed-block').html($('.panel-fixed-heading').html());
			$('.panel-fixed-block').addClass('menu-fixed2');
			$('.panel-fixed-block').attr('style', 'width:'+anchoContainer+'px;');
			$('.panel-fixed-block').show();
		} else {
			$('.panel-fixed-block').hide();
			$('.panel-fixed-block').removeClass('menu-fixed2');
			$('.panel-fixed-block').html('');
		}
	});	

	$(window).resize(function() {
		clearTimeout(id_Resize);
    	id_Resize = setTimeout(miResize(),500);
	});

});
