﻿using EnerginetDemo;
using EnerginetDemo.Application;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Application.Validators;
using EnerginetDemo.Common;
using EnerginetDemo.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace EnerginetDemo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISampleMessageConverter, SampleMessageConverter>();
            builder.Services.AddSingleton<ISampleMessageDeserializer, SampleMessageDeserializer>();
            builder.Services.AddSingleton<ISampleMessageValidator, SampleMessageValidator>();

            builder.Services.AddDbContext<SampleMessageDbContext>((_, options) =>
            {
                SampleMessageDbContextFactory.ConfigureDbContext(options);
            });
        }
    }
}
