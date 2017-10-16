using DriverManagers;
using FrameWork;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System;
using System.Threading;
using static System.Configuration.ConfigurationManager;

namespace FrameWorkTests
{
    [TestFixture]
    class TestCase2Class
    {
        LoginPageObject loginPage;
        JournalItemsPageObject journalPage;
        JournalArticlePageObject journalArticlePage;
        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser("Firefox");
           
            BrowserFactory.LoadApplication(AppSettings["URL"]);
            loginPage = new LoginPageObject(BrowserFactory.Driver);
            journalPage = new JournalItemsPageObject(BrowserFactory.Driver);

            journalArticlePage = new JournalArticlePageObject(BrowserFactory.Driver);

            FrameWorkManager.Input_Login(AppSettings["Username"], loginPage);
            FrameWorkManager.Input_Password(AppSettings["Password"], loginPage);
            FrameWorkManager.LogIn_Button_Click(loginPage);

            journalArticlePage = new JournalArticlePageObject(BrowserFactory.Driver);



        }


        [Test]
        public void Check_Article_Tools_Menu_ItemsPresent_Expected_Result_True()
        {
            FrameWorkManager.Click_Journal_To_Search_Link(journalPage);
            Thread.Sleep(1000);
            FrameWorkManager.Switch_Window(BrowserFactory.Driver);
            journalArticlePage.Free_Article_Link.Click();
            FrameWorkManager.Verify_Article_Tools_Menu_Items_Present(journalArticlePage);
            Assert.IsTrue(FrameWorkManager.Verify_Article_Tools_Menu_Items_Present(journalArticlePage));
            //   journalPage.Free_Article_Link.Click();
            //JournalArticlePageObject journalArticlePage = new JournalArticlePageObject(BrowserFactory.Driver);
            //FrameWorkManager.Click_Open_Article_Link(journalArticlePage);
            //articleToolsPage = new ArticleToolsPageObject(BrowserFactory.Driver);

            //FrameWorkManager.Verify_Article_Tools_Menu_Items_Present(articleToolsPage);
            //Assert.IsTrue(FrameWorkManager.Verify_Article_Tools_Menu_Items_Present(articleToolsPage));

        }
        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseAllDrivers();
        }

    }
}
