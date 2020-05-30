using Lab.business_object;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.service
{
    class ProductService
    {
        public static ProductEditing Create_Product (Product product, IWebDriver driver)
        {
            MainPage mainpage = new MainPage(driver);
            ProductEditing productediting = new ProductEditing(driver);
            new Actions(driver).Click(driver.FindElement(By.XPath("//*[@href=\"/Product/Create\"]"))).Build().Perform();
            mainpage = productediting.CreateProduct(product);

            return new ProductEditing(driver);
        }

        public static ProductEditing GetProduct(Product product, IWebDriver driver)
        {
            MainPage mainpage = new MainPage(driver);
            new Actions(driver).Click(driver.FindElement(By.XPath($"//*[text()=\"{product.ProductName}\"]/../..//../*[text()=\"Edit\"]"))).Build().Perform();
            return new ProductEditing(driver);
        }

        public static MainPage DeleteProduct(Product product, IWebDriver driver)
        {
            MainPage mainpage = new MainPage(driver);
            new Actions(driver).Click(driver.FindElement(By.XPath($"//*[text()=\"{product.ProductName}\"]//..//..//a[text()=\"Remove\"]"))).Build().Perform();
            driver.SwitchTo().Alert().Accept();
            return new MainPage (driver);
        }
    }
}
