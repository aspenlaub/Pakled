﻿using Autofac;

namespace Aspenlaub.Net.GitHub.CSharp.Pakled;

public static class PakledCoreContainerBuilder {
    public static ContainerBuilder UsePakledCore(this ContainerBuilder builder) {
        builder.RegisterType<GoMaker>().As<IGoMaker>();
        return builder;
    }
}