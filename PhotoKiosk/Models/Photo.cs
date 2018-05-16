using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoKiosk.Models
{
    public class Photo
    {
        [Required]
        public int Id { get; set; }

        [StringLength(255)]
        public string PhotoFilename { get; set; }   

        public ICollection<Person> People { get; set; }
    }
}