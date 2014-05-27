

using System;
using System.Collections.Generic;

using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using RssReader2.Activities;

namespace RssReader2.Fragments
{
	public class BrowseFragment : MyFragment
    {
		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.fragment_browse, null);

            return view;
        }
	}
}