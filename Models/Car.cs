using System;
using Android.Widget;
using System.Collections.Generic;
using RssReader2.SQLite;

namespace RssReader2
{
	public class Car
	{
		[PrimaryKey][AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public int ImageResource { get; set; }
		public string[] Tags { get; set; }

		public Car ()
		{
		}

		public Car(string _Name, int _ImageResource, string[] _Tags){
			this.Name = _Name;
			this.ImageResource = _ImageResource;
			this.Tags = _Tags;
		}

		public override string ToString ()
		{
			return string.Format ("[Car: Id={0}, Name={1}, ImageResource={2}, Tags={3}]", Id, Name, ImageResource, Tags);
		}

		public static List<Car> GenerateData(){
			List<Car> cars = new List<Car> ();

			cars.Add (new Car (
				"TV Series BatMobile",
				Resource.Drawable.tv_series_batmobile,
				new string[]{"bat","batman","batmobile","tv","series","classic"}));

			cars.Add (new Car (
				"School Bus",
				Resource.Drawable.school_bus,
				new string[] {"school","bus","student"}));

			cars.Add (new Car (
				"FlintMobile",
				Resource.Drawable.flintmobile,
				new string[] {"flinstones","flintmobile","tv","series","cartoon"}));

			cars.Add (new Car (
				"Angry Birds Minion",
				Resource.Drawable.angry_birds_minion,
				new string[] {"angry","birds","minion","games","rovio","bad", "piggies"}));

			cars.Add (new Car (
				"Red Bird",
				Resource.Drawable.red_bird,
				new string[] {"red","bird","angry","birds","games","rovio"}));

			cars.Add (new Car (
				"Bat Mobile",
				Resource.Drawable.bat_mobile,
				new string[] {"batman","tv","series","bat"}));

			cars.Add (new Car (
				"Bat Pod",
				Resource.Drawable.bat_pod,
				new string[] {"batman","movies","bat","pod"}));

			cars.Add (new Car (
				"Island Chopper",
				Resource.Drawable.island_chopper,
				new string[] {"island","chopper","aero","air","helicopter"}));

			cars.Add (new Car (
				"Sharkruiser",
				Resource.Drawable.sharkruiser,
				new string[] {"sharkruiser","fish","animals","aquatic"}));

			return cars;
		}
	}
}

