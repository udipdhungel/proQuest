using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Threading;

namespace GitHub_Assignment
{
    
    public class Assignment
    {
        IWebDriver driver;

        [Test]
        public void Proquest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement searchBox = driver.FindElement(By.XPath("//input[@name='q']"));
            searchBox.SendKeys("Proquest");
            searchBox.SendKeys(Keys.Enter);
            IReadOnlyList <IWebElement> titles = driver.FindElements(By.XPath("//a/h3"));


            StreamWriter sw = new StreamWriter("file.txt");

            foreach (IWebElement result in titles)

            {
                if (String.IsNullOrEmpty(result.Text))
                {
                    Console.WriteLine("Title: " + result.Text);
                    sw.WriteLine("Title: " + result.Text);
                }
            }

            sw.Close();

            

        }

        [Test]

        public void TestTakeScreenshot()
        {
            Proquest();
            IWebElement proQuest = driver.FindElement(By.XPath("//h3[contains(text(),'EBooks and Technology')]"));
            proQuest.Click();
            Thread.Sleep(5000);
            IWebElement searchBtn = driver.FindElement(By.XPath("//i[@class=' fa  fa-2  fa-search ']"));
            searchBtn.Click();
            IWebElement search = driver.FindElement(By.XPath("//li//input[@name='searchKeyword']"));
            search.SendKeys("QA");
            search.SendKeys(Keys.Return);
            ITakesScreenshot screenshot = ((ITakesScreenshot)driver);
            Screenshot ss = screenshot.GetScreenshot();
            ss.SaveAsFile("C:\\Users\\iot\\source\\repos\\GitHub%Assignment", ScreenshotImageFormat.Jpeg);
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
