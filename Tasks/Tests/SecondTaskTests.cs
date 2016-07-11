using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Tests
{
    [TestClass]
    public class SecondTaskTests
    {
        private SecondTask secondTask;

        private const string S1 = "my&friend&Paul has heavy hats! &";
        private const string S2 = "my friend John has many many friends &";
        private const string S3 = "mmmmm m nnnnn y&friend&Paul has heavy hats! &";
        private const string S4 = "my frie n d Joh n has ma n y ma n y frie n ds n&";


        [TestInitialize]
        public void Init()
        {
            secondTask = new SecondTask();
        }

        [TestMethod]
        public void SecondTask_WithS1AndS2_ReturnsCorrectString()
        {
            Assert.AreEqual("2:nnnnn/1:aaaa/1:hhh/2:mmm/2:yyy/=:ee/=:ss/2:dd/2:ff/2:ii/2:rr", secondTask.Mix(S1, S2));
        }

        [TestMethod]
        public void SecondTask_WithS3AndS4_ReturnsCorrectString()
        {
            Assert.AreEqual("=:nnnnnn/1:mmmmmm/1:aaaa/1:hhh/2:yyy/=:ee/=:ss/2:dd/2:ff/2:ii/2:rr", secondTask.Mix(S3, S4));
        }
    }
}
