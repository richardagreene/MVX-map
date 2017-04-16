using MvvmCross.Platform.IoC;
using Xamarin.Forms;

namespace MVXmapForms.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterAppStart<ViewModels.MainTabbedViewModel>();
		}

	}
}
