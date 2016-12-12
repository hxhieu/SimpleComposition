using SimpleComposition.Abstracts;
using SimpleComposition.Tests.Components;

namespace SimpleComposition.Tests.Entities
{
    internal class Dog : IEntity
    {
        public IIdentifier Id { get; set; }
        public IIdentifier SecondId { get; set; }
    }
}
