using NUnit.Framework;
using TaskEngine;
using TaskEngine.Sets;
using TaskEngine.Writers;

namespace Tests
{
    [TestFixture]
    public class ExpressionWriterTests
    {
        private readonly ExpressionWriter _expressionWriter = new ExpressionWriter();

        [Test]
        public void Write()
        {
            for (int index = 0; index < 2; index++)
            {
                var index1 = index;
                var set = new ExpressionSet<int>("A", i => index1 * i, 10);

                var result = _expressionWriter.Write(set.Expression);

                StringAssert.Contains($"{{x | x = ({index} * x), x ∈ Z}}", result);
            }
        }
    }
}