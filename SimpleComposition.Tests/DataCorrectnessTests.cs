using SimpleComposition.Tests.Entities;
using System;
using Xunit;

namespace SimpleComposition.Tests
{
    [Trait("SimpleComposition", "Data Correctness Tests")]
    public class DataCorrectnessTests
    {
        [Fact]
        public void Identity_Age()
        {
            SimpleComposition.Instance.Register(GetType().Assembly).Build();

            var dog = SimpleComposition.Instance.Create<Dog>();

            Assert.NotNull(dog);
            Assert.NotNull(dog.Id);
            Assert.NotNull(dog.SecondId);

            int age = 7;
            dog.Id.Dob = DateTime.Today.AddYears(7);

            Assert.Equal(age, dog.Id.Age);
        }
    }
}
