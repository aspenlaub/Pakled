using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled.Test;

[TestClass]
public class GoMakerTest {
    private IContainer _Container;

    [TestInitialize]
    public async Task Initialize() {
        _Container = (await new ContainerBuilder().UsePakledAsync()).Build();
    }

    [TestMethod]
    public void CanMakeThingGo() {
        var brokenThing = new Thing {State = ThingState.Broken};
        var sut = _Container.Resolve<IGoMaker>();
        sut.MakeItGo(brokenThing);
        Assert.AreEqual(ThingState.Fixed, brokenThing.State);
    }

    [TestMethod]
    public void CanMakeThingByDisassemblingAndReassembling() {
        var brokenThing = new Thing { State = ThingState.Broken };
        var sut = _Container.Resolve<IGoMaker>();
        var reassembledThing = sut.DisassembleAndReassemble(brokenThing);
        Assert.AreEqual(ThingState.Fixed, reassembledThing.State);
    }
}