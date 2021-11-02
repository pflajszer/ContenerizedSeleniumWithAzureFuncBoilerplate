using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate.BRL.Browsers.Abstractions
{
	public interface IBrowser
	{
		Task GetMavenProjectTextFile();
	}
}
