using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TestProject1
{
    [TestFixture]
    public class CreateBoardTest : TestBase
    {
        public static IEnumerable<BoardData> BoardDataFromXmlFile()
        {
            return (List<BoardData>)new XmlSerializer(typeof(List<BoardData>))
                .Deserialize(new StreamReader(@"boards.xml"));
        }

        [Test, TestCaseSource("BoardDataFromXmlFile")]
        public void AddBoardTest(BoardData board)
        {
            AccountData user = new AccountData(
                "2qyc9@deltajohnsons.com",
                "2qyc9@deltajohnsons.com"
            );

            applicationManager.Navigation.OpenHomePage();
            applicationManager.Auth.Login(user);

            applicationManager.Navigation.OpenBoardCreationPage();
            applicationManager.Board.Create(board);

            applicationManager.Navigation.OpenDashboard();

            Assert.That(applicationManager.Board.IsBoardWithTitlePresent(board.Title), Is.True);
        }
    }
}