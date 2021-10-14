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
    var StartTime = $('#inputstarttime').val();
    var EndTime = $('#inputendtime').val();
    var Description = $('#desc').val;

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