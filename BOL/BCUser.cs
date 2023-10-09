using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("BCUser")]
    public class BCUser
    {
        [Key]
        public int Eid { get; set; }

        [Required]
        public string? EName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


        [Required]
        public DateTime DOB { get; set; }

        
        [Required]
        public String Address { get; set; }


    }
}