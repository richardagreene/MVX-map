using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MVXmap.Core.Messages;
using MVXMap.Core.Messages;
using MVXMap.Core.Model;
using MVXmapForms.Services;
using Xamarin.Forms;

namespace MVXmapForms.ViewModels
{
	public class MappingViewModel : BaseClass
	{
		private readonly ISuburbService _repo = null;

		public MappingViewModel(ISuburbService repo)
		{
			_repo = repo;
			SubscribeToMessages();
		}

		private List<Suburb> _suburbs = new List<Suburb>();
		public List<Suburb> Suburbs
		{
			get { return _suburbs; }
			set { SetProperty(ref _suburbs, value); }
		 } 

		/// <summary>
		/// Loads the data async from the database
		/// </summary>
		/// <returns>The data async.</returns>
		async Task LoadDataAsync()
		{
			Suburbs = await _repo.Get();
			_log.Debug("Map Got data {0} records", _suburbs.Count);
 			RaisePropertyChanged(() => Suburbs);
			MessagingCenter.Send<ShowPinsMessage>(new ShowPinsMessage(), AppMessage.ShowPins.ToString());
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
