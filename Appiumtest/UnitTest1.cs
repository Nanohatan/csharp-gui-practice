using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Appiumtest;

public class Tests
{
    private IOSDriver _driver = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var deviceName = Environment.GetEnvironmentVariable("DEVICE_NAME")
            ?? throw new InvalidOperationException("DEVICE_NAME is not set.");

        var udid = Environment.GetEnvironmentVariable("UDID")
            ?? throw new InvalidOperationException("UDID is not set.");

        var bundleId = Environment.GetEnvironmentVariable("BUNDLE_ID")
            ?? throw new InvalidOperationException("BUNDLE_ID is not set.");

        var appiumHost = Environment.GetEnvironmentVariable("APPIUM_HOST")
            ?? "http://127.0.0.1:4723/";

        var options = new AppiumOptions
        {
            AutomationName = "XCUITest",
            PlatformName = "iOS",
            DeviceName = deviceName
        };

        options.AddAdditionalAppiumOption("udid", udid);
        options.AddAdditionalAppiumOption("bundleId", bundleId);

        _driver = new IOSDriver(
            new Uri(appiumHost),
            options,
            TimeSpan.FromSeconds(180)
        );
    }

    [Test]
    public void Home_ToProductEdit_NavigatesSuccessfully()
    {
        var button = FindDisplayedElement("Home_ProductEditButton");

        Assert.That(button.Enabled, Is.True);
        button.Click();

        var productNameEntry = FindDisplayedElement("ProductNameEntry");

        Assert.That(productNameEntry.Displayed, Is.True);
    }

    private AppiumElement FindDisplayedElement(
        string accessibilityId,
        int timeoutSeconds = 10)
    {
        var timeoutAt = DateTime.UtcNow.AddSeconds(timeoutSeconds);
        WebDriverException? lastException = null;

        do
        {
            try
            {
                var element = _driver.FindElement(
                    MobileBy.AccessibilityId(accessibilityId));

                if (element.Displayed)
                {
                    return element;
                }
            }
            catch (WebDriverException ex)
            {
                lastException = ex;
            }

            Thread.Sleep(200);
        }
        while (DateTime.UtcNow < timeoutAt);

        throw new AssertionException(
            $"AccessibilityId '{accessibilityId}' was not displayed " +
            $"within {timeoutSeconds} seconds.",
            lastException);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}
