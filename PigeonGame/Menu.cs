using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BmFont;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Menu
	{
		private Game1 _game;
		private Texture2D _texture;
		private Color _color;
		private FontRenderer _fontRenderer;

		public Menu(Game1 g, Texture2D texture)
		{
			_game = g;
			_texture = texture;
			_color = Color.White;

			/**
			 * GENERATE FONT FROM FNT & _0.PNG FILE
			 * CREATE FONT
			 **/
			var fontFilePath = Path.Combine(g.Content.RootDirectory, "minecrafter.fnt");
			var fontFile = FontLoader.Load(fontFilePath);
			var fontTexture = Assets.FontTexture;
			_fontRenderer = new FontRenderer(fontFile, fontTexture);
		}

		public void Update (GameTime gameTime)
		{
			
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _game.GraphicsDevice.Viewport.Bounds, _color);
			_fontRenderer.DrawText (spriteBatch, _game.GraphicsDevice.Viewport.Width / 3, _game.GraphicsDevice.Viewport.Height - 150, "Druk Op Spatie om te starten");
		}
	}
}

