
namespace PortfolioApi.DTOs;

public record BlogpostUpdateDto(
    string Titel,
    string Inhoud,
    DateTime Publicatiedatum
);
