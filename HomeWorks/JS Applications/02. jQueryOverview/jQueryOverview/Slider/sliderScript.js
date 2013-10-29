$(document).ready(function () {

    var Slider = {
        init: function (selector) {
            this.selector = selector;
            this.sliderContent = [];
        },
        render: function () {
            for (var j = 0, len = this.sliderContent.length; j < len; j++) {
                if (j == 0) {
                    $(this.selector).append('<div class="current first"> ' + this.sliderContent[j] + '</div>');
                } else if (j == len - 1) {
                    $(this.selector).append('<div class="previous last"> ' + this.sliderContent[j] + '</div>');
                } else {
                    $(this.selector).append('<div class="previous"> ' + this.sliderContent[j] + '</div>');
                }
            }
        },
        addContent: function (content) {
            if (arguments.length > 1) {
                for (var i = 0; i < arguments.length; i++) {
                    this.sliderContent.push(arguments[i]);
                }
            }
            this.sliderContent.push(content);
        }
    };

    var theSlider = Object.create(Slider);
    theSlider.init('#slider');
    theSlider.addContent("<h3>Lady</h3><img src='/Slider/img/lady.jpg'>");
    theSlider.addContent("<h2>H2 Title1</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>");
    theSlider.addContent("<h2>H2 Title1</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>");
    theSlider.addContent("<h2>H2 Title2</h2><div>Lorem ipsum dolor sit amet <ul><li>list item</li><li>list item2</li></ul></div>",
                    "<h2>H2 Title3</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                    "<h2>H2 Title4</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                    "<h2>H2 Title5</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                    "<img src='/Slider/img/IMG_2659jm.jpg'><h4>Strawberries and cream muffins</h4>");
    theSlider.render();

    $("#left-arrow").on('click', prev);
    $("#right-arrow").on('click', next);

    function next() {
        var curContent = $('.current');
        var nextContent = curContent.next();
        if (nextContent.length == 0)
            nextContent = $('#slider .first');

        curContent.removeClass('current').addClass('previous');
        nextContent.hide().removeClass('previous').slideDown('slow').addClass('current');
    }

    function prev() {
        var curContent = $('.current');
        var prevContent = curContent.prev();
        if (prevContent.length == 0)
            prevContent = $('#slider .last');
        curContent.removeClass('current').addClass('previous');
        prevContent.hide().removeClass('previous').slideDown('slow').addClass('current');
    }
    setInterval(next, 5000);

    $("#left-arrow").on('mousedown', function () {
        $("#left-arrow").css({ "border-top-color": "#1b435e;", 'background': '#1b435e;' });
    });
    $("#left-arrow").on('mouseup', function () {
        $("#left-arrow").css({ "border-top-color": "#1b435e;", 'background': '#1b435e;' });
    });
    $("#right-arrow").on('mousedown', function () {
        $("#right-arrow").css({ "border-top-color": "#1b435e;", 'background': '#1b435e;' });
    });
    $("#right-arrow").on('mouseup', function () {
        $("#right-arrow").css({"border-top-color": "#1b435e;",'background': '#1b435e;'});
    });
});
