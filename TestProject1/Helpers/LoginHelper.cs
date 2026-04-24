using OpenQA.Selenium;

namespace TestProject1
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            manager.Navigation.OpenLoginForm();
            Type(By.Id("email"), user.Email);
            Type(By.Id("id_password"), user.Password);
            driver.FindElement(By.Id("sign-in-button")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector(".ff.ff-menu")) ||
                   IsElementPresent(By.Id("board-list")) ||
                   IsElementPresent(By.Id("list"));
        }
    }
}