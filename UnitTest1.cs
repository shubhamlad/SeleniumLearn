using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumLearn.PageObject;

namespace SeleniumLearn
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OpenNavigateSendkeyClsose()
        {
            IWebDriver driver=new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in/");
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.Name("q"));
            webElement.SendKeys("Hare Krishna");  
            webElement.SendKeys(Keys.Enter);
            driver.Close();
        }

        [Test]
        public void AllLocator()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
/*            SeleniumMethods.Click(driver, By.Id("loginLink"));
            SeleniumMethods.EnterText(driver, By.Name("UserName"), "admin");
            SeleniumMethods.EnterText(driver, By.Name("Password"), "password");
            SeleniumMethods.Submit(driver, By.CssSelector(".btn"));
*/        }

        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLogin();
            loginPage.Login("admin", "password");

        }

        [Test]
        public void SignUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/r.php/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("firstname")).SendKeys("first");
            driver.FindElement(By.Name("lastname")).SendKeys("lastname");

            driver.FindElement(By.Name("reg_email__")).SendKeys("9999999999");
            SelectElement selectBirthDay = new SelectElement(driver.FindElement(By.Name("birthday_day")));
            selectBirthDay.SelectByText("7");
            SelectElement selectBirthMonth = new SelectElement(driver.FindElement(By.Name("birthday_month")));
            selectBirthMonth.SelectByIndex(3);
            SelectElement selectYear = new SelectElement(driver.FindElement(By.Name("birthday_year")));
            selectYear.SelectByValue("2000");

            driver.FindElement(By.XPath("//input[@name='sex'][@value='2']")).Click();
            
        }
        
    }

}