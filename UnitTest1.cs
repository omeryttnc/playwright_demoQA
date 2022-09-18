using Microsoft.Playwright;

namespace demoQA_playwright;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://demoqa.com/");
        await page.ClickAsync("#app > div > div > div.home-body > div > div:nth-child(1) > div > div.avatar.mx-auto.white > svg");


        await page.ClickAsync("(//span[@class='text'])[1]");



        await page.FillAsync("#userName", "ben username");
        await page.FillAsync("#userEmail", "oasd@gmail.com");
        await page.FillAsync("#currentAddress", "ben currentAddress");

        await page.ClickAsync("#submit");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });

        var isExist = await page.Locator("#name").IsVisibleAsync();
        Assert.IsTrue(isExist);


    }
}