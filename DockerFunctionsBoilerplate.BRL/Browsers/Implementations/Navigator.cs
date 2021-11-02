using DockerFunctionsBoilerplate.BRL.Browsers.Abstractions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Remote;
using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate.BRL.Browsers.Implementations
{
	public class Navigator : INavigator
	{
		private readonly RemoteWebDriver _driver;
		private readonly IConfiguration _config;

		public Navigator(RemoteWebDriver driver,
						 IConfiguration config)
		{
			_driver = driver;
			_config = config;
		}


		public async Task GoToAsync(string url)
		{
			_driver.Navigate().GoToUrl(url);
			await HandleAudit();
		}

		public async Task GoBackAsync()
		{
			_driver.Navigate().Back();
			await HandleAudit();
		}

		public async Task GoForwardAsync()
		{
			_driver.Navigate().Forward();
			await HandleAudit();
		}

		public async Task RefreshAsync()
		{
			_driver.Navigate().Forward();
			await HandleAudit();
		}

		private async Task HandleAudit()
		{
			if (bool.TryParse(_config["isAuditActive"], out var isAuditActive))
			{
				// take a screenshot > IAuditService ?
				// log message async > IAuditService ?
			}
		}
	}
}
