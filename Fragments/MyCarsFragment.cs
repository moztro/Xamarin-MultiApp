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
using Android.Content;
using System.IO;

namespace RssReader2
{
	public class MyCarsFragment: MyFragment //Android.Support.V4.App.Fragment
	{
		private List<Car> items;
		private SearchView searchView;
		private GridView grid;

		public MyCarsFragment()
		{
			items = Car.GenerateData ();
			this.RetainInstance = true;
			this.HasOptionsMenu = true;
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.fragment_mycars, null);
			grid = view.FindViewById<GridView> (Resource.Id.my_cars_grid);

			UpdateAdapter (items);

			grid.ItemClick += (sender, args) =>{
				Car car = items[args.Position];
				Toast.MakeText(Activity.ApplicationContext,
					car.Name,
					ToastLength.Short).Show();
			};
				
			return view;
		}

		private void UpdateAdapter(List<Car> carList){
			grid.Adapter = new CarAdapter(Activity, Resource.Layout.car_item, carList);
		}

		public override void OnCreateOptionsMenu (Android.Views.IMenu menu, Android.Views.MenuInflater inflater)
		{
			inflater.Inflate (Resource.Menu.menuBar, menu);
			var actionView = menu.FindItem (Resource.Id.action_search).ActionView;
			searchView = actionView.JavaCast<Android.Widget.SearchView>();


			if (searchView != null) {
				searchView.SetIconifiedByDefault (true);
			}

			searchView.QueryTextSubmit += (sender, e) => {
				OnSearch (e.Query);
			};

			base.OnCreateOptionsMenu (menu, inflater);
		}

		private void OnSearch(string mySearch){
			items.Clear();
			items = Car.GenerateData();
			List<Car> retList = new List<Car>();

			foreach(Car car in items){
				foreach(string tag in car.Tags){
					if(mySearch.Contains(tag)){
						retList.Add(car);
						break;
					}
				}
			}
			items = retList;

			UpdateAdapter(retList);

			Toast.MakeText(Activity.ApplicationContext,
				"Your result for: " + mySearch,
				ToastLength.Short).Show();
		}
	}
}

