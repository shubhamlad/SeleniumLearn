using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumLearn.PageObject;
using System.Text.Json;

namespace SeleniumLearn
{

    
    public class DataDrivenTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void LoginTestNew(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);
            var isLoggedIn = loginPage.IsLoggedIn();
            Assert.IsTrue(isLoggedIn.EmployeeList && isLoggedIn.ManageUser);
        }

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
            foreach(var logindata in loginModel)
            {
                yield return logindata;
            }
        }

        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel =JsonSerializer.Deserialize<LoginModel>(jsonString);

        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
