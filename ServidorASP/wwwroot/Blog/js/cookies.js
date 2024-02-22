document.addEventListener("DOMContentLoaded", function () {
    const cookieBanner = document.getElementById("cookie-banner");
    const acceptButton = document.getElementById("accept-cookies");

    acceptButton.addEventListener("click", function () {
        // Establecer una cookie denominada "cookies" con el valor "true"
        document.cookie = "cookies=true; path=/; max-age=31536000"; // Edad máxima: 1 año

        // Ocultar el banner de cookies
        cookieBanner.style.display = "none";
    });

    // Compruebe si la cookie de "cookies" está configurada
    if (document.cookie.indexOf("cookies=true") === -1) {
        cookieBanner.style.display = "block"; // Mostrar el banner si no se aceptan cookies
    }else{
        cookieBanner.style.display="none"
    }
});


