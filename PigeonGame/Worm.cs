using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Worm : GameObjects
	{
		KeyboardState _keyboard;

		public Worm (Game1 g, World w, Texture2D tex, Vector2 pos, float scale) :base (g, w, tex, pos, scale)
		{
		}

		public Rectangle WormPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/12, _texture.Height/5/4);
		}

		public void Update(GameTime gameTime, Pidgy pidgy)
		{
			if (pidgy.PigeonPosition ().Intersects (WormPosition ())) {
				_position = new Vector2 (-100, -100);
				_world.MyScore.Update (gameTime);
			}

			_keyboard = Keyboard.GetState ();
			if (_world.GetPidgyPosition().X > _game.GraphicsDevice.Viewport.Width/2 && _keyboard.IsKeyDown (Keys.Right))
			{
				//_position -= new Vector2 (3, 0);
				_position -= new Vector2 (3, 0);
			}

			if (_world.GetPidgyPosition().X < _game.GraphicsDevice.Viewport.Width/8 && _keyboard.IsKeyDown (Keys.Left) && _position.X > 0)
			{
				_position += new Vector2 (3, 0);
			}

		}

	}
}

