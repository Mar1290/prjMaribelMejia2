$("#btnGuardar2").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var Productoid = $(".idpdt").val();
    //obtener el valor del input nombre-categoria
    var Moduloid = $(".idmod").val();

    //sugerencia de validacion
    if (Productoid < 0 || Moduloid < 0) {
        Swal.fire({
            title: 'todos los campos son requeridos',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        })
    }
    else {
        var xhr = $.ajax({

            //url destino
            url: "CrearNuevaOferta",
            type: "POST",
            //agregamos los parametros de la petición
            data: {
                "IdProducto": Productoid,
                "IdModulo": Moduloid
            }
        });

        //Mensaje de respuesta
        xhr.done(function (data) {
            if (data.success) {

                //mostrar mensaje de guardado satisfactorio
                Swal.fire(
                    'Guardado correctamente!',
                    data.message,//'¡Click en el botón!',
                    'success'
                )

                //luego de 2 segundos redireccioonar a lista categoria
                setTimeout(function () {
                    location.href = "../Ofertas/Ofertas";
                }, 3000)
            }
            else {
                Swal.fire(
                    '¡Error!',
                    data.message,//'¡Click en el botón!',
                    'Error no se realizò la transacción'
                )
            }
        });
        xhr.fail(function () {
            notif({
                msg: "Error al guardar este registro",
                type: "error"
            });
        })
    }
});