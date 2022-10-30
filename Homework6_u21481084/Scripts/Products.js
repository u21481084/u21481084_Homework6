////$(document).ready(function () {
////    loadData();
////});
////function loadData() {
////    $.ajax({
////        url: "/Home/List",
////        type: "GET",
////        contentType: "application/json;charset=utf-8",
////        dataType: "json",
////        success: function (result) {
////            var html = '';
////            $.each(result, function (key, item) {
////                html += '<tr>';
////                html += '<td>' + item.Id + '</td>';
////                html += '<td>' + item.Name + '</td>';
////                html += '<td>' + item.Age + '</td>';
////                html += '<td>' + item.State + '</td>';
////                html += '<td>' + item.Country + '</td>';
////                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';
////                html += '</tr>';
////            });
////            $('.tbody').html(html);
////        },
////        error: function (errormessage) {
////            alert(errormessage.responseText);
////        }
////    });
////}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Name: $('#Name').val(),
        Year: $('#Year').val(),
        Price: $('#Price').val(),
        Brand: $('#Brand').val(),
        Category: $('#Category').val()
    };
    $.ajax({
        url: "/products/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function getbyID(Id) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Year').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('#Brand').css('border-color', 'lightgrey');
    $('#Category').css('border-color', 'lightgrey');
    $.ajax({
        url: "/products/getbyID/" + Id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
           
            $('#Name').val(result.Name);
            $('#Year').val(result.Year);
            $('#Price').val(result.Price);
            $('#Brand').val(result.Brand);
            $('#Category').val(result.Category);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Name: $('#Name').val(),
        Year: $('#Year').val(),
        Price: $('#Price').val(),
        Brand: $('#Brand').val(),
        Category: $('#Category').val()
    };
    $.ajax({
        url: "/products/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
           
            $('#Name').val("");
            $('#Year').val("");
            $('#Price').val("");
            $('#Brand').val("");
            $('#Category').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/products/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function clearTextBox() {
  
    $('#Name').val("");
    $('#Year').val("");
    $('#Price').val("");
    $('#Brand').val("");
    $('#Category').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}
function validate() {
    var isValid = true;
    
    return isValid;
}