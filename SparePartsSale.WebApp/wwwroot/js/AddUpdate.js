
$('#barcode').keypress(function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        GetProduct($("#barcode").val());
        return false;
    }
});

function GetProduct(val) {
    $("#product").val('');
    $("#volume").val('');
    $("#price").val('');

    $.ajax({
        type: "POST",
        url: "/Sale/GetProduct",
        data: { Barcode: val },
        dataType: "text",
        success: function (msg) {
            var data = JSON.parse(msg);
            $("#product").val(data.name);
            $("#volume").val(data.volume);
            $("#price").val(data.price);
        },
        error: function (req, status, error) {
            console.log(msg);
        }
    });


}

function Calc() {
    var quantity = parseFloat($("#quantity").val());
    var price = parseFloat($("#price").val());
    var discount = ($("#discount").val() == '' ? '0' : parseFloat($("#discount").val()));

    var total = quantity * (price - discount);
    $("#total").val(total);
}


var SaleRow = 0;

function Addline() {
    $("#Saledetail").each(function () {
        SaleRow++;
      
        var tr = '<tr>';

        var td =  SaleRow ;
        td += "<td>"+$("#id").val()+"</td>"; 
       
        td += "<td >" + $("#barcode").val() + "</td>";
        td += "<td>" + $("#product").val() + "</td>";
        td += "<td>" + $("#quantity").val() + "</td>";
        td += "<td>" + $("#volume").val() + "</td>";
        td += "<td>" + $("#price").val() + "</td>";
        td += "<td>" + $("#discount").val() + "</td>";
        td += "<td>" + $("#total").val() + "</td>";
        td += "<td><button type='button' class='btn btn-danger btn-sm btnDelete'><i class='fa fa-trash-o'></i> </button></td>";
        tr += td + '</tr>';

        $('tbody', this).append(tr);

    });
}

$("#Saledetail").on('click', '.btnDelete', function () {
    $(this).closest('tr').remove();
});

function SaveSales() {

    var header = [];
    
    header.push('Id');
   
    header.push('Barcode');
    header.push('ProductName');
    header.push('Quantity');
    header.push('Volume');
    header.push('Price');
    header.push('DisCount');
    header.push('Total');



    var DocNo = $("#DocNo").val();
    var Dates = $("#Date").val();
    var PlaceId = $("#PlaceId").val();
    var VendorID = $("#CustomerId").val();
    var DocType = $("#PayType").val();
    var melumat = {
        DocNo: DocNo,
        Date: Dates,
        PlaceId: PlaceId,
        VendorID: VendorID,
        DocType: DocType
    };
    var jsonmelumat = melumat

    var jsondata = TableToJson(header);
    var st = {
       addDetails: jsondata,
        addInfo: jsonmelumat
    };


    $.ajax({
        url: '/add/addupdate',
        type: 'post',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(st),
        success: function (response) {
            if (response.status === 'success') {
                window.location.href = response.redirect_url;
            } else {
                // Uğursuzluq halları ilə əlaqədar işləmələr
            }
        }
    });
   


}


function TableToJson(header) {
    var table = document.getElementById("Saledetail");
    var rows = [];
    for (var i = 1; i < table.rows.length; i++) {
        var row = table.rows[i];
        var data = {};
        for (var j = 0; j < row.cells.length - 1; j++) {


            var cell = row.cells[j];
            var value = cell.innerHTML;
            data[header[j]] = value;
        }
        rows.push(data);


    }

    //console.log(rows);




    return rows;
}


//function top() {
//    var data = {
//        DocNo: $("#DocNo").val(),
//        Date: $("#Date").val(),
//        PlaceId: $("#baPlaceIdrcode").val()
//        CustomerId: $("#CustomerId").val(),
//        PayType: $("#PayType").val()
//    };

//    $.ajax({
//        url: '/sale/addtop',
//        type: 'POST',
//        dataType: 'json',
//        contentType: 'application/json',
//        data: data,
//        success: function (response) {
//            /*do stuff*/
//        }
//    });

//}