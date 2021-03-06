﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverExtended.Page
{
    public class Page : IPageObject
    {
        public IWebDriver Driver { get; protected set; }
        public string DisplayName { get; protected set; }
        public string BaseUrl { get; set; }
        public string Path { get; set; }
        private WebDriverWait PageWait;
        public bool Mobile { get; protected set; }

        /// <summary>
        /// Creates a pageobject
        /// </summary>
        /// <param name="driver">the webdriver instance to attach to this page</param>
        /// <param name="displayName">The human readable name to display for reporting</param>
        public Page(IWebDriver driver, string displayName)
        {
            Driver = driver;
            PageWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            DisplayName = displayName;
            Mobile = false;
        }

        public string getPageUrl()
        {
            if (Path != null)
            {
                return BaseUrl + Path;
            }
            return BaseUrl;
        }

        /// <summary>
        /// Navigate to the the pages absolute url. Both the base URL and the relative url must be stored within the page object
        /// </summary>
        /// <param name="url"></param>
        public virtual void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public virtual void Navigate(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public virtual void Navigate()
        {
            Driver.Navigate().GoToUrl(getPageUrl());
        }

    }
}
