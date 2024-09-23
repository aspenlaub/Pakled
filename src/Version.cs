using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public class Version : IVersion {
    public int Major { init; get; }
    public int Minor { init; get; }

    public static IVersion GetVersion() {
        var defaultVersion = new Version {
            Major = 0,
            Minor = 0
        };
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "Aspenlaub.Net.GitHub.CSharp.Pakled.version.json";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) { return defaultVersion; }

        using var reader = new StreamReader(stream);
        return JsonSerializer.Deserialize<Version>(reader.ReadToEnd());
    }
}