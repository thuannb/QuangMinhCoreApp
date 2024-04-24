var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        //validate form
        $('#frmLogin').validate({
            errorClass: 'red',
            ignore: [],//dua danh sach id khong can validate
            lang: 'vi',
            rules: {
                //Theo name cua html
                userName: {
                    required: true
                    //Co the them max-lenght....
                },
                password: {
                    required: true
                }
            }
        });

        $('#btnLogin').on('click', function (event) {
            event.preventDefault();
            var userName = $('#txtUserName').val();
            var password = $('#txtPassword').val();

            login(userName, password);
        })
    }

    var login = function (userName, password) {
        $.ajax({
            type: 'POST',
            dataType:'json',
            url:'/admin/login/authen',
            data: {
                Email: userName,
                Password: password
            },
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Admin/Home/Index";
                }
                else {
                    kbstar.notify('Login failed', 'error');
                }
            }
        })
    }
}