using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SpeakingNumbers.Models;

namespace SpeakingNumbers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new InputModel());
        }

        [HttpPost]
        public ActionResult Index(InputModel model)
        {
            if (ModelState.IsValid)
            {
                var parser = new InputParser();
                using (var stream = parser.Parse(model))
                {
                    var result = new FileStreamResult(stream, "audio/wav");
                    result.FileDownloadName = model.NumberAsString + ".wav";
                }
            }

            return View(model);
        }
    }
}
