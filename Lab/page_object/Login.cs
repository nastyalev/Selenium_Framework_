using Lab.business_object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement InputName => driver.FindElement(By.Id("Name"));
        private IWebElement InputPassword => driver.FindElement(By.Id("Password"));
        private IWebElement ButtonSend => driver.FindElement(By.XPath("//*[@type=\"submit\"]"));
        private IWebElement login => driver.FindElement(By.XPath("//*[text()=\"Login\"]"));



        public HomePage Login_(UserName_Password user)
        {
            new Actions(driver).SendKeys(InputName, user.InputName).Build().Perform();
            new Actions(driver).SendKeys(InputPassword, user.InputPassword).Build().Perform();
            new Actions(driver).Click().Click(ButtonSend).Build().Perform();

            return new HomePage(driver);
        }

        public bool AssertLogout()
        {
            return login.Displayed;
        }
    }
}
