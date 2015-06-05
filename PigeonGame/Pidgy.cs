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

		// PROPERTIES
		public Vector2 GetPosition ()
		{
			return _position;
		}

		public Pidgy (Game1 g, World w, Texture2D texture, Vector2 position) : base (g, w, texture, position)
		{

			_fly = new Vector2 (0, 1.5f);
			_gravity = new Vector2 (0, 2);
		}



		public void Update ()
		{
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
			}

			if (_keyboard.IsKeyDown (Keys.Left))
			{
				_position -= new Vector2 (3, 0);
			}

		}
			

	}
}

