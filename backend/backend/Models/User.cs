namespace backend.Models
{
    public class User : IBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int BestMonthlyScore { get; set; }
        public int ThisMonthsScore { get; set; }
        public int ThisWeeksScore { get; set; }
        public int ThisYearsScore { get; set; }
        public int OverallScore { get; set; }
        public DateTime BestMonthlyScoreDate { get; set; }
        public Achievement[] Achievements { get; set; }
        public Guid ActiveTask { get; set; }


        public Task CurrentTask { get;}
        public Task[] ActiveTasks { get; }
    }
}
