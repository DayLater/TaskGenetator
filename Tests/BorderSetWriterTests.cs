using NUnit.Framework;
using TaskEngine;
using TaskEngine.Models.Sets;
using TaskEngine.Writers;

namespace Tests
{
    [TestFixture]
    public class BorderSetWriterTests
    {
        [Test]
        public void WriteCharacteristicProperty()
        {
            var startBorder = new SetBorder<int>(2, BorderType.Close);
            var endBorder = new SetBorder<int>(6, BorderType.Open);
            var set = new IntBorderedSet("A", startBorder, endBorder);
            var writer = new BorderSetWriter();

            var result = writer.WriteCharacteristicProperty(set);

            var expected = $"{{x | x {Symbols.Belongs} Z, 2{Symbols.LessOrEquals}x{Symbols.Less}6}}";
            StringAssert.Contains(expected, result);
        }
    }
}