using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Web1.Pages
{
    public class WeekModel : PageModel
    {
        private readonly ILogger<WeekModel> _logger;
        public IEnumerable<Week> Weeks { get; set; }
        public WeekModel(ILogger<WeekModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Debug.WriteLine("weekschedule get");
            Weeks = LoadJson();
        }
        public List<Week> LoadJson()
        {
            List<Week> items = Enumerable.Empty<Week>().ToList();
            using (StreamReader r = new StreamReader("Wochen.json"))
            {
                string json = r.ReadToEnd();
                 items = JsonConvert.DeserializeObject<List<Week>>(json);
            }

            return items;
        }
    }
    public class Week
    {
        public int id;
        public string Thema;
        public string Dozent;
        public string Raum;
    }
    public class Date
    {
        public static void CurrentDate()
        {
            DateTime thisDay = DateTime.Today;
            var CurrentMonth = thisDay.ToString("MM/yyyy");
         }

    }

}
