$.ajax({
    url: "https://localhost:44330/api/divisions",

}).done(result => {
    text = ''
    $.each(result.data, function (key, val) {
        console.log(val.id)
        text += `<option value= "${val.id}">${val.name}</option>`
    })
    $('#inputdivisi').html(text)
}).fail(result => {
    console.log(result)
});

$("#registerBtn").click(function (event) {
    event.preventDefault();

    var obj = new Object();
    obj.userId = $('#inputID').val();
    obj.FirstName = $("#inputFirstName").val();
    obj.LastName = $("#inputLastName").val();
    obj.Phone = $("#inputPhone").val();
    obj.gender = parseInt($("#inputGender").val());
    obj.Salary = parseInt($("#inputSalary").val());
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    obj.DivisionId = parseInt($("#inputdivisi").val());
    obj.ManagerId = $("#inputmanager").val();
    console.log(obj);

    $.ajax({
        /*url: "https://localhost:44316/api/persons/register",*/
        url: "/Register/RegisterData",
        type: "POST",
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        data: obj
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Registered',
            icon: 'success',
        }).then(result => window.location = '/Login/Index');
    }).fail((result) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Register',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})

$.ajax({
    url: "https://localhost:44330/api/accounts/getmanager",
}).done(result => {
    text = ''
    console.log(result)
    $.each(result, function (key, value) {
        console.log(value.id)
        console.log(value.fullName)
        text += `<option value= "${value.id}">${value.fullName}</option>`
    })
    $('#inputmanager').html(text)
}).fail(result => {
    console.log("gagal")
});

$(function () {
    var $password = $(".form-control[type='password']");
    var $passwordAlert = $(".password-alert");
    var $requirements = $(".requirements");
    var leng, bigLetter, num, specialChar;
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

$("#forgotbtn").click(function (event) {
    event.preventDefault();

    var obj = new Object();
    obj.Id = $('#inputuserId').val();
    obj.Email = $("#inputEmail").val();
    console.log(obj);

    $.ajax({
        /*url: "https://localhost:44316/api/persons/register",*/
        url: "/ForgotPassword/Forgot",
        type: "POST",
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        data: obj
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Registered',
            icon: 'success',
        }).then(result => window.location = '/Login/Index');
    }).fail((result) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Register',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})
