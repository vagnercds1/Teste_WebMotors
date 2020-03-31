using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Domain.Data.DTO;

namespace WebMotors.Domain.Business.Interfaces
{
    public interface IAnuncioBusiness
    {
        AnuncioDTO Create(AnuncioDTO entity);
        AnuncioDTO FindById(int id);
        List<AnuncioDTO> FindAll();
        AnuncioDTO Update(AnuncioDTO entity);
        void Delete(int id);
    }
}
