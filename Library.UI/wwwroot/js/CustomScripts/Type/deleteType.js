﻿$(document).ready(function () {

    $('#btnDelete').click(function (e) {
        debugger;
        e.preventDefault();
        var request = {};
        request.Id = $('#btnDelete').data('id');
        CallAjaxWithToken('https://localhost:44341/DeleteType', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Type/List';

        });
    });
});