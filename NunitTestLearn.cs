using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumLearn.PageObject;

namespace SeleniumLearn
{
    [TestFixture("admin", "password")]
    public class NunitTestLearn
    {
        private IWebDriver _driver;
        private readonly String _username;
        private readonly String _password;
        public NunitTestLearn(string username, string password)
        {
            _username = username;
            _password = password;

        }
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginTestNew()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(_username, _password);

        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
