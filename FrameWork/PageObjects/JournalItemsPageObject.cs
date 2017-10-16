using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace PageObjects
{
  public  class JournalItemsPageObject
    {

        private IWebDriver driver;

      
        public JournalItemsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly int timeToWaitSeconds =30;

        public IWebElement Log_Out_Link { get => this.driver.MyFindElement(By.LinkText("Log Out"), timeToWaitSeconds); }

        public IWebElement Journal_To_Search_Link { get => this.driver.MyFindElement(By.LinkText("Academic Medicine"), timeToWaitSeconds); }

        public IWebElement Free_Article_Link
        {
            get => this.driver.MyFindElement
                (By.LinkText("We Must Not Let Clinician–Scientists Become an Endangered Species"), timeToWaitSeconds);
        }

        //public IWebElement Free_Article_Link
        //{
        //    get => this.driver.MyFindElement(By.XPath("//*[@id='wpFeatureArticles']/div[1]/article[1]/div/div/header/h4/a"), timeToWaitSeconds);
        //}

        public IWebElement Table_Of_Contents_Outline_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Table of Contents Outline"), timeToWaitSeconds);
        }

        public IWebElement Subscribe_to_eTOC_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Subscribe to eTOC"), timeToWaitSeconds);
        }

        public IWebElement View_Contributor_Index_Link
        {
            get => this.driver.MyFindElement(By.LinkText("View Contributor Index"), timeToWaitSeconds);
        }


    }
}
