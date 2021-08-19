namespace FestivalManager
{	
	using Entities;
	using System;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			//example usage of the Stage class
			var song1 = new Song("Winds", new TimeSpan(0,3,30));
			var song2 = new Song("Nights", new TimeSpan(0, 2, 30));

			var performer = new Performer("Ivan", "Ivanov", 19);
			Stage stage = new Stage();

			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddPerformer(performer);

            Console.WriteLine(stage.AddSongToPerformer("Winds", "Ivan Ivanov"));

            Console.WriteLine(stage.Play());
		}
	}
}