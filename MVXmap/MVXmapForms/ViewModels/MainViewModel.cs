using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MVXMap.Core.Model;
using MVXmapForms.Services;

namespace MVXmapForms.ViewModels
{
	public class MainViewModel : BaseClass
	{
		private readonly ISuburbService _repo = null;

		public MainViewModel(ISuburbService repo)
		{
			_repo = repo;
			// Load any data required for the View Model
			LoadDataAsync();
		}

		private IList<Suburb> _suburbs = new List<Suburb>();
		public IList<Suburb> Suburbs { get { return _suburbs; } set { _suburbs = value; } }

		private string _yourNickname = string.Empty;
		public string YourNickname
		{
			get { return _yourNickname; }
			set
			{
				if (SetProperty(ref _yourNickname, value))
					RaisePropertyChanged(() => Hello);
			}
		}

		// set the message 
		public string Hello
		{
			get { return "Hello " + YourNickname; }
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
			_suburbs = await _repo.Get();
			RaisePropertyChanged(() => Suburbs);
		}
	}
}
