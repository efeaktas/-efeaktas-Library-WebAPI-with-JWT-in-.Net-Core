$(document).ready(function () {
    CallAjaxWithToken('https://localhost:44341/ListBook').done(function (response) {
        $.unblockUI();
        for (var i = 0; i < response.length; i++) {
            debugger;
            var book = '<tr><td>' + response[i].bookName + '</td><td>' + response[i].typeName + '</td><td>' + response[i].authorName + '</td> <td><a id="btnUpdate" data-id="' + response[i].id + '" href="/Book/Update?id=' + response[i].id + '&name=' + response[i].bookName +'" class="btn btn-success sm">Düzenle</a></td></tr > ';
            $('#bookBody').append(book);
        }

    });
});