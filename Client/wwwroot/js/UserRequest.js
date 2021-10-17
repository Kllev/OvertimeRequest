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
    $('#tableClient').DataTable({
        "filter": true,
        "ajax": {
            "url": 'https://localhost:44330/api/requests/GetReq/' + userId,
            /*"url": 'https://localhost:44330/API/Requests/',*/
            "datatype": "json",
            "dataSrc": ""
        },
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]

                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
        ],
        "columns": [
            {
                "data": null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                /*"autoWidth": true,*/
                "orderable": false
            },
            { "data": "id", "autoWidth": true },
            { "data": "employeeId", "autoWidth": true },
            { "data": "employeeName", "autoWidth": true },
            {
                "data": null,
                "orderable": false,
                "render": function (data, type, row) {

                    return row["requestDate"].slice(0,10);
                },
                "autoWidth": true
            },
            { "data": "statusName", "autoWidth": true },
            {
                "render": function (data, type, row) {
                    sessionStorage.setItem("RequestId", row["id"])
                    return `<button type="button"
                        class="btn btn-primary"
                        data-toggle="modal"
                        data-target="#exampleModal"
                        onclick="detail('${row["id"]}')">Detail</button></td>
                        <button type="button"
                        class="btn btn-danger"
                        onclick="remove('${row["id"]}')">Delete</button></td>
                        `;
                },
                "autoWidth": true,
                "orderable": false
            }
        ]
    });
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });
    $('#DataTable').DataTable({

    });

});
$(document).ready(function () {
    $('#tableApprover').DataTable({
        "filter": true,
        "ajax": {
            "url": 'https://localhost:44330/Api/Requests/GetAllApproved',
            "datatype": "json",
            "dataSrc": ""
        },
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]

                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
        ],
        "columns": [
            {
                "data": null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                /*"autoWidth": true,*/
                "orderable": false
            },
            { "data": "id", "autoWidth": true },
            { "data": "statusName", "autoWidth": true },
            {
                "data": null,
                "orderable": false,
                "render": function (data, type, row) {

                    return row["requestDate"].slice(0, 10);
                },
                "autoWidth": true
            },
            { "data": "salaryOvertime", "autoWidth": true },
            {
                "render": function (data, type, row) {
                    sessionStorage.setItem("RequestId", row["id"])
                    return `<button type="button"
                        class="btn btn-primary"
                        data-toggle="modal"
                        data-target="#exampleModal"
                        onclick="detail('${row["id"]}')">Detail</button></td>
                        <button type="button"
                        class="btn btn-danger"
                        onclick="remove('${row["id"]}')">Delete</button></td>
                        `;
                },
                "autoWidth": true,
                "orderable": false
            }
        ]
    });
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });
    $('#DataTable').DataTable({

    });

});

$(document).ready(function () {

    $('#btnFIllReq').on('click', fillTable);
});
//tampil user request sesuai request id yang di klik
function detail(id) {
    sessionStorage.setItem("RequestId", id)
    $.ajax({
        url: "https://localhost:44330/API/UserRequests/GetUserReq/" + id,
    }).done((result) => {
        console.log(id);
        console.log(result);
        //menampil kan data
        var rowHtml = "";
        result.forEach(function (req) {
            rowHtml += '<tr></tr><td>' + req.userId + '</td><td>' + req.jobTask + '</td><td>' + req.date.slice(0, 10) + '</td><td>' + req.startTime + ":00" + '</td><td>' + req.endTime + ":00" + '</td><td>' + req.time + '</td><td>' + req.description + '</td>';
        });
        //tampilkan
        $('#tableDetail tbody').html(rowHtml);
    }).fail((result) => {
        console.log(result);
    });
};

$("#btnapprove").click(function (event) {
    event.preventDefault();
    var obj = new Object();
    obj.id = parseInt(sessionStorage.getItem("RequestId"));
    obj.email = email;
    console.log(obj);
    $.ajax({ 
        url: `Request/Approve/`,
        type: "PUT",
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        data: obj
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Submited',
            icon: 'success',
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Submit',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})

$("#btndecline").click(function (event) {
    event.preventDefault();
    var obj = new Object();
    obj.id = parseInt(sessionStorage.getItem("RequestId"));
    obj.email = email;
    console.log(obj);
    $.ajax({
        url: `Request/Decline/`,
        type: "PUT",
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        data: obj
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Submited',
            icon: 'success',
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Submit',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    });
})


function remove(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            //let val = document.getElementById('nik');
            //console.log(nik);
            //val.remove();
            $.ajax({
                url: "Request/DeleteReq" + id,
                method: 'DELETE',
                success: function () {
                    console.log(id);
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                    $('#tableClient').DataTable().ajax.reload();
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
    })
}
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
    //tampilkan
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
