using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using BmFont;

namespace PigeonGame
{
	public class World
	{
		private Enemy _enemy;
		private Enemy _enemy2;
		private Enemy _enemy3;
		Texture2D _enemyTex;

		Pidgy _pidgy;
		Vector2 _pidgyPosition;
		Background _background;
		Texture2D _pidgyTexture;
		Texture2D _bgTexture;
		float _scale;
		float _gameh;
		float _texh;
		float _pidgyHeight;
		FontRenderer _fontRenderer;


		public World (Game1 g)
		{
			_enemyTex = g.Content.Load<Texture2D> ("enemy");
			_enemy = new Enemy (g, this, _enemyTex, new Vector2 (100, 70), 3);
			_enemy2 = new Enemy (g, this, _enemyTex, new Vector2 (50, 20), 4);
			_enemy3 = new Enemy (g, this, _enemyTex, new Vector2 (200, 150), 5);

			_bgTexture = g.Content.Load<Texture2D> ("level_old");
			_background = new Background(g, this, _bgTexture, new Vector2(0, 0));

			_gameh = g.GraphicsDevice.Viewport.Height;
			_texh = _bgTexture.Height;



			_pidgyTexture = g.Content.Load<Texture2D> ("Untitled");
			_pidgyPosition = new Vector2 (g.GraphicsDevice.Viewport.Width/8, g.GraphicsDevice.Viewport.Height - _pidgyTexture.Height - PidgyHeight());

			_pidgy = new Pidgy (g, this, _pidgyTexture, _pidgyPosition);

			/*
			 * GENERATE FONT FROM FNT & _0.PNG FILE
			 * 
			 */
			var fontFilePath = Path.Combine(g.Content.RootDirectory, "minecrafter.fnt");
			var fontFile = FontLoader.Load(fontFilePath);
			var fontTexture = g.Content.Load<Texture2D>("minecrafter_0.png");
			_fontRenderer = new FontRenderer(fontFile, fontTexture);

			Console.WriteLine (_gameh);
			Console.WriteLine (_texh);
			Console.WriteLine (_scale = _texh/ _gameh);
			Console.WriteLine (Scaling());
			Console.WriteLine (PidgyHeight());
		}
	
		public Vector2 GetPidgyPosition()
		{
			return _pidgy.GetPosition ();
		}

		public float PidgyHeight ()
		{
			return _pidgyHeight = 77* Scaling ();
		}

		public float Scaling()
		{
			return _scale = _gameh / _texh;
		}
			

		public void Update ()
		{
			_pidgy.Update ();
			_background.Update ();

			_enemy.Update ();
			_enemy2.Update ();
			_enemy3.Update ();
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			// BACKGROUND DRAW
			_background.Draw (spriteBatch);

			// DRAW TEXT
			_fontRenderer.DrawText(spriteBatch, 50, 50, "Druk op spatie om te starten");

			// PIGEON DRAW
			_pidgy.Draw (spriteBatch);

			_enemy.Draw (spriteBatch);
			_enemy2.Draw (spriteBatch);
			_enemy3.Draw (spriteBatch);

		}
	}
}

