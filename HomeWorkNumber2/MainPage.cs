using OpenQA.Selenium;
using System.Threading;

namespace HomeWorkNumber2
{
    public class MainPage : BasePage
    {
        private const string TOPIC_OF_THE_LETTER = "My favorite football teams";
        private const string DESTINATION_EMAIL_ADDRESS = "ale01.0134@gmail.com";
        private const string MESSAGE_IN_A_LETTER = "Tottenham, Inter Milan and Zenit Saint-Petersburg forever :)";

        public MainPage(IWebDriver driver) : base(driver)
        {
        }
        public void Open()
        {
            GetDriver().Manage().Window.Maximize();
        }
        public void FillingALetter()
        {
            IWebElement WriteLetterBtn = GetDriver().FindElement(By.XPath("//a[@class = 'mail-ComposeButton js-main-action-compose']")); 
            WriteLetterBtn.Click();
            IWebElement AdresseeOfTheLetter = GetDriver().FindElement(By.XPath("//div[@class = 'composeYabbles']"));
            AdresseeOfTheLetter.SendKeys(DESTINATION_EMAIL_ADDRESS);
            IWebElement TopicOfTheLetter = GetDriver().FindElement(By.XPath("//input[@name = 'subject']"));
            TopicOfTheLetter.SendKeys(TOPIC_OF_THE_LETTER);
            IWebElement TextOfTheLetter = GetDriver().FindElement(By.XPath("//div[@class = 'cke_wysiwyg_div cke_reset cke_enable_context_menu cke_editable cke_editable_themed cke_contents_ltr cke_htmlplaceholder']"));
            TextOfTheLetter.SendKeys(MESSAGE_IN_A_LETTER);
            IWebElement CloseBtn = GetDriver().FindElement(By.XPath("//div[@class = 'ControlButton ControlButton_button_close']"));
            CloseBtn.Click();
        }
        public void SearchAndRemoveDrafts()
        {
            IWebElement PressDrafts = GetDriver().FindElement(By.XPath("//a[@href = '#draft']")); //Я знаю, что очень хреново привязываться так через XPath, но другого варианта я не увидел работающего
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
            return IsElementAbsent(By.XPath("//div[@class = 'ns-view-messages-item-wrap']")); 
        }
        public void LogOut()
        {
            IWebElement PressAvatar = GetDriver().FindElement(By.XPath("//div[@class = 'PSHeader-User']")); //It's need cause we can't press LogOutBtn without click on avatar
            PressAvatar.Click();
            IWebElement LogOutBtn = GetDriver().FindElement(By.XPath("//a[@class = 'menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_exit legouser__menu-item legouser__menu-item_action_exit']"));
            LogOutBtn.Click();
        }
        public void Close()
        {
            GetDriver().Close();
        }
        
        private void SearchTopic()
        {
            IWebElement SearchForASpecificTopic = GetDriver().FindElement(By.XPath("//input[@class = 'textinput__control']"));
            SearchForASpecificTopic.SendKeys(TOPIC_OF_THE_LETTER);
            IWebElement SearchBtn = WaitAndFindElement(By.XPath("//button[@class = 'control button2 button2_view_default button2_tone_mail-suggest-themed button2_size_n button2_theme_normal button2_pin_clear-round button2_type_submit search-input__form-button']"));
            SearchBtn.Click();
        }
    }
}