using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Autofac;
using Json.More;
using Json.Schema;
using Json.Schema.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled.Test;

[TestClass]
public class VersionTest {
    private IContainer _Container;

    [TestInitialize]
    public async Task Initialize() {
        _Container = (await new ContainerBuilder().UsePakledAsync()).Build();
    }

    [TestMethod]
    public void CanGetVersion() {
        var version = _Container.Resolve<IVersion>();
        Assert.AreEqual(2, version.Major);
        Assert.AreEqual(4, version.Minor);
    }

    [TestMethod]
    public void VersionSchemaIsCorrect() {
        var builder = new JsonSchemaBuilder();
        var schemaAsDocument = builder.FromType<Version>().Build().ToJsonDocument();
        var options = new JsonWriterOptions {
            Indented = true
        };
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream, options);
        schemaAsDocument.WriteTo(writer);
        writer.Flush();
        var schemaAsString = Encoding.UTF8.GetString(stream.ToArray());
        var versionSchema = _Container.Resolve<IVersionSchema>();
        Assert.AreEqual(schemaAsString, versionSchema.VersionSchemaAsString);
    }
}