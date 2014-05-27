using System;

namespace RssReader2.Model
{
	public class Post : Java.Lang.Object
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string PubDate { get; set; }
		public string Image { get; set; }
		public string Link { get; set; }

		public Post ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("Title={0} \nContent={1} \nPubDate={2} \nImage={3} \nLink={4}", Title, Content, PubDate, Image, Link);
		}
	}
}

