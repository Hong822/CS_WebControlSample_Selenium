using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CS_WebContorlSample_Selemium
{
    class Program
    {
        static void Main(string[] args)
        {

            FirefoxDriverService _driverSerivce = FirefoxDriverService.CreateDefaultService("C:\\WebDrivers");
            _driverSerivce.HideCommandPromptWindow = true;
            FirefoxOptions _options = new FirefoxOptions();
            //_options.AddArgument("no-sandbox");
            IWebDriver _driver = new FirefoxDriver(_driverSerivce, _options);

            string url = "https://dvkomiy:ta790909-1234@sso.volkswagen.de/kpmweb/index.do;jsessionid=ydr9irMbCOcxffBE27_cuxwg-64Lit_sYNMYCCLgz9PAWFo67z4s!761829767";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(url);

            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));

            string ID = "problem_middle";
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(ID)));
            element = _driver.FindElement(By.Id(ID));
            element.Click();

            
            ID = "erfassenForm:erfassenForm:workflowErfassungSelection:workflowErfassungSelection_input";
            //ID = "erfassenForm:erfassenForm:workflowErfassungSelection:workflowErfassungSelection_focus";
            //ID = "problemForm:panelEEFehleranspracheStammdaten:panelBodyEEFehleranspracheStammdaten:eProjektComboBox:eProjektComboBox_input";

            //element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(ID)));
            element = _driver.FindElement(By.Id(ID));

            SelectElement oSelection = new SelectElement(element);
            foreach (IWebElement Item in oSelection.Options)
            {
                System.Diagnostics.Debug.WriteLine(Item.Text);        // Print Each Value's Text (But null is printed!!!)
                System.Diagnostics.Debug.WriteLine(Item.TagName);     // Print Each Value's Tag (Correct tag name is printed.)
            }

            oSelection.SelectByValue("[21 MMI-H3 ] E/E");    // Select a value from Dropdown.

            int test = 10;
        }
    }
}
