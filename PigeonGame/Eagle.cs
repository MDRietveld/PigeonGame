using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PigeonGame
{
	public class Eagle : Enemy
	{
		private int _speed;
		float _elapsed;
		float _delay = 100;
		int _frames;
		int _frames2;
		int _rij;

		Rectangle _eagle;

		public Eagle (Game1 g, World w, Texture2D texture, Vector2 position, int speed, float scale) : base (g, w, texture, position, speed, scale)
		{
			_speed = speed;

			int size = _texture.Width/8;
			_rij = 1;
			_sourceRectangle = new Rectangle (size *_frames, size* _rij, size, size);
		}

		public Rectangle EaglePosition()
		{
			return _eagle = new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/8, _texture.Height/5/2);
		}

		public override void Update (GameTime gameTime)
		{
			int size = _texture.Width/8;
			/*
			if(pidgy.PigeonPosition().Intersects(EaglePosition()))
			{
				Console.WriteLine ("Collission!");
			}
			*/

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
			_sourceRectangle = new Rectangle (size *_frames, size* _rij, size, size);
				
			_position.X += _speed;
			//if (_position.X  > 300) 
			//{
			//_speed *= -1;
			// rij= 1;
			//}else if (_position.x <0 )
			//{
			//_speed*= -1;
			//rij =0;
			//}

			//Check om de direction te bepalen
			if (_speed < 0) {
				Console.WriteLine("speed is -1");
			}
		}
	}
}

