package rssreader2;


public class GenericAdapter_1_ViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RssReader2.GenericAdapter`1/ViewHolder, RssReader2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GenericAdapter_1_ViewHolder.class, __md_methods);
	}


	public GenericAdapter_1_ViewHolder () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GenericAdapter_1_ViewHolder.class)
			mono.android.TypeManager.Activate ("RssReader2.GenericAdapter`1/ViewHolder, RssReader2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
