using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public interface IBaseModel
    {
            [BsonId]
            Guid Id { get; set; }
            bool Deleted { get; set; }
            Guid CreatedBy { get; set; }
            DateTime CreatedDate { get; set; }
            Guid UpdatedBy { get; set; }
            DateTime UpdatedDate { get; set; }
    }
}
