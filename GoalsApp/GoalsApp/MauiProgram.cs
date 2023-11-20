﻿using GoalsApp.Views;

namespace GoalsApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

			});


        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<PasswordRecovery>();
        builder.Services.AddTransient<RegistrationPage>();

		builder.Services.AddSingleton<SQLdbContexts>();
        return builder.Build();
	}
}
