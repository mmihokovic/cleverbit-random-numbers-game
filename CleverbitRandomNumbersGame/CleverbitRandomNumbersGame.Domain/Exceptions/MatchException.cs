using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain.Exceptions
{
    public class MatchException : Exception
    {
        public MatchException(string message): base(message)
        {

        }
    }
}
