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
        public string player1 { get; set; }
        public string player2 { get; set; }
        [DataType(DataType.DateTime)]
        public string date { get; set; }
        public string gameScore { get; set; }
    }
}