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
    public class LoginPageObject
    {
        private readonly int timeToWaitSeconds = 10;

        private IWebDriver driver;

        //[FindsBy(How = How.LinkText, Using = "Log Out")]
        //public IWebElement Log_Out_Link
        //{
        //    get; 
        //}


        //[FindsBy(How = How.Id, Using = "ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_UserName")]
        //public IWebElement UserNameInput
        //{
        //    get; 
        //}

       // [FindsBy(How = How.Id, Using = "ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_Password")]
       //public IWebElement PasswordInput
       // {
       //     get;
       // }

        //[FindsBy(How = How.Id, Using = "ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_LoginButton")]
        //public IWebElement LoginButton
        //{
        //    get;          
        //}


        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
        }


        public IWebElement UserNameInput
        {
            get => this.driver.MyFindElement(By.Id("ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_UserName"), timeToWaitSeconds);
        }


        public IWebElement PasswordInput
        {
            get => this.driver.MyFindElement(By.Id("ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_Password"), timeToWaitSeconds);
        }

        public IWebElement LoginButton
        {
            get => this.driver.MyFindElement(By.Id("ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_LoginButton"), timeToWaitSeconds);
        }

    }
}
