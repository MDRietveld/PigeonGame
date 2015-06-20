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

		public Background _background;

		float _scale;
		float _gameh;
		float _texh;

		KeyboardState _keyboard;
		Menu _menu;
		bool _menuCheck;
		FontRenderer _fontRenderer;
		Level _level;
//		List<Enemy> _level1 = new List <Enemy>();

		Flag _flag;

		public World (Game1 g)
		{
			/**
			 * CLASSES
			 **/
			_flag = new Flag(this, new Vector2(800,100), Assets.Level1Map);
			_level = new Level (g, this);

			_background = new Background(g, this, Assets.Level1Map, new Vector2(0, 0));
			_menu = new Menu (g, Assets.MainScreen);

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
			_flag.Update (gameTime, _pidgy);
			_level.Update (gameTime, _pidgy);
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
				_flag.Draw (spriteBatch);

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

