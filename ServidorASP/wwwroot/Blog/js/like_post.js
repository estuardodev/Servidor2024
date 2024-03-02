function likeArticle(articleId) {
    var likeCount = document.querySelector(".like-count");
    const localStorageKey = `liked_${articleId}`;
    const estado = localStorage.getItem(localStorageKey);
    const url = `/Blog/LikeArticleGET/${articleId}/${estado}`;
    console.log("Estado es: " + estado)


    return fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ articleId: articleId, estado: estado })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            // Aquí maneja la respuesta exitosa
            console.log("Data es: " + data);
            if (data.success === true) {
                const newLikes = data.likes;
                likeCount.textContent = newLikes;
                return true;
            } else {
                console.log(data);
                const newLikes = data.likes;
                likeCount.textContent = newLikes;
                return false;
            }
        })
        .catch(error => {
            // Aquí maneja errores de red o errores en el servidor
            console.error('Error:', error);
            return false; // Si hay un error, retorna false
        });
}