using System;
using Android.Widget;
using ZXing.Mobile;
using System.Collections.Generic;
using ZXing;

namespace RssReader2
{
	public class ScanFragment: MyFragment
	{
		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.scanner_view, null);
//			var buttonCancel = view.FindViewById<Button> (Resource.Id.button_scan_cancel);
//			var buttonTorch = view.FindViewById<Button> (Resource.Id.button_scan_torch);
			var buttonStartScan = view.FindViewById<Button> (Resource.Id.button_start_scan);

			var scanner = new MobileBarcodeScanner (Activity);

			var options = new MobileBarcodeScanningOptions () {
				PossibleFormats = new List<BarcodeFormat> () { BarcodeFormat.QR_CODE }
			};
//
//			scanner.UseCustomOverlay = true;
//			scanner.CustomOverlay = view;
			scanner.TopText = "Hold the Code close to the camera";
			scanner.BottomText = "The code will be scanned automatically";

			buttonStartScan.Click += (sender, e) => {
				scanner.Scan (options).ContinueWith ((t) => {

					string msg = (t.Result != null) ? "Scanned: " + t.Result.Text : "Not Barcode or QRCode Scanned";
					ShowMessage(msg);

				});
			};

			return view;
		}

		private void ShowMessage(string msg){
			Toast.MakeText (Activity.ApplicationContext,
				msg,
				ToastLength.Short).Show ();
		}
	}
}

