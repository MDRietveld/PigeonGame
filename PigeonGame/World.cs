using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using BmFont;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace PigeonGame
{
	public class World
	{

		/**
		 * PIGEON
		 **/
		Pidgy _pidgy;
		Vector2 _pidgyPosition;
		float _pidgyHeight;

		Background _background;

		float _scale;
		float _gameh;
		float _texh;

		KeyboardState _keyboard;
		Menu _menu;
		bool _menuCheck;
		FontRenderer _fontRenderer;
		Level _level;
//		List<Enemy> _level1 = new List <Enemy>();

		public World (Game1 g)
		{
			/**
			 * CLASSES
			 **/

			_level = new Level (g, this);

//			_level1.Add (new Eagle (g, this, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f));
//			_level1.Add (new Eagle (g, this, Assets.EagleTexture, new Vector2 (30, 20), 1, 0.2f));
//			_level1.Add (new Eagle (g, this, Assets.EagleTexture, new Vector2 (200, 150), 1, 0.2f));

			_background = new Background(g, this, Assets.Level1Map, new Vector2(0, 0));
			_menu = new Menu (g,Assets.MainScreen);

			/**
			 * POSITIONS
			 **/
			_gameh = g.GraphicsDevice.Viewport.Height;
			_texh = Assets.Level1Map.Height;

			_pidgyPosition = new Vector2 (g.GraphicsDevice.Viewport.Width/8, 500);
			_pidgy = new Pidgy (g, this, Assets.PigeonTexture, _pidgyPosition, Scaling());

			/**
			 * GENERATE FONT FROM FNT & _0.PNG FILE
			 * CREATE FONT
			 **/
			var fontFilePath = Path.Combine(g.Content.RootDirectory, "minecrafter.fnt");
			var fontFile = FontLoader.Load(fontFilePath);
			var fontTexture = Assets.FontTexture;
			_fontRenderer = new FontRenderer(fontFile, fontTexture);
		}
	
		public Vector2 GetPidgyPosition()
		{
			return _pidgy.GetPosition ();
		}

		public float PidgyHeight ()
		{
			return _pidgyHeight = 30* Scaling ();
		}

		public float Scaling()
		{
			return _scale = _gameh / _texh;
		}

		public void Update (GameTime gameTime)
		{
			_pidgy.Update (gameTime);
			_background.Update (gameTime);
			_level.Update (gameTime);
			//_eagle.Update (gameTime, _pidgy);


//			foreach (Enemy e in _level1) 
//			{
//				e.Update (gameTime);
//			}


			/*
			//Enemies sorteren per class, elke list toevoegen aan collision
			if(_pidgy.PigeonPosition().Intersects(_enemy.EaglePosition()))
			{
				Console.WriteLine ("Collission!");
			}
			if(_pidgy.PigeonPosition().Intersects(_enemy2.EaglePosition()))
			{
				Console.WriteLine ("Collission!");
			}
			if(_pidgy.PigeonPosition().Intersects(_enemy3.EaglePosition()))
			{
				Console.WriteLine ("Collission!");
			}*/
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			//spriteBatch.Draw (_menuScreenTexture, new Vector2 (50, 50), Color.White);
			_keyboard = Keyboard.GetState ();

			/**
			 * Menu Builder
			 **/

			// Check if menuCheck is false
			if (!_menuCheck) {
				if (_keyboard.IsKeyDown (Keys.Space)) {
					_menuCheck = true;
					Assets.Level1Song.Play ();
				} else {
					_menu.Draw (spriteBatch);
				}
			// Check if menuCheck is true
			} else if (_menuCheck) {
				// Put all the drawings here...

				// BACKGROUND DRAW
				_background.Draw (spriteBatch);

				// DRAW TEXT
				//_fontRenderer.DrawText (spriteBatch, 50, 50, "Druk op spatie om te starten");

				// PIGEON DRAW
				_pidgy.Draw (spriteBatch);

				// CREATE ENEMIES
				_level.Draw (spriteBatch);
//				foreach (Enemy e in _level1) 
//				{
//					e.Draw (spriteBatch);
//				}
			}
		}
	}
}

