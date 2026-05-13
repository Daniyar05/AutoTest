using NUnit.Framework;

namespace TestProject1
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        public void SetupTest()
        {
            applicationManager = ApplicationManager.GetInstance();
            applicationManager.Navigation.OpenHomePage();
        }
    }
}