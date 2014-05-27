using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using RssReader2.Model;

namespace RssReader2
{
	public class Database<T>: SQLite.SQLiteConnection
	{
		static object locker = new object();

		public static string DatabaseFilePath{
			get{
				var sqLiteFileName = "database.db";

				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				string libraryPath = Path.Combine (documentsPath, "Library");

				var path = Path.Combine (documentsPath, sqLiteFileName);

				return path;
			}
		}

		public Database (string path) : base (path)
		{
			// create the tables
			CreateTable<User> ();
			CreateTable<Post> ();
		}

//		public IEnumerable<T> GetAll () 
//		{
//			lock (locker) {
//				return (from i in Table<T> () select i).ToList ();
//			}
//		}
//
//		public T Get (int id)
//		{
//			lock(locker){
//				return Get<T> (id);
////				return Table<User>().FirstOrDefault(x => x.Id == id);
//			}
//		}

		public int Save (T item) 
		{
			lock (locker) {
//				if (item.Id != 0) {
//					Update (item);
//					return item.Id;
//				} else {
					return Insert (item);
//				}
			}
		}

		public int Update (T item){
			lock (locker) {
				return Update (item);
			}
		}
			
		public int Delete(int id) 
		{
			lock (locker) {
				return Delete<T> (id);
			}
		}
	}
}

