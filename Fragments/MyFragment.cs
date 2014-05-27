using System;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Util;
using Android.App;
using Android.Content;
using Java.Interop;

namespace RssReader2
{
	public class MyFragment: Android.Support.V4.App.Fragment
	{
		private SearchView searchView;
		public ShareActionProvider shareActionProvider;

		public MyFragment ()
		{
			this.RetainInstance = true;
			this.HasOptionsMenu = true;
		}

		public override void OnCreateOptionsMenu (Android.Views.IMenu menu, Android.Views.MenuInflater inflater)
		{
			inflater.Inflate (Resource.Menu.menuBar, menu);
			var actionView = menu.FindItem (Resource.Id.action_search).ActionView;
			searchView = actionView.JavaCast<Android.Widget.SearchView>();
			IMenuItem item = menu.FindItem (Resource.Id.share_menu);
			item.SetVisible (true);
			shareActionProvider = (ShareActionProvider)item.ActionProvider;
			shareActionProvider.SetShareIntent (
				IntentUtils.CreateShareIntent ("text/plain", "Share this!!!"));

			if (searchView != null) {
				searchView.SetIconifiedByDefault (true);
			}

			searchView.QueryTextSubmit += (sender, e) => {
				Toast.MakeText(Activity,
					"You searched for: " + e.Query,
					ToastLength.Long).Show();
			};

			base.OnCreateOptionsMenu (menu, inflater);
		}
	}
}

