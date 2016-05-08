using System;
using Jannine.Forms.Models;

namespace Jannine.Forms.Helpers
{
	public interface ITweetStore
	{
		void Save (System.Collections.Generic.List<Tweet> tweets);
	}
}

