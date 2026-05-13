using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            applicationManager.Auth.Logout();

            AccountData user = new AccountData(Settings.Login, Settings.Password);
            applicationManager.Auth.Login(user);

            Assert.That(applicationManager.Auth.IsLoggedIn(), Is.True);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            applicationManager.Auth.Logout();

            AccountData user = new AccountData("wrong_login", "wrong_password");
            applicationManager.Auth.Login(user);

            Assert.That(applicationManager.Auth.IsLoggedIn(), Is.False);
        }
    }
}