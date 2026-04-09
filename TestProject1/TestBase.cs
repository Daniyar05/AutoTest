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

    public class TestBase
    {
        protected IWebDriver driver;
        protected IJavaScriptExecutor js;
        public IDictionary<string, object> vars { get; private set; }

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://ideaflip.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(668, 784);
        }

        protected void OpenBoardCreationPage()
        {
            driver.Navigate().GoToUrl("https://ideaflip.com/create/");
        }

        protected void OpenLoginForm()
        {
            driver.FindElement(By.CssSelector(".sign-in")).Click();
        }

        protected void Login(AccountData user)
        {
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(user.Email);
            driver.FindElement(By.Id("id_password")).Clear();
            driver.FindElement(By.Id("id_password")).SendKeys(user.Password);
            driver.FindElement(By.Id("sign-in-button")).Click();
        }
        protected void CreateBoard(BoardData board)
        {

            driver.FindElement(By.Id("id_title")).Click();
            driver.FindElement(By.Id("id_title")).Clear();
            driver.FindElement(By.Id("id_title")).SendKeys(board.Title);

            driver.FindElement(By.Id("create")).Click();
        }
      

        protected void OpenDashboard()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.Id("icon-logo")).Click();
            driver.FindElement(By.CssSelector("#dashboard > .toollink")).Click();
        }

    }
}
