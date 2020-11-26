$(document).ready(function () {

    $('#createAuthorForm').submit(function (e) {
        e.preventDefault();
        var name = $('#txtAuthorName').val();
        var request = {};
        request.Name = name;
        CallAjaxWithToken('https://localhost:44341/CreateAuthor', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Author/List';

        });
    });
});