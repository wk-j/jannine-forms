using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Jannine.Forms.ViewModels;
using Jannine.Forms.Models;

namespace Jannine.Forms
{
	public partial class MenuPage : ContentPage
	{
		private RootPage _root;
		private List<HomeMenuItem> _menuItems;

		public MenuPage (RootPage root)
		{
			InitializeComponent ();

			_root = root;

			BindingContext = new BaseViewModel {
				Title = "Jannine Weigel",
				Icon = "slideout.png"
			};

			ListViewMenu.ItemsSource = _menuItems = new List<HomeMenuItem> () { 
				new HomeMenuItem { Title = "About",MenuType = MenuType.About, Icon = "about.png" },
				new HomeMenuItem { Title = "Twitter", MenuType = MenuType.Twitter, Icon = "twitter.png" },
				new HomeMenuItem { Title = "Instagram", MenuType = MenuType.Instagram, Icon = "instagram.png" },
				new HomeMenuItem { Title = "Soundcloud", MenuType = MenuType.Soundcloud, Icon = "soundcloud.png" },
			};

			ListViewMenu.SelectedItem = _menuItems [0];
			ListViewMenu.ItemSelected += async (s, e) => {
				if (ListViewMenu.SelectedItem == null)
					return;

				var menu = (HomeMenuItem)e.SelectedItem;
				await _root.NavigateAsync (menu.MenuType);
			};
		}
	}
}

