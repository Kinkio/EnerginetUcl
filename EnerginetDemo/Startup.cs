using EnerginetDemo;
using EnerginetDemo.Application;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Application.Validators;
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
            builder.Services.AddScoped<ISampleMessageConverter, SampleMessageConverter>();
            builder.Services.AddScoped<ISampleMessageDeserializer, SampleMessageDeserializer>();
            builder.Services.AddScoped<ISampleMessageValidator, SampleMessageValidator>();
            builder.Services.AddScoped<ISampleMessageRepository, SampleMessageRepository>();
            builder.Services.AddScoped<ISampleMessageService, SampleMessageService>();

            builder.Services.AddDbContext<SampleMessageDbContext>((_, options) =>
            {
                SampleMessageDbContextFactory.ConfigureDbContext(options);
            });
        }
    }
}
