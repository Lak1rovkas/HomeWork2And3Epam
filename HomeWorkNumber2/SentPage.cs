using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    class SentPage : MainPage
    {
        private const string XPATH_OF_CHECK_MAIL_BOX = "//div[@data-key = 'box=messages-item-box']";
        private const string XPATH_OF_SENT_BTN = "//a[@data-title = 'Отправленные']";

        private readonly IWebDriver _driver;

        public IWebElement SentBtn { get; private set; }

        public SentPage (IWebDriver driver) : base(driver)
        {
            _driver = driver;
            SentBtn = _driver.FindElement(By.XPath(XPATH_OF_SENT_BTN));
        }

        public bool DoesTheSentMailExistInTheSents(string topic)
        {
            SentBtn.Click();
            SearchForEmail(topic);
            return IsElementPresent(By.XPath(XPATH_OF_CHECK_MAIL_BOX));
        }
    }
}
