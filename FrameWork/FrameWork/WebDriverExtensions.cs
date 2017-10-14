using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameWork
{
   public static class WebDriverExtensions
    {
        public static IWebElement MyFindElement(this IWebDriver driver, By by, int timeOutSeconds)
        {
            if (timeOutSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutSeconds));
                return wait.Until(d => d.FindElement(by));
            }
            return driver.FindElement(by);
        }

    }
}
