using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Crossplatform_ssp.StartsideFolder
{
	public class StartpageControl : CarouselPage
	{
		public StartpageControl ()
		{
            Children.Add(new Startsidessp());
            Children.Add(new Startsidecube());
            Children.Add(new Startsidetetriz());
            Children.Add(new Startsidepublikationer());
		}
	}
}