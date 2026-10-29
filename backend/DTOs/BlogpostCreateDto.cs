
namespace PortfolioApi.DTOs;

public record BlogpostCreateDto(
    string Titel,
    string Inhoud,
    DateTime Publicatiedatum
);
