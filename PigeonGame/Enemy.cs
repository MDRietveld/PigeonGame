
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	public class Enemy : GameObjects
	{
		Game1 _game;
		int _speed;
		float _elapsed;
		float _delay = 100;
		int _frames, _textureFrames, _rij, size_hor, size_ver, _kolom, _scaleX, _scaleY;
		float _time = 0;
		string _enemyClass;

		public Enemy (Game1 g, World w, Texture2D texture, Vector2 position, int speed, float scale, int scale_x, int scale_y, string enemyclass) : base (g, w, texture, position, scale)
		{
			_game = g;
			_speed = speed;
			_enemyClass = enemyclass;

			_scaleX = scale_x;
			_scaleY = scale_y;

			size_hor = _texture.Width / _scaleX;
			size_ver = _texture.Height / _scaleY;

			_rij = 1;
			_kolom = 0;

			_sourceRectangle = new Rectangle (size_hor * _kolom, size_ver* _rij, size_hor, size_ver);
		}

		public Rectangle EnemyPosition()
		{
			return new Rectangle ((int)_position.X, (int)_position.Y, _texture.Width/5/_scaleX, _texture.Height/5/_scaleY);
		}
			
		public virtual void Update (GameTime gameTime, Pidgy pidgy)
		{
			if(pidgy.PigeonPosition().Intersects(EnemyPosition()))
			{
				_game.paused = true;
				Console.WriteLine ("Collission!");
			}
				
			_elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			switch (_enemyClass) {
			case "Fox":
				_textureFrames = 11;
				break;
			case "Eagle":
				_textureFrames = 7;	
				break;
			case "Gorilla":
				_textureFrames = 8;
				break;
			case "Kangeroo":
				_textureFrames = 2;
				break;
			}

			if (_elapsed >= _delay) 
			{
				if (_frames >= _textureFrames) {
					_frames = 0;
				} else {
					_frames++;
				}
				_elapsed = 0;

			}
			_sourceRectangle = new Rectangle (size_hor *_frames, size_ver* _rij, size_hor, size_ver);


			_position.X += _speed;

			_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (_time >= 3000) 
			{
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