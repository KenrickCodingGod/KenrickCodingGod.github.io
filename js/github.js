const githubStatus = document.querySelector("#github-status");
const githubData = document.querySelector("#github-data");
const githubUsername = "KenrickCodingGod";

const createGithubInfo = (profile) => {
    const container = document.createElement("div");
    container.classList.add("github-card");

    const username = document.createElement("p");
    username.textContent = `Gebruikersnaam: ${profile.login}`;

    const repositories = document.createElement("p");
    repositories.textContent = `Publieke repositories: ${profile.public_repos}`;

    const link = document.createElement("a");
    link.href = profile.html_url;
    link.textContent = "Bekijk mijn GitHub-profiel";
    link.target = "_blank";
    link.rel = "noopener noreferrer";

    container.append(username, repositories, link);
    return container;
};

const loadGithubData = async () => {
    githubStatus.textContent = "GitHub-gegevens laden...";
    githubData.replaceChildren();

    try {
        const response = await fetch(`https://api.github.com/users/${githubUsername}`);

        if (!response.ok) {
            throw new Error("GitHub API gaf geen geldig antwoord.");
        }

        const profile = await response.json();
        githubData.appendChild(createGithubInfo(profile));
        githubStatus.textContent = "Actuele gegevens geladen via de GitHub API.";
    } catch (error) {
        githubStatus.textContent = "De GitHub-gegevens konden niet worden geladen. Probeer het later opnieuw.";
        console.error(error);
    }
};

loadGithubData();
