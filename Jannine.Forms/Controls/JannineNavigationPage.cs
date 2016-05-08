using System;
using Xamarin.Forms;

namespace Jannine.Forms.Controls
{
	public class JannineNavigationPage: NavigationPage
	{
		public JannineNavigationPage ()
		{
			Init ();
		}


		public JannineNavigationPage (Page root) : base (root)
		{
			Init ();
		}

		void Init ()
		{
			BackgroundColor = Color.FromHex ("#03A9F4");
			BarTextColor = Color.White;
		}
	}
}

