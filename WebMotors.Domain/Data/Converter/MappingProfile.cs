using AutoMapper;
using WebMotors.Domain.Data.DTO;
using WebMotors.Repository.Entity;

namespace WebMotors.Domain.Data.Converter
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anuncio, AnuncioDTO>().ReverseMap();
        }
    }
}
