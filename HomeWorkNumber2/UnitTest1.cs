using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeWorkNumber2
{
    public class HomeWork2
    {
        private const string URL = "https://mail.yandex.ru/";
        private const string EXPECTED_MAIL = "lakirovkas85@yandex.ru";
        private const string MAIL = "lakirovkas85@yandex.ru";
        private const string PASSWORD = "abc01de25";

        private static IWebDriver driver;
        private MainPage mainPage;
        private LoginPage loginPage;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            mainPage = new MainPage(driver);
            loginPage = new LoginPage(driver);
            
            mainPage.GetDriver().Navigate().GoToUrl(URL);
            mainPage.Open();
        }

        [Test]
        public void createEmail_whenLoginPassSpecified_shouldCreateEmail() 
        {
            loginPage.Login(MAIL, PASSWORD);
            mainPage.FillingALetter();
            string result = loginPage.CheckingAccount();
            
            Assert.AreEqual(EXPECTED_MAIL, result);

            mainPage.LogOut();
        }

        [Test]
        public void checkingAndDeletingDrafts_whenDraftTopicFound_shouldDeleteTheDraft()
        {            
            loginPage.Login(MAIL, PASSWORD);
            mainPage.SearchAndRemoveDrafts();

            Assert.IsTrue(mainPage.IsTopicOfDraftAbsent());

            mainPage.LogOut();
        }

        [TearDown]
        public void closeBrowser()
        {
            mainPage.GetDriver().Quit();
        }
    }
}