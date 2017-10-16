using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects;
using OpenQA.Selenium;
namespace FrameWork
{
    public static  class FrameWorkManager
    {


        public static void Input_Login(string login, LoginPageObject loginPage)
        {
            loginPage.UserNameInput.Clear();
            loginPage.UserNameInput.SendKeys(login);
        }

        public static void Input_Password(string password, LoginPageObject loginPage)
        {
            loginPage.PasswordInput.Clear();
            loginPage.PasswordInput.SendKeys(password);
        }


        public static void LogIn_Button_Click(LoginPageObject loginPage)
        {
            loginPage.LoginButton.Click();
        }

        public static bool Verify_Link_Log_Out_Is_Present(JournalItemsPageObject journalPage)
        {
            return journalPage.Log_Out_Link.Displayed;
        }

        public static void Click_Journal_To_Search_Link(JournalItemsPageObject page)
        {
            page.Journal_To_Search_Link.Click();
        }

        public static void Switch_Window(IWebDriver driver)
        {
            //driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchTo().Window(driver.WindowHandles[1]);

        }

        public static void Click_Open_Article_Link( JournalArticlePageObject page)
        {
            page.Free_Article_Link.Click();
        }

        public static bool Verify_Article_Tools_Menu_Items_Present(JournalArticlePageObject page)
        {
           if(page.Article_As_Pdf_Menu_Item_Link.Displayed && page.Article_As_Epub_Link.Displayed
                && page.Email_To_Colleague_Link.Displayed &&
               page.Add_To_My_Favorites_Link.Displayed && page.Export_To_Citation_Manager_Link.Displayed 
               && page.Alert_Me_When_cited_Link.Displayed &&
              page.Get_Content_And_Permissions_Link.Displayed)
            {
                return true;
            }
            else
            {
                 return false;
            }
          

         
          
        }




    }
}
