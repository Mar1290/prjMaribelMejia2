//1- definir evento clic para el botón guardar
$("#btnGuardar").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var nombremodulo = $(".nombremodulo").val();

    var idpropietario = $(".idprop").val();
    var descripcionmodulo = $(".descmodulo").val();

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
                "IdPropietario": idpropietario,
                "DescripcionModulo": descripcionmodulo
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
$("#btnEliminar").click(function ()
{
    var idModulo = $(".idmod").val();
    if (idModulo == 0) {
        Swal.fire({
            title: 'No se encontró registro para eliminar',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        })
    }
    else {

        var xhr2 = $.ajax({
            //url destino
            url: "EliminarModulo",
            type: "POST",
            //agregamos los parametros de la petición
            data: {
                "IdModulo": IdModulo
            }
        });
        //Mensaje de respuesta
        xhr2.done(function (data) {

            if (data.success) {

                //mostrar mensaje de guardado satisfactorio
                Swal.fire({
                    title: 'Esta seguro de eliminar este registro?',
                    text: "You won't be able to revert this!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, delete it!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        Swal.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        )
                    }
                })
                //luego de 2 segundos redireccioonar a lista de modulos
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
    } 

});
