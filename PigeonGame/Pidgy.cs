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
		float _delay = 200;
		int _frames;
		int _rij;

		// PROPERTIES
		public Vector2 GetPosition ()
		{
			return _position;
		}

		public Pidgy (Game1 g, World w, Texture2D texture, Vector2 position) : base (g, w, texture, position)
		{

			_fly = new Vector2 (0, 1.5f);
			_gravity = new Vector2 (0, 2);

			/*
			int size = _texture.Width/12;
			_sourceRectangle = new Rectangle (size *1, size* _rij, size, size);
			_rij = 1;
			*/
		}
			

		public void Update (GameTime gameTime)
		{
			/*
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
			*/
			_position += _gravity;


			if (_position.Y > _game.GraphicsDevice.Viewport.Height - _texture.Height - _world.PidgyHeight())
			{
				_position.Y = _game.GraphicsDevice.Viewport.Height - _texture.Height - _world.PidgyHeight();
			}

			_keyboard = Keyboard.GetState ();

			if (_keyboard.IsKeyDown (Keys.Up)) {
				_fly.Y *= 1.05f;
				if (_fly.Y > 6) 
				{
					_fly.Y = 6;
				}
				_position.Y -= _fly.Y;
			} else {
				_fly = new Vector2 (0, 1.5f);
			}

			if (_position.Y < 0f) 
			{
				_fly = new Vector2 (0, 0);
			}

			if (_position.X > _game.GraphicsDevice.Viewport.Width /2 + 1) 
			{
				_position.X = _game.GraphicsDevice.Viewport.Width /2 + 1;
			}

			if (_position.X < _game.GraphicsDevice.Viewport.Width /8) 
			{
				_position.X = _game.GraphicsDevice.Viewport.Width /8;
			}


			if (_keyboard.IsKeyDown (Keys.Right))
			{
				_position += new Vector2 (3, 0);
				/*
				_rij = 1;
				_sourceRectangle = new Rectangle (size * _frames, size* _rij, size, size);
				*/
			}

			if (_keyboard.IsKeyDown (Keys.Left))
			{
				_position -= new Vector2 (3, 0);
				/*
				_rij = 2;
				_sourceRectangle = new Rectangle (size * _frames, size* _rij, size, size);
				*/
			}
		}
			

	}
}

