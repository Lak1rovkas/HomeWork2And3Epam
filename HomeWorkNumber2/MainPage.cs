using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    public class MainPage : BasePage
    {
        private const string TOPIC_OF_THE_LETTER_VERSION_2 = "Where am I from?";
        private const string DESTINATION_EMAIL_ADDRESS = "ale01.0134@gmail.com";
        private const string DESTINATION_EMAIL_ADDRESS_VERSION_2 = "lakirovkas85@yandex.ru";
        private const string XPATH_OF_WRITE_LETTER_BTN = "//a[@class = 'mail-ComposeButton js-main-action-compose']";
        private const string XPATH_OF_REFRESH_BTN = "//span[@data-click-action = 'mailbox.check']";
        private const string XPATH_OF_SEARCH_BTN = "//button[@class = 'control button2 button2_view_default button2_tone_mail-suggest-themed button2_size_n button2_theme_normal button2_pin_clear-round button2_type_submit search-input__form-button']";
        private const string XPATH_OF_SEARCH_FIELD = "//input[@class = 'textinput__control']";
        private const string XPATH_OF_CHECK_MAIL_BOX = "//div[@data-key = 'box=messages-item-box']";
        private const string XPATH_OF_INBOX_BTN = "//a[@data-title = 'Входящие']";
        private const string XPATH_OF_PRESS_AVATAR = "//div[@class = 'PSHeader-User']";
        private const string XPATH_OF_LOGOUT_BTN = "//a[@class = 'menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_exit legouser__menu-item legouser__menu-item_action_exit']";

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            GetDriver().Manage().Window.Maximize();
        }

        public void FillingALetter()
        {
            var emailForm = new EmailForm(GetDriver());
            IWebElement WriteLetterBtn = GetDriver().FindElement(By.XPath(XPATH_OF_WRITE_LETTER_BTN));
            WriteLetterBtn.Click();
            emailForm.FillingALetter(DESTINATION_EMAIL_ADDRESS);
        }

        public void FillingALetterVersion2()
        {
            var emailForm = new EmailForm(GetDriver());
            IWebElement WriteLetterBtn = GetDriver().FindElement(By.XPath(XPATH_OF_WRITE_LETTER_BTN));
            WriteLetterBtn.Click();
            emailForm.FillingALetter(DESTINATION_EMAIL_ADDRESS_VERSION_2);
            IWebElement RefreshBtn = GetDriver().FindElement(By.XPath(XPATH_OF_REFRESH_BTN));
            RefreshBtn.Click();
        }

        public bool DoesTheSentMailExistInTheInbox()
        {
            IWebElement InboxBtn = GetDriver().FindElement(By.XPath(XPATH_OF_INBOX_BTN));
            InboxBtn.Click();
            SearchTopicVersion2();
            return IsElementPresent(By.XPath(XPATH_OF_CHECK_MAIL_BOX));
        }

        public void SearchTopicVersion2()
        {
            IWebElement SearchForASpecificTopic = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_FIELD));
            SearchForASpecificTopic.SendKeys(TOPIC_OF_THE_LETTER_VERSION_2);
            IWebElement SearchBtn = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_BTN));
            SearchBtn.Click();
        }

        public void LogOut()
        {
            IWebElement PressAvatar = GetDriver().FindElement(By.XPath(XPATH_OF_PRESS_AVATAR)); //It's need cause we can't press LogOutBtn without click on avatar
            PressAvatar.Click();
            IWebElement LogOutBtn = GetDriver().FindElement(By.XPath(XPATH_OF_LOGOUT_BTN));
            LogOutBtn.Click();
        }
        public void Close()
        {
            GetDriver().Close();
        }        
    }
}