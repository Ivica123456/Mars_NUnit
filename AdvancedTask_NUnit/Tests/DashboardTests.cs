using AdvancedTask_NUnit.Pages;
using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Tests
{
    public class DashboardTests : CommonDriver
    {
        [Test, Order(1), Description("Verify Selection - Select All notifications ")]

        public void verifySelectedAllNotitications()
        {
            // Log the test step in the Extent Report
            test.Info("Starting verifySelectedAllNotitications ...");
           
            dashboardObj.notificationsSelectAll();

            // Get all the elements in the list
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("li"));

            // Assert that all the elements are selected
            foreach (IWebElement element in elements)
            {
                Assert.IsTrue(element.Selected);
            }
            test.Pass(" SelectedAllNotitications verified.");

        }
        [Test, Order(2), Description("Verify that no notifications are selected")]
        public void UnselectAllTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting Verify that no notifications are selected...");
           
            dashboardObj.notificationsUnselectAll();

            // Get all the elements in the list.
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("li"));

            // Assert that all the elements in the list are unselected.
            foreach (IWebElement element in elements)
            {
                Assert.IsFalse(element.Selected);

            }
            test.Pass(" No notifications are selected verified.");
        }
        [Test, Order(3), Description("Verify that the selected notifications are marked as read")]
        public void MarkSelectionAsReadTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting selected notifications are marked as read...");

            dashboardObj.markAllSelectedAsRead();

            // Get all the elements of the notifications.
            IList<IWebElement> notifications = driver.FindElements(By.CssSelector(".notification"));

            // Check if each notification is marked as read.
            foreach (IWebElement notification in notifications)
            {
                string isRead = notification.GetAttribute("read");

                // Assert that the notification is marked as read.
                Assert.That(isRead, Is.EqualTo("true"));

            }
            test.Pass("  notifications are marked as read.");
        }


        [Test, Order(4), Description("Verify that additional notifications are loaded.")]

        public void loadMoreNotificationsTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting selected notifications are loaded ...");
           
            dashboardObj.loadMoreNotifications();

            // Assert that the "Show Less" button is now visible
            IWebElement showLessButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[8]/div[1]/center/a"));
            Assert.IsTrue(showLessButton.Displayed);
            test.Pass("  notifications are loaded.");


        }

        [Test, Order(5), Description("Verify that less notifications are loaded.")]

        public void showLessNotificationsTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting selected less notifications are loaded ...");
           
            dashboardObj.showLessNotifications();

            // Assert that the "Load More" button is now visible
            IWebElement loadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button' and text()='Load More...']"));
            Assert.IsTrue(loadMoreButton.Displayed);
            test.Pass("  notifications less are loaded.");


        }


        [Test, Order(6), Description("Verify that the selected notifications are deleted")]
        public void DeleteSelectionTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting that the selected notifications are deleted ...");
                        
            dashboardObj.deleteSelection();


            // Get all the elements of the notifications.

            IList<IWebElement> notifications = driver.FindElements(By.CssSelector(".notification"));

            // Assert that there are no notifications left.
            Assert.That(notifications.Count, Is.EqualTo(0));
            test.Pass(" selected notifications are deleted");

        }
    }
}
