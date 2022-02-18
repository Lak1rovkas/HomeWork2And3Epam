using OpenQA.Selenium;

namespace HomeWorkNumber2
{
    public class LoginPage : BasePage
    {
        private IWebElement LoginButton;
        private IWebElement LoginField;
        private IWebElement EnterBtn;
        private IWebElement PasswordField;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            //LoginButton = GetDriver().FindElement(By.XPath("//span[@class = 'button2__text']"));
            //LoginField = GetDriver().FindElement(By.Id("passp-field-login"));
            //EnterBtn = GetDriver().FindElement(By.Id("passp:sign-in"));
            //PasswordField = WaitAndFindElement(By.Id("passp-field-passwd"));
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
            IWebElement mail = GetDriver().FindElement(By.ClassName("legouser__menu-header")).FindElement(By.ClassName("user-account__subname"));
            return mail.GetAttribute("textContent");
        }
    }
}
