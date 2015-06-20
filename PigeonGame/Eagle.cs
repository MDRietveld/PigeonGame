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
		//int _frames2;
		int _rij;
		int size_hor;
		int size_ver;
		int _kolom;

		float _time = 0;

		//Rectangle _eagle;

		public Eagle (Game1 g, World w, Texture2D texture, Vector2 position, int speed, float scale) : base (g, w, texture, position, speed, scale)
		{
			_speed = speed;



			size_hor = _texture.Width/8;
			size_ver = _texture.Height / 2;
			_rij = 1;
			_kolom = 0;

			_sourceRectangle = new Rectangle (size_hor * _kolom, size_ver* _rij, size_hor, size_ver);

		}

		//  wordt gebruikt voor collision detection
		public override Rectangle Bounds {
			get { 
				return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/8, _texture.Height/5/2);
			}
		}

		public override void Update (GameTime gameTime)
		{
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
			_sourceRectangle = new Rectangle (size_hor *_frames, size_ver* _rij, size_hor, size_ver);


			_position.X += _speed;

			_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (_time >= 3000) 
			{
				_speed *= -1;
				_time = 0;

				if (_rij == 1) {
					_rij = 0;
				} else {
					_rij = 1;
				}
			}
		}
	}
}

