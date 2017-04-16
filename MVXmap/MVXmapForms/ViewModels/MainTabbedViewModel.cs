using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MVXmapForms.Pages;
using MVXmapForms.Services;
using Xamarin.Forms;

namespace MVXmapForms.ViewModels
{
	public class MainTabbedViewModel : MvxViewModel
	{
		public MainTabbedViewModel()
		{

			var map = new MappingPage();
			map.BindingContext = new MappingViewModel(Mvx.Resolve<ISuburbService>());
			map.Title = "Map";
			Pages.Add(map); 

			var page1 = new MainPage();
			page1.BindingContext = new MainViewModel();
			page1.Title = "Main";
			Pages.Add(page1);

			var page2 = new AboutPage();
			page2.BindingContext = new AboutViewModel();
			page2.Title = "About";
			Pages.Add(page2);
		}

		IList<ContentPage> _pages = new List<ContentPage>();
		public IList<ContentPage> Pages
		{
			get { return _pages; }
			set
			{
				if (SetProperty(ref _pages, value))
					RaisePropertyChanged(() => Pages);
			}
		}
	}
}
