using System;
using Microsoft.AspNetCore.Mvc;
using RestSharp.Portable;
using RestSharp;
using RestSharp.Authenticators;
using GiantBomb.Api.Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using QuickType;
using Newtonsoft.Json.Linq;

namespace GameGallery.Controllers
{
    public class GameController : Controller
    {
        private String apiKey = "bbf11d4afbc46237a98e179ed5e541945d1b4bf0";
        private RestClient client = new RestClient("https://www.giantbomb.com");

        public IActionResult Index()
        {

            // Nintendo Switch = 157
            // Nintendo Wii = 23
            // Nintendo GameCube = 36
            // Nintendo 64 = 43


            List<String[]> games = getGamesByPlatform(157);
            List<String[]> platforms = getPlatforms();

            return View(platforms);
        }
     
        public List<String[]> getGamesByPlatform(int platformID){
           
            RestSharp.RestRequest request = new RestSharp.RestRequest("api/games", RestSharp.Method.GET);
            request.AddParameter("api_key", apiKey, RestSharp.ParameterType.QueryString);
            request.AddParameter("platforms", "157", RestSharp.ParameterType.QueryString);
            request.AddParameter("limit", "25", RestSharp.ParameterType.QueryString);
            request.AddParameter("format", "json", RestSharp.ParameterType.QueryString);

            RestSharp.IRestResponse response = client.Execute(request);

            dynamic results = JsonConvert.DeserializeObject<dynamic>(response.Content);

            JObject obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(response.Content);
            JArray jarr = (JArray)obj["results"];

            List<String[]> games = new List<String[]>();

            foreach (var item in jarr)
            {
                string Id = Convert.ToString(item["id"]);
                string Name = Convert.ToString(item["name"]);
                string Image = Convert.ToString(item["image"]["medium_url"]);

                games.Add(new string[] { Id, Name, Image });
            }

            return games;
        }
        public List<String[]> getPlatforms()
        {

            RestSharp.RestRequest request = new RestSharp.RestRequest("api/platforms", RestSharp.Method.GET);
            request.AddParameter("api_key", apiKey, RestSharp.ParameterType.QueryString);
            request.AddParameter("filter", "id:157|23|36|43", RestSharp.ParameterType.QueryString);
            request.AddParameter("format", "json", RestSharp.ParameterType.QueryString);
            request.AddParameter("sort", "original_release_date:desc", RestSharp.ParameterType.QueryString);

            RestSharp.IRestResponse response = client.Execute(request);

            dynamic results = JsonConvert.DeserializeObject<dynamic>(response.Content);

            JObject obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(response.Content);
            JArray jarr = (JArray)obj["results"];

            List<String[]> games = new List<String[]>();

            foreach (var item in jarr)
            {
                string Id = Convert.ToString(item["id"]);
                string Name = Convert.ToString(item["name"]);
                string Image = Convert.ToString(item["image"]["medium_url"]);

                games.Add(new string[] { Id, Name, Image });
            }

            return games;
        }


    }

}