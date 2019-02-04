using Newtonsoft.Json;

namespace Aspenlaub.Net.GitHub.CSharp.PakledCore {
    public class GoMaker {
        public void MakeItGo(IThing thing) {
            thing.State = ThingState.Fixed;
        }

        public IThing DisassembleAndReassemble(IThing thing) {
            var disassembledThing = JsonConvert.SerializeObject(thing);
            const string propertyName = nameof(thing.State);
            const int brokenState = (int) ThingState.Broken;
            const int fixedState = (int) ThingState.Fixed;
            disassembledThing = disassembledThing.Replace($"\"{propertyName}\":{brokenState}", $"\"{propertyName}\":{fixedState}");
            var reassembledThing = JsonConvert.DeserializeObject<Thing>(disassembledThing);
            return reassembledThing;
        }
    }
}
