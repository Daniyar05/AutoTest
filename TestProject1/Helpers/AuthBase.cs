using NUnit.Framework;

namespace TestProject1
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void AuthSetup()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            applicationManager.Auth.Login(user);
        }
    }
}