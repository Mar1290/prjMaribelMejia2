//1- definir evento clic para el botón guardar
$("#btnGuardar").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var nombrepdto = $(".Nombrepdto").val();
    //obtener el valor del input nombre-categoria
    var descripcionpdt = $(".descripcion-pdto").val();
    var idcat = $(".idcat").val();
    var preciopdto = $(".preciopdto").val();
    var idmarca = $(".idmarca").val();
    var marca = $(".nmarca").val();

    //sugerencia de validacion 
    if (nombrepdto == "" || descripcionpdt == "" || idcat == "" || preciopdto == "" || idmarca == ""){
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
        //hacer la peticion al servidor para crear nueva categoria

        var xhr = $.ajax({

            //url destino
            url: "CrearProducto",
            type: "POST",
            //agregamos los parametros de la petición
            data: {
                "Producto": nombrepdto,
                "IdCategoria": idcat,
                "Precio": preciopdto,
                "Descripcion": descripcionpdt,
                "IdMarca": idmarca
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

                //luego de 2 segundos redireccioonar a lista de productos
                setTimeout(function () {
                    location.href = "../Productos/Productos";
                }, 2000)              

            }
            else {
                Swal.fire(
                    '¡Error!',
                    data.message,//'¡Click en el botón!',
                    'error'
                )
            }
            //borrar: console.log(data);

        });

        xhr.fail(function () {
            notif({
                msg: "Error al guardar este registro",
                type: "error"
            });


        })

    }

});
