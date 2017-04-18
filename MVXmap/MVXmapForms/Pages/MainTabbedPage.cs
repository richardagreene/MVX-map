using System;
using System.Collections.Generic;
using MVXmapForms;
using MVXmapForms.ViewModels;
using Xamarin.Forms;
using MVXmap.Core;
using MVXmap.Core.Messages;
using MVXMap.Core.Messages;

namespace MVXmapForms.Pages
{
	public class MainTabbedPage : TabbedPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MVXmapForms.Pages.MainTabbedPage"/> class.
		/// </summary>
		public MainTabbedPage()
		{
			SubscribeToMessages();

			// Set a button
			ToolbarItem tbiPopulate = new ToolbarItem();
			tbiPopulate.Text = "Populate";
			tbiPopulate.SetBinding(ToolbarItem.CommandProperty, new Binding("PopulateCommand"));
            this.ToolbarItems.Add(tbiPopulate);
			ToolbarItem tbiLogout = new ToolbarItem();
			tbiLogout.Text = "Logout";
			tbiLogout.SetBinding(ToolbarItem.CommandProperty, new Binding("LogoutCommand"));
			this.ToolbarItems.Add(tbiLogout);
			ToolbarItem tbiAbout = new ToolbarItem();
			tbiAbout.Text = "About";
			tbiAbout.SetBinding(ToolbarItem.CommandProperty, new Binding("AboutCommand"));
			this.ToolbarItems.Add(tbiAbout);
		}

		/// <summary>
		/// Subscribes to messages.
		/// </summary>
		private void SubscribeToMessages()
		{
			MessagingCenter.Subscribe<AlertMessage>(this, AppMessage.Alert.ToString(), (navigationMessage) =>
			{
				// Perform the actual navigation here
				if (navigationMessage.MessageText != null)
					DisplayAlert("Message", navigationMessage.MessageText, "OK");
			});

			MessagingCenter.Subscribe<ReloadMessage>(this, AppMessage.Reload.ToString(), (navigationMessage) =>
			{
			});

		}

		/// <summary>
		/// Not good to set the binding context but can't bind to Children.
		/// </summary>
		protected override void OnBindingContextChanged()
		{
			MainTabbedViewModel vm = BindingContext as MainTabbedViewModel;
			if (vm != null)
			{
                this.Children.Clear();
				foreach (var mypage in vm.Pages)
					this.Children.Add(mypage);
			}
			base.OnBindingContextChanged();
		}
	}
}
