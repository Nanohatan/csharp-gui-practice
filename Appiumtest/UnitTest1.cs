using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Appiumtest;

public class Tests
{
    private IOSDriver _driver = null!;

    [OneTimeSetUp]
    public void SetUp()
    {
        var serverUri = new Uri(
            Environment.GetEnvironmentVariable("APPIUM_HOST")
            ?? "http://127.0.0.1:4723/"
        );

        var driverOptions = new AppiumOptions
        {
            AutomationName = "XCUITest",
            PlatformName = "iOS",
            DeviceName = "iPad Air 11-inch (M4)"
        };

        driverOptions.AddAdditionalAppiumOption(
            "bundleId",
            "com.companyname.omamagotoapp"
        );

        driverOptions.AddAdditionalAppiumOption(
            "noReset",
            true
        );

        _driver = new IOSDriver(
            serverUri,
            driverOptions,
            TimeSpan.FromSeconds(180)
        );

        _driver.Manage()
            .Timeouts()
            .ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    [Test]
    public void TestApp()
    {
        var element = _driver.FindElement(
            MobileBy.AccessibilityId("Home_ProductEditButton")
        );

        element.Click();
    }
}