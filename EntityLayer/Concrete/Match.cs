using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public int? HomeTeamsId { get; set; }
        public int? GuesteamsId { get; set; }
        public string MatchDate { get; set; }
        public string Stadium { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuesTime { get; set; }
    }
}
