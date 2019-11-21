// JavaScript Document
$(document).ready(function(){	
	/*$('#header').affix({
				offset: {
					top: $('#header').height()
				}
	});*/


if ($('#sidebar-nav').length)
	{
	$('#sidebar-nav').affix({
			offset: {     
				top: $('#sidebar-nav').offset().top,
				bottom: ($('#footer').outerHeight(true) + $('.stay-in-touch').outerHeight(true))
			}
	});
}



if ($('#filter-bar').length)
{
$('.filter-bar').affix({	
	offset: {     
				top: $('.filter-bar').offset().top				
			}		
	});	
}

var fheight = $('.filter-bar').height();
$('.sticky-placeholder').css('height',fheight);




$(".vdo-popup").on('hidden.bs.modal', function (e) {
    $(".vdo-popup iframe").attr("src", $(".vdo-popup iframe").attr("src"));
});

$('body').prepend('<a href="javascript:void();" class="back-to-top" title="Back to Top"><i class="fa fa-angle-double-up"></i></a>');
var amountScrolled = 300;
$(window).scroll(function() {
	if ( $(window).scrollTop() > amountScrolled ) {
		$('a.back-to-top').fadeIn('slow');
	} else {
		$('a.back-to-top').fadeOut('slow');
	}
});
$('a.back-to-top').click(function() {
	$('html, body').animate({
		scrollTop: 0
	}, 1000);
	return false;
});


var owl = $('.mntr-vdo-carousel.owl-carousel');
	owl.owlCarousel({
		loop: false,
		mouseDrag: false,
		margin:10,
		dots: false,
		items:3,
		nav:true,
		slideBy:3,
		responsive: {
		0: {
			items: 1,			
			mouseDrag: true
		},
		480: {
			items: 2,			
			mouseDrag: true
		},
		767: {
			items: 3,			
			mouseDrag: true
		},
		991: {
			items: 3,						
			mouseDrag: true
		}
		}
	});	
	

var owl = $('.mentor-carousel.owl-carousel');
	owl.owlCarousel({
		loop: true,
		mouseDrag: false,
		dots: false,
		nav:true,
		margin: 10,    
		items: 4,
		responsive: {
		0: {
			items: 1,
			center: true,
			loop: true,
			stagePadding: 50,
			mouseDrag: true
		},
		480: {
			items: 2,
			center: true,
			loop: true,
			mouseDrag: true
		},
		767: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 60,
			mouseDrag: true
		},
		991: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 100,
			mouseDrag: true
		},
		1024: {
			items: 4
		}
		}
	});	
	

	var owl = $('#home-slider.owl-carousel');
	owl.owlCarousel({
		loop: false,
		mouseDrag: false,
	//	center:true,
		dots: true,
		autoplay:true,
		smartSpeed:800,
    autoplayTimeout:5000,
		items: 1,
		responsive: {
		0: {
			dots: false
		},
		767: {
			dots: true
		}
		}
	});	
	var owl = $('.start-ups-slider.owl-carousel');
	owl.owlCarousel({
		loop: true,
	//	center:true,
		dots: false,
		mouseDrag: false,
		autoplay:true,
		smartSpeed:800,
    autoplayTimeout:5000,
		items: 1,
		nav:true,
	});	
	
	var owl = $('.carousel-sidebar.owl-carousel');
	owl.owlCarousel({
		loop: true,
		mouseDrag: false,
		animateOut: 'slideOutUp',
  	animateIn: 'slideInUp',
		dots: false,
		items: 1,
		nav:true
	});	
	
	var owl = $('.upcomin-events.owl-carousel');
	owl.owlCarousel({
		loop: true,
		mouseDrag: false,
		dots: false,
		nav:true,
		margin: 10,    
		items: 4,
		responsive: {
		0: {
			items: 1,
			center: true,
			loop: true,
			stagePadding: 50,
			mouseDrag: true
		},
		480: {
			items: 2,
			center: true,
			loop: true,
			mouseDrag: true
		},
		767: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 60,
			mouseDrag: true
		},
		991: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 100,
			mouseDrag: true
		},
		1024: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 100,
			mouseDrag: true
		}
		}
	});	
	
	var owl = $('.webinar-carousel.owl-carousel');
	owl.owlCarousel({
		loop: true,
		mouseDrag: false,
		dots: false,
		nav:true,
		margin: 10,    
		items: 4,
		responsive: {
		0: {
			items: 1,
			center: true,
			loop: true,
			stagePadding: 50,
			mouseDrag: true
		},
		480: {
			items: 2,
			center: true,
			loop: true,
			mouseDrag: true
		},
		767: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 60,
			mouseDrag: true
		},
		991: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 100,
			mouseDrag: true
		},
		1024: {
			items: 3,
			center: true,
			loop: true,
			stagePadding: 100,
			mouseDrag: true
		}
		}
	});	
	$('[data-toggle="tooltip"]').tooltip();
	
	$('.toggle-btn').click(function(e){ 
		e.stopPropagation();
		$('#navbar').show().toggleClass('open');
		$('.toggle-btn').toggleClass('active');
		$('body').toggleClass('no-scroll');
		$('.bg-overlay').toggleClass('active');
	});
	$('.bg-overlay').click(function(){ 
		$('body').removeClass('no-scroll');
		$('.toggle-btn, .bg-overlay').removeClass('active');
		$('#navbar').removeClass('open');
	});
	
	$('.filter-trigger').click(function(){ 
		$(this).toggleClass('active');
		$('.filter-form .data-table').slideToggle();
	});
	
	//~ $('.date').datetimepicker({
		//~ format: 'LL'
	//~ });
	$('.selectpicker').selectpicker({
  	multipleSeparator:""
	});


	// Event Slider
	var owl = $('.event-slide.owl-carousel');
	owl.owlCarousel({
		loop: true,
		mouseDrag: false,
		dots: false,
		smartSpeed:800,
		items:1,
		nav:true
	});	

