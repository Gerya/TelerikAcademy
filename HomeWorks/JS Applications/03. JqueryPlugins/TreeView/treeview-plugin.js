/// <reference path="Scripts/jquery-2.0.2.min.js" />
/// <reference path="Scripts/jquery-ui-1.10.3.custom.min.js" />

$.widget("myctrls.TreeView", {
    options: {
        collapsed: true,
        toggle: null
    },
    _create: function () {
        var self = this;

        if (self.options.collapsed) {
            this.element.children("ul").click(function (event) {
                var $target = $(event.target);

                if ($target.is("a")) {
                    $target.parent().children("ul").toggle();

                    if (self.options.toggle != null) {
                        self.options.toggle($target);
                    }
                }
            });
        }
    }
});