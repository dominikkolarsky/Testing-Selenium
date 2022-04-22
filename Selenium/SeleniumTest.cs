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
        IWebElement errorMessage;
        IWebElement errorBanner;

        [TestInitialize]
        public void OpenTheDriver() {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://certicon-testing.azurewebsites.net/");
            linkMessages = driver.FindElement(By.LinkText("Messages"));
            linkMessages.Click();
        }
        [TestMethod]
        public void EverythingOK() {
            EnterTheName();
            EnterTheEmail();
            EnterTheMessage();
            //buttonCreate
            ClickTheButton();
            succesInfoLabel = driver.FindElement(By.Id("success"));
            Assert.AreEqual("The message has been saved", succesInfoLabel.Text);
            messageNumberLabel = driver.FindElement(By.Id("messageNumber"));
            Assert.AreEqual("You have 1 messages", messageNumberLabel.Text);
        }

        private void ClickTheButton() {
            buttonCreate = driver.FindElement(By.Id("buttonCreate"));
            buttonCreate.Click();
        }

        private void EnterTheEmail() {
            tbEmail = driver.FindElement(By.Id("Email"));
            tbEmail.SendKeys("Karel@mail.com");
        }

        private void EnterTheMessage() {
            tbContent = driver.FindElement(By.Id("Content"));
            tbContent.SendKeys("Just another test fellas.");
        }

        private void EnterTheName() {
            tbName = driver.FindElement(By.Id("Name"));
            tbName.SendKeys("Karel");
        }

        [TestMethod]
        public void ForgotToEntryEmail() {
            EnterTheName();
            //EnterTheEmail();
            EnterTheMessage();
            ClickTheButton();
            errorMessage = driver.FindElement(By.ClassName("field-validation-error"));
            Assert.AreEqual("Email is Required", errorMessage.Text);
            errorBanner = driver.FindElement(By.ClassName("validation-summary-error"));
            Assert.AreEqual("Email is Required", errorBanner.Text);
        }

        [TestCleanup]
        public void CloseTheDriver() {
            //driver.Close();
        }
    }
}