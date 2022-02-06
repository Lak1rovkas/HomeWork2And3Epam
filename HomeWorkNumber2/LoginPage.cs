using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    public class LoginPage : BasePage
    {
        private const string LOGIN_FIELD_ID = "passp-field-login";
        private const string ENTER_BUTTON_ID = "passp:sign-in";
        private const string PASSWORD_FIELD_ID = "passp-field-passwd";
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void Login(string login, string password)
        {
            IWebElement loginButton = GetDriver().FindElement(By.XPath("//a[@href = 'https://passport.yandex.ru/auth?from=mail&origin=hostroot_homer_auth_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F&backpath=https%3A%2F%2Fmail.yandex.ru%3Fnoretpath%3D1']"));
            loginButton.Click();
            IWebElement loginBox = GetDriver().FindElement(By.Id(LOGIN_FIELD_ID));
            loginBox.SendKeys(login);
            IWebElement enterBtn = GetDriver().FindElement(By.Id(ENTER_BUTTON_ID));;
            enterBtn.Click();
            IWebElement passBox = WaitAndFindElement(By.Id(PASSWORD_FIELD_ID));
            passBox.SendKeys(password);
            IWebElement enterBtnAgain = WaitAndFindElement(By.Id(ENTER_BUTTON_ID));
            enterBtnAgain.Click();
        }

        public string CheckingAccount()
        {
            IWebElement mail = GetDriver().FindElement(By.ClassName("legouser__menu-header")).FindElement(By.ClassName("user-account__subname"));
            return mail.GetAttribute("textContent");
        }
    }
}
