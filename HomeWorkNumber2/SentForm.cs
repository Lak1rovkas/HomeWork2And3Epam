using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    class SentForm : MainPage
    {
        private const string XPATH_OF_CHECK_MAIL_BOX = "//div[@data-key = 'box=messages-item-box']";
        private const string XPATH_OF_SENT_BTN = "//a[@data-title = 'Отправленные']";

        private readonly IWebDriver _driver;

        public IWebElement SentBtn { get; private set; }
        public IWebElement SearchForASpecificTopic { get; private set; }

        public SentForm (IWebDriver driver) : base(driver)
        {
            _driver = driver;
            SentBtn = _driver.FindElement(By.XPath(XPATH_OF_SENT_BTN));
        }
        public bool DoesTheSentMailExistInTheSents()
        {
            SentBtn.Click();
            SearchTopicVersion2();
            return IsElementPresent(By.XPath(XPATH_OF_CHECK_MAIL_BOX));
        }
    }
}
