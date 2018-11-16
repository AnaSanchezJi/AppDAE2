using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using AppDAE2.Models;
using Newtonsoft.Json;

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
        
    }
}
