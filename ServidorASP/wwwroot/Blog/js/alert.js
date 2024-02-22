// cookies-alert.js

function initializeCookieAlert() {
    const closeButton = document.querySelector('[data-dismiss-target="#alert-2"]');
    const containerAlert = document.getElementById('container-alert');

    closeButton.addEventListener('click', () => {
        // Guardar la cookie cuando el botón de cerrar se hace clic
        document.cookie = 'alertAccepted=true; expires=Fri, 31 Dec 9999 23:59:59 GMT';

        // Ocultar el div container-alert
        containerAlert.style.display = 'none';
    });

    // Verificar si la cookie ya ha sido aceptada al cargar la página
    if (document.cookie.includes('alertAccepted=true')) {
        containerAlert.style.display = 'none';
    }
}
