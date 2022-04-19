namespace ASB;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		MauiAppBuilder builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("NotoSans-Black.ttf", "NotoSans-Black");
				fonts.AddFont("NotoSans-BlackItalic.ttf", "NotoSans-BlackItalic");
				fonts.AddFont("NotoSans-Bold.ttf", "NotoSans-Bold");
				fonts.AddFont("NotoSans-BoldItalic.ttf", "NotoSans-BoldItalic");
				fonts.AddFont("NotoSans-ExtraBold.ttf", "NotoSans-ExtraBold");
				fonts.AddFont("NotoSans-ExtraBoldItalic.ttf", "NotoSans-ExtraBoldItalic");
				fonts.AddFont("NotoSans-ExtraLight.ttf", "NotoSans-ExtraLight");
				fonts.AddFont("NotoSans-ExtraLightItalic.ttf", "NotoSans-ExtraLightItalic");
				fonts.AddFont("NotoSans-Italic.ttf", "NotoSans-Italic");
				fonts.AddFont("NotoSans-Light.ttf", "NotoSans-Light");
				fonts.AddFont("NotoSans-LightItalic.ttf", "NotoSans-LightItalic");
				fonts.AddFont("NotoSans-Medium.ttf", "NotoSans-Medium");
				fonts.AddFont("NotoSans-MediumItalic.ttf", "NotoSans-MediumItalic");
				fonts.AddFont("NotoSans-Regular.ttf", "NotoSans-Regular");
				fonts.AddFont("NotoSans-SemiBold.ttf", "NotoSans-SemiBold");
				fonts.AddFont("NotoSans-SemiBoldItalic.ttf", "NotoSans-SemiBoldItalic");
				fonts.AddFont("NotoSans-Thin.ttf", "NotoSans-Thin");
				fonts.AddFont("NotoSans-ThinItalic.ttf", "NotoSans-ThinItalic");
			});

		return builder.Build();
	}
}
