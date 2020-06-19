using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using Coypu;
using Coypu.Drivers;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace IBP
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class IBPZ1Y
    {
        IWebDriver driver;
        ApplicationJobHelper _applicationJobHelper;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:/IBP/packages/Selenium.Chrome.WebDriver.79.0.0/driver");
            _applicationJobHelper = new ApplicationJobHelper(driver);
        }



        [Test]
        public void DownloadZ1YFile()
        {
            string json = File.ReadAllText("C://IBP//IBP//Credential.json");
            Env env = JsonConvert.DeserializeObject<Env>(json);
            var z1y = env.Z1Y;
            var wnaFileName = string.Empty;
            var hanaFileName = "HANA Trace File";
            int rowNumber = 0;

            driver.Manage().Window.Maximize();

            _applicationJobHelper.GoToUrl(z1y.url);
            _applicationJobHelper.z1yLogin(z1y.id, z1y.Password);
            _applicationJobHelper.ClickGeneralPlanner();
            _applicationJobHelper.ClickApplicationJob();


            foreach (var plant in z1y.plant_name)
            {
                wnaFileName = "WNA_OPT_" + plant.ToUpper().Trim() + ":Scheduled_with_cURL";

                _applicationJobHelper.ClearDate();
                _applicationJobHelper.EnterZ1yDates(env);
                _applicationJobHelper.SearchPlant(plant);

                rowNumber = _applicationJobHelper.GetPlantNames().FindIndex(k => k.Text.Equals(wnaFileName));

                driver.FindElement(By.CssSelector("#application-IBPApplicationJob-show-component---JobRunList--jobRunTable-rows-row" + rowNumber + "-col1 div span")).Click();

                Thread.Sleep(15000);

                _applicationJobHelper.ClickPlant(hanaFileName);
                driver.Navigate().Back();
                Thread.Sleep(10000);
            }
        }
    }

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class IBPZSB
    {
        IWebDriver driver;
        ApplicationJobHelper _applicationJobHelper;

        [SetUp]
        public void startBrowser()
        {

            driver = new ChromeDriver("C:/IBP/packages/Selenium.Chrome.WebDriver.79.0.0/driver");
            _applicationJobHelper = new ApplicationJobHelper(driver);
        }

        [Test]

        public void DownloadZSBFile()
        {
            string json = File.ReadAllText("C://IBP//IBP//Credential.json");
            Env env = JsonConvert.DeserializeObject<Env>(json);
            var zsb = env.ZSB;
            var wnaFileName = string.Empty;
            var hanaFileName = "HANA Trace File";
            int rowNumber = 0;

            driver.Manage().Window.Maximize();

            _applicationJobHelper.GoToUrl(zsb.url);
            _applicationJobHelper.zsbLogin(zsb.id, zsb.Password);
            _applicationJobHelper.ClickGeneralPlanner();
            _applicationJobHelper.ClickApplicationJob();

            foreach (var plant in env.ZSB.plant_name)
            {
                wnaFileName = "WNA_OPT_" + plant.ToUpper().Trim() + ":Scheduled_with_cURL";

                _applicationJobHelper.ClearDate();
                _applicationJobHelper.EnterZsbDates(env);
                _applicationJobHelper.SearchPlant(plant);

                rowNumber = _applicationJobHelper.GetPlantNames().FindIndex(k => k.Text.Equals(wnaFileName));

                driver.FindElement(By.CssSelector("#application-IBPApplicationJob-show-component---JobRunList--jobRunTable-rows-row" + rowNumber + "-col1 div span")).Click();

                Thread.Sleep(15000);

                _applicationJobHelper.ClickPlant(hanaFileName);
                driver.Navigate().Back();
                Thread.Sleep(10000);
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Console.WriteLine("test: "+status);
            var fromAddress = new MailAddress("kaushl.singh07@gmail.com", "Kaushal");
            var toAddress = new MailAddress("crazyneeraj42@gmail.com", "To Name");
            const string fromPassword = "9300830154";
            const string subject = "Subject";
            string body = "Test status: " + status;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            //Thread.Sleep(300000);
            //driver.Close();
        }
    }

}
