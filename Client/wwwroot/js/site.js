$("#registerBtn").click(function (event) {
    event.preventDefault();

    var obj = new Object();
    obj.userId = $('#inputuserId').val();
    obj.FirstName = $("#inputFirstName").val();
    obj.LastName = $("#inputLastName").val();
    obj.Phone = $("#inputPhone").val();
    obj.gender = parseInt($("#inputGender").val());
    obj.Salary = parseInt($("#inputSalary").val());
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    console.log(obj);

    $.ajax({
        /*url: "https://localhost:44316/api/persons/register",*/
        url: "/Users/RegisterData/",
        type: "POST",
        dataType: 'json',
        contentType: 'application/json; charset-utf-8',
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Registered',
            icon: 'success',
        })
        $('#tableClient').DataTable().ajax.reload();
    }).fail((result) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Register',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})
