$(document).ready(function () {

    $('#authorForm').submit(function (e) {
        debugger;
        e.preventDefault();
        var name = $('#txtAuthorName').val();
        var request = {};
        request.Id = $('#btnUpdate').data('id');
        request.Name = name;
        CallAjaxWithToken('https://localhost:44341/UpdateAuthor', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Author/List';

        });
    });
});