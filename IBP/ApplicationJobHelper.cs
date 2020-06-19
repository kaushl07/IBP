using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace IBP
{
    public class ApplicationJobHelper
    {

        IWebDriver driver;
        ApplicationJobElement obj;

        public ApplicationJobHelper(IWebDriver _driver)
        {
            driver = _driver;
            obj = new ApplicationJobElement(driver);
        }

        public void GoToUrl(string url)
        {
            driver.Url = url;
            Thread.Sleep(5000);
        }

        public void zsbLogin(string id, string pwd)
        {
            driver.FindElement(By.CssSelector("[id$='username']")).SendKeys(id);
            driver.FindElement(By.CssSelector("[id$='password']")).SendKeys(pwd);
            driver.FindElement(By.Id("logOnFormSubmit")).Click();
            Thread.Sleep(30000);
        }

        public void z1yLogin(string id, string z1ypwd)
        {
            driver.FindElement(By.CssSelector("[id$='username']")).SendKeys(id);
            driver.FindElement(By.CssSelector("[id$='password']")).SendKeys(z1ypwd);
            driver.FindElement(By.Id("logOnFormSubmit")).Click();
            Thread.Sleep(30000);
        }

        public void ClickGeneralPlanner()
        {
            driver.FindElement(obj.generalPlanner).Click();
        }

        public void ClickApplicationJob()
        {
            driver.FindElement(obj.applicationJobs).Click();
            Thread.Sleep(25000);
        }

        public void ClearDate()
        {
            driver.FindElement(obj.searchDateFrom).Clear();
            driver.FindElement(obj.searchDateTo).Clear();
        }

        public void EnterZsbDates(Env env)
        {
            if (env.ZSB.date_from.ToLower().Equals("today"))
            {
                DateTime date = DateTime.Today;
                string dateFrom = string.Format("{0:MM/dd/yyyy HH:mm:ss}", date);
                string dateTo = string.Format("{0:MM/dd/yyyy}", date) + ", 23:59:59";
                driver.FindElement(obj.searchDateFrom).SendKeys(dateFrom);
                driver.FindElement(obj.searchDateTo).SendKeys(dateTo);
            }
            else
            {
                driver.FindElement(obj.searchDateFrom).SendKeys(env.ZSB.date_from);
                driver.FindElement(obj.searchDateTo).SendKeys(env.ZSB.date_to);
            }
        }

        public void EnterZ1yDates(Env env)
        {
            if (env.Z1Y.date_from.ToLower().Equals("today"))
            {
                DateTime date = DateTime.Today;
                string dateFrom = string.Format("{0:MM/dd/yyyy HH:mm:ss}", date);
                string dateTo = string.Format("{0:MM/dd/yyyy}", date) + ", 23:59:59";
                driver.FindElement(obj.searchDateFrom).SendKeys(dateFrom);
                driver.FindElement(obj.searchDateTo).SendKeys(dateTo);
            }
            else
            {
                driver.FindElement(obj.searchDateFrom).SendKeys(env.Z1Y.date_from);
                driver.FindElement(obj.searchDateTo).SendKeys(env.Z1Y.date_to);
            }
        }
        public void SearchPlant(string plant)
        {
            driver.FindElement(obj.search).SendKeys(plant);
            driver.FindElement(obj.searchBtn).Click();
            Thread.Sleep(10000);
        }

        public List<IWebElement> GetPlantNames()
        {
            return driver.FindElements(obj.plantDes).ToList();
        }

        public void ClickPlant(string hanaFileName)
        {
            driver.FindElements(By.CssSelector("table a")).First(k => k.Text.Equals(hanaFileName)).Click();
        }
    }
}

