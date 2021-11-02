using DockerFunctionsBoilerplate.BRL.Browsers.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DockerFunctionsBoilerplate
{
	public class Function1
	{
		private readonly IBrowser _browser;
		public Function1(IBrowser browser)
		{
			_browser = browser;
		}

		[FunctionName("Function1")]
		public async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
			ILogger log)
		{
			await _browser.GetMavenProjectTextFile();

			return new OkResult();
		}
	}
}
