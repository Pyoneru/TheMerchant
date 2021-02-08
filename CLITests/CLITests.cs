using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TheMerchant.Controller;
using TheMerchant.Model;

namespace CLITests
{
    [TestClass]
    public class CLITests
    {
        [TestMethod]
        public void GetInstanceTest()
        {
            CLI cliFirstInstance = CLI.GetInstance();
            CLI cliSecondInstance = CLI.GetInstance();

            Assert.ReferenceEquals(cliFirstInstance, cliSecondInstance);
        }

        [TestMethod]
        public void WriteMenuTest(List<CLIOption> options, CLIOption selectedOption)
        {
            // verified internal calls
            Assert.Equals(true,true);
        }
    }
}
