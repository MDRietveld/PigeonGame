
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	public class Enemy : GameObjects
	{
		private int _speed;
		float _elapsed;
		float _delay = 100;
		int _frames;
		int _frames2;
		int _rij;

		Rectangle _eagle;


		public Enemy (Game1 g, World w, Texture2D texture, Vector2 position, int speed, float scale) : base (g, w, texture, position, scale)
		{
			_speed = speed;

			int size = _texture.Width/8;
			_rij = 1;
			_sourceRectangle = new Rectangle (size *0, size* _rij, size, size);
		}

		public Rectangle EaglePosition()
		{
			return _eagle = new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/8, _texture.Height/5/2);
		}

		public void Update (GameTime gameTime)
		{



			_elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (_elapsed >= _delay) 
			{
				if (_frames >= 7) {
					_frames = 0;
				} else {
					_frames++;
				}
				_elapsed = 0;

			}

			if (_elapsed >= _delay) 
			{
				if (_frames2 >= 3) {
					_frames2 = 0;
				} else {
					_frames2++;
				}
				_elapsed = 0;
				_rij = 1;

			}
			_position.X += _speed;
			//if (_position.X  > 300 || _position.X < 0) 
			//{
				//_speed *= -1;
			//}
		}

	}
}
