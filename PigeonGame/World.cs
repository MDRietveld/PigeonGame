using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using BmFont;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class World
	{
		/**
		 * ENEMIES
		 **/
		private Enemy _enemy;
		private Enemy _enemy2;
		private Enemy _enemy3;
		Texture2D _enemyTex;

		/**
		 * PIGEON
		 **/
		Pidgy _pidgy;
		Vector2 _pidgyPosition;
		Texture2D _pidgyTexture;
		float _pidgyHeight;

		Background _background;
		Texture2D _bgTexture;

		float _scale;
		float _gameh;
		float _texh;

		KeyboardState _keyboard;
		Menu _menu;
		bool _menuCheck;
		Texture2D _menuScreenTexture;
		FontRenderer _fontRenderer;


		public World (Game1 g)
		{
			/** 
			 * TEXTURE LOAD
			 **/
			_menuScreenTexture = g.Content.Load<Texture2D> ("main");
			_enemyTex = g.Content.Load<Texture2D> ("enemy");
			_bgTexture = g.Content.Load<Texture2D> ("level_old");


			/**
			 * CLASSES
			 **/
			_enemy = new Enemy (g, this, _enemyTex, new Vector2 (100, 70), 1);
			_enemy2 = new Enemy (g, this, _enemyTex, new Vector2 (50, 20), 1);
			_enemy3 = new Enemy (g, this, _enemyTex, new Vector2 (200, 150), 1);
			_background = new Background(g, this, _bgTexture, new Vector2(0, 0));
			_menu = new Menu (g,_menuScreenTexture);

			/**
			 * POSITIONS
			 **/
			_gameh = g.GraphicsDevice.Viewport.Height;
			_texh = _bgTexture.Height;

			_pidgyTexture = g.Content.Load<Texture2D> ("Untitled");
			_pidgyPosition = new Vector2 (g.GraphicsDevice.Viewport.Width/8, g.GraphicsDevice.Viewport.Height - _pidgyTexture.Height - PidgyHeight());
			_pidgy = new Pidgy (g, this, _pidgyTexture, _pidgyPosition);

			/**
			 * GENERATE FONT FROM FNT & _0.PNG FILE
			 * CREATE FONT
			 **/
			var fontFilePath = Path.Combine(g.Content.RootDirectory, "minecrafter.fnt");
			var fontFile = FontLoader.Load(fontFilePath);
			var fontTexture = g.Content.Load<Texture2D>("minecrafter_0.png");
			_fontRenderer = new FontRenderer(fontFile, fontTexture);

		}
	
		public Vector2 GetPidgyPosition()
		{
			return _pidgy.GetPosition ();
		}

		public float PidgyHeight ()
		{
			return _pidgyHeight = 77* Scaling ();
		}

		public float Scaling()
		{
			return _scale = _gameh / _texh;
		}

		public void Update (GameTime gameTime)
		{
			_pidgy.Update (gameTime);
			_background.Update (gameTime);
			_enemy.Update (gameTime);
			_enemy2.Update (gameTime);
			_enemy3.Update (gameTime);
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
				_enemy.Draw (spriteBatch);
				_enemy2.Draw (spriteBatch);
				_enemy3.Draw (spriteBatch);
			}
		}
	}
}

