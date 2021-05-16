using System;
using System.Linq;
using NUnit.Framework;
using TaskEngine.Generators.SetGenerators;

namespace Tests
{
    [TestFixture]
    public class IntMathSetGeneratorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void CountReturnsThatElementsCount(int count)
        {
            var generator = new IntMathSetGenerator(new Random()) {Count = count};
            for (int i = 0; i < 100000; i++)
            {
                var set = generator.Generate("a");
                Assert.AreEqual(count, set.GetElements().Count());
            }
        }
    }
}