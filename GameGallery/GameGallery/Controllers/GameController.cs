using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameGallery.Models;
using Flurl;
using Flurl.Http;
using GiantBomb.Api;
using GiantBomb.Api.Model;
using RestSharp.Portable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiContrib.Formatting;
using QuickType;

namespace GameGallery.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {

            var giantBomb = new GiantBombRestClient("bbf11d4afbc46237a98e179ed5e541945d1b4bf0");

            // Get all search results
            GiantBomb.Api.Model.Platform platform = giantBomb.GetPlatform(157);
            ViewBag.platform = platform;



            var results = giantBomb.SearchForAllGames("nintendo switch");

            // Display
            results = results.OrderByDescending(g => g.DateAdded);



            return View(results);
        }
     



    }

}