(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Something went wrong!',
                    })
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === true) {
                    event.preventDefault();
                    insert();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();
function insert() {
    var userid = context.Session.GetString(UserId);
    var obj = {
        "UserId":$('#userid').val(),
        "JobTask": $('#jobtask').val(),
        "Description": $('#desc').val(),
        "Date": $('#date').val(),
        "EndTime": $('#startTime').val(),
        "StartTime": $('#endTime').val(),
    };
    console.log(JSON.stringify(obj));
    $.ajax({
        url: "UserRequests/PostUserReq",
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(obj),
        success: function (data) {
            console.log(data);
            Swal.fire('Request telah ditambahkan');
            /*$('#addModal').modal("hide");*/
            //$('#addModal').hide();
            //$('.modal-backdrop').remove();
            //$('#formatRegister').trigger('reset');
            //$('#myTable').DataTable().ajax.reload();
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!'
            });
        }
    })
}