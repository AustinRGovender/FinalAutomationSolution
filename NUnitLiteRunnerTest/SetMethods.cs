using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Interview.Test2
{
    public static class SetMethods
    {

        //Enter Text
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
            //no more stronglytyped variables
        }

        //Click Button Operation
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        //Selecting a ddl
        //Not using
        public static void SelectDropdown(this IWebElement element, string value)
        {
                new SelectElement(element).SelectByText(value);
        }
    }
}

