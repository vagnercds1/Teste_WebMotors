using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMotors.Domain.Data.DTO;
using WebMotors.Repository.Entity;

namespace WebMotors.Domain.Data.Converter
{
    public class AnuncioConverter : IConverter<AnuncioDTO, Anuncio>, IConverter<Anuncio, AnuncioDTO>
    { 
        private IMapper _mapper;
        public AnuncioConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Anuncio Parse(AnuncioDTO origin)
        {
            return _mapper.Map<Anuncio>(origin);
        }

        public AnuncioDTO Parse(Anuncio origin)
        {
            return _mapper.Map<AnuncioDTO>(origin);
        }

        public List<Anuncio> ParseList(List<AnuncioDTO> origin)
        {
            if (origin == null) return new List<Anuncio>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AnuncioDTO> ParseList(List<Anuncio> origin)
        {
            if (origin == null) return new List<AnuncioDTO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
