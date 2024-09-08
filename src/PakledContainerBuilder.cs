using System.Threading.Tasks;
using Autofac;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public static class PakledContainerBuilder {
    public static async Task<ContainerBuilder> UsePakledAsync(this ContainerBuilder builder) {
        builder.RegisterType<GoMaker>().As<IGoMaker>();
        builder.RegisterInstance(Version.GetVersion());
        builder.RegisterInstance(await VersionSchema.GetVersionSchemaAsync()).As<IVersionSchema>();
        return builder;
    }
}