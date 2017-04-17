using System;
using MVXmapForms.Services;
using Xamarin.Forms;

namespace MVXmapForms.Pages
{
	public class NetworkPage: ContentPage
	{

		public NetworkPage() 
		{
			var layout = new StackLayout();
			var button = new Button
			{
				Text = "StackLayout",
				BorderWidth=1,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			button.SetBinding(Button.CommandProperty, new Binding("APICommand"));
			layout.Children.Add(button);

			var label = new Label();
			label.SetBinding(Label.TextProperty, new Binding("APIResult"));
			layout.Children.Add(label);
			Content = layout;
		}
	}
}
