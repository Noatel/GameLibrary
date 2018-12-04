using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameManager.Models;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameManager.Controllers
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


            List<Game> games = getGamesByPlatform(157);
            List<Game> platforms = getPlatforms();
            List<Game> mario = getGamesByName("mario");

            return View(mario);
        }

        public List<Game> getGamesByPlatform(int platformID)
        {

            RestSharp.RestRequest request = new RestSharp.RestRequest("api/games", RestSharp.Method.GET);
            request.AddParameter("api_key", apiKey, RestSharp.ParameterType.QueryString);
            request.AddParameter("platforms", platformID, RestSharp.ParameterType.QueryString);
            request.AddParameter("format", "json", RestSharp.ParameterType.QueryString);
            request.AddParameter("sort", "original_release_date:desc", RestSharp.ParameterType.QueryString);

            RestSharp.IRestResponse response = client.Execute(request);

            dynamic results = JsonConvert.DeserializeObject<dynamic>(response.Content);

            JObject obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(response.Content);
            JArray jarr = (JArray)obj["results"];

            List<Game> games = new List<Game>();

            foreach (var item in jarr)
            {
                string Id = Convert.ToString(item["id"]);

                if (!Id.Equals("67742") && !Id.Equals("59938") && !Id.Equals("71095") && !Id.Equals("70513") && !Id.Equals("65713") && !Id.Equals("66679"))
                {

                    Game game = new Game()
                    {
                        Name = Convert.ToString(item["name"]),
                        Image = Convert.ToString(item["image"]["original_url"])
                    };

                    //asdfasdfasfd
                    games.Add(game);
                }

            }

            return games;
        }
        public List<Game> getPlatforms()
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

            List<Game> games = new List<Game>();

            foreach (var item in jarr)
            {
                string Id = Convert.ToString(item["id"]);

                if (!Id.Equals("67742") && !Id.Equals("59938") && !Id.Equals("71095") && !Id.Equals("70513") && !Id.Equals("65713") && !Id.Equals("66679"))
                {

                    Game game = new Game()
                    {
                        Name = Convert.ToString(item["name"]),
                        Image = Convert.ToString(item["image"]["original_url"])
                    };

                    games.Add(game);
                }

            }

            return games;
        }
        public List<Game> getGamesByName(string name)
        {

            RestSharp.RestRequest request = new RestSharp.RestRequest("api/games", RestSharp.Method.GET);
            request.AddParameter("api_key", apiKey, RestSharp.ParameterType.QueryString);
            request.AddParameter("format", "json", RestSharp.ParameterType.QueryString);
            request.AddParameter("filter", "name:" + name, RestSharp.ParameterType.QueryString);

            request.AddParameter("limit", "20", RestSharp.ParameterType.QueryString);
            request.AddParameter("sort", "original_release_date:desc", RestSharp.ParameterType.QueryString);

            RestSharp.IRestResponse response = client.Execute(request);

            dynamic results = JsonConvert.DeserializeObject<dynamic>(response.Content);

            JObject obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(response.Content);
            JArray jarr = (JArray)obj["results"];

            List<Game> games = new List<Game>();

            foreach (var item in jarr)
            {
                string Id = Convert.ToString(item["id"]);

                if (!Id.Equals("67742") && !Id.Equals("59938") && !Id.Equals("71095") && !Id.Equals("70513") && !Id.Equals("65713") && !Id.Equals("66679"))
                {

                    Game game = new Game()
                    {
                        Name = Convert.ToString(item["name"]),
                        Image = Convert.ToString(item["image"]["original_url"])
                    };

                    games.Add(game);
                }

            }

            return games;
        }


    }
}
