using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace TestProject1
{
    public class BoardHelper : HelperBase
    {
        public BoardHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Create(BoardData board)
        {
            Thread.Sleep(1000);

            IWebElement title = driver.FindElement(By.Id("id_title"));
            title.Clear();
            title.SendKeys(board.Title);

            driver.FindElement(By.Id("create")).Click();
        }

        public bool IsCreateFormOpened()
        {
            return IsElementPresent(By.Id("id_title")) && IsElementPresent(By.Id("create"));
        }

        public bool IsDashboardOpened()
        {
            return IsElementPresent(By.Id("board-list")) || IsElementPresent(By.Id("list"));
        }

        public bool IsBoardOpened()
        {
            return IsElementPresent(By.CssSelector(".ff.ff-menu")) ||
                   IsElementPresent(By.CssSelector(".ellipsis")) ||
                   IsElementPresent(By.CssSelector(".logo span"));
        }

        public IList<IWebElement> GetBoards()
        {
            return driver.FindElements(By.CssSelector("#list .whiteboard, .whiteboard-list .whiteboard"));
        }

        public int GetBoardCount()
        {
            return GetBoards().Count;
        }

        public bool IsBoardPresent()
        {
            return GetBoardCount() > 0;
        }

        public void OpenFirstBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                if (GetBoards().Count > 0)
                    break;

                Thread.Sleep(1000);
            }

            GetBoards().First().Click();
        }

        public string GetFirstBoardTitle()
        {
            Thread.Sleep(2000);

            return driver.FindElement(By.CssSelector("#list .title")).Text.Trim();
        }

        public bool IsBoardWithTitlePresent(string title)
        {
            return !driver.FindElements(By.CssSelector("#list .title"))
                .Any(x => x.Text.Trim() == title);
        }

        public void OpenOpenedBoardMenu()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".ff-menu")).Click();
        }

        public void DeleteOpenedBoard()
        {
            OpenOpenedBoardMenu();

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("li:nth-child(1) > .toollink")).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".ellipsis")).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".admin:nth-child(7)")).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.Name("action")).Click();
        }
    }
}