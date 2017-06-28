jQuery(document).ready(function ($) {
	//	Square images
	squareImages();

	//	Init BX Slider
	$('.bxslider').bxSlider({
		pager : false,
		controls : false,
		auto : true
	});
});

$(window).resize(function() {
	//	Square images
	squareImages();
});

function squareImages () {
	var items = $(".items .image");
	var itemsWidth = items.width();

	items.height(itemsWidth);
}