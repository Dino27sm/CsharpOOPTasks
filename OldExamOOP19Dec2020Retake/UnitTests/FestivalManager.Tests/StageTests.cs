// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Create_Song_Obj()
	    {
			var song1 = new Song("Winds", new TimeSpan(0, 3, 30));
			var duration = new TimeSpan(0, 3, 30);
			string printOut = $"{song1.Name} ({duration:mm\\:ss})";

			Assert.AreEqual("Winds", song1.Name);
			Assert.AreEqual(duration, song1.Duration);
			Assert.AreEqual(printOut, song1.ToString());
		}

		[Test]
		public void Create_Performer_Obj()
		{
			var song1 = new Song("Winds", new TimeSpan(0, 3, 30));
			var performer = new Performer("Ivan", "Ivanov", 19);

			Assert.AreEqual("Ivan Ivanov", performer.FullName);
			Assert.AreEqual(19, performer.Age);
			Assert.AreEqual(0, performer.SongList.Count);
			Assert.AreEqual("Ivan Ivanov", performer.ToString());
		}

		[Test]
		public void Create_Stage_Obj()
		{
			Stage stage = new Stage();

			Assert.AreEqual(0, stage.Performers.Count);
		}

		[Test]
		public void AddPerformer_Stage_EX()
		{
			var performer = new Performer("Ivan", "Ivanov", 17);
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}

		[Test]
		public void AddPerformer_Stage_OK()
		{
			var performer = new Performer("Ivan", "Ivanov", 18);
			Stage stage = new Stage();

			stage.AddPerformer(performer);

			Assert.AreEqual(1, stage.Performers.Count);
		}

		[Test]
		public void AddSong_Stage_EX()
		{
			var song1 = new Song("Winds", new TimeSpan(0, 0, 30));
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() => stage.AddSong(song1));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void AddSongToPerformer_Stage_EX()
		{
			var song1 = new Song("Winds", new TimeSpan(0, 1, 30));
			var performer = new Performer("Ivan", "Ivanov", 18);
			Stage stage = new Stage();

			stage.AddSong(song1);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, performer.FullName));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(song1.Name, null));

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("ErrorName", performer.FullName));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song1.Name, "ErrorName"));
		}

		[Test]
		public void AddSongToPerformer_Stage_OK()
		{
			var song1 = new Song("Winds", new TimeSpan(0, 1, 30));
			var performer = new Performer("Ivan", "Ivanov", 18);
			Stage stage = new Stage();

			stage.AddSong(song1);
			stage.AddPerformer(performer);

			Assert.AreEqual($"{song1} will be performed by {performer}", stage.AddSongToPerformer(song1.Name, performer.FullName));
			Assert.AreEqual(1, performer.SongList.Count);
		}

		[Test]
		public void Play_Stage_OK()
		{
			var song1 = new Song("Winds1", new TimeSpan(0, 1, 30));
			var song2 = new Song("Winds2", new TimeSpan(0, 2, 30));
			var song3 = new Song("Winds3", new TimeSpan(0, 3, 30));
			var performer1 = new Performer("Ivan", "Ivanov", 18);
			var performer2 = new Performer("Petar", "Petrov", 20);
			Stage stage = new Stage();

			stage.AddPerformer(performer1);
			stage.AddPerformer(performer2);
			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddSongToPerformer("Winds1", performer1.FullName);
			stage.AddSongToPerformer("Winds2", performer1.FullName);
			stage.AddSongToPerformer("Winds3", performer2.FullName);

			Assert.AreEqual("2 performers played 3 songs", stage.Play());
		}
	}
}