using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Pages
{
    public class SearchSkillsPage: CommonDriver
    {
        WebDriverWait wait;
        private IWebElement searchIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
        private IWebElement searchUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));
        private IWebElement chooseUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[2]"));
        private IWebElement serviceInfo => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[2]/div[1]/a[2]"));
        private IWebElement messageTextBox => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea"));
        private IWebElement requestButton => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]"));
        private IWebElement confirmTraderequestButton => driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[1]"));
        private IWebElement signOut => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[1]/div[2]/div/a[2]"));
        private IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailAddressTextBox => driver.FindElement(By.Name("email"));
        private IWebElement passwordTexbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement loginButton => driver.FindElement(By.CssSelector("body > div.ui.page.modals.dimmer.transition.visible.active > div > div > div:nth-child(1) > div > div:nth-child(5) > button"));

        public SearchSkillsPage()
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            // Initialize WebDriverWait and set implicit wait timeout
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void sendRequest(string user,string message,string email,string password)
        {
            searchIcon.Click();
            searchUser.Click();
            searchUser.SendKeys(user);
            searchUser.Click();
            chooseUser.Click();
            serviceInfo.Click();
            messageTextBox.SendKeys(message);
            requestButton.Click();
            confirmTraderequestButton.Click();

            //Received Requests message is present on the page
            signOut.Click();
            signInButton.Click();
            emailAddressTextBox.SendKeys(email);
            passwordTexbox.SendKeys(password);
            loginButton.Click();

        }
        

    }
}
