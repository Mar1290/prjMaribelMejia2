﻿//1- definir evento clic para el botón guardar
$("#btnGuardar").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var nombremodulo = $(".nombremodulo").val();

    var idpropietario = $(".idprop").val();

    //sugerencia de validacion 
    if (nombremodulo == "" || idpropietario == 0 ) {
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
            url: "CrearModulo",
            type: "POST",
            //agregamos los parametros de la petición
            data: {
                "Modulo": nombremodulo,
                "IdPropietario": idpropietario     
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
                    location.href = "../Modulos/Modulos";
                }, 2000)
            }
            else {
                Swal.fire(
                    '¡Error!',
                    data.message,//'¡Click en el botón!',
                    'error'
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
