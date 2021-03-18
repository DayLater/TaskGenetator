using NUnit.Framework;
using TaskEngine.Sets;
using TaskEngine.Writers;

namespace Tests
{
    [TestFixture]
    public class BorderSetWriterTests
    {
        [Test]
        public void WriteCharacteristicProperty()
        {
            var set = new IntBorderedSet("A", 2, BorderType.Close, 6, BorderType.Open);
            var writer = new BorderSetWriter();

            var result = writer.WriteCharacteristicProperty(set);
        }
    }
}