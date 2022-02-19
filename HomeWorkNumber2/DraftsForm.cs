using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    class DraftsForm : MainPage
    {
        private const string XPATH_OF_IS_BUTTON_AVAILABLE = "//input[@class = 'checkbox_controller']";
        private const string XPATH_OF_CHECK_DRAFTS = "//div[@class = 'ns-view-messages-empty-wrap']";
        private const string XPATH_OF_SEARCH_FIELD = "//input[@class = 'textinput__control']";
        private const string XPATH_OF_SEARCH_BTN = "//button[@class = 'control button2 button2_view_default button2_tone_mail-suggest-themed button2_size_n button2_theme_normal button2_pin_clear-round button2_type_submit search-input__form-button']";
        private const string XPATH_OF_PRESS_DRAFTS = "//a[@data-title = 'Черновики']";
        private const string XPATH_OF_SELECT_ALL_BTN = "//span[@class = 'checkbox_view']";
        private const string XPATH_OF_DELETE_BTN = "//span[@class = 'mail-Toolbar-Item-Text js-toolbar-item-title js-toolbar-item-title-delete']";

        private readonly IWebDriver _driver;

        public IWebElement PressDrafts { get; private set; }
        public IWebElement SearchForASpecificTopic { get; private set; }
        public IWebElement SelectAllBtn { get; private set; }
        public IWebElement DeleteBtn { get; private set; }
        public IWebElement SearchBtn { get; private set; }

        public DraftsForm(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PressDrafts = _driver.FindElement(By.XPath(XPATH_OF_PRESS_DRAFTS));           
        }

        public void SearchAndRemoveDrafts(string topic)
        {
            PressDrafts.Click();
            SearchTopic(topic);
            SearchBtn.Click();
            bool IsButtonAvailable = IsElementPresent(By.XPath(XPATH_OF_IS_BUTTON_AVAILABLE));
            if (IsButtonAvailable == true)
            {
                GetSelectAllAndDeleteBtns();
                SelectAllBtn.Click();
                DeleteBtn.Click();
            }
        }

        public bool IsTopicOfDraftAbsent(string topic)
        {
            SearchTopic(topic);
            return IsElementAbsent(By.XPath(XPATH_OF_CHECK_DRAFTS));
        }
        private void SearchTopic(string topic)
        {            
            SearchForASpecificTopic = _driver.FindElement(By.XPath(XPATH_OF_SEARCH_FIELD));
            SearchForASpecificTopic.SendKeys(topic);
            SearchBtn = WaitAndFindElement(By.XPath(XPATH_OF_SEARCH_BTN));
        }
        private void GetSelectAllAndDeleteBtns()
        {
            SelectAllBtn = WaitAndFindElement(By.XPath(XPATH_OF_SELECT_ALL_BTN));
            DeleteBtn = WaitAndFindElement(By.XPath(XPATH_OF_DELETE_BTN));
        }

    }
}
