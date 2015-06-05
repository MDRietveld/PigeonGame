#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace PigeonGame
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		World _world;

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
			_world.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin ();
			_world.Draw (spriteBatch);
			spriteBatch.End ();
		}
	}
}

