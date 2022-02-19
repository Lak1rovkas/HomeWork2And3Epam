using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeWorkNumber2
{
    public class HomeWork2
    {
        private const string URL = "https://mail.yandex.ru/";
        private const string TOPIC_OF_THE_LETTER = "My favorite football teams";
        private const string DESTINATION_EMAIL_ADDRESS = "ale01.0134@gmail.com";
        private const string MESSAGE_IN_A_LETTER = "Tottenham, Inter Milan and Zenit Saint-Petersburg forever :)";
        private const string TOPIC_OF_THE_LETTER_VERSION_2 = "Where am I from?";
        private const string DESTINATION_EMAIL_ADDRESS_VERSION_2 = "lakirovkas85@yandex.ru";
        private const string MESSAGE_IN_A_LETTER_VERSION_2 = "Russia, Saint-Petersburg";

        private static IWebDriver _driver;

        private MainPage _mainPage;
        private LoginPage _loginPage;
        private UserAccount _userAccount = new UserAccount(@"C:\Users\zampir\source\repos\HomeWorkNumber2\HomeWorkNumber2\MailAndPassword\user.txt");

        [SetUp]
        public void startBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();

            _mainPage = new MainPage(_driver);
            _loginPage = new LoginPage(_driver);
            _loginPage.Login(_userAccount.Login, _userAccount.Password);
        }

        [Test]
        public void createEmail_whenLoginPassSpecified_shouldCreateEmail()
        {
            _mainPage.FillAndSafeLetter(DESTINATION_EMAIL_ADDRESS, TOPIC_OF_THE_LETTER, MESSAGE_IN_A_LETTER);
            string result = _loginPage.CheckingAccount();

            Assert.AreEqual(_userAccount.Login, result);
        }

        [Test]
        public void checkingAndDeletingDrafts_whenDraftTopicFound_shouldDeleteTheDraft()
        {
            var draftsForm = new DraftsForm(_driver);
            draftsForm.SearchAndRemoveDrafts(TOPIC_OF_THE_LETTER);

            Assert.IsTrue(draftsForm.IsTopicOfDraftAbsent(TOPIC_OF_THE_LETTER));
        }

        [Test]
        public void checkingAndSendingMails_whenMailSent_shouldCheckMailInInboxAndSent()
        {            
            _mainPage.FillAndSendLetter(DESTINATION_EMAIL_ADDRESS_VERSION_2, TOPIC_OF_THE_LETTER_VERSION_2, MESSAGE_IN_A_LETTER_VERSION_2);
            var sentPage = new SentPage(_driver);

            Assert.IsTrue(sentPage.DoesTheSentMailExistInTheSents(TOPIC_OF_THE_LETTER_VERSION_2));
            Assert.IsTrue(_mainPage.DoesTheSentMailExistInTheInbox(TOPIC_OF_THE_LETTER_VERSION_2));
        }

        [TearDown]
        public void closeBrowser()
        {
            _mainPage.LogOut();
            _driver.Quit();
        }
    }
}