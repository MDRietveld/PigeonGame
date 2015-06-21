using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Flag
	{
		private World 		_world;
		private Level 		_level;
		private Texture2D 	_texture = Assets.Flag;
		private Vector2 	_position;
		private float		_scale;

		public Flag (World world, Vector2 position)
		{
			_world 		= world;
			_position 	= position;
			_scale 		= 0.2f;
		}

		public Rectangle FlagPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
		}

		public void Update (GameTime gameTime, Pidgy _pidgy)
		{
			if(_pidgy.PigeonPosition().Intersects(FlagPosition()))
			{
				Assets.LevelComplete = true;
				Assets.IntervalNewLevel = gameTime.TotalGameTime + TimeSpan.FromMilliseconds (3000);

				this._position.X += 100; // Tijdelijk gebruik om te testen of de levels werken //

				switch (_world.LevelState) {
				case 1:
					Assets.Level1SongInstance.Stop ();
					Assets.Level2SongInstance.Play ();

					_world.LevelState = 2;
					Console.WriteLine ("LEVEL 2");
					break;
				case 2:
					Assets.Level2SongInstance.Stop ();
					Assets.Level3SongInstance.Play ();

					_world.LevelState = 3;
					Console.WriteLine ("LEVEL 3");
					break;
				case 3:
					Assets.Level3SongInstance.Stop ();
					Assets.Level4SongInstance.Play ();

					_world.LevelState = 4;
					Console.WriteLine ("LEVEL 4");
					break;
				case 4:
					Assets.Level4SongInstance.Stop ();
					Assets.Level5SongInstance.Play ();

					_world.LevelState = 5;
					Console.WriteLine ("BOSS LEVEL");
					break;
				case 5:
				// GAME FINISHED
					break;
				}
			}

			//Console.WriteLine (_world._level._background.GetPosition().X);
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _position, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
		}
	}
}

