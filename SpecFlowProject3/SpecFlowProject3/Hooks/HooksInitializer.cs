using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject3
{
    [Binding]
    public sealed class HooksInitializer
    {
        private readonly IObjectContainer container;

        public HooksInitializer(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario("browser", Order = 1)]
        public void CreateWebDriver()
        {
            ChromeDriver driver = new ChromeDriver();

            // Make 'driver' available for DI
            container.RegisterInstanceAs<IWebDriver>(driver);

            // navigate to url
            driver.Navigate().GoToUrl("https://www.lloydsbank.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}