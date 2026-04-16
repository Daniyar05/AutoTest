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

            BoardData board = new BoardData("I don't have an idea ...");

            applicationManager.Navigation.OpenHomePage();
            applicationManager.Navigation.OpenLoginForm();
            applicationManager.Auth.Login(user);

            applicationManager.Navigation.OpenBoardCreationPage();
            applicationManager.Board.Create(board);
            applicationManager.Navigation.OpenDashboard();

        }

    }
}

