
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TesteWebMotors.Models;
using TesteWebMotors.Services;

namespace Services
{
    public static class ApiVeiculos 
    {
        public static List<Marca> GetMarcas()
        {
            List<Marca> listMarca = new List<Marca>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(Paths.Make_URL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var objJsonString = response.Content.ReadAsStringAsync().Result;
                    listMarca = JsonConvert.DeserializeObject<Marca[]>(objJsonString).ToList();

                }
            }
            return listMarca;
        }
        
        public static List<Modelo> GetModelos(int marcaID)
        {
            List<Modelo> listModelo = new List<Modelo>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(Paths.Model_URL + marcaID).Result;
                if (response.IsSuccessStatusCode)
                {
                    var objJsonString = response.Content.ReadAsStringAsync().Result;
                    listModelo = JsonConvert.DeserializeObject<Modelo[]>(objJsonString).ToList();

                }
            }
            return listModelo;
        }

        public static List<Versao> GetVersoes(int modeloID)
        {
            List<Versao> listVersao = new List<Versao>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(Paths.Version_URL + modeloID).Result;
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
