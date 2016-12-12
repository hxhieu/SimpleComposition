using SimpleComposition.Tests.Entities;
using Xunit;

namespace SimpleComposition.Tests
{
    [Trait("SimpleComposition", "Registration Tests")]
    public class RegistrationTests
    {
        [Fact]
        public void Entity_Create()
        {
            SimpleComposition.Instance.Register(GetType().Assembly).Build();

            var dog = SimpleComposition.Instance.Create<Dog>();

            Assert.NotNull(dog);
        }

        [Fact]
        public void Component_Create()
        {
            SimpleComposition.Instance.Register(GetType().Assembly).Build();

            var dog = SimpleComposition.Instance.Create<Dog>();

            Assert.NotNull(dog);
            Assert.NotNull(dog.Id);
        }

        [Fact]
        public void Component_SameType()
        {
            SimpleComposition.Instance.Register(GetType().Assembly).Build();

            var dog = SimpleComposition.Instance.Create<Dog>();

            Assert.NotNull(dog);
            Assert.NotNull(dog.Id);
            Assert.NotNull(dog.SecondId);
        }
    }
}
