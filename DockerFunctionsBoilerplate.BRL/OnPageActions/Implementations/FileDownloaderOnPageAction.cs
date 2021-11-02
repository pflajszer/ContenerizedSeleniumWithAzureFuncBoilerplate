using DockerFunctionsBoilerplate.BRL.OnPageActions.Abstractions;
using DockerFunctionsBoilerplate.BRL.Pages.Abstractions;

namespace DockerFunctionsBoilerplate.BRL.OnPageActions.Implementations
{
	public class FileDownloaderOnPageAction : IFileDownloaderOnPageAction
	{
		private readonly ILoginPage _loginPage;
		private readonly IFileDownloadPage _fileDownloadPage;

		public FileDownloaderOnPageAction(ILoginPage loginPage,
							IFileDownloadPage fileDownloadPage)
		{
			_loginPage = loginPage;
			_fileDownloadPage = fileDownloadPage;
		}

		public void SignIn()
		{
			_loginPage.LogIn();
		}

		public void DownloadTheFile(string fileName)
		{
			_fileDownloadPage.DownloadFile(fileName);
		}
	}
}
