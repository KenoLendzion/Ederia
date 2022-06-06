
namespace Domain.Entities
{
    public class Recipe : BaseAuditableEntity 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? KcalPerPortion { get; set; }
        public int? CookingTimeInMinutes { get; set; }   
    }
}
