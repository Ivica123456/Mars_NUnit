using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Pages;
using AdvancedTask_NUnit.Utilities;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Tests
{
    [TestFixture]
    public class LanguageTests: CommonDriver
    {
        [Test]
        [Order(1)]
        public void AddLanguagesTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddLanguagesTest...");

            string jsonContent = File.ReadAllText("C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\language.json");
            List<LanguageDataModel> languageList = JsonConvert.DeserializeObject<List<LanguageDataModel>>(jsonContent);

            LanguagePage languagePage = new LanguagePage();
            languagePage.AddLanguages(languageList);

            VerifyLanguagesInTable(languageList);
        }

        private void VerifyLanguagesInTable(List<LanguageDataModel> expectedLanguages)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table element to be visible
            IWebElement table = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")));

            var rows = table.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));

            // Assert that the number of rows in the table matches the expected count
            Assert.That(rows.Count, Is.EqualTo(expectedLanguages.Count), $"The number of rows in the table is incorrect. Expected: {expectedLanguages.Count}, Actual: {rows.Count}");

            for (int i = 0; i < expectedLanguages.Count; i++)
            {
                IWebElement row = rows[i];
                string language = row.FindElements(By.TagName("td"))[0].Text;
                string level = row.FindElements(By.TagName("td"))[1].Text;

                Assert.That(language, Is.EqualTo(expectedLanguages[i].language), $"The language in row {i + 1} is incorrect.");
                test.Pass("Language value verified.");
                Assert.That(level, Is.EqualTo(expectedLanguages[i].level), $"The level in row {i + 1} is incorrect.");
                test.Pass("Level value verified.");
            }
        }


        [Test]
        [Order(2)]
        public void AddLanguagesInvalidDataTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddLanguagesTestInvalidDataTest...");

            string jsonContent = File.ReadAllText("C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\language.json");
            List<LanguageDataModel> languageList = JsonConvert.DeserializeObject<List<LanguageDataModel>>(jsonContent);

            LanguagePage languagePage = new LanguagePage();
            languagePage.AddLanguages(languageList);



            string jsonContent1 = File.ReadAllText("C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\negative_languages.json");
            List<LanguageDataModel> languageList1 = JsonConvert.DeserializeObject<List<LanguageDataModel>>(jsonContent1);

            // Wait for the table element to be visible
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement table1 = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table")));

            var rows1 = table1.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));


            Assert.That(rows1.Count, Is.Not.EqualTo(languageList1.Count), "The number of rows in the table is correct.");

            for (int i = 0; i < languageList.Count && i <= rows1.Count - 1; i++)
            {
                IWebElement row = rows1[i];
                string language = row.FindElements(By.TagName("td"))[0].Text;
                string level = row.FindElements(By.TagName("td"))[1].Text;

                //string language = rows1[i].FindElements(By.TagName("td"))[0].Text;
                //string level = rows1[i].FindElements(By.TagName("td"))[1].Text;
                Assert.That(language, Is.Not.EqualTo(languageList1[i].language), $"The language in row {i + 1} is correct.");
                test.Pass("Language value verified.");

                Assert.That(level, Is.Not.EqualTo(languageList1[i].level), $"The level in row {i + 1} is correct.");
                test.Pass("Level value verified.");
            }


        }



        [Test]
        [Order(3)]
        public void EditLanguageTests()
        {
            // Log the test step in the Extent Report
            test.Info("Starting EditLanguageTests");
            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\edit_languages.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            LanguageDataModel languageDataModel = JsonConvert.DeserializeObject<LanguageDataModel>(jsonContent);

            // Access the values from the DataModel object
            string language = languageDataModel.language;
            string level = languageDataModel.level;



            LanguagePage languagePage = new LanguagePage();
            languagePage.EditLanguages(languageDataModel);

            Assert.That(languagePage.GetEditLanguages(), Is.EqualTo(language), "Title should match the expected value.");
            test.Pass("Language value verified.");
            Assert.That(languagePage.GetEditLevel(), Is.EqualTo(level), "Title should match the expected value.");
            test.Pass("Level value verified.");

        }
        [Test, Order(4)]
        public void DeleteLanguagesTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting DeleteLanguagesTest");

            List<string> languagesToDelete = new List<string>()
            {
             "Croatian",
             "Italian",
            };

            LanguagePage languagePage = new LanguagePage();
            languagePage.DeleteLanguages(languagesToDelete);

            // Assert that the languages were deleted successfully
            foreach (string language in languagesToDelete)
            {
                IWebElement languageRow = null;
                try
                {
                    languageRow = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));

                }
                catch (NoSuchElementException)
                {
                    // Language row not found, which means it was deleted successfully
                }



                Assert.That(languageRow, Is.Null, $"The language '{language}' was not deleted.");
                test.Pass(" value verified DeleteLanguagesTest.");
            }
        }

        [Test, Order(5)]
        public void DeleteNonExistentLanguageTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting DeleteNonExistentLanguageTest");



            List<string> languagesToDelete = new List<string>()
            {
             "German" // This language doesn't exist in the table
            };

            LanguagePage languagePage = new LanguagePage();
            languagePage.DeleteLanguages(languagesToDelete);

            // Assert that the languages were not deleted (i.e., still exist)
            foreach (string language in languagesToDelete)
            {
                IWebElement languageRow = null;
                try
                {
                    languageRow = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
                }
                catch (NoSuchElementException)
                {
                    // Language row not found, which means it wasn't deleted (negative case)
                }

                Assert.That(languageRow, Is.Not.Null, $"The language '{language}' was incorrectly deleted.");
                test.Pass("Negative case verified in DeleteNonExistentLanguageTest.");
            }
        }
    }
}
