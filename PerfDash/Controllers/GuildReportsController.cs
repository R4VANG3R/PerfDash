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
            List<GuildReportModel> reports = await wlogs.GetGuildReports("Silverblade", "Frostmane", "EU");
            
            return View(new GuildReportsModel { GuildReports = reports });
        }
    }
}