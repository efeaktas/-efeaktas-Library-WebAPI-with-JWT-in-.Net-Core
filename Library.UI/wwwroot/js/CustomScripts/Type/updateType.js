$(document).ready(function () {

    $('#typeForm').submit(function (e) {
        debugger;
        e.preventDefault();
        var name = $('#txtType').val();
        var request = {};
        request.Id = $('#btnUpdate').data('id');
        request.Name = name;
        CallAjaxWithToken('https://localhost:44341/UpdateType', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Type/List';

        });
    });
});