using Lombiq.HelpfulExtensions.Tests.UI.Extensions;
using Lombiq.Tests.UI.Attributes;
using Lombiq.Tests.UI.Services;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Lombiq.OSOCE.Tests.UI.Tests.ModuleTests;

public class BehaviorHelpfulExtensionsTests : UITestBase
{
    public BehaviorHelpfulExtensionsTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Theory(Skip = "Not needed for troubleshooting."), Chrome]
    public Task FeatureFlow(Browser browser) =>
        ExecuteTestAfterSetupAsync(
            context => context.TestFlowAdditionalStylingPartAsync(),
            browser);

    [Theory(Skip = "Not needed for troubleshooting."), Chrome]
    public Task FeatureWidgets(Browser browser) =>
        ExecuteTestAfterSetupAsync(
            context => context.TestFeatureWidgetsAsync(),
            browser);

    [Theory(Skip = "Not needed for troubleshooting."), Chrome]
    public Task FeatureCodeGeneration(Browser browser) =>
        ExecuteTestAfterSetupAsync(
            context => context.TestFeatureCodeGenerationsAsync(),
            browser);
}
