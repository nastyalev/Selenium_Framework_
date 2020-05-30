using Lab.business_object;
using Lab.service;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Lab
{
    public class Test
    {
        protected IWebDriver driver;
        private WebDriverWait wait;
        private string baseUrl;

        private Login login;
        private HomePage homepage;
        private MainPage mainpage;
        private ProductEditing productediting;

        private Product Fortune_cookie = new Product ("Fortune cookie", "Confections", "Specialty Biscuits, Ltd.", "3,000", "10 boxes x 15 pieces", "1", "3", "0" );
        private UserName_Password user = new UserName_Password ("user", "user");


        [SetUp]
        public void Setup()
        {
            var service = ChromeDriverService.CreateDefaultService();
            driver = new ChromeDriver();
            baseUrl = "http://localhost:5000";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void Test1_Login()
        {
            login = new Login(driver);
            homepage = login.Login_(user);

            Assert.AreEqual("Home page", homepage.GetHomePage());
        }

        [SetUp]
        public void HomePage_MainPage()
        {
            homepage = new HomePage(driver);
            mainpage = homepage.AllProducts();

            Assert.AreEqual("ProductId", mainpage.GetMainPage());
        }

        [Test]
        public void Test2_AddProduct()
        {
            productediting = ProductService.Create_Product(Fortune_cookie, driver);
            Assert.AreEqual(Fortune_cookie.ProductName, mainpage.AssertAddProduct(Fortune_cookie));
        }

        [Test]
        public void Test3_OpenAndCheck()
        {
            productediting = ProductService.GetProduct(Fortune_cookie, driver);

            Assert.True(productediting.GetProductName(Fortune_cookie));
            Assert.True(productediting.GetCategory(Fortune_cookie));
            Assert.True(productediting.GetSupplier(Fortune_cookie));
            Assert.True(productediting.GetUnitPrice(Fortune_cookie));
            Assert.True(productediting.GetQuantityPerUnit(Fortune_cookie));
            Assert.True(productediting.GetUnitsInStock(Fortune_cookie));
            Assert.True(productediting.GetUnitsOnOrder(Fortune_cookie));
            Assert.True(productediting.GetReorderLevel(Fortune_cookie));
        }

        [Test]
        public void Test4_DeleteProduct()
        {
            mainpage = ProductService.DeleteProduct(Fortune_cookie, driver);
            Thread.Sleep(2000);
            Assert.False(isElementPresent(By.XPath($"//*[text()=\"{Fortune_cookie.ProductName}\"]")));
        }

        private bool isElementPresent(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        [Test]
        public void Test5_Logout()
        {
            mainpage = new MainPage(driver);
            login = mainpage.Logout();

            Assert.True(login.AssertLogout());
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}