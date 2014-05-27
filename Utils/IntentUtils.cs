using System;
using Android.Content;

namespace RssReader2
{
	public abstract class IntentUtils
	{
		public static Intent CreateShareIntent(string shareContentType, string shareContent){
			Intent shareIntent = new Intent();
			shareIntent.SetAction(Intent.ActionSend);
			shareIntent.PutExtra(Intent.ExtraText, shareContent);
			shareIntent.SetType (shareContentType);
			return shareIntent;
		}
	}
}

