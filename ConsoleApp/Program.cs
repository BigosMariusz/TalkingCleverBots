using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string driverPath = Environment.CurrentDirectory;
            IWebDriver driver1 = new ChromeDriver(driverPath);
            driver1.Navigate().GoToUrl("https://www.eviebot.com/en/");

            IWebDriver driver2 = new ChromeDriver(driverPath);
            driver2.Navigate().GoToUrl("https://www.eviebot.com/en/");
            string response1 = "";
            string response2 = "";

            //initialize talk
            driver1.FindElement(By.Name("stimulus")).SendKeys("I like trains");
            driver1.FindElement(By.Name("sayitbutton")).Click();

            while (true)
            {
                while (true) //checking if the bot finished talking
                {
                    Thread.Sleep(100);
                    try
                    {
                        driver1.FindElement(By.Id("line1")).FindElement(By.ClassName("bot")).FindElement(By.TagName("img"));
                    }
                    catch (NoSuchElementException) { continue; }
                    break;
                }

                try //reply
                {
                    response1 = driver1.FindElement(By.Id("line1")).FindElement(By.ClassName("bot")).Text;
                    driver2.FindElement(By.Name("stimulus")).SendKeys(response1);
                    driver2.FindElement(By.Name("sayitbutton")).Click();
                }
                catch (Exception) { }

                while (true) //checking if the bot finished talking
                {
                    Thread.Sleep(100);
                    try
                    {
                        driver2.FindElement(By.Id("line1")).FindElement(By.ClassName("bot")).FindElement(By.TagName("img"));
                    }
                    catch (NoSuchElementException) { continue; }
                    break;
                }

                try //reply
                {
                    response2 = driver2.FindElement(By.Id("line1")).FindElement(By.ClassName("bot")).Text;
                    driver1.FindElement(By.Name("stimulus")).SendKeys(response2);
                    driver1.FindElement(By.Name("sayitbutton")).Click();
                }
                catch (Exception) { }
            }
        }
    }
}


