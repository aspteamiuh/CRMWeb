jQuery(function($){
	
	$(document).ready(function() {
		
		jQuery('.counter-item').appear(function() {
			jQuery('.counter-number').countTo();
			jQuery(this).addClass('funcionando');
			console.log('funcionando');
		});
		
		var $window = $(window),
		$body = $('body');		
		
		$window.scroll(function(){
			$('#site-header-menu').removeClass('toggled-on');
		});
		
		$('#site-header-menu').scroll(function() {
			 $('#site-header-menu').addClass('toggled-on');
		});
		
	}); 
	
});
