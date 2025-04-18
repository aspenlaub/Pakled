using System.Threading.Tasks;
using Autofac;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public static class PakledContainerBuilder {
    public static async Task<ContainerBuilder> UsePakledAsync(this ContainerBuilder builder) {
        builder.RegisterType<GoMaker>().As<IGoMaker>();
        return await Task.FromResult(builder);
    }
}