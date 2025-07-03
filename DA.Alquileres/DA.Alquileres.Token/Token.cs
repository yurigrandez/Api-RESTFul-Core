using DA.Alquileres.DTO.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.Token
{
    public class Token
    {
        private readonly IConfiguration configuration;

        public Token(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerarToken(UsuarioLoginResponseDTO usuario)
        {
            var jwtSetting = configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["key"]!));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString()!),
                new Claim("NombreCompleto", usuario.NombreCompleto),
                new Claim("IdUsuario", usuario.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                                issuer: jwtSetting["Issuer"],
                                audience: jwtSetting["Audience"],
                                claims: claims,
                                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSetting["ExpirationMinutes"]!)),
                                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
