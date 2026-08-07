using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTests;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IPage Page;

    [SetUp]
    public async Task Setup()
    {
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
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}