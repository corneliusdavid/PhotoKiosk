using System.ComponentModel.DataAnnotations;

namespace PhotoDirectory.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PhotoFilename { get; set; }   
    }
}