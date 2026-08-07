# SauceDemo UI Automation Framework

## Overview

This project is a UI automation framework developed as part of a technical assessment using **C#**, **Microsoft Playwright**, and **NUnit**.

The framework automates the core user journeys on the SauceDemo website while following the **Page Object Model (POM)** design pattern for improved maintainability and code reuse.

**Application Under Test**

https://www.saucedemo.com/

---

## Technologies Used

* C#
* .NET 10
* Microsoft Playwright
* NUnit
* ExtentReports
* Visual Studio Code

---

## Project Structure

```text
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
├── ExtentReport.cs
├── SauceDemoTests.csproj
└── README.md
```

---

## Automated Test Scenarios

### Successful Login

* Navigate to SauceDemo.
* Login with valid credentials.
* Verify the Products page is displayed.

### Unsuccessful Login

* Login with invalid credentials.
* Verify the appropriate error message is displayed.

### Add Item to Basket

* Login with valid credentials.
* Add the Sauce Labs Backpack to the shopping cart.
* Verify the shopping cart badge displays one item.

### Complete Checkout

* Login with valid credentials.
* Add an item to the shopping cart.
* Complete the checkout process.
* Verify the checkout completed successfully.
* Verify the order confirmation message is displayed.

---

## Running the Tests

### 1. Restore NuGet packages

```bash
dotnet restore
```

### 2. Build the project

```bash
dotnet build
```

### 3. Install Playwright browsers

```powershell
.\bin\Debug\net10.0\playwright.ps1 install
```

### 4. Execute all tests

```bash
dotnet test
```

---

## Test Report

An Extent HTML report is automatically generated after the test execution.

The report includes:

* Test summary
* Passed and failed test results
* Execution time
* Failure details
* System information

The report is generated in the NUnit working directory after the tests complete successfully.

---

## Design Pattern

This project follows the * (POM)** design pattern.

* Reusable page methods


