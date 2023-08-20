using Newtonsoft.Json;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public class GoMaker : IGoMaker {
    public void MakeItGo(IThing thing) {
        thing.State = ThingState.Fixed;
    }

    public IThing DisassembleAndReassemble(IThing thing) {
        var disassembledThing = Disassemble(thing);
        var reassembledThing = Reassemble(disassembledThing);
        return reassembledThing;
    }

    private string Disassemble(IThing thing) {
        var disassembledThing = JsonConvert.SerializeObject(thing);
        const string propertyName = nameof(thing.State);
        const int brokenState = (int)ThingState.Broken;
        const int fixedState = (int)ThingState.Fixed;
        return disassembledThing.Replace($"\"{propertyName}\":{brokenState}", $"\"{propertyName}\":{fixedState}");
    }

    private Thing Reassemble(string disassembledThing) {
        return JsonConvert.DeserializeObject<Thing>(disassembledThing);
    }
}