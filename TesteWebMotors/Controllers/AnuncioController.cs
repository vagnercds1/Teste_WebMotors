
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteWebMotors.Models;
using WebMotors.Domain.Business.Interfaces;
using WebMotors.Domain.Data.DTO;
using WebMotors.Repository.Interfaces;

namespace TesteWebMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {

        private IAnuncioBusiness _business;

        public AnuncioController(IAnuncioBusiness business, IMapper mapper)
        {
            _business = business;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(_business.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var anuncio = _business.FindById(id);
                if (anuncio == null) return NotFound();
                return new OkObjectResult(anuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            } 
        }

        // POST api/values 
        [HttpPost()]
        [Route("create")]
        public IActionResult Post([FromBody]AnuncioDTO anuncio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            try
            {
                if (anuncio == null) return BadRequest();
                return new OkObjectResult(_business.Create(anuncio));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            } 
        }


        // PUT api/values/5 
        [Route("update")]
        [HttpPut()]
        public IActionResult Put([FromBody] AnuncioDTO anuncio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            try
            {
                if (anuncio == null) return BadRequest();
                var updatedanuncio = _business.Update(anuncio);
                if (updatedanuncio == null) return BadRequest();
                return new OkObjectResult(updatedanuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        // DELETE api/values/5 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var retono = _business.FindById(id);

            if (retono == null)
                return NotFound();

            try
            {
                _business.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            } 
        }
    }
}
