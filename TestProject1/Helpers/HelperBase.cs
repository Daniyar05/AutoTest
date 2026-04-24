using OpenQA.Selenium;

namespace TestProject1
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void Type(By by, string text)
        {
            IWebElement element = driver.FindElement(by);
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
    }
}