using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MVXmap.Core.Messages;
using MVXMap.Core.Model;
using MVXmapForms.Services;
using Xamarin.Forms;

namespace MVXmapForms.ViewModels
{
	public class MainViewModel : BaseClass
	{
		private readonly ISuburbService _repo = null;

		public MainViewModel(ISuburbService repo)
		{
			_repo = repo;
			// Load any data required for the View Model
			SubscribeToMessages();
		}

		private IList<Suburb> _suburbs = new List<Suburb>();
		public IList<Suburb> Suburbs { get { return _suburbs; } set { SetProperty(ref _suburbs, value); } }

		private string _search = string.Empty;
		public string Search
		{
			get { return _search; }
			set { SetProperty(ref _search, value); }
		}

		public ICommand FilterListCommand
		{
			get { return new MvxCommand(async () => await LoadDataAsync()); }
		}

		public ICommand ShowAboutPageCommand
		{
			get { return new MvxCommand(() => ShowViewModel<AboutViewModel>()); }
		}

		/// <summary>
		/// Loads the data async from the database
		/// </summary>
		/// <returns>The data async.</returns>
		async Task LoadDataAsync()
		{
			if (string.IsNullOrEmpty(Search))
				Suburbs = await _repo.Get();
			else
			{
				var result = await _repo.Get();
				Suburbs = result.Where(x => x.Name.ToLower().Contains(Search.ToLower())).ToList();
			}
		}

		//  -------- Messages  -----------

		/// <summary>
		/// Subscribes to messages.
		/// </summary>
		private void SubscribeToMessages()
		{
			MessagingCenter.Subscribe<ReloadMessage>(this, AppMessage.Reload.ToString(), async (result) =>
			{
				await LoadDataAsync();
			});
		}
	}
}
