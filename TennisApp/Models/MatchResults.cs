using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TennisApp.Models
{
    public class MatchResults
    {
        [Key]
        public int MatchId { get; set; }
        [Display(Name = "Player 1")]
        public string player1 { get; set; }
        [Display(Name = "Player 2")]
        public string player2 { get; set; }
        [Display(Name = "Match Date")]
        public string matchDate { get; set; }
        [Display(Name = "Set Scores")]
        public string setScore { get; set; }
        [Display (Name = "Added By")]
        public string addedBy { get; set; }
    }
}