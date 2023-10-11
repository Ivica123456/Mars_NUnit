using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.AssertHelper
{
    public class AssertPage : CommonDriver
    {
        WebDriverWait wait;

        public AssertPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));


        }
        public void assertSelectedAllNotitications()
        {
            // Get all the elements in the list
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("li"));

            // Assert that all the elements are selected
            foreach (IWebElement element in elements)
            {
                Assert.IsTrue(element.Selected);
            }
        }
        public void assertUnselectAll()
        {
            // Get all the elements in the list.
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("li"));

            // Assert that all the elements in the list are unselected.
            foreach (IWebElement element in elements)
            {
                Assert.IsFalse(element.Selected);

            }

        }
        public void assertMarkSelectionAsRead()
        {
            // Get all the elements of the notifications.
            IList<IWebElement> notifications = driver.FindElements(By.CssSelector(".notification"));

            // Check if each notification is marked as read.
            foreach (IWebElement notification in notifications)
            {
                string isRead = notification.GetAttribute("read");

                // Assert that the notification is marked as read.
                Assert.That(isRead, Is.EqualTo("true"));

            }

        }
        public void assertloadMoreNotifications()
        {
            // Assert that the "Show Less" button is now visible
            IWebElement showLessButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[8]/div[1]/center/a"));
            Assert.IsTrue(showLessButton.Displayed);
            test.Pass("  notifications are loaded.");
        }
        public void assertShowLessNotifications()
        {
            // Assert that the "Load More" button is now visible
            IWebElement loadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
            Assert.IsTrue(loadMoreButton.Displayed);
            test.Pass("  notifications less are loaded.");

        }


        public void assertDashboardNotificationDelete()
        {
            //// Get all the elements of the notifications.
            IList<IWebElement> notifications = driver.FindElements(By.CssSelector(".notification"));


            // Assert that there are no notifications left.
            Assert.That(notifications.Count, Is.EqualTo(0));
            test.Pass(" selected notifications are deleted");
        }
    }
}
