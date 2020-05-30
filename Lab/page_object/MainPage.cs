using Lab.business_object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab
{
    class MainPage
    {
        //главная страница (AllProducts)
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Main_page => driver.FindElement(By.XPath($"//*[text()=\"ProductId\"]"));
        

        public Login Logout()
        {
            new Actions(driver).Click(driver.FindElement(By.XPath("//*[@href=\"/Account/Logout\"]"))).Build().Perform();
            return new Login(driver);
        }

        public string GetMainPage()
        {
            return Main_page.Text;
        }

        public string AssertAddProduct(Product product)
        {
            IWebElement AssertProduct = driver.FindElement(By.XPath($"//*[text()=\"{product.ProductName}\"]"));
            return AssertProduct.Text;
        }
    }
}
