$(document).ready(function () {

    $('#createTypeForm').submit(function (e) {
        e.preventDefault();
        var name = $('#txtType').val();
        var request = {};
        request.Name = name;
        CallAjaxWithToken('https://localhost:44341/CreateType', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Type/List';

        });
    });
});