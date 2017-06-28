jQuery(document).ready(function ($) {
	//	Square images
	squareImages();
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