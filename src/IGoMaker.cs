namespace Aspenlaub.Net.GitHub.CSharp.PakledCore {
    public interface IGoMaker {
        void MakeItGo(IThing thing);
        IThing DisassembleAndReassemble(IThing thing);
    }
}