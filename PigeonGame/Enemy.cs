
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	class Enemy
	{
		private Texture2D _enemyTexture;
		private Vector2 _myPosition;
		private int _speed;
		public Game1 g;

		public Enemy (Game1 g,Vector2 position, int speed)
		{
			_enemyTexture = g.Content.Load<Texture2D> ("enemy");
			_myPosition = position;
			_speed = speed;
		}
		public void Update ()
		{
			_myPosition.X += _speed;
			if (_myPosition.X + _enemyTexture.Width > 300 || _myPosition.X < 0) 
			{
				_speed *= -1;
			}
		}
		public void Draw (SpriteBatch batch){
			batch.Draw (_enemyTexture,_myPosition);
		}

	}
}
