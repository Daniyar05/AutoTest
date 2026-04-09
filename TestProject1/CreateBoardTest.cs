using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestProject1
{
    public class CreateBoardTest : TestBase
    {
        [Test]
        public void AddBoardTest()
        {
            AccountData user = new AccountData(
                "2qyc9@deltajohnsons.com",
                "2qyc9@deltajohnsons.com"
            );

            BoardData board = new BoardData("I don't have an idea) ...");

            OpenHomePage();
            OpenLoginForm();
            Login(user);

            OpenBoardCreationPage();
            CreateBoard(board);
            OpenDashboard();

        }

    }
}

