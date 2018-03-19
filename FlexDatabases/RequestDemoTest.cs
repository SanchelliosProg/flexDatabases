using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FlexDatabases.Helpers;
using System.Threading;

namespace FlexDatabases {
    [TestFixture, Description("Кнопка Request Demo")]
    public class RequestDemoTest {
        private ProductsPage page;
        private IWebDriver driver;

        private const String URL = "http://tmp.flexdatabases.com/en/";

        [OneTimeSetUp]
        public void start() {
            driver = new ChromeDriver();
            page = new ProductsPage(driver);
        }

        [Test, Description("Нажимаем на кнопку наверху, чтобы открыть форму")]
        public void TopButton() {
            page.open();
            page.clickTopRequestDemoButton();
            Assert.AreEqual(true, page.isRequestDemoFormOpened());
        }

        [Test, Description("Нажимаем на кнопку наверху, чтобы открыть форму"), Combinatorial]
        public void BlogButtons([Values(0,1,2,3,4,5,6,7)] int itemNumber) {
            page.open();
            page.clickOnRequestDemoButtonNumber(itemNumber);
            Assert.AreEqual(true, page.isRequestDemoFormOpened());
        }

        [OneTimeTearDown]
        public void stop() {
            driver.Quit();
            driver = null;
        }
    }
}
