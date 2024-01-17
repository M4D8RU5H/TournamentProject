using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentProject.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public DateTime BannedUntill { get; set; }
        public string Rank { get; set; }

        public List<TeamUser> Team_Users { get; set; }

        public UserRole Role { get; set; }

        public List<Message> Messages { get; set; }

        public List<Report> Reports { get; set; } 
    }
}