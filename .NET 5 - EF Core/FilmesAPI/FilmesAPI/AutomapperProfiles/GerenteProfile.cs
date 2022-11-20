using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.AutomapperProfiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
        } 
    }
}
