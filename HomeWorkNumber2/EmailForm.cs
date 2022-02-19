using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    class EmailForm
    {
        private const string TOPIC_OF_THE_LETTER = "My favorite football teams";
        private const string DESTINATION_EMAIL_ADDRESS = "ale01.0134@gmail.com";
        private const string MESSAGE_IN_A_LETTER = "Tottenham, Inter Milan and Zenit Saint-Petersburg forever :)";
        private const string TOPIC_OF_THE_LETTER_VERSION_2 = "Where am I from?";
        private const string DESTINATION_EMAIL_ADDRESS_VERSION_2 = "lakirovkas85@yandex.ru";
        private const string MESSAGE_IN_A_LETTER_VERSION_2 = "Russia, Saint-Petersburg";

        private const string XPATH_OF_ADRESSEE_OF_THE_LETTER = "//div[@class = 'composeYabbles']";
        private const string XPATH_OF_TOPIC_OF_THE_LETTER = "//input[@name = 'subject']";
        private const string XPATH_OF_TEXT_OF_THE_LETTER = "//div[@class = 'cke_wysiwyg_div cke_reset cke_enable_context_menu cke_editable cke_editable_themed cke_contents_ltr cke_htmlplaceholder']";
        private const string XPATH_OF_CLOSE_BTN = "//button[@class = 'ControlButton-Button']";
        private const string XPATH_OF_SEND_BTN = "//button[@class = 'Button2 Button2_pin_circle-circle Button2_view_default Button2_size_l']";

        private readonly IWebDriver _driver;
        public IWebElement AdresseeOfTheLetter { get; private set; }
        public IWebElement TopicOfTheLetter { get; private set; }
        public IWebElement TextOfTheLetter { get; private set; }
        public IWebElement CloseBtn { get; private set; }
        public IWebElement SendBtn { get; private set; }

        public EmailForm(IWebDriver driver)
        {
            _driver = driver;
            AdresseeOfTheLetter = _driver.FindElement(By.XPath(XPATH_OF_ADRESSEE_OF_THE_LETTER));
            TopicOfTheLetter = _driver.FindElement(By.XPath(XPATH_OF_TOPIC_OF_THE_LETTER));
            TextOfTheLetter = _driver.FindElement(By.XPath(XPATH_OF_TEXT_OF_THE_LETTER));
            CloseBtn = _driver.FindElement(By.XPath(XPATH_OF_CLOSE_BTN));
            SendBtn = _driver.FindElement(By.XPath(XPATH_OF_SEND_BTN));
        }

        public void FillingALetter(string adresseeOfTheLetter)
        {
            if (adresseeOfTheLetter == DESTINATION_EMAIL_ADDRESS)
            {
                AdresseeOfTheLetter.SendKeys(DESTINATION_EMAIL_ADDRESS);
                TopicOfTheLetter.SendKeys(TOPIC_OF_THE_LETTER);
                TextOfTheLetter.SendKeys(MESSAGE_IN_A_LETTER);
                CloseBtn.Click();
            }
            if (adresseeOfTheLetter == DESTINATION_EMAIL_ADDRESS_VERSION_2)
            {
                AdresseeOfTheLetter.SendKeys(DESTINATION_EMAIL_ADDRESS_VERSION_2);
                TopicOfTheLetter.SendKeys(TOPIC_OF_THE_LETTER_VERSION_2);
                TextOfTheLetter.SendKeys(MESSAGE_IN_A_LETTER_VERSION_2);
                SendBtn.Click();
            }
        }
    }
}
