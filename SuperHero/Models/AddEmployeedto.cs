namespace SuperHero.Models
{
    public class AddEmployeedto
    {
        public required string Name { get; set; }


        public required int Email { get; set; }
        public required string Description { get; set; }


        public string? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
