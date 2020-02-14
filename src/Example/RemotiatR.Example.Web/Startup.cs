﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RemotiatR.Client;
using RemotiatR.Example.Shared;
using System;
using RemotiatR.Example.Shared.Features.Info;
using AutoMapper.QuickMaps.Configuration;
using RemotiatR.Client.Configuration;
using AutoMapper.QuickMaps.MappingMatchers;
using RemotiatR.Client.FluentValidation.Configuration;

namespace RemotiatR.Example.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.CreateQuickMaps(y =>
            {
                y.AddAssemblies(typeof(Program), typeof(SharedMarker));
                y.AddMappingMatchers(
                    DefaultMappingMatchers.TypeNameMatcher("{action}_{model}+Response", "{view}+{model}ViewModel"),
                    DefaultMappingMatchers.TypeNameMatcher("{view}+{model}ViewModel", "{action}_{model}+Request")
                );
            }), typeof(Program));

            services.AddRemotiatr(x =>
            {
                x.AddAssemblies(typeof(SharedMarker));
                x.SetBaseUri(new Uri("https://localhost:44339"));
                x.SetUriBuilder(Defaults.UriBuilder);
                x.Services.AddFluentValidation(typeof(Program), typeof(SharedMarker));
            });
        }

        public void Configure(IServiceProvider services)
        {
            // Pings the server to wake it up
            services.GetRequiredService<IRemotiatr>().Send(new Ping_Info.Request());
        }
    }
}
