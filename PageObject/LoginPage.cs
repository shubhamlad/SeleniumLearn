using OpenQA.Selenium;

namespace SeleniumLearn.PageObject
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement TxtUsername => driver.FindElement(By.Name("UserName"));
        IWebElement TxtPassword => driver.FindElement(By.Name("Password"));
        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));
        IWebElement LnkEmployeeList => driver.FindElement(By.LinkText("Employee List"));
        IWebElement LnkManageUser => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement LnkLogOff => driver.FindElement(By.PartialLinkText("off"));


        public void ClickLogin()
        {
            LoginLink.ClickElement();
        }
        public void Login(string username, string password)
        {
            TxtUsername.EnterText("admin");
            TxtPassword.EnterText("password");
            BtnLogin.SubmitElement();
        }

        public (bool EmployeeList,bool ManageUser) IsLoggedIn()
        {
            return (LnkEmployeeList.Displayed,LnkManageUser.Displayed);
        }
    }
}
