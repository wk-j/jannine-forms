using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Jannine.Forms.ViewModels;
using Jannine.Forms.Models;

namespace Jannine.Forms
{
	public partial class TwitterPage : ContentPage
	{
		private TwitterViewModel ViewModel {
			get {
				return BindingContext as TwitterViewModel;
			}
		}

		public TwitterPage ()
		{
			InitializeComponent ();
			BindingContext = new TwitterViewModel ();

			TwitterListView.ItemTapped += (s, a) => {
				if (TwitterListView.SelectedItem == null) return;
				var tweet = TwitterListView.SelectedItem as Tweet;
				Navigation.PushAsync (new WebsiteView ("https://m.twitter.com/janninamusic/" + tweet.StatusID, tweet.Date));
				TwitterListView.SelectedItem = null;
			};
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy || ViewModel.Tweets.Count > 0) return;

			ViewModel.LoadTweetsCommand.Execute (null);
		}
	}
}

