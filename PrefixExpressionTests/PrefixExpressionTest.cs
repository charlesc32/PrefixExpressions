using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrefixExpressionTests
{
    [TestClass]
    public class PrefixExpressionTest
    {
        [TestMethod]
        public void EvauluatePrefixExpressionTest()
        {
            Assert.AreEqual(Program.EvaluatePrefixExpression("* + 2 3 4"), 20);
            Assert.AreEqual(Program.EvaluatePrefixExpression("/ 10 5"), 2);
        }
    }
}
