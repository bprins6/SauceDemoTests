using NUnit.Framework;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    [Order(1)]
    public async Task SuccessfulLogin()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);

        await loginPage.Login("standard_user", "secret_sauce");

        Assert.That(await inventoryPage.IsInventoryPageDisplayed(), Is.True,
            "The Products page was not displayed after login.");
    }

    [Test]
    [Order(2)]
    public async Task InvalidLogin()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.Login("wrong_user", "wrong_password");

        var error = await loginPage.GetErrorMessage();

        Assert.That(error, Does.Contain("Username and password do not match"));
    }
}