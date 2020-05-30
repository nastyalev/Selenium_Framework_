using Lab.business_object;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{

    class ProductEditing
    {
        private IWebDriver driver;

        public ProductEditing(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductName_ => driver.FindElement(By.Id("ProductName"));
        private IWebElement UnitPrice_ => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement QuantityPerUnit_ => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement UnitsInStock_ => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement UnitsOnOrder_ => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement ReorderLevel_ => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement ButtonSend_ => driver.FindElement(By.XPath("//*[@type=\"submit\"]"));

        public MainPage CreateProduct(Product product)
        {
            new Actions(driver).SendKeys(ProductName_, product.ProductName).Build().Perform();

            driver.FindElement(By.XPath($"//*[@id=\"CategoryId\"]/*[@value][text()=\"{product.Category}\"]")).Click();
            driver.FindElement(By.XPath($"//*[@id=\"SupplierId\"]/*[@value][text()=\"{product.Supplier}\"]")).Click();

            new Actions(driver).Click(UnitPrice_).SendKeys(product.UnitPrice).Build().Perform();
            new Actions(driver).Click(QuantityPerUnit_).SendKeys(product.QuantityPerUnit).Build().Perform();
            new Actions(driver).Click(UnitsInStock_).SendKeys(product.UnitsInStock).Build().Perform();
            new Actions(driver).Click(UnitsOnOrder_).SendKeys(product.UnitsOnOrder).Build().Perform();
            new Actions(driver).Click(ReorderLevel_).SendKeys(product.ReorderLevel).Build().Perform();

            new Actions(driver).Click(ButtonSend_).Build().Perform();
            return new MainPage(driver);
        }

        public bool GetProductName(Product product)
        {
            IWebElement NewProductName = driver.FindElement(By.XPath($"//input[@id=\"ProductName\"][@value=\"{product.ProductName}\"]"));
            return NewProductName.Displayed;
        }

        public bool GetCategory(Product product)
        {
            IWebElement NewCategory = driver.FindElement(By.XPath($"//*[@id=\"CategoryId\"]/*[@selected][text()=\"{product.Category}\"]"));
            return NewCategory.Displayed;
        }
        public bool GetSupplier(Product product)
        {
            IWebElement NewSupplier = driver.FindElement(By.XPath($"//*[@id=\"SupplierId\"]/*[@selected][text()=\"{product.Supplier}\"]"));
            return NewSupplier.Displayed;
        }

        public bool GetUnitPrice(Product product)
        {
            IWebElement NewUnitPrice = driver.FindElement(By.XPath($"//*[@id=\"UnitPrice\" and contains(@value,\"{ product.UnitPrice}\")]"));
            return NewUnitPrice.Displayed;
        }

        public bool GetQuantityPerUnit(Product product)
        {
            IWebElement NewQuantityPerUnit = driver.FindElement(By.XPath($"//input[@id=\"QuantityPerUnit\"][@value=\"{product.QuantityPerUnit}\"]"));
            return NewQuantityPerUnit.Displayed;
        }

        public bool GetUnitsInStock(Product product)
        {
            IWebElement NewUnitsInStock = driver.FindElement(By.XPath($"//input[@id=\"UnitsInStock\"][@value=\"{product.UnitsInStock}\"]"));
            return NewUnitsInStock.Displayed;
        }

        public bool GetUnitsOnOrder(Product product)
        {
            IWebElement NewUnitsOnOrder = driver.FindElement(By.XPath($"//input[@id=\"UnitsOnOrder\"][@value=\"{product.UnitsOnOrder}\"]"));
            return NewUnitsOnOrder.Displayed;
        }

        public bool GetReorderLevel(Product product)
        {
            IWebElement NewReorderLevel = driver.FindElement(By.XPath($"//input[@id=\"ReorderLevel\"][@value=\"{product.ReorderLevel}\"]"));
            return NewReorderLevel.Displayed;
        }
    }
}
