﻿using CommunityToolkit.Maui;
using GoalsApp.Views;

namespace GoalsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        
        // Initialise the toolkit
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                //Newly added fonts: 
                fonts.AddFont("Montserrat-Regular.ttf", "Montserrat");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-ExtraBold.ttf", "MontserratExtraBold"); //pretty bold, maybe too bold 
                fonts.AddFont("Montserrat-Light.ttf", "MontserratLight");
                fonts.AddFont("Montserrat-Italic.ttf", "MontserratItalic");

            });


        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<PasswordRecovery>();
        builder.Services.AddTransient<RegistrationPage>();

        return builder.Build();
	}
}
