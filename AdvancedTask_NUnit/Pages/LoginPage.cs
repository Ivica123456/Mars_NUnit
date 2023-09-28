using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask_NUnit.Pages
{
    public class LoginPage : CommonDriver
    {
        WebDriverWait wait;
       
        public LoginPage() 
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));


        }
        public void goToProfilePage()
        {


            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();

            IWebElement emailAddressTextBox = driver.FindElement(By.Name("email"));
            emailAddressTextBox.SendKeys("ivica.cuncic@gmail.com");
            IWebElement passwordTexbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTexbox.SendKeys("mars123");
            IWebElement loginButton = driver.FindElement(By.CssSelector("body > div.ui.page.modals.dimmer.transition.visible.active > div > div > div:nth-child(1) > div > div:nth-child(5) > button"));
            loginButton.Click();



        }

    }
}

