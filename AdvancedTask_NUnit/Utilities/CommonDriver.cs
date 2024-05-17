using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Utilities
{
    public class CommonDriver
    {
        [ThreadStatic]
        public static IWebDriver driver;
        public UserDetailsPage userDetailsPageObj;
        public LanguagePage languagePage;
        public DashboardPage dashboardObj;
        public SkillsPage skillsPageObj;
        public SearchSkillsPage searchSkillsPageObj;

        // Extent Reports configuration for my tests
        public ExtentReports extent;
        public ExtentTest test;

        public void Initialize()
        {
            // Get the browser type from an environment variable or default to Chrome
            string browserType = Environment.GetEnvironmentVariable("BROWSER") ?? "Chrome";

            switch (browserType)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browserType}");
            }
        }

        [SetUp]
        public void Setup()
        {
            Initialize();

            HomePage homePage = new HomePage();
            homePage.GoToLoginPage();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.goToProfilePage();
            userDetailsPageObj = new UserDetailsPage();
            languagePage = new LanguagePage();
            dashboardObj = new DashboardPage();
            skillsPageObj = new SkillsPage();
            searchSkillsPageObj = new SearchSkillsPage();
        }

        [OneTimeSetUp]
        public void InitializeExtentReports()
        {
            var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "D:\\Industry Connect\\Mars_NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\ExtentReports\\");
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
            string screenshotDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "ExtentReports/Screenshots/");
            Directory.CreateDirectory(screenshotDir);
            string screenshotPath = Path.Combine(screenshotDir, $"{TestContext.CurrentContext.Test.Name}.png");
            //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit(); // Update to Quit() for proper browser closure
        }
    }
}