using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task Login(string username, string password)
    {
        await _page.FillAsync("#user-name", username);
        await _page.FillAsync("#password", password);
        await _page.ClickAsync("#login-button");
    }

    public async Task<string> GetErrorMessage()
    {
        return await _page.Locator("[data-test='error']").InnerTextAsync();
    }
}