$(document).ready(function () {

    $('#btnDelete').click(function (e) {
        debugger;
        e.preventDefault();
        var request = {};
        request.Id = $('#btnDelete').data('id');
        CallAjaxWithToken('https://localhost:44341/DeleteBook', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Book/List';

        });
    });
});