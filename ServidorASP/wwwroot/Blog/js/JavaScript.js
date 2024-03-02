document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".like-button").forEach(function (element) {
        const articleId = element.dataset.articleId;
  
        likeArticle(articleId)
            .then(resultado => {
                console.log(resultado);
                if (resultado) {
                    element.classList.add("liked");
                    element.querySelector('.like-filled-icon').classList.remove('hidden');
                    localStorage.setItem(`liked_${articleId}`, "true");
                } else {
                    element.classList.remove("liked");
                    element.querySelector('.like-filled-icon').classList.add('hidden');
                    localStorage.removeItem(`liked_${articleId}`);
                }
            })
            .catch(error => {
                // Manejar errores de promesa
                console.error('Error en la promesa:', error);
            })
        
    });

    document.querySelectorAll(".like-button").forEach(function (button) {
        button.addEventListener("click", function (e) {
            const articleId = button.dataset.articleId;
            const likeButton = this;
            const likeFilledIcon = likeButton.querySelector('.like-filled-icon');
            var likeCount = document.querySelector(".like-count");
            
            const url = `/Blog/LikeArticle/${articleId}`;
            fetch(url, {
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
                    console.log(data)
                    // Aquí maneja la respuesta exitosa
                    if (data.success === true) {
                        const newLikes = data.likes;
                        likeCount.textContent = newLikes;
                        likeButton.classList.toggle("liked");
                        likeFilledIcon.classList.toggle('hidden');

                        // Almacenar o eliminar el estado de "like" en LocalStorage
                        const localStorageKey = `liked_${articleId}`;
                        if (likeButton.classList.contains("liked")) {
                            localStorage.setItem(localStorageKey, "true");
                        } else {
                            localStorage.removeItem(localStorageKey);
                        }
                    }

                    
                })
                .catch(error => {
                    // Aquí maneja errores de red o errores en el servidor
                    console.error('Error:', error);
                });
            
        });
    });


});