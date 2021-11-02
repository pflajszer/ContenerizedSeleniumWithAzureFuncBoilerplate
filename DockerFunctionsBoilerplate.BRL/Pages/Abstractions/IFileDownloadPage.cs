using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate.BRL.Pages.Abstractions
{
	public interface IFileDownloadPage
	{
		void DownloadFile(string fileName);
	}
}
