namespace backend.Models
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}
