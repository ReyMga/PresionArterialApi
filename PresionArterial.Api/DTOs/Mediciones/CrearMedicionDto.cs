using System.ComponentModel.DataAnnotations;

namespace PresionArterial.Api.DTOs.Mediciones;

public class CrearMedicionDto
{
    [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
    public DateTime FechaHora { get; set; }

    [Range(5, 30, ErrorMessage = "La presión sistólica debe estar entre 5 y 30.")]
    public decimal PresionSistolica { get; set; }

    [Range(3, 20, ErrorMessage = "La presión diastólica debe estar entre 3 y 20.")]
    public decimal PresionDiastolica { get; set; }

    [Range(-20, 60, ErrorMessage = "La temperatura debe estar entre -20 y 60 °C.")]
    public decimal Temperatura { get; set; }

    [Range(0, 100, ErrorMessage = "La humedad debe estar entre 0 y 100.")]
    public decimal Humedad { get; set; }

    [Range(
        0,
        1000,
        ErrorMessage = "La dosis de Valsartán debe estar entre 0 y 1000 mg."
    )]
    public int ValsartanMg { get; set; }

    [Range(
        0,
        500,
        ErrorMessage = "La dosis de Atenolol debe estar entre 0 y 500 mg."
    )]
    public int AtenololMg { get; set; }

    [StringLength(
        500,
        ErrorMessage = "Las observaciones no pueden superar los 500 caracteres."
    )]
    public string? Observaciones { get; set; }
}