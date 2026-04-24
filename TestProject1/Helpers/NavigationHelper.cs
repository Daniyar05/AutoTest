using OpenQA.Selenium;

namespace TestProject1
{
    public class NavigationHelper : HelperBase
    {
        private readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenLoginForm()
        {
            OpenHomePage();

            if (IsElementPresent(By.CssSelector(".sign-in")))
            {
                driver.FindElement(By.CssSelector(".sign-in")).Click();
            }
        }

        public void OpenBoardCreationPage()
        {
            driver.Navigate().GoToUrl(baseURL + "create/");
        }

        public void OpenDashboard()
        {
            driver.Navigate().GoToUrl(baseURL + "home/");
        }
    }
}