using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PigeonGame
{
	public class World
	{
		Pidgy _pidgy;
		Texture2D _pidgyTexture;
		Vector2 _pidgyPosition ;
//		Game1 _g;
		Background _background;
		Texture2D _bgTexture;
		private float _scale;
		private float _gameh;
		private float _texh;
		float _pidgyHeight;


		public World (Game1 g)
		{
			_bgTexture = g.Content.Load<Texture2D> ("w");
//			_bgTexture.Height = g.GraphicsDevice.Viewport.Height;
			_background = new Background(g, _bgTexture);

			_gameh = g.GraphicsDevice.Viewport.Height;
			_texh = _bgTexture.Height;



			_pidgyTexture = g.Content.Load<Texture2D> ("Untitled");
			_pidgyPosition = new Vector2 (30, g.GraphicsDevice.Viewport.Height - _pidgyTexture.Height - PidgyHeight());

			_pidgy = new Pidgy (g, this, _pidgyTexture, _pidgyPosition);



			Console.WriteLine (_gameh);
			Console.WriteLine (_texh);
			Console.WriteLine (_scale = _texh/ _gameh);
			Console.WriteLine (Scaling());
			Console.WriteLine (PidgyHeight());

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

			_pidgy.Draw (spriteBatch);

		}
	}
}

