using System;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace MVXmapForms.Pages
{
	public class MappingPage: ContentPage
	{
		public MappingPage()
		{

			var map = new Map();
			map.MapType = MapType.Street;
			map.VerticalOptions = LayoutOptions.FillAndExpand;


			var grid = new Grid();
			grid.HorizontalOptions = LayoutOptions.Fill;
			grid.VerticalOptions = LayoutOptions.Fill;
			grid.Children.Add(map);
			Content = grid;

			// Map Clicked
			map.MapClicked += (sender, e) =>
			{
				var lat = e.Point.Latitude.ToString("0.000");
				var lng = e.Point.Longitude.ToString("0.000");
				this.DisplayAlert("MapClicked", $"{lat}/{lng}", "CLOSE");
			};

			// Map Long clicked
			map.MapLongClicked += (sender, e) =>
			{
				var lat = e.Point.Latitude.ToString("0.000");
				var lng = e.Point.Longitude.ToString("0.000");

				this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
			};

			Position position = new Position(37.79762, -122.40181);
			map.MoveToRegion(new MapSpan(position,  10, 10));
			map.HasZoomEnabled = true;
			// set pins
			SetPins();
		}

		public async void SetPins()
		{
//			var connection = GlobalConfiguration.Instance.Connection;
//			IRepository<Suburb> stockRepo = new Repository<Suburb>(connection);
//			var results = await stockRepo.Get();
//			foreach (var result in results)
//			{
//				if (result.LAT == 0) continue; // no value
//				Position position = new Position(result.LAT, result.Long);
//				map.Pins.Add(new Pin
//				{
//					Label = result.Name,
//					Position = position
//				});
//			}
		}
	}
}
