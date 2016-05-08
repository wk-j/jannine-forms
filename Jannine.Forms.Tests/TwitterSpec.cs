using System;
using NUnit.Framework;
using Jannine.Forms.ViewModels;

namespace Jannine.Forms.Tests
{
	[TestFixture]
	public class TwitterSpec
	{
		public TwitterSpec ()
		{
		}

		[Test]
		public void ShouldEqual1 ()
		{
			Assert.AreEqual (1, 1);
		}


		[Test]
		public void ShouldGetTweets ()
		{
			var tw = new TwitterViewModel ();
			tw.ExecuteLoadTweetsCommand ();

			var rs = tw.Tweets;
			Assert.IsTrue (rs.Count > 0);
		}
	}
}

