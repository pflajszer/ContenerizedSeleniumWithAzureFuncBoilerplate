using DockerFunctionsBoilerplate.BRL.Pages.Abstractions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DockerFunctionsBoilerplate.BRL.Pages.Implementations
{
	public class LoginPage : ILoginPage
	{
		public By LoginTextBoxXPath { get; } = By.XPath("/html/body/div[2]/div/div/form/div[1]/div/input");
		public By PasswordTextBoxXPath { get; } = By.XPath("/html/body/div[2]/div/div/form/div[2]/div/input");
		public By LoginButtonXPath { get; } = By.XPath("/html/body/div[2]/div/div/form/button");


		private readonly RemoteWebDriver _driver;
		private readonly IConfiguration _config;
		public LoginPage(RemoteWebDriver driver, IConfiguration config)
		{
			_driver = driver;
			_config = config;
		}

		public void LogIn()
		{
			// find login box and input login:
			var loginBox = _driver.FindElement(LoginTextBoxXPath);
			loginBox.SendKeys(_config["login"]);

			// find password box and input password:
			var passwordBox = _driver.FindElement(PasswordTextBoxXPath);
			passwordBox.SendKeys(_config["password"]);

			// find auth form submission button and click it:
			var btn = _driver.FindElement(LoginButtonXPath);
			btn.Click();
		}
	}
}
