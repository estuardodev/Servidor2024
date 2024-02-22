document.addEventListener('DOMContentLoaded', function () {
    var themeToggleBtn = document.getElementById('theme-toggle');

    // Obtener la preferencia de tema del usuario
    var prefersDarkMode = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;


    var existClave = localStorage.getItem('dark_mode');

    if (existClave !== null) {
        // Obtener el estado del modo oscuro desde localStorage
        var isDarkMode = localStorage.getItem('dark_mode') === 'true';
        var useDarkMode = isDarkMode;
    } else {

        var useDarkMode = prefersDarkMode;
        // Establecer el estado inicial del interruptor de tema y el tema
        themeToggleBtn.checked = useDarkMode;
        document.documentElement.classList.toggle('dark', useDarkMode);
    }

    themeToggleBtn.addEventListener('change', function () {
        // Cambiar el tema al hacer clic en el interruptor
        document.documentElement.classList.toggle('dark', themeToggleBtn.checked);

        // Almacenar el estado del modo oscuro en localStorage
        localStorage.setItem('dark_mode', themeToggleBtn.checked);
    });
});
