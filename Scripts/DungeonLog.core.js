(function($) {
    $(function() {
        $('a.button').each(function() {
            var opts = {};
            var icon = $(this).attr("data-icon");
            if(icon) {
                opts.text = false,
                opts.icons = {
                    primary: "ui-icon-" + icon
                };
            }
            $(this).button(opts);
        });
    });
})(jQuery);