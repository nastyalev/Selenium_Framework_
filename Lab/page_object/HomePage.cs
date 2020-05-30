using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement allproducts => driver.FindElement(By.XPath("//*[@href=\"/Product\"]"));
        private IWebElement allcategories => driver.FindElement(By.XPath("//*[@href=\"/Category\"]"));
        private IWebElement Home_page => driver.FindElement(By.XPath("//*[text()=\"Home page\"]"));

        public MainPage AllProducts()
        {
            new Actions(driver).Click().Click(allproducts).Build().Perform();
            return new MainPage(driver);
        }

        public string GetHomePage()
        {
            return Home_page.Text;
        }
    }
}
