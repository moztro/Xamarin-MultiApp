package rssreader2;


public class MyFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateOptionsMenu:(Landroid/view/Menu;Landroid/view/MenuInflater;)V:GetOnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler\n" +
			"";
		mono.android.Runtime.register ("RssReader2.MyFragment, RssReader2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyFragment.class, __md_methods);
	}


	public MyFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyFragment.class)
			mono.android.TypeManager.Activate ("RssReader2.MyFragment, RssReader2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreateOptionsMenu (android.view.Menu p0, android.view.MenuInflater p1)
	{
		n_onCreateOptionsMenu (p0, p1);
	}

	private native void n_onCreateOptionsMenu (android.view.Menu p0, android.view.MenuInflater p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
