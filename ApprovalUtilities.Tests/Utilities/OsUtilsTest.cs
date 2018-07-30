using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApprovalUtilities.Tests.Utilities
{
    [TestClass]
    public class OsUtilsTest
    {
        // [Ignore]
        [TestMethod]
        public void DemoOsName()
        {
            
            Assert.AreEqual("Microsoft Windows 10.0.17134", OsUtils.GetFullOsNameFromWmi());
        }
    }
}