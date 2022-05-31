﻿using Lombiq.BaseTheme.Tests.UI.Extensions;
using Lombiq.Tests.UI.Attributes;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using Microsoft.SqlServer.Management.Dmf;
using OpenQA.Selenium;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Lombiq.OSOCE.Tests.UI.Tests;

public class BehaviorBaseThemeTests : UITestBase
{
    public BehaviorBaseThemeTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Theory, Chrome]
    public Task ThemeFeaturesShouldWork(Browser browser) =>
        ExecuteTestAfterSetupAsync(
            async context =>
            {
                await context.SignInDirectlyAndGoToHomepageAsync();
                await context.TestBaseThemeFeaturesAsync();
            },
            browser);

    [Theory, Chrome]
    public Task TestAdminBackgroundTasksAsMonkeyRecursivelyShouldWorkWithAdminUserTestAdminBackgroundTasksAsMonkeyRecursivelyShouldWorkWithAdminUser(
        Browser browser) =>
        ExecuteTestAfterSetupAsync(
            async context =>
            {
                await context.GoToRelativeUrlAsync("/nasdjklandasjlasjlsd");
                await context.GoToHomePageAsync();
                context.Get(By.Id("nasdjklandasjlasjlsd"));
            },
            browser);
}
