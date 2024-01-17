using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentProject.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }

        public List<Comment> Comments { get; set; }
        public User User { get; set; }
    }
}