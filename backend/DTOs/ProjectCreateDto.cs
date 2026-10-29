
namespace PortfolioApi.DTOs;

public record ProjectCreateDto(
    string Titel,
    string Beschrijving,
    string Categorie,
    string GitHubUrl,
    DateTime Datum
);
