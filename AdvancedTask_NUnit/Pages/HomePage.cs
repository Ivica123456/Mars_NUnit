using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Pages
{
    public class HomePage : CommonDriver
    {
        WebDriverWait wait;


        public HomePage()
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        }
        public void GoToLoginPage()
        {
            //Open Chrome Driver

            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();

        }


    }
}
