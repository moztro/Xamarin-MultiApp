using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using Android.Views;

namespace RssReader2
{
	public class CarAdapter: ArrayAdapter<Car>
	{
		private Activity mContext;
		private List<Car> mObjects;

		public CarAdapter (Activity activity, int resourceLayout, List<Car> objects)
			:base(activity.ApplicationContext, resourceLayout, objects)
		{
			mContext = activity;
			mObjects = objects;
		}

		public class ViewHolder: Java.Lang.Object
		{
			public TextView vName;
			public ImageView vImage;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			ViewHolder viewHolder;

			if (convertView == null) {
				LayoutInflater inflater = mContext.LayoutInflater;
				convertView = inflater.Inflate (Resource.Layout.car_item, null);

				viewHolder = new ViewHolder ();
				viewHolder.vName = convertView.FindViewById<TextView> (Resource.Id.Name);
				viewHolder.vImage = convertView.FindViewById<ImageView> (Resource.Id.Image);
				convertView.Tag = viewHolder;
			} else {
				viewHolder = (ViewHolder)convertView.Tag;
			}

			Car car = mObjects [position];
			if (car != null) {
				viewHolder.vName.Text = car.Name;
				viewHolder.vImage.SetBackgroundResource(car.ImageResource);
			}

			return convertView;
		}
	}
}