var owl = $('#schrdule_cal');
	owl.owlCarousel({
		loop: false,
		dots: false,
		items:7,
		mouseDrag: false,
		slideBy:7,
		smartSpeed: 150,
		nav:true
	});
		
	 $('[data-toggle="tooltip"]').tooltip();
	 $('[data-toggle="popover"]').popover();
	 
	 
	 
	 
	 
	 
	 $('#add_more').click(function(){
		$('.delete_row').show();
		var $clone;
		var $len = $('#eduDiv').find('.row').length;
		if($len==5)
		return;
		
		
		$clone= $('#eduDiv').find('.row:last').clone();
		//$clone.append('<div class="col-sm-2 form-group form-group-lg"> <label>&nbsp;</label><button type="button" class="btn btn-sm btn-primary delete_row">Delete</button></div>');
		
		
		 $clone.find('.bootstrap-select').replaceWith(function() { return $('select', this); });
		$clone.find('select option').removeAttr('selected');
		//$clone.find('select').selectpicker();
		
		$clone.find('input,textarea').val('');
		$clone.find('.other_input_box').remove();
		$clone.find('select').selectpicker('refresh');
		$clone.appendTo($('#eduDiv'));
		
		//$('#eduDiv').find('select').selectpicker();
	});
	
	$('#eduDiv').on('click','.delete_row',function(){	
		var $count = $('#eduDiv').find('.delete_row').length;
		console.log($count);
		if($count<=2)
		{
			$('.delete_row').hide();
		}
		if($count>1)
		$(this).parent().parent().remove(); 
	});
		 
	$('.more').readmore({
		speed: 500,
		moreLink: '<a href="#" class="btn-collapse">Read More <span class="glyphicon glyphicon-menu-down"></span></a>',
		lessLink: '<a href="#" class="btn-collapse">Read Less <span class="glyphicon glyphicon-menu-up"></span></a>',
		collapsedHeight: 110
	});
});


// Custom Upload Button
(function(e,t,n){var r=e.querySelectorAll("html")[0];r.className=r.className.replace(/(^|\s)no-js(\s|$)/,"$1js$2")})(document,window,0);

/*
	By Osvaldas Valutis, www.osvaldas.info
	Available for use under the MIT License
*/



