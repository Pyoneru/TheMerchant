using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TheMerchant.Model;

namespace CLITests
{
    [TestClass]
    public class CLIOptionTests
    {
        private void SampleOptionMethod()
        {
        }

        [TestMethod]
        public void CreateOptionTest()
        {
            CLIOption cliOption = new CLIOption("Buy product",SampleOptionMethod);

            Assert.AreEqual("Buy product", cliOption.Name);
            Assert.ReferenceEquals((Action)SampleOptionMethod, cliOption.Action);
        }
    }
}
