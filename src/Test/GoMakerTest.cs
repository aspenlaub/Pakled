using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled.Test;

[TestClass]
public class GoMakerTest {
    private readonly IContainer vContainer;

    public GoMakerTest() {
        vContainer = new ContainerBuilder().UsePakledCore().Build();
    }

    [TestMethod]
    public void CanMakeThingGo() {
        var brokenThing = new Thing {State = ThingState.Broken};
        var sut = vContainer.Resolve<IGoMaker>();
        sut.MakeItGo(brokenThing);
        Assert.AreEqual(ThingState.Fixed, brokenThing.State);
    }

    [TestMethod]
    public void CanMakeThingByDisassemblingAndReassembling() {
        var brokenThing = new Thing { State = ThingState.Broken };
        var sut = vContainer.Resolve<IGoMaker>();
        var reassembledThing = sut.DisassembleAndReassemble(brokenThing);
        Assert.AreEqual(ThingState.Fixed, reassembledThing.State);
    }
}