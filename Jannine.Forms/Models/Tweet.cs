using System;
using Newtonsoft.Json;

namespace Jannine.Forms.Models
{
	public class Tweet
	{
		public Tweet ()
		{
		}

		public ulong StatusID { set; get; }
		public string ScreenName { set; get; }
		public string Text { set; get; }
		public DateTime CreatedAt { set; get; }
		public ulong CurrentUserRetweet { set; get; }
		public string Image { set; get; }

		[JsonIgnore]
		public string Date { get { return CreatedAt.ToString ("g"); } }

		[JsonIgnore]
		public string RTCout {
			get {
				return CurrentUserRetweet == 0 ? string.Empty : CurrentUserRetweet + "RT";
			}
		}

	}
}

