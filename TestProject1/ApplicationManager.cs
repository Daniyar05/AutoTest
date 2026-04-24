using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject1
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> application = new ThreadLocal<ApplicationManager>();

        private IWebDriver driver;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private BoardHelper board;

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Window.Size = new System.Drawing.Size(668, 784);

            baseURL = "https://ideaflip.com/";

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            board = new BoardHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!application.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                application.Value = newInstance;
            }
            return application.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public NavigationHelper Navigation
        {
            get { return navigation; }
        }

        public LoginHelper Auth
        {
            get { return auth; }
        }

        public BoardHelper Board
        {
            get { return board; }
        }

        public void ResetSession()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(baseURL);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}