using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Question
	{
		Texture2D 	_texture;
		Vector2 	_position;
		Rectangle 	_rectangle;
		Color 		_colour = new Color (255, 255, 255, 255);

		public Vector2 size;
			
		public Question (Texture2D tex, GraphicsDevice graphics)
		{
			_texture = Texture;

			size = new Vector2 (graphics.Viewport.Width / 8, graphics.Viewport.Height / 30);
		}

		bool down;
		public bool isClicked;
		public void Update (MouseState mouse)
		{
			Rectangle = new Rectangle ((int)_position.X, (int)_position.Y, (int)size.X, (int)size.Y);

			Rectangle mouseRectangle = new Rectangle (mouse.X, mouse.Y, 1, 1);

			if (mouseRectangle.Intersects (Rectangle)) 
			{
				if (_colour.A == 255) down = false;
				if (_colour.A == 0) down = true;
				if (down) _colour.A += 3; else _colour.A -= 3;
				if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
			}
			else if (_colour.A <255)
			{
				_colour.A += 3;
				isClicked = false;
			}
		}
		public void setPosition (Vector2 newPos)
		{
			_position = newPos;
		}

		public void DrawableGameComponent (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _rectangle, _colour);
		}

	}
}
 
