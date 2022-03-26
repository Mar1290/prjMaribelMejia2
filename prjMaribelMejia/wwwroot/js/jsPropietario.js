//script propietarios
$("#btnGuardar2").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var nombrepropietario = $(".npropietario").val();
    var identProp = $(".identp").val();
    var direccion = $(".dirp").val();
    var telefono = $(".telefonop").val();


    //sugerencia de validacion
    if (identProp == "" || direccion == "" || telefono == "" || nombrepropietario == "") {
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
            url: "CrearPropietarios",
            type: "POST",
            //agregamos los parametros de la petición
            data: {
                "NombrePropietario": nombrepropietario,
                "IdentificacionPropietario": identProp,
                "DireccionPropietario": direccion,
                "TelefonoPropietario": telefono
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
                    location.href = "../Propietarios/Propietarios";
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