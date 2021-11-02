using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate.BRL.Browsers.Abstractions
{
	public interface INavigator
	{
		Task GoToAsync(string url);
		Task GoBackAsync();
		Task GoForwardAsync();
		Task RefreshAsync();
	}
}
