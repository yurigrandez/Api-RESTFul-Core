using AutoMapper;
using DA.Alquileres.DTO.General;
using DA.Alquileres.DTO.Usuario;
using DA.Alquileres.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DA.Alquileres.API.Controllers
{
    /// <summary>
    /// Controlador que permite identificarse al usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServices services;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="services">Contiene los métodos</param>
        /// <param name="mapper">Sirve para mapear los objetos</param>
        /// <param name="configuration">Sirve para obtener datos de appsetting</param>
        public LoginController(IUsuarioServices services, IMapper mapper, IConfiguration configuration)
        {
            this.services = services;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponseData<string>>> login([FromBody] UsuarioLoginRequestDTO requestDTO)
        {
            var respuesta = new GeneralResponseData<string>();
            var usuarioLogin = await services.Login(requestDTO);

            if (usuarioLogin == null)
            {
                respuesta.Success = false;
                respuesta.ShowAlert = true;
                respuesta.Title = "Login";
                respuesta.Mensaje = "Usuario / Clave incorrecto";
                respuesta.Data = null;

                return BadRequest(respuesta);
            }

            var token = GenerarToken(usuarioLogin!);

            respuesta.Success = true;
            respuesta.ShowAlert = false;
            respuesta.Title = "Login";
            respuesta.Mensaje = "Login correcto";
            respuesta.Data = token;

            return Ok(respuesta);
        }

        private string GenerarToken(UsuarioLoginResponseDTO usuario)
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
