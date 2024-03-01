function likeArticle(articleId) {
    const url = `/Blog/LikeArticleGET/${articleId}`;
    var likeCount = document.querySelector(".like-count");

    return fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ articleId: articleId })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            // Aquí maneja la respuesta exitosa
            if (data.success === true) {
                const newLikes = data.likes;
                likeCount.textContent = newLikes;
                return true;
            } else {
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