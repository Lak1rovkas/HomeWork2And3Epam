using OpenQA.Selenium;
using System;

namespace HomeWorkNumber2
{
    class EmailForm
    {
        private const string XPATH_OF_ADRESSEE_OF_THE_LETTER = "//div[@class = 'composeYabbles']";
        private const string XPATH_OF_TOPIC_OF_THE_LETTER = "//input[@name = 'subject']";
        private const string XPATH_OF_TEXT_OF_THE_LETTER = "//div[@class = 'cke_wysiwyg_div cke_reset cke_enable_context_menu cke_editable cke_editable_themed cke_contents_ltr cke_htmlplaceholder']";
        private const string XPATH_OF_CLOSE_BTN = "//div[@class = 'ControlButton ControlButton_button_close']";
        private const string XPATH_OF_SEND_BTN = "//button[@class = 'Button2 Button2_pin_circle-circle Button2_view_default Button2_size_l']";

        private readonly IWebDriver _driver;
        public IWebElement AdresseeOfTheLetter { get; private set; }
        public IWebElement TopicOfTheLetter { get; private set; }
        public IWebElement TextOfTheLetter { get; private set; }
        public IWebElement CloseBtn { get; private set; }
        public IWebElement SendBtn { get; private set; }

        public EmailForm(IWebDriver driver)
        {
            if (driver == null) throw new NullReferenceException("Parameter argument is NULL");   
            
            _driver = driver;
            AdresseeOfTheLetter = _driver.FindElement(By.XPath(XPATH_OF_ADRESSEE_OF_THE_LETTER));
            TopicOfTheLetter = _driver.FindElement(By.XPath(XPATH_OF_TOPIC_OF_THE_LETTER));
            TextOfTheLetter = _driver.FindElement(By.XPath(XPATH_OF_TEXT_OF_THE_LETTER));
            CloseBtn = _driver.FindElement(By.XPath(XPATH_OF_CLOSE_BTN));
            SendBtn = _driver.FindElement(By.XPath(XPATH_OF_SEND_BTN));
        }

        private void FillALetter(string adresseeOfTheLetter, string topic, string text)
        {
            AdresseeOfTheLetter.SendKeys(adresseeOfTheLetter);
            TopicOfTheLetter.SendKeys(topic);
            TextOfTheLetter.SendKeys(text);           
        }

        public void FillAndSafeLetter(string adresseeOfTheLetter, string topic, string text)
        {
            FillALetter(adresseeOfTheLetter, topic, text);
            CloseBtn.Click();
        }

        public void FillAndSendLetter(string adresseeOfTheLetter, string topic, string text)
        {
            FillALetter(adresseeOfTheLetter, topic, text);
            SendBtn.Click();
        }
    }
}
