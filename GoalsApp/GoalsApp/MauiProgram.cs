using CommunityToolkit.Maui;
using GoalsApp.Views;
//using Plugin.LocalNotification;

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
            //.UseLocalNotification()
			.ConfigureFonts(fonts =>
			{
                //Old fonts:
				//fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				//fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                //Newly added fonts: 
                fonts.AddFont("Montserrat-Regular.ttf", "Montserrat");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-ExtraBold.ttf", "MontserratExtraBold"); //pretty bold, maybe too bold 
                fonts.AddFont("Montserrat-Light.ttf", "MontserratLight");
                fonts.AddFont("Montserrat-Italic.ttf", "MontserratItalic");

            });


        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<PasswordRecovery>();
        builder.Services.AddTransient<SignUpPage>();

		//builder.Services.AddSingleton<SQLdbContexts>();
        return builder.Build();
	}
}
