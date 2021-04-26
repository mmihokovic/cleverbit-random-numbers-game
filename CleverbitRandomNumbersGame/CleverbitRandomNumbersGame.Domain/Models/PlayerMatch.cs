using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain.Models
{
    public class PlayerMatch
    {
        public int Id { get; set; }
        public User Player { get; set; }
        public int Number { get; set; }
        public DateTime? PlayDate { get; set; }
    }
}
