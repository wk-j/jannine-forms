using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using Jannine.Forms.Models;
using Jannine.Forms.ViewModels;
using Jannine.Forms.Controls;

namespace Jannine.Forms
{
	public class RootPage : MasterDetailPage
	{

		private Dictionary<MenuType, NavigationPage> _pages { set; get; }

		public RootPage ()
		{
			_pages = new Dictionary<MenuType, NavigationPage> ();
			Master = new MenuPage (this);
			BindingContext = new BaseViewModel {
				Title = "Jannine",
				Icon = "slideout.png"
			};

			NavigateAsync (MenuType.About);
			InvalidateMeasure ();
		}

		public async Task NavigateAsync (MenuType id)
		{
			Page newPage;
			if (!_pages.ContainsKey (id)) {
				switch (id) {
				case MenuType.About:
					_pages.Add (id, new JannineNavigationPage (new AboutPage ()));
					break;
				case MenuType.Twitter:
					_pages.Add (id, new JannineNavigationPage (new TwitterPage ()));
					break;
				case MenuType.Soundcloud:
					_pages.Add (id, new JannineNavigationPage (new SoundcloudPage ()));
					break;
				case MenuType.Instagram:
					_pages.Add (id, new JannineNavigationPage (new InstagramPage ()));
					break;
				}
			}

			newPage = _pages [id];
			if (newPage == null) return;

			Detail = newPage;
			if (Device.Idiom != TargetIdiom.Tablet) {
				IsPresented = false;
			}
		}
	}
}


