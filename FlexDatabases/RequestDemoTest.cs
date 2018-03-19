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

        [SetUp]
        public void start() {
            driver = new ChromeDriver();
            page = new ProductsPage(driver);
        }

        [Test, Description("Нажимаем на кнопку наверху, чтобы открыть форму")]
        public void FirstTest() {
            page.open();
            page.clickTopRequestDemoButton();
            Assert.AreEqual(true, page.isRequestDemoFormOpened());
        }

        [TearDown]
        public void stop() {
            driver.Quit();
            driver = null;
        }
    }
}
