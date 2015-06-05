using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	public class GameObjects
	{
		protected Game1 _game;
		protected Texture2D _texture;
		protected Vector2 _position;
		protected World _world;
		protected float _scale;
		protected float _rotation;
		protected Color _color;
		protected Vector2 _origin;
		protected Rectangle _sourceRectangle;
		protected Rectangle _bounds;

		public Rectangle Bounds {
			get { 
				return new Rectangle(0,0,_texture.Width, _texture.Height); 
			}
		}

		public GameObjects (Game1 g, World w, Texture2D texture, Vector2 position)
		{
			_game = g;
			_world = w;
			_texture = texture;
			_position = position;


			_color = Color.White;
			_scale = 1;
			_rotation = 0;
			_origin = Vector2.Zero;

			_sourceRectangle = new Rectangle (0, 0, _texture.Width, _texture.Height);
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _position, _sourceRectangle,	_color, _rotation, _origin, _scale, SpriteEffects.None, 0f);
		}
	}
}

