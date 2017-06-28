jQuery(document).ready(function ($) {
	//	Cart
	$('.top-head .show-cart-button').click(function () {
		event.preventDefault();
		$('.top-head-hidden').slideToggle(400);
	})

	//	Close cart button
	$('.top-head-hidden .basket .close-basket').click(function () {
		event.preventDefault();
		$('.top-head-hidden').slideUp(400);
	});

	//	Mobile menu
	$(".menu-button").click(function () {
		event.preventDefault();
		$("ul.mobile-menu").slideToggle(400);
	});

	//	Left-bar (Mobile)
	$('.toggle-button').click(function(){
		$('.mega-wrapper').toggleClass('open');
	});

	//	Input labels manipulation
	$(".input-wrap input").keyup(function () {
		if ($(this).val().length != 0) {
			$(this).parents(".form-group").addClass("unicue");
		}
		else {
			$(this).parents(".form-group").removeClass("unicue");
		}
	});
});