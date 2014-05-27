package rssreader2.model;


public class Post
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"";
		mono.android.Runtime.register ("RssReader2.Model.Post, RssReader2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Post.class, __md_methods);
	}


	public Post () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Post.class)
			mono.android.TypeManager.Activate ("RssReader2.Model.Post, RssReader2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();

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
