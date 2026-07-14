namespace PresionArterial.Api.DTOs.Mediciones;

public class EstadisticasMedicionDto
{
    public int CantidadMediciones { get; set; }

    public decimal PromedioSistolica { get; set; }

    public decimal PromedioDiastolica { get; set; }

    public decimal MinimoSistolica { get; set; }

    public decimal MaximoSistolica { get; set; }

    public decimal MinimoDiastolica { get; set; }

    public decimal MaximoDiastolica { get; set; }

    public decimal PromedioTemperatura { get; set; }

    public decimal PromedioHumedad { get; set; }
}