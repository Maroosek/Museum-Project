using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzeum.Domain.DomainExceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException(DateTime DataUrodzin) : base(ModifyMessage(DataUrodzin)) 
        {
        }

        private static string ModifyMessage (DateTime DataUrodzin) 
        {
            return $"Niewlasciwa data urodzin {DataUrodzin}.";
        }
    }
}
