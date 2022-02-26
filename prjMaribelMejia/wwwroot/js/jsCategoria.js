/*muestra alerta*/
alert("Archivo cargado");
/*cambia el color a al h1*/
$('h1').css("color", "green");
/*para cargar valores en los controles de una vista*/
$('.nombre-categoria').val('Digite Descripción de la Categoría');
$(".pruebajq4").val("Digite Categoría");
/*como definir eventos en jquery*/

//1- definir evento clic para el bootn guardar
$("#btnGuardar").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var nombrecategoria=$(".pruebajq4").val();
    //obtener el valor del input nombre-categoria
    var descripcioncat = $(".nombre-categoria").val();
    /*
    //3.ahora lo pasamos y mostramos los valores al contenedor
    $(".contenedor").text(nombrecategoria + " - " + descripcioncat);
    */
    /*
    //validar los campos vacios
    if (nombrecategoria == "") {
        alert ("El campo Nombre Categoria es requerido")        
    }
    */
    //sugerencia de validacion 
    if (nombrecategoria == "" || descripcioncat=="")
    {
        alert("todos los campos son requeridos")
   
    Swal.fire({
        title: 'El nombre categoria es requerido',
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
        //utilizar ajax
       /* //sintaxis
        var ajax = $.ajax({

        })
        */

        var xhr = $.ajax({

            //url destino
            url: "CrearCategoria",
            type: "POST",
            //agregamos los parametros de la petición
            data: {
                "NombreCategoria": nombrecategoria,
                "DescripcionCategoria": descripcioncat
            }
        });

        //Mensaje de respuesta
        xhr.done(function () {

            notif({
                msg: "Categoria guardada correctamente",
                type: "success"
            });

            $(".nombre-Categoria").va("");
            $(".pruebajq4").val("");


            xhr.fail(function () {
                notif({
                    msg: "Error al guardar este registro",
                    type: "error"
                });

            });
        })

    }
 
});
