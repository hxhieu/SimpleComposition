using SimpleComposition.Abstracts;
using System;

namespace SimpleComposition.Tests.Components
{
    internal interface IIdentifier
    {
        string Name { get; set; }
        DateTime Dob { get; set; }
        int Age { get; }
    }

    internal class Identifier : IIdentifier, ITransientComponent
    {
        public int Age
        {
            get
            {
                return DateTime.Today.Year - Dob.Year;
            }
        }

        public DateTime Dob { get; set; }

        public string Name { get; set; }
    }
}
