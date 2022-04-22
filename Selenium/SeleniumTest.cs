using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium {
    [TestClass]
    public class SeleniumTest {
        IWebDriver driver;
        IWebElement linkMessages;
        IWebElement tbName;
        IWebElement tbEmail;
        IWebElement tbContent;
        IWebElement buttonCreate;
        IWebElement succesInfoLabel;
        IWebElement messageNumberLabel;

        [TestInitialize]
        public void OpenTheDriver() {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://certicon-testing.azurewebsites.net/");
            linkMessages = driver.FindElement(By.LinkText("Messages"));
            linkMessages.Click();
        }
        [TestMethod]
        public void EverythingOK() {
            tbName = driver.FindElement(By.Id("Name"));
            tbName.SendKeys("Karel");
            tbEmail = driver.FindElement(By.Id("Email"));
            tbEmail.SendKeys("Karel@mail.com");
            tbContent = driver.FindElement(By.Id("Content"));
            tbContent.SendKeys("Just another test fellas.");
            //buttonCreate
            buttonCreate = driver.FindElement(By.Id("buttonCreate"));
            buttonCreate.Click();
            succesInfoLabel = driver.FindElement(By.Id("success"));
            Assert.AreEqual("The message has been saved", succesInfoLabel.Text);
            messageNumberLabel = driver.FindElement(By.Id("messageNumber"));
            Assert.AreEqual("You have 1 messages", messageNumberLabel.Text);
        }

        [TestCleanup]
        public void CloseTheDriver() {
            driver.Close();
        }
    }
}