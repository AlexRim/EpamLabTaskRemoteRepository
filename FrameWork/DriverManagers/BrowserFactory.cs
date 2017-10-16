using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;

namespace DriverManagers
{
   public class BrowserFactory
    {
     //   private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException("The WebDriver instance wasn't initialized!");
                }
                return driver;
            }

            private set
            {
                driver = value;
            }

        }


        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                     //   Drivers.Add("Firefox", Driver);

                    }
                    break;
                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver(@"E:\EpamLabTasks\FrameWork\FrameWork\bin\Debug");
                      //  Drivers.Add("Chrome", Driver);
                    }
                    break;
            }


        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
            //   Driver.Navigate().GoToUrl(url);
        }

        public static void CloseAllDrivers()
        {
            //foreach (var key in Drivers.Keys)
            //{
            //   Drivers[key].Close();
            //   Drivers[key].Quit();

            //}
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
    

        }

    }
}
