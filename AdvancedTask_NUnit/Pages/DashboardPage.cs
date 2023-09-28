using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Pages
{
    public class DashboardPage : CommonDriver
    {
        WebDriverWait wait;
        private IWebElement dashboardButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]"));
        private IWebElement selectAllButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]"));
        private IWebElement markSelectionAsReadButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
        private IWebElement unselectAllButton => driver.FindElement(By.CssSelector(".ui.icon.basic.button.button-icon-style"));
        private IWebElement deleteSelectionButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
        private IWebElement loadMoreButton => driver.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
        private  IWebElement showLessButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[8]/div[1]/center/a"));

        public DashboardPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }
        public void notificationsSelectAll()
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]")));
            dashboardButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]")));
            selectAllButton.Click();


        }
        public void notificationsUnselectAll()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]")));
            dashboardButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]")));
            selectAllButton.Click();
                       
            // Click on the "Unselect all" button.
            unselectAllButton.Click();

        }
        public void markAllSelectedAsRead()
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]")));
            dashboardButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]")));
            selectAllButton.Click();

            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]")));
            markSelectionAsReadButton.Click();

        }
        public void loadMoreNotifications() 
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]")));
            dashboardButton.Click();
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='ui button' and text()='Load More...']")));
            loadMoreButton.Click();

            // Get the JavascriptExecutor object.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Execute the JavaScript code to scroll the page to the bottom.
            js.ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");


        }
        public void showLessNotifications()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]")));
            dashboardButton.Click();
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='ui button' and text()='Load More...']")));
            loadMoreButton.Click();

            // Get the JavascriptExecutor object.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Execute the JavaScript code to scroll the page to the bottom.
            js.ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[8]/div[1]/center/a")));
            showLessButton.Click();

        }

        public void deleteSelection()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]")));
            dashboardButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]")));
            selectAllButton.Click();
            // Identify the "Delete selection" button.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]")));
            // Click on the "Delete selection" button.
            deleteSelectionButton.Click();




        }
    }

}
