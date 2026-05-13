using NUnit.Framework;
using System;

namespace TestProject1
{
    [TestFixture]
    public class DeleteBoardTest : AuthBase
    {
        [Test]
        public void DeleteBoard()
        {
            BoardData board = new BoardData("Board for delete " + DateTime.Now.Ticks);

            applicationManager.Navigation.OpenBoardCreationPage();
            applicationManager.Board.Create(board);
            applicationManager.Navigation.OpenDashboard();

            Assert.That(applicationManager.Board.IsBoardWithTitlePresent(board.Title), Is.True);

            applicationManager.Board.OpenBoardByTitle(board.Title);
            applicationManager.Board.DeleteOpenedBoard();
            applicationManager.Navigation.OpenDashboard();

            Assert.That(applicationManager.Board.IsBoardWithTitlePresent(board.Title), Is.True);
        }
    }
}