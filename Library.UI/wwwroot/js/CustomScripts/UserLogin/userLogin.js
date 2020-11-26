$(document).ready(function () {

    $('#loginForm').submit(function (e) {
        e.preventDefault();
        var email = $('#txtEmail').val();
        var password = $('#txtPassword').val();
        var request = {};
        request.Email = email;
        request.Password = password;

        CallAjax('https://localhost:44341/UserLogin', request).done(function (response) {
            debugger;
            $.unblockUI();
            localStorage.setItem('token', response.token);
             window.location.href = '/Book/List';
         
        });
    });
});