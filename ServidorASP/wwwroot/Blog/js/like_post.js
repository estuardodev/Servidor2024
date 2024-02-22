$(document).ready(function () {
    $(".like-button").each(function () {
        const articleId = $(this).data("article-id");
        const hasLiked = localStorage.getItem(`liked_${articleId}`);

        if (hasLiked) {
            $(this).addClass("liked");
            $(this).find('.like-filled-icon').removeClass('hidden');
        }
    });

    $(".like-button").click(function (e) {
        e.preventDefault();
        const articleId = $(this).data("article-id");
        const likeButton = $(this);
        const likeFilledIcon = likeButton.find('.like-filled-icon');
        const likeCount = likeButton.siblings(".like-count");

        $.ajax({
            url: `/Blog/LikeArticle/${articleId}`,
            method: "POST",
            data: { articleId: articleId }, // Corregido el nombre del parámetro
            success: function (response) {
                if (response.success) {
                    const newLikes = response.likes;
                    likeCount.text(newLikes);

                    likeButton.toggleClass("liked");
                    likeFilledIcon.toggleClass('hidden');

                    // Almacenar o eliminar el estado de "like" en LocalStorage
                    const localStorageKey = `liked_${articleId}`;
                    if (likeButton.hasClass("liked")) {
                        localStorage.setItem(localStorageKey, "true");
                    } else {
                        localStorage.removeItem(localStorageKey);
                    }
                }
            },
            error: function (error) {
                console.error(error);
            }
        });
    });
});
