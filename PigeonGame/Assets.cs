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
									Heart, Flag,
									Level1Intro, Level1Map, Level2Intro, Level2Map, Level3Intro, Level3Map, Level4Intro, Level4Map, Level5Intro, Level5Map;

		public static SoundEffect	Level1Song, Level2Song, Level3Song, Level4Song, Level5Song;

		public static void LoadContent(Game1 game){
			MainScreen 		= game.Content.Load<Texture2D> ("Main");
			PauseScreen 	= game.Content.Load<Texture2D> ("Pause");
			FontTexture 	= game.Content.Load<Texture2D> ("minecrafter_0.png");

			NestTexture 	= game.Content.Load<Texture2D> ("Nest_sprites");
			PigeonTexture 	= game.Content.Load<Texture2D> ("Pigeon_sprites");
			EagleTexture 	= game.Content.Load<Texture2D> ("Eagle_sprites");
			FoxTexture		= game.Content.Load<Texture2D> ("Fox_sprites");
			GorillaTexture	= game.Content.Load<Texture2D> ("Gorilla_sprites");
			KangerooTexture	= game.Content.Load<Texture2D> ("Kangeroo_sprites");
			BossTexture 	= game.Content.Load<Texture2D> ("Boss");

			Heart			= game.Content.Load<Texture2D> ("Hearth");
			Flag 			= game.Content.Load<Texture2D> ("Flag");

			Level1Intro 	= game.Content.Load<Texture2D> ("IntroLevel1");
			Level1Map 		= game.Content.Load<Texture2D> ("level_lowres");
			Level1Song 		= game.Content.Load<SoundEffect>("Song1");

			Level2Intro 	= game.Content.Load<Texture2D> ("IntroLevel2");
			Level2Map 		= game.Content.Load<Texture2D> ("level_lowres");
			Level2Song 		= game.Content.Load<SoundEffect>("Song1");

			Level3Intro 	= game.Content.Load<Texture2D> ("IntroLevel3");
			Level3Map 		= game.Content.Load<Texture2D> ("Level3_lowres");
			Level3Song 		= game.Content.Load<SoundEffect>("Song2");

			Level4Intro 	= game.Content.Load<Texture2D> ("IntroLevel4");
			Level4Map 		= game.Content.Load<Texture2D> ("Level4_lowres");
			Level4Song 		= game.Content.Load<SoundEffect>("Song3");

			Level5Intro 	= game.Content.Load<Texture2D> ("IntroLevel5");
			Level5Map 		= game.Content.Load<Texture2D> ("Boss_level");
			Level5Song 		= game.Content.Load<SoundEffect>("Song4");
		}
	}
}

