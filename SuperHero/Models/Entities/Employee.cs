namespace SuperHero.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public  required string Name { get; set; }

        
        public required int Email { get; set; }
        public required string Description { get; set; }


        public string? Phone { get; set; }

        public  decimal Salary { get; set; }


    }
}
