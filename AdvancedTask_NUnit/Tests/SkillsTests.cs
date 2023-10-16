using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Pages;
using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdvancedTask_NUnit.Tests
{
    [TestFixture]
    public class SkillsTests : CommonDriver
    {
        [Test]
        [Order(1)]

       
        public void AddSkillTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddSkillTests");
            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\skills.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            SkillsDataModel skillsDataModel = JsonConvert.DeserializeObject<SkillsDataModel>(jsonContent);

            // Access the values from the DataModel object
            string name = skillsDataModel.Name;
            string level = skillsDataModel.Level;

            
            skillsPageObj.AddSkills(skillsDataModel);
            

            
            Assert.That(skillsPageObj.getAddSkill(), Is.EqualTo(name), "Title should match the expected value.");
            test.Pass("Skill value verified.");
            Assert.That(skillsPageObj.getAddSkillLevel(), Is.EqualTo(level), "Title should match the expected value.");
            test.Pass("Level value verified.");

        }
        [Test]
        [Order(2)]

        public void editSkillsTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddSkillTests");
            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\editSkills.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            SkillsDataModel skillsDataModel = JsonConvert.DeserializeObject<SkillsDataModel>(jsonContent);

            // Access the values from the DataModel object
            string name = skillsDataModel.Name;
            string level = skillsDataModel.Level;


            skillsPageObj.editSkill(skillsDataModel);


            Assert.That(skillsPageObj.getEditSkill(), Is.EqualTo(name), "Title should match the expected value.");
            test.Pass("Skill value verified.");
            Assert.That(skillsPageObj.getEditSkillLevel(), Is.EqualTo(level), "Title should match the expected value.");
            test.Pass("Level value verified.");

        }
        [Test]
        [Order(3)]
        public void deleteTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddSkillTests");

            skillsPageObj.deleteButton();

            // Verify that the button is no longer present
            Assert.IsFalse(driver.FindElements(By.Id("delete-button")).Count > 0);

        }

    }


}
