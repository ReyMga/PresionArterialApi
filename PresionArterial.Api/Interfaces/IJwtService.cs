using PresionArterial.Api.Models;

namespace PresionArterial.Api.Interfaces;

public interface IJwtService
{
    string GenerarToken(Usuario usuario);
}