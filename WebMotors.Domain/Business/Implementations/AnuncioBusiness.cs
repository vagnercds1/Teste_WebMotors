using AutoMapper;
using System;
using System.Collections.Generic;
using WebMotors.Domain.Business.Interfaces;
using WebMotors.Domain.Data.Converter;
using WebMotors.Domain.Data.DTO;
using WebMotors.Repository.Interfaces;

namespace WebMotors.Domain.Business.Implementations
{
    public class AnuncioBusiness : IAnuncioBusiness
    {
        private IAnuncioRepository _repository;

        private readonly AnuncioConverter _AnuncioConverter;
        
        public AnuncioBusiness(IAnuncioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _AnuncioConverter = new AnuncioConverter(mapper);
        }

        public AnuncioDTO Create(AnuncioDTO entity)
        {
            var AnuncioEntity = _AnuncioConverter.Parse(entity);
            AnuncioEntity = _repository.Create(AnuncioEntity);
            return _AnuncioConverter.Parse(AnuncioEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<AnuncioDTO> FindAll()
        {
            return _AnuncioConverter.ParseList(_repository.FindAll());
        }

        public AnuncioDTO FindById(int id)
        {

            return _AnuncioConverter.Parse(_repository.FindById(id));
        }

        public AnuncioDTO Update(AnuncioDTO entity)
        {
            var AnuncioEntity = _AnuncioConverter.Parse(entity);
            AnuncioEntity = _repository.Update(AnuncioEntity);
            return _AnuncioConverter.Parse(AnuncioEntity);
        }
    }
}
