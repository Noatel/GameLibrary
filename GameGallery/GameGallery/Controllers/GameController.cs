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
        public IActionResult Index()
        {
            RestClient client = new RestClient("https://www.giantbomb.com");
            RestSharp.RestRequest request = new RestSharp.RestRequest("api/games", RestSharp.Method.GET);
            request.AddParameter("api_key", "bbf11d4afbc46237a98e179ed5e541945d1b4bf0", RestSharp.ParameterType.QueryString);
            request.AddParameter("platforms", "157", RestSharp.ParameterType.QueryString);
            request.AddParameter("limit", "25", RestSharp.ParameterType.QueryString);
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


            return View(games);
        }
     



    }

}