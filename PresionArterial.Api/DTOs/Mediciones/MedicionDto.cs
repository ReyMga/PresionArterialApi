namespace PresionArterial.Api.DTOs.Mediciones;

public class MedicionDto
{
    public int Id { get; set; }

    public DateTime FechaHora { get; set; }

    public decimal PresionSistolica { get; set; }

    public decimal PresionDiastolica { get; set; }

    public decimal Temperatura { get; set; }

    public decimal Humedad { get; set; }

    public int ValsartanMg { get; set; }

    public int AtenololMg { get; set; }

    public string? Observaciones { get; set; }
}