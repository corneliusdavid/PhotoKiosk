using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoKiosk.Models
{
    public class Group
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Index("IX_GroupName")]
        public string GroupName { get; set; }

        public ICollection<Person> Member { get; set; }
    }
}