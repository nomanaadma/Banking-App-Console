using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App_Console.Entities
{
    internal class Option
    {
        public int Id { get; init; }
        public required string Msg { get; init; }
        public required string Value { get; init; }
    }
}
