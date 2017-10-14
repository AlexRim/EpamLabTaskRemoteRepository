using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FrameWork;

namespace PageObjects
{
    class ArticleToolsPageObject
    {
        private IWebDriver driver;

        public ArticleToolsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement View_Full_Text_Menu_Item
        {
            get => this.driver.MyFindElement(By.LinkText("View Full Text"),5);
        }

        public IWebElement Article_As_Pdf_Menu_Item
        {
            get => this.driver.MyFindElement(By.LinkText("Article as PDF (64 KB)"), 5);
        }

        public IWebElement Article_As_Epub
        {
            get => this.driver.MyFindElement(By.LinkText("Article as EPUB"),5);
        }





    }
}
