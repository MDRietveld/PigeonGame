using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PigeonGame
{
	public class Worm : GameObjects
	{
		public Worm (Game1 g, World w, Texture2D tex, Vector2 pos) :base (g, w, tex, pos)
		{
		}

		public Rectangle PigeonPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/12, _texture.Height/5/4);
		}


	}
}

