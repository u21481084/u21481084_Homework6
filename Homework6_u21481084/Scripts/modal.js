$(function () {
    $.ajaxSetup({ cache: false });
    $("a[data-modal]").on("click", function (e) {
        $('#ModalxContent').load(this.href, function () {
            $('#Modalx').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {
    $('form', dialog).submit(function () {

        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#Modalx').modal('hide');

                    window.location.reload();
                } else {

                    $('#ModalxContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}