using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Level
	{
		Game1 _game;
		List<Enemy> _level1 = new List <Enemy>();
		Vector2 _position;
		KeyboardState _keyboard;
		World _world;

		public Vector2 GetPosition()
		{
			return _position;
		}

		public Level (Game1 g, World world)
		{
			_position = new Vector2 (0, 0);
			_game = g;
			_world = world;

			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (30, 20), 1, 0.2f, 8, 2, "Eagle"));
			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (200, 150), 1, 0.2f, 8, 2, "Eagle"));
		}


		public void Update(GameTime gameTime, Pidgy pidgy) 
		{
			foreach (Enemy e in _level1) 
			{
				e.Update (gameTime, pidgy);
			}

			_keyboard = Keyboard.GetState ();
			if (_world.GetPidgyPosition().X > _game.GraphicsDevice.Viewport.Width/2 && _keyboard.IsKeyDown (Keys.Right) && _position.X > (Assets.Level1Map.Width * _world.Scaling() - _game.GraphicsDevice.Viewport.Width) *-1)
			{
				_position -= new Vector2 (3, 0);
			}

			if (_world.GetPidgyPosition().X < _game.GraphicsDevice.Viewport.Width/8 && _keyboard.IsKeyDown (Keys.Left) && _position.X > 0)
			{
				_position += new Vector2 (3, 0);
			}

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Enemy e in _level1) 
			{
				e.Draw (spriteBatch);
			}
		}


	}
}

