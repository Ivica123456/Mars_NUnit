using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTask_NUnit.DataModel;

namespace AdvancedTask_NUnit.Pages
{
    public class LanguagePage : CommonDriver
    {
        WebDriverWait wait;
        private IWebElement clickLanguageButton => driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.top.attached.tabular.menu > a.item.active"));
        private IWebElement addNewButton => driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > thead > tr > th.right.aligned > div"));
        private IWebElement addLanguageTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        private IWebElement chooseLanguageLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
        private IWebElement addLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));

        public LanguagePage()
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            // Initialize WebDriverWait and set implicit wait timeout
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }



        public void AddLanguages(List<LanguageDataModel> languages)
        {
            foreach (LanguageDataModel language in languages)
            {
                if (string.IsNullOrEmpty(language.language) || string.IsNullOrEmpty(language.level))
                {
                    continue;
                }

                clickLanguageButton.Click();
                addNewButton.Click();
                addLanguageTextBox.Clear();
                addLanguageTextBox.SendKeys(language.language);
                chooseLanguageLevel.Click();
                SelectElement selectElementLanguageLevel = new(chooseLanguageLevel);
                selectElementLanguageLevel.SelectByValue(language.level);
                addLanguage.Click();
                //Refresh page
                driver.Navigate().Refresh();
            }
        }


        public void EditLanguages(LanguageDataModel languageDataModel)
        {


            clickLanguageButton.Click();
            editButton.Click();
            IWebElement editLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            editLanguageTextBox.Clear();
            editLanguageTextBox.SendKeys(languageDataModel.language);
            IWebElement editLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            editLanguageLevel.Click();
            SelectElement selectElementLanguageLevel = new(editLanguageLevel);
            selectElementLanguageLevel.SelectByValue(languageDataModel.level);
            updateButton.Click();
            // Refresh the page
            driver.Navigate().Refresh();

        }
        public string GetEditLanguages()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")));
            IWebElement actualLanguages = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return actualLanguages.Text;
        }
        public string GetEditLevel()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]")));
            IWebElement actualLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
            return actualLevel.Text;
        }




        public void DeleteLanguages(List<string> languagesToDelete)
        {
            string combinedXPath = string.Join(" | ", languagesToDelete.Select(language =>
                $"//table/tbody//tr/td[contains(text(), '{language}')]/following-sibling::td[2]/span[2]"));

            IReadOnlyCollection<IWebElement> deleteButtons = driver.FindElements(By.XPath(combinedXPath));

            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
               
            }
            // Refresh the page
            driver.Navigate().Refresh();
        }

    }
}
