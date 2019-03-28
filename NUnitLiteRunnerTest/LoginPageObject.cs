using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Test2
{
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropCollection.driver, this);
        }

        //FindById
        [FindsBy(How = How.Id, Using = "emailT")]
        public IWebElement txtEmail { get; set; }
        //ForFailCondition
        [FindsBy(How = How.Id, Using = "ema")]
        public IWebElement txtEmailFail { get; set; }
        //FindByName
        [FindsBy(How = How.Name, Using = "psw")]
        public IWebElement txtPassword { get; set; }
        //FindByCssSelector
        [FindsBy(How = How.CssSelector, Using = "#pageContent > div > form > input[type="+"submit"+"]:nth-child(5)")]
        public IWebElement btnSubmit { get; set; }
        //FindById-Link
        [FindsBy(How = How.Id, Using = "link1")]
        public IWebElement hLink { get; set; }

        public UpdatePageObjects Login(string email, string password)
        {
            txtEmail.EnterText(email);
            Console.WriteLine("Email is: " + txtEmail.GetText());
            txtPassword.EnterText(password);
            Console.WriteLine("Password is: " + txtPassword.GetText());
            btnSubmit.Clicks();

            return new UpdatePageObjects();
        }

        public UpdatePageObjects LoginFail(string email, string password)
        {
            txtEmailFail.EnterText(email);
            Console.WriteLine("Email is: " + txtEmail.GetText());
            txtPassword.EnterText(password);
            Console.WriteLine("Password is: " + txtPassword.GetText());
            btnSubmit.Clicks();

            return new UpdatePageObjects();
        }

        public void VerifyHyperLinkGithub()
        {
            hLink.Clicks();
        }
    }
}
