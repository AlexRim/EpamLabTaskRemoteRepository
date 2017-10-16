using DriverManagers;
using FrameWork;
using NUnit.Framework;
using PageObjects;
using static System.Configuration.ConfigurationManager;

namespace FrameWorkTests
{
    [TestFixture]
    public class TestCase1Class
    {
        LoginPageObject loginPage;
        JournalItemsPageObject journalPage;

        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser("Firefox");
            BrowserFactory.LoadApplication(AppSettings["URL"]);
            loginPage = new LoginPageObject(BrowserFactory.Driver);
            journalPage = new JournalItemsPageObject(BrowserFactory.Driver);
            FrameWorkManager.Input_Login(AppSettings["Username"], loginPage);
            FrameWorkManager.Input_Password(AppSettings["Password"], loginPage);
            FrameWorkManager.LogIn_Button_Click(loginPage);
        }

        [Test]
        public void Check_Link_LogOut_Present_Expected_Result_True()
        {

            Assert.IsTrue(FrameWorkManager.Verify_Link_Log_Out_Is_Present(journalPage));

        }


        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseAllDrivers();
        }




    }
}
