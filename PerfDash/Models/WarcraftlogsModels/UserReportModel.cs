using System.ComponentModel.DataAnnotations;

namespace PerfDash.Models.WarcraftlogsModels
{
    public class UserReportModel
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
        public int StartTime;

        [Required]
        public int EndTime;
    }
}
