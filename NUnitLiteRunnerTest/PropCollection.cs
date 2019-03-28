using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Test2
{

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
    }
}
