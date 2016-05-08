using System;
using Xamarin.Forms;
using System.Linq;
using LinqToTwitter;
using System.Collections.ObjectModel;
using Jannine.Forms.Models;
using System.Threading.Tasks;
using Jannine.Forms.Helpers;

namespace Jannine.Forms.ViewModels
{
	public class TwitterViewModel : BaseViewModel
	{
		private Command _loadTweetsCommand;

		public ObservableCollection<Tweet> Tweets { set; get; }

		public TwitterViewModel ()
		{
			Title = "Twitter";
			Icon = "slideout.png";
			Tweets = new ObservableCollection<Tweet> ();
		}

		public Command LoadTweetsCommand {
			get {
				return _loadTweetsCommand ?? (_loadTweetsCommand = new Command (async () => {
					await ExecuteLoadTweetsCommand ();
				}, () => {
					return !IsBusy;
				}));
			}
		}
		public async Task _ExecuteLoadTweetsCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			LoadTweetsCommand.ChangeCanExecute ();
			var error = false;
			try {

				Tweets.Clear ();
				/*
				var auth = new ApplicationOnlyAuthorizer () {
					CredentialStore = new InMemoryCredentialStore {
						ConsumerKey = "ZTmEODUCChOhLXO4lnUCEbH2I",
						ConsumerSecret = "Y8z2Wouc5ckFb1a0wjUDT9KAI6DUat5tFNdmIkPLl8T4Nyaa2J",
					},
				}; */

				var auth = new ApplicationOnlyAuthorizer () {
					CredentialStore = new InMemoryCredentialStore {
						ConsumerKey = "nvQvzjkVQYagpijRzZIsQ",
						ConsumerSecret = "r3xtESAVMZu4uHDDDOKEbXew3RX1cvL2k7lsgZoOE",
					},
				}; 

		
				await auth.AuthorizeAsync ();

				var twitterContext = new TwitterContext (auth);
				var jannineMusic = "JanninaWMusic";

				var queryResponse = await
				  (from tweet in twitterContext.Status
				   where tweet.Type == StatusType.User &&
					tweet.ScreenName == jannineMusic &&
					 tweet.Count == 100 &&
					 tweet.IncludeRetweets == true &&
					 tweet.ExcludeReplies == true
				   select tweet).ToListAsync ();

				var tweets =
				  (from tweet in queryResponse
				   select new Tweet {
					   StatusID = tweet.StatusID,
					   ScreenName = tweet.User.ScreenNameResponse,
					   Text = tweet.Text,
					   CurrentUserRetweet = tweet.CurrentUserRetweet,
					   CreatedAt = tweet.CreatedAt,
					   Image = tweet.RetweetedStatus != null && tweet.RetweetedStatus.User != null ?
									tweet.RetweetedStatus.User.ProfileImageUrl.Replace ("http://", "https://") : (tweet.User.ScreenNameResponse == jannineMusic ? "jannine.png" : tweet.User.ProfileImageUrl.Replace ("http://", "https://"))
				   }).ToList ();
				foreach (var tweet in tweets) {
					Tweets.Add (tweet);
				}

				if (Device.OS == TargetPlatform.iOS) {
					// only does anything on iOS, for the Watch
					DependencyService.Get<ITweetStore> ().Save (tweets);
				}



			} catch {
				error = true;
			}

			if (error) {
				var page = new ContentPage ();
				await page.DisplayAlert ("Error", "Unable to load tweets.", "OK");
			}

			IsBusy = false;
			LoadTweetsCommand.ChangeCanExecute ();

		}

		public async Task ExecuteLoadTweetsCommand ()
		{
			if (IsBusy) return;
			IsBusy = true;
			LoadTweetsCommand.ChangeCanExecute ();

			var error = false;

			try {
				Tweets.Clear ();
				var auth = new ApplicationOnlyAuthorizer {
					CredentialStore = new InMemoryCredentialStore {
						ConsumerKey = "ZTmEODUCChOhLXO4lnUCEbH2I",
						ConsumerSecret = "Y8z2Wouc5ckFb1a0wjUDT9KAI6DUat5tFNdmIkPLl8T4Nyaa2J"
					}
				};
				await auth.AuthorizeAsync ();
				var twitterContext = new TwitterContext (auth);
				var jw = "JaninaWMusic";
				var queryResponse = await
					(from tweet in twitterContext.Status
					 where tweet.Type == StatusType.User &&
					 tweet.ScreenName == jw &&
					 tweet.Count == 100 &&
					 tweet.IncludeRetweets == true &&
					 tweet.ExcludeReplies == true
					 select tweet).ToListAsync ();

				var tweets =
					(from tweet in queryResponse
					 select new Tweet {
						 StatusID = tweet.StatusID,
						 ScreenName = tweet.ScreenName,
						 Text = tweet.Text,
						 CurrentUserRetweet = tweet.CurrentUserRetweet,
						 CreatedAt = tweet.CreatedAt,
						 Image = tweet.RetweetedStatus != null && tweet.RetweetedStatus.User != null ?
									  tweet.RetweetedStatus.User.ProfileImageUrl.Replace ("http://", "https://") :
										  (tweet.User.ScreenNameResponse == jw ? "jannine.png" : tweet.User.ProfileImageUrl.Replace ("http://", "https://"))
					 }).ToList ();

				foreach (var tweet in tweets) {
					Tweets.Add (tweet);
				}

				if (Device.OS == TargetPlatform.iOS) {
					//DependencyService.Get<ITweetStore> ().Save (tweets);
				}

			} catch (Exception ex) {
				error = true;
			}

			if (error) {
				var page = new ContentPage ();
				await page.DisplayAlert ("Error", "Unable to load tweets", "OK");
			}

			IsBusy = false;
			LoadTweetsCommand.ChangeCanExecute ();

		}
	}
}

