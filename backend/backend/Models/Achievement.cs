namespace backend.Models
{
    public class Achievement
    {
        public string Name { get; set; }
        public DateTime DateAchieved { get; set; }
        public AchievementType Type { get; set; }
    }

    public enum AchievementType
    {
        Bronze,
        Silver,
        Gold
    }
}
