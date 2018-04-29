using System.ComponentModel.DataAnnotations;

namespace PhotoDirectory.Models
{
    public class RelationShipType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RelationshipName { get; set; }    
    }
}