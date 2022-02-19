using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    public class MainPage : BasePage
    {
        private const string XPATH_OF_WRITE_LETTER_BTN = "//a[@class = 'mail-ComposeButton js-main-action-compose']";
        private const string XPATH_OF_SEARCH_BTN = "//button[@class = 'control button2 button2_view_default button2_tone_mail-suggest-themed button2_size_n button2_theme_normal button2_pin_clear-round button2_type_submit search-input__form-button']";
        private const string XPATH_OF_SEARCH_FIELD = "//input[@class = 'textinput__control']";
        private const string XPATH_OF_CHECK_MAIL_BOX = "//div[@data-key = 'box=messages-item-box']";
        private const string XPATH_OF_INBOX_BTN = "//a[@data-title = 'Входящие']";
        private const string XPATH_OF_PRESS_AVATAR = "//div[@class = 'PSHeader-User']";
        private const string XPATH_OF_LOGOUT_BTN = "//a[@class = 'menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_exit legouser__menu-item legouser__menu-item_action_exit']";

        public IWebElement SearchBtn { get; private set; }
        public IWebElement InboxBtn { get; private set; }
        public IWebElement PressAvatar { get; private set; }
        public IWebElement LogOutBtn { get; private set; }
        public IWebElement WriteLetterBtn { get; private set; }
        public IWebElement SearchForASpecificTopic { get; private set; }

        public MainPage(IWebDriver driver) : base(driver)
        {            
        }

        public void FillAndSafeLetter(string adresseeOfTheLetter, string topic, string text)
        {
            WriteEmail();
            var emailForm = new EmailForm(GetDriver());
            emailForm.FillAndSafeLetter(adresseeOfTheLetter, topic, text);
        }
        public void FillAndSendLetter(string adresseeOfTheLetter, string topic, string text)
        {
            WriteEmail();
            var emailForm = new EmailForm(GetDriver());
            emailForm.FillAndSendLetter(adresseeOfTheLetter, topic, text);
        }

        public bool DoesTheSentMailExistInTheInbox(string topic)
        {
            InboxBtn = GetDriver().FindElement(By.XPath(XPATH_OF_INBOX_BTN));
            InboxBtn.Click();
            SearchForEmail(topic);
            SearchBtn.Click();
            return IsElementPresent(By.XPath(XPATH_OF_CHECK_MAIL_BOX));
        }

        public void SearchForEmail(string topic)
        {
            SearchForASpecificTopic = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_FIELD));
            SearchForASpecificTopic.SendKeys(topic);
            SearchBtn = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_BTN));            
        }

        public void LogOut()
        {
            GetLogOutBtns();
            PressAvatar.Click();            
            LogOutBtn.Click();
        }

        private void WriteEmail()
        {
            WriteLetterBtn = GetDriver().FindElement(By.XPath(XPATH_OF_WRITE_LETTER_BTN));
            WriteLetterBtn.Click();
        }
        private void GetLogOutBtns()
        {
            PressAvatar = GetDriver().FindElement(By.XPath(XPATH_OF_PRESS_AVATAR)); //It's need cause we can't press LogOutBtn without click on avatar
            LogOutBtn = GetDriver().FindElement(By.XPath(XPATH_OF_LOGOUT_BTN));
        }
    }
}