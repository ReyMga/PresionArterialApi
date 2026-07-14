using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresionArterial.Api.Data;
using PresionArterial.Api.DTOs.Auth;
using PresionArterial.Api.Interfaces;
using PresionArterial.Api.Models;

namespace PresionArterial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly IConfiguration _configuration;

    public AuthController(
        AppDbContext context,
        IJwtService jwtService,
        IConfiguration configuration)
    {
        _context = context;
        _jwtService = jwtService;
        _configuration = configuration;
    }

    // POST: api/auth/google
    [HttpPost("google")]
    public async Task<ActionResult<AuthResponseDto>> LoginConGoogle(
        LoginGoogleDto dto)
    {
        var googleClientId = _configuration["Google:ClientId"];

        if (string.IsNullOrWhiteSpace(googleClientId))
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new
                {
                    mensaje = "Google Client ID no está configurado."
                });
        }

        try
        {
            var settings =
                new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { googleClientId }
                };

            var payload = await GoogleJsonWebSignature.ValidateAsync(
                dto.IdToken,
                settings);

            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(
                    u => u.GoogleId == payload.Subject);

            if (usuario is null)
            {
                usuario = new Usuario
                {
                    GoogleId = payload.Subject,
                    Nombre = payload.Name ?? payload.Email,
                    Email = payload.Email,
                    FechaCreacion = DateTime.UtcNow
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            else
            {
                usuario.Nombre = payload.Name ?? usuario.Nombre;
                usuario.Email = payload.Email;

                await _context.SaveChangesAsync();
            }

            var token = _jwtService.GenerarToken(usuario);

            var duracionMinutos =
                _configuration.GetValue<int>(
                    "Jwt:DuracionMinutos");

            return Ok(new AuthResponseDto
            {
                Token = token,
                Expiracion = DateTime.UtcNow.AddMinutes(
                    duracionMinutos),
                Nombre = usuario.Nombre,
                Email = usuario.Email
            });
        }
        catch (InvalidJwtException)
        {
            return Unauthorized(new
            {
                mensaje = "El token de Google no es válido."
            });
        }
    }
}