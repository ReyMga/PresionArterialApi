namespace PresionArterial.Api.Models;

public class Usuario
{
    public int Id { get; set; }

    public string GoogleId { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public ICollection<Medicion> Mediciones { get; set; }
        = new List<Medicion>();
}