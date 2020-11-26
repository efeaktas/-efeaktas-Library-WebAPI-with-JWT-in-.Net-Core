$(document).ready(function () {
    CallAjaxWithToken('https://localhost:44341/ListAuthor').done(function (response) {
        $.unblockUI();
        for (var i = 0; i < response.length; i++) {
            var author = '<tr><td>' + response[i].name + '</td> <td><a id="btnUpdate" data-id="' + response[i].id + '" href="/Author/Update?id=' + response[i].id + '&name=' + response[i].name + '" class="btn btn-success sm">Düzenle</a></td></tr > ';
            $('#bodyAuthor').append(author);
        }

    });
});