
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteWebMotors.Models;

namespace TesteWebMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly TesteContext _context;

        public AnuncioController(TesteContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anuncio>>> Get()
        {
            return await _context.Anuncios.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> Get(int id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        // POST api/values 
        [HttpPost()]
        [Route("create")]
        public async Task<ActionResult<Anuncio>> Post([FromBody]Anuncio anuncio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
             
            var listMarcas = ApiVeiculos.GetMarcas(); 
            if (!listMarcas.Where(x => x.Name.Contains(anuncio.Marca)).Any())
                return NotFound("Marca não encontrada");
             

            var listModelos = ApiVeiculos.GetModelos(listMarcas.Where(x => x.Name.Contains(anuncio.Marca)).First().ID);
            if (!listModelos.Where(x => x.Name.Contains(anuncio.Modelo)).Any())
                return NotFound("Modelo não encontrado");
            else  
                anuncio.Modelo = listModelos.Where(x => x.Name.Contains(anuncio.Modelo)).First().Name;
             

            var listVersoes = ApiVeiculos.GetVersoes(listModelos[0].ID);
            if (!listVersoes.Where(x => x.Name.Contains(anuncio.Versao)).Any())
                return NotFound("Versão não encontrada");
            else
                anuncio.Versao = listVersoes.Where(x => x.Name.Contains(anuncio.Versao)).First().Name;

            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = anuncio.ID }, anuncio);
        }


        // PUT api/values/5 
        [Route("update")]
        [HttpPut()]
        public async Task<ActionResult<Anuncio>> Put(Anuncio anuncio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var retorno = _context.Anuncios.Find(anuncio.ID);

            if (retorno == null)
                return NotFound();
            else
            {
                var listMarcas = ApiVeiculos.GetMarcas();
                if (retorno.Marca != anuncio.Marca)
                { 
                    if (!listMarcas.Where(x => x.Name.Contains(anuncio.Marca)).Any())
                        return NotFound("Marca não encontrada");
                    else
                        retorno.Marca = listMarcas[0].Name;
                }

                var listModelos = new List<Modelo>();
                if (retorno.Modelo != anuncio.Modelo)
                {
                    listModelos = ApiVeiculos.GetModelos(listMarcas.Where(a=>a.Name == anuncio.Marca).First().ID);
                    if (!listModelos.Where(x => x.Name.Contains(anuncio.Modelo)).Any())
                        return NotFound("Modelo não encontrado");
                    else
                        retorno.Modelo = listModelos[0].Name;
                }
                 
                if (retorno.Versao != anuncio.Versao)
                {
                    var listVersoes = ApiVeiculos.GetVersoes(listModelos.Where(a=>a.Name == anuncio.Modelo).First().ID);
                    if (!listVersoes.Where(x => x.Name.Contains(anuncio.Versao)).Any())
                        return NotFound("Versão não encontrada");
                    else
                        retorno.Versao = listVersoes[0].Name;
                }
                 
                retorno.Observacao = anuncio.Observacao; 
                retorno.Ano = anuncio.Ano;
                retorno.Kilometragem = anuncio.Kilometragem; 
                _context.Entry(retorno).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("Get", new { id = anuncio.ID }, anuncio);
        }


        // DELETE api/values/5 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var retono = _context.Anuncios.Find(id);

            if (retono != null)
            {
                _context.Anuncios.Remove(retono);
                _context.SaveChanges();
            }
        }
    }
}
