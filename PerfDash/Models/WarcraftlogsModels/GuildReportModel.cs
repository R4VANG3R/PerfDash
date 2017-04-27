using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerfDash.Models.WarcraftlogsModels
{
    public class GuildReportsModel
    {
        [Required]
        public List<GuildReportModel> GuildReports { get; set; }
    }

    public class GuildReportModel
    {
        [Required]
        public string Id;

        [Required]
        public string Title;

        [Required]
        public string Owner;

        [Required]
        public int Zone;

        [Required]
        [Timestamp]
        public int StartTime;

        [Required]
        [Timestamp]
        public int EndTime;
    }
}
