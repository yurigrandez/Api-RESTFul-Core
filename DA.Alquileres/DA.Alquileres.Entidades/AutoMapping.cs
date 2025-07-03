using AutoMapper;
using DA.Alquileres.DTO.Usuario;
using DA.Alquileres.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.Entidades
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TabUsuarios, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioNuevoDTO, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioActualizarDTO, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioLoginRequestDTO, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioLoginResponseDTO, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioLoginRequestDTO, TabUsuarios>().ReverseMap();
            CreateMap<UsuarioLoginResponseDTO, TabUsuarios>().ReverseMap();
        }
    }
}
