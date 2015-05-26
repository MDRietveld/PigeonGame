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
		Game1 _g;



		public World (Game1 g)
		{
			_pidgyTexture = g.Content.Load<Texture2D> ("Untitled");
			_pidgyPosition = new Vector2 (30, g.GraphicsDevice.Viewport.Height - _pidgyTexture.Height - 30);

			_pidgy = new Pidgy (g, _pidgyTexture, _pidgyPosition);
		}

		public void Update ()
		{
			_pidgy.Update ();	
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			_pidgy.Draw (spriteBatch);

		}
	}
}

