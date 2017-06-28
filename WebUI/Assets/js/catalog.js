jQuery(document).ready(function ($) {
	//	Square images
    squareImages();
    //  Fix searcbox size 
    fixSearchBoxSize();

    //  Sorting
    $("#sorting-list").on("change", function () {
        var value = $(this).val();
        SearchAndSort(value, "");
    });

    //  Search
    $("#searchBox form").on("submit", function () {
        event.preventDefault();
        var sVal = $(this).find("input").val();
        var oVal = $.cookie("sortingState");
        SearchAndSort(oVal, sVal);
    });

    //	    Grid/List
    //  Checking
    checkViewType();
    //  Toogle
	$('.product-list .list-view-button').click(function () {
		event.preventDefault();
		$('.product-list .view-type').addClass('items-list');

		$('.product-list .grid-view-button').removeClass('active');
		$('.product-list .list-view-button').addClass('active');

        localStorage.viewType = "list";
	});
	$('.product-list .grid-view-button').click(function () {
		event.preventDefault();
		$('.product-list .view-type').removeClass('items-list');

		$('.product-list .list-view-button').removeClass('active');
		$('.product-list .grid-view-button').addClass('active');

		localStorage.viewType = "grid";
	});
});

$(window).resize(function() {
	//	Square images
	squareImages();
    //  Fix searcbox size
    fixSearchBoxSize();
});

function squareImages() {
    var items = $(".items .image");
    var itemsWidth = items.width();

    items.height(itemsWidth);
};

function fixSearchBoxSize() {
    if ($(window).width() > 480) {
        var searchBox = $("#searchBox");
        var parentWidth = searchBox.parent().outerWidth();
        var siblingsWidth = 0;
        searchBox.siblings().each(function() {
            siblingsWidth += $(this).outerWidth(true);
        });
        searchBox.outerWidth(parentWidth - siblingsWidth - 40);
    }
};

function checkViewType() {
    var viewType = localStorage.viewType;

    switch (viewType) {
        case "list":
            $('.product-list .view-type').addClass('items-list');
            $('.product-list .grid-view-button').removeClass('active');
            $('.product-list .list-view-button').addClass('active');
            break;
        case "grid":
            $('.product-list .view-type').removeClass('items-list');
            $('.product-list .list-view-button').removeClass('active');
            $('.product-list .grid-view-button').addClass('active');
            break;
    }
};