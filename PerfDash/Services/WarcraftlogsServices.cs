﻿using PerfDash.Models.WarcraftlogsModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PerfDash.Services
{
    public class WarcraftlogsServices
    {
        private const string apiKey = "e1316422d89395603ca94b6bb2926987";
        private readonly Uri baseUri = new Uri("https://www.warcraftlogs.com");
        private HttpClient client = new HttpClient();

        public WarcraftlogsServices()
        {
            client.BaseAddress = baseUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets an array of Report objects. Each Report corresponds to a single calendar report for the specified guild.
        /// </summary>
        /// <param name="guildName">The name of the guild to collect reports for.</param>
        /// <param name="serverName">The server that the guild is found on. For World of Warcraft this is the 'slug' field returned from their realm status API.</param>
        /// <param name="serverRegion">The short region name for the server on which the guild is located: US, EU, KR, TW, CN.</param>
        /// <param name="start">An optional start time. This is a UNIX timestamp but with millisecond precision. If omitted, 0 is assumed.</param>
        /// <param name="end">An optional end time. This is a UNIX timestamp but with millisecond precision. If omitted, the current time is assumed.</param>
        /// <returns></returns>
        public async Task<List<GuildReportModel>> GetGuildReports(string guildName, string serverName, string serverRegion, long start = -1, long end = -1)
        {
            List<GuildReportModel> reports = null; 
            string relativeUri = string.Format("/v1/reports/guild/{0}/{1}/{2}", guildName, serverName, serverRegion);

            UriBuilder requestUri = new UriBuilder(new Uri(client.BaseAddress, relativeUri));

            requestUri.Query = string.Format("api_key={0}", apiKey);
            if (start > -1)
                requestUri.Query += string.Format("&start={0}", start);
            if (end > -1)
                requestUri.Query += string.Format("&end={0}", end);

            HttpResponseMessage response = await client.GetAsync(requestUri.Uri);
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                reports = JsonConvert.DeserializeObject<List<GuildReportModel>>(responseData);
            }

            return reports;
        }
    }
}
