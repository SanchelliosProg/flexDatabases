using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static FlexDatabases.Helpers.ProductsSelectors;

namespace FlexDatabases.Helpers {
    class ProductsPage {
        private const String URL = "http://tmp.flexdatabases.com/en/";
        private IWebDriver driver;
        private WebDriverWait wait;

        public ProductsPage(IWebDriver driver) {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void open() {
            driver.Navigate().GoToUrl(URL);
        }

        public void clickTopRequestDemoButton() {
            driver.FindElement(By.CssSelector(MAIN_REQUEST_BUTTON)).Click();
        }

        public Boolean isRequestDemoFormOpened() {
            IWebElement form = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(REQUEST_DEMO_FORM)));
            if (form != null) {
                return true;
            } else {
                return false;
            }
        }
    }
}
