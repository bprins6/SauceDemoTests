using NUnit.Framework;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[TestFixture]
public class CheckoutTests : BaseTest
{
    [Test]
    [Order(4)]
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

        // Verify we're on the overview page
        Assert.That(await Page.Locator(".title").InnerTextAsync(), Is.EqualTo("Checkout: Overview"));

        // Finish order
        await Page.ClickAsync("#finish");

        // Verify checkout completed
        Assert.Multiple(async () =>
        {
            Assert.That(await Page.Locator(".title").InnerTextAsync(), Is.EqualTo("Checkout: Complete!"));

            Assert.That(await Page.Locator(".complete-header").InnerTextAsync(),
                Is.EqualTo("Thank you for your order!"));

            Assert.That(await Page.Locator(".complete-text").InnerTextAsync(),
                Does.Contain("Your order has been dispatched"));

            Assert.That(await Page.Locator("#back-to-products").IsVisibleAsync(), Is.True);
        });
    }
}