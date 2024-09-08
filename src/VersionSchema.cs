using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public class VersionSchema : IVersionSchema {
    public string VersionSchemaAsString { init; get; }

    private const string SchemaUrl = "https://www.aspenlaub.net/schemas/versionSchemaMajMin.json";

    public static async Task<IVersionSchema> GetVersionSchemaAsync() {
        var client = new HttpClient();
        var response = await client.GetAsync(SchemaUrl);
        var versionSchemaAsString = response.StatusCode == HttpStatusCode.OK
            ? await response.Content.ReadAsStringAsync()
            : "";
        var versionSchema = new VersionSchema {
            VersionSchemaAsString = versionSchemaAsString
        };
        return versionSchema;
    }
}