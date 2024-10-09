using SQLite;

namespace CarListApp.Models
{
    [Table(nameof(Car))]
    public class Car : BaseEntity
    {
        [MaxLength(200)]
        public string Make { get; set; }

        [MaxLength(200)]
        public string Model { get; set; }

        [Unique, MaxLength(12)]
        public string Vin { get; set; }
    }
}
