using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;

namespace SauceDemoTests;

public static class ExtentReport
{
    private static readonly ExtentReports Extent;
    public static ExtentTest? Test;

    static ExtentReport()
    {
        // Get NUnit working directory
        string reportFolder = TestContext.CurrentContext.WorkDirectory;

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(reportFolder);

        // Full path to the report
        string reportPath = Path.Combine(reportFolder, "TestReport.html");

        // Display report location in the console
        Console.WriteLine($"======================================");
        Console.WriteLine($"Extent Report Location:");
        Console.WriteLine(reportPath);
        Console.WriteLine($"======================================");

        // Create the reporter
        var reporter = new ExtentSparkReporter(reportPath);

        reporter.Config.DocumentTitle = "SauceDemo Automation Report";
        reporter.Config.ReportName = "Playwright Test Execution Report";

        // Attach reporter
        Extent = new ExtentReports();
        Extent.AttachReporter(reporter);

        // System information
        Extent.AddSystemInfo("Framework", ".NET 10");
        Extent.AddSystemInfo("Automation Tool", "Microsoft Playwright");
        Extent.AddSystemInfo("Test Framework", "NUnit");
        Extent.AddSystemInfo("Browser", "Chromium");
        Extent.AddSystemInfo("Environment", "QA");
    }

    public static void CreateTest(string testName)
    {
        Test = Extent.CreateTest(testName);
    }

    public static void Flush()
    {
        Extent.Flush();
    }
}