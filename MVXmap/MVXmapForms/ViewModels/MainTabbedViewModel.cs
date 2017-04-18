using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MVXmap.Core;
using MVXmap.Core.Messages;
using MVXMap.Core.Messages;
using MVXMap.Core.Model;
using MVXmapForms.Pages;
using MVXmapForms.Services;
using Xamarin.Forms;

namespace MVXmapForms.ViewModels
{
	public class MainTabbedViewModel : BaseClass
	{
		private readonly ISuburbService _repo = null;

		public MainTabbedViewModel(ISuburbService repo)
		{
			_repo = repo;

			var map = new MappingPage();
			map.BindingContext = new MappingViewModel(Mvx.Resolve<ISuburbService>());
			map.Title = "Map";
			Pages.Add(map); 

			var page1 = new MainPage();
			page1.BindingContext = new MainViewModel(Mvx.Resolve<ISuburbService>());
			page1.Title = "Main";
			Pages.Add(page1);

			var page2 = new NetworkPage();
			page2.BindingContext = new NetworkViewModel(Mvx.Resolve<INetworkAPIService>());
			page2.Title = "Network";
			Pages.Add(page2);

			// tell all child pages to load
			MessagingCenter.Send<ReloadMessage>(new ReloadMessage(), AppMessage.Reload.ToString());

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


		//  -------- Commands  -----------

		public ICommand LogoutCommand
		{
			get	{ return new MvxCommand(() => { 
					MessagingCenter.Send<AlertMessage>(new AlertMessage() { MessageText = "Message From Beyond!" }, AppMessage.Alert.ToString());	});
			}
		}

		public ICommand AboutCommand
		{
			get { return new MvxCommand(() => ShowViewModel<AboutViewModel>()); }
		}

		public ICommand PopulateCommand
		{
			get
			{
				return new MvxCommand(async () =>
				{
					// Get current list and add one
					var _current = await _repo.Get();
					Random rnd = new Random();
					var s = new Suburb()
					{
						Name = String.Format("test{0}", _current.Count),
						Long = -122.40181 + rnd.NextDouble(),
						LAT = 37.79762 + rnd.NextDouble()
					};
					await _repo.Insert(s);
					MessagingCenter.Send<ReloadMessage>(new ReloadMessage(), AppMessage.Reload.ToString());
				});
			}
		}
	}
}
