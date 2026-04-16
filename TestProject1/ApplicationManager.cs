using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject1
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private BoardHelper board;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "https://ideaflip.com/";

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            board = new BoardHelper(this);
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

        public void Stop()
        {
            driver.Quit();
        }

    }
}
