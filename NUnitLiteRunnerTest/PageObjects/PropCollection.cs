using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Test2
{
    //create driver instance + auto implemented properties
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssSelector,
        ClassName
    }
    class PropCollection
    {
        //Auto-Implemented Properties
        public static IWebDriver driver { get; set; }

        public void captureScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(@"C:\Users\User\Desktop\iLab Automation\iLabAutomationProject\iLabAutomationProject\TestResults" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}
