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
			// about button
			/* var aboutItem = new ToolbarItem { Text = "About",ClassId = "About", Order = ToolbarItemOrder.Primary };
			aboutItem.SetBinding(ToolbarItem.CommandProperty, new Binding("ShowAboutPageCommand"));
			ToolbarItems.Add(aboutItem);

			var entry = new Entry() { Placeholder = "Who are you?", TextColor = Color.Red };
			entry.SetBinding(Entry.TextProperty, new Binding("YourNickname"));
			var label = new Label();
			label.SetBinding(Label.TextProperty, new Binding("Hello"));
			var stack = new StackLayout() { Spacing = 10, Orientation = StackOrientation.Vertical };
			stack.Children.Add(new Label() { Text = "Enter your name" });
			stack.Children.Add(entry);
			stack.Children.Add(label);
			*/
			_suburbs = new ObservableCollection<Suburb>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Suburbs";
			lstView.ItemTemplate = new DataTemplate(typeof(CustomSuburbCell));
			_suburbs.Add(new Suburb { Name = "test" });
			_suburbs.Add(new Suburb { Name = "test1" });
			_suburbs.Add(new Suburb { Name = "test2" });
			lstView.SetBinding(ListView.ItemsSourceProperty, new Binding("Suburbs"));
			//lstView.ItemsSource = _suburbs;
			Content = lstView;

		}

		public class CustomSuburbCell : ViewCell
		{
			public CustomSuburbCell()
			{
				//instantiate each of our views
				var image = new Image();
				var nameLabel = new Label();
				var typeLabel = new Label();
				var verticaLayout = new StackLayout();
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.AntiqueWhite };

				//set bindings
				nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
				//typeLabel.SetBinding(Label.TextProperty, new Binding("Type"));
				//image.SetBinding(Image.SourceProperty, new Binding("Image"));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				image.HorizontalOptions = LayoutOptions.End;
				nameLabel.FontSize = 24;

				//add views to the view hierarchy
				verticaLayout.Children.Add(nameLabel);
				verticaLayout.Children.Add(typeLabel);
				horizontalLayout.Children.Add(verticaLayout);
				horizontalLayout.Children.Add(image);

				// add to parent view
				View = horizontalLayout;
			}
		}

		protected override void OnBindingContextChanged()
		{
			MainViewModel vm = BindingContext as MainViewModel;
			base.OnBindingContextChanged();
        }

	}
}
