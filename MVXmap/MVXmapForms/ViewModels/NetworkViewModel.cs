using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MVXmapForms.Services;

namespace MVXmapForms.ViewModels
{
	public class NetworkViewModel : MvxViewModel
	{
		INetworkAPIService _netService = null;
		string _apiResult;

		public NetworkViewModel(INetworkAPIService netService)
		{
			_netService = netService;
		}

		public string APIResult
		{
			get { return _apiResult; }
			set { SetProperty(ref _apiResult, value); }
		}

		public ICommand APICommand
		{
			get
			{
				return new MvxCommand(HandleClick);
		 	}
		}

		public async void HandleClick()
		{
			APIResult = await _netService.GetData();	
		}
	}
}
