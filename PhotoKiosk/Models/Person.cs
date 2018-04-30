using System.ComponentModel.DataAnnotations;

namespace PhotoKiosk.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string MiddleName { get; set; }

        [StringLength(100)]
        public string NickName { get; set; }

        public Photo Photo { get; set; }

        public int PhotoID { get; set; }    
    }
}