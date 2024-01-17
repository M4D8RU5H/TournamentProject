using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentProject.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

        public User User { get; set; }
    }
}