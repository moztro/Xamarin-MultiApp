using System;
using System.Collections.Generic;

namespace RssReader2
{
	public class UserRepository
	{
		Database<User> db = null;
		protected static UserRepository me;

		static UserRepository ()
		{
			me = new UserRepository ();
		}

		protected UserRepository()
		{
			db = new Database<User> (Database<User>.DatabaseFilePath);
		}

		public static int Save(User item)
		{
			if (item.Id != 0)
				return me.db.Update (item);
			return me.db.Insert (item);
		}

		public static int Delete(int id)
		{
			return me.db.Delete (id);
		}
//
//		public static User Get(int id)
//		{
//			return me.db.Get(id);
//		}
//
//		public static IEnumerable<User> GetAll()
//		{
//			return me.db.GetAll();
//		}
	}
}

