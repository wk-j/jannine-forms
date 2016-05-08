using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Jannine.Forms
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();

			Twitter.GestureRecognizers.Add (new TapGestureRecognizer () {
				Command = new Command (async () => {
					await Navigation.PushAsync (new WebsiteView ("https://m.twitter.com/janninamusic", "@JanninaMusic"));
				})
			});

			Facebook.GestureRecognizers.Add (new TapGestureRecognizer () {
				Command = new Command (async () => {
					await Navigation.PushAsync (new WebsiteView ("https://facebook.com/JanninaW", "Jannine @Facebook"));
				})
			});

			Soundcloud.GestureRecognizers.Add (new TapGestureRecognizer () {
				Command = new Command (async () => {
					await Navigation.PushAsync (new WebsiteView ("https://soundcloud.com/jannina-weigel", "Jannine @Soundcloud"));
				})
			});

			Instagram.GestureRecognizers.Add (new TapGestureRecognizer () {
				Command = new Command (async () => {
					await Navigation.PushAsync (new WebsiteView ("https://www.instagram.com/jannineweigel", "Jannine @Intragram"));
				})
			});
		}
	}
}

