using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Pidgy : GameObjects
	{
		// FIELDS
		Vector2 _gravity;
		Vector2 _fly;
		KeyboardState _keyboard;

		float _elapsed;
		float _delay = 100;
		int _frames;
		int _frames2;
		int _rij;

		float _cooldowntime = 0;
		float _flying = 0;
		float _regen = 0;
		bool _flyup = true;

		// PROPERTIES
		public Vector2 GetPosition ()
		{
			return _position;
		}

		public Pidgy (Game1 g, World w, Texture2D texture, Vector2 position, float scale) : base (g, w, texture, position, scale)
		{

			_fly = new Vector2 (0, 1.5f);
			_gravity = new Vector2 (0, 2);
			_scale = 0.2f;


			int size = _texture.Width/12;
			_rij = 2;
			_sourceRectangle = new Rectangle (size *0, size* _rij, size, size);

		}

		public Rectangle PigeonPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/12, _texture.Height/5/4);
		}
			

		public void Update (GameTime gameTime)
		{

			
			int size = _texture.Width/12;

			_elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (_elapsed >= _delay) 
			{
				if (_frames >= 11) {
					_frames = 0;
				} else {
					_frames++;
				}
				_elapsed = 0;

			}

//			if (_elapsed >= _delay) 
//			{
//				if (_frames2 >= 3) {
//					_frames2 = 0;
//				} else {
//					_frames2++;
//				}
//				_elapsed = 0;
//				_rij = 3;
//
//			}
//			Console.WriteLine ("ben ik " + _scale);
			_keyboard = Keyboard.GetState ();


			_position += _gravity;


			if (_position.Y > 500)
			{
				_position.Y = 500;
			}

			_regen += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
//			_cooldowntime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
//			if (_cooldowntime >= 3000f) 
//			{
//				_flyup = true;
//			}

//			if (_flying += (float) gameTime.ElapsedGameTime.TotalMilliseconds)
			Console.WriteLine (_flying);

			if (_regen >= 300 && _flying >= 0) 
			{
				_flying -= 100;
				_regen = 0;

			}
			if (_flying >= 2000f) {
				_flyup = false;
			} else {
				_flyup = true;
			}

			if (_keyboard.IsKeyDown (Keys.Up) && _flyup) {
				_flying += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
				_fly.Y *= 1.05f;
				if (_fly.Y > 6) 
				{
					_fly.Y = 6;
				}
				_position.Y -= _fly.Y;
				_sourceRectangle = new Rectangle (size * _frames, size* _rij, size, size);


				if (_flying <= 0) 
				{
					_flying = 0;
				}


			} else {
				_fly = new Vector2 (0, 1.5f);
			}
				


			if (_keyboard.IsKeyDown (Keys.Right))
			{
				_sourceRectangle = new Rectangle (size * _frames, size * _rij, size, size);

				//_position += new Vector2 (3, 0);
				_position += new Vector2 (20, 0);

				if (_position.Y > 499) {
					_rij = 2;

				} else {
					_rij = 0;
					//					_sourceRectangle = new Rectangle (size * _frames, size* _rij, size, size);
				}

			}

			if (_keyboard.IsKeyDown (Keys.Left))
			{
				_position -= new Vector2 (3, 0);
				_sourceRectangle = new Rectangle (size * _frames, size * _rij, size, size);


				if (_position.Y > 499) {
					_rij = 3;
					//					_sourceRectangle = new Rectangle (size * _frames, size * _rij, size, size);

				} else {
					_rij = 1;
					//					_sourceRectangle = new Rectangle (size * _frames, size* _rij, size, size);
				}


			}



			if (_position.Y < 0) 
			{
				_fly = new Vector2 (0, 0);
			}
			if (_position.Y < 500 && (_rij == 2 || _rij == 3)) 
			{
				_rij = 0;
			}
//			if (_position.Y > 499) 
//			{
//				_sourceRectangle = new Rectangle (size * 1, size* 3, size, size);
//				if (_keyboard.IsKeyDown(Keys.Left)){
//					_sourceRectangle = new Rectangle (size * 1, size* 2, size, size);
//				}
//
//			}

			if (_position.X > _game.GraphicsDevice.Viewport.Width /2 + 1) 
			{
				_position.X = _game.GraphicsDevice.Viewport.Width /2 + 1;
			}

			if (_position.X < _game.GraphicsDevice.Viewport.Width /8) 
			{
				_position.X = _game.GraphicsDevice.Viewport.Width /8;
			}


//			_position = new Vector2 (0,0);
		}
			

	}
}

