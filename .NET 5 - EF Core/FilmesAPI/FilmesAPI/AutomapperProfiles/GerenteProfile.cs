﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.AutomapperProfiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas,
                           opts => opts.MapFrom(gerente =>
                                            gerente.Cinemas.Select(
                                                cinema => new
                                                {
                                                    cinema.Id,
                                                    cinema.Nome,
                                                    cinema.Endereco,
                                                    cinema.EnderecoId
                                                }
                                                )));
        } 
    }
}
