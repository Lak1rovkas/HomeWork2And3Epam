using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    public class LoginPage : BasePage
    {
        public IWebElement LoginButton { get; private set; }
        public IWebElement LoginField { get; private set; }
        public IWebElement EnterBtn { get; private set; }
        public IWebElement PasswordField { get;  private set; }
        public IWebElement mailCheck { get; private set; }
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void Login(string login, string password)
        {
            LoginButton = GetDriver().FindElement(By.XPath("//a[@href = 'https://passport.yandex.ru/auth?from=mail&amp;origin=hostroot_homer_auth_ru&amp;retpath=https%3A%2F%2Fmail.yandex.ru%2F&amp;backpath=https%3A%2F%2Fmail.yandex.ru%3Fnoretpath%3D1']"));
            LoginButton.Click();
            LoginField = GetDriver().FindElement(By.Id("passp-field-login"));
            LoginField.SendKeys(login);
            EnterBtn = GetDriver().FindElement(By.Id("passp:sign-in"));
            EnterBtn.Click();
            PasswordField = WaitAndFindElement(By.Id("passp-field-passwd"));
            PasswordField.SendKeys(password);
            EnterBtn.Click();
        }

        public string CheckingAccount()
        {
            mailCheck = GetDriver().FindElement(By.ClassName("legouser__menu-header")).FindElement(By.ClassName("user-account__subname"));
            return mailCheck.GetAttribute("textContent");
        }
    }
}
