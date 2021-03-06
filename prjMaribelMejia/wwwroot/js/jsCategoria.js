/*muestra alerta*/
/*
alert("Archivo cargado");
//cambia el color a al h1
$('h1').css("color", "green");
//para cargar valores en los controles de una vista
$('.nombre-categoria').val('Digite Descripción de la Categoría');
$(".pruebajq4").val("Digite Categoría");

*/
//1- definir evento clic para el bootn guardar
$("#btnGuardar").click(function () {
    //   alert("Este es el evento click");
    //2. obtener el valor del input pruebajq4 en una variable
    var nombrecategoria=$(".pruebajq4").val();
    //obtener el valor del input nombre-categoria
    var descripcioncat = $(".nombre-categoria").val();

    //sugerencia de validacion 
    if (nombrecategoria == "" || descripcioncat=="")
    {        
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
                "Categoria": nombrecategoria,
                "DescripcionCategoria": descripcioncat
            }

        });

        //Mensaje de respuesta
        xhr.done(function (data) {

            //notif({
            //    msg: "Categoría guardada correctamente",
            //    type: "success"
            //});
            if (data.success) {
             
                //mostrar mensaje de guardado satisfactorio
                Swal.fire(
                    'Guardado correctamente!',
                    data.message,//'¡Click en el botón!',
                    'success'
                )
              
                //luego de 2 segundos redireccioonar a lista categoria
                setTimeout(function () {
                    location.href = "../Categorias/ListaCategorias";
                }, 2000)
                //$(".pruebajq4").val("");
                //$(".nombre-Categoria").va("");

            }
            else
            {
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
