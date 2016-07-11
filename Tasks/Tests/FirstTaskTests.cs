using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tasks.Tests
{
    [TestClass]
    public class FirstTaskTests
    {
        private FirstTask firstTask;

        private const string VALID_STRING1 = "(){}[]";
        private const string VALID_STRING2 = "([{}])";
        private const string INVALID_STRING1 = "[(])";
        private const string INVALID_STRING2 = "(}";

        [TestInitialize]
        public void Init()
        {
            firstTask = new FirstTask();
        }

        [TestMethod]
        public void FirstTask_WithValidString1_ReturnsTrue()
        {
            Assert.IsTrue(firstTask.validBraces(VALID_STRING1));
        }

        [TestMethod]
        public void FisrtTask_WithValidString2_ReturnsTrue()
        {
            Assert.IsTrue(firstTask.validBraces(VALID_STRING2));
        }

        [TestMethod]
        public void FisrtTask_WithInvalidString1_ReturnsFalse()
        {
            Assert.IsFalse(firstTask.validBraces(INVALID_STRING1));
        }

        [TestMethod]
        public void FisrtTask_WithInvalidString2_ReturnFalse()
        {
            Assert.IsFalse(firstTask.validBraces(INVALID_STRING2));
        }

        [TestMethod]
        public void FirstTask_WithNullString_ReturnFalse()
        {
            Assert.IsFalse(firstTask.validBraces(null));
        }

        [TestMethod]
        public void FirstTask_WithWhiteSpaceString_ReturnFalse()
        {
            Assert.IsFalse(firstTask.validBraces(" "));
        }
    }
}
