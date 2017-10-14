using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace FrameWork.PageObjects
{
    class JournalPage
    {
        private IWebDriver driver;

        public JournalPage (IWebDriver driver)
        {
            this.driver = driver;
        }

  
        public IWebElement LogOutLink { get => this.driver.MyFindElement(By.LinkText("Log Out"),5);}

        public IWebElement JournalToSearchLink { get => this.driver.MyFindElement(By.LinkText("Academic Medicine"), 5); }

        public IWebElement FreeArticleLink { get => this.driver.MyFindElement(By.LinkText("We Must Not Let " +
            "Clinician–Scientists Become an Endangered Species"), 5); }

       






    }
}
