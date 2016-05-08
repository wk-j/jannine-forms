using System;

using Xamarin.Forms;

namespace Jannine.Forms
{
	public class SoundcloudPage : ContentPage
	{
		public SoundcloudPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


