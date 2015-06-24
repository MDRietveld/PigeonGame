#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using BmFont;
using System.IO;
using Microsoft.Xna.Framework.Media;

#endregion

namespace PigeonGame 
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		World _world;
		private KeyboardState _keyboard;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferHeight = 595;
			graphics.PreferredBackBufferWidth = 1000;

			IsMouseVisible = false;
		}


		protected override void Initialize ()
		{
			base.Initialize ();
			Assets.LoadContent (this);
			_world = new World (this);
		}


		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
		}

		protected override void Update (GameTime gameTime)
		{
			if (_world.TotalLife == 0 || _world.BossTotalLife == 0) {
				_keyboard = Keyboard.GetState ();

				if(_keyboard.IsKeyDown(Keys.Q)) {
					Quit();
				}
					
			} else {
				_world.Update (gameTime);
			}
		}


		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.Black);
			spriteBatch.Begin ();

			if (_world.TotalLife == 0) {
				spriteBatch.Draw (Assets.GameOverScreen, new Vector2 (0, 0), Color.White);
				spriteBatch.DrawString (Assets.Font, "Druk op Q om het spel te sluiten.", new Vector2 (325, 400), Color.White);
			} else if(_world.BossTotalLife == 0) {
				spriteBatch.Draw (Assets.FinalScreen, new Vector2 (0, 0), Color.White);
				spriteBatch.DrawString (Assets.Font, "Jou score : " + Assets.Score.ToString(), new Vector2 (380, 160), Color.Black);
			}else {
				_world.Draw (spriteBatch);
			}
			spriteBatch.End ();
		}

		public void Quit()
		{
			this.Exit ();
		}
	}
}

