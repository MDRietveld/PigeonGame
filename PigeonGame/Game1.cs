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
		Pidgy _pidgy;
		Texture2D _pidgyTexture;
		Vector2 _pidgyPosition ;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;	

		}


		protected override void Initialize ()
		{
			base.Initialize ();
			_pidgyTexture = (this).Content.Load<Texture2D> ("Untitled");
			_pidgyPosition = new Vector2 (30, (this).GraphicsDevice.Viewport.Height - _pidgyTexture.Height - 30);

			_pidgy = new Pidgy ((this), _pidgyTexture, _pidgyPosition);
		}


		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);

		}

		protected override void Update (GameTime gameTime)
		{
			_pidgy.Update ();
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin ();
			_pidgy.Draw (spriteBatch);
			spriteBatch.End ();
		}
	}
}

