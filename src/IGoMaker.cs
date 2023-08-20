namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public interface IGoMaker {
    void MakeItGo(IThing thing);
    IThing DisassembleAndReassemble(IThing thing);
}