(function ($) {
    $(function () {
        $('a.button, input:submit, button').each(function () {
            var opts = {};
            var icon = $(this).attr("data-icon");
            if (icon) {
                opts.text = false;
                opts.icons = {
                    primary: "ui-icon-" + icon
                };
            }
            if ($(this).attr("data-text")) {
                opts.text = true;
            }
            $(this).button(opts);
        });

        $('a.confirm').live('click', function () {
            // Create the confirm dialog on-demand
            var href = $(this).attr('href');
            var msg = $(this).attr('data-msg-confirm');
            $('<div class="dialog" title="Confirm">' + msg + '</div>').appendTo('body').dialog({
                modal: true,
                resizeable: false,
                close: function () { $(this).remove(); },
                buttons: [
                    {
                        text: "Yes, I'm sure",
                        click: function () {
                            $(this).dialog('close');
                            window.location.href = href;
                        }
                    },
                    {
                        text: "No, I'm not sure",
                        click: function () {
                            $(this).dialog('close');
                        }
                    }
                ]
            });
            return false;
        });
    });
})(jQuery);