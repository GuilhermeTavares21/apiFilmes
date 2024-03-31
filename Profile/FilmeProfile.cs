using AutoMapper;
using FilmesApiAlura.Dto;
using FilmesApiAlura.Models;

namespace FilmesApiAlura.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDtos, Filme>();

        CreateMap<UpdateFilmeDto, Filme>();
    }
}
