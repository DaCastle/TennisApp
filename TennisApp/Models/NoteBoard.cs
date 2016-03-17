using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TennisApp.Models
{
    public class NoteBoard
    {
        [Key]
        public int eventId { get; set; }
        [Display (Name = "Note")]
        public string note { get; set; }
        [Display (Name = "User")]
        public string userName { get; set; }
        [Display (Name = "Date")]
        public DateTime date { get; set; }
    }
}