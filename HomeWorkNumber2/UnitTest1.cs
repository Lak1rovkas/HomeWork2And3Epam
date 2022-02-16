using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeWorkNumber2
{
    public class HomeWork2
    {
        private const string folderOfImportantData = @"D:\Обучение в ЕПАМ\mandp.txt"; //Обычно это в репозитории проекта и на этот файл накладывается гитигнор, но я уже менять не стал, так как работает. Хотя, могу ошибаться насчёт того, что это обычно в репозитории проекта хранят 
        private const string URL = "https://mail.yandex.ru/";
        //private const string EXPECTED_MAIL = "lakirovkas85@yandex.ru";
        //private const string MAIL = ;
        //private const string PASSWORD = "abc01de25";
        private static IWebDriver driver;
        private MainPage mainPage;
        private LoginPage loginPage;
        private static readonly string[] file = File.ReadAllLines(folderOfImportantData);

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

        public string[] ImportantData()
        {
            try
            {
                string[] textFile = file;
                return textFile;
            }
            catch
            {
                throw new Exception();
            }
        }

        [Test]
        public void createEmail_whenLoginPassSpecified_shouldCreateEmail()
        {
        loginPage.Login(ImportantData()[0], ImportantData()[1]);
        mainPage.FillingALetter();
        string result = loginPage.CheckingAccount();

        Assert.AreEqual(ImportantData()[2], result);

        mainPage.LogOut();
        }

        [Test]
        public void checkingAndDeletingDrafts_whenDraftTopicFound_shouldDeleteTheDraft()
        {
            loginPage.Login(ImportantData()[0], ImportantData()[1]);
            mainPage.SearchAndRemoveDrafts();

            Assert.IsTrue(mainPage.IsTopicOfDraftAbsent());

            mainPage.LogOut();
        }

        [Test]
        public void checkingAndSendingMails_whenMailSent_shouldCheckMailInInboxAndSent()
        {
            loginPage.Login(ImportantData()[0], ImportantData()[1]);
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