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
            var set = new ExpressionSet<int>("A",i => 2 * i, 10);

            var result = _expressionWriter.Write(set.Expression); 
            
            StringAssert.Contains("{x | x = (2 * x), x ∈ Z}", result);
        }
    }
}