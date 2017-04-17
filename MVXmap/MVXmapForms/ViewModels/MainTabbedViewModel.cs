using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MVXmap.Core;
using MVXmap.Core.Messages;
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
			SubscribeToMessages();
			_repo = repo;

			var map = new MappingPage();
			map.BindingContext = new MappingViewModel(Mvx.Resolve<ISuburbService>());
			map.Title = "Map";
			Pages.Add(map); 

			var page1 = new MainPage();
			page1.BindingContext = new MainViewModel(Mvx.Resolve<ISuburbService>());
			page1.Title = "Main";
			Pages.Add(page1);

			var page2 = new AboutPage();
			page2.BindingContext = new AboutViewModel();
			page2.Title = "About";
			Pages.Add(page2);

			MessagingCenter.Send<InitDatabaseMessage>(new InitDatabaseMessage(), AppMessage.InitDatabase.ToString());

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


		private void SubscribeToMessages()
		{
			MessagingCenter.Subscribe<InitDatabaseMessage>(this, AppMessage.InitDatabase.ToString(), async (result) =>
			{
			var x = await _repo.Get();

			_log.Debug("results of message=>{0}", x.Count.ToString()); 
			});
		}
	}
}
