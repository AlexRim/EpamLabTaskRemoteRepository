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


        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Log Out")]
        private IWebElement Log_Out_Link
        {
            get; set;
        }


        [FindsBy(How = How.Id, Using = "ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_UserName")]
        private IWebElement UserNameInput
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_Password")]
        private IWebElement PasswordInput
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_LoginButton")]
        private IWebElement LoginButton
        {
            get;
            set;
        }


        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
