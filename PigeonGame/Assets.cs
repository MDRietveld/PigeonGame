using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace PigeonGame
{
	/** 
	 * Assets Load Manager
	 **/

	public static class Assets
	{
		public static Texture2D 	MainScreen, PauseScreen, FontTexture, 
									NestTexture, PigeonTexture, EagleTexture, FoxTexture, GorillaTexture, KangerooTexture, BossTexture,
									Heart, Flag, FoodTexture,
									Level1Intro, Level1Map, Level2Intro, Level2Map, Level3Intro, Level3Map, Level4Intro, Level4Map, Level5Intro, Level5Map;

		public static SoundEffect	Level1Song, Level2Song, Level3Song, Level4Song, Level5Song;
		public static SoundEffectInstance Level1SongInstance, Level2SongInstance, Level3SongInstance, Level4SongInstance, Level5SongInstance;
		private static bool 		_songLoop = true;
		public static bool 			LevelComplete = false;
		public static bool			LevelIntro = false;
		public static TimeSpan 		IntervalNewLevel;

		public static void LoadContent(Game1 game){
			MainScreen 			= game.Content.Load<Texture2D> ("Main");
			PauseScreen 		= game.Content.Load<Texture2D> ("Pause");
			FontTexture 		= game.Content.Load<Texture2D> ("minecrafter_0.png");

			NestTexture 		= game.Content.Load<Texture2D> ("Nest_sprites");
			PigeonTexture 		= game.Content.Load<Texture2D> ("Pigeon_sprites");
			EagleTexture 		= game.Content.Load<Texture2D> ("Eagle_sprites");
			FoxTexture			= game.Content.Load<Texture2D> ("Fox_sprites");
			GorillaTexture		= game.Content.Load<Texture2D> ("Gorilla_sprites");
			KangerooTexture		= game.Content.Load<Texture2D> ("Kangeroo_sprites");
			BossTexture 		= game.Content.Load<Texture2D> ("Boss");

			FoodTexture			= game.Content.Load<Texture2D> ("Food_sprite");
			Heart				= game.Content.Load<Texture2D> ("Hearth");
			Flag 				= game.Content.Load<Texture2D> ("Flag");

			Level1Intro 		= game.Content.Load<Texture2D> ("IntroLevel1");
			Level1Map 			= game.Content.Load<Texture2D> ("level_lowres");
			Level1Song 			= game.Content.Load<SoundEffect>("Song1");
			Level1SongInstance 	= Level1Song.CreateInstance ();
			Level1SongInstance.IsLooped = _songLoop;

			Level2Intro 		= game.Content.Load<Texture2D> ("IntroLevel2");
			Level2Map 			= game.Content.Load<Texture2D> ("level_lowres");
			Level2Song 			= game.Content.Load<SoundEffect>("Song1");
			Level2SongInstance 	= Level2Song.CreateInstance ();
			Level2SongInstance.IsLooped = _songLoop;

			Level3Intro 		= game.Content.Load<Texture2D> ("IntroLevel3");
			Level3Map 			= game.Content.Load<Texture2D> ("Level3_lowres");
			Level3Song 			= game.Content.Load<SoundEffect>("Song2");
			Level3SongInstance 	= Level3Song.CreateInstance ();
			Level3SongInstance.IsLooped = _songLoop;

			Level4Intro 		= game.Content.Load<Texture2D> ("IntroLevel4");
			Level4Map 			= game.Content.Load<Texture2D> ("Level4_lowres");
			Level4Song 			= game.Content.Load<SoundEffect>("Song3");
			Level4SongInstance 	= Level4Song.CreateInstance ();
			Level4SongInstance.IsLooped = _songLoop;

			Level5Intro 		= game.Content.Load<Texture2D> ("IntroLevel5");
			Level5Map 			= game.Content.Load<Texture2D> ("Boss_level");
			Level5Song 			= game.Content.Load<SoundEffect>("Song4");
			Level5SongInstance 	= Level5Song.CreateInstance ();
			Level5SongInstance.IsLooped = _songLoop;
		}
	}
}

