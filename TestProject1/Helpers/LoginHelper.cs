using System;
using System.Collections.Generic;
using System.Text;
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
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(user.Email);

            driver.FindElement(By.Id("id_password")).Click();
            driver.FindElement(By.Id("id_password")).Clear();
            driver.FindElement(By.Id("id_password")).SendKeys(user.Password);

            driver.FindElement(By.Id("sign-in-button")).Click();
        }
    }
}
