using System.Threading;
using OpenQA.Selenium;

namespace TestProject1
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Email))
                {
                    return;
                }

                Logout();
            }

            driver.Navigate().GoToUrl(Settings.BaseURL);
            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector(".sign-in")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(user.Email);

            driver.FindElement(By.Id("id_password")).Clear();
            driver.FindElement(By.Id("id_password")).SendKeys(user.Password);

            driver.FindElement(By.Id("sign-in-button")).Click();

            Thread.Sleep(3000);
        }

        public void Logout()
        {
            driver.Navigate().GoToUrl(Settings.BaseURL + "logout/");
            Thread.Sleep(2000);

            driver.Navigate().GoToUrl(Settings.BaseURL);
            Thread.Sleep(2000);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("icon-logo")) ||
                   IsElementPresent(By.Id("board-list")) ||
                   IsElementPresent(By.Id("id_title"));
        }

        public bool IsLoggedIn(string username)
        {
            return IsLoggedIn();
        }
    }
}