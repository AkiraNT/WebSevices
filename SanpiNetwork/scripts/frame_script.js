$(document).ready(function () {

    $('.li_not').show();
    $('.li_user').hide();
    let isAuth = localStorage.getItem("IsAuthentication");
    if (isAuth == undefined || isAuth == null)
        isAuth = false;
    if (isAuth === true || isAuth === 'true') {
        $('.li_not').hide();
        $('.li_user').show();
        const jsonData = localStorage.getItem("Profile");
        if (jsonData == undefined || jsonData == '')
            return;
        const obj = JSON.parse(jsonData);
        if (obj == undefined || obj == null)
            return;
        //----------------------------------------
        $('.userName').text(obj.FullName);

        //----------------------------------------
        if (typeof (obj.TotalPI) != 'undefined')
            $(".total-pi").text(obj.TotalPI);

        //----------------------------------------
        if (typeof (obj.BalancePI) != 'undefined')
            $(".sodu-pi").text(obj.BalancePI);

        //----------------------------------------
        if (typeof (obj.DepositPI) != 'undefined')
            $(".dachi-pi").text(obj.DepositPI);
    }
    $window_width = $(window).width();
    
    function resize_sreen() {
        if ($("#container").length) {
            var $height_sreen = $(window).outerHeight();
            var $height_header = $("#header").outerHeight();
            var $height_footer = $("#footer").outerHeight();
            $("#container").css({
                "min-height": Number($height_sreen) - Number($height_header) - Number($height_footer) + "px"
            });
        }
        if ($("#wrap_form").length) {
            var $height_sreen_2 = $(window).outerHeight();
            $("#wrap_form").css({
                "min-height": Number($height_sreen_2) + "px"
            });
        }
    }
    $(window).resize(function () {
        resize_sreen();
    });
    $(window).load(function () {
        resize_sreen();
    });
    $(".dkbtc").click(function () {
        var answer = confirm("Bạn chưa đăng nhập hoặc phải đăng ký tài khoản mới có thể sử dụng tính năng này..!");
        if (answer) {
            window.location = "login.html";
        }
    });
    $(".icon_menu_mobile").click(function (e) {
        $val = $(".icon_menu_mobile").attr("val");
        if ($val == 0) {
            $(".menu_mobile").attr("style", "visibility: visible;");
            $(this).attr("val", 1);
            $('body').attr("class", "ad_body");
        }
    });
    $(".close_menu_mobile").click(function () {
        $(".menu_mobile").removeAttr("style");
        $(".icon_menu_mobile").attr("val", 0);
        $('body').removeAttr("class");
    });
    $(".btn_login").click(function (e) {
        e.preventDefault();
        const $serializeArray = $("form").serializeArray();
        let isValid = false;
        $serializeArray.forEach(function (item) {
            if (item.value == '')
                isValid = true;
        });
        if (isValid) {
            alert("Vui lòng điền thông tin đăng nhập!");
            return;
        }
        const bodyData = {
            Email : $('input[name="email"]').val(),
            Password : $('input[name="pass"]').val()
        };
        $.ajax({
            type: "POST",
            url: "/api/v1/Account/SignIn",
            headers: {
                'Accept-Language': 'vi',
                'Content-Type': 'application/json'
            },
            success: function (data) {
                if (data == undefined) {
                    alert("Hệ thống bảo trì!");
                    return;
                }
                if (data.Status != 1) {
                    alert(data.Message);
                    return;
                }
                localStorage.setItem("IsAuthentication", true);
                localStorage.setItem("Profile", JSON.stringify(data.Items));
                window.location = "dashboard.html";
            },
            error: function (error) {
                console.log(error)
            },
            async: true,
            data: JSON.stringify(bodyData),
            cache: false,
            contentType: false,
            processData: false,
            timeout: 60000
        });
    });
    $(".btn_register").click(function (e) {
        e.preventDefault();
        const $serializeArray = $("form").serializeArray();
        let isValid = false;
        $serializeArray.forEach(function (item) {
            if (item.value == '')
                isValid = true;
        });
        if (isValid) {
            alert("Vui lòng điền đầy đủ thông tin!");
            return;
        }
        const bodyData = {
            FullName : $('input[name="ten"]').val(),
            Email : $('input[name="email"]').val(),
            Phone : $('input[name="dt"]').val(),
            Password : $('input[name="pass"]').val(),
            Password2 : $('input[name="repass"]').val()
        };
        $.ajax({
            type: "POST",
            url: "/api/v1/Account/Register",
            headers: {
                'Accept-Language': 'vi',
                'Content-Type': 'application/json'
            },
            success: function (data) {
                if (data == undefined) {
                    alert("Hệ thống bảo trì!");
                    return;
                }
                if (data.Status != 1) {
                    alert(data.Message);
                    return;
                }
                var answer = confirm("Đăng ký tài khoản thành công!");
                if (answer)
                    window.location = "login.html";
                return;
            },
            error: function (error) {
                console.log(error)
            },
            async: true,
            data: JSON.stringify(bodyData),
            cache: false,
            contentType: false,
            processData: false,
            timeout: 60000
        });
    });
    $('.btn_logout').click(function (e) {
        e.preventDefault();
        localStorage.setItem("IsAuthentication", false);
        window.location = "index.html";
    });
    $('.btn_forgot').click(function (e) {
        alert("Vui lòng kiểm tra email!");
    });
    //----------------------------------------
    $('.in-buy-qty').change(function () {
        const qty = parseInt($(this).val());
        if (isNaN(qty) || qty <= 0) {
            $(".um-buy-pi").text("0");
            return;
        }
        const rate = parseInt($(".in-buy").val());
        if (isNaN(rate))
            rate = 2;
        const a = new Intl.NumberFormat('en-IN', { maximumSignificantDigits: 3 }).format((rate * qty))
        $(".num-buy-pi").text(a);
    });
    $(".btn_buy").click(function (e) {
        e.preventDefault();
        let isAuth = localStorage.getItem("IsAuthentication");
        if (isAuth == undefined || isAuth == null)
            isAuth = false;
        if(isAuth != true && isAuth !='true'){
            var answer = confirm("Vui lòng đăng nhập để sử dụng chức năng này!");
            if (answer) {
                window.location = "login.html";
            }
            return;
        }
        const rate = parseInt($(".in-buy").val());
        if (isNaN(rate))
            rate = 2;
        const qty = parseInt($(".in-buy-qty").val());
        if (isNaN(qty) || qty <= 0) {
            alert("Số lượng PI không hợp lệ");
            return;
        }
        $(".process-buy").show(300);
        const bodyData = {
            Code: 'TS-' + new Date().getTime(),
            Rate: rate,
            Qty: qty,
            Amount: rate * qty,
            Status: 'Pending',
            Type: 'Buy'
        };
        $.ajax({
            type: "POST",
            url: "/api/v1/Transaction/Create",
            headers: {
                'Accept-Language': 'vi',
                'Content-Type': 'application/json'
            },
            success: function (data) {
                $(".process-buy").hide(200);
                if (data == undefined) {
                    alert("Hệ thống bảo trì!");
                    return;
                }
                if (data.Status != 1) {
                    alert(data.Message);
                    return;
                }
                $(".success-buy").show(800);
                setTimeout(function () {
                    $(".success-buy").hide(1000);
                }, 3000);
            },
            error: function (error) {
                console.log(error)
            },
            async: true,
            data: JSON.stringify(bodyData),
            cache: false,
            contentType: false,
            processData: false,
            timeout: 60000
        });
    });

    $('.in-sell-qty').change(function () {
        const qty = parseInt($(this).val());
        if (isNaN(qty) || qty <= 0) {
            $(".num-sell-pi").text("0");
            return;
        }
        const rate = parseFloat($(".in-sell").val());
        if (isNaN(rate))
            rate = 1.5;
        const a = new Intl.NumberFormat('en-IN', { maximumSignificantDigits: 3 }).format((rate * qty))
        $(".num-sell-pi").text(a);
    });

    $(".btn_sell").click(function (e) {
        e.preventDefault();
        let isAuth = localStorage.getItem("IsAuthentication");
        if (isAuth == undefined || isAuth == null)
            isAuth = false;
        if(isAuth != true && isAuth !='true'){
            var answer = confirm("Vui lòng đăng nhập để sử dụng chức năng này!");
            if (answer) {
                window.location = "login.html";
            }
            return;
        }
        const rate = parseInt($(".in-sell").val());
        if (isNaN(rate))
            rate = 1.5;
        const qty = parseInt($(".in-sell-qty").val());
        if (isNaN(qty) || qty <= 0) {
            alert("Số lượng PI không hợp lệ");
            return;
        }
        $(".process-sell").show(300);
        const bodyData = {
            Code: 'TS-' + new Date().getTime(),
            Rate: rate,
            Qty: qty,
            Amount: rate * qty,
            Status: 'Pending',
            Type: 'Sell'
        };
        $.ajax({
            type: "POST",
            url: "/api/v1/Transaction/Create",
            headers: {
                'Accept-Language': 'vi',
                'Content-Type': 'application/json'
            },
            success: function (data) {
                $(".process-sell").hide(200);
                if (data == undefined) {
                    alert("Hệ thống bảo trì!");
                    return;
                }
                if (data.Status != 1) {
                    alert(data.Message);
                    return;
                }
                $(".success-sell").show(800);
                setTimeout(function () {
                    $(".success-sell").hide(1000);
                }, 3000);
            },
            error: function (error) {
                console.log(error)
            },
            async: true,
            data: JSON.stringify(bodyData),
            cache: false,
            contentType: false,
            processData: false,
            timeout: 60000
        });
    });

    $(".btn_tra_cuu").click(function(e){
        e.preventDefault();
        let isAuth = localStorage.getItem("IsAuthentication");
        if (isAuth == undefined || isAuth == null)
            isAuth = false;
        if(isAuth != true && isAuth !='true'){
            var answer = confirm("Vui lòng đăng nhập để sử dụng chức năng này!");
            if (answer) {
                window.location = "login.html";
            }
        }
        const bodyData = {
            Code: $('input[name="gd_ma"]').val()
        };
        $.ajax({
            type: "POST",
            url: "/api/v1/Transaction/Check",
            headers: {
                'Accept-Language': 'vi',
                'Content-Type': 'application/json'
            },
            success: function (data) {
                if (data == undefined) {
                    $(".output-transaction").hide();
                    alert("Hệ thống bảo trì!");
                    return;
                }
                if (data.Status != 1) {
                    $(".output-transaction").hide();
                    alert(data.Message);
                    return;
                }
                const obj = data.Items;
                if (obj == undefined || obj == null) {
                    $(".output-transaction").hide();
                    return;
                }
                $(".trans-code").text(obj.Code);
                $(".trans-qty").text(obj.Qty);
                $(".trans-rate").text(obj.Rate);
                $(".trans-status").text(obj.Status);
                $(".output-transaction").show(1000);
            },
            error: function (error) {
                console.log(error)
            },
            async: true,
            data: JSON.stringify(bodyData),
            cache: false,
            contentType: false,
            processData: false,
            timeout: 60000
        });
    });
    $(".copy-address").click(function(e){
        e.preventDefault();
        /* Get the text field */
        var copyText = document.getElementById("mywallet");

        /* Select the text field */
        copyText.select();
        copyText.setSelectionRange(0, 99999); /* For mobile devices */

        /* Copy the text inside the text field */
        navigator.clipboard.writeText(copyText.value);
        $("#mywallet").css({
            "background":"#4f2e54",
            "color":"#fff"
        });
        setTimeout(function(){
            $("#mywallet").css({
                "background":"#fff",
                "color":"#333"
            });
        }, 2000);
    })
});
