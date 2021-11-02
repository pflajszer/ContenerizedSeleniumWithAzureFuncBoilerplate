using DockerFunctionsBoilerplate.BRL.Browsers.Abstractions;
using DockerFunctionsBoilerplate.BRL.OnPageActions.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate.BRL.Browsers.Implementations
{
	public class Chrome : IBrowser
	{
		private readonly IConfiguration _config;
		private readonly INavigator _nav;
		private readonly IFileDownloaderOnPageAction _fileDownloaderOPA;
		public Chrome(IConfiguration config, INavigator nav, IFileDownloaderOnPageAction fileDownloaderOPA)
		{
			_config = config;
			_nav = nav;
			_fileDownloaderOPA = fileDownloaderOPA;
		}

		public async Task GetMavenProjectTextFile()
		{
			// Navigate to the login page > INavigator task
			var loginPageUrl = _config["loginPageUrl"];
			await _nav.GoToAsync(loginPageUrl);

			// Log in > IFileDownloaderOnPageAction task
			_fileDownloaderOPA.SignIn();

			// Navigate to the file download page > INavigator task
			var fileDownloadPageUrl = _config["fileDownloadPageUrl"];
			await _nav.GoToAsync(fileDownloadPageUrl);

			// Download file > IFileDownloaderOnPageAction task
			var fileName = "maven-project.txt";
			_fileDownloaderOPA.DownloadTheFile(fileName);
		}
	}
}
