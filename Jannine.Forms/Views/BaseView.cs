using System;
using Xamarin.Forms;
namespace Jannine.Forms
{
	public class BaseView: ContentPage
	{
		public BaseView ()
		{
			SetBinding (Page.TitleProperty, new Binding ("Title"));
			SetBinding (Page.IconProperty, new Binding ("Icon"));
		}
	}
}

