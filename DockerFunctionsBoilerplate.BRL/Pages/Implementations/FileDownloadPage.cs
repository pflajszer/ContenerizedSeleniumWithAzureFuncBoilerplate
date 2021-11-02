using DockerFunctionsBoilerplate.BRL.Pages.Abstractions;
using OpenQA.Selenium.Remote;

namespace DockerFunctionsBoilerplate.BRL.Pages.Implementations
{
	public class FileDownloadPage : IFileDownloadPage
	{
		private readonly RemoteWebDriver _driver;

		public FileDownloadPage(RemoteWebDriver driver)
		{
			_driver = driver;
		}

		public void DownloadFile(string fileName)
		{
			// file the file download link by it's name:
			var file = _driver.FindElementByLinkText(fileName);

			// download file:
			file.Click();
		}
	}
}
