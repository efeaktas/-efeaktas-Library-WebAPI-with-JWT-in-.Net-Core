$(document).ready(function () {
    CallAjaxWithToken('https://localhost:44341/ListAuthor').done(function (response) {
        $.unblockUI();
        for (var i = 0; i < response.length; i++) {
            var author = '<option class="optionValue" data-id="'+response[i].id+'">'+response[i].name+'</option>';
                $('#selectAuthor').append(author);
        }

    });
    CallAjaxWithToken('https://localhost:44341/ListType').done(function (response) {
        $.unblockUI();
        for (var i = 0; i < response.length; i++) {
            var type = '<option class="optionValue" data-id="' + response[i].id + '">' + response[i].name + '</option>';
            $('#selectType').append(type);
        }

    });

    $('#bookForm').submit(function (e) {
        debugger;
        e.preventDefault();
        var authorId = $('#selectAuthor').children("option:selected").data('id');
        var typeId = $('#selectType').children("option:selected").data('id');
        var bookName = $('#txtBookName').val();


        var request = {};
        request.AuthorId = authorId;
        request.TypeId = typeId;
        request.Name = bookName;
        CallAjaxWithToken('https://localhost:44341/CreateBook', request).done(function (response) {
            $.unblockUI();
            window.location.href = '/Book/List';
        });
    });

});