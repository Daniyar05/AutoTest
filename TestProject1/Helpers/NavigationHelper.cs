using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace TestProject1
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Size = new System.Drawing.Size(668, 784);
        }

        public void OpenLoginForm()
        {
            driver.FindElement(By.CssSelector(".sign-in")).Click();
        }

        public void OpenBoardCreationPage()
        {
            driver.Navigate().GoToUrl(baseURL + "create/");
        }

        public void OpenDashboard()
        {
            driver.FindElement(By.Id("icon-logo")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#dashboard > .toollink")).Click();
        }
    }
}
