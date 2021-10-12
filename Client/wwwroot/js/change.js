$(function () {
    var $password = $(".form-control[name='newPassword']");
    var $passwordAlert = $(".password-alert");
    var $requirements = $(".requirements");
    var leng, bigLetter, num;
    var $leng = $(".leng");
    var $bigLetter = $(".big-letter");
    var $num = $(".num");
    var numbers = "0123456789";

    $requirements.addClass("wrong");
    $password.on("focus", function () { $passwordAlert.show(); });

    $password.on("input blur", function (e) {
        var el = $(this);
        var val = el.val();
        $passwordAlert.show();

        if (val.length < 8) {
            leng = false;
        }
        else if (val.length > 7) {
            leng = true;
        }


        if (val.toLowerCase() == val) {
            bigLetter = false;
        }
        else { bigLetter = true; }

        num = false;
        for (var i = 0; i < val.length; i++) {
            for (var j = 0; j < numbers.length; j++) {
                if (val[i] == numbers[j]) {
                    num = true;
                }
            }
        }

        console.log(leng, bigLetter, num);

        if (leng == true && bigLetter == true && num == true) {
            $(this).addClass("valid").removeClass("invalid");
            $requirements.removeClass("wrong").addClass("good");
            $passwordAlert.removeClass("alert-warning").addClass("alert-success");
        }
        else {
            $(this).addClass("invalid").removeClass("valid");
            $passwordAlert.removeClass("alert-success").addClass("alert-warning");

            if (leng == false) { $leng.addClass("wrong").removeClass("good"); }
            else { $leng.addClass("good").removeClass("wrong"); }

            if (bigLetter == false) { $bigLetter.addClass("wrong").removeClass("good"); }
            else { $bigLetter.addClass("good").removeClass("wrong"); }

            if (num == false) { $num.addClass("wrong").removeClass("good"); }
            else { $num.addClass("good").removeClass("wrong"); }
        }


        if (e.type == "blur") {
            $passwordAlert.hide();
        }
    });
});

$('#newpassword, #confirmpassword').on('keyup', function () {
    if ($('#newpassword').val() == $('#confirmpassword').val()) {
        $('#message').html('Password Matching').css('color', 'green');
    } else
        $('#message').html('Password Not Matching').css('color', 'red');
});

$("#changebtn").click(function (event) {
    event.preventDefault();
    var obj = new Object();
    obj.Email = email;
    obj.Password = $("#oldpassword").val();
    obj.NewPassword = $("#newpassword").val();
    obj.ConfirmPassword = $("#confirmpassword").val();
    console.log(obj);

    $.ajax({
        /*url: "https://localhost:44330/api/accounts/changepassword",*/
        url: "/ChangePassword/Change",
        type: "POST",
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        data: obj
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'Change Password Success',
            icon: 'success',
        });
    }).fail((result) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Register',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})
