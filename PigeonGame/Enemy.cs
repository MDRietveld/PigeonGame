
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	public class Enemy : GameObjects
	{
		private int _speed;

		public Enemy (Game1 g, World w, Texture2D texture, Vector2 position, int speed, float scale) : base (g, w, texture, position, scale)
		{
			_speed = speed;
		}
			
		public virtual void Update (GameTime gameTime, Pidgy pidgy)
		{
			_position.X += _speed;
			//if (_position.X  > 300 || _position.X < 0) 
			//{
				//_speed *= -1;
			//}

			//Check om de direction te bepalen
			if (_speed < 0) {
				Console.WriteLine("speed is -1");
			}
		}
	}
}
