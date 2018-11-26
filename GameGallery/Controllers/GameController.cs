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

namespace GameGallery.Controllers
{
    public class GameController : Controller
    {

        public  IActionResult Index()
        {

            var giantBomb = new GiantBombRestClient("bbf11d4afbc46237a98e179ed5e541945d1b4bf0");

            // Get all search results
            GiantBomb.Api.Model.Platform platform = giantBomb.GetPlatform(157);
            ViewBag.platform = platform;


        
            var request = new RestRequest();
            request.Resource = "games?platforms=157";

            var result = giantBomb.Execute(request).Content;




            return View(result);
        }
       

    }
}