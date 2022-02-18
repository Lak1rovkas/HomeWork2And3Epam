using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HomeWorkNumber2
{ 
    public abstract class BasePage
    {
        private const int DEFAULT_TIMEOUT_SECONDS = 10;
        private static IWebDriver _driver;

        protected BasePage (IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public bool IsElementPresent(By by)
        {
            return _driver.FindElements(by).Count > 0;
        }

        public bool IsElementAbsent(By by)
        {
            return !IsElementPresent(by);
        }

        public static IWebElement WaitAndFindElement(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(DEFAULT_TIMEOUT_SECONDS));
            return wait.Until(drv => drv.FindElement(by));
        }
    }
}


