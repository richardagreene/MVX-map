using System;
using Xamarin.Forms;
using MVXmapForms.ViewModels;
using System.Collections.ObjectModel;
using MVXMap.Core.Model;

namespace MVXmapForms.Pages
{
	public class MainPage : ContentPage
	{
		public ObservableCollection<Suburb> _suburbs { get; set; }
		public MainPage()
		{
			_suburbs = new ObservableCollection<Suburb>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Suburbs";
			lstView.ItemTemplate = new DataTemplate(typeof(CustomSuburbCell));
			lstView.IsPullToRefreshEnabled = true;
			lstView.SetBinding(ListView.ItemsSourceProperty, new Binding("Suburbs"));

			var stack = new StackLayout() { Spacing = 10, Orientation = StackOrientation.Vertical };
			var searchBar = new SearchBar() { Placeholder = "Search" };
			searchBar.SetBinding(SearchBar.TextProperty, new Binding("Search"));
			searchBar.SetBinding(SearchBar.SearchCommandProperty, new Binding("FilterListCommand"));

			stack.Children.Add( searchBar );
			stack.Children.Add(lstView);

			Content = stack;

		}

		public class CustomSuburbCell : ViewCell
		{
			public CustomSuburbCell()
			{
				//instantiate each of our views
				var nameLabel = new Label();
				var typeLabel = new Label();
				var verticaLayout = new StackLayout();
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.White };

				//set bindings
				nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
				//typeLabel.SetBinding(Label.TextProperty, new Binding("Type"));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				nameLabel.FontSize = 24;

				//add views to the view hierarchy
				verticaLayout.Children.Add(nameLabel);
				verticaLayout.Children.Add(typeLabel);
				horizontalLayout.Children.Add(verticaLayout);

				// add to parent view
				View = horizontalLayout;
			}
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
        }

	}
}
