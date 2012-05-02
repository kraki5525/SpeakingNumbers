using System;
using System.Collections.Generic;
using System.IO;
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

    public class InputParser {
        public Stream Parse(InputModel model)
        {
            var reversedNumber = model.NumberAsString.Reverse();
            var parsedModel = new ParsedModel();
            var actions = new Dictionary<int, Action<ParsedModel, string>> 
                          {
                              {0, (pm, value) => pm.Ones = value},
                              {1, (pm, value) => pm.Tens = value},
                              {2, (pm, value) => pm.Hundreds = value},
                              {3, (pm, value) => pm.Thousands = value},
                              {4, (pm, value) => pm.TenThousands = value},
                              {5, (pm, value) => pm.HundredThousands = value},
                              {6, (pm, value) => pm.Millions = value},
                              {7, (pm, value) => pm.TenMillions = value},
                              {8, (pm, value) => pm.HundredMillions = value},
                              {9, (pm, value) => pm.Billions = value},
                              {10, (pm, value) => pm.TenBillions = value},
                              {11, (pm, value) => pm.HundredBillions = value}
                          };
        }

        public class ParsedModel {
            public string Ones { get; set; }

            public string Tens { get; set; }

            public string Hundreds { get; set; }

            public string Thousands { get; set; }

            public string TenThousands { get; set; }

            public string HundredThousands { get; set; }

            public string Millions { get; set; }

            public string TenMillions { get; set; }

            public string HundredMillions { get; set; }

            public string Billions { get; set; }

            public string TenBillions { get; set; }

            public string HundredBillions { get; set; }
        }
    }
}
