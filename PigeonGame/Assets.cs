using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace PigeonGame
{
	public static class Assets
	{
		public static Texture2D 	EagleTexture;
		public static Texture2D 	Level1Intro;
		public static SoundEffect	Level1Song;

		public static void LoadContent(Game1 game){
			EagleTexture = game.Content.Load<Texture2D> ("Eagle_sprites");
			Level1Intro = game.Content.Load<Texture2D> ("IntroLevel1");
			Level1Song = game.Content.Load<SoundEffect>("Song1");
		}
	}
}

