﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	// Pigeon Character jhkj
	public class Pidgy
	{
		Game1 _game;
		Texture2D _texture;
		Vector2 _position;
		Vector2 _gravity;
		Vector2 _fly;
		KeyboardState _keyboard;
		Background _background;
		float _scale;

		public Pidgy (Game1 g, Texture2D texture, Vector2 position)
		{

			_game = g;
			_texture = texture;
			_position = position;
			_fly = new Vector2 (0, 1.5f);
			_gravity = new Vector2 (0, 2);
//			_scale = _background.Scaling () / 77;
		}



		public void Update ()
		{
			_position += _gravity;


			if (_position.Y > _game.GraphicsDevice.Viewport.Height - 30)// - _scale)
			{
				_position.Y = _game.GraphicsDevice.Viewport.Height - 30;// - _scale;
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



			if (_keyboard.IsKeyDown (Keys.Right))
			{
				_position += new Vector2 (3, 0);
			}

			if (_keyboard.IsKeyDown (Keys.Left))
			{
				_position -= new Vector2 (3, 0);
			}

		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (_texture, _position);
		}

	}
}
