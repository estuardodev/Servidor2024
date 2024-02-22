function compartirArticulo(id, url) {
    // Obtener el token CSRF

    // Enviar la solicitud POST para incrementar el contador
    $.ajax({
        url: `/Blog/IncrementarCompartidos/${id}`,
        type: "POST",
        data: {},
        headers: {},
        dataType: "json",
        success: function (data) {
            console.log(data.message);
            
            // Abrir el enlace en una nueva ventana
            window.open(url, '_blank');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}
