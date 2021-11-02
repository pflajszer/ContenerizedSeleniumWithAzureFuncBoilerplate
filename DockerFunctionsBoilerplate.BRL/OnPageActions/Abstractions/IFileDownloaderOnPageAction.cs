using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate.BRL.OnPageActions.Abstractions
{
	public interface IFileDownloaderOnPageAction
	{
		void SignIn();
		void DownloadTheFile(string fileName);
	}
}
