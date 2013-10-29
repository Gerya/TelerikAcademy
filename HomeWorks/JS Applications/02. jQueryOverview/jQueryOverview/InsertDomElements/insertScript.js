$(function () {
    $("#js-before").on('click', prev);
    $("#js-after").on('click', next);

    function next() {
        $('#js-main').after('<div class="after box"></div>');
    }

    function prev() {
        $('#js-main').before('<div class="before box"></div>');
    }
});