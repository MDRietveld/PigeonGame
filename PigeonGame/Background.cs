using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	
	public class Background : GameObjects
	{
		// Vector2 _gameEnd;
		KeyboardState _keyboard;
		Vector2 _position;
		Game1 _game;
		Level _level;

		public Background (Game1 game, World w, Level l, Texture2D texture, Vector2 position) : base (game, w, l, texture, position)
		{
			_game = game;
			_level = l;
			_position = position;
		}

		public Vector2 GetPosition()
		{
			return _position;
		}

		public void Update(GameTime gameTime)
		{
			_keyboard = Keyboard.GetState ();
			if (_level.GetPidgyPosition().X > _game.GraphicsDevice.Viewport.Width/2 && _keyboard.IsKeyDown (Keys.Right) && _position.X > (_texture.Width * _level.Scaling() - _game.GraphicsDevice.Viewport.Width) *-1)
			{
				//_position -= new Vector2 (3, 0);
				_position -= new Vector2 (3, 0);
			}

			if (_level.GetPidgyPosition().X < _game.GraphicsDevice.Viewport.Width/8 && _keyboard.IsKeyDown (Keys.Left) && _position.X > 0)
			{
				_position += new Vector2 (3, 0);
			}


		}
			
	}
}

