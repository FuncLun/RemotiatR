﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace RemotiatR.Client
{
    public interface IAddRemotiatrOptions
    {
        IServiceCollection Services { get; }

        IAddRemotiatrOptions SetUriBuilder(Func<Type, Uri> uriBuilder);

        IAddRemotiatrOptions SetBaseUri(Uri baseUri);

        IAddRemotiatrOptions AddAssemblies(params Assembly[] assembliesToScan);

        IAddRemotiatrOptions AddAssemblies(params Type[] assemblyTypeMarkers);
    }
}
