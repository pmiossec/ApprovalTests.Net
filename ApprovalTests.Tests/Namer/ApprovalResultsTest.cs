using ApprovalTests.Namers;
using NUnit.Framework;

namespace ApprovalTests.Tests.Namer
{
    [TestFixture]
    public class ApprovalResultsTest
    {
        [Test]
        public void TestEasyNames()
        {
            // populate from https://en.wikipedia.org/wiki/List_of_Microsoft_Windows_versions
            var osversions = new[] { "Microsoft Windows 6.1.7601 S" };
            Approvals.VerifyAll("EasyNames", osversions, v => $"{v} -> {ApprovalResults.TransformEasyOsName(v)}");


        }
    }
}