using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Util;

namespace RssReader2
{
	public class GenericAdapter<T>: ArrayAdapter<T>
	{
		private Activity mContext;
		private List<T> mObjects;
		private List<int> mResources;
		private int mLayout;

		public GenericAdapter (Activity context, List<T> objects, int layout, List<int> widgets)
			:base(context, layout, objects)
		{
			mContext = context;
			mObjects = objects;
			mResources = widgets;
			mLayout = layout;
		}

		private class ViewHolder: Java.Lang.Object{
			public List<View> widgets;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			ViewHolder viewHolder;

			if (convertView == null) {
				LayoutInflater inflater = mContext.LayoutInflater;
				convertView = inflater.Inflate (mLayout, null);

				viewHolder = new ViewHolder ();
				for (int i = 0, j = mResources.Count; i < j; i++) {
					viewHolder.widgets [i] = convertView.FindViewById<View> (mResources [i]);
				}
				convertView.Tag = viewHolder;
			} else {
				viewHolder = (ViewHolder)convertView.Tag;
			}

			T t = mObjects [position];
			if (t != null) {
				int i = 0;
				foreach (Attribute attr in t.GetType().GetEnumValues()) {
					Log.Debug ("ATTRIBUTES", attr.ToString ());
				}
			}

			return convertView;
		}
	}
}

