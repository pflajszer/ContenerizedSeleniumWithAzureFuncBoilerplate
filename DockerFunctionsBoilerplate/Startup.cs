using DockerFunctionsBoilerplate;
using DockerFunctionsBoilerplate.BRL.Browsers.Abstractions;
using DockerFunctionsBoilerplate.BRL.Browsers.Implementations;
using DockerFunctionsBoilerplate.BRL.OnPageActions.Abstractions;
using DockerFunctionsBoilerplate.BRL.OnPageActions.Implementations;
using DockerFunctionsBoilerplate.BRL.Pages.Abstractions;
using DockerFunctionsBoilerplate.BRL.Pages.Implementations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DockerFunctionsBoilerplate
{
	public class Startup : FunctionsStartup
	{
public override void Configure(IFunctionsHostBuilder builder)
{
	// register dependency injection of RemoteWebDriver class:
	builder.Services.AddScoped(serviceProvider =>
	{
		var config = serviceProvider
				.GetRequiredService<IConfiguration>();
		var containerUri = new Uri(config["containerUrl"]);
		var opts = new ChromeOptions();

		return new RemoteWebDriver(containerUri, opts);
	});

	// browsers: 
	builder.Services.AddScoped<IBrowser, Chrome>();
	builder.Services.AddScoped<INavigator, Navigator>();

	// on-page actions:
	builder
		.Services
		.AddScoped
			<IFileDownloaderOnPageAction, FileDownloaderOnPageAction>();

	// pages:
	builder.Services.AddScoped<ILoginPage, LoginPage>();
	builder.Services.AddScoped<IFileDownloadPage, FileDownloadPage>();
}
	}
}
