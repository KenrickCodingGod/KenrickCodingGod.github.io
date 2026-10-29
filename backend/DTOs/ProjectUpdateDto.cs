
namespace PortfolioApi.DTOs;

public record ProjectUpdateDto(
    string Titel,
    string Beschrijving,
    string Categorie,
    string GitHubUrl,
    DateTime Datum
);
