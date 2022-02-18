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

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

            mainPage = new MainPage(driver);
            loginPage = new LoginPage(driver);

            mainPage.GetDriver().Navigate().GoToUrl(URL);
            mainPage.Open();
        }

        public LoginClass GetUser()
        {
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    LoginClass user = new LoginClass("user");
                    return user;
                case 2:
                    LoginClass admin = new LoginClass("admin");
                    return admin;
                default:
                    Console.WriteLine("Wrong choice of user type. Try again later");
                    throw new Exception(); //There should be specific exception, but I don't now which one
            }
        }

        [Test]
        public void createEmail_whenLoginPassSpecified_shouldCreateEmail()
        {
            loginPage.Login(GetUser().GetLogin(), GetUser().GetPassword());
            mainPage.FillingALetter();
            string result = loginPage.CheckingAccount();

            Assert.AreEqual(GetUser().GetLogin(), result);

            mainPage.LogOut();
        }

        [Test]
        public void checkingAndDeletingDrafts_whenDraftTopicFound_shouldDeleteTheDraft()
        {
            loginPage.Login(GetUser().GetLogin(), GetUser().GetPassword());
            mainPage.SearchAndRemoveDrafts();

            Assert.IsTrue(mainPage.IsTopicOfDraftAbsent());

            mainPage.LogOut();
        }

        [Test]
        public void checkingAndSendingMails_whenMailSent_shouldCheckMailInInboxAndSent()
        {
            loginPage.Login(GetUser().GetLogin(), GetUser().GetPassword());
            mainPage.FillingALetterTest2();

            Assert.IsTrue(mainPage.DoesTheSentMailExistInTheSents());
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