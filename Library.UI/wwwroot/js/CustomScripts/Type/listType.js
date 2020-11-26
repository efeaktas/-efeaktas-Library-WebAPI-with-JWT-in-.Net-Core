$(document).ready(function () {
    CallAjaxWithToken('https://localhost:44341/ListType').done(function (response) {
        $.unblockUI();
        for (var i = 0; i < response.length; i++) {
            var type = '<tr><td>' + response[i].name + '</td> <td><a id="btnUpdate" data-id="' + response[i].id + '" href="/Type/Update?id=' + response[i].id + '&name=' + response[i].name + '" class="btn btn-success sm">Düzenle</a></td></tr > ';
            $('#bodyType').append(type);
        }

    });
});