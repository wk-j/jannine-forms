using System;
namespace Jannine.Forms.Models
{
	public enum MenuType
	{
		About,
		Twitter,
		Soundcloud
	}

	public class BaseMedel
	{
		public string Title { set; get; }
		public string Details { set; get; }
		public int Id { set; get; }
	}

	public class HomeMenuItem : BaseMedel
	{
		public HomeMenuItem ()
		{
			MenuType = MenuType.About;
		}

		public string Icon { set; get; }
		public MenuType MenuType { set; get; }
	}
}

