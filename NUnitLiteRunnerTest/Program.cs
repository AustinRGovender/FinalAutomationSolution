// ***********************************************************************
// Copyright (c) 2015 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using NUnitLite;
using NUnit.Framework;
using Interview.Test2;
using AventStack.ExtentReports;
using System;

namespace NUnitLite.Tests
{   [TestFixture]
    public class Program : BaseTest
    {
        /// <summary>
        /// The main program executes the tests. Output may be routed to
        /// various locations, depending on the arguments passed.
        /// </summary>
        /// <remarks>Run with --help for a full list of arguments supported</remarks>
        /// <param name="args"></param>
        public static int Main(string[] args)
        {
            return new AutoRun().Execute(args);
        }

        [Test, Order(1)]
        [Author("Austin Ryan Govender", "austinryang1@gmai.com")]
        [Description("This test is to simulate Logging in to the application via via credentials parsed in Excel Data Source")]
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
        public void tc3ValidateButtonProperties()
        {

        }

        [Test, Order(4)]
        public void tc4ValidateHyperLinkNavigation()
        {
            test = extent.CreateTest("tc1VerifyLoginProcedurePositeTest").Info("tc1VerifyLoginProcedurePositeTest Started");
            try
            {
                test = extent.CreateTest("tc1VerifyLoginProcedurePositeTest").Info("tc1VerifyLoginProcedurePositeTest Started");
                LoginPageObject loginObject = new LoginPageObject();
                loginObject.VerifyHyperLinkGithub();
                test.Log(Status.Info, "Successfully Logged In with DS Data");
                test.Log(Status.Pass, "tc1VerifyLoginProcedurePositeTest Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }
    }
}
