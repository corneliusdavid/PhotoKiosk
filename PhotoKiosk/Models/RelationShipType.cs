using System.ComponentModel.DataAnnotations;

namespace PhotoKiosk.Models
{
    public class RelationShipType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RelationshipName { get; set; }    
    }
}