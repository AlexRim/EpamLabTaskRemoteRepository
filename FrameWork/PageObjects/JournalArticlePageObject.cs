using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace PageObjects
{
   public class JournalArticlePageObject
    {

        private IWebDriver driver;
        private readonly int timeToWaitSeconds = 10;
        private WebDriverWait Wait { get; set; }

        public JournalArticlePageObject(IWebDriver driver)
        {
            this.driver = driver;
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }


        public IWebElement Free_Article_Link
        {
            get => this.driver.MyFindElement
                (By.LinkText("We Must Not Let Clinician–Scientists Become an Endangered Species"), timeToWaitSeconds);
        }

        public IWebElement Article_As_Pdf_Menu_Item_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Article as PDF (64 KB)"), timeToWaitSeconds);
        }


        public IWebElement Article_As_Epub_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Article as EPUB"), timeToWaitSeconds);
        }

        public IWebElement Print_This_Article_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Print this Article"), timeToWaitSeconds);
        }

        public IWebElement Email_To_Colleague_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Email To Colleague"), timeToWaitSeconds);
        }

        public IWebElement Add_To_My_Favorites_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Add to My Favorites"), timeToWaitSeconds);
        }

        public IWebElement Export_To_Citation_Manager_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Export to Citation Manager"), timeToWaitSeconds);
        }

        public IWebElement Alert_Me_When_cited_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Alert Me When cited"), timeToWaitSeconds);
        }

        public IWebElement Get_Content_And_Permissions_Link
        {
            get => this.driver.MyFindElement(By.LinkText("Get Content & Permissions"), timeToWaitSeconds);
        }
    }
}
