using System;
using Xamarin.Forms;
using MVXmapForms.ViewModels;

namespace MVXmapForms.Pages
{
	public class MainPage : ContentPage
	{
		public MainPage()
		{
			var aboutItem = new ToolbarItem { Text = "About",ClassId = "About", Order = ToolbarItemOrder.Primary };
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
			Content = stack;

		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
        }

	}
}
