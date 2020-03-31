
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;
using System;
using System.Collections.Generic;
using TesteWebMotors.Models;

namespace TesteWebMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    { 
        public CombosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // GET api/values
        [HttpGet]
        [Route("getmarcas")]
        public  ActionResult<IEnumerable<Marca>> GetMarcas()
        {
            try
            {
                return new ApiVeiculos(Configuration).GetMarcas();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            } 
        }


        // GET api/values
        [HttpGet]
        [Route("getmodelos")]
        public ActionResult<IEnumerable<Modelo>> GetModelos(int idMarca)
        {
            try
            {
                return new ApiVeiculos(Configuration).GetModelos(idMarca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET api/values
        [HttpGet]
        [Route("getversoes")]
        public ActionResult<IEnumerable<Versao>> GetVersoes(int idModelo)
        {
            try
            {
                return new ApiVeiculos(Configuration).GetVersoes(idModelo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        } 
    }
}
