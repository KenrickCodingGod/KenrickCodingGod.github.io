
namespace PortfolioApi.DTOs;

public record BlogpostResponseDto(
    int Id,
    string Titel,
    string Inhoud,
    DateTime Publicatiedatum
);
