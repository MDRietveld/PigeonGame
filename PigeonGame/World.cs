using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using BmFont;

namespace PigeonGame
{
	public class World
	{
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
			_bgTexture = g.Content.Load<Texture2D> ("Main");
			_background = new Background(g, this, _bgTexture);

			_gameh = g.GraphicsDevice.Viewport.Height;
			_texh = _bgTexture.Height;



			_pidgyTexture = g.Content.Load<Texture2D> ("Untitled");
			_pidgyPosition = new Vector2 (30, g.GraphicsDevice.Viewport.Height - _pidgyTexture.Height - PidgyHeight());

			_pidgy = new Pidgy (g, this, _pidgyTexture, _pidgyPosition);

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
			return _pidgyHeight = 77/ Scaling ();
		}

		public float Scaling()
		{
			return _scale = _texh / _gameh;
		}
			

		public void Update ()
		{
			_pidgy.Update ();
			_background.Update ();
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			_background.Draw (spriteBatch);
			_fontRenderer.DrawText(spriteBatch, 50, 50, "Druk op spatie om te starten");
			_pidgy.Draw (spriteBatch);

		}
	}
}

