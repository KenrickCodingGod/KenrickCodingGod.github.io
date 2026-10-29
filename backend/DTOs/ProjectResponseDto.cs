
namespace PortfolioApi.DTOs;

public record ProjectResponseDto(
    int Id,
    string Titel,
    string Beschrijving,
    string Categorie,
    string GitHubUrl,
    DateTime Datum
);
