using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;
using NGIS.Forms;
using SQLite.Net.Platform.XamarinIOS;
using MVXmapForms.Services;

namespace MVXmapForms.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		UIWindow _window;
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			// Setup of the application at startup
			//global::Xamarin.Forms.Forms.Init();
			Xamarin.FormsGoogleMaps.Init(GlobalConfiguration.Instance.MapsApiKey);
			Google.Maps.MapServices.ProvideAPIKey(GlobalConfiguration.Instance.MapsApiKey);
			GlobalConfiguration.Instance.PathToDB = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MVXmap.db");
			GlobalConfiguration.Instance.Platform = new SQLitePlatformIOS();

			var setup = new Setup(this, _window);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			IDataService database = Mvx.Resolve<IDataService>();
			database.InitAsync();

			_window.MakeKeyAndVisible();

			return true;
		}
	}
}
