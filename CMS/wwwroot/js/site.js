// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(".myTable").DataTable({
        order: [
            [3, 'desc'],
            [0, 'asc']
        ],
        dom: 'Bfrtip',
        buttons: {
            buttons: [{
                extend: 'copy',
                className: 'btn btn-sm btn-success'
            },
            {
                extend: 'csv',
                className: 'btn btn-sm btn-danger mx-3'
            },
            {
                extend: 'excel',
                className: 'btn btn-sm btn-primary mx-3'
            },
            {
                extend: 'pdf',
                className: 'btn btn-sm btn-warning mx-3'
            },
            {
                extend: 'print',
                className: 'btn btn-sm btn-info mx-3'
            }
            ]
        }
    });
});
