using System;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using RssReader2.Model;
using RssReader2.Enums;
using Java.Net;
using Android.Util;
using System.Xml;
using Org.XmlPull.V1;
using Android.App;
using Java.Interop;
using Android.Views;

namespace RssReader2
{
	public class NewsFragment: Android.Support.V4.App.Fragment
	{
		private List<Post> items = new List<Post>();
		private SearchView searchView;
		private View view;
		private ListView grid;
		private ShareActionProvider shareActionProvider;

		public NewsFragment()
		{
			this.RetainInstance = true;
			this.HasOptionsMenu = true;
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			view = inflater.Inflate(Resource.Layout.fragment_news, null);

			string url = GetString (Resource.String.rss_fge);
			GetRss (url);

			UpdateAdapter ();

			grid.ItemClick += (sender, args) =>{
				Post post = items[args.Position];
				Log.Debug("DEBUG", "Post: " + post.Title);
			};

			return view;
		}

		private void GetRss(string url){
			try{
				items.Clear ();
				items = new GetRssData ().Execute (url).GetResult ();
			}catch(Exception ex){
				Log.Error ("ERROR", ex.StackTrace);
				Toast.MakeText (Activity.ApplicationContext,
					"Ocurrio un error al cargar las noticias. Intentelo de nuevo.",
					ToastLength.Long).Show ();
			}
		}

		private void UpdateAdapter(){
			grid = view.FindViewById<ListView> (Resource.Id.news_list);
			grid.Adapter = new PostAdapter(Activity, Resource.Layout.item, items);
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
				GetRss(e.Query);
				UpdateAdapter();
			};

			base.OnCreateOptionsMenu (menu, inflater);
		}
	}
}

