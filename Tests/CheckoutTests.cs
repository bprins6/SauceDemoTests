using NUnit.Framework;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[TestFixture]
public class CheckoutTests : BaseTest
{
    [Test]
    public async Task CompleteCheckout()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);

        // Login
        await loginPage.Login("standard_user", "secret_sauce");

        // Add backpack
        await inventoryPage.AddBackpackToCart();

        // Open cart
        await Page.ClickAsync(".shopping_cart_link");

        // Checkout
        await Page.ClickAsync("#checkout");

        // Customer details
        await Page.FillAsync("#first-name", "Brandon");
        await Page.FillAsync("#last-name", "Prins");
        await Page.FillAsync("#postal-code", "2000");

        await Page.ClickAsync("#continue");

        // Finish order
        await Page.ClickAsync("#finish");

        // Verify success
        var message = await Page.Locator(".complete-header").InnerTextAsync();

        Assert.That(message, Is.EqualTo("Thank you for your order!"));
    }
}