using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using RssReader2.Fragments;
using RssReader2.Helpers;
using System.Collections.Generic;
using RssReader2.Model;
using RssReader2.Enums;
using Java.Net;
using System.Xml;
using Android.Util;
using Org.XmlPull.V1;
using ZXing.Mobile;
using ZXing;

namespace RssReader2.Activities
{
	[Activity(MainLauncher = true, LaunchMode = LaunchMode.SingleTop,Theme = "@style/MyTheme", Icon = "@drawable/hot_wheels_logo")]
    public class HomeView : FragmentActivity
	{
        
        private MyActionBarDrawerToggle m_DrawerToggle;
        private string m_DrawerTitle;
        private string m_Title;

        private DrawerLayout m_Drawer;
		private ListView m_DrawerList;
		//private ListView m_NewsList;
		private static readonly string[] sections = new[]
            {
			"Account", "News", "My Cars", "Scan", "Family", "Work", "My Group 1", "My Group 2", "Spam"
            };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_home_view);

            this.m_Title = this.m_DrawerTitle = this.Title;

            this.m_Drawer = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this.m_DrawerList = this.FindViewById<ListView>(Resource.Id.left_drawer);

			this.m_DrawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, sections);

            this.m_DrawerList.ItemClick += (sender, args) => ListItemClicked(args.Position);


			this.m_Drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

            this.m_DrawerToggle = new MyActionBarDrawerToggle(this, this.m_Drawer,
                                                      Resource.Drawable.ic_drawer_light,
                                                      Resource.String.drawer_open,
                                                      Resource.String.drawer_close);

            this.m_DrawerToggle.DrawerClosed += (o, args) => 
            {
                this.ActionBar.Title = this.m_Title;
                this.InvalidateOptionsMenu();
            };

            this.m_DrawerToggle.DrawerOpened += (o, args) => 
            {
                this.ActionBar.Title = this.m_DrawerTitle;
                this.InvalidateOptionsMenu();
            };

            this.m_Drawer.SetDrawerListener(this.m_DrawerToggle);

			this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.SetHomeButtonEnabled(true);
        }

		protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this.m_DrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this.m_DrawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (this.m_DrawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }

        private void ListItemClicked(int position)
        {
			Android.Support.V4.App.Fragment fragment = null;

			switch (position) {
			case 0: 
				fragment = new AddUserFragment ();
				break;
			case 1:
				fragment = new NewsFragment ();
				break;
			case 2:
				fragment = new MyCarsFragment ();
				break;
			case 3:
				fragment = new ScanFragment ();
				break;
			default:
				fragment = new BrowseFragment ();
				break;
			}
            SupportFragmentManager.BeginTransaction()
				.Replace(Resource.Id.content_frame, fragment)
                .Commit();

			Toast.MakeText (this,
				"You are on " + sections[position] + " section",
				ToastLength.Short).Show ();

            this.m_DrawerList.SetItemChecked(position, true);
			ActionBar.Title = this.m_Title = sections[position];
            this.m_Drawer.CloseDrawer(this.m_DrawerList);
        }

       
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {

            var drawerOpen = this.m_Drawer.IsDrawerOpen(this.m_DrawerList);
            
			for (int i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);


            return base.OnPrepareOptionsMenu(menu);
        }
	}
}

