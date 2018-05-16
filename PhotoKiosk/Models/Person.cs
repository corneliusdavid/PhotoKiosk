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
        public string NickName { get; set; }

        public virtual int? GroupId { get; set; }
        public Group Group { get; set; }    

        public virtual int? PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}