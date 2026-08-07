using NUnit.Framework;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[TestFixture]
public class BasketTests : BaseTest
{
    [Test]
    [Order(3)]
    public async Task AddItemToBasket()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);

        await loginPage.Login("standard_user", "secret_sauce");

        await inventoryPage.AddBackpackToCart();

        Assert.That(await inventoryPage.GetCartCount(), Is.EqualTo("1"));
    }
}