using System.ComponentModel.DataAnnotations;

namespace PresionArterial.Api.DTOs.Auth;

public class LoginGoogleDto
{
    [Required]
    public string IdToken { get; set; } = string.Empty;
}