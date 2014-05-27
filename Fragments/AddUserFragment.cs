using System;
using Android.Widget;
using Android.Views;

namespace RssReader2
{
	public class AddUserFragment: Android.Support.V4.App.Fragment
	{
		private EditText userNameField, passwordField;
		private Button createAccountButton;

		public AddUserFragment ()
		{
			this.RetainInstance = true;
			this.HasOptionsMenu = true;
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.fragment_users_register, null);

			Init (view);

			string user = userNameField.Text;
			string pass = passwordField.Text;

			createAccountButton.Click += (sender, e) => {

				int id = UserRepository.Save(new User(user, pass));
				if(id>0){
					ShowMessage("Success Save with Id="+id);
				}else{
					ShowMessage("Unable to save following data [User: "+user+", Pass: "+pass+"]");
				}
			};

			return view;
		}

		private void ShowMessage(string msg){
			Toast.MakeText (Activity.ApplicationContext,
				msg,
				ToastLength.Short).Show ();
		}

		private void Init(View view){
			this.userNameField = view.FindViewById<EditText> (Resource.Id.user_field);
			this.passwordField = view.FindViewById<EditText> (Resource.Id.password_field);
			this.createAccountButton = view.FindViewById<Button> (Resource.Id.button_create_account);
		}
	}
}

