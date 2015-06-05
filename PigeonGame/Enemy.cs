
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	class Enemy : GameObjects
	{
		private int _speed;

		public Enemy (Game1 g, World w, Texture2D texture, Vector2 position, int speed) : base (g, w, texture, position)
		{
			_speed = speed;
		}
		public void Update ()
		{
			_position.X += _speed;
			if (_position.X + _texture.Width > 300 || _position.X < 0) 
			{
				_speed *= -1;
			}
		}

	}
}
