using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
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

        public void clickOnRequestDemoButtonNumber(int blogItemNumber) {
            List<IWebElement> blogItems = getListOfBlogItems();
            IWebElement blogItem = blogItems[blogItemNumber];
            IWebElement button = scrollToThe(blogItem).FindElement(By.CssSelector("a"));
            button.Click();
        }

        private IWebElement scrollToThe(IWebElement element) {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }

        private List<IWebElement> getListOfBlogItems() {
            return new List<IWebElement>(driver.FindElements(By.CssSelector(BLOG_ITEM_CARD_LIST)));
        }
    }
}
