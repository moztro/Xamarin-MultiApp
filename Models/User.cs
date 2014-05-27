using System;
using RssReader2.SQLite;
using System.Collections.Generic;

namespace RssReader2
{
	public class User
	{
		[PrimaryKey][AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
//		public ICollection<Car> CarCollection { get; set; }

		public User ()
		{
		}

		public User(string _UserName, string _Password){
			this.UserName = _UserName;
			this.Password = _Password;
		}

		public override string ToString ()
		{
			return string.Format ("[User: Id={0}, Name={1}, UserName={2}, Password={3}]", Id, Name, UserName, Password);
		}
	}
}

