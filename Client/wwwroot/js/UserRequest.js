////$(document).ready(function () {
////    $('.datepicker').datepicker({
////        startDate: '-3d'
////    });

////});
$(function () {
    $('#dateOvertime').datepicker({
        startDate: '-3d',
        endDate: '0d',
        todayHighlight: 'TRUE',
        format: 'dd/mm/yyyy'
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
    $('#btnReq').on('click', sendReq(fillTable.obj));
});

function fillTable() {
    // get values form dropdown and text boxes
    //dibikin list
    let obj = [{
        UserId : $('#userid').val(),
        JobTask : $('#jobtask').val(),
        Date : $('#dateOvertime').val(),
        StartTime : $('#startTime').val(),
        EndTime : $('#endTime').val(),
        Description : $('#desc').val()
    }]
    //di foreach
    var rowHtml = "";
    obj.forEach(function (req) {
        rowHtml += '<tr></tr><td></td><td>' + req.UserId + '</td><td>' + req.JobTask + '</td><td>' + req.Date + '</td><td>' + req.StartTime + '</td><td>' + req.EndTime + '</td><td>' + req.Description + '</td>';
    });
    // lets suppose table id is 'tblViewRecords'
    //tampilkan
    $('#myTable tbody').append(rowHtml);
    return obj;
}
function sendReq(obj) {
    console.log(JSON.stringify(obj));
    $.ajax({
        url: "/Persons/PostReg",
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(obj),
        success: function (data) {
            console.log(data);
            Swal.fire('Registration Success');
            /*$('#addModal').modal("hide");*/
            $('#addModal').hide();
            $('.modal-backdrop').remove();
            $('#formatRegister').trigger('reset');
            $('#myTable').DataTable().ajax.reload();
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
//function hitungSalaryOT() {
//    var Time = 0;
//    var Salary = $("#salary").val();
//    var SalaryOT = 0;
//    var date = $("#dateOvertime").val();

//    if (date.getDay() = weekend) {
//        if (Time <= 8) {
//            SalaryOT = Time * 2 * (1 / 173) * Salary;
//            return SalaryOT
//        } else if (Time > 8 && Time <= 9) {
//            SalaryOT = 8 * 2 * (1 / 173) * Salary;
//            SalaryOT += 1 * 3 * (1 / 173) * Salary;
//            return SalaryOT
//        } else (Time > 9){
//            SalaryOT = 8 * 2 * (1 / 173) * Salary;
//            SalaryOT += 1 * 3 * (1 / 173) * Salary;
//            SalaryOT += (Time - 9) * 4 * (1 / 173) * Salary;
//            return SalaryOT
//        }
//    } else {
//        if (row = 1) {
//            SalaryOT = Time * 1.5 * (1 / 173) * Salary;
//            return SalaryOT;
//        } else (row >= 1) {
//            SalaryOT += Time * 2 * (1 / 173) * Salary;
//            return SalaryOT;
//        }
//    }
    
//}
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
$(document).ready(function () {

    $('#btnFIllReq').on('click', fillTable);

});

function fillTable() {
    // get values form dropdown and text boxes
    var UserId = $('#userid').val();
    var JobTask = $('#jobtask').val();
    var Date = $('#dateOvertime').val();
    var StartTime = $('#startTime').val();
    var EndTime = $('#endTime').val();
    var Description = $('#desc').val();

    var rowHtml = '<tr><td><input type="checkbox" name="ID" value="@employee.ID" class="custom-checkbox chkCheckBoxId" /></td><td>' + UserId + '</td><td>' + JobTask + '</td><td>' + Date + '</td><td>' + StartTime + '</td><td>' + EndTime + '</td><td>' + Description + '</td><td>';

    // lets suppose table id is 'tblViewRecords'

    $('#myTable tbody').append(rowHtml);
}

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