using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerfDash.Services;
using PerfDash.Models.WarcraftlogsModels;

namespace PerfDash.Controllers
{
    public class GuildReportsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            WarcraftlogsServices wlogs = new WarcraftlogsServices();

            //long start = DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeMilliseconds();
            long start = new DateTimeOffset(new DateTime(2017, 3, 28, 0, 0, 0, DateTimeKind.Utc)).ToUnixTimeMilliseconds(); // patch 7.2
            List<GuildReportModel> reports = await wlogs.GetGuildReports("Silverblade", "Frostmane", "EU", start);
            
            return View(new GuildReportsModel { GuildReports = reports });
        }
    }
}