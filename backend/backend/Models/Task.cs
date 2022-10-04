namespace backend.Models
{
    public class Task : IBaseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public States State { get; set; }
        public int Score { get; set; }
        public bool Deleted { get; set; }
        public Guid? OwnerId { get; set; }
        public decimal EstimatedTime { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public enum States
    {
        New,
        Reserved,
        Active,
        Completed
    }
}
