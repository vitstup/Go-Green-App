using Microsoft.Extensions.Logging;
using SoberApp.Code;
using SoberApp.Code.Databases;

namespace SoberApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
				});

			builder.Services.AddMauiBlazorWebView();
			//builder.Services.Configure<options>

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

			string connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AccountsDatabase.db3");
			AccountsDb db = new AccountsDb(connectionString);
			builder.Services.AddSingleton<AccountsDb>(db);

			builder.Services.AddSingleton<CurrentInfo>();

			return builder.Build();
		}
	}
}