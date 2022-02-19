using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeWorkNumber2
{
    public class HomeWork2
    {
        private const string URL = "https://mail.yandex.ru/";

        private static IWebDriver driver;

        private MainPage mainPage;
        private LoginPage loginPage;
        private UserAccount userAccount = new UserAccount(@"C:\Users\zampir\source\repos\HomeWorkNumber2\HomeWorkNumber2\MailAndPassword\user.txt");
        private DraftsForm draftsForm;
        private SentForm sentForm;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

            mainPage = new MainPage(driver);
            loginPage = new LoginPage(driver);
            draftsForm = new DraftsForm(driver);
            sentForm = new SentForm(driver);

            mainPage.GetDriver().Navigate().GoToUrl(URL);
            mainPage.Open();
        }



        [Test]
        public void createEmail_whenLoginPassSpecified_shouldCreateEmail()
        {
            loginPage.Login(userAccount.Login, userAccount.Password);
            mainPage.FillingALetter();
            string result = loginPage.CheckingAccount();

            Assert.AreEqual(userAccount.Login, result);

            mainPage.LogOut();
        }

        [Test]
        public void checkingAndDeletingDrafts_whenDraftTopicFound_shouldDeleteTheDraft()
        {
            loginPage.Login(userAccount.Login, userAccount.Password);
            draftsForm.SearchAndRemoveDrafts();

            Assert.IsTrue(draftsForm.IsTopicOfDraftAbsent());

            mainPage.LogOut();
        }

        [Test]
        public void checkingAndSendingMails_whenMailSent_shouldCheckMailInInboxAndSent()
        {
            loginPage.Login(userAccount.Login, userAccount.Password);
            mainPage.FillingALetterVersion2();

            Assert.IsTrue(sentForm.DoesTheSentMailExistInTheSents());
            Assert.IsTrue(mainPage.DoesTheSentMailExistInTheInbox());

            mainPage.LogOut();
        }

        [TearDown]
        public void closeBrowser()
        {
            mainPage.GetDriver().Quit();
        }
    }
}