using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentProject.Models
{
    public class Tournament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime TournamentDate { get; set; }
        [Required]
        public int MaxTeamAmount { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime RegistrationStarts { get; set; }
        [Required]
        public DateTime RegistrationEnds { get; set; }
        public int Status { get; set; }
        public string LiveTransmisionEmbed { get; set; }

        public List<TournamentTeam> Tournament_Teams { get; set; }
        public List<Match> Matches { get; set; }

    }
}