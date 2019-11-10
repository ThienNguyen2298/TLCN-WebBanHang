var loginController = function () {
    this.initialize = function () {
        registerEvent();
    }
    var registerEvent = function () {
        $('#btnLogin').on('click', function (event) {
            event.preventDefault();
            var user = $('#txtUserName').val();
            var pass = $('#txtPassword').val();
            login(user, pass);
        })
    }
    var login = function (user, pass) {
        $.ajax({
            type: 'POST',
            data: {
                UserName: user,
                Password: pass
            },
            dataType: 'json',
            url: "/Admin/Login/Authen",
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Admin/Admin/Index"
                }
                else {
                    shop.notify("Đăng nhập không đúng!", 'error');
                }
            }
        })
    }
}