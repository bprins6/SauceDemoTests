using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace SauceDemoTests;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IPage Page;

    [SetUp]
    public async Task Setup()
    {
        ExtentReport.CreateTest(TestContext.CurrentContext.Test.Name);

        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 500
        });

        Page = await Browser.NewPageAsync();

        await Page.GotoAsync("https://www.saucedemo.com/");
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
        {
            ExtentReport.Test?.Pass("Test Passed");
        }
        else
        {
            ExtentReport.Test?.Fail(TestContext.CurrentContext.Result.Message);
        }

        ExtentReport.Flush();

        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}