using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Level
	{
		Game1 _game;
		public Background _background;
		private Vector2 _offSetIntro;
		List<Enemy> _level1 = new List <Enemy>();
		List<Enemy> _level2 = new List <Enemy>();
		List<Enemy> _level3 = new List <Enemy>();
		List<Enemy> _level4 = new List <Enemy>();
		List<Enemy> _level5 = new List <Enemy>();
		Vector2 _position;
		KeyboardState _keyboard;
		World _world;

		public Vector2 GetPosition()
		{
			return _position;
		}

		public Level (Game1 g, World world)
		{
			_position = new Vector2 (0, 0);
			_offSetIntro = new Vector2 (0, -100);
			_game = g;
			_world = world;	
			_background = new Background(_game, _world, Assets.Level1Map, new Vector2(0, 0));

			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (30, 20), 1, 0.2f, 8, 2, "Eagle"));
			_level1.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (500, 500), 1, 0.2f, 11, 2, "Fox"));

			_level2.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level2.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (500, 500), 1, 0.2f, 11, 2, "Fox"));
			_level2.Add (new Enemy (_game, _world, Assets.GorillaTexture, new Vector2 (200, 150), 0, 0.2f, 8, 2, "Gorilla"));
			_level2.Add (new Enemy (_game, _world, Assets.KangerooTexture, new Vector2 (300, 50), 1, 0.2f, 2, 2, "Kangeroo"));

			_level3.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level3.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (30, 20), 1, 0.2f, 11, 2, "Fox"));
			_level3.Add (new Enemy (_game, _world, Assets.GorillaTexture, new Vector2 (200, 150), 0, 0.2f, 8, 2, "Gorilla"));
			_level3.Add (new Enemy (_game, _world, Assets.KangerooTexture, new Vector2 (300, 50), 1, 0.2f, 2, 2, "Kangeroo"));

			_level4.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level4.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (30, 20), 1, 0.2f, 11, 2, "Fox"));
			_level4.Add (new Enemy (_game, _world, Assets.GorillaTexture, new Vector2 (200, 150), 0, 0.2f, 8, 2, "Gorilla"));
			_level4.Add (new Enemy (_game, _world, Assets.KangerooTexture, new Vector2 (300, 50), 1, 0.2f, 2, 2, "Kangeroo"));
		}


		public void Update(GameTime gameTime, Pidgy pidgy) 
		{
			_background.Update (gameTime);

			if (Assets.LevelComplete) {
				Assets.LevelIntro = true;
				//Console.WriteLine (gameTime.TotalGameTime);
				//Console.WriteLine (Assets.IntervalNewLevel);
				if (gameTime.TotalGameTime >= Assets.IntervalNewLevel) {
					//Console.WriteLine ("DELAY IS OVER");
					Assets.LevelComplete = false;
					Assets.LevelIntro = false;
				}	
			} else {
				switch (_world.LevelState) {
				case 1:
					foreach (Enemy e in _level1) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 2:
					foreach (Enemy e in _level2) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 3:
					foreach (Enemy e in _level3) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 4:
					foreach (Enemy e in _level4) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 5:
					foreach (Enemy e in _level5) {
						e.Update (gameTime, pidgy);
					}
					break;
				}
			}
			_keyboard = Keyboard.GetState ();
			if (_world.GetPidgyPosition().X > _game.GraphicsDevice.Viewport.Width/2 && _keyboard.IsKeyDown (Keys.Right) && _position.X > (Assets.Level1Map.Width * _world.Scaling() - _game.GraphicsDevice.Viewport.Width) *-1)
			{
				_position -= new Vector2 (3, 0);
			}

			if (_world.GetPidgyPosition().X < _game.GraphicsDevice.Viewport.Width/8 && _keyboard.IsKeyDown (Keys.Left) && _position.X > 0)
			{
				_position += new Vector2 (3, 0);
			}

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (Assets.LevelIntro) {
				switch (_world.LevelState) {
				case 1:
					spriteBatch.Draw (Assets.Level1Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 2:
					spriteBatch.Draw (Assets.Level2Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 3:
					spriteBatch.Draw (Assets.Level3Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 4:
					spriteBatch.Draw (Assets.Level4Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 5:
					spriteBatch.Draw (Assets.Level5Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				}
			} else {
				switch (_world.LevelState) {
				case 1:
					_background = new Background (_game, _world, Assets.Level1Map, new Vector2 (0, 0));
					foreach (Enemy e in _level1) {
						e.Draw (spriteBatch);
					}
					break;
				case 2:
					_background = new Background (_game, _world, Assets.Level2Map, new Vector2 (0, 0));
					foreach (Enemy e in _level2) {
						e.Draw (spriteBatch);
					}
					break;
				case 3:
					_background = new Background (_game, _world, Assets.Level3Map, new Vector2 (0, 0));
					foreach (Enemy e in _level3) {
						e.Draw (spriteBatch);
					}
					break;
				case 4:
					_background = new Background (_game, _world, Assets.Level4Map, new Vector2 (0, 0));
					foreach (Enemy e in _level4) {
						e.Draw (spriteBatch);
					}
					break;
				case 5:
					_background = new Background (_game, _world, Assets.Level5Map, new Vector2 (0, 0));
					foreach (Enemy e in _level5) {
						e.Draw (spriteBatch);
					}
					break;
				}
			}
		}


	}
}

