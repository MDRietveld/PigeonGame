﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	
	public class Background
	{
		Texture2D _texture;
		Vector2 _position;
		World _world;
		Game1 _game;
		float _scale;
		float _gameh;
		float _texh;
		KeyboardState _keyboard;


		public Background (Game1 game, World w, Texture2D texture)
		{
			_position = new Vector2(0, 0);
			_texture = texture;
			_game = game;
			_world = w;

			_gameh = game.GraphicsDevice.Viewport.Height;
			_texh = _texture.Height;

			_scale = _gameh / _texh;

		}


		public void Update(){
			_keyboard = Keyboard.GetState ();
			if (_world.GetPidgyPosition().X > _game.GraphicsDevice.Viewport.Width/2 && _keyboard.IsKeyDown (Keys.Right))
			{
				_position -= new Vector2 (3, 0);
			}

		}

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw (_texture, _position, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
		}
	}
}

