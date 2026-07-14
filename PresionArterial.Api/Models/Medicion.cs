namespace PresionArterial.Api.Models;
public class Medicion
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

    public int? UsuarioId { get; set; }

    public Usuario? Usuario { get; set; }
}