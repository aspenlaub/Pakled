using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.PakledCore.Test {
    [TestClass]
    public class StrongThingTest {
        [TestMethod]
        public void StrongThingIsStrong() {
            var sut = new StrongThing();
            Assert.IsTrue(sut.IsStrong);
        }
    }
}
