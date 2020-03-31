
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TesteWebMotors.Models;

namespace Services
{
    public  class ApiVeiculos 
    {
        public ApiVeiculos(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public   List<Marca> GetMarcas()
        {
            List<Marca> listMarca = new List<Marca>();
            using (var client = new HttpClient())
            { 
                HttpResponseMessage response = client.GetAsync(Configuration["API_Veiculos:Make_URL"]).Result; 
                if (response.IsSuccessStatusCode)
                {
                    var objJsonString = response.Content.ReadAsStringAsync().Result;
                    listMarca = JsonConvert.DeserializeObject<Marca[]>(objJsonString).ToList();

                }
            }
            return listMarca;
        }
        
        public List<Modelo> GetModelos(int marcaID)
        {
            List<Modelo> listModelo = new List<Modelo>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(Configuration["API_Veiculos:Model_URL"]  + marcaID).Result;
                if (response.IsSuccessStatusCode)
                {
                    var objJsonString = response.Content.ReadAsStringAsync().Result;
                    listModelo = JsonConvert.DeserializeObject<Modelo[]>(objJsonString).ToList();

                }
            }
            return listModelo;
        }

        public List<Versao> GetVersoes(int modeloID)
        {
            List<Versao> listVersao = new List<Versao>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(Configuration["API_Veiculos:Version_URL"] + modeloID).Result;
                if (response.IsSuccessStatusCode)
                {
                    var objJsonString = response.Content.ReadAsStringAsync().Result;
                    listVersao = JsonConvert.DeserializeObject<Versao[]>(objJsonString).ToList();

                }
            }
            return listVersao;
        } 
    }
}
