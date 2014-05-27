using System;
using Android.Widget;
using RssReader2.Model;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using RssReader2;

namespace RssReader2
{
	public class PostAdapter : ArrayAdapter<Post>
	{
		private Activity mActivity;
		private List<Post> mObjects;

		public PostAdapter (Activity activity, int resourceLayout, List<Post> objects)
			: base (activity.ApplicationContext, resourceLayout, objects)
		{
			mActivity = activity;
			mObjects = objects;
		}

		private class ViewHolder: Java.Lang.Object
		{
			public TextView vTitle/*, vPubDate*/;
			//public ImageView vImage;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			ViewHolder viewHolder;

			if (convertView == null) {
				LayoutInflater inflater = mActivity.LayoutInflater;
				convertView = inflater.Inflate (Resource.Layout.item, null);

				viewHolder = new ViewHolder ();
				viewHolder.vTitle = convertView.FindViewById<TextView> (Resource.Id.Title);
//				viewHolder.vPubDate = convertView.FindViewById<TextView> (Resource.Id.PubDate);
//				viewHolder.vImage = convertView.FindViewById<ImageView> (Resource.Id.Image);

				convertView.Tag = viewHolder;
			} else {
				viewHolder = (ViewHolder)convertView.Tag;
			}

			Post post = mObjects [position];
			if (post != null) {
				viewHolder.vTitle.Text = post.Title;
//				viewHolder.vPubDate.Text = post.PubDate;
//				viewHolder.vImage.SetBackgroundResource (Resource.Drawable.news);
			}

			return convertView;
		}
	}
}

