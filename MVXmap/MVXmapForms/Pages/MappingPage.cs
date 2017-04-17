using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MVXmap.Core.Messages;
using MVXMap.Core.Model;
using MVXmapForms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace MVXmapForms.Pages
{
	public class MappingPage : ContentPage
	{
		Map _map = new Map();
		public MappingPage()
		{
			SubscribeToMessages();
			_map.MapType = MapType.Street;
			_map.VerticalOptions = LayoutOptions.FillAndExpand;

			var grid = new Grid();
			grid.HorizontalOptions = LayoutOptions.Fill;
			grid.VerticalOptions = LayoutOptions.Fill;
			grid.Children.Add(_map);
			Content = grid;

			// Map Clicked
			_map.MapClicked += (sender, e) =>
			{
				var lat = e.Point.Latitude.ToString("0.000");
				var lng = e.Point.Longitude.ToString("0.000");
				this.DisplayAlert("MapClicked", $"{lat}/{lng}", "CLOSE");
			};

			// Map Long clicked
			_map.MapLongClicked += (sender, e) =>
			{
				var lat = e.Point.Latitude.ToString("0.000");
				var lng = e.Point.Longitude.ToString("0.000");

				this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
			};

			Position position = new Position(37.79762, -122.40181);
			_map.MoveToRegion(new MapSpan(position, 10, 10));
			_map.HasZoomEnabled = true;
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
		}

		public void SetPins(Map map, IList<Suburb> suburbs)
		{
			foreach (var suburb in suburbs)
			{
				if (suburb.LAT == 0) continue; // no value
				Position position = new Position(suburb.LAT, suburb.Long);
				_map.Pins.Add(new Pin
				{
					Label = suburb.Name,
					Position = position
				});
			}
		}
		/// <summary>
		/// Subscribes to messages.
		/// </summary>
		private void SubscribeToMessages()
		{
			MessagingCenter.Subscribe<ReloadMessage>(this, AppMessage.Reload.ToString(), (navigationMessage) =>
			{
				MappingViewModel vm = BindingContext as MappingViewModel;
				if (vm != null)
					SetPins(_map, vm.Suburbs);
			});
		}
	}
}
