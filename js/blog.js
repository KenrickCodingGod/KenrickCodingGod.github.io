const readMoreButton = document.querySelector("#read-more-button");
const blogExtra = document.querySelector("#blog-extra");

const toggleBlogText = () => {
    const isHidden = blogExtra.hidden;

    blogExtra.hidden = !isHidden;
    readMoreButton.textContent = isHidden ? "Toon minder" : "Lees meer";
    readMoreButton.setAttribute("aria-expanded", String(isHidden));
};

readMoreButton.addEventListener("click", toggleBlogText);
