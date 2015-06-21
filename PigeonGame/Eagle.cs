using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PigeonGame
{
	/*
	public class Eagle : Enemy
	{
		private Game1 _game;
		private int _speed;
		float _elapsed;
		float _delay = 100;
		int _frames, _rij, size_hor, size_ver, _kolom, _scaleX, _scaleY;
		float _time = 0;

		//Rectangle _eagle;

		public Eagle (Game1 g, World w, Texture2D texture, Vector2 position, int speed, float scale, int scale_x, int scale_y) : base (g, w, texture, position, speed, scale)
		{
			_game = g;
			_speed = speed;

			_scaleX = scale_x;
			_scaleY = scale_y;
			size_hor = _texture.Width / _scaleX;
			size_ver = _texture.Height / _scaleY;
			_rij = 1;
			_kolom = 0;

			_sourceRectangle = new Rectangle (size_hor * _kolom, size_ver* _rij, size_hor, size_ver);

		}

		//  wordt gebruikt voor collision detection
		/*
		public override Rectangle Bounds {
			get { 
				return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/8, _texture.Height/5/2);
			}
		}
		*/
		/*
		public Rectangle EaglePosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/_scaleX, _texture.Height/5/_scaleY);
		}

		public override void Update (GameTime gameTime, Pidgy pidgy)
		{
			if(pidgy.PigeonPosition().Intersects(EaglePosition()))
			{
				_game.paused = true;
				Console.WriteLine ("Collission!");
			}
				
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
				/*
				_speed*= -1;
				_rij =1;
				*/
			/*
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
*/
	
}

