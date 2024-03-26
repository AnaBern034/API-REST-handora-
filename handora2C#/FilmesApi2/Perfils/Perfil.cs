using AutoMapper;
using Models.Dto.Filme;
using Models.Dto.FilmeUpdate;
using Models.Dto.ReadDto;
using Models.Filme;


namespace PerfilDto.Perfils;
public class Perfils : Profile
{
    public Perfils()
    {
        CreateMap<CreateDto,Filmes>();
        CreateMap<UpdateDto,Filmes>();
        CreateMap<Filmes,UpdateDto>();
        CreateMap<Filmes,ReadDto>();
        
    }
}