using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvancedTask_NUnit.Pages
{
    public class UserDetailsPage : CommonDriver
    {
        WebDriverWait wait;

        public UserDetailsPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
           
        }
       
        public void availabilityAdd(ProfilePage_DataModel profilePage_DataModel)
        {

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")));
            IWebElement changeAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            changeAvailability.Click();
          
            // Find the <select> element using its ID or other locator
            IWebElement selectElement1 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
          
            // Create a SelectElement object
            SelectElement select = new SelectElement(selectElement1);
            select.SelectByText(profilePage_DataModel.availability);
            changeAvailability.Click();

            // Refresh the page
            driver.Navigate().Refresh();

            
        }
        public string actaulAvailability()
        {
           
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span")));
            IWebElement actualAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
            return actualAvailability.Text;
        }
       
        public void hoursUpdateAdd(ProfilePage_DataModel profilePage_DataModel)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")));
            IWebElement addHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
            addHours.Click();

            // Find the <select> element using its ID or other locator
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")));
            IWebElement selectElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            selectElement.Click();

            // Create a SelectElement object
            SelectElement select = new SelectElement(selectElement);
            select.SelectByText(profilePage_DataModel.hours);
            driver.Navigate().Refresh();
            


        }
        public string actaulhoursUpdate()
        {
            IWebElement actualhoursUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span"));
            return actualhoursUpdate.Text;
        }
        public void earnTargetUpdate(ProfilePage_DataModel profilePage_DataModel)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")));
            IWebElement addEarnTarget = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
            addEarnTarget.Click();

            // Find the <select> element using its ID or other locator
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select")));
            IWebElement selectElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
            selectElement.Click();

            // Create a SelectElement object
            SelectElement select = new SelectElement(selectElement);
            select.SelectByText(profilePage_DataModel.earnTarget);
            driver.Navigate().Refresh();
           
            
        }
        public string actualEarnTarget ()
        {
            IWebElement actualhoursUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div"));
            return actualhoursUpdate.Text;

        }
    }
    
}
