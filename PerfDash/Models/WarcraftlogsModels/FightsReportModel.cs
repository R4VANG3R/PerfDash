using System.ComponentModel.DataAnnotations;

namespace PerfDash.Models.WarcraftlogsModels
{
    public class FightsReportModel
    {
        public string Id;
        public string Title;
        public string Owner;
        public long Zone;
        
        [Display(Name = "start_time")]
        public long Start;

        [Display(Name = "end_time")]
        public long End;
    }
}
