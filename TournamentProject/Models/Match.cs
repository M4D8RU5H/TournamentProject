using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentProject.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public int? WinnerId { get; set; }
        public int Score { get; set; }
        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        [Required]
        public int Phase { get; set; }

        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public Team? WinnerTeam { get; set; }
    }
}