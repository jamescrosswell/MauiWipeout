using Microsoft.Extensions.Logging;

namespace MauiWipeout;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSentry(options =>
			{
				options.Dsn = "https://cc8aa9a0be20947945daf0d826745de8@o447951.ingest.us.sentry.io/4508956483518465";
				options.Debug = true;
				options.AttachScreenshot = true;
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.Services.AddSingleton<IHttpClientFactory, SentryHttpClientFactory>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

}