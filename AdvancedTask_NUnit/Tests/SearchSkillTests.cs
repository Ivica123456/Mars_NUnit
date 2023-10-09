using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Tests
{
    public class SearchSkillTests: CommonDriver
    {
        [Test, Order(1), Description("Request Skill Trade")]
        public void requestSkillTrade()
        {
            // Log the test step in the Extent Report
            test.Info("Starting Request Skill Trade...");

            searchSkillsPageObj.sendRequest("zl","Let's trade","test123@yahoo.com","mars123");

           
            // Assert that the message is present on the page
            Assert.That(driver.PageSource, Contains.Substring("You have Pending trade request from IvicaCuncic."));
            test.Pass("ReceivedRequests message is present on the page");


        }
    }
}
