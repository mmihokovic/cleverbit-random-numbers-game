using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Seed { get; set; }     
        public List<PlayerMatch> PlayerMatches { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
