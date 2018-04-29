using System.ComponentModel.DataAnnotations;

namespace PhotoDirectory.Models
{
    public class Relationship
    {
        public int Id { get; set; }

        public Person Person1 { get; set; }  

        [Required]
        public int Person1Id { get; set; }

        public Person Person2 { get; set; }

        [Required]
        public int Person2Id { get; set; }

        public RelationShipType RelationShipType { get; set; }

        [Required]
        public int RelationShipTypeId { get; set; } 
    }
}