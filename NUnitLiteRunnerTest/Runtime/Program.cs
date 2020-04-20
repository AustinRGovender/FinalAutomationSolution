using NUnitLite;
using NUnit.Framework;
using Interview.Test2;
using AventStack.ExtentReports;
using System;
using OpenQA.Selenium;

namespace NUnitLite.Tests
{   [TestFixture]
    public class Program : BaseTest
    {
        public static int Main(string[] args)
        {
            return new AutoRun().Execute(args);
        }

        [Test, Order(1)]
        public void tc1ValidateUrlAgainstDataSource()
        {
            test = extent.CreateTest("tc1ValidateUrlAgainstDataSource").Info("tc1ValidateUrlAgainstDataSource Started");
            string currentUrl = null;
            string expectedUrl = null;
            currentUrl = PropCollection.driver.Url;
            //sort out the stream processing
            expectedUrl = DataLib.ReadData(1,"URL");
            try
            {

                if (currentUrl == expectedUrl)
                    test.Log(Status.Info, "Correct System Under Test");
                    test.Log(Status.Pass, "Navigated to Correct URL.   URL Returned: " + currentUrl + " Expected: " + expectedUrl);
            }
            catch
            (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                test.Log(Status.Pass, "Navigated to Correct URL.   URL Returned: " + currentUrl + " Expected: " + expectedUrl);
                throw;
            }
        }
    

        [Test, Order(2)]
        public void tc2ValidateButtonIsDisplayedTrue()
        {
            try
            {
                test = extent.CreateTest("tc2ValidateIsButtonDisplayedTrue").Info("tc2ValidateButtonIsDisplayedTrue Started");
                PropCollection.driver.FindElement(By.CssSelector("#pageContent > div > form > input[type=" 
                    + "submit" + "]:nth-child(5)"));
                test.Log(Status.Info, "Successfully Found Button");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }

        [Test, Order(3)]
        public void tc3ValidateButtonIsDisplayedFalse()
        {
            try
            {
                test = extent.CreateTest("tc3ValidateButtonIsDisplayedFalse").Info("tc3ValidateButtonIsDisplayedFalse Started");
                PropCollection.driver.FindElement(By.CssSelector("#pageContent > form > input[type="
                    + "submit" + "]:nth-child(7)"));
                test.Log(Status.Info, "Successfully Found Button");
            }
            catch (NoSuchElementException e)
            {
                test.Log(Status.Fail, e.ToString());
            }
        }

        [Test, Order(4)]
        public void tc4UpdateUserCredentialsUponLoginDDTPositiveTest()
        {
            DataLib2.PopulateInCollection2(@"DataSources\Data2.xlsx");

            test = extent.CreateTest("tc4UpdateUserCredentialsUponLoginDDTPositiveTest").Info("tc4UpdateUserCredentialsUponLoginDDTPositiveTest Started");
            try
            { //testing cycle -- point to ExcelDataTableCount
                for (int i = 1; i < 6; i++)
                {
                    LoginPageObject loginObject = new LoginPageObject();

                    UpdatePageObjects pageObj = loginObject.Login(DataLib2.ReadData2(i, "Email"), DataLib2.ReadData2(i, "Password"));
                    test.Log(Status.Info, "Successfully Logged In. \n" + " Email: " + DataLib2.ReadData2(i, "Email") +
                    " With Password: " + DataLib2.ReadData2(i, "Password"));
                    test.Log(Status.Pass, "Login Passed for Line: " + i + " from Datasource");
                    pageObj.UpdateDetails(DataLib2.ReadData2(i, "Initial"), DataLib2.ReadData2(i, "Name"),
                        DataLib2.ReadData2(i, "Surname"),
                    DataLib2.ReadData2(i, "UpdateEmail"), DataLib2.ReadData2(i, "UpdatePassword"));
                    test.Log(Status.Info, "Update Passed. \n" + " Initials: " + DataLib2.ReadData2(i, "Initial") +
                    " With Name: " + DataLib2.ReadData2(i, "Name") +
                    " Surname: " + DataLib2.ReadData2(i, "Surname") + " Updated Email: " + DataLib2.ReadData2(i, "UpdateEmail") +
                    " Updated Password: " + DataLib2.ReadData2(i, "UpdatePassword"));
                }
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }


    }
}
