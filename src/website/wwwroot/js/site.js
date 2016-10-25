
var Page = {

    Init: function () {

        $('.date').datepicker();

        $('.switchdiv').click(function (e) {
            e.preventDefault();
            var userId = $(this).attr('data-userid');
            var div_toShow = '#' + $(this).attr('data-show');
            var div_toHide = '#' + $(this).attr('data-hide');
            $(div_toShow).show();
            $(div_toHide).hide();
        });
    }
}

$(document).ready(function () {
    Page.Init();

});
