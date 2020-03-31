using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Repository.Entity;

namespace WebMotors.Repository.GenericRepository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindById(int id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(int id);
    }
}
