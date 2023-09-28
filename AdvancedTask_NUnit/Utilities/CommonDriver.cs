using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvancedTask_NUnit.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public UserDetailsPage userDetailsPageObj;
        public LanguagePage languagePage;
        public DashboardPage dashboardObj;
        public SkillsPage skillsPageObj;

        //Extent Reports configuration for my tests store in CommonDriver part1 starts:
        public ExtentReports extent;
        public ExtentTest test;
        


        public void Initialize()
        {

            driver = new ChromeDriver();
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            HomePage homePage = new HomePage();
            homePage.GoToLoginPage();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.goToProfilePage();
            userDetailsPageObj = new UserDetailsPage();
            languagePage = new LanguagePage();
            dashboardObj = new DashboardPage();
            skillsPageObj = new SkillsPage();
            
           


        }
        //Extent Reports configuration for my tests store in CommonDriver part2 start:

        [OneTimeSetUp]
        public void InitializeExtentReports()
        {
            var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\ExtentReports\\");
            var extentHtmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(extentHtmlReporter);
        }

        [OneTimeTearDown]
        public void FlushExtentReports()
        {
            extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string screenshotPath = TakeScreenshot();
                test.AddScreenCaptureFromPath(screenshotPath);
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                test.Pass("Test Passed");
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Fail("Test Failed");
            }
        }

        private string TakeScreenshot()
        {
            string screenshotDir = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\ExtentReports\\";
            Directory.CreateDirectory(screenshotDir);
            string screenshotPath = Path.Combine(screenshotDir, $"{TestContext.CurrentContext.Test.Name}.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }






    }


}
