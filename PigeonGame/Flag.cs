using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Flag
	{
		private World 		_world;
		private Texture2D 	_texture = Assets.Flag, _level;
		private Vector2 	_position, _newPosition;
		private float		_scale;

		public Flag (World world, Vector2 position, Texture2D level)
		{
			_world 		= world;
			_level 		= level;
			_position 	= position;
			_scale 		= 0.2f;

			var _positionX = _level.Width - _position.X;
			var _positionY = _level.Height - _position.Y;

			_newPosition = new Vector2 (600, 0);
		}

		public Rectangle FlagPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
		}

		public void Update (GameTime gameTime, Pidgy _pidgy)
		{
			if(_pidgy.PigeonPosition().Intersects(FlagPosition()))
			{
				Console.WriteLine ("Finished");
			}

			Console.WriteLine (_world._background.GetPosition().X);
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _newPosition, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
		}
	}
}

