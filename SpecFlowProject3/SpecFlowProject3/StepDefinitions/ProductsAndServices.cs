using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject3.PageMaps;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject3.StepDefinitions
{

    [Binding]
    public class ProductsAndServices
    {
        private readonly IWebDriver driver;
        private readonly CurrentAccount currentAccountPage;

        // private readonly ScenarioContext _scenarioContext;
        public ProductsAndServices(IWebDriver driver)
        {
            // Assign 'driver' to private field or use it to initialize a page object
            this.driver = driver;

            // Initialize Selenium page object
            this.currentAccountPage = new CurrentAccount(driver);
        }

        [Given(@"the user click on product and services tab")]
        public void GivenAUserClickOnProductAndServicesTab()
        {
            WaitForLoading();
            currentAccountPage.ProductAndServicesTab.Click();
        }

        [When(@"the user click on current accounts from the dropdown")]
        public void GivenTheUserClickOnCurrentAccountsFromTheDropdown()
        {
            currentAccountPage.CurrentAccountButton.Click();
        }

        [Then(@"the user land on the correct page")]
        public void ThenTheUserLandOnTheCorrrectPage()
        {
            WaitForLoading();
            var headerText = currentAccountPage.CurrentAccountHeader.Text;
            Assert.IsTrue(headerText.Contains("Current Accounts"), "the header text shows current account");
        }

        [Then(@"the user can see three current account products")]
        public void ThenTheUserCanSeeThreeCurrentAccountProducts()
        {
            WaitForLoading();
            ScrollTo(currentAccountPage.ClassicAccountProduct);

            var classicAccount = currentAccountPage.ClassicAccountProduct.Text;
            Assert.IsTrue(classicAccount.Contains("Classic account"), "classic account product is visible");

            var clubLlyodsAccount = currentAccountPage.ClubLyodsAccountProduct.Text;
            Assert.IsNotNull(clubLlyodsAccount, "Club Lloyds account product is visible");

            var platinumAccount = currentAccountPage.PlatinumAccountProduct.Text;
            Assert.IsNotNull(platinumAccount, "Platinum account product is visible");
        }

        [Then(@"the fees of platinum accout is £(.*) per month")]
        public void ThenTheFeesOfPlatinumAccoutIsPerMonth(int fees)
        {
            WaitForLoading();
            var platinumAccountContent = currentAccountPage.PlatinumAccountContent;
            Assert.IsTrue(platinumAccountContent.Text.Contains($"£{fees} per month"));
        }

        internal void WaitForLoading(int Seconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            Thread.Sleep(200);
        }

        public void ScrollTo(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", element);
        }
    }



}