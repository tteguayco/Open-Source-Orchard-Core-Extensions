using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLogHost();

var configuration = builder.Configuration;

// Here we're adding the configuration to builder services. It will be used for configuring the UI Testing Toolbox
// (https://github.com/Lombiq/UI-Testing-Toolbox) so UI tests can be executed on the app. For a tutorial on how to
// create UI tests check out the project.
builder.Services
    .AddSingleton(configuration)
    .AddOrchardCms(orchardCoreBuilder =>
        orchardCoreBuilder.ConfigureFeaturesGuard(
            new Dictionary<string, IEnumerable<string>>
            {
                ["OrchardCore.Twitter"] = new[] { "Lombiq.UIKit", "Lombiq.ChartJs" },
            }));

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();
app.Run();

string path = Path.Combine(Environment.CurrentDirectory, "App_Data\\Testing.txt");

using (var sw = File.CreateText(path))
{
    var time = DateTime.Now.ToString("G", CultureInfo.InvariantCulture);
    sw.WriteLine(time + " - The app started.");
}

[SuppressMessage(
    "Design",
    "CA1050: Declare types in namespaces",
    Justification = "As described here: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0.")]
public partial class Program
{
    protected Program()
    {
        // Nothing to do here.
    }
}
