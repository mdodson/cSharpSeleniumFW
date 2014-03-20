using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;



namespace Selenium
{
    [TestClass]
    public class UnitTest1
    {
        //DesiredCapabilities cap = new BumblebeeIOS.IOSCapabilities();
        //DesiredCapabilities cap = new DesiredCapabilities();

        

        public IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement queary = driver.FindElement(By.Name("q"));

            queary.SendKeys("cheese");

            queary.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });

            System.Console.WriteLine("Page Title is: " + driver.Title);

            driver.Quit();

        }

        [TestMethod]
        public void TestMethod2()
        {
            //cap.SetCapability("version", "7.0");
            //cap.SetCapability("device", "iphone");
            //cap.SetCapability("language", "en");
            //cap.SetCapability("locale", "en_GB");
            //cap.SetCapability("bundle_name", "ToDoList");
            //cap.SetCapability("simulator", true);
            //cap.SetCapability("time_hack", false);
            //cap.IsJavaScriptEnabled = true;

            DesiredCapabilities cap = BumblebeeIOS.IOSCapabilities.Iphone("ToDoList");

            driver = new RemoteWebDriver(new Uri("http://192.168.157.129:4444/wd/hub"), cap);

            try
            {
                //open web site
                driver.Url = "http://seleniumhq.org/";

                //sleep for a bit
                System.Threading.Thread.Sleep(5000);

                //find documentation link
                IWebElement link = driver.FindElement(By.PartialLinkText("Documentation"));

                //sleep for a bit
                System.Threading.Thread.Sleep(5000);

                //click the link
                link.Click();

                //sleep for a bit
                System.Threading.Thread.Sleep(5000);
            }
            finally
            {
                //sleep for a bit
                System.Threading.Thread.Sleep(5000);
                driver.Quit();
            }
        }
    }
}
