
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
        public void tc1VerifyLoginProcedurePositeTest()
        {
            try
            {
                test = extent.CreateTest("tc1VerifyLoginProcedurePositeTest").Info("tc1VerifyLoginProcedurePositeTest Started");
                LoginPageObject loginObject = new LoginPageObject();
                UpdatePageObjects pageObj = loginObject.Login(DataLib.ReadData(1, "Email"), DataLib.ReadData(1, "Password"));
                test.Log(Status.Info, "Successfully Logged In.  Email: " + DataLib.ReadData(1, "Email") + "  With Password" + DataLib.ReadData(1, "Password"));
                test.Log(Status.Pass, "tc1VerifyLoginProcedurePositeTest Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Pass, e.ToString());
                throw;
            }
        }

        [Test, Order(2)]
        public void tc2UpdateUserCredentialsUponLoginDDTPositiveTest()
        {
            DataLib2.PopulateInCollection2(@"C:\Users\User\Desktop\New folder\NUnitLiteRunnerTest\NUnitLiteRunnerTest\DataSources\Data2.xlsx");
            test = extent.CreateTest("tc2UpdateUserCredentialsUponLoginDDTPositiveTest").Info("tc2UpdateUserCredentialsUponLoginDDTPositiveTest Started");
            try
            { //testing cycle --dont forget to point to ExcelDataTableCount
                for (int i = 1; i < 6; i++)
                {
                    LoginPageObject loginObject = new LoginPageObject();

                    UpdatePageObjects pageObj = loginObject.Login(DataLib2.ReadData2(i, "Email"), DataLib2.ReadData2(i, "Password"));
                    test.Log(Status.Info, "Successfully Logged In. \n" +  " Email: " + DataLib2.ReadData2(i, "Email") + " With Password: " + DataLib2.ReadData2(i, "Password"));
                    test.Log(Status.Pass, "Login Passed for Line: " +  i + " from Datasource");
                    pageObj.UpdateDetails(DataLib2.ReadData2(i, "Initial"), DataLib2.ReadData2(i, "Name"), DataLib2.ReadData2(i, "Surname"),
                    DataLib2.ReadData2(i, "UpdateEmail"), DataLib2.ReadData2(i, "UpdatePassword"));
                    test.Log(Status.Info, "Update Passed. \n" + " Initials: " + DataLib2.ReadData2(i, "Initial") + " With Name: " + DataLib2.ReadData2(i, "Name") + 
                    " Surname: "+DataLib2.ReadData2(i, "Surname") +" Updated Email: " +DataLib2.ReadData2(i, "UpdateEmail") + " Updated Password: " + DataLib2.ReadData2(i, "Update Password"));
                }
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }

        [Test, Order(3)]
        public void tc3ValidateButtonDisplayedTrue()
        {
            try
            {
                test = extent.CreateTest("tc3ValidateButtonProperties").Info("tc3ValidateButtonProperties Started");
                PropCollection.driver.FindElement(By.Id("bSubmit"));
                test.Log(Status.Info, "Successfully Found Button");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }

        [Test, Order(4)]
        public void tc4ValidateButtonDisplayedFalse()
        {
            try
            {
                test = extent.CreateTest("tc4ValidateButtonDisplayedFalse").Info("tc4ValidateButtonDisplayedFalse Started");
                PropCollection.driver.FindElement(By.Id("btnSubmit"));
                test.Log(Status.Info, "Successfully Found Button");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }

        [Test, Order(4)]
        public void tc4ValidateHyperLinkNavigation()
        {
            test = extent.CreateTest("tc4ValidateHyperLinkNavigation").Info("tc4ValidateHyperLinkNavigation Started");
            try
            {                
                LoginPageObject loginObject = new LoginPageObject();
                loginObject.VerifyHyperLinkGithub();
                test.Log(Status.Info, "Successfully Navigated to HyperLink");
                test.Log(Status.Pass, "tc4ValidateHyperLinkNavigation Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }
    }
}
