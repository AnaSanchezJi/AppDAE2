using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using AppDAE2.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppDAE2.Areas.General.Services
{
    public class FicSrcCatEdificiosList
    {
        HttpClient FiClient;


        public FicSrcCatEdificiosList()
        {
            this.FiClient = new HttpClient();
            this.FiClient.BaseAddress = new Uri("http://localhost:51049/");
            this.FiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Lista Edificio 100%
        public async Task<List<eva_cat_edificios>> FicGetListCatEdificios()
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/GetEdificios");
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<eva_cat_edificios>>(FicRespuesta);

            }
            return new List<eva_cat_edificios>();
        }

        
        //Detallle Edificio 100%
        public async Task<eva_cat_edificios> FicGetDetailCatEdificios(int id)
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/"+id);
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<eva_cat_edificios>(FicRespuesta);
            }
            return new eva_cat_edificios();
        }

        //Eliminar Edificio -----------------------------------------       
        public async Task<string> FicCatEdificiosDelete(short id)
        {
            HttpResponseMessage FicRespuesta = await this.FiClient.DeleteAsync("api/" + id);
            return FicRespuesta.IsSuccessStatusCode ? "OK" : "ERROR";
        }


        //Editar-------------------------------------------------------------------
        public async Task<eva_cat_edificios> FicCatEdificiosUpdate(eva_cat_edificios edificio)
        {
            edificio.FechaUltMod = DateTime.Now;
            edificio.UsuarioMod = "Paty";

            var json = JsonConvert.SerializeObject(edificio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var respuestaPut = await FiClient.PutAsync("api/" + edificio.IdEdificio, content);
            if (respuestaPut.IsSuccessStatusCode)
            {
                return edificio;
            }
            return null;
        }

        //Nuevo Edificio ------------------------------------------------------------------       
        public async Task<eva_cat_edificios> FicCatEdificiosCreate(eva_cat_edificios edificio)
        {
            edificio.FechaReg = DateTime.Now;
            edificio.FechaUltMod = DateTime.Now;
            edificio.UsuarioReg = "Ana";
            edificio.UsuarioMod = "Ana";            
            

            var FicJson = JsonConvert.SerializeObject(edificio);
            var FiContent = new StringContent(FicJson, Encoding.UTF8, "application/json");
            var FicRespuesta = await FiClient.PostAsync("api/AddEdificios", FiContent);
            if (FicRespuesta.IsSuccessStatusCode)
            {
                return edificio;
            }
            return null;
        }


    }
}
