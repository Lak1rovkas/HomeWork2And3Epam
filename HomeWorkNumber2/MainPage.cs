using OpenQA.Selenium;
using System.Threading;

namespace HomeWorkNumber2
{
    public class MainPage : BasePage
    {
        private const string TOPIC_OF_THE_LETTER = "My favorite football teams";
        private const string DESTINATION_EMAIL_ADDRESS = "ale01.0134@gmail.com";
        private const string MESSAGE_IN_A_LETTER = "Tottenham, Inter Milan and Zenit Saint-Petersburg forever :)";
        private const string TOPIC_OF_THE_LETTER_TEST_2 = "Where am I from?";
        private const string DESTINATION_EMAIL_ADDRESS_TEST_2 = "lakirovkas85@yandex.ru";
        private const string MESSAGE_IN_A_LETTER_TEST_2 = "Russia, Saint-Petersburg";
        private const string XPATH_OF_ADRESSEE_OF_THE_LETTER = "//div[@class = 'composeYabbles']";
        private const string XPATH_OF_WRITE_LETTER_BTN = "//a[@class = 'mail-ComposeButton js-main-action-compose']";
        private const string XPATH_OF_TOPIC_OF_THE_LETTER = "//input[@name = 'subject']";
        private const string XPATH_OF_TEXT_OF_THE_LETTER = "//div[@class = 'cke_wysiwyg_div cke_reset cke_enable_context_menu cke_editable cke_editable_themed cke_contents_ltr cke_htmlplaceholder']";
        private const string XPATH_OF_CLOSE_BTN = "//button[@class = 'ControlButton-Button']";
        private const string XPATH_OF_SEND_BTN = "//button[@class = 'Button2 Button2_pin_circle-circle Button2_view_default Button2_size_l']";
        private const string XPATH_OF_REFRESH_BTN = "//span[@data-click-action = 'mailbox.check']";
        private const string XPATH_OF_SEARCH_BTN = "//button[@class = 'control button2 button2_view_default button2_tone_mail-suggest-themed button2_size_n button2_theme_normal button2_pin_clear-round button2_type_submit search-input__form-button']";
        private const string XPATH_OF_SEARCH_FIELD = "//input[@class = 'textinput__control']";
        private const string XPATH_OF_CHECK_MAIL_BOX = "//div[@data-key = 'box=messages-item-box']";
        private const string XPATH_OF_CHECK_DRAFTS = "//div[@class = 'ns-view-messages-empty-wrap']";
        private const string XPATH_OF_SENT_BTN = "//a[@data-title = 'Отправленные']";
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
            IWebElement WriteLetterBtn = GetDriver().FindElement(By.XPath(XPATH_OF_WRITE_LETTER_BTN)); 
            WriteLetterBtn.Click();
            IWebElement AdresseeOfTheLetter = GetDriver().FindElement(By.XPath(XPATH_OF_ADRESSEE_OF_THE_LETTER));
            AdresseeOfTheLetter.SendKeys(DESTINATION_EMAIL_ADDRESS);
            IWebElement TopicOfTheLetter = GetDriver().FindElement(By.XPath(XPATH_OF_TOPIC_OF_THE_LETTER));
            TopicOfTheLetter.SendKeys(TOPIC_OF_THE_LETTER);
            IWebElement TextOfTheLetter = GetDriver().FindElement(By.XPath(XPATH_OF_TEXT_OF_THE_LETTER));
            TextOfTheLetter.SendKeys(MESSAGE_IN_A_LETTER);
            IWebElement CloseBtn = GetDriver().FindElement(By.XPath(XPATH_OF_CLOSE_BTN));
            CloseBtn.Click();
        }

        public void FillingALetterTest2()
        {
            IWebElement WriteLetterBtn = GetDriver().FindElement(By.XPath(XPATH_OF_WRITE_LETTER_BTN));
            WriteLetterBtn.Click();
            IWebElement AdresseeOfTheLetter = GetDriver().FindElement(By.XPath(XPATH_OF_ADRESSEE_OF_THE_LETTER));
            AdresseeOfTheLetter.SendKeys(DESTINATION_EMAIL_ADDRESS_TEST_2);
            IWebElement TopicOfTheLetter = GetDriver().FindElement(By.XPath(XPATH_OF_TOPIC_OF_THE_LETTER));
            TopicOfTheLetter.SendKeys(TOPIC_OF_THE_LETTER_TEST_2);
            IWebElement TextOfTheLetter = GetDriver().FindElement(By.XPath(XPATH_OF_TEXT_OF_THE_LETTER));
            TextOfTheLetter.SendKeys(MESSAGE_IN_A_LETTER_TEST_2);
            IWebElement SendBtn = GetDriver().FindElement(By.XPath(XPATH_OF_SEND_BTN));
            SendBtn.Click();
            IWebElement RefreshBtn = GetDriver().FindElement(By.XPath(XPATH_OF_REFRESH_BTN));
            RefreshBtn.Click();
        }

        public void SearchAndRemoveDrafts()
        {
            IWebElement PressDrafts = GetDriver().FindElement(By.XPath("//a[@data-title = 'Черновики']")); //Я знаю, что очень хреново привязываться так через XPath, но другого варианта я не увидел работающего
            PressDrafts.Click();
            SearchTopic();
            bool IsButtonAvailable = IsElementPresent(By.XPath("//input[@class = 'checkbox_controller']"));
            if (IsButtonAvailable == true)
            {
                IWebElement SelectAllBtn = WaitAndFindElement(By.XPath("//span[@class = 'checkbox_view']"));
                SelectAllBtn.Click();
                IWebElement DeleteBtn = WaitAndFindElement(By.XPath("//span[@class = 'mail-Toolbar-Item-Text js-toolbar-item-title js-toolbar-item-title-delete']"));
                DeleteBtn.Click();
            }
        }

        public bool IsTopicOfDraftAbsent()
        {
            SearchTopic();
            return IsElementAbsent(By.XPath(XPATH_OF_CHECK_DRAFTS)); 
        }

        public bool DoesTheSentMailExistInTheInbox()
        {
            IWebElement InboxBtn = GetDriver().FindElement(By.XPath(XPATH_OF_INBOX_BTN));
            InboxBtn.Click();
            SearchTopicTest2();
            return IsElementPresent(By.XPath(XPATH_OF_CHECK_MAIL_BOX));
        }

        public bool DoesTheSentMailExistInTheSents()
        {
            IWebElement SentBtn = GetDriver().FindElement(By.XPath(XPATH_OF_SENT_BTN));
            SentBtn.Click();
            SearchTopicTest2();
            return IsElementPresent(By.XPath(XPATH_OF_CHECK_MAIL_BOX));
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
        
        private void SearchTopic()
        {
            IWebElement SearchForASpecificTopic = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_FIELD));
            SearchForASpecificTopic.SendKeys(TOPIC_OF_THE_LETTER);
            IWebElement SearchBtn = WaitAndFindElement(By.XPath(XPATH_OF_SEARCH_BTN));
            SearchBtn.Click();
        }
        private void SearchTopicTest2()
        {
            IWebElement SearchForASpecificTopic = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_FIELD));
            SearchForASpecificTopic.SendKeys(TOPIC_OF_THE_LETTER_TEST_2);
            IWebElement SearchBtn = GetDriver().FindElement(By.XPath(XPATH_OF_SEARCH_BTN));
            SearchBtn.Click();
        }
    }
}