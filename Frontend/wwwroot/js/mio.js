//Get Wish
//  deseo = [];

//function getWish(usuario) {

    
   
   jQuery.ajax({
        url: '@Url.Action("GetWishByUsuario","Wish")?idUsuario=1',// + usuario,
        type: "GET",
        //data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.data != null) {
                //deseo = [];
                $('#cantDeseo').text('0');
                $.each(data.data, function (i, item) {
                    deseo.push(data.data[i].producto);
                })
                $('#cantDeseo').text(deseo.length);
                return deseo;

            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
     });

    //debugger;
    //deseo = [3, 13];
   // return deseo;
//}