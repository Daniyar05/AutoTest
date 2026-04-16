using System;
using System.Collections.Generic;
using System.Text;
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
            driver.FindElement(By.Id("id_title")).Click();
            driver.FindElement(By.Id("id_title")).Clear();
            driver.FindElement(By.Id("id_title")).SendKeys(board.Title);

            driver.FindElement(By.Id("create")).Click();
        }
    }
}
