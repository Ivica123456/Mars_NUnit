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
            

           
            //test.Pass(" SelectedAllNotitications verified.");
            dashboardObj.notificationsSelectAll();
            //Check all notifications are selected
            var success = dashboardObj.IsnotificationsSelectAll();
            Assert.IsTrue(success);
            test.Pass(" SelectedAllNotitications verified.");

        }
        [Test, Order(2), Description("Verify that no notifications are selected")]
        public void UnselectAllTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting Verify that no notifications are selected...");
            

            dashboardObj.notificationsUnselectAll();
            var success = dashboardObj.IsnotificationsUnselectAll();
            Assert.IsTrue(success);

            test.Pass(" No notifications are selected verified.");
        }
        [Test, Order(3), Description("Verify that the selected notifications are marked as read")]
        public void MarkSelectionAsReadTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting selected notifications are marked as read...");

            dashboardObj.markAllSelectedAsRead();
            var success = dashboardObj.IsmarkAllSelectedAsRead();
            Assert.IsTrue(success);
            test.Pass("  notifications are marked as read.");
        }


        [Test, Order(4), Description("Verify that additional notifications are loaded.")]

        public void loadMoreNotificationsTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting selected notifications are loaded ...");

            dashboardObj.loadMoreNotifications();
            var success = dashboardObj.IsloadMoreNotifications();
            Assert.IsTrue(success);
            test.Pass("  notifications are load more.");

        }

        [Test, Order(5), Description("Verify that less notifications are loaded.")]

        public void showLessNotificationsTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting selected less notifications are loaded ...");

            dashboardObj.showLessNotifications();
            var success = dashboardObj.IsshowLessNotifications();
            Assert.IsTrue(success);
            test.Pass("  notifications are show less.");

        }


        [Test, Order(6), Description("Verify that the selected notifications are deleted")]
        public void DeleteSelectionTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting that the selected notifications are deleted ...");

            dashboardObj.deleteSelection();
            var success = dashboardObj.IsdeleteSelection();
            Assert.IsTrue(success);
            test.Pass("  notifications are deleted");


        }
    }
}
