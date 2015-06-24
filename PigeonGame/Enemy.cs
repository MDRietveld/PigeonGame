
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Enemy : GameObjects
	{
		Level _level;
		float _speed;
		float _elapsed;
		float _delay = 100;
		int _frames, _textureFrames, _rij, size_hor, size_ver, _kolom, _scaleX, _scaleY, _enemyMovement;
		float _time = 0;
		string _enemyClass;
		KeyboardState _keyboard;


		public Enemy (Game1 g, World w, Texture2D texture, Vector2 position, float speed, float scale, int scale_x, int scale_y, string enemyclass, int enemyMovement) : base (g, w, texture, position, scale)
		{
			_world = w;
			_speed = speed;
			_enemyClass = enemyclass;
			_enemyMovement = enemyMovement;

			_scaleX = scale_x;
			_scaleY = scale_y;

			size_hor = _texture.Width / _scaleX;
			size_ver = _texture.Height / _scaleY;

			_rij = 1;
			_kolom = 0;

			if (_enemyClass == "Boss") {
				_sourceRectangle = new Rectangle (0, 0, size_hor, size_ver);
			} else {
				_sourceRectangle = new Rectangle (size_hor * _kolom, size_ver * _rij, size_hor, size_ver);
			}
		}

		public Rectangle EnemyPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/_scaleX, _texture.Height/5/_scaleY);
		}
			
		public virtual void Update (GameTime gameTime, Pidgy pidgy)
		{

			_keyboard = Keyboard.GetState ();

			if (_enemyClass == "Boss") {
			} else {
				if (_world.GetPidgyPosition ().X > _game.GraphicsDevice.Viewport.Width / 2 && _keyboard.IsKeyDown (Keys.Right) && _position.X > (_texture.Width * _world.Scaling () - _game.GraphicsDevice.Viewport.Width) * -1) {
					//_position -= new Vector2 (3, 0);
					_position -= new Vector2 (3, 0);
				}

				if (_world.GetPidgyPosition ().X < _game.GraphicsDevice.Viewport.Width / 8 && _keyboard.IsKeyDown (Keys.Left) && _position.X > 0) {
					_position += new Vector2 (3, 0);
				}
			}


			if(pidgy.PigeonPosition().Intersects(EnemyPosition()))
			{
				_world.PidgyHitEnemy = true;
				Assets.GenerateNumber = Assets.Random.Next (1, 10);
				_position = new Vector2 (-100, -100);
				Console.WriteLine ("Collission!");
			}
				
			_elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			switch (_enemyClass) {
			case "Fox":
				_textureFrames = 10;
				break;
			case "Eagle":
				_textureFrames = 7;
				break;
			case "Gorilla":
				_textureFrames = 7;
				break;
			case "Kangeroo":
				_textureFrames = 1;

				break;
			}

			if (_enemyClass == "Boss") {
				_position.Y += _speed;

				_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

				if (_time >= 3000) {
					_speed *= -1;
					_time = 0;
				}
			}else{
				if (_elapsed >= _delay) {
					if (_frames >= _textureFrames) {
						_frames = 0;
					} else {
						_frames++;
					}
					_elapsed = 0;

				}
				_sourceRectangle = new Rectangle (size_hor * _frames, size_ver * _rij, size_hor, size_ver);


				_position.X += _speed;

				_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

				if (_time >= _enemyMovement*100) {
					/*
				_speed*= -1;
				_rij =1;
				*/
					_speed *= -1;
					_time = 0;

					if (_rij == 1) {
						_rij = 0;
					} else {
						_rij = 1;
					}
				}
			}
		}
	}
}