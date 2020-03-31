using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Repository.Entity;
using WebMotors.Repository.GenericRepository;
using WebMotors.Repository.Interfaces;

namespace WebMotors.Repository.Implementations
{
    public class AnuncioRepository:GenericRepository<Anuncio>,IAnuncioRepository 
    {
        public AnuncioRepository(ContextDB context) : base(context) { }
    }
}
