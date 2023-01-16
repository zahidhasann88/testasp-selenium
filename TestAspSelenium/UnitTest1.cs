using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAspSelenium

{
    public class UnitTest1
    {
        [Theory]
        [InlineData("5")]
        [InlineData("7")]
        [InlineData("9")]
        public void TestShowDetailsRightTitle(string rowNum)
        {
            string URL = "https://localhost:44374/Bookandcosts";
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);

            IWebElement bookTitle = driver.FindElement(By.Id(string.Format("", rowNum)));
            string title = bookTitle.Text;

            IWebElement detailLink = driver.FindElement(By.Name(string.Format("", rowNum)));
            detailLink.Click();

            WebDriverWait wait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.XPath("")));

            IWebElement detailTitle = driver.FindElement(By.XPath(""));
            Assert.Equal(title, detailTitle.Text);

            driver.Close();
        }
    }
}