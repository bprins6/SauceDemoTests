# SauceDemo UI Automation Tests

## Overview

This project contains a simple UI automation framework built using **C#**, **Playwright**, and **NUnit**.

The framework automates the core user journeys on the SauceDemo website:

* Successful Login
* Unsuccessful Login
* Add Item to Basket
* Complete Checkout

Website Tested:
https://www.saucedemo.com/

---

## Technologies Used

* C#
* .NET 10
* Microsoft Playwright
* NUnit
* Visual Studio Code

---

## Project Structure

```
SauceDemoTests
│
├── Pages
│   ├── LoginPage.cs
│   └── InventoryPage.cs
│
├── Tests
│   ├── LoginTests.cs
│   ├── BasketTests.cs
│   └── CheckoutTests.cs
│
├── BaseTest.cs
├── SauceDemoTests.csproj
└── README.md
```

---

## Test Scenarios

### Successful Login

* Navigate to the login page
* Enter valid credentials
* Verify the user is successfully logged in

### Unsuccessful Login

* Enter invalid credentials
* Verify the error message is displayed

### Add Item to Basket

* Login with a valid user
* Add the Sauce Labs Backpack to the cart
* Verify the cart badge displays one item

### Complete Checkout

* Login
* Add an item to the cart
* Complete the checkout process
* Verify the order confirmation message

---

## How to Run

1. Clone the repository

2. Restore NuGet packages

```
dotnet restore
```

3. Build the project

```
dotnet build
```

4. Install Playwright browsers

```
.\bin\Debug\net10.0\playwright.ps1 install
```

5. Run all tests

```
dotnet test
```

---

## Notes

* The project uses the Page Object Model (POM) to separate page interactions from test logic.
* The browser runs in headed mode (`Headless = false`) so the test execution can be observed.
* The framework has been intentionally kept simple for readability and ease of maintenance.
