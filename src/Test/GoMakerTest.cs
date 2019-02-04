using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.PakledCore.Test {
    [TestClass]
    public class GoMakerTest {
        [TestMethod]
        public void CanMakeThingGo() {
            var brokenThing = new Thing {State = ThingState.Broken};
            var sut = new GoMaker();
            sut.MakeItGo(brokenThing);
            Assert.AreEqual(ThingState.Fixed, brokenThing.State);
        }

        [TestMethod]
        public void CanMakeThingByDisassemblingAndReassembling() {
            var brokenThing = new Thing { State = ThingState.Broken };
            var sut = new GoMaker();
            var reassembledThing = sut.DisassembleAndReassemble(brokenThing);
            Assert.AreEqual(ThingState.Fixed, reassembledThing.State);
        }
    }
}
