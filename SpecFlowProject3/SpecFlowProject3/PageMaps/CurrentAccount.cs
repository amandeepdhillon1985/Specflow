using OpenQA.Selenium;
using System.Linq;

namespace SpecFlowProject3.PageMaps
{
    public class CurrentAccount
    {
        private IWebDriver driver;

        public CurrentAccount(IWebDriver driver)
        {
            this.driver=driver;
        }

        public IWebElement ProductAndServicesTab => driver.FindElement(By.PartialLinkText("Products and services"));

        public IWebElement CurrentAccountButton => driver.FindElement(By.PartialLinkText("Current accounts"));

        public IWebElement CurrentAccountHeader => driver.FindElement(By.CssSelector("h1.header-text"));

        public IWebElement ClassicAccountProduct => driver.FindElements(By.CssSelector("div.heading-container")).First();

        public IWebElement ClubLyodsAccountProduct => driver.FindElement(By.XPath("//span[.='Club Lloyds account']"));

        public IWebElement PlatinumAccountProduct => driver.FindElement(By.XPath("//span[.='Platinum account']"));

        public IWebElement PlatinumAccountContent => driver.FindElements(By.CssSelector("span.rte-body--large-text")).Last();

    }
}
