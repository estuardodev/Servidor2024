document.addEventListener('DOMContentLoaded', function () {
    var themeToggleBtn = document.getElementById('theme-toggle');

  
    var existClave = localStorage.getItem('dark_mode');
    console.log(existClave);

    if (existClave === 'true') {
        // Obtener el estado del modo oscuro desde localStorage
        document.documentElement.classList.add('dark');
    } 

    themeToggleBtn.addEventListener('change', function () {
        // Cambiar el tema al hacer clic en el interruptor
        document.documentElement.classList.toggle('dark', themeToggleBtn.checked);

        // Almacenar el estado del modo oscuro en localStorage
        localStorage.setItem('dark_mode', themeToggleBtn.checked);
    });
});