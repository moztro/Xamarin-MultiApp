using System;
using Android.OS;
using System.Collections.Generic;
using RssReader2.Model;
using Java.Net;
using RssReader2.Enums;
using Android.Util;
using System.Xml;
using Org.XmlPull.V1;
using Android.App;

namespace RssReader2
{
	public class GetRssData : AsyncTask<string, int, List<Post>>
	{
		private Tag currentTag;

		protected override List<Post> RunInBackground (params string[] @params)
		{
			if (IsCancelled)
				return null;

			string rss = @params [0];
			System.IO.Stream inputStream = null;
			List<Post> items = new List<Post> ();
			try{
				URL url = new URL(rss);
				HttpURLConnection conn = (HttpURLConnection)url.OpenConnection();
				conn.ReadTimeout = 10000;
				conn.ConnectTimeout = 15000;
				conn.RequestMethod = "GET";
				conn.DoInput = true;
				conn.Connect();
				Log.Info("RESPONSE", "The response is " + conn.ResponseCode);
				inputStream = conn.InputStream;

				XmlReader xml = XmlReader.Create(inputStream);
				Post post = null;

				while(xml.Read()){
					if(xml.IsStartElement()){
						if(xml.Name.Equals("title")){
							currentTag = RssReader2.Enums.Tag.TITLE;
						}else if(xml.Name.Equals("description")){
							currentTag = RssReader2.Enums.Tag.CONTENT;
						}else if(xml.Name.Equals("pubDate")){
							currentTag = RssReader2.Enums.Tag.PUB_DATE;
						}else if(xml.Name.Equals("image")){
							currentTag = RssReader2.Enums.Tag.IMAGE;
						}else if(xml.Name.Equals("link")){
							currentTag = RssReader2.Enums.Tag.LINK;
						}else{
							post = new Post();
							currentTag = RssReader2.Enums.Tag.IGNORE_TAG;
						}
					}else if(!xml.IsStartElement()){
						if(xml.Name.Equals("item"))
							items.Add(post);
						}
					if(xml.Value != null){
						string content = xml.Value;
						if(post != null){
							switch(currentTag){
							case RssReader2.Enums.Tag.TITLE:
								if(content.Length != 0){
									if(post.Title != null){
										post.Title += content;
									}else{
										post.Title = content;
									}
								}
								break;
							case RssReader2.Enums.Tag.CONTENT:
								if(content.Length != 0){
									if(post.Content != null){
										post.Content += content;
									}else{
										post.Content = content;
									}
								}
								break;
							case RssReader2.Enums.Tag.IMAGE:
								if(content.Length != 0){
									if(post.Image != null){
										post.Image += content;
									}else{
										post.Image = content;
									}
								}
								break;
							case RssReader2.Enums.Tag.LINK:
								if(content.Length != 0){
									if(post.Link != null){
										post.Link += content;
									}else{
										post.Link = content;
									}
								}
								break;
							case RssReader2.Enums.Tag.PUB_DATE:
								if(content.Length != 0){
									if(post.PubDate != null){
										post.PubDate += content;
									}else{
										post.PubDate = content;
									}
								}
								break;
							default:
								break;
							}
						}
					}
				}
				Log.Info("ITEMS IN VIEW", items.Count.ToString());
			}catch(MalformedURLException urlEx){
				Log.Error ("ERROR", urlEx.StackTrace);
			}catch(SocketException ioEx){
				Log.Error ("ERROR", ioEx.StackTrace);
			}catch(XmlPullParserException xppEx){
				Log.Error ("ERROR", xppEx.StackTrace);
			}
			return items;
		}

	}
}


