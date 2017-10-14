using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NUnit.Framework;
using FrameWork.WrapperFactory;
using FrameWork.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using static System.Configuration.ConfigurationManager;

namespace FrameWork
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void Test()
        {
          BrowserFactory.InitBrowser("Chrome");
          BrowserFactory.LoadApplication(AppSettings["URL"]);
          var loginPage = new LoginPage(BrowserFactory.Driver);
          loginPage.LoginToJournal();
          Assert.IsTrue(loginPage.VerifyLinkLogOutIsPresent());
          BrowserFactory.CloseAllDrivers();



        }
        


    }
}
