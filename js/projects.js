const projects = [
    {
        title: "Portfolio website",
        category: "Web",
        year: 2026,
        description: "Een responsive portfolio met HTML, CSS en JavaScript."
    },
    {
        title: "Campus EventDesk",
        category: "Database",
        year: 2026,
        description: "Een schoolproject waarin ik een datamodel en relationele database heb uitgewerkt."
    },
    {
        title: "GymBuddy",
        category: "AI",
        year: 2025,
        description: "Een schoolproject waarin ik heb gewerkt met een lokale AI-agent en verschillende taalmodellen."
    }
];

const projectList = document.querySelector("#project-list");
const categoryFilter = document.querySelector("#category-filter");
const yearSort = document.querySelector("#year-sort");
const projectCount = document.querySelector("#project-count");

const createProjectCard = (project) => {
    const article = document.createElement("article");
    article.classList.add("project-card");

    const title = document.createElement("h2");
    title.textContent = project.title;

    const meta = document.createElement("p");
    const strong = document.createElement("strong");
    strong.textContent = `${project.category} - ${project.year}`;
    meta.appendChild(strong);

    const description = document.createElement("p");
    description.textContent = project.description;

    article.append(title, meta, description);
    return article;
};

const getVisibleProjects = () => {
    const selectedCategory = categoryFilter.value;
    const selectedSort = yearSort.value;

    const filteredProjects = selectedCategory === "all"
        ? [...projects]
        : projects.filter((project) => project.category === selectedCategory);

    filteredProjects.sort((a, b) => {
        return selectedSort === "newest" ? b.year - a.year : a.year - b.year;
    });

    return filteredProjects;
};

const renderProjects = () => {
    const visibleProjects = getVisibleProjects();
    projectList.replaceChildren();

    visibleProjects.forEach((project) => {
        projectList.appendChild(createProjectCard(project));
    });

    projectCount.textContent = `${visibleProjects.length} project(en) gevonden.`;
};

categoryFilter.addEventListener("change", renderProjects);
yearSort.addEventListener("change", renderProjects);

renderProjects();
