using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        [Test]
        public void Login()
        {
            AccountData user = new AccountData(
                "2qyc9@deltajohnsons.com",
                "2qyc9@deltajohnsons.com"
            );

            applicationManager.Auth.Login(user);
            applicationManager.Navigation.OpenDashboard();

            Assert.That(applicationManager.Board.IsDashboardOpened(), Is.False);
        }
    }
}