

//Get Wish
function getWish(usuario) {


   jQuery.ajax({
       url: '/Wish/GetWishByUsuario?idUsuario=' + usuario,
       
        type: "GET",
        //data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.data != null) {
             
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

      return deseo;
}