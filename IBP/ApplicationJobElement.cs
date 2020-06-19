using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace IBP
{
    public class ApplicationJobElement
    {

        IWebDriver driver;

        public ApplicationJobElement(IWebDriver _driver)
        {
            driver = _driver;

        }
        public By generalPlanner = By.XPath("//div[contains(text(),'General Planner')]");
        public By applicationJobs = By.Id("__jsview6");
        public By search = By.Id("application-IBPApplicationJob-show-component---JobRunList--appJobRunListSmartFilterBar-btnBasicSearch-I");
        public By searchBtn = By.Id("application-IBPApplicationJob-show-component---JobRunList--appJobRunListSmartFilterBar-btnBasicSearch-search");
        public By plantDes = By.CssSelector("#application-IBPApplicationJob-show-component---JobRunList--jobRunTable-table tbody tr > td:nth-child(5) > div > span");
        public By searchDateFrom = By.Id("application-IBPApplicationJob-show-component---JobRunList--jobRunFromTimeInput-inner");
        public By searchDateTo = By.Id("application-IBPApplicationJob-show-component---JobRunList--jobRunToTimeInput-inner");
        //public By plantIcon = By.CssSelector("#application-IBPApplicationJob-show-component---JobRunList--jobRunTable-rows-row" + rowNumber + "-col1 div span");
    }
}

