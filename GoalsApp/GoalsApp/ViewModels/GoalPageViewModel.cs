namespace GoalsApp;

public class NewPage1 : ContentPage
{
	public NewPage1()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				} //new .cs file for goal view model
			}
		};
	}
}