using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace demoQA_playwright;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://demoqa.com/");
    }

    [Test]
    public async Task Test1()
    {
       

        await Page.ClickAsync("#app > div > div > div.home-body > div > div:nth-child(1) > div > div.avatar.mx-auto.white > svg");
     

        await Page.ClickAsync("(//span[@class='text'])[1]");
     


        await Page.FillAsync("#userName", "ben username");
        await Page.FillAsync("#userEmail", "oasd@gmail.com");
        await Page.FillAsync("#currentAddress", "ben currentAddress");

        await Page.ClickAsync("#submit");

        await screenShoot();

        //assert1
        var isExist = await Page.Locator("#name").IsVisibleAsync();
        Assert.IsTrue(isExist);

        //assert2
       await Expect(Page.Locator("#name")).ToBeVisibleAsync();

    }
    private async Task screenShoot()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });

    }
}