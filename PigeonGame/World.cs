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
		float _scale;
		float _gameh;
		float _texh;

		Game1 _game;
		KeyboardState _keyboard;
		Menu _menu;
		bool _menuCheck;
		FontRenderer _fontRenderer;
		Flag _flag;

		public Level level;
		public int LevelState = 0;
		public bool paused = false;

		public World (Game1 g)
		{
			/**
			 * CLASSES
			 **/
			_game = g;

			_flag = new Flag (this, new Vector2 (300, 528));
			level = new Level (_game, this);
			_menu = new Menu (_game, Assets.MainScreen);

			/**
			 * POSITIONS
			 **/
			_gameh = _game.GraphicsDevice.Viewport.Height;
			_texh = Assets.Level1Map.Height;

			_pidgyPosition = new Vector2 (_game.GraphicsDevice.Viewport.Width/8, 500);
			_pidgy = new Pidgy (_game, this, Assets.PigeonTexture, _pidgyPosition, Scaling());

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
			_keyboard = Keyboard.GetState ();

			_pidgy.Update (gameTime);
			_flag.Update (gameTime, _pidgy);
			level.Update (gameTime, _pidgy);

			if (_keyboard.IsKeyDown (Keys.Space)) {
				Assets.IntervalNewLevel = gameTime.TotalGameTime + TimeSpan.FromMilliseconds (3000);
			}

			if (_menuCheck) {
				if (gameTime.TotalGameTime >= Assets.IntervalNewLevel) {
					//Console.WriteLine ("DELAY IS OVER");
					Assets.LevelIntro = false;
				}	
			}

			if (paused) {
				switch (LevelState) {
				case 1:
					Assets.Level1SongInstance.Pause ();
					Console.WriteLine ("Song 1 Paused");
					break;
				case 2:
					Assets.Level2SongInstance.Pause	();
					Console.WriteLine ("Song 2 Paused");
					break;
				case 3:
					Assets.Level3SongInstance.Pause ();
					Console.WriteLine ("Song 3 Paused");
					break;
				case 4:
					Assets.Level4SongInstance.Pause ();
					Console.WriteLine ("Song 4 Paused");
					break;
				case 5:
					Assets.Level5SongInstance.Pause ();
					Console.WriteLine ("Song 5 Paused");
					break;
				}
			} else {
				switch (LevelState) {
				case 1:
					Assets.Level1SongInstance.Resume();
					break;
				case 2:
					Assets.Level2SongInstance.Resume();
					break;
				case 3:
					Assets.Level3SongInstance.Resume();
					break;
				case 4:
					Assets.Level4SongInstance.Resume();
					break;
				case 5:
					Assets.Level5SongInstance.Resume();
					break;
				}
			}
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			_keyboard = Keyboard.GetState ();

			/**
			 * Menu Builder
			 **/

			// Check if menuCheck is false
			if (!_menuCheck) {
				if (_keyboard.IsKeyDown (Keys.Space)) {
					_menuCheck = true;
					Assets.LevelIntro = true;
					this.LevelState = 1;
				} else {
					_menu.Draw (spriteBatch);
				}
			// Check if menuCheck is true
			} else if (_menuCheck) {
				// Put all the drawings here...

				/**
				 * Pause function
				 */
				_keyboard = Keyboard.GetState ();
				if (!paused) {
					//Console.WriteLine ("It's not Paused");
					if (_keyboard.IsKeyDown (Keys.P)) {
						paused = true;
						//Console.WriteLine ("Paused is set on True");
					}

					// BACKGROUND DRAW
					level._background.Draw (spriteBatch);

					// PIGEON DRAW
					_pidgy.Draw (spriteBatch);
					_flag.Draw (spriteBatch);

					// CREATE ENEMIES
					level.Draw (spriteBatch);

				} else if (paused) {
					spriteBatch.Draw(Assets.PauseScreen, new Vector2(40 ,_game.GraphicsDevice.Viewport.Height/4), Color.White);

					if (_keyboard.IsKeyDown (Keys.Escape)) {
						paused = false;
						//Console.WriteLine ("Paused is set on False");
					}
					//Console.WriteLine ("Paused is true");
				}
			}
		}
	}
}

