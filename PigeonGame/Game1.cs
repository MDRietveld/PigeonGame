#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using BmFont;

#endregion

namespace PigeonGame
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		World _world;

		KeyboardState _keyboard;
		FontRenderer _fontRenderer;

		// Pause
		bool paused = false;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;

			graphics.PreferredBackBufferHeight = 595;
			graphics.PreferredBackBufferWidth = 1000;

			IsMouseVisible = true;
		}


		protected override void Initialize ()
		{
			base.Initialize ();
			_world = new World (this);
		}


		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
		}

		protected override void Update (GameTime gameTime)
		{
			/**
			 * Pause function
			 */

			if (!paused) {
				Console.WriteLine ("It's not Paused");
				if (_keyboard.IsKeyDown (Keys.Enter)) {
					paused = true;
					Console.WriteLine ("Paused is set on True");
				}
				_world.Update (gameTime);
			} else if (paused) {
				if (_keyboard.IsKeyDown (Keys.Escape)) {
					paused = false;
					Console.WriteLine ("Paused is set on False");
				}
				Console.WriteLine ("Paused is true");
			}
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin ();
			_world.Draw (spriteBatch);

			// If it's paused, write the text Paused
			if (paused) {
				_fontRenderer.DrawText (spriteBatch, 100, 100, "Paused");
			}

			spriteBatch.End ();
		}
	}
}

