using System.ComponentModel.DataAnnotations;

namespace PerfDash.Models.WarcraftlogsModels
{
    public class CharacterParseModel
    {
        public int Rank;

        public int OutOf;

        public int Total;

        public int Class;

        public int Spec;

        public string Guild;

        public int Duration;

        public int StartTime;

        public int ItemLevel;

        public int Patch;

        public string ReportID;

        public int FightID;

        public int Difficulty;

        public int Size;

        public bool Estimated;
    }
}
