$(function () {
    $('#dateOvertime').datepicker({
        startDate: '-3d',
        endDate: '0d',
        todayHighlight: 'TRUE',
        format: 'yyyy/mm/dd'
    });
});
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
$(document).ready(function () {

    $('#btnFIllReq').on('click', fillTable);
});

let Request = [];

function fillTable() {
    //dibikin list
    let requested = []
    var obj = new Object()
    obj.UserId = $('#userid').val();
    obj.JobTask = $('#jobtask').val();
    obj.Date = $('#dateOvertime').val();
    obj.StartTime = parseInt($("#inputstarttime").val());
    obj.EndTime = parseInt($("#inputendtime").val());
    obj.timeperhitungan = parseInt($("#inputendtime").val()) - parseInt($("#inputstarttime").val());
    obj.Description = $('#desc').val()
    console.log(obj)
    Request.push(obj)
    requested.push(obj)
    console.log(Request)
    //di foreach
    var rowHtml = "";
    requested.forEach(function (req) {
        rowHtml += '<tr></tr><td></td><td>' + req.UserId + '</td><td>' + req.JobTask + '</td><td>' + req.Date + '</td><td>' + req.StartTime + ":00" + '</td><td>' + req.EndTime + ":00" + '</td><td>' + req.Description + '</td>';
        let objReq = {
            "UserId": req.UserId,
            "JobTask": req.JobTask,
            "Description": req.Description,
            "Date": req.Date,
            "EndTime": req.EndTime,
            "StartTime": req.StartTime
        };
    });
    $('#myTable tbody').append(rowHtml);
}

$("#btnSendReq").click(function (event) {
    event.preventDefault();
    let sum = 0;
    for (let i = 0; i < Request.length; i++) {
        sum += Request[i].timeperhitungan;
    }
    var obj = new Object();
    Request.forEach
    obj.ApproverName = $('#manager').val();
    obj.Salary = parseInt($('#salary').val());
    obj.StatusName = 2;
    obj.Time = sum;
    obj.userRequests = Request;
    console.log(obj);

    $.ajax({
        url: "https://localhost:44330/api/UserRequests/InsertUserReq",
        /*url: "/Register/RegisterData",*/
        type: "POST",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Submited',
            icon: 'success',
        });
    }).fail((result) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Submit',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})


$(document).ready(function () {
    $('#DataTable').DataTable();
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });
});

$("#deletebtn").click(function (event) {
    event.preventDefault();
    var row = table.row(this.closest('tr')).data();
})

//$(document).ready(function () {
//    $('#myTable').DataTable({
//        "filter": true,
//        "ajax": {
//            "url": "/UserRequest/GetAllData",
//            "datatype": "json",
//            "dataSrc": ""
//        },
//        "dom": 'Bfrtip',
//        "buttons": [
//            {
//                extend: 'excelHtml5',
//                exportOptions: {
//                    columns: [1, 2, 3, 4, 5]
//                },
//                className: 'btn btn-sm btn-outline-secondary',
//                bom: true
//            },
//            {
//                extend: 'pdfHtml5',
//                exportOptions: {
//                    columns: [1, 2, 3, 4, 5]

//                },
//                className: 'btn btn-sm btn-outline-secondary',
//                bom: true
//            },
//            {
//                extend: 'print',
//                exportOptions: {
//                    columns: [1, 2, 3, 4, 5]
//                },
//                className: 'btn btn-sm btn-outline-secondary',
//                bom: true
//            },
//        ],
//        "columns": [
//            {
//                "data": null,
//                render: function (data, type, row, meta) {
//                    return meta.row + meta.settings._iDisplayStart + 1;
//                },
//                /*"autoWidth": true,*/
//                "orderable": false
//            },
//            { "data": "RequestId", "autoWidth": true },
//            { "data": "JobTask", "autoWidth": true },
//            { "data": "Date", "autoWidth": true },
//            { "data": "time", "autoWidth": true },
//        ]
//    });
//});
//function insert() {
//    var obj = {
//        "UserId":$('#userid').val(),
//        "JobTask": $('#jobtask').val(),
//        "Description": $('#desc').val(),
//        "Date": $('#dateOvertime').val(),
//        "EndTime": $('#startTime').val(),
//        "StartTime": $('#endTime').val(),
//    };
//    console.log(JSON.stringify(obj));
//    $.ajax({
//        url: "UserRequests/PostUserReq",
//        type: 'POST',
//        dataType: 'json',
//        contentType: 'application/json; charset=utf-8',
//        data: JSON.stringify(obj),
//        success: function (data) {
//            console.log(data);
//            Swal.fire('Request telah ditambahkan');
//            /*$('#addModal').modal("hide");*/
//            //$('#addModal').hide();
//            //$('.modal-backdrop').remove();
//            //$('#formatRegister').trigger('reset');
//            //$('#myTable').DataTable().ajax.reload();
//        },
//        error: function (xhr, status, error) {
//            Swal.fire({
//                icon: 'error',
//                icon: 'error',
//                title: 'Oops...',
//                text: 'Something went wrong!'
//            });
//        }
//    })
//}