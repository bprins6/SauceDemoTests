using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    public async Task AddBackpackToCart()
    {
        await _page.ClickAsync("#add-to-cart-sauce-labs-backpack");
    }

    public async Task<string> GetCartCount()
    {
        return await _page.Locator(".shopping_cart_badge").InnerTextAsync();
    }

    public async Task<bool> IsInventoryPageDisplayed()
    {
        return await _page.Locator(".title").InnerTextAsync() == "Products";
    }
}