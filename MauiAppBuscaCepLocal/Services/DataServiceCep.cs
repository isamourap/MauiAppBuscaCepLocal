using MauiAppBuscaCepLocal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiAppBuscaCepLocal.Services
{
    public class DataServiceCep
    {
        public static async Task<Endereco?> GetEnderecoByCep(
            string cep)
        {
            Endereco? end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(
                    "http://10.0.2.2:8000/endereco/by-cep?cep=" + cep);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco?>(json);
                }
                else
                    throw new Exception(
                        response.RequestMessage.Content.ToString());
            }
            return end;
        }
    }
}
