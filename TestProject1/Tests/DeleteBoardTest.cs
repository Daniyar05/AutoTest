using System;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class DeleteBoardTest : TestBase
    {
        [Test]
        public void DeleteBoard()
        {
            AccountData user = new AccountData(
                "2qyc9@deltajohnsons.com",
                "2qyc9@deltajohnsons.com"
            );

            BoardData board = new BoardData("BoardToDelete");

            applicationManager.Auth.Login(user);
            applicationManager.Navigation.OpenBoardCreationPage();
            applicationManager.Board.Create(board);
            applicationManager.Navigation.OpenDashboard();

            Assert.That(applicationManager.Board.IsBoardWithTitlePresent(board.Title), Is.True);

            applicationManager.Board.OpenFirstBoard();
            applicationManager.Board.DeleteOpenedBoard();
            applicationManager.Navigation.OpenDashboard();
        }
    }
}